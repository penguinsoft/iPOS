using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraTabbedMdi;
using iPOS.Core.Helper;
using iPOS.Core.Logger;
using System.Runtime.Serialization;
using ConfigEngine = iPOS.Core.Helper.ConfigEngine;
using DevExpress.XtraGrid.Views.Grid;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace iPOS.IMC.Helper
{
    public class CommonEngine
    {
        public static iPOS.DTO.Systems.SYS_tblUserDTO userInfo;
        public static DateTime SystemDateTime;
        protected static ILogEngine logger = new LogEngine();

        public static void ShowMessage(string message, byte type)
        {
            string title = "";
            title = LanguageEngine.GetMessageCaption((type == 0) ? "ERROR_TITLE_CAPTION" : "MESSAGE_TITLE_CAPTION", ConfigEngine.Language);
            if (type == 0)
                logger.Error(message);
            XtraMessageBox.Show(message, title, MessageBoxButtons.OK, (type == 1) ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }

        public static void ShowExceptionMessage(Exception ex)
        {
            logger.Error(ex);
            XtraMessageBox.Show(ex.Message, LanguageEngine.GetMessageCaption("ERROR_SYSTEM_TITLE_CAPTION", ConfigEngine.Language), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool ShowConfirmMessageAlert(string message)
        {
            if (XtraMessageBox.Show(message, ConfigEngine.Language == "vi" ? "Thông Báo" : "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                return true;
            return false;
        }

        public static void OpenInputForm(XtraUserControl uc, Size size)
        {
            frmOpen frm = new frmOpen();
            frm.Text = LanguageEngine.GetOpenFormText(uc.Name, ConfigEngine.Language);
            frm.Size = size;
            frm.MaximumSize = size;
            frm.MinimumSize = size;
            frm.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            frm.Controls.Add(uc);
            uc.Show();
            frm.ShowDialog();
        }

        public static void OpenInputForm(XtraUserControl uc, Size size, bool isEdit)
        {
            frmOpen frm = new frmOpen();
            string temp = "";
            if (isEdit)
                temp = (ConfigEngine.Language == "vi") ? "Cập Nhật" : "Update";
            else temp = (ConfigEngine.Language == "vi") ? "Thêm Mới" : "Add New";
            frm.Text = string.Format("{0} {1}", temp, LanguageEngine.GetOpenFormText(uc.Name, ConfigEngine.Language));
            frm.Size = size;
            frm.MaximumSize = size;
            frm.MinimumSize = size;
            frm.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            frm.Controls.Add(uc);
            uc.Show();
            frm.ShowDialog();
        }

        public static void OpenImportExcelForm(string template_name, string store_procedure, string module_id, string function_id)
        {
            OpenInputForm(new iPOS.IMC.Tool.uc_ImportExcel(template_name, store_procedure, module_id, function_id), new Size(900, 600));
        }

        public static void OpenMdiChildForm(RibbonForm index, XtraUserControl uc, XtraTabbedMdiManager tab)
        {
            bool found = false;
            foreach(XtraForm frm in index.MdiChildren)
                if (frm.Name.Equals(uc.Name))
                {
                    found = true;
                    break;
                }

            if (found)
            {
                foreach (XtraMdiTabPage _tab in tab.Pages)
                    if (_tab.Text.ToLower().Equals(LanguageEngine.GetOpenFormText(uc.Name, ConfigEngine.Language).ToLower()))
                    {
                        tab.SelectedPage = _tab;
                        break;
                    }
            }
            else
            {
                XtraForm frm = new XtraForm();
                frm.Text = LanguageEngine.GetOpenFormText(uc.Name, ConfigEngine.Language);
                frm.Name = uc.Name;
                frm.MdiParent = index;
                uc.Dock = DockStyle.Fill;
                frm.Controls.Clear();
                frm.Controls.Add(uc);
                frm.Show();
            }
        }

        public static void ChangeDateTimeActionToCurrentData<T>(IEnumerable<T> item, BarStaticItem[] bar_static_items)
        {
            try
            {
                DataRow temp = ConvertEngine.ConvertObjectListToDataRow<T>(item);
                if (temp != null)
                {
                    bar_static_items[0].Visibility = bar_static_items[1].Visibility = bar_static_items[2].Visibility = bar_static_items[3].Visibility = BarItemVisibility.Always;
                    bar_static_items[1].Caption = string.Format(@"<b><color=RED>{0}</color></b>", temp["Creater"]);
                    bar_static_items[3].Caption = string.Format(@"<b><color=RED>{0}</color></b>", Convert.ToDateTime(temp["CreateTime"] + "").ToString(ConfigEngine.DateTimeFormat));
                    if (!string.IsNullOrEmpty(temp["Editer"] + ""))
                    {
                        bar_static_items[4].Visibility = bar_static_items[5].Visibility = bar_static_items[6].Visibility = bar_static_items[7].Visibility = BarItemVisibility.Always;
                        bar_static_items[5].Caption = string.Format(@"<b><color=RED>{0}</color></b>", temp["Editer"]);
                        bar_static_items[7].Caption = string.Format(@"<b><color=RED>{0}</color></b>", Convert.ToDateTime(temp["EditTime"] + "").ToString(ConfigEngine.DateTimeFormat));
                    }
                    else bar_static_items[4].Visibility = bar_static_items[5].Visibility = bar_static_items[6].Visibility = bar_static_items[7].Visibility = BarItemVisibility.Never;
                }
                else foreach (BarStaticItem bar_static_item in bar_static_items)
                        bar_static_item.Visibility = BarItemVisibility.Never;
            }
            catch (Exception ex)
            {
                logger.Equals(ex);
                return;
            }
        }

        public static DataTable GetDataTableAfterFilter(DataTable data_source, GridView grid_view)
        {
            try
            {
                DataView filter_view = new DataView(data_source);
                filter_view.RowFilter = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetDataSetWhere(grid_view.ActiveFilterCriteria);
                data_source = filter_view.ToTable();

                return data_source;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        public static void ExportGridViewData(DataTable data_source, GridView grid_view)
        {
            if (data_source != null && data_source.Rows.Count > 0)
            {
                SaveFileDialog sDialog = new SaveFileDialog();
                sDialog.Filter = "Microsoft Excel (*.xls)|*.xls|Microsoft Excel 2007 (*.xlsx)|*.xlsx|PDF (*.pdf)|*.pdf|Rich Text Format (*.rtf)|*.rtf|Webpage (*.html)|*.html|Rich Text File (*.rtf)|*.rtf|Text File (*.txt)|*.txt";
                sDialog.Title = LanguageEngine.GetMessageCaption("000007", ConfigEngine.Language);
                if (sDialog.ShowDialog() == DialogResult.OK)
                {
                    switch (sDialog.FilterIndex)
                    {
                        case 1:
                            grid_view.ExportToXls(sDialog.FileName);
                            break;
                        case 2:
                            grid_view.ExportToXlsx(sDialog.FileName);
                            break;
                        case 3:
                            grid_view.ExportToPdf(sDialog.FileName);
                            break;
                        case 4:
                            grid_view.ExportToText(sDialog.FileName);
                            break;
                        case 5:
                            grid_view.ExportToHtml(sDialog.FileName);
                            break;
                        case 6:
                            grid_view.ExportToRtf(sDialog.FileName);
                            break;
                        case 7:
                            grid_view.ExportToText(sDialog.FileName);
                            break;
                    }
                    if (XtraMessageBox.Show(LanguageEngine.GetMessageCaption("000006", ConfigEngine.Language).Replace("$FileName$", sDialog.FileName), (ConfigEngine.Language == "vi") ? "Thông Báo" : "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        Process.Start(sDialog.FileName);
                    }
                }
            }
            else
            {
                return;
            }
        }

        public static void QuickExportGridViewData(DataTable data_source, GridView grid_view)
        {
            ExportGridViewData(GetDataTableAfterFilter(data_source, grid_view), grid_view);
        }

        public static bool CheckExistsUnicodeChar(string input)
        {
            if (Regex.Matches(input, @"[^a-zA-Z_0-9\s]").Count > 0)
                return true;
            return false;
        }

        public static bool CompareDateEdit(DateEdit from, DateEdit to, bool is_time)
        {
            if (is_time)
            {
                if (from.DateTime > to.DateTime)
                    return false;
            }
            else
            {
                if (from.DateTime.Date > to.DateTime.Date)
                    return false;
            }

            return true;
        }

        [DllImport("Shlwapi.dll", CharSet = CharSet.Auto)]
        public static extern long StrFormatByteSize(long fileSize, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder buffer, int bufferSize);
        public static string StrFormatByteSize(long filesize)
        {
            StringBuilder sb = new StringBuilder(11);
            StrFormatByteSize(filesize, sb, sb.Capacity);
            return sb.ToString();
        }
    }
}
