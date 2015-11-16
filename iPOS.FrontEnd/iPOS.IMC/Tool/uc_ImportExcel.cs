using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iPOS.Core.Helper;
using LanguageEngine = iPOS.IMC.Helper.LanguageEngine;
using System.IO;
using iPOS.IMC.Helper;
using System.Text.RegularExpressions;
using System.Linq;
using System.Threading.Tasks;
using iPOS.DRO.Systems;

namespace iPOS.IMC.Tool
{
    public partial class uc_ImportExcel : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        List<SelectedFile> fileList;
        string strTemplate = "", strStoreProcedure = "", strFunctionID = "", strModuleID = "";
        bool isClickCheckFile = false, isImportAnyFile = false, isGetFileData = false;
        int total_file = 0, correct_file = 0, invalid_file = 0, total_row = 0, inserted_row = 0, updated_row = 0, invalid_row = 0, normal_row = 0;
        DataSet dsMainData;
        #endregion

        #region [Personal Methods]
        public void ChangeLanguage(string language)
        {
            LanguageEngine.ChangeCaptionLayoutControlGroup(this.Name, language, new DevExpress.XtraLayout.LayoutControlGroup[] { logSelectedFiles, logGridMainData });
            LanguageEngine.ChangeCaptionLayoutControlItem(this.Name, language, new DevExpress.XtraLayout.LayoutControlItem[] { lciBrowseFile, lciFileList });
            LanguageEngine.ChangeCaptionSimpleButton(this.Name, language, new SimpleButton[] { btnDownloadTemplate, btnCheckValid, btnImportAllFiles, btnImportSelectedFile });
            LanguageEngine.ChangeCaptionLabelControl(this.Name, language, new LabelControl[] { lblResult3, lblResult4, lblResult5, lblResult6 });
            LanguageEngine.ChangeCaptionGroupPanelTextGridView(this.Name, language, grvSeletedFiles);
            LanguageEngine.ChangeCaptionGridColumn(this.Name, language, new DevExpress.XtraGrid.Columns.GridColumn[] { gcolSelectedFileName, gcolSelectedFileSize, gcolSelectedDateModified, gcolSelectedNote, gcolSeletedFilePath });
            LanguageEngine.ChangeCaptionButtonWizardControl(this.Name, language, wzcMain);
            LanguageEngine.ChangeCaptionWelcomeWizardPage(this.Name, language, wwpStepOne);
            LanguageEngine.ChangeCaptionWizardPage(this.Name, language, wwpStepTwo);
            LanguageEngine.ChangeCaptionCompletionWizardPage(this.Name, language, wwpStepThree);
        }

        private void Initialize()
        {
            fileList = new List<SelectedFile>();
            gridSeletedFiles.DataBindings.Clear();
            gridSeletedFiles.DataSource = fileList;
            wwpStepOne.AllowNext = false;
            btnBrowseFile.Properties.Buttons[1].Enabled = false;
            dsMainData = new DataSet();

            DevExpress.XtraGrid.StyleFormatCondition styleInsertFormat = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleUpdateFormat = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleNormalFormat = new DevExpress.XtraGrid.StyleFormatCondition();
            #region [Inserted Style Format]
            styleInsertFormat.Appearance.BackColor = System.Drawing.Color.Green;
            styleInsertFormat.Appearance.BorderColor = Color.Black;
            styleInsertFormat.Appearance.ForeColor = Color.White;
            styleInsertFormat.Appearance.Options.UseBackColor = true;
            styleInsertFormat.Appearance.Options.UseBorderColor = true;
            styleInsertFormat.Appearance.Options.UseForeColor = true;
            styleInsertFormat.Column = grvMainData.Columns["Return Message"];
            styleInsertFormat.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleInsertFormat.Value1 = "Inserted";
            styleInsertFormat.Value2 = "Đã thêm mới";
            styleInsertFormat.ApplyToRow = true;
            #endregion
            #region [Updated Style Format]
            styleUpdateFormat.Appearance.BackColor = Color.Yellow;
            styleUpdateFormat.Appearance.BorderColor = Color.Black;
            styleUpdateFormat.Appearance.ForeColor = Color.Black;
            styleUpdateFormat.Appearance.Options.UseBackColor = true;
            styleUpdateFormat.Appearance.Options.UseBorderColor = true;
            styleUpdateFormat.Appearance.Options.UseForeColor = true;
            styleUpdateFormat.Column = grvMainData.Columns["Return Message"];
            styleUpdateFormat.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleUpdateFormat.Value1 = ConfigEngine.Language.Equals("vi") ? "Đã cập nhật" : "Updated";
            styleUpdateFormat.ApplyToRow = true;
            #endregion
            grvMainData.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] { styleInsertFormat, styleUpdateFormat });
        }

        private void ShowDataTable(DataTable dt)
        {
            gridMainData.BeginUpdate();
            try
            {
                grvMainData.Columns.Clear();
                gridMainData.DataSource = null;
                gridMainData.DataSource = dt;
                if (grvMainData.Columns.ColumnByFieldName("Return Message") != null)
                {
                    grvMainData.Columns["Return Message"].VisibleIndex = 0;
                    grvMainData.Columns["Return Message"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                }
                grvMainData.BestFitColumns();
            }
            finally
            {
                gridMainData.EndUpdate();
            }
        }

        private async Task ShowRequireColumn()
        {
            SYS_tblReportCaptionDRO captionList = await iPOS.BUS.Systems.SYS_tblReportCaptionBUS.GetReportCaption(CommonEngine.userInfo.Username, ConfigEngine.Language, strFunctionID, true);
            if (captionList != null && captionList.ReportCaptionList.Count > 0)
            {
                for (int i = 0; i < grvMainData.Columns.Count; i++)
                {
                    var tmp = (from caption in captionList.ReportCaptionList
                               where caption.CaptionEN.ToLower().Trim().Equals(grvMainData.Columns[i].FieldName.ToLower().Trim()) || caption.CaptionVN.ToLower().Trim().Equals(grvMainData.Columns[i].FieldName.ToLower().Trim())
                               select caption).ToList();
                    if (tmp != null && tmp.Count > 0)
                        if (tmp[0].IsRequire)
                            grvMainData.Columns[i].AppearanceHeader.ForeColor = Color.Red;
                }
            }
        }

        private async Task GetDataToImport()
        {
            try
            {
                total_file = fileList.Count;
                correct_file = (from item in fileList
                                where item.IsValid == true
                                select item).ToList().Count;
                invalid_file = total_file - correct_file;

                fileList = (from item in fileList
                            where item.IsValid
                            select item).ToList();
                grvSeletedFiles.RefreshData();

                gluSeletedFiles.DataBindings.Clear();
                gluSeletedFiles.Properties.DataSource = fileList;
                gluSeletedFiles.Properties.ValueMember = "TableName";
                gluSeletedFiles.Properties.DisplayMember = "FileName";
                if (fileList.Count > 0) gluSeletedFiles.EditValue = fileList[0].TableName;

                DataSet temp = new DataSet();
                string column_array = "";
                foreach (var file in fileList)
                {
                    CommonEngine.SetWaitFormInfo("Đang tải tập tin " + file.FileName, "Loading file data " + file.FileName, 1);
                    column_array = "";
                    ReportEngine.GetDataExcel(ref dsMainData, strFunctionID, file.FilePath, file.TableName, file.SheetName, ref column_array);
                    file.CollumArray = column_array.Substring(0, column_array.Length - 1);
                }

                if (dsMainData.Tables.Count > 0)
                {
                    isGetFileData = true;
                    ShowDataTable(dsMainData.Tables[gluSeletedFiles.EditValue + ""]);
                    await ShowRequireColumn();
                }
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
            }
        }

        private async Task<bool> CheckValidTemplate()
        {
            bool temp = false;
            FileInfo file;
            var sheetName = "";

            foreach (var item in fileList)
            {
                try
                {
                    if (!CommonEngine.CheckExistsUnicodeChar(item.FileName))
                    {
                        item.IsValid = false;
                        item.Note = LanguageEngine.GetMessageCaption("000021", ConfigEngine.Language);
                    }
                    file = new FileInfo(item.FilePath);
                    CommonEngine.SetWaitFormInfo("Đang kiểm tra tập tin " + file.Name, "Checking file " + file.Name, 1);
                    if (file.Exists)
                    {
                        temp = await ReportEngine.CheckValidImportTemplate(CommonEngine.userInfo.UserID, ConfigEngine.Language, strStoreProcedure, file.Name, strModuleID, strFunctionID, file.FullName);
                        if (!temp)
                        {
                            item.IsValid = false;
                            item.Note = ConfigEngine.Language.Equals("vi") ? "Mẫu không hợp lệ!" : "Invalid template!";
                        }
                        else
                        {
                            item.IsValid = true;
                            item.Note = ConfigEngine.Language.Equals("vi") ? "Mẫu hợp lệ!" : "Valid template!";
                            item.SheetName = sheetName;
                            string tmp = item.FileName;
                            tmp = tmp.Substring(0, tmp.LastIndexOf('.'));
                            tmp = Regex.Replace(tmp, @"[^a-zA-Z0-9\s-().\[\]]", "");
                            item.TableName = tmp;
                        }
                    }
                    else
                    {
                        item.IsValid = false;
                        item.Note = ConfigEngine.Language.Equals("vi") ? "Tập tin không tồn tại!" : "File not exists!";
                    }
                }
                catch (Exception ex)
                {
                    CommonEngine.ShowExceptionMessage(ex);
                }
            }
            grvSeletedFiles.RefreshData();

            return true;
        }
        #endregion

        #region [Form Events]
        public uc_ImportExcel()
        {
            InitializeComponent();
        }

        public uc_ImportExcel(string template_name, string store_procedure, string module_id, string function_id)
        {
            InitializeComponent();
            strStoreProcedure = store_procedure;
            strModuleID = module_id;
            strTemplate = template_name;
            strFunctionID = function_id;
            ChangeLanguage(ConfigEngine.Language);
            Initialize();
        }

        private void btnBrowseFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Microsoft Excel 97 - 2003 (*.xls)|*.xls|Microsoft Excel 2007 (*.xlsx)|*.xlsx";
                ofd.Title = ConfigEngine.Language.Equals("vi") ? "Chọn tệp dữ liệu" : "Choose data file";
                ofd.Multiselect = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in ofd.FileNames)
                    {
                        var _file = new FileInfo(file);
                        if (_file.Exists)
                        {
                            var files = (from item in fileList
                                         where item.FilePath.ToLower().Equals(_file.FullName.ToLower())
                                         select item).ToList();
                            if (files != null && files.Count > 0) continue;
                            fileList.Add(new SelectedFile
                            {
                                FileName = _file.Name,
                                DateModified = _file.LastWriteTime,
                                FileSize = CommonEngine.StrFormatByteSize(_file.Length),
                                FilePath = _file.FullName,
                                IsValid = false
                            });
                        }
                    }
                    grvSeletedFiles.RefreshData();
                    wwpStepOne.AllowNext = btnCheckValid.Enabled = string.IsNullOrEmpty(ofd.FileNames.ToString()) ? false : true;
                }
            }
        }

        private void gridSeletedFiles_DragDrop(object sender, DragEventArgs e)
        {
            Cursor saveCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                FileInfo file;
                Object data = e.Data.GetData(DataFormats.FileDrop);

                foreach (object obj in (string[])data)
                {
                    file = new FileInfo(obj.ToString());
                    if (file.Exists)
                    {
                        var files = (from item in fileList
                                     where item.FilePath.ToLower().Equals(file.FullName.ToLower())
                                     select item).ToList();
                        if (files != null && files.Count > 0) continue;
                        fileList.Add(new SelectedFile
                        {
                            FileName = file.Name,
                            DateModified = file.LastWriteTime,
                            FileSize = CommonEngine.StrFormatByteSize(file.Length),
                            FilePath = file.FullName,
                            IsValid = false
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
            }
            finally
            {
                Cursor.Current = saveCursor;
            }
            grvSeletedFiles.RefreshData();
            wwpStepOne.AllowNext = btnCheckValid.Enabled = fileList.Count > 0;
        }

        private void gridSeletedFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void grvSeletedFiles_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0 && e.Info.IsRowIndicator)
                e.Info.DisplayText = e.RowHandle + 1 + "";
        }

        private void grvSeletedFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (fileList.Count > 0)
                if (e.KeyData == Keys.Delete)
                    fileList.RemoveAt(grvSeletedFiles.FocusedRowHandle);

            wwpStepOne.AllowNext = btnCheckValid.Enabled = !(fileList.Count == 0);
            grvSeletedFiles.RefreshData();
        }
        
        private async void btnCheckValid_Click(object sender, EventArgs e)
        {
            CommonEngine.ShowWaitForm(this.ParentForm);
            isClickCheckFile = await CheckValidTemplate();
            CommonEngine.CloseWaitForm();
        }

        private void btnDownloadTemplate_Click(object sender, EventArgs e)
        {
            CommonEngine.ShowWaitForm(this.ParentForm);
            ReportEngine.GetFileWithReportCaption(CommonEngine.userInfo.Username, ConfigEngine.Language, strTemplate, strFunctionID, strModuleID);
            CommonEngine.CloseWaitForm();
        }

        private async void gluSeletedFiles_EditValueChanged(object sender, EventArgs e)
        {
            if (dsMainData.Tables.Count > 0)
            {
                ShowDataTable(dsMainData.Tables[gluSeletedFiles.EditValue + ""]);
                await ShowRequireColumn();
            }
        }

        private void grvMainData_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = e.RowHandle + 1 + "";
        }

        private async void wzcMain_SelectedPageChanging(object sender, DevExpress.XtraWizard.WizardPageChangingEventArgs e)
        {
            if (e.Page == wwpStepTwo && e.Direction == DevExpress.XtraWizard.Direction.Forward)
            {
                if (!isClickCheckFile)
                {
                    CommonEngine.ShowMessage(ConfigEngine.Language.Equals("vi") ? "Hệ thống sẽ tự động kiểm tra tệp dữ liệu." : "System will auto check valid all data files.", MessageType.Success);
                    e.Cancel = true;

                    CommonEngine.ShowWaitForm(this.ParentForm);
                    isClickCheckFile = await CheckValidTemplate();
                    CommonEngine.CloseWaitForm();
                }
                if (isClickCheckFile && !isGetFileData)
                {
                    var errorFiles = (from file in fileList
                                      where file.IsValid == false
                                      select file).ToList();
                    if (errorFiles != null && errorFiles.Count > 0)
                    {
                        if (CommonEngine.ShowConfirmMessageAlert(ConfigEngine.Language.Equals("vi") ? "Có tập tin bị lỗi, bạn có muốn tiếp tục không?" : "Having corrupted file(s), do you want to continue?"))
                        {
                            CommonEngine.ShowWaitForm(this.ParentForm);
                            await GetDataToImport();
                            CommonEngine.CloseWaitForm();
                            e.Cancel = false;
                        }
                        else
                        {
                            e.Cancel = true;
                            return;
                        }
                    }
                    else
                    {
                        CommonEngine.ShowWaitForm(this.ParentForm);
                        await GetDataToImport();
                        CommonEngine.CloseWaitForm();
                    }

                    wzcMain.SelectedPage = wwpStepTwo;
                }

                wwpStepTwo.AllowNext = isImportAnyFile;
            }
            else if (e.Page == wwpStepOne && e.Direction == DevExpress.XtraWizard.Direction.Backward)
            {
                if (CommonEngine.ShowConfirmMessageAlert(ConfigEngine.Language.Equals("vi") ? "Tất cả dữ liệu sẽ bị mất, bạn có muốn tiếp tục không?" : "All data will be lost, do you want to continue?"))
                {
                    dsMainData.Clear();
                    dsMainData.Tables.Clear();
                    e.Cancel = false;
                    isImportAnyFile = false;
                    isGetFileData = false;
                }
                else e.Cancel = true;
            }
            else if (e.Page == wwpStepThree && e.Direction == DevExpress.XtraWizard.Direction.Forward)
            {
                lblResult1.Text = string.Format(ConfigEngine.Language.Equals("vi") ? @"Tổng số tập tin đã chọn: <b>{0}</b> tệp, trong đó có <b><color=RED>{1}</color></b> tệp tin lỗi, <b><color=GREEN>{2}</color></b> tệp tin hợp lệ." : @"Total selected file: <b>{0}</b> file(s), including <b><color=RED>{1}</color></b> invalid file(s), <b><color=GREEN>{2}</color></b> valid file(s).", total_file, invalid_file, correct_file);

                total_row = inserted_row = updated_row = normal_row = invalid_row = 0;
                foreach (DataTable dt in dsMainData.Tables)
                {
                    total_row += dt.Rows.Count;
                    foreach (DataRow dr in dt.Rows)
                    {
                        switch ((dr["Return Message"] + "").Trim())
                        {
                            case "Inserted":
                            case "Đã thêm mới":
                                inserted_row += 1; break;
                            case "Updated": 
                            case "Đã cập nhật":
                                updated_row += 1; break;
                            case "": normal_row += 1; break;
                            default: invalid_row += 1; break;
                        }
                    }
                }

                lblResult2.Text = string.Format(ConfigEngine.Language.Equals("vi") ? @"Tổng số dòng dữ liệu cần nhập: <b>{0}</b> dòng, trong đó:" : @"Total row of data need to import: <b>{0}</b> rows, in which:", total_row);
                lblSummary3.Text = string.Format(ConfigEngine.Language.Equals("vi") ? @"<b><color=GREEN>{0}</color></b> dòng." : @"<b><color=GREEN>{0}</color></b> row(s).", inserted_row);
                lblSummary4.Text = string.Format(ConfigEngine.Language.Equals("vi") ? @"<b><color=BLUE>{0}</color></b> dòng." : @"<b><color=BLUE>{0}</color></b> row(s).", updated_row);
                lblSummary5.Text = string.Format(ConfigEngine.Language.Equals("vi") ? @"<b><color=RED>{0}</color></b> dòng." : @"<b><color=RED>{0}</color></b> row(s).", invalid_row);
                lblSummary6.Text = string.Format(ConfigEngine.Language.Equals("vi") ? @"<b>{0}</b> dòng." : @"<b>{0}</b> row(s).", normal_row);

                wwpStepThree.AllowBack = false;
            }
        }

        private async void btnImportSelectedFile_Click(object sender, EventArgs e)
        {
            try
            {
                CommonEngine.ShowWaitForm(this.ParentForm);
                SYS_tblReportCaptionDRO captionList = await iPOS.BUS.Systems.SYS_tblReportCaptionBUS.GetReportCaption(CommonEngine.userInfo.Username, ConfigEngine.Language, strFunctionID, true);
                if (captionList != null && captionList.ReportCaptionList.Count > 0)
                {
                    DataTable dt = dsMainData.Tables[gluSeletedFiles.EditValue + ""];
                    var file = (from _file in fileList
                                where _file.TableName.Equals(gluSeletedFiles.EditValue)
                                select _file).ToList();

                    if (file != null && file.Count > 0)
                    {
                        string tmp = file[0].CollumArray;
                        if (!string.IsNullOrEmpty(tmp))
                        {
                            SYS_tblImportFileConfigDRO result;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                result = await iPOS.BUS.Systems.SYS_tblImportFileConfigBUS.ImportDataRow(CommonEngine.userInfo.Username, ConfigEngine.Language, strStoreProcedure, dt.Rows[i], tmp);
                                if (!CommonEngine.CheckValidResponseItem(result.ResponseItem)) continue;
                                dt.Rows[i]["Return Message"] = result.ResponseItem.Message;
                            }
                        }

                        grvMainData.BestFitColumns();
                    }
                }
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
            }
            finally
            {
                CommonEngine.CloseWaitForm();
            }

            isImportAnyFile = true;
            wwpStepTwo.AllowNext = isImportAnyFile;
        }

        private async void btnImportAllFiles_Click(object sender, EventArgs e)
        {
            try
            {
                CommonEngine.ShowWaitForm(this.ParentForm);
                foreach (var file in fileList)
                {
                    SYS_tblReportCaptionDRO captionList = await iPOS.BUS.Systems.SYS_tblReportCaptionBUS.GetReportCaption(CommonEngine.userInfo.Username, ConfigEngine.Language, strFunctionID, true);
                    if (captionList != null && captionList.ReportCaptionList.Count > 0)
                    {
                        DataTable dt = dsMainData.Tables[file.TableName];
                        string tmp = file.CollumArray;
                        if (tmp.Length > 0)
                        {
                            SYS_tblImportFileConfigDRO result;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                result = await iPOS.BUS.Systems.SYS_tblImportFileConfigBUS.ImportDataRow(CommonEngine.userInfo.Username, ConfigEngine.Language, strStoreProcedure, dt.Rows[i], tmp);
                                if (!CommonEngine.CheckValidResponseItem(result.ResponseItem)) continue;
                                dt.Rows[i]["Return Message"] = result.ResponseItem.Message;
                            }
                        }

                        grvMainData.BestFitColumns();
                    }
                }
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
            }
            finally
            {
                CommonEngine.CloseWaitForm();
            }

            isImportAnyFile = true;
            wwpStepTwo.AllowNext = isImportAnyFile;
        }
        #endregion
    }

    #region [SelectedFile]
    public class SelectedFile
    {
        public string FileName { get; set; }
        public DateTime DateModified { get; set; }
        public string FileSize { get; set; }
        public string FilePath { get; set; }
        public string Note { get; set; }
        public bool IsValid { get; set; }
        public string SheetName { get; set; }
        public string TableName { get; set; }
        public string CollumArray { get; set; }
    }
    #endregion
}
