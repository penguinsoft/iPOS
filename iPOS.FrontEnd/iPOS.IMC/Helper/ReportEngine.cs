using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using Aspose.Cells;
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

        public static void SaveExportCustom(Workbook wb, string report_name, bool isXlsFormat)
        {
            try
            {
                report_name = report_name.Remove(report_name.LastIndexOf('.'));
                SaveOptions saveOptions = new XlsSaveOptions(isXlsFormat ? SaveFormat.Excel97To2003 : SaveFormat.Xlsx);
                
                SaveFileDialog sDialog = new SaveFileDialog();
                string str = string.Format(@"{0}_{1}_{2}", report_name, DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"), DateTime.Now.Ticks);
                sDialog.Filter = isXlsFormat ? "Microsoft Excel (*.xls)|*.xls" : "Microsoft Excel 2007 (*.xlsx)";
                sDialog.Title = LanguageEngine.GetMessageCaption("000007", ConfigEngine.Language);
                sDialog.InitialDirectory = Temp;
                sDialog.FileName = str;
                if (sDialog.ShowDialog() == DialogResult.OK)
                {
                    wb.Save(sDialog.FileName, saveOptions);
                    DeleteAsposeWorksheet(sDialog.FileName);
                    CommonEngine.ShowMessage(ConfigEngine.Language.Equals("vi") ? "Tải tập tin mẫu thành công!" : "Download template success!", MessageType.Success);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return;
            }
        }

        public static void DeleteAsposeWorksheet(string file_path)
        {
            object missing = Type.Missing;
            Excel.Application oXL = null;
            Excel.Workbooks oWBs = null;
            Excel.Workbook oWB = null;
            Excel.Worksheet oSheet = null;
            Excel.Range oCells = null;
            try
            {
                oXL = new Excel.Application();
                oXL.Visible = false;

                oWBs = oXL.Workbooks;
                oWB = oWBs.Open(file_path, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);

                oSheet = oWB.ActiveSheet as Excel.Worksheet;
                oSheet.Name = "Sheet " + oWB.Worksheets.Count;
                oCells = oSheet.Cells;
                oCells[5, 1] = "";

                oSheet = oWB.Worksheets[1] as Excel.Worksheet;
                ((Excel._Worksheet)oSheet).Activate();

                oWB.Save();
                oWB.Close(missing, missing, missing);
                oXL.UserControl = true;
                oXL.Quit();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return;
            }
            finally
            {
                if (oCells != null)
                {
                    Marshal.FinalReleaseComObject(oCells);
                    oCells = null;
                }
                if (oSheet != null)
                {
                    Marshal.FinalReleaseComObject(oSheet);
                    oSheet = null;
                }
                if (oWB != null)
                {
                    Marshal.FinalReleaseComObject(oWB);
                    oWB = null;
                }
                if (oWBs != null)
                {
                    Marshal.FinalReleaseComObject(oWBs);
                    oWBs = null;
                }
                if (oXL != null)
                {
                    Marshal.FinalReleaseComObject(oXL);
                    oXL = null;
                }
            }
        }

        public static void LoadReportCaption(string template_name, string function_id)
        {

        }

        public async static Task<bool> CheckValidImportTemplate(string username, string language_id, string store_procedure, string file_name, string module_id, string function_id, string file_path)
        {
            bool result = false;
            Excel.Application App = null;
            Excel.Workbook Book = null;
            Excel.Worksheet Sheet = null;

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
                    int colCount = Sheet.Columns.Count;
                    int rowCount = Sheet.Rows.Count;

                    List<iPOS.DTO.Tools.OBJ_TableColumnDTO> objList = await iPOS.BUS.Tools.OBJ_TableColumnBUS.GetTableColumnList(username, store_procedure);
                    if (objList != null && objList.Count > 0)
                    {
                        int count = 0;
                        for (int i = 1; i <= colCount; i++)
                        {
                            if (string.IsNullOrEmpty(Sheet.Cells[1, i].Value + ""))
                                break;
                            string tmp = Sheet.Cells[1, i].Value.ToString().ToLower().Trim();
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
                        result = count < 3;
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
                Marshal.FinalReleaseComObject(Sheet);
                Marshal.FinalReleaseComObject(Book);
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
                    string str = "";
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

                                    str = "";
                                    for (int k = 0; k < comboItems.ComboDynamicList.Count; k++)
                                    {
                                        SheetData.Cells[k + 2, 1] = comboItems.ComboDynamicList[k].Code;
                                        SheetData.Cells[k + 2, 2] = comboItems.ComboDynamicList[k].Name;
                                        str += comboItems.ComboDynamicList[k].Code + ",";
                                    }
                                    str = str.Substring(0, str.Length - 1);

                                    RangeData = SheetData.Range[SheetData.Cells[1, 1], SheetData.Cells[comboItems.ComboDynamicList.Count + 1, 2]];
                                    RangeData.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                    Excel.Borders BorderData = RangeData.Borders;
                                    BorderData.LineStyle = Excel.XlLineStyle.xlContinuous;
                                    BorderData.Weight = 2d;
                                    RangeData.Columns.AutoFit();

                                    RangeData = Sheet.Range[Sheet.Cells[3, colIndex], Sheet.Cells[rowCount, colIndex]];
                                    RangeData.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, str, Missing);
                                    Range.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                    RangeData.Validation.InCellDropdown = true;
                                }
                            }
                        }
                        //TopRange.Replace("$" + captionList.ReportCaptionList[i].ControlID + "$", captionList.ReportCaptionList[i].Caption, Excel.XlLookAt.xlWhole, Excel.XlSearchOrder.xlByColumns, true, Missing, Missing, Missing);
                        if (captionList.ReportCaptionList[i].IsList)
                        {
                            
                        }
                    }
                }
                Range.Columns.AutoFit();

                App.Visible = true;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return;
            }
            finally
            {
                Marshal.FinalReleaseComObject(Sheet);
                Marshal.FinalReleaseComObject(Book);
                Marshal.FinalReleaseComObject(App);
            }
        }

        //public async static void GetFileWithReportCaption(string username, string language_id, string template, string function_id, string module_id)
        //{
        //    try
        //    {
        //        SYS_tblReportCaptionDRO captionList = await iPOS.BUS.Systems.SYS_tblReportCaptionBUS.GetReportCaption(username, language_id, function_id, true);
        //        Workbook wb = new Workbook(string.Format(@"{0}\{1}\{2}", Temp, module_id, template));
        //        Worksheet ws = wb.Worksheets[0];
        //        int index = 0;
        //        int count = wb.Worksheets.Count;
        //        if (captionList != null && captionList.ReportCaptionList.Count > 0)
        //        {
        //            FindOptions findOptions = new FindOptions
        //            {
        //                LookInType = LookInType.Values,
        //                LookAtType = LookAtType.EntireContent
        //            };

        //            for (int i = 0; i < captionList.ReportCaptionList.Count; i++)
        //            {
        //                Cell cell = ws.Cells.Find("$" + captionList.ReportCaptionList[i].ControlID + "$", null, findOptions);
        //                if (cell != null)
        //                {
        //                    int column = cell.Column;
        //                    ws.Replace("$" + captionList.ReportCaptionList[i].ControlID + "$", captionList.ReportCaptionList[i].Caption);
        //                    if (captionList.ReportCaptionList[i].IsList)
        //                    {
        //                        string tmp = "";
        //                        tmp = ws.Cells[cell.Row + 1, column].Value + "";
        //                        SYS_tblReportCaptionDRO comboItems = await iPOS.BUS.Systems.SYS_tblReportCaptionBUS.GetComboDynamicList(username, language_id, "", captionList.ReportCaptionList[i].TableName, "Code");
        //                        index++;
        //                        if (comboItems != null && comboItems.ComboDynamicList.Count > 0)
        //                        {
        //                            wb.Worksheets[index].Name = captionList.ReportCaptionList[i].TableName;
        //                            Worksheet ws1 = wb.Worksheets[index];
        //                            ws1.Cells.ImportDataTable(iPOS.Core.Helper.ConvertEngine.ConvertObjectListToDataTable<iPOS.DTO.Systems.ComboDynamicItemDTO>(comboItems.ComboDynamicList), true, 0, 0, true, false);
        //                            Range range = ws1.Cells.CreateRange(1, 0, comboItems.ComboDynamicList.Count, 1);
        //                            range.Name = tmp;
        //                            for (int j = 0; j < comboItems.ComboDynamicList.Count; j++)
        //                            {
        //                                iPOS.Core.Extensions.AsposeCellsStyle.Cells.BackgroundColor(ws1.Cells[0, j], Color.Yellow);
        //                                iPOS.Core.Extensions.AsposeCellsStyle.Cells.Font.Color(ws1.Cells[0, j], Color.Red);
        //                            }
        //                            ws1.AutoFitColumns();
        //                        }
        //                        CellArea cellArea = new CellArea
        //                        {
        //                            StartRow = 2,
        //                            EndRow = ws.Cells.MaxRow,
        //                            StartColumn = cell.Column,
        //                            EndColumn = cell.Column
        //                        };
        //                        ValidationCollection validations = ws.Validations;
        //                        Validation validation = validations[validations.Add(cellArea)];
        //                        validation.Type = ValidationType.List;
        //                        validation.Operator = OperatorType.None;
        //                        validation.InCellDropDown = true;
        //                        validation.Formula1 = "=" + tmp;
        //                        validation.ShowError = false;
        //                        validation.AreaList.Add(cellArea);
        //                    }
        //                }
        //                if (captionList.ReportCaptionList[i].IsRequire)
        //                    iPOS.Core.Extensions.AsposeCellsStyle.Cells.Font.Color(cell, Color.Red);
        //            }
        //            SaveExportCustom(wb, template, true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex);
        //        return;
        //    }
        //}
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
                            for (int i = 2; i <= endCol ; i++)
                            {
                                string value = Sheet.Cells[j, i].Value != null ? Sheet.Cells[j, i].Value + "" : "";
                                if (j == 2) column_array += value + "|";
                                if (Sheet.Cells[j, i].Value != null && Sheet.Cells[j, i].Value.GetType().Equals(typeof(DateTime)))
                                    value = ((DateTime)Sheet.Cells[j, i].Value).ToString(ConfigEngine.DateTimeFormat);
                                dr[i - 2] = value;
                            }

                            if (j > 2) dt.Rows.Add(dr);
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
                Marshal.FinalReleaseComObject(Sheet);
                Marshal.FinalReleaseComObject(Book);
                Marshal.FinalReleaseComObject(App);
            }

            return result;
        }

        public static int GetEndColumn(Worksheet ws)
        {
            int num = 0;
            while (true)
            {
                string temp = "";
                temp = (ws.Cells[1, num].Value == null) ? "" : ws.Cells[1, num].Value + "";
                if (temp == "")
                    break;

                num++;
            }

            return num;
        }

        public static int GetEndRow(Worksheet ws)
        {
            int num = 2;
            while (true)
            {
                string temp = "";
                temp = ws.Cells[num, 0].Value == null ? "" : ws.Cells[num, 0].Value + "";
                if (temp == "")
                    break;

                num++;
            }

            return num;
        }
    }
}
