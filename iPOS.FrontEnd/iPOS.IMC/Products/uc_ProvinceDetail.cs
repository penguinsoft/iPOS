using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iPOS.IMC.Helper;
using iPOS.Core.Helper;
using iPOS.DTO.Products;
using System.Threading.Tasks;
using iPOS.BUS.Products;
using iPOS.DRO.Products;

namespace iPOS.IMC.Products
{
    public partial class uc_ProvinceDetail : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        private uc_Province parent_form;
        #endregion

        #region [Personal Methods]
        private void Initialize()
        {
            LanguageEngine.ChangeCaptionLayoutControlGroup(this.Name, ConfigEngine.Language, logDetail);
            LanguageEngine.ChangeCaptionLayoutControlItem(this.Name, ConfigEngine.Language, new DevExpress.XtraLayout.LayoutControlItem[] { lciProvinceCode, lciVNName, lciENName, lciRank, lciNote });
            LanguageEngine.ChangeCaptionCheckEdit(this.Name, ConfigEngine.Language, chkUsed);
            LanguageEngine.ChangeCaptionSimpleButton(this.Name, ConfigEngine.Language, new SimpleButton[] { btnSaveClose, btnSaveInsert, btnCancel });
        }

        private bool CheckValidate()
        {
            if (string.IsNullOrEmpty(txtProvinceCode.Text))
            {
                depError.SetError(txtProvinceCode, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                txtProvinceCode.Focus();
                return false;
            }
            if (txtProvinceCode.Text.Contains(" "))
            {
                depError.SetError(txtProvinceCode, LanguageEngine.GetMessageCaption("000004", ConfigEngine.Language));
                txtProvinceCode.Focus();
                return false;
            }
            if (CommonEngine.CheckExistsUnicodeChar(txtProvinceCode.Text))
            {
                depError.SetError(txtProvinceCode, LanguageEngine.GetMessageCaption("000021", ConfigEngine.Language));
                txtProvinceCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtVNName.Text.Trim()))
            {
                depError.SetError(txtVNName, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                txtVNName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtENName.Text.Trim()))
            {
                depError.SetError(txtENName, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                txtENName.Focus();
                return false;
            }

            return true;
        }

        private async Task<bool> SaveProvince(bool isEdit)
        {
            PRO_tblProvinceDRO result = new PRO_tblProvinceDRO();
            try
            {
                result = await PRO_tblProvinceBUS.InsertUpdateProvince(new PRO_tblProvinceDTO
                {
                    ProvinceID = isEdit ? txtProvinceID.Text : "0",
                    ProvinceCode = txtProvinceCode.Text,
                    VNName = txtVNName.Text,
                    ENName = txtENName.Text,
                    Rank = speRank.EditValue != null ? Convert.ToInt32(speRank.Value) : (Int32?)null,
                    Used = chkUsed.Checked,
                    Note = mmoNote.Text,
                    UserID = CommonEngine.userInfo.UserID,
                    Activity = (isEdit) ? BaseConstant.COMMAND_UPDATE_EN : BaseConstant.COMMAND_INSERT_EN,
                    LanguageID = ConfigEngine.Language
                }, new DTO.Systems.SYS_tblActionLogDTO
                {
                    Activity = BaseConstant.COMMAND_INSERT_EN,
                    UserID = CommonEngine.userInfo.UserID,
                    LanguageID = ConfigEngine.Language,
                    ActionEN = isEdit ? BaseConstant.COMMAND_UPDATE_EN : BaseConstant.COMMAND_INSERT_EN,
                    ActionVN = isEdit ? BaseConstant.COMMAND_UPDATE_VI : BaseConstant.COMMAND_INSERT_VI,
                    FunctionID = "8",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa {1} thành công tỉnh thành có mã tỉnh là '{2}'.", CommonEngine.userInfo.UserID, isEdit ? "cập nhật" : "thêm mới", txtProvinceCode.Text),
                    DescriptionEN = string.Format("Account '{0}' has {1} province successfully with province code is '{2}'.", CommonEngine.userInfo.UserID, isEdit ? "updated" : "inserted", txtProvinceCode.Text)
                });

                if (result.ResponseItem.IsError)
                {
                    CommonEngine.ShowHTTPErrorMessage(result.ResponseItem);
                    txtProvinceCode.Focus();
                    return false;
                }
                if (!string.IsNullOrEmpty(result.ResponseItem.Message))
                {
                    CommonEngine.ShowMessage(result.ResponseItem.Message, 0);
                    txtProvinceCode.Focus();
                    return false;
                }
                else if (parent_form != null) parent_form.GetAllProvinces();
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
                return false;
            }

            return true;
        }

        private void LoadDataToEdit(PRO_tblProvinceDTO item)
        {
            txtProvinceID.EditValue = (item == null) ? null : item.ProvinceID;
            txtProvinceCode.EditValue = (item == null) ? null : item.ProvinceCode;
            //txtProvinceCode.Properties.ReadOnly = (item == null) ? false : true;
            txtVNName.EditValue = (item == null) ? null : item.VNName;
            txtENName.EditValue = (item == null) ? null : item.ENName;
            speRank.EditValue = (item == null) ? null : item.Rank;
            chkUsed.Checked = (item == null) ? true : item.Used;
            mmoNote.EditValue = (item == null) ? null : item.Note;
            if (item == null)
            {
                depError.ClearErrors();
                this.ParentForm.Text = LanguageEngine.GetOpenFormText(this.Name, ConfigEngine.Language, false);
                txtProvinceCode.Focus();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            BeginInvoke(new MethodInvoker(() =>
            {
                if (!string.IsNullOrEmpty(txtProvinceID.Text))
                    txtVNName.Focus();
            }));
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                btnSaveClose_Click(null, null);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.Shift | Keys.S))
            {
                btnSaveInsert_Click(null, null);
                return true;
            }
            else if (keyData == Keys.Escape)
            {
                btnCancel_Click(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);

        }
        #endregion

        #region [Form Events]
        public uc_ProvinceDetail()
        {
            InitializeComponent();
            Initialize();
        }

        public uc_ProvinceDetail(uc_Province _parent_form, PRO_tblProvinceDTO item = null)
        {
            InitializeComponent();
            Initialize();
            parent_form = _parent_form;
            if (item != null)
                LoadDataToEdit(item);
        }

        private void txtProvinceCode_EditValueChanged(object sender, EventArgs e)
        {
            if (txtProvinceCode.Text.Contains(" "))
                depError.SetError(txtProvinceCode, LanguageEngine.GetMessageCaption("000004", ConfigEngine.Language));
            else if (string.IsNullOrEmpty(txtProvinceCode.Text))
                depError.SetError(txtProvinceCode, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
            else if (CommonEngine.CheckExistsUnicodeChar(txtProvinceCode.Text))
                depError.SetError(txtProvinceCode, LanguageEngine.GetMessageCaption("000021", ConfigEngine.Language));
            else depError.SetError(txtProvinceCode, null);
        }

        private void txtVNName_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtVNName, string.IsNullOrEmpty(txtVNName.Text.Trim()) ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : null);
        }

        private void txtENName_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtENName, string.IsNullOrEmpty(txtENName.Text.Trim()) ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : null);
        }

        private async void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (await SaveProvince(!string.IsNullOrEmpty(txtProvinceID.Text)))
                    this.ParentForm.Close();
        }

        private async void btnSaveInsert_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (await SaveProvince(!string.IsNullOrEmpty(txtProvinceID.Text)))
                    LoadDataToEdit(null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        #endregion
    }
}
