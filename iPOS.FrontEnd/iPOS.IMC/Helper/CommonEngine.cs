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
using System.Drawing.Imaging;

namespace iPOS.IMC.Helper
{
    public class CommonEngine
    {
        public static iPOS.DTO.Systems.SYS_tblUserDTO userInfo;
        public static DateTime SystemDateTime;
        protected static ILogEngine logger = new LogEngine();

        public static void ShowMessage(string message, MessageType type, bool is_code = false)
        {
            string title = "";
            MessageBoxIcon icon = MessageBoxIcon.Error;
            if (is_code) message = LanguageEngine.GetMessageCaption(message, ConfigEngine.Language);
            switch (type)
            {
                case MessageType.Error:
                    title = "ERROR_TITLE_CAPTION";
                    icon = MessageBoxIcon.Error;
                    break;
                case MessageType.Success:
                    title = "MESSAGE_TITLE_CAPTION";
                    icon = MessageBoxIcon.Information;
                    break;
                case MessageType.Warning:
                    title = "ERROR_SYSTEM_TITLE_CAPTION";
                    icon = MessageBoxIcon.Warning;
                    break;
            }
            title = LanguageEngine.GetMessageCaption(title, ConfigEngine.Language);
            if (type == 0)
                logger.Error(message);
            XtraMessageBox.Show(message, title, MessageBoxButtons.OK, icon);
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

        public static void ShowHTTPErrorMessage(iPOS.DRO.ResponseItem res)
        {
            string title = LanguageEngine.GetMessageCaption("ERROR_TITLE_CAPTION", ConfigEngine.Language);
            XtraMessageBox.Show(string.Format("Request error: {0}\n{1}", res.ErrorCode, res.ErrorMessage), title, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (ConfigEngine.TouchMode)
            {
                int width = 0, height = 0;
                string[] tmp = CaptionEngine.GetControlCaption(uc.Name, null, BaseConstant.FORM_SIZE, null).Split('|');
                width = Convert.ToInt32(tmp[0]);
                height = Convert.ToInt32(tmp[1]);
                size = new Size(width, height);
            }
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

        public static void ExportGridViewData(DataTable data_source, GridView grid_view, string file_name = "")
        {
            if (data_source != null && data_source.Rows.Count > 0)
            {
                SaveFileDialog sDialog = new SaveFileDialog();
                sDialog.Filter = "Microsoft Excel (*.xls)|*.xls|Microsoft Excel 2007 (*.xlsx)|*.xlsx|PDF (*.pdf)|*.pdf|Rich Text Format (*.rtf)|*.rtf|Webpage (*.html)|*.html|Rich Text File (*.rtf)|*.rtf|Text File (*.txt)|*.txt";
                sDialog.Title = LanguageEngine.GetMessageCaption("000007", ConfigEngine.Language);
                if (!string.IsNullOrEmpty(file_name)) sDialog.FileName = FileEngine.CreateUniqueFileName(file_name);
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

        public static void QuickExportGridViewData(DataTable data_source, GridView grid_view, string file_name)
        {
            ExportGridViewData(GetDataTableAfterFilter(data_source, grid_view), grid_view, file_name);
        }

        public static bool CheckExistsUnicodeChar(string input)
        {
            if (Regex.IsMatch(input, @"[^a-zA-Z_0-9\s]"))
                return true;
            return false;
        }

        public static bool CheckValidEmailAddress(string input)
        {
            if (string.IsNullOrEmpty(input)) return true;
            if (Regex.IsMatch(input, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
                return true;
            return false;
        }

        public static string OnlyGetNumberText(string input)
        {
            return Regex.Replace(input, @"[^0-9]", "");
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

        public static void ChooseImage(ref PictureEdit picture_edit, ref string file_name)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = FileEngine.GetImageFilterOpenFile();
            ofd.Multiselect = false;
            ofd.Title = ConfigEngine.Language.Equals("vi") ? "Chọn hình ảnh" : "Choose an image";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picture_edit.Image = Image.FromFile(ofd.FileName);
                file_name = ofd.FileName;
            }
        }

        public async static void LoadUserPermission(string function_id, TextEdit txtID, SimpleButton btnSaveClose, SimpleButton btnSaveInsert)
        {
            iPOS.DRO.Systems.SYS_tblPermissionDRO permission = new iPOS.DRO.Systems.SYS_tblPermissionDRO();
            permission = await iPOS.BUS.Systems.SYS_tblPermissionBUS.GetPermissionItem(CommonEngine.userInfo.UserID, ConfigEngine.Language, function_id);
            if (permission.ResponseItem.IsError)
            {
                CommonEngine.ShowHTTPErrorMessage(permission.ResponseItem);
                btnSaveClose.Enabled = btnSaveInsert.Enabled = false;
                return;
            }
            if (permission.PermissionItem != null)
            {
                if (string.IsNullOrEmpty(txtID.Text))
                    btnSaveClose.Enabled = btnSaveInsert.Enabled = permission.PermissionItem.AllowInsert;
                else
                {
                    btnSaveClose.Enabled = permission.PermissionItem.AllowUpdate;
                    btnSaveInsert.Enabled = permission.PermissionItem.AllowInsert & permission.PermissionItem.AllowUpdate;
                }
            }
            else btnSaveClose.Enabled = btnSaveInsert.Enabled = false;
        }

        public async static void LoadUserPermission(string function_id, BarLargeButtonItem btnDelete, BarLargeButtonItem btnPrint, BarLargeButtonItem btnImport, BarLargeButtonItem btnExport)
        {
            iPOS.DRO.Systems.SYS_tblPermissionDRO permission = new iPOS.DRO.Systems.SYS_tblPermissionDRO();
            permission = await iPOS.BUS.Systems.SYS_tblPermissionBUS.GetPermissionItem(CommonEngine.userInfo.UserID, ConfigEngine.Language, function_id);
            if (permission.ResponseItem.IsError)
            {
                CommonEngine.ShowHTTPErrorMessage(permission.ResponseItem);
                btnDelete.Enabled = btnPrint.Enabled = btnImport.Enabled = btnExport.Enabled = false;
                return;
            }
            if (permission.PermissionItem != null)
            {
                btnDelete.Enabled = permission.PermissionItem.AllowDelete;
                btnPrint.Enabled = permission.PermissionItem.AllowPrint;
                btnImport.Enabled = permission.PermissionItem.AllowImport;
                btnExport.Enabled = permission.PermissionItem.AllowExport;
            }
            else btnDelete.Enabled = btnPrint.Enabled = btnImport.Enabled = btnExport.Enabled = false;
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

    public enum MessageType
    {
        Error = 0,
        Success = 1,
        Warning = 2
    }
}
