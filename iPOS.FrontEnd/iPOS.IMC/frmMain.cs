using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using LanguageEngine = iPOS.IMC.Helper.LanguageEngine;
using ConfigEngine = iPOS.Core.Helper.ConfigEngine;
using iPOS.IMC.Helper;
using iPOS.IMC.Systems;

namespace iPOS.IMC
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string language = "";

        private void ChangeCaptionInMdiChildren(Control control)
        {
            switch (control.Name.ToLower())
            {
                case "uc_groupuser":
                    uc_GroupUser uc_groupuser = (uc_GroupUser)control;
                    uc_groupuser.ChangeLanguage(language);
                    break;
            }
        }

        private void ChangeCaptionLanguage(string language)
        {
            LanguageEngine.ChangeTextRibbonForm(this, language);
            LanguageEngine.ChangeCaptionRibbonPage(this.Name, language, new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribSystemModule, ribProductModule });
            LanguageEngine.ChangeCaptionRibbonPageGroup(this.Name, language, new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribSystemPage, ribUserPermissionPage, ribDatabasePage });
            LanguageEngine.ChangeCaptionBarButtonItem(this.Name, language, new BarButtonItem[] { btnShutdown, btnRestart, btnLockScreen, btnGroupUserList, btnUserList, btnPermission, btnChangePassword, btnBackupDatabase, btnRestoreDatabase, btnRefineDatabase });

            lblSystemDateValue.Caption = string.Format("<b><color=RED>{0}</color></b>", CommonEngine.SystemDateTime.ToString(ConfigEngine.DateFormat));
            lblSystemTimeValue.Caption = string.Format("<b><color=RED>{0}</color></b>", CommonEngine.SystemDateTime.ToString(ConfigEngine.TimeFormat));
        }

        public frmMain()
        {
            InitializeComponent();
        }

        public frmMain(string language)
        {
            InitializeComponent();
            language = ConfigEngine.Language;
            ChangeCaptionLanguage(language);
        }

        private void btnGroupUserList_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommonEngine.OpenMdiChildForm(this, new uc_GroupUser(ConfigEngine.Language), tabMain);
        }

        private void tmeMain_Tick(object sender, EventArgs e)
        {
            CommonEngine.SystemDateTime = CommonEngine.SystemDateTime.AddSeconds(1);
            lblSystemDateValue.Caption = string.Format("<b><color=RED>{0}</color></b>", CommonEngine.SystemDateTime.ToString(ConfigEngine.DateFormat));
            lblSystemTimeValue.Caption = string.Format("<b><color=RED>{0}</color></b>", CommonEngine.SystemDateTime.ToString(ConfigEngine.TimeFormat));
        }

        private void btnChangePassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommonEngine.OpenInputForm(new uc_ChangePassword(), new System.Drawing.Size(400, 225));
        }

        private void btnUserList_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommonEngine.OpenMdiChildForm(this, new uc_User(), tabMain);
        }

        private void btnPermission_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (language.Equals("vi"))
                language = "en";
            else language = "vi";

            ChangeCaptionLanguage(language);

            foreach (DevExpress.XtraEditors.XtraForm frm in this.MdiChildren)
            {
                foreach (Control ctl in frm.Controls)
                {
                    if (ctl.Name.StartsWith("uc_"))
                    {
                        ChangeCaptionInMdiChildren(ctl);
                        break;
                    }
                }
            }
        }
    }
}