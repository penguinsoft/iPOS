using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using LanguageEngine = iPOS.IMC.Helper.LanguageManage;
using ConfigEngine = iPOS.Core.Helper.ConfigEngine;

namespace iPOS.IMC
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string language = "";

        private void ChangeCaptionLanguage(string language)
        {
            LanguageEngine.ChangeTextRibbonForm(this, language);
            LanguageEngine.ChangeCaptionRibbonPage(this.Name, language, new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribSystemModule, ribProductModule });
            LanguageEngine.ChangeCaptionRibbonPageGroup(this.Name, language, new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribSystemPage, ribUserPermissionPage, ribDatabasePage });
            LanguageEngine.ChangeCaptionBarButtonItem(this.Name, language, new BarButtonItem[] { btnShutdown, btnRestart, btnLockScreen, btnGroupUserList, btnUserList, btnPermission, btnChangePassword, btnBackupDatabase, btnRestoreDatabase, btnRefineDatabase });
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
            if (language.Equals("vi"))
                language = "en";
            else language = "vi";

            ChangeCaptionLanguage(language);
        }
    }
}