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
using iPOS.Core.Security;
using iPOS.BUS.Systems;

namespace iPOS.IMC.Systems
{
    public partial class uc_ChangePassword : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Personal Methods]
        private void Initialize()
        {
            LanguageEngine.ChangeCaptionLabelControl(this.Name, ConfigEngine.Language, lblNote);
            LanguageEngine.ChangeCaptionLayoutControlItem(this.Name, ConfigEngine.Language, new DevExpress.XtraLayout.LayoutControlItem[] { lciUsername, lciGroupName, lciOldPassword, lciNewPassword, lciConfirmPassword });
            LanguageEngine.ChangeCaptionSimpleButton(this.Name, ConfigEngine.Language, new SimpleButton[] { btnSave, btnCancel });
            txtUsername.Text = CommonEngine.userInfo.UserID;
            txtGroupName.Text = CommonEngine.userInfo.GroupName;
        }

        private bool CheckValidate()
        {
            if (string.IsNullOrEmpty(txtOldPassword.Text))
            {
                depError.SetError(txtOldPassword, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                txtOldPassword.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                depError.SetError(txtNewPassword, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                txtNewPassword.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                depError.SetError(txtConfirmPassword, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                txtConfirmPassword.Focus();
                return false;
            }
            if (!txtNewPassword.Text.Equals(txtConfirmPassword.Text))
            {
                depError.SetError(txtConfirmPassword, LanguageEngine.GetMessageCaption("000014", ConfigEngine.Language));
                txtConfirmPassword.Focus();
                return false;
            }
            if (!EncryptEngine.Encrypt(txtOldPassword.Text).Equals(CommonEngine.userInfo.Password))
            {
                depError.SetError(txtOldPassword, LanguageEngine.GetMessageCaption("000015", ConfigEngine.Language));
                txtOldPassword.Focus();
                return false;
            }

            return true;
        }
        #endregion

        #region [Form Events]
        public uc_ChangePassword(bool is_expried)
        {
            InitializeComponent();
            Initialize();
            lciLabelNote.Visibility = (is_expried) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        public uc_ChangePassword()
        {
            InitializeComponent();
            Initialize();
        }

        private void txtOldPassword_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOldPassword.Text))
                depError.SetError(txtOldPassword, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
            else if (!EncryptEngine.Encrypt(txtOldPassword.Text).Equals(CommonEngine.userInfo.Password))
                depError.SetError(txtOldPassword, LanguageEngine.GetMessageCaption("000015", ConfigEngine.Language));
            else depError.SetError(txtOldPassword, null);
        }

        private void txtNewPassword_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtNewPassword, string.IsNullOrEmpty(txtNewPassword.Text) ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : null);
        }

        private void txtConfirmPassword_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
                depError.SetError(txtConfirmPassword, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
            else if (!txtConfirmPassword.Text.Equals(txtNewPassword.Text))
                depError.SetError(txtConfirmPassword, LanguageEngine.GetMessageCaption("000014", ConfigEngine.Language));
            else depError.SetError(txtConfirmPassword, null);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
            {
                string strError = "";
                try
                {
                    strError = await SYS_tblUserBUS.ChangeUserPassword(txtUsername.Text, ConfigEngine.Language, EncryptEngine.Encrypt(txtNewPassword.Text), new DTO.Systems.SYS_tblActionLogDTO
                    {
                        Activity = BaseConstant.COMMAND_INSERT_EN,
                        UserID = txtUsername.Text,
                        LanguageID = ConfigEngine.Language,
                        ActionVN = "Đổi Mật Khẩu",
                        ActionEN = "Change Password",
                        FunctionID = "",
                        FunctionNameVN = "Đổi Mật Khẩu",
                        FunctionNameEN = "Change Password",
                        DescriptionVN = string.Format("Tài khoản '{0}' vừa đổi mật khẩu thành công vào lúc {1}.", txtUsername.Text, DateTime.Now),
                        DescriptionEN = string.Format("Account '{0}' has change password successfully at {1}.", txtUsername.Text, DateTime.Now)
                    });
                    if (string.IsNullOrEmpty(strError))
                    {
                        CommonEngine.userInfo.Password = EncryptEngine.Encrypt(txtNewPassword.Text);
                        txtOldPassword.EditValue = txtNewPassword.EditValue = txtConfirmPassword.EditValue = null;
                        CommonEngine.ShowMessage(ConfigEngine.Language.Equals("vi") ? "Đổi mật khẩu người dùng thành công." : "Change user password successfully.", MessageType.Success);
                        this.ParentForm.Close();
                    }
                    else
                    {
                        CommonEngine.ShowMessage(strError, 0);
                        txtOldPassword.Focus();
                    }
                }
                catch (Exception ex)
                {
                    CommonEngine.ShowExceptionMessage(ex);
                    txtOldPassword.Focus();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        #endregion
    }
}