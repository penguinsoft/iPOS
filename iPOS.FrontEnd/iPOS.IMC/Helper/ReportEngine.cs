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

namespace iPOS.IMC.Helper
{
    public class ReportEngine
    {
        protected static ILogEngine logger = new LogEngine();
        private static string Temp = @"D:\Working\Hell Demons\iPOS_Old\trunk\iPOS\iPOS_Old\iPOS.Management\Template";

        public static void SaveExportCustom(Workbook wb, string report_name, bool isXlsFormat)
        {
            try
            {
                report_name = report_name.Remove(report_name.LastIndexOf('.'));
                SaveOptions saveOptions = new XlsSaveOptions(isXlsFormat ? SaveFormat.Excel97To2003 : SaveFormat.Xlsx);
                wb.Worksheets.RemoveAt(wb.Worksheets.Count - 1);
                string str = string.Format(@"{0}\{1}_{2}_{3}.{4}", Temp, report_name, DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"), DateTime.Now.Ticks, isXlsFormat ? "xls" : "xlsx");
                wb.Save(str, saveOptions);
                DeleteAsposeWorksheet(str);
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

        public async static Task<bool> CheckValidImportTemplate(string username, string language_id, string store_procedure, string file_name, string module_id, string function_id, Worksheet ws)
        {
            bool result = false;
            try
            {
                iPOS.DTO.Systems.SYS_tblImportFileConfigDTO tmpItem = await iPOS.BUS.Systems.SYS_tblImportFileConfigBUS.CheckValidImportTemplate(username, language_id, store_procedure, file_name, module_id, function_id);
                if (tmpItem != null && !string.IsNullOrEmpty(tmpItem.ImportFileConfigID + ""))
                    result = true;
                else
                {
                    List<iPOS.DTO.Tools.OBJ_TableColumnDTO> objList = await iPOS.BUS.Tools.OBJ_TableColumnBUS.GetTableColumnList(username, store_procedure);
                    if (objList != null && objList.Count > 0)
                    {
                        int count = 0;
                        for (int i = 0; i < ws.Cells.MaxColumn; i++)
                        {
                            if (string.IsNullOrEmpty(ws.Cells[1, i].Value + ""))
                                break;
                            string tmp = ws.Cells[1, i].Value.ToString().ToLower().Trim();
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

            return result;
        }

        public async static void GetFileWithReportCaption(string username, string language_id, string template, string function_id, string module_id)
        {
            try
            {
                List<iPOS.DTO.Systems.SYS_tblReportCaptionDTO> captionList = await iPOS.BUS.Systems.SYS_tblReportCaptionBUS.GetReportCaption(username, language_id, function_id, true);
                Workbook wb = new Workbook(string.Format(@"{0}\{1}\{2}", Temp, module_id, template));
                Worksheet ws = wb.Worksheets[0];
                int index = 0;
                int count = wb.Worksheets.Count;
                if (captionList != null && captionList.Count > 0)
                {
                    FindOptions findOptions = new FindOptions
                    {
                        LookInType = LookInType.Values,
                        LookAtType = LookAtType.EntireContent
                    };

                    for (int i = 0; i < captionList.Count; i++)
                    {
                        Cell cell = ws.Cells.Find("$" + captionList[i].ControlID + "$", null, findOptions);
                        if (cell != null)
                        {
                            int column = cell.Column;
                            ws.Replace("$" + captionList[i].ControlID + "$", captionList[i].Caption);
                            if (captionList[i].IsList)
                            {
                                string tmp = "";
                                tmp = ws.Cells[cell.Row + 1, column].Value + "";
                                List<iPOS.DTO.Systems.ComboDynamicItemDTO> comboItems = await iPOS.BUS.Systems.SYS_tblReportCaptionBUS.GetComboDynamicList(username, language_id, "", captionList[i].TableName, "Code");
                                index++;
                                if (comboItems != null && comboItems.Count > 0)
                                {
                                    wb.Worksheets[index].Name = captionList[i].TableName;
                                    Worksheet ws1 = wb.Worksheets[index];
                                    ws1.Cells.ImportDataTable(iPOS.Core.Helper.ConvertEngine.ConvertObjectListToDataTable<iPOS.DTO.Systems.ComboDynamicItemDTO>(comboItems), true, 0, 0, true, false);
                                    Range range = ws1.Cells.CreateRange(1, 0, comboItems.Count, 1);
                                    range.Name = tmp;
                                    for (int j = 0; j < comboItems.Count; j++)
                                    {
                                        iPOS.Core.Extensions.AsposeCellsStyle.Cells.BackgroundColor(ws1.Cells[0, j], Color.Yellow);
                                        iPOS.Core.Extensions.AsposeCellsStyle.Cells.Font.Color(ws1.Cells[0, j], Color.Red);
                                    }
                                    ws1.AutoFitColumns();
                                }
                                CellArea cellArea = new CellArea
                                {
                                    StartRow = 2,
                                    EndRow = ws.Cells.MaxRow,
                                    StartColumn = cell.Column,
                                    EndColumn = cell.Column
                                };
                                ValidationCollection validations = ws.Validations;
                                Validation validation = validations[validations.Add(cellArea)];
                                validation.Type = ValidationType.List;
                                validation.Operator = OperatorType.None;
                                validation.InCellDropDown = true;
                                validation.Formula1 = "=" + tmp;
                                validation.ShowError = false;
                                validation.AreaList.Add(cellArea);
                            }
                        }
                        if (captionList[i].IsRequire)
                            iPOS.Core.Extensions.AsposeCellsStyle.Cells.Font.Color(cell, Color.Red);
                    }
                    SaveExportCustom(wb, template, true);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return;
            }
        }

        public static string GetDataExcel(ref DataSet ds, string function_id, string file_path, string table_name, string sheet_name, ref string column_array)
        {
            string result = "", temp1 = "", temp2 = "";
            try
            {
                if (!File.Exists(file_path))
                    result = "File not exists!";
                else
                {
                    Workbook wb = new Workbook(file_path);
                    Worksheet ws = wb.Worksheets[sheet_name];
                    DataTable dt = new DataTable();
                    dt.TableName = table_name;
                    int endCol = GetEndColumn(ws);
                    int endRow = GetEndRow(ws);

                    try
                    {
                        for (int i = 1; i < endCol; i++)
                        {
                            string temp3 = "";
                            if (ws.Cells[0, i].Value != null)
                            {
                                temp3 = ws.Cells[0, i].Value.ToString().Trim();
                                if (temp1.IndexOf(temp3 + "|") > 0)
                                    temp2 = "Trùng header: " + temp3;
                                temp1 += temp3 + "|";
                            }
                            dt.Columns.Add(new DataColumn(temp3, typeof(string)));
                        }
                        dt.Columns.Add(new DataColumn("Return Message", typeof(string)));

                        for (int j = 1; j < endRow; j++)
                        {
                            DataRow dr = dt.NewRow();
                            for (int i = 1; i < endCol; i++)
                            {
                                string value = ws.Cells[j, i].Value == null ? "" : ws.Cells[j, i].Value.ToString().Trim();
                                if (j == 1) column_array += value + "|";
                                if (ws.Cells[j, i].Value != null && ws.Cells[j, i].Value.GetType().Equals(typeof(DateTime)))
                                    value = ((DateTime)ws.Cells[j, i].Value).ToString(ConfigEngine.DateTimeFormat);
                                dr[i - 1] = value;
                            }

                            if (j > 1) dt.Rows.Add(dr);
                        }

                        int num = 0;
                        FindOptions findOptions = new FindOptions
                        {
                            LookAtType = LookAtType.EntireContent,
                            LookInType = LookInType.Values
                        };
                        while (ws.Cells.Find("$HideColumn$", null, findOptions) != null)
                        {
                            Cell cell = ws.Cells.Find("$HideColumn$", null, findOptions);
                            dt.Columns.RemoveAt(cell.Column - num);
                            cell.PutValue("");
                            num++;
                        }

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
                logger.Error(ex);
                result = ex.Message;
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
