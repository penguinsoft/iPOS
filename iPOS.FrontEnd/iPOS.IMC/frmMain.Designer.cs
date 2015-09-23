namespace iPOS.IMC
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnShutdown = new DevExpress.XtraBars.BarButtonItem();
            this.btnRestart = new DevExpress.XtraBars.BarButtonItem();
            this.btnLockScreen = new DevExpress.XtraBars.BarButtonItem();
            this.btnGroupUserList = new DevExpress.XtraBars.BarButtonItem();
            this.btnUserList = new DevExpress.XtraBars.BarButtonItem();
            this.btnPermission = new DevExpress.XtraBars.BarButtonItem();
            this.btnChangePassword = new DevExpress.XtraBars.BarButtonItem();
            this.btnBackupDatabase = new DevExpress.XtraBars.BarButtonItem();
            this.btnRestoreDatabase = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefineDatabase = new DevExpress.XtraBars.BarButtonItem();
            this.btnStore = new DevExpress.XtraBars.BarButtonItem();
            this.btnWarehouse = new DevExpress.XtraBars.BarButtonItem();
            this.btnStall = new DevExpress.XtraBars.BarButtonItem();
            this.btnLevel1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnLevel2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnLevel3 = new DevExpress.XtraBars.BarButtonItem();
            this.btnProduct = new DevExpress.XtraBars.BarButtonItem();
            this.btnProviders = new DevExpress.XtraBars.BarButtonItem();
            this.btnUnit = new DevExpress.XtraBars.BarButtonItem();
            this.btnProvince = new DevExpress.XtraBars.BarButtonItem();
            this.btnDistrict = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportExport = new DevExpress.XtraBars.BarButtonItem();
            this.lblSystemDateCaption = new DevExpress.XtraBars.BarStaticItem();
            this.lblSystemDateValue = new DevExpress.XtraBars.BarStaticItem();
            this.lblSystemTimeCaption = new DevExpress.XtraBars.BarStaticItem();
            this.lblSystemTimeValue = new DevExpress.XtraBars.BarStaticItem();
            this.lblCopyRight = new DevExpress.XtraBars.BarStaticItem();
            this.ribSystemModule = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribSystemPage = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribUserPermissionPage = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribDatabasePage = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribProductModule = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribStorePage = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribProductPage = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribProviderUnit = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribProvincePage = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.tmeMain = new System.Windows.Forms.Timer(this.components);
            this.tabMain = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationIcon = global::iPOS.IMC.Properties.Resources.logo;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnShutdown,
            this.btnRestart,
            this.btnLockScreen,
            this.btnGroupUserList,
            this.btnUserList,
            this.btnPermission,
            this.btnChangePassword,
            this.btnBackupDatabase,
            this.btnRestoreDatabase,
            this.btnRefineDatabase,
            this.btnStore,
            this.btnWarehouse,
            this.btnStall,
            this.btnLevel1,
            this.btnLevel2,
            this.btnLevel3,
            this.btnProduct,
            this.btnProviders,
            this.btnUnit,
            this.btnProvince,
            this.btnDistrict,
            this.btnImportExport,
            this.lblSystemDateCaption,
            this.lblSystemDateValue,
            this.lblSystemTimeCaption,
            this.lblSystemTimeValue,
            this.lblCopyRight});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 28;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribSystemModule,
            this.ribProductModule});
            this.ribbon.Size = new System.Drawing.Size(968, 144);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnShutdown
            // 
            this.btnShutdown.Caption = "Đăng Xuất";
            this.btnShutdown.Id = 1;
            this.btnShutdown.LargeGlyph = global::iPOS.IMC.Properties.Resources.shutdown_32;
            this.btnShutdown.LargeWidth = 70;
            this.btnShutdown.Name = "btnShutdown";
            // 
            // btnRestart
            // 
            this.btnRestart.Caption = "Khởi Động Lại";
            this.btnRestart.Id = 2;
            this.btnRestart.LargeGlyph = global::iPOS.IMC.Properties.Resources.restart_32;
            this.btnRestart.LargeWidth = 70;
            this.btnRestart.Name = "btnRestart";
            // 
            // btnLockScreen
            // 
            this.btnLockScreen.Caption = "Tạm Khóa Màn Hình";
            this.btnLockScreen.Id = 3;
            this.btnLockScreen.LargeGlyph = global::iPOS.IMC.Properties.Resources.lockscreen_32;
            this.btnLockScreen.LargeWidth = 70;
            this.btnLockScreen.Name = "btnLockScreen";
            // 
            // btnGroupUserList
            // 
            this.btnGroupUserList.Caption = "Nhóm Người Dùng";
            this.btnGroupUserList.Id = 4;
            this.btnGroupUserList.LargeGlyph = global::iPOS.IMC.Properties.Resources.group_user_32;
            this.btnGroupUserList.LargeWidth = 70;
            this.btnGroupUserList.Name = "btnGroupUserList";
            this.btnGroupUserList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGroupUserList_ItemClick);
            // 
            // btnUserList
            // 
            this.btnUserList.Caption = "Người Dùng";
            this.btnUserList.Id = 5;
            this.btnUserList.LargeGlyph = global::iPOS.IMC.Properties.Resources.user_32;
            this.btnUserList.LargeWidth = 70;
            this.btnUserList.Name = "btnUserList";
            this.btnUserList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUserList_ItemClick);
            // 
            // btnPermission
            // 
            this.btnPermission.Caption = "Phân Quyền Dữ Liệu";
            this.btnPermission.Id = 6;
            this.btnPermission.LargeGlyph = global::iPOS.IMC.Properties.Resources.permission_32;
            this.btnPermission.LargeWidth = 75;
            this.btnPermission.Name = "btnPermission";
            this.btnPermission.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPermission_ItemClick);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Caption = "Đổi Mật Khẩu";
            this.btnChangePassword.Id = 7;
            this.btnChangePassword.LargeGlyph = global::iPOS.IMC.Properties.Resources.change_password_32;
            this.btnChangePassword.LargeWidth = 70;
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChangePassword_ItemClick);
            // 
            // btnBackupDatabase
            // 
            this.btnBackupDatabase.Caption = "Sao Lưu Dữ Liệu";
            this.btnBackupDatabase.Id = 8;
            this.btnBackupDatabase.LargeGlyph = global::iPOS.IMC.Properties.Resources.backup_database_32;
            this.btnBackupDatabase.LargeWidth = 70;
            this.btnBackupDatabase.Name = "btnBackupDatabase";
            // 
            // btnRestoreDatabase
            // 
            this.btnRestoreDatabase.Caption = "Phục Hồi Dữ Liệu";
            this.btnRestoreDatabase.Id = 9;
            this.btnRestoreDatabase.LargeGlyph = global::iPOS.IMC.Properties.Resources.restore_database_32;
            this.btnRestoreDatabase.LargeWidth = 70;
            this.btnRestoreDatabase.Name = "btnRestoreDatabase";
            // 
            // btnRefineDatabase
            // 
            this.btnRefineDatabase.Caption = "Tinh Chỉnh Dữ Liệu";
            this.btnRefineDatabase.Id = 10;
            this.btnRefineDatabase.LargeGlyph = global::iPOS.IMC.Properties.Resources.refine_database_32;
            this.btnRefineDatabase.LargeWidth = 70;
            this.btnRefineDatabase.Name = "btnRefineDatabase";
            // 
            // btnStore
            // 
            this.btnStore.Caption = "Cửa Hàng";
            this.btnStore.Id = 11;
            this.btnStore.LargeGlyph = global::iPOS.IMC.Properties.Resources.shop_32;
            this.btnStore.LargeWidth = 70;
            this.btnStore.Name = "btnStore";
            this.btnStore.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStore_ItemClick);
            // 
            // btnWarehouse
            // 
            this.btnWarehouse.Caption = "Kho Hàng";
            this.btnWarehouse.Id = 12;
            this.btnWarehouse.LargeGlyph = global::iPOS.IMC.Properties.Resources.inventory_32;
            this.btnWarehouse.LargeWidth = 70;
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnWarehouse_ItemClick);
            // 
            // btnStall
            // 
            this.btnStall.Caption = "Quầy Bán Hàng";
            this.btnStall.Id = 13;
            this.btnStall.LargeGlyph = global::iPOS.IMC.Properties.Resources.cashier_32;
            this.btnStall.LargeWidth = 70;
            this.btnStall.Name = "btnStall";
            this.btnStall.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStall_ItemClick);
            // 
            // btnLevel1
            // 
            this.btnLevel1.Caption = "Ngành Hàng";
            this.btnLevel1.Id = 14;
            this.btnLevel1.LargeGlyph = global::iPOS.IMC.Properties.Resources.level1_32;
            this.btnLevel1.LargeWidth = 70;
            this.btnLevel1.Name = "btnLevel1";
            // 
            // btnLevel2
            // 
            this.btnLevel2.Caption = "Nhóm Hàng";
            this.btnLevel2.Id = 15;
            this.btnLevel2.LargeGlyph = global::iPOS.IMC.Properties.Resources.level2_32;
            this.btnLevel2.LargeWidth = 70;
            this.btnLevel2.Name = "btnLevel2";
            // 
            // btnLevel3
            // 
            this.btnLevel3.Caption = "Phân Nhóm Hàng";
            this.btnLevel3.Id = 16;
            this.btnLevel3.LargeGlyph = global::iPOS.IMC.Properties.Resources.level3_32;
            this.btnLevel3.LargeWidth = 70;
            this.btnLevel3.Name = "btnLevel3";
            // 
            // btnProduct
            // 
            this.btnProduct.Caption = "Hàng Hóa";
            this.btnProduct.Id = 17;
            this.btnProduct.LargeGlyph = global::iPOS.IMC.Properties.Resources.product_32;
            this.btnProduct.LargeWidth = 70;
            this.btnProduct.Name = "btnProduct";
            // 
            // btnProviders
            // 
            this.btnProviders.Caption = "Nhà Cung Cấp";
            this.btnProviders.Id = 18;
            this.btnProviders.LargeGlyph = global::iPOS.IMC.Properties.Resources.providers_32;
            this.btnProviders.LargeWidth = 70;
            this.btnProviders.Name = "btnProviders";
            // 
            // btnUnit
            // 
            this.btnUnit.Caption = "Đơn Vị Tính";
            this.btnUnit.Id = 19;
            this.btnUnit.LargeGlyph = global::iPOS.IMC.Properties.Resources.units_32;
            this.btnUnit.LargeWidth = 70;
            this.btnUnit.Name = "btnUnit";
            // 
            // btnProvince
            // 
            this.btnProvince.Caption = "Tỉnh Thành";
            this.btnProvince.Id = 20;
            this.btnProvince.LargeGlyph = global::iPOS.IMC.Properties.Resources.province_32;
            this.btnProvince.LargeWidth = 70;
            this.btnProvince.Name = "btnProvince";
            this.btnProvince.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProvince_ItemClick);
            // 
            // btnDistrict
            // 
            this.btnDistrict.Caption = "Quận Huyện";
            this.btnDistrict.Id = 21;
            this.btnDistrict.LargeGlyph = global::iPOS.IMC.Properties.Resources.district_32;
            this.btnDistrict.LargeWidth = 70;
            this.btnDistrict.Name = "btnDistrict";
            this.btnDistrict.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDistrict_ItemClick);
            // 
            // btnImportExport
            // 
            this.btnImportExport.Caption = "Phương Thức Nhập Xuất";
            this.btnImportExport.Id = 22;
            this.btnImportExport.LargeGlyph = global::iPOS.IMC.Properties.Resources.import_export_method_32;
            this.btnImportExport.LargeWidth = 80;
            this.btnImportExport.Name = "btnImportExport";
            // 
            // lblSystemDateCaption
            // 
            this.lblSystemDateCaption.Caption = "Ngày hệ thống:";
            this.lblSystemDateCaption.Glyph = global::iPOS.IMC.Properties.Resources.calendar_16;
            this.lblSystemDateCaption.Id = 23;
            this.lblSystemDateCaption.Name = "lblSystemDateCaption";
            this.lblSystemDateCaption.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblSystemDateValue
            // 
            this.lblSystemDateValue.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.lblSystemDateValue.Caption = "24/07/1992";
            this.lblSystemDateValue.Id = 24;
            this.lblSystemDateValue.Name = "lblSystemDateValue";
            this.lblSystemDateValue.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblSystemTimeCaption
            // 
            this.lblSystemTimeCaption.Caption = "Giờ hệ thống:";
            this.lblSystemTimeCaption.Glyph = global::iPOS.IMC.Properties.Resources.clock_16;
            this.lblSystemTimeCaption.Id = 25;
            this.lblSystemTimeCaption.Name = "lblSystemTimeCaption";
            this.lblSystemTimeCaption.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblSystemTimeValue
            // 
            this.lblSystemTimeValue.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.lblSystemTimeValue.Caption = "12:00:00 AM";
            this.lblSystemTimeValue.Id = 26;
            this.lblSystemTimeValue.Name = "lblSystemTimeValue";
            this.lblSystemTimeValue.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblCopyRight
            // 
            this.lblCopyRight.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.lblCopyRight.Caption = "© Copyright by <b><color=RED>Penguin Software</color></b> Company, 2015. All righ" +
    "t reserved.";
            this.lblCopyRight.Id = 27;
            this.lblCopyRight.Name = "lblCopyRight";
            this.lblCopyRight.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // ribSystemModule
            // 
            this.ribSystemModule.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribSystemPage,
            this.ribUserPermissionPage,
            this.ribDatabasePage});
            this.ribSystemModule.Name = "ribSystemModule";
            this.ribSystemModule.Text = "Hệ Thống";
            // 
            // ribSystemPage
            // 
            this.ribSystemPage.ItemLinks.Add(this.btnShutdown);
            this.ribSystemPage.ItemLinks.Add(this.btnRestart);
            this.ribSystemPage.ItemLinks.Add(this.btnLockScreen, true);
            this.ribSystemPage.Name = "ribSystemPage";
            this.ribSystemPage.ShowCaptionButton = false;
            this.ribSystemPage.Text = "Hệ Thống";
            // 
            // ribUserPermissionPage
            // 
            this.ribUserPermissionPage.ItemLinks.Add(this.btnGroupUserList);
            this.ribUserPermissionPage.ItemLinks.Add(this.btnUserList);
            this.ribUserPermissionPage.ItemLinks.Add(this.btnPermission, true);
            this.ribUserPermissionPage.ItemLinks.Add(this.btnChangePassword);
            this.ribUserPermissionPage.Name = "ribUserPermissionPage";
            this.ribUserPermissionPage.ShowCaptionButton = false;
            this.ribUserPermissionPage.Text = "Người Dùng - Bảo Mật";
            // 
            // ribDatabasePage
            // 
            this.ribDatabasePage.ItemLinks.Add(this.btnBackupDatabase);
            this.ribDatabasePage.ItemLinks.Add(this.btnRestoreDatabase);
            this.ribDatabasePage.ItemLinks.Add(this.btnRefineDatabase, true);
            this.ribDatabasePage.Name = "ribDatabasePage";
            this.ribDatabasePage.ShowCaptionButton = false;
            this.ribDatabasePage.Text = "Công Cụ Dữ Liệu";
            // 
            // ribProductModule
            // 
            this.ribProductModule.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribStorePage,
            this.ribProductPage,
            this.ribProviderUnit,
            this.ribProvincePage});
            this.ribProductModule.Name = "ribProductModule";
            this.ribProductModule.Text = "Hàng Hóa";
            // 
            // ribStorePage
            // 
            this.ribStorePage.ItemLinks.Add(this.btnStore);
            this.ribStorePage.ItemLinks.Add(this.btnWarehouse);
            this.ribStorePage.ItemLinks.Add(this.btnStall);
            this.ribStorePage.Name = "ribStorePage";
            this.ribStorePage.ShowCaptionButton = false;
            this.ribStorePage.Text = "Cửa Hàng - Kho Hàng";
            // 
            // ribProductPage
            // 
            this.ribProductPage.ItemLinks.Add(this.btnLevel1);
            this.ribProductPage.ItemLinks.Add(this.btnLevel2);
            this.ribProductPage.ItemLinks.Add(this.btnLevel3);
            this.ribProductPage.ItemLinks.Add(this.btnProduct, true);
            this.ribProductPage.Name = "ribProductPage";
            this.ribProductPage.ShowCaptionButton = false;
            this.ribProductPage.Text = "Hàng Hóa";
            // 
            // ribProviderUnit
            // 
            this.ribProviderUnit.ItemLinks.Add(this.btnProviders);
            this.ribProviderUnit.ItemLinks.Add(this.btnUnit, true);
            this.ribProviderUnit.Name = "ribProviderUnit";
            this.ribProviderUnit.ShowCaptionButton = false;
            this.ribProviderUnit.Text = "Nhà Cung Cấp - Đơn Vị Tính";
            // 
            // ribProvincePage
            // 
            this.ribProvincePage.ItemLinks.Add(this.btnProvince);
            this.ribProvincePage.ItemLinks.Add(this.btnDistrict);
            this.ribProvincePage.ItemLinks.Add(this.btnImportExport, true);
            this.ribProvincePage.Name = "ribProvincePage";
            this.ribProvincePage.ShowCaptionButton = false;
            this.ribProvincePage.Text = "Danh Mục Khác";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.lblCopyRight);
            this.ribbonStatusBar.ItemLinks.Add(this.lblSystemDateCaption, true);
            this.ribbonStatusBar.ItemLinks.Add(this.lblSystemDateValue, true);
            this.ribbonStatusBar.ItemLinks.Add(this.lblSystemTimeCaption, true);
            this.ribbonStatusBar.ItemLinks.Add(this.lblSystemTimeValue, true);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 533);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(968, 31);
            // 
            // tmeMain
            // 
            this.tmeMain.Enabled = true;
            this.tmeMain.Interval = 1000;
            this.tmeMain.Tick += new System.EventHandler(this.tmeMain_Tick);
            // 
            // tabMain
            // 
            this.tabMain.MdiParent = this;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 564);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "iPOS Management 1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribSystemModule;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribSystemPage;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnShutdown;
        private DevExpress.XtraBars.BarButtonItem btnRestart;
        private DevExpress.XtraBars.BarButtonItem btnLockScreen;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribUserPermissionPage;
        private DevExpress.XtraBars.BarButtonItem btnGroupUserList;
        private DevExpress.XtraBars.BarButtonItem btnUserList;
        private DevExpress.XtraBars.BarButtonItem btnPermission;
        private DevExpress.XtraBars.BarButtonItem btnChangePassword;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribDatabasePage;
        private DevExpress.XtraBars.BarButtonItem btnBackupDatabase;
        private DevExpress.XtraBars.BarButtonItem btnRestoreDatabase;
        private DevExpress.XtraBars.BarButtonItem btnRefineDatabase;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribProductModule;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribStorePage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribProductPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribProviderUnit;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribProvincePage;
        private DevExpress.XtraBars.BarButtonItem btnStore;
        private DevExpress.XtraBars.BarButtonItem btnWarehouse;
        private DevExpress.XtraBars.BarButtonItem btnStall;
        private DevExpress.XtraBars.BarButtonItem btnLevel1;
        private DevExpress.XtraBars.BarButtonItem btnLevel2;
        private DevExpress.XtraBars.BarButtonItem btnLevel3;
        private DevExpress.XtraBars.BarButtonItem btnProduct;
        private DevExpress.XtraBars.BarButtonItem btnProviders;
        private DevExpress.XtraBars.BarButtonItem btnUnit;
        private DevExpress.XtraBars.BarButtonItem btnProvince;
        private DevExpress.XtraBars.BarButtonItem btnDistrict;
        private DevExpress.XtraBars.BarButtonItem btnImportExport;
        private DevExpress.XtraBars.BarStaticItem lblSystemDateCaption;
        private DevExpress.XtraBars.BarStaticItem lblSystemDateValue;
        private DevExpress.XtraBars.BarStaticItem lblSystemTimeCaption;
        private DevExpress.XtraBars.BarStaticItem lblSystemTimeValue;
        private DevExpress.XtraBars.BarStaticItem lblCopyRight;
        private System.Windows.Forms.Timer tmeMain;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager tabMain;
    }
}