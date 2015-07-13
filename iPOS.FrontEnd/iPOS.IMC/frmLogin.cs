using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LanguageEngine = iPOS.IMC.Helper.LanguageManage;
using EncryptEngine = iPOS.Core.Security.EcryptEngine;
using ConfigEngine = iPOS.Core.Helper.ConfigEngine;
using IOEngine = iPOS.Core.Helper.IOEngine;

namespace iPOS.IMC
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
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
            LanguageEngine.ChangeCaptionLabelControl(this.Name, language, new LabelControl[] { lblTitle, lblLanguage, lblUsername, lblPassword });
            LanguageEngine.ChangeCaptionSimpleButton(this.Name, language, new SimpleButton[] { btnLogin, btnExit });
            LanguageEngine.ChangeCaptionImageComboBoxEdit(this.Name, language, icbLanguage);
            LanguageEngine.ChangeTextXtraForm(this, language);
        }

        public frmLogin()
        {
            InitializeComponent();
        }

        public frmLogin(string language)
        {
            InitializeComponent();
            Initialize(language);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            
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
    }
}