using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading.Tasks;
using LanguageEngine = iPOS.IMC.Helper.LanguageEngine;
using EncryptEngine = iPOS.Core.Security.EncryptEngine;
using ConfigEngine = iPOS.Core.Helper.ConfigEngine;
using IOEngine = iPOS.Core.Helper.IOEngine;
using CommonEngine = iPOS.IMC.Helper.CommonEngine;
using UserBUS = iPOS.BUS.Systems.SYS_tblUserBUS;
using iPOS.DTO.Systems;
using iPOS.BUS.Systems;
using iPOS.IMC.Helper;
using iPOS.DRO.Systems;
using iPOS.DRO;

namespace iPOS.IMC
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        #region [Personal Methods]
        private void Initialize(string language)
        {
            string username = EncryptEngine.Decrypt(ConfigEngine.Username),
                password = EncryptEngine.Decrypt(ConfigEngine.Password);
            icbLanguage.SelectedIndex = (language.Equals("vi")) ? 1 : 0;
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                txtUsername.Text = EncryptEngine.Decrypt(ConfigEngine.Username);
                txtPassword.Text = EncryptEngine.Decrypt(ConfigEngine.Password);
                txtPassword.Focus();
                chkRemember.Checked = true;
            }
            else chkRemember.Checked = false;
        }

        private void ChangeCaptionLanguage(string language)
        {
            LanguageEngine.ChangeCaptionCheckEdit(this.Name, language, chkRemember);
            LanguageEngine.ChangeCaptionHyperLinkEdit(this.Name, language, hplForgotPassword);
            LanguageEngine.ChangeCaptionLabelControl(this.Name, language, lblTitle);
            LanguageEngine.ChangeCaptionSimpleButton(this.Name, language, new SimpleButton[] { btnLogin, btnExit });
            LanguageEngine.ChangeCaptionImageComboBoxEdit(this.Name, language, icbLanguage);
            LanguageEngine.ChangeCaptionLayoutControlItem(this.Name, language, new DevExpress.XtraLayout.LayoutControlItem[] { lciLanguage, lciUsername, lciPassword });
            LanguageEngine.ChangeTextXtraForm(this, language);
            LanguageEngine.ChangeFormSize(this, this.Name, ConfigEngine.TouchMode);
        }

        private async Task<bool> CheckLogin()
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                CommonEngine.ShowMessage(LanguageEngine.GetMessageCaption("000011", ConfigEngine.Language), MessageType.Error);
                txtUsername.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                CommonEngine.ShowMessage(LanguageEngine.GetMessageCaption("000011", ConfigEngine.Language), MessageType.Error);
                txtPassword.Focus();
                return false;
            }
            try
            {
                SYS_tblUserDRO user = await UserBUS.CheckLogin(txtUsername.Text.Trim(), EncryptEngine.Encrypt(txtPassword.Text.Trim()), ConfigEngine.Language);
                if (user.ResponseItem.IsError)
                {
                    CommonEngine.ShowHTTPErrorMessage(user.ResponseItem);
                    return false;
                }
                else
                {
                    if (user.UserItem != null)
                    {
                        CommonEngine.userInfo = user.UserItem;
                        string temp = user.UserItem.Username.Substring(user.UserItem.Username.IndexOf("|") + 1);
                        user.UserItem.Username = user.UserItem.Username.Replace("|" + temp, "");
                        CommonEngine.SystemDateTime = Convert.ToDateTime(temp);

                        if (user.UserItem.Locked)
                        {
                            CommonEngine.ShowMessage(LanguageEngine.GetMessageCaption("000010", ConfigEngine.Language).Replace("$UserName$", user.UserItem.Username), MessageType.Error);
                            txtUsername.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        CommonEngine.ShowMessage(LanguageEngine.GetMessageCaption("000009", ConfigEngine.Language), MessageType.Error);
                        txtUsername.Focus();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
                txtUsername.Focus();
                return false;
            }

            return true;
        }
        #endregion

        #region [Form Events]
        public frmLogin()
        {
            InitializeComponent();
        }

        public frmLogin(string language)
        {
            InitializeComponent();
            Initialize(language);
            ChangeCaptionLanguage(language);
        }

        private void icbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            IOEngine.Write("Initialize", "Language", icbLanguage.Properties.Items[icbLanguage.SelectedIndex].Value + "");
            ChangeCaptionLanguage(icbLanguage.SelectedIndex == 0 ? "en" : "vi");
        }

        private void txtUsername_EditValueChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text.Contains(" "))
                depError.SetError(txtUsername, LanguageEngine.GetMessageCaption("000004", ConfigEngine.Language));
            else depError.SetError(txtUsername, (string.IsNullOrEmpty(txtUsername.Text)) ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : null);
        }

        private void txtPassword_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtPassword, string.IsNullOrEmpty(txtPassword.Text) ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : null);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (await CheckLogin())
            {
                string username = (chkRemember.Checked) ? EncryptEngine.Encrypt(txtUsername.Text.Trim()) : "";
                string password = (chkRemember.Checked) ? EncryptEngine.Encrypt(txtPassword.Text.Trim()) : "";
                IOEngine.Write("Initialize", "Username", username);
                IOEngine.Write("Initialize", "Password", password);

                ResponseItem result = await SYS_tblActionLogBUS.InsertUpdateLog(new SYS_tblActionLogDTO
                {
                    ID = string.Empty,
                    ActionVN = "Đăng Nhập",
                    ActionEN = "Login",
                    ActionTime = DateTime.Now,
                    FunctionID = string.Empty,
                    FunctionNameVN = "Đăng Nhập",
                    FunctionNameEN = "Login",
                    DescriptionEN = string.Format("Account '{0}' has logined to system at {1}.", txtUsername.Text, DateTime.Now),
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa đăng nhập vào hệ thống vào lúc {1}.", txtUsername.Text, DateTime.Now),
                    FullName = CommonEngine.userInfo.FullName,
                    Activity = "Insert",
                    UserID = CommonEngine.userInfo.UserID,
                    LanguageID = ConfigEngine.Language
                });

                if (result.IsError)
                {
                    CommonEngine.ShowHTTPErrorMessage(result);
                }
                else
                {
                    if (!string.IsNullOrEmpty(result.Message))
                    {
                        CommonEngine.ShowMessage(result.Message, 0);
                        return;
                    }
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btnLogin_Click(null, null);
        }
        #endregion
    }
}