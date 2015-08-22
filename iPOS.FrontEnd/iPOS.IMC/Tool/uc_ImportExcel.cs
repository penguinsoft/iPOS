using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iPOS.Core.Helper;
using LanguageEngine = iPOS.IMC.Helper.LanguageManage;
using System.IO;
using iPOS.IMC.Helper;
using Aspose.Cells;
using System.Text.RegularExpressions;
using System.Linq;

namespace iPOS.IMC.Tool
{
    public partial class uc_ImportExcel : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        DataTable dtSelectedFile;
        string strTemplate = "", strStoreProcedure = "", strFunctionID = "", strModuleID = "";
        bool isClickCheckFile = false;
        int total_file = 0, correct_file = 0, invalid_file = 0, total_row = 0, inserted_row = 0, updated_row = 0, invalid_row = 0, normal_row = 0;
        DataSet dsMainData;
        #endregion

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
            dtSelectedFile = CreateSelectedFileDataTable();
            gridSeletedFiles.DataBindings.Clear();
            gridSeletedFiles.DataSource = dtSelectedFile;
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
            styleUpdateFormat.Value1 = "Updated";
            styleUpdateFormat.ApplyToRow = true;
            #endregion
            grvMainData.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] { styleInsertFormat, styleUpdateFormat });
        }

        private DataTable CreateSelectedFileDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FileName", typeof(string));
            dt.Columns.Add("DateModified", typeof(DateTime));
            dt.Columns.Add("FileSize", typeof(string));
            dt.Columns.Add("FilePath", typeof(string));
            dt.Columns.Add("Note", typeof(string));
            dt.Columns.Add("IsValid", typeof(bool));
            dt.Columns.Add("SheetName", typeof(string));
            dt.Columns.Add("TableName", typeof(string));
            dt.Columns.Add("ColumnArray", typeof(string));

            return dt;
        }

        private void ShowDataTable(DataTable dt)
        {
            grvMainData.Columns.Clear();
            grvMainData.OptionsBehavior.AutoPopulateColumns = true;
            gridMainData.DataBindings.Clear();
            gridMainData.DataSource = dt;
            grvMainData.Columns["Return Message"].VisibleIndex = 0;
            grvMainData.Columns["Return Message"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            grvMainData.BestFitColumns();
        }

        private async void ShowRequireColumn()
        {
            List<iPOS.DTO.Systems.SYS_tblReportCaptionDTO> captionList = await iPOS.BUS.Systems.SYS_tblReportCaptionBUS.GetReportCaption(CommonEngine.userInfo.Username, ConfigEngine.Language, strFunctionID, true);
            if (captionList != null && captionList.Count > 0)
            {
                for (int i = 0; i < grvMainData.Columns.Count; i++)
                {
                    var tmp = (from caption in captionList
                               where caption.Caption.ToLower().Trim().Equals(grvMainData.Columns[i].FieldName.ToLower().Trim())
                               select caption).ToList();
                    if (tmp != null && tmp.Count > 0)
                        if (tmp[0].IsRequire)
                            grvMainData.Columns[i].AppearanceHeader.ForeColor = Color.Red;
                }
            }
        }

        private void GetDataToImport()
        {
            total_file = dtSelectedFile.Rows.Count;
            correct_file = dtSelectedFile.Select("IsValid=True").Length;
            invalid_file = total_file - correct_file;

            DataRow[] drDeleted = dtSelectedFile.Select("IsValid=False");
            foreach (DataRow dr in drDeleted)
                dr.Delete();
            dtSelectedFile.AcceptChanges();

            gluSeletedFiles.DataBindings.Clear();
            gluSeletedFiles.Properties.DataSource = dtSelectedFile;
            gluSeletedFiles.Properties.ValueMember = "TableName";
            gluSeletedFiles.Properties.DisplayMember = "FileName";
            if (dtSelectedFile.Rows.Count > 0) gluSeletedFiles.EditValue = dtSelectedFile.Rows[0]["TableName"];

            DataSet temp = new DataSet();
            string column_array = "";
            foreach (DataRow dr in dtSelectedFile.Rows)
            {
                column_array = "";
                ReportEngine.GetDataExcel(ref dsMainData, strFunctionID, dr["FilePath"] + "", dr["TableName"] + "", dr["SheetName"] + "", ref column_array);
                dr["ColumnArray"] = column_array.Substring(0, column_array.Length - 1);
            }

            if (dsMainData.Tables.Count > 0)
            {
                ShowDataTable(dsMainData.Tables[gluSeletedFiles.EditValue + ""]);
                ShowRequireColumn();
            }
        }

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
                string files = "";
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Microsoft Excel 2007 (*.xlsx)|*.xlsx|Microsoft Excel 97 - 2003 (*.xls)|*.xls";
                ofd.Title = ConfigEngine.Language.Equals("vi") ? "Chọn tệp dữ liệu" : "Choose data file";
                ofd.Multiselect = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in ofd.FileNames)
                        files += file + ";";
                    btnBrowseFile.EditValue = files.Equals("") ? string.Empty : files.Substring(0, files.Length - 1);
                    btnBrowseFile.Properties.Buttons[1].Enabled = files.Equals("") ? false : true;
                }
            }
            else if (e.Button.Index == 1)
            {
                FileInfo file;
                foreach (string item in btnBrowseFile.EditValue.ToString().Split(';'))
                {
                    file = new FileInfo(item.ToString());
                    if (file.Exists)
                        if (dtSelectedFile.Select("FilePath='" + item + "'").Length == 0)
                            dtSelectedFile.Rows.Add(new object[] { file.Name, file.LastWriteTime, CommonEngine.StrFormatByteSize(file.Length), file.FullName, "", false });
                }
                wwpStepOne.AllowNext = dtSelectedFile.Rows.Count > 0;
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
                        if (dtSelectedFile.Select("FilePath='" + obj + "'").Length == 0)
                            dtSelectedFile.Rows.Add(new object[] { file.Name, file.LastWriteTime, CommonEngine.StrFormatByteSize(file.Length), file.FullName, "" });
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
            wwpStepOne.AllowNext = dtSelectedFile.Rows.Count > 0;
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
            if (dtSelectedFile.Rows.Count > 0)
                if (e.KeyData == Keys.Delete)
                    dtSelectedFile.Rows.RemoveAt(grvSeletedFiles.FocusedRowHandle);
        }

        private async void btnCheckValid_Click(object sender, EventArgs e)
        {
            Workbook wb;
            bool temp = false;
            FileInfo file;
            foreach (DataRow dr in dtSelectedFile.Rows)
            {
                try
                {
                    file = new FileInfo(dr["FilePath"] + "");
                    if (file.Exists)
                    {
                        wb = new Workbook(file.FullName);
                        temp = await ReportEngine.CheckValidImportTemplate(CommonEngine.userInfo.Username, ConfigEngine.Language, strStoreProcedure, dr["FileName"] + "", strModuleID, strFunctionID, wb.Worksheets[0]);
                        if (!temp)
                        {
                            dr["IsValid"] = false;
                            dr["Note"] = "Invalid template!";
                        }
                        else
                        {
                            dr["IsValid"] = true;
                            dr["Note"] = "OK!";
                            dr["SheetName"] = wb.Worksheets[0].Name;
                            string tmp = dr["FileName"] + "";
                            tmp = tmp.Substring(0, tmp.LastIndexOf('.'));
                            tmp = Regex.Replace(tmp, @"[^a-zA-Z0-9\s-().\[\]]", "");
                            dr["TableName"] = tmp;
                        }
                    }
                    else
                    {
                        dr["IsValid"] = false;
                        dr["Note"] = "File not exists!";
                    }
                }
                catch (Exception ex)
                {
                    CommonEngine.ShowExceptionMessage(ex);
                }
            }
            isClickCheckFile = true;
        }

        private void btnDownloadTemplate_Click(object sender, EventArgs e)
        {
            ReportEngine.GetFileWithReportCaption(CommonEngine.userInfo.Username, ConfigEngine.Language, strTemplate, strFunctionID, strModuleID);
        }

        private void gluSeletedFiles_EditValueChanged(object sender, EventArgs e)
        {
            if (dsMainData.Tables.Count > 0)
            {
                ShowDataTable(dsMainData.Tables[gluSeletedFiles.EditValue + ""]);
                ShowRequireColumn();
            }
        }

        private void grvMainData_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = e.RowHandle + 1 + "";
        }

        private void wzcMain_SelectedPageChanging(object sender, DevExpress.XtraWizard.WizardPageChangingEventArgs e)
        {
            if (e.Page == wwpStepTwo && e.Direction == DevExpress.XtraWizard.Direction.Forward)
            {
                if (!isClickCheckFile)
                {
                    CommonEngine.ShowMessage(ConfigEngine.Language.Equals("vi") ? "Hệ thống sẽ tự động kiểm tra tệp dữ liệu." : "System will auto check valid all data files.", 1);
                    btnCheckValid_Click(null, null);
                }
                if (isClickCheckFile)
                {
                    if (dtSelectedFile.Select("IsValid=False").Length > 0)
                    {
                        if (CommonEngine.ShowConfirmMessageAlert(ConfigEngine.Language.Equals("vi") ? "Có tập tin bị lỗi, bạn có muốn tiếp tục không?" : "Having corrupted file(s), do you want to continue?"))
                        {
                            e.Cancel = false;
                            GetDataToImport();
                        }
                        else e.Cancel = true;
                    }
                    else GetDataToImport();
                }
            }
        }
    }
}
