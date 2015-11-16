using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using iPOS.Core.Logger;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using iPOS.Core.Helper;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using iPOS.DRO.Systems;

namespace iPOS.IMC.Helper
{
    public class ReportEngine
    {
        protected static ILogEngine logger = new LogEngine();
        private static string Temp = @"D:\Working\Hell Demons\iPOS\trunk\iPOS.FrontEnd\iPOS.Core\Template";

        public async static Task<bool> CheckValidImportTemplate(string username, string language_id, string store_procedure, string file_name, string module_id, string function_id, string file_path)
        {
            bool result = false;
            Excel.Application App = null;
            Excel.Workbook Book = null;
            Excel.Worksheet Sheet = null;
            Excel.Range Range = null;

            object Missing = System.Reflection.Missing.Value;
            try
            {
                SYS_tblImportFileConfigDRO tmpItem = await iPOS.BUS.Systems.SYS_tblImportFileConfigBUS.CheckValidImportTemplate(username, language_id, store_procedure, file_name, module_id, function_id);
                if (tmpItem != null && (tmpItem.ImportFileConfigItem != null && tmpItem.ImportFileConfigItem.ImportFileConfigID.ToString() != "0"))
                    result = true;
                else
                {
                    App = new Excel.Application();
                    Book = App.Workbooks.Open(file_path);
                    Sheet = (Excel.Worksheet)Book.Worksheets[1];
                    Range = Sheet.UsedRange;
                    int colCount = Range.Columns.Count;
                    int rowCount = Range.Rows.Count;

                    List<iPOS.DTO.Tools.OBJ_TableColumnDTO> objList = await iPOS.BUS.Tools.OBJ_TableColumnBUS.GetTableColumnList(username, store_procedure);
                    if (objList != null && objList.Count > 0)
                    {
                        int count = 0;
                        for (int i = 1; i <= colCount; i++)
                        {
                            if (string.IsNullOrEmpty(Sheet.Cells[2, i].Value + ""))
                                break;
                            string tmp = Sheet.Cells[2, i].Value.ToString().ToLower().Trim();
                            if (string.IsNullOrEmpty(tmp))
                                break;
                            if (tmp != "stt" && tmp != "seq" && tmp != "$hidecolumn$" && tmp != "$deletecolumn$")
                            {
                                tmp = "@" + tmp;
                                var objs = (from obj in objList
                                            where obj.ColumnName.ToLower().Equals(tmp.ToLower())
                                            select obj).ToList();
                                if (objs.Count == 0) count++;
                            }
                        }
                        //result = count < 3;
                        result = count == 0;    //!= 0 is different all
                    }
                    else result = false;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
            finally
            {
                if (App != null)
                    App.Quit();
                GC.Collect();
                if (Range != null)
                    Marshal.FinalReleaseComObject(Range);
                if (Sheet != null)
                    Marshal.FinalReleaseComObject(Sheet);
                if (Book != null)
                {
                    //Book.Close(true, Missing, Missing);
                    Marshal.FinalReleaseComObject(Book);
                }
                if (App != null)
                    Marshal.FinalReleaseComObject(App);
            }

            return result;
        }

        public async static void GetFileWithReportCaption(string username, string language_id, string template, string function_id, string module_id)
        {
            Excel.Application App = null;
            Excel.Workbook Book = null;
            Excel.Worksheet Sheet = null;
            Excel.Range Range = null;
            object Missing = System.Reflection.Missing.Value;
            string strFilePath = "";

            try
            {
                App = new Excel.Application();
                Book = App.Workbooks.Open(string.Format(@"{0}\{1}\{2}", Temp, module_id, template));
                Sheet = (Excel.Worksheet)Book.Worksheets[1];
                Range = Sheet.UsedRange;
                int rowCount = Range.Rows.Count;
                int colCount = Range.Columns.Count;

                SYS_tblReportCaptionDRO captionList = new SYS_tblReportCaptionDRO();
                captionList = await iPOS.BUS.Systems.SYS_tblReportCaptionBUS.GetReportCaption(username, language_id, function_id, true);
                if (!CommonEngine.CheckValidResponseItem(captionList.ResponseItem)) return;

                int index = 1;
                if (captionList != null && captionList.ReportCaptionList.Count > 0)
                {
                    Excel.Range cellRange;
                    SYS_tblReportCaptionDRO comboItems;

                    for (int i = 0; i < captionList.ReportCaptionList.Count; i++)
                    {
                        cellRange = Sheet.Cells.Find("$" + captionList.ReportCaptionList[i].ControlID + "$", Missing, Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlPart, Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlNext, false, Missing, false);
                        if (cellRange != null && cellRange.Cells.Count > 0)
                        {
                            cellRange.Replace("$" + captionList.ReportCaptionList[i].ControlID + "$", captionList.ReportCaptionList[i].Caption, Excel.XlLookAt.xlWhole, Excel.XlSearchOrder.xlByColumns, true, Missing, Missing, Missing);
                            int colIndex = cellRange.Cells.Column;
                            int rowIndex = cellRange.Cells.Row;

                            if (captionList.ReportCaptionList[i].IsComment)
                            {
                                cellRange.AddComment(captionList.ReportCaptionList[i].Comment);
                            }

                            if (captionList.ReportCaptionList[i].IsRequire)
                            {
                                cellRange.Font.Bold = true;
                                cellRange.Font.Color = Color.Red;
                            }

                            if (captionList.ReportCaptionList[i].IsList)
                            {
                                comboItems = new SYS_tblReportCaptionDRO();
                                comboItems = await iPOS.BUS.Systems.SYS_tblReportCaptionBUS.GetComboDynamicList(username, language_id, "", captionList.ReportCaptionList[i].TableName, "Code");
                                index++;
                                if (comboItems != null && comboItems.ComboDynamicList.Count > 0)
                                {
                                    Excel.Worksheet SheetData = null;
                                    if (index > Book.Worksheets.Count)
                                        SheetData = (Excel.Worksheet)Book.Worksheets.Add(Missing, index, Missing, Missing);
                                    else SheetData = (Excel.Worksheet)Book.Worksheets[index];
                                    SheetData.Name = captionList.ReportCaptionList[i].TableName;
                                    Excel.Range RangeData = SheetData.Range[SheetData.Cells[1, 1], SheetData.Cells[1, 2]];
                                    RangeData.Interior.Color = System.Drawing.Color.Yellow;
                                    RangeData.Font.Bold = true;
                                    RangeData.Font.Color = System.Drawing.Color.Red;
                                    SheetData.Cells[1, 1] = "Code";
                                    SheetData.Cells[1, 2] = "Name";

                                    for (int k = 0; k < comboItems.ComboDynamicList.Count; k++)
                                    {
                                        SheetData.Cells[k + 2, 1] = comboItems.ComboDynamicList[k].Code;
                                        SheetData.Cells[k + 2, 2] = comboItems.ComboDynamicList[k].Name;
                                    }

                                    RangeData = SheetData.Range[SheetData.Cells[1, 1], SheetData.Cells[comboItems.ComboDynamicList.Count + 1, 2]];
                                    RangeData.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                    Excel.Borders BorderData = RangeData.Borders;
                                    BorderData.LineStyle = Excel.XlLineStyle.xlContinuous;
                                    BorderData.Weight = 2d;
                                    RangeData.Columns.AutoFit();
                                    RangeData = Sheet.Range[Sheet.Cells[3, colIndex], Sheet.Cells[rowCount, colIndex]];
                                    RangeData.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, string.Format("={0}!$A$2:$A${1}", captionList.ReportCaptionList[i].TableName, comboItems.ComboDynamicList.Count + 1), Missing);
                                    Range.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                    RangeData.Validation.InCellDropdown = true;
                                }
                            }
                        }
                    }
                }
                Range.Columns.AutoFit();

                strFilePath = SaveExportCustom(Book, template, false);
                Book.Close(false, Missing, Missing);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return;
            }
            finally
            {
                App.Quit();
                Marshal.FinalReleaseComObject(Range);
                Marshal.FinalReleaseComObject(Sheet);
                Marshal.FinalReleaseComObject(Book);
                Marshal.FinalReleaseComObject(App);
                App = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();

                System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName("excel");
                foreach (System.Diagnostics.Process process in processes)
                {
                    if (process.MainWindowTitle.Length == 0)
                        process.Kill();
                }
            }

            System.Diagnostics.Process.Start(strFilePath);
        }

        public static string SaveExportCustom(Excel.Workbook Book, string report_name, bool isXlsFormat = false)
        {
            object Missing = System.Reflection.Missing.Value;
            string str = "";
            try
            {
                report_name = report_name.Remove(report_name.LastIndexOf('.'));

                SaveFileDialog sDialog = new SaveFileDialog();
                str = string.Format(@"{0}_{1}_{2}", report_name, DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"), DateTime.Now.Ticks);
                sDialog.Filter = isXlsFormat ? "Microsoft Excel (*.xls)|*.xls" : "Microsoft Excel 2007 (*.xlsx)|*.xlsx";
                sDialog.Title = LanguageEngine.GetMessageCaption("000007", ConfigEngine.Language);
                sDialog.InitialDirectory = Temp;
                sDialog.FileName = str;
                if (sDialog.ShowDialog() == DialogResult.OK)
                {
                    str = sDialog.FileName;
                    Book.SaveAs(str, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Missing, Missing, Missing, Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Missing, Missing, Missing, Missing, Missing);
                    CommonEngine.ShowMessage(ConfigEngine.Language.Equals("vi") ? "Tải tập tin mẫu thành công!" : "Download template success!", MessageType.Success);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return str;
        }

        public static string GetDataExcel(ref DataSet ds, string function_id, string file_path, string table_name, string sheet_name, ref string column_array)
        {
            string result = "", temp1 = "", temp2 = "";
            Excel.Application App = null;
            Excel.Workbook Book = null;
            Excel.Worksheet Sheet = null;
            Excel.Range Range = null;
            object Missing = System.Reflection.Missing.Value;

            try
            {
                if (!File.Exists(file_path))
                {
                    result = "File not exists!";
                }
                else
                {
                    App = new Excel.Application();
                    Book = App.Workbooks.Open(file_path);
                    Sheet = (Excel.Worksheet)Book.Worksheets[1];
                    DataTable dt = new DataTable();
                    dt.TableName = table_name;
                    Range = Sheet.UsedRange;
                    int endCol = Range.Columns.Count;
                    int endRow = Range.Rows.Count;
                    int emptyCount = 0;

                    try
                    {
                        //Default skip seq (STT) column
                        for (int i = 2; i <= endCol; i++)
                        {
                            string temp3 = "";
                            if (Sheet.Cells[1, i].Value != null)
                            {
                                temp3 = Sheet.Cells[1, i].Value + "";
                                if (temp1.IndexOf(temp3 + "|") > 0)
                                    temp2 = "Duplicate: " + temp3;
                                temp1 += temp3 + "|";
                            }
                            dt.Columns.Add(new DataColumn(temp3, typeof(string)));
                        }
                        dt.Columns.Add(new DataColumn("Return Message", typeof(string)));

                        for (int j = 2; j <= endRow; j++)
                        {
                            DataRow dr = dt.NewRow();
                            emptyCount = 0;
                            for (int i = 2; i <= endCol; i++)
                            {
                                string value = Sheet.Cells[j, i].Value != null ? Sheet.Cells[j, i].Value + "" : "";
                                if (j == 2) column_array += value + "|";
                                else if (string.IsNullOrEmpty(value)) emptyCount++;

                                if (Sheet.Cells[j, i].Value != null && Sheet.Cells[j, i].Value.GetType().Equals(typeof(DateTime)))
                                    value = ((DateTime)Sheet.Cells[j, i].Value).ToString(ConfigEngine.DateTimeFormat);
                                dr[i - 2] = value;
                            }
                            emptyCount += 1;
                            if (j > 2 && emptyCount != endCol) dt.Rows.Add(dr);
                        }

                        Excel.Range cellRange = null;
                        cellRange = Sheet.Cells.Find("$HideColumn$", Missing, Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlPart, Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlNext, false, Missing, false);
                        int num = 0;
                        string column = "";
                        while (cellRange != null)
                        {
                            cellRange = Sheet.Cells.Find("$HideColumn$", Missing, Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlPart, Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlNext, false, Missing, false);
                            dt.Columns.RemoveAt(cellRange.Columns.Count - num - 1);
                            column = Sheet.Cells[1, cellRange.Columns.Count].Value;
                            column_array = column_array.Replace(column + "|", "");
                            Sheet.Cells[1, cellRange.Columns.Count] = "";
                            num++;
                        };

                        ds.Tables.Add(dt);
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                result = ex.Message;
            }
            finally
            {
                App.Quit();
                GC.Collect();
                Marshal.FinalReleaseComObject(Range);
                Marshal.FinalReleaseComObject(Sheet);
                Marshal.FinalReleaseComObject(Book);
                Marshal.FinalReleaseComObject(App);
            }

            return result;
        }
    }
}
