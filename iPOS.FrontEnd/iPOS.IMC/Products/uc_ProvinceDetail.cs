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

namespace iPOS.IMC.Products
{
    public partial class uc_ProvinceDetail : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        private uc_Province parent_form;
        #endregion

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
            if (string.IsNullOrEmpty(txtVNName.Text))
            {
                depError.SetError(txtVNName, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                txtVNName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtENName.Text))
            {
                depError.SetError(txtENName, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                txtENName.Focus();
                return false;
            }

            return true;
        }

        private async Task<bool> SaveProvince(bool isEdit)
        {
            string strError = "";
            try
            {
                PRO_tblProvinceDTO item = new PRO_tblProvinceDTO
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
                };
                strError = await PRO_tblProvinceBUS.InsertUpdateProvince(item, new DTO.Systems.SYS_tblActionLogDTO
                {
                    Activity = BaseConstant.COMMAND_INSERT_EN,
                    UserID = CommonEngine.userInfo.UserID,
                    LanguageID = ConfigEngine.Language,
                    ActionEN = isEdit ? BaseConstant.COMMAND_UPDATE_EN : BaseConstant.COMMAND_INSERT_EN,
                    ActionVN = isEdit ? BaseConstant.COMMAND_UPDATE_VI : BaseConstant.COMMAND_INSERT_VI,
                    FunctionID = "8",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa {1} thành công tỉnh thành có mã tỉnh là '{2}'.", item.UserID, isEdit ? "cập nhật" : "thêm mới", txtProvinceCode.Text),
                    DescriptionEN = string.Format("Account '{0}' has {1} province successfully with province code is '{2}'.", item.UserID, isEdit ? "updated" : "inserted", txtProvinceCode.Text)
                });
                if (!string.IsNullOrEmpty(strError))
                {
                    CommonEngine.ShowMessage(strError, 0);
                    txtProvinceID.Focus();
                    return false;
                }
                else parent_form.GetAllProvinces();
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
                return false;
            }

            return true;
        }

        public uc_ProvinceDetail()
        {
            InitializeComponent();
            Initialize();
        }

        public uc_ProvinceDetail(uc_Province _parent_form, PRO_tblProvinceDTO item = null)
        {
            InitializeComponent();
            parent_form = _parent_form;
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
            depError.SetError(txtVNName, string.IsNullOrEmpty(txtVNName.Text) ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : txtVNName.Text.Contains(" ") ? LanguageEngine.GetMessageCaption("000004", ConfigEngine.Language) : null);
        }

        private void txtENName_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtENName, string.IsNullOrEmpty(txtENName.Text) ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : txtENName.Text.Contains(" ") ? LanguageEngine.GetMessageCaption("000004", ConfigEngine.Language) : null);
        }

        private async void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (await SaveProvince(!string.IsNullOrEmpty(txtProvinceID.Text)))
                    this.ParentForm.Close();
        }

        private void btnSaveInsert_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
