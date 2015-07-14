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
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnShutdown = new DevExpress.XtraBars.BarButtonItem();
            this.btnRestart = new DevExpress.XtraBars.BarButtonItem();
            this.btnLockScreen = new DevExpress.XtraBars.BarButtonItem();
            this.ribSystemModule = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribSystemPage = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
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
            this.btnLockScreen});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 4;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribSystemModule});
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
            // ribSystemModule
            // 
            this.ribSystemModule.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribSystemPage});
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
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 533);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(968, 31);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 564);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "frmMain";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "frmMain";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
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
    }
}