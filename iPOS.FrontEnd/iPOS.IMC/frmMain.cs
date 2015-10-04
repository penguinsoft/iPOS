using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using LanguageEngine = iPOS.IMC.Helper.LanguageEngine;
using ConfigEngine = iPOS.Core.Helper.ConfigEngine;
using iPOS.IMC.Helper;
using iPOS.IMC.Systems;
using iPOS.IMC.Products;

namespace iPOS.IMC
{
    public partial class frmMain : RibbonForm
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

            ribbon.SelectedPage = ribProductModule;
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
            CommonEngine.OpenInputForm(new uc_ChangePassword(false), new System.Drawing.Size(400, 225)); //is expired 250
        }

        private void btnUserList_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommonEngine.OpenMdiChildForm(this, new uc_User(ConfigEngine.Language), tabMain);
        }

        private void btnPermission_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommonEngine.OpenMdiChildForm(this, new uc_UserPermission(ConfigEngine.Language), tabMain);
            //if (language.Equals("vi"))
            //    language = "en";
            //else language = "vi";

            //ChangeCaptionLanguage(language);

            //foreach (DevExpress.XtraEditors.XtraForm frm in this.MdiChildren)
            //{
            //    foreach (Control ctl in frm.Controls)
            //    {
            //        if (ctl.Name.StartsWith("uc_"))
            //        {
            //            ChangeCaptionInMdiChildren(ctl);
            //            break;
            //        }
            //    }
            //}
        }

        private void btnProvince_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommonEngine.OpenMdiChildForm(this, new uc_Province(ConfigEngine.Language), tabMain);
        }

        private void btnDistrict_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommonEngine.OpenMdiChildForm(this, new uc_District(ConfigEngine.Language), tabMain);
        }

        private void btnStore_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommonEngine.OpenMdiChildForm(this, new uc_Store(ConfigEngine.Language), tabMain);
        }

        private void btnWarehouse_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommonEngine.OpenMdiChildForm(this, new uc_Warehouse(ConfigEngine.Language), tabMain);
        }

        private void btnStall_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommonEngine.OpenMdiChildForm(this, new uc_Stall(ConfigEngine.Language), tabMain);
        }

        private void btnLevel1_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommonEngine.OpenMdiChildForm(this, new uc_Level1(ConfigEngine.Language), tabMain);
        }
    }
}