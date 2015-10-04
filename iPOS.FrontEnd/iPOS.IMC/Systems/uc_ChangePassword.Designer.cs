namespace iPOS.IMC.Systems
{
    partial class uc_ChangePassword
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.depError = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.lciButtonCancel = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.locMain = new DevExpress.XtraLayout.LayoutControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtConfirmPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtNewPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtOldPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtGroupName = new DevExpress.XtraEditors.TextEdit();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.lblNote = new DevExpress.XtraEditors.LabelControl();
            this.logMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.esiFirst = new DevExpress.XtraLayout.EmptySpaceItem();
            this.logDetail = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciLabelNote = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciUsername = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciGroupName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciOldPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciNewPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciConfirmPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciButtonSave = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.depError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locMain)).BeginInit();
            this.locMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLabelNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGroupName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOldPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNewPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciConfirmPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonSave)).BeginInit();
            this.SuspendLayout();
            // 
            // depError
            // 
            this.depError.ContainerControl = this;
            // 
            // lciButtonCancel
            // 
            this.lciButtonCancel.Control = this.btnCancel;
            this.lciButtonCancel.CustomizationFormText = "lciButtonCancel";
            this.lciButtonCancel.Location = new System.Drawing.Point(295, 189);
            this.lciButtonCancel.Name = "lciButtonCancel";
            this.lciButtonCancel.Size = new System.Drawing.Size(100, 28);
            this.lciButtonCancel.TextSize = new System.Drawing.Size(0, 0);
            this.lciButtonCancel.TextVisible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::iPOS.IMC.Properties.Resources.cancel_16;
            this.btnCancel.Location = new System.Drawing.Point(297, 191);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 22);
            this.btnCancel.StyleController = this.locMain;
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // locMain
            // 
            this.locMain.Controls.Add(this.btnSave);
            this.locMain.Controls.Add(this.btnCancel);
            this.locMain.Controls.Add(this.txtConfirmPassword);
            this.locMain.Controls.Add(this.txtNewPassword);
            this.locMain.Controls.Add(this.txtOldPassword);
            this.locMain.Controls.Add(this.txtGroupName);
            this.locMain.Controls.Add(this.txtUsername);
            this.locMain.Controls.Add(this.lblNote);
            this.locMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.locMain.Location = new System.Drawing.Point(0, 0);
            this.locMain.Name = "locMain";
            this.locMain.Root = this.logMain;
            this.locMain.Size = new System.Drawing.Size(395, 217);
            this.locMain.TabIndex = 1;
            this.locMain.Text = "layoutControl1";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::iPOS.IMC.Properties.Resources.save_end_16;
            this.btnSave.Location = new System.Drawing.Point(197, 191);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 22);
            this.btnSave.StyleController = this.locMain;
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Lưu Lại";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.EnterMoveNextControl = true;
            this.txtConfirmPassword.Location = new System.Drawing.Point(112, 155);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Properties.UseSystemPasswordChar = true;
            this.txtConfirmPassword.Size = new System.Drawing.Size(269, 20);
            this.txtConfirmPassword.StyleController = this.locMain;
            this.txtConfirmPassword.TabIndex = 4;
            this.txtConfirmPassword.EditValueChanged += new System.EventHandler(this.txtConfirmPassword_EditValueChanged);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.EnterMoveNextControl = true;
            this.txtNewPassword.Location = new System.Drawing.Point(112, 131);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Properties.UseSystemPasswordChar = true;
            this.txtNewPassword.Size = new System.Drawing.Size(269, 20);
            this.txtNewPassword.StyleController = this.locMain;
            this.txtNewPassword.TabIndex = 3;
            this.txtNewPassword.EditValueChanged += new System.EventHandler(this.txtNewPassword_EditValueChanged);
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.EnterMoveNextControl = true;
            this.txtOldPassword.Location = new System.Drawing.Point(112, 107);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Properties.UseSystemPasswordChar = true;
            this.txtOldPassword.Size = new System.Drawing.Size(269, 20);
            this.txtOldPassword.StyleController = this.locMain;
            this.txtOldPassword.TabIndex = 2;
            this.txtOldPassword.EditValueChanged += new System.EventHandler(this.txtOldPassword_EditValueChanged);
            // 
            // txtGroupName
            // 
            this.txtGroupName.EnterMoveNextControl = true;
            this.txtGroupName.Location = new System.Drawing.Point(112, 83);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtGroupName.Properties.Appearance.Options.UseFont = true;
            this.txtGroupName.Properties.ReadOnly = true;
            this.txtGroupName.Size = new System.Drawing.Size(269, 20);
            this.txtGroupName.StyleController = this.locMain;
            this.txtGroupName.TabIndex = 1;
            this.txtGroupName.TabStop = false;
            // 
            // txtUsername
            // 
            this.txtUsername.EnterMoveNextControl = true;
            this.txtUsername.Location = new System.Drawing.Point(112, 59);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtUsername.Properties.Appearance.Options.UseFont = true;
            this.txtUsername.Properties.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(269, 20);
            this.txtUsername.StyleController = this.locMain;
            this.txtUsername.TabIndex = 0;
            this.txtUsername.TabStop = false;
            // 
            // lblNote
            // 
            this.lblNote.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblNote.Location = new System.Drawing.Point(19, 37);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(357, 13);
            this.lblNote.StyleController = this.locMain;
            this.lblNote.TabIndex = 4;
            this.lblNote.Text = "Your password has expired. Please enter new password.";
            // 
            // logMain
            // 
            this.logMain.CustomizationFormText = "logMain";
            this.logMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.logMain.GroupBordersVisible = false;
            this.logMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.esiFirst,
            this.logDetail,
            this.lciButtonCancel,
            this.lciButtonSave});
            this.logMain.Location = new System.Drawing.Point(0, 0);
            this.logMain.Name = "logMain";
            this.logMain.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.logMain.Size = new System.Drawing.Size(395, 217);
            this.logMain.TextVisible = false;
            // 
            // esiFirst
            // 
            this.esiFirst.AllowHotTrack = false;
            this.esiFirst.CustomizationFormText = "esiFirst";
            this.esiFirst.Location = new System.Drawing.Point(0, 189);
            this.esiFirst.MaxSize = new System.Drawing.Size(195, 27);
            this.esiFirst.MinSize = new System.Drawing.Size(195, 27);
            this.esiFirst.Name = "esiFirst";
            this.esiFirst.Size = new System.Drawing.Size(195, 28);
            this.esiFirst.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.esiFirst.TextSize = new System.Drawing.Size(0, 0);
            // 
            // logDetail
            // 
            this.logDetail.CustomizationFormText = "layoutControlGroup1";
            this.logDetail.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciLabelNote,
            this.lciUsername,
            this.lciGroupName,
            this.lciOldPassword,
            this.lciNewPassword,
            this.lciConfirmPassword});
            this.logDetail.Location = new System.Drawing.Point(0, 0);
            this.logDetail.Name = "logDetail";
            this.logDetail.Size = new System.Drawing.Size(395, 189);
            this.logDetail.Text = "Password Information";
            // 
            // lciLabelNote
            // 
            this.lciLabelNote.Control = this.lblNote;
            this.lciLabelNote.CustomizationFormText = "lciLabelNote";
            this.lciLabelNote.Location = new System.Drawing.Point(0, 0);
            this.lciLabelNote.Name = "lciLabelNote";
            this.lciLabelNote.Padding = new DevExpress.XtraLayout.Utils.Padding(7, 7, 7, 7);
            this.lciLabelNote.Size = new System.Drawing.Size(371, 27);
            this.lciLabelNote.TextSize = new System.Drawing.Size(0, 0);
            this.lciLabelNote.TextVisible = false;
            this.lciLabelNote.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // lciUsername
            // 
            this.lciUsername.Control = this.txtUsername;
            this.lciUsername.CustomizationFormText = "Tên tài khoản:";
            this.lciUsername.Location = new System.Drawing.Point(0, 27);
            this.lciUsername.Name = "lciUsername";
            this.lciUsername.Size = new System.Drawing.Size(371, 24);
            this.lciUsername.Text = "Tên tài khoản:";
            this.lciUsername.TextSize = new System.Drawing.Size(95, 13);
            // 
            // lciGroupName
            // 
            this.lciGroupName.Control = this.txtGroupName;
            this.lciGroupName.CustomizationFormText = "Nhóm người dùng:";
            this.lciGroupName.Location = new System.Drawing.Point(0, 51);
            this.lciGroupName.Name = "lciGroupName";
            this.lciGroupName.Size = new System.Drawing.Size(371, 24);
            this.lciGroupName.Text = "Nhóm người dùng:";
            this.lciGroupName.TextSize = new System.Drawing.Size(95, 13);
            // 
            // lciOldPassword
            // 
            this.lciOldPassword.Control = this.txtOldPassword;
            this.lciOldPassword.CustomizationFormText = "Mật khẩu cũ:";
            this.lciOldPassword.Location = new System.Drawing.Point(0, 75);
            this.lciOldPassword.Name = "lciOldPassword";
            this.lciOldPassword.Size = new System.Drawing.Size(371, 24);
            this.lciOldPassword.Text = "Mật khẩu cũ:";
            this.lciOldPassword.TextSize = new System.Drawing.Size(95, 13);
            // 
            // lciNewPassword
            // 
            this.lciNewPassword.Control = this.txtNewPassword;
            this.lciNewPassword.CustomizationFormText = "Mật khẩu mới:";
            this.lciNewPassword.Location = new System.Drawing.Point(0, 99);
            this.lciNewPassword.Name = "lciNewPassword";
            this.lciNewPassword.Size = new System.Drawing.Size(371, 24);
            this.lciNewPassword.Text = "Mật khẩu mới:";
            this.lciNewPassword.TextSize = new System.Drawing.Size(95, 13);
            // 
            // lciConfirmPassword
            // 
            this.lciConfirmPassword.Control = this.txtConfirmPassword;
            this.lciConfirmPassword.CustomizationFormText = "Xác nhận mật khẩu:";
            this.lciConfirmPassword.Location = new System.Drawing.Point(0, 123);
            this.lciConfirmPassword.Name = "lciConfirmPassword";
            this.lciConfirmPassword.Size = new System.Drawing.Size(371, 24);
            this.lciConfirmPassword.Text = "Xác nhận mật khẩu:";
            this.lciConfirmPassword.TextSize = new System.Drawing.Size(95, 13);
            // 
            // lciButtonSave
            // 
            this.lciButtonSave.Control = this.btnSave;
            this.lciButtonSave.CustomizationFormText = "lciButtonSave";
            this.lciButtonSave.Location = new System.Drawing.Point(195, 189);
            this.lciButtonSave.Name = "lciButtonSave";
            this.lciButtonSave.Size = new System.Drawing.Size(100, 28);
            this.lciButtonSave.TextSize = new System.Drawing.Size(0, 0);
            this.lciButtonSave.TextVisible = false;
            // 
            // uc_ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.locMain);
            this.DoubleBuffered = true;
            this.Name = "uc_ChangePassword";
            this.Size = new System.Drawing.Size(395, 217);
            ((System.ComponentModel.ISupportInitialize)(this.depError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locMain)).EndInit();
            this.locMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLabelNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGroupName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOldPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNewPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciConfirmPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonSave)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider depError;
        private DevExpress.XtraLayout.LayoutControl locMain;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.TextEdit txtConfirmPassword;
        private DevExpress.XtraEditors.TextEdit txtNewPassword;
        private DevExpress.XtraEditors.TextEdit txtOldPassword;
        private DevExpress.XtraEditors.TextEdit txtGroupName;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraEditors.LabelControl lblNote;
        private DevExpress.XtraLayout.LayoutControlGroup logMain;
        private DevExpress.XtraLayout.EmptySpaceItem esiFirst;
        private DevExpress.XtraLayout.LayoutControlGroup logDetail;
        private DevExpress.XtraLayout.LayoutControlItem lciLabelNote;
        private DevExpress.XtraLayout.LayoutControlItem lciUsername;
        private DevExpress.XtraLayout.LayoutControlItem lciGroupName;
        private DevExpress.XtraLayout.LayoutControlItem lciOldPassword;
        private DevExpress.XtraLayout.LayoutControlItem lciNewPassword;
        private DevExpress.XtraLayout.LayoutControlItem lciConfirmPassword;
        private DevExpress.XtraLayout.LayoutControlItem lciButtonCancel;
        private DevExpress.XtraLayout.LayoutControlItem lciButtonSave;
    }
}