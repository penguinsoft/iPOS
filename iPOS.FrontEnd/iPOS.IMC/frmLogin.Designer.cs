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
            this.lblPassword = new DevExpress.XtraEditors.LabelControl();
            this.lblUsername = new DevExpress.XtraEditors.LabelControl();
            this.lblLanguage = new DevExpress.XtraEditors.LabelControl();
            this.icbLanguage = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.imcLanguage = new DevExpress.Utils.ImageCollection(this.components);
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.depError = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.picLogin = new DevExpress.XtraEditors.PictureEdit();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.hplForgotPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRemember.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbLanguage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imcLanguage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogin.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // hplForgotPassword
            // 
            this.hplForgotPassword.EditValue = "Quên mật khẩu?";
            this.hplForgotPassword.Location = new System.Drawing.Point(12, 143);
            this.hplForgotPassword.Name = "hplForgotPassword";
            this.hplForgotPassword.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.hplForgotPassword.Properties.Appearance.Options.UseBackColor = true;
            this.hplForgotPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.hplForgotPassword.Size = new System.Drawing.Size(100, 18);
            this.hplForgotPassword.TabIndex = 18;
            // 
            // chkRemember
            // 
            this.chkRemember.Location = new System.Drawing.Point(192, 113);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Properties.Caption = "Nhớ tài khoản và mật khẩu?";
            this.chkRemember.Size = new System.Drawing.Size(207, 19);
            this.chkRemember.TabIndex = 14;
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Image = global::iPOS.IMC.Properties.Resources.logout_16;
            this.btnExit.Location = new System.Drawing.Point(311, 138);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(84, 23);
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "Thoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(110, 90);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(48, 13);
            this.lblPassword.TabIndex = 23;
            this.lblPassword.Text = "Mật khẩu:";
            // 
            // lblUsername
            // 
            this.lblUsername.Location = new System.Drawing.Point(110, 64);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(79, 13);
            this.lblUsername.TabIndex = 22;
            this.lblUsername.Text = "Tên người dùng:";
            // 
            // lblLanguage
            // 
            this.lblLanguage.Location = new System.Drawing.Point(110, 38);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(51, 13);
            this.lblLanguage.TabIndex = 21;
            this.lblLanguage.Text = "Ngôn ngữ:";
            // 
            // icbLanguage
            // 
            this.icbLanguage.EditValue = "vi-VN";
            this.icbLanguage.Location = new System.Drawing.Point(195, 35);
            this.icbLanguage.Name = "icbLanguage";
            this.icbLanguage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbLanguage.Properties.HtmlImages = this.imcLanguage;
            this.icbLanguage.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Tiếng Anh", "en-US", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Tiếng Việt", "vi-VN", 1)});
            this.icbLanguage.Properties.SmallImages = this.imcLanguage;
            this.icbLanguage.Size = new System.Drawing.Size(200, 20);
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
            this.lblTitle.Location = new System.Drawing.Point(201, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(87, 17);
            this.lblTitle.TabIndex = 19;
            this.lblTitle.Text = "ĐĂNG NHẬP";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(195, 87);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtPassword.Size = new System.Drawing.Size(200, 20);
            this.txtPassword.TabIndex = 13;
            this.txtPassword.EditValueChanged += new System.EventHandler(this.txtPassword_EditValueChanged);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // txtUsername
            // 
            this.txtUsername.EnterMoveNextControl = true;
            this.txtUsername.Location = new System.Drawing.Point(195, 61);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(200, 20);
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
            this.picLogin.Location = new System.Drawing.Point(4, 22);
            this.picLogin.Name = "picLogin";
            this.picLogin.Properties.AllowFocused = false;
            this.picLogin.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picLogin.Properties.Appearance.Options.UseBackColor = true;
            this.picLogin.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picLogin.Properties.ShowMenu = false;
            this.picLogin.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.picLogin.Size = new System.Drawing.Size(87, 122);
            this.picLogin.TabIndex = 20;
            // 
            // btnLogin
            // 
            this.btnLogin.Image = global::iPOS.IMC.Properties.Resources.login_16;
            this.btnLogin.Location = new System.Drawing.Point(194, 138);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(111, 23);
            this.btnLogin.TabIndex = 15;
            this.btnLogin.Text = "Đăng Nhập";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(411, 177);
            this.Controls.Add(this.hplForgotPassword);
            this.Controls.Add(this.chkRemember);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.icbLanguage);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.picLogin);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.HyperLinkEdit hplForgotPassword;
        private DevExpress.XtraEditors.CheckEdit chkRemember;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.LabelControl lblPassword;
        private DevExpress.XtraEditors.LabelControl lblUsername;
        private DevExpress.XtraEditors.LabelControl lblLanguage;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbLanguage;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.PictureEdit picLogin;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.Utils.ImageCollection imcLanguage;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider depError;
    }
}