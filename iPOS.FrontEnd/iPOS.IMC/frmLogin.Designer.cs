namespace iPOS.IMC
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.hplForgotPassword = new DevExpress.XtraEditors.HyperLinkEdit();
            this.chkRemember = new DevExpress.XtraEditors.CheckEdit();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.icbLanguage = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.imcLanguage = new DevExpress.Utils.ImageCollection(this.components);
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.depError = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.picLogin = new DevExpress.XtraEditors.PictureEdit();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.locMain = new DevExpress.XtraLayout.LayoutControl();
            this.logLogin = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciLanguage = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciUsername = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciRememberPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciButtonLogin = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciButtonExit = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciLoginTitle = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciForgotPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciLoginPicture = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.hplForgotPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRemember.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbLanguage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imcLanguage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locMain)).BeginInit();
            this.locMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLanguage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRememberPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLoginTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciForgotPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLoginPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // hplForgotPassword
            // 
            this.hplForgotPassword.EditValue = "Quên mật khẩu?";
            this.hplForgotPassword.Location = new System.Drawing.Point(12, 134);
            this.hplForgotPassword.Name = "hplForgotPassword";
            this.hplForgotPassword.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.hplForgotPassword.Properties.Appearance.Options.UseBackColor = true;
            this.hplForgotPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.hplForgotPassword.Size = new System.Drawing.Size(130, 18);
            this.hplForgotPassword.StyleController = this.locMain;
            this.hplForgotPassword.TabIndex = 18;
            // 
            // chkRemember
            // 
            this.chkRemember.Location = new System.Drawing.Point(204, 111);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Properties.Caption = "Nhớ tài khoản và mật khẩu?";
            this.chkRemember.Size = new System.Drawing.Size(195, 19);
            this.chkRemember.StyleController = this.locMain;
            this.chkRemember.TabIndex = 14;
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Image = global::iPOS.IMC.Properties.Resources.logout_16;
            this.btnExit.Location = new System.Drawing.Point(289, 134);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(110, 22);
            this.btnExit.StyleController = this.locMain;
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "Thoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // icbLanguage
            // 
            this.icbLanguage.EditValue = "vi-VN";
            this.icbLanguage.Location = new System.Drawing.Point(207, 39);
            this.icbLanguage.Name = "icbLanguage";
            this.icbLanguage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbLanguage.Properties.HtmlImages = this.imcLanguage;
            this.icbLanguage.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Tiếng Anh", "en-US", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Tiếng Việt", "vi-VN", 1)});
            this.icbLanguage.Properties.SmallImages = this.imcLanguage;
            this.icbLanguage.Size = new System.Drawing.Size(192, 20);
            this.icbLanguage.StyleController = this.locMain;
            this.icbLanguage.TabIndex = 17;
            this.icbLanguage.SelectedIndexChanged += new System.EventHandler(this.icbLanguage_SelectedIndexChanged);
            // 
            // imcLanguage
            // 
            this.imcLanguage.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imcLanguage.ImageStream")));
            this.imcLanguage.InsertImage(global::iPOS.IMC.Properties.Resources.uk_flag_16, "uk_flag_16", typeof(global::iPOS.IMC.Properties.Resources), 0);
            this.imcLanguage.Images.SetKeyName(0, "uk_flag_16");
            this.imcLanguage.InsertImage(global::iPOS.IMC.Properties.Resources.vi_flag_16, "vi_flag_16", typeof(global::iPOS.IMC.Properties.Resources), 1);
            this.imcLanguage.Images.SetKeyName(1, "vi_flag_16");
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(162, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(87, 17);
            this.lblTitle.StyleController = this.locMain;
            this.lblTitle.TabIndex = 19;
            this.lblTitle.Text = "ĐĂNG NHẬP";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(207, 87);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtPassword.Size = new System.Drawing.Size(192, 20);
            this.txtPassword.StyleController = this.locMain;
            this.txtPassword.TabIndex = 13;
            this.txtPassword.EditValueChanged += new System.EventHandler(this.txtPassword_EditValueChanged);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // txtUsername
            // 
            this.txtUsername.EnterMoveNextControl = true;
            this.txtUsername.Location = new System.Drawing.Point(207, 63);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(192, 20);
            this.txtUsername.StyleController = this.locMain;
            this.txtUsername.TabIndex = 12;
            this.txtUsername.EditValueChanged += new System.EventHandler(this.txtUsername_EditValueChanged);
            // 
            // depError
            // 
            this.depError.ContainerControl = this;
            // 
            // picLogin
            // 
            this.picLogin.EditValue = global::iPOS.IMC.Properties.Resources.login_banner;
            this.picLogin.Location = new System.Drawing.Point(12, 39);
            this.picLogin.Name = "picLogin";
            this.picLogin.Properties.AllowFocused = false;
            this.picLogin.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picLogin.Properties.Appearance.Options.UseBackColor = true;
            this.picLogin.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picLogin.Properties.ShowMenu = false;
            this.picLogin.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.picLogin.Size = new System.Drawing.Size(130, 91);
            this.picLogin.StyleController = this.locMain;
            this.picLogin.TabIndex = 20;
            // 
            // btnLogin
            // 
            this.btnLogin.Image = global::iPOS.IMC.Properties.Resources.login_16;
            this.btnLogin.Location = new System.Drawing.Point(146, 134);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(139, 22);
            this.btnLogin.StyleController = this.locMain;
            this.btnLogin.TabIndex = 15;
            this.btnLogin.Text = "Đăng Nhập";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // locMain
            // 
            this.locMain.Controls.Add(this.picLogin);
            this.locMain.Controls.Add(this.btnExit);
            this.locMain.Controls.Add(this.hplForgotPassword);
            this.locMain.Controls.Add(this.lblTitle);
            this.locMain.Controls.Add(this.chkRemember);
            this.locMain.Controls.Add(this.icbLanguage);
            this.locMain.Controls.Add(this.txtUsername);
            this.locMain.Controls.Add(this.txtPassword);
            this.locMain.Controls.Add(this.btnLogin);
            this.locMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.locMain.Location = new System.Drawing.Point(0, 0);
            this.locMain.Name = "locMain";
            this.locMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(729, 375, 250, 350);
            this.locMain.Root = this.logLogin;
            this.locMain.Size = new System.Drawing.Size(411, 169);
            this.locMain.TabIndex = 24;
            this.locMain.Text = "layoutControl1";
            // 
            // logLogin
            // 
            this.logLogin.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.logLogin.GroupBordersVisible = false;
            this.logLogin.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciLanguage,
            this.lciUsername,
            this.lciPassword,
            this.lciRememberPassword,
            this.lciButtonLogin,
            this.lciButtonExit,
            this.lciForgotPassword,
            this.lciLoginPicture,
            this.lciLoginTitle});
            this.logLogin.Location = new System.Drawing.Point(0, 0);
            this.logLogin.Name = "Root";
            this.logLogin.Size = new System.Drawing.Size(411, 169);
            this.logLogin.TextVisible = false;
            // 
            // lciLanguage
            // 
            this.lciLanguage.Control = this.icbLanguage;
            this.lciLanguage.Location = new System.Drawing.Point(134, 27);
            this.lciLanguage.Name = "lciLanguage";
            this.lciLanguage.Size = new System.Drawing.Size(257, 24);
            this.lciLanguage.TextSize = new System.Drawing.Size(57, 13);
            // 
            // lciUsername
            // 
            this.lciUsername.Control = this.txtUsername;
            this.lciUsername.Location = new System.Drawing.Point(134, 51);
            this.lciUsername.Name = "lciUsername";
            this.lciUsername.Size = new System.Drawing.Size(257, 24);
            this.lciUsername.TextSize = new System.Drawing.Size(57, 13);
            // 
            // lciPassword
            // 
            this.lciPassword.Control = this.txtPassword;
            this.lciPassword.Location = new System.Drawing.Point(134, 75);
            this.lciPassword.Name = "lciPassword";
            this.lciPassword.Size = new System.Drawing.Size(257, 24);
            this.lciPassword.TextSize = new System.Drawing.Size(57, 13);
            // 
            // lciRememberPassword
            // 
            this.lciRememberPassword.Control = this.chkRemember;
            this.lciRememberPassword.Location = new System.Drawing.Point(134, 99);
            this.lciRememberPassword.Name = "lciRememberPassword";
            this.lciRememberPassword.Padding = new DevExpress.XtraLayout.Utils.Padding(60, 2, 2, 2);
            this.lciRememberPassword.Size = new System.Drawing.Size(257, 23);
            this.lciRememberPassword.TextSize = new System.Drawing.Size(0, 0);
            this.lciRememberPassword.TextVisible = false;
            // 
            // lciButtonLogin
            // 
            this.lciButtonLogin.Control = this.btnLogin;
            this.lciButtonLogin.Location = new System.Drawing.Point(134, 122);
            this.lciButtonLogin.Name = "lciButtonLogin";
            this.lciButtonLogin.Size = new System.Drawing.Size(143, 27);
            this.lciButtonLogin.TextSize = new System.Drawing.Size(0, 0);
            this.lciButtonLogin.TextVisible = false;
            // 
            // lciButtonExit
            // 
            this.lciButtonExit.Control = this.btnExit;
            this.lciButtonExit.Location = new System.Drawing.Point(277, 122);
            this.lciButtonExit.Name = "lciButtonExit";
            this.lciButtonExit.Size = new System.Drawing.Size(114, 27);
            this.lciButtonExit.TextSize = new System.Drawing.Size(0, 0);
            this.lciButtonExit.TextVisible = false;
            // 
            // lciLoginTitle
            // 
            this.lciLoginTitle.Control = this.lblTitle;
            this.lciLoginTitle.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lciLoginTitle.Location = new System.Drawing.Point(0, 0);
            this.lciLoginTitle.Name = "lciLoginTitle";
            this.lciLoginTitle.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 5, 5);
            this.lciLoginTitle.Size = new System.Drawing.Size(391, 27);
            this.lciLoginTitle.TextSize = new System.Drawing.Size(0, 0);
            this.lciLoginTitle.TextVisible = false;
            // 
            // lciForgotPassword
            // 
            this.lciForgotPassword.Control = this.hplForgotPassword;
            this.lciForgotPassword.Location = new System.Drawing.Point(0, 122);
            this.lciForgotPassword.MinSize = new System.Drawing.Size(54, 22);
            this.lciForgotPassword.Name = "lciForgotPassword";
            this.lciForgotPassword.Size = new System.Drawing.Size(134, 27);
            this.lciForgotPassword.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciForgotPassword.TextSize = new System.Drawing.Size(0, 0);
            this.lciForgotPassword.TextVisible = false;
            // 
            // lciLoginPicture
            // 
            this.lciLoginPicture.Control = this.picLogin;
            this.lciLoginPicture.Location = new System.Drawing.Point(0, 27);
            this.lciLoginPicture.Name = "lciLoginPicture";
            this.lciLoginPicture.Size = new System.Drawing.Size(134, 95);
            this.lciLoginPicture.TextSize = new System.Drawing.Size(0, 0);
            this.lciLoginPicture.TextVisible = false;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(411, 169);
            this.Controls.Add(this.locMain);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập Hệ Thống - iPOS Management 1.0";
            ((System.ComponentModel.ISupportInitialize)(this.hplForgotPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRemember.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbLanguage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imcLanguage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locMain)).EndInit();
            this.locMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLanguage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRememberPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLoginTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciForgotPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLoginPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.HyperLinkEdit hplForgotPassword;
        private DevExpress.XtraEditors.CheckEdit chkRemember;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbLanguage;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.PictureEdit picLogin;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.Utils.ImageCollection imcLanguage;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider depError;
        private DevExpress.XtraLayout.LayoutControl locMain;
        private DevExpress.XtraLayout.LayoutControlGroup logLogin;
        private DevExpress.XtraLayout.LayoutControlItem lciLanguage;
        private DevExpress.XtraLayout.LayoutControlItem lciUsername;
        private DevExpress.XtraLayout.LayoutControlItem lciPassword;
        private DevExpress.XtraLayout.LayoutControlItem lciRememberPassword;
        private DevExpress.XtraLayout.LayoutControlItem lciButtonLogin;
        private DevExpress.XtraLayout.LayoutControlItem lciButtonExit;
        private DevExpress.XtraLayout.LayoutControlItem lciLoginTitle;
        private DevExpress.XtraLayout.LayoutControlItem lciForgotPassword;
        private DevExpress.XtraLayout.LayoutControlItem lciLoginPicture;
    }
}