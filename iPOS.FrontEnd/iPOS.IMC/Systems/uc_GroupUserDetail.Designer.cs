namespace iPOS.IMC.Systems
{
    partial class uc_GroupUserDetail
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
            this.locMain = new DevExpress.XtraLayout.LayoutControl();
            this.txtENName = new DevExpress.XtraEditors.TextEdit();
            this.txtGroupID = new DevExpress.XtraEditors.TextEdit();
            this.btnSaveClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveInsert = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.chkActive = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsDefault = new DevExpress.XtraEditors.CheckEdit();
            this.mmoNote = new DevExpress.XtraEditors.MemoEdit();
            this.txtVNName = new DevExpress.XtraEditors.TextEdit();
            this.txtGroupCode = new DevExpress.XtraEditors.TextEdit();
            this.logMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.logDetail = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciGroupCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciVNName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciNote = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciIsDefault = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciActive = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciENName = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.esiFirst = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciButtonCancel = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciButtonSaveInsert = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciGroupID = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.depError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locMain)).BeginInit();
            this.locMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtENName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsDefault.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmoNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVNName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGroupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVNName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciIsDefault)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciENName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonSaveInsert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGroupID)).BeginInit();
            this.SuspendLayout();
            // 
            // depError
            // 
            this.depError.ContainerControl = this;
            // 
            // locMain
            // 
            this.locMain.Controls.Add(this.txtENName);
            this.locMain.Controls.Add(this.txtGroupID);
            this.locMain.Controls.Add(this.btnSaveClose);
            this.locMain.Controls.Add(this.btnSaveInsert);
            this.locMain.Controls.Add(this.btnCancel);
            this.locMain.Controls.Add(this.chkActive);
            this.locMain.Controls.Add(this.chkIsDefault);
            this.locMain.Controls.Add(this.mmoNote);
            this.locMain.Controls.Add(this.txtVNName);
            this.locMain.Controls.Add(this.txtGroupCode);
            this.locMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.locMain.Location = new System.Drawing.Point(0, 0);
            this.locMain.Name = "locMain";
            this.locMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(859, 163, 250, 350);
            this.locMain.Root = this.logMain;
            this.locMain.Size = new System.Drawing.Size(439, 251);
            this.locMain.TabIndex = 1;
            this.locMain.Text = "layoutControl1";
            // 
            // txtENName
            // 
            this.txtENName.Location = new System.Drawing.Point(84, 81);
            this.txtENName.Name = "txtENName";
            this.txtENName.Size = new System.Drawing.Size(341, 20);
            this.txtENName.StyleController = this.locMain;
            this.txtENName.TabIndex = 14;
            this.txtENName.EditValueChanged += new System.EventHandler(this.txtENName_EditValueChanged);
            // 
            // txtGroupID
            // 
            this.txtGroupID.Location = new System.Drawing.Point(79, 227);
            this.txtGroupID.Name = "txtGroupID";
            this.txtGroupID.Size = new System.Drawing.Size(50, 20);
            this.txtGroupID.StyleController = this.locMain;
            this.txtGroupID.TabIndex = 13;
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Image = global::iPOS.IMC.Properties.Resources.save_end_16;
            this.btnSaveClose.Location = new System.Drawing.Point(133, 227);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(100, 22);
            this.btnSaveClose.StyleController = this.locMain;
            this.btnSaveClose.TabIndex = 5;
            this.btnSaveClose.Text = "Lưu && Đóng";
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // btnSaveInsert
            // 
            this.btnSaveInsert.Image = global::iPOS.IMC.Properties.Resources.save_add_16;
            this.btnSaveInsert.Location = new System.Drawing.Point(237, 227);
            this.btnSaveInsert.Name = "btnSaveInsert";
            this.btnSaveInsert.Size = new System.Drawing.Size(100, 22);
            this.btnSaveInsert.StyleController = this.locMain;
            this.btnSaveInsert.TabIndex = 6;
            this.btnSaveInsert.Text = "Lưu && Thêm";
            this.btnSaveInsert.Click += new System.EventHandler(this.btnSaveInsert_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::iPOS.IMC.Properties.Resources.cancel_16;
            this.btnCancel.Location = new System.Drawing.Point(341, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 22);
            this.btnCancel.StyleController = this.locMain;
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkActive
            // 
            this.chkActive.EditValue = true;
            this.chkActive.Location = new System.Drawing.Point(273, 191);
            this.chkActive.Name = "chkActive";
            this.chkActive.Properties.Caption = "Đang sử dụng?";
            this.chkActive.Size = new System.Drawing.Size(152, 19);
            this.chkActive.StyleController = this.locMain;
            this.chkActive.TabIndex = 4;
            // 
            // chkIsDefault
            // 
            this.chkIsDefault.Location = new System.Drawing.Point(118, 191);
            this.chkIsDefault.Name = "chkIsDefault";
            this.chkIsDefault.Properties.Caption = "Nhóm mặc định?";
            this.chkIsDefault.Size = new System.Drawing.Size(138, 19);
            this.chkIsDefault.StyleController = this.locMain;
            this.chkIsDefault.TabIndex = 3;
            // 
            // mmoNote
            // 
            this.mmoNote.EditValue = "";
            this.mmoNote.Location = new System.Drawing.Point(84, 105);
            this.mmoNote.Name = "mmoNote";
            this.mmoNote.Size = new System.Drawing.Size(341, 82);
            this.mmoNote.StyleController = this.locMain;
            this.mmoNote.TabIndex = 2;
            // 
            // txtVNName
            // 
            this.txtVNName.EnterMoveNextControl = true;
            this.txtVNName.Location = new System.Drawing.Point(84, 57);
            this.txtVNName.Name = "txtVNName";
            this.txtVNName.Properties.MaxLength = 255;
            this.txtVNName.Size = new System.Drawing.Size(341, 20);
            this.txtVNName.StyleController = this.locMain;
            this.txtVNName.TabIndex = 1;
            this.txtVNName.EditValueChanged += new System.EventHandler(this.txtVNName_EditValueChanged);
            // 
            // txtGroupCode
            // 
            this.txtGroupCode.EditValue = "";
            this.txtGroupCode.EnterMoveNextControl = true;
            this.txtGroupCode.Location = new System.Drawing.Point(84, 33);
            this.txtGroupCode.Name = "txtGroupCode";
            this.txtGroupCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtGroupCode.Properties.Appearance.Options.UseFont = true;
            this.txtGroupCode.Properties.MaxLength = 20;
            this.txtGroupCode.Size = new System.Drawing.Size(341, 20);
            this.txtGroupCode.StyleController = this.locMain;
            this.txtGroupCode.TabIndex = 0;
            this.txtGroupCode.EditValueChanged += new System.EventHandler(this.txtGroupCode_EditValueChanged);
            // 
            // logMain
            // 
            this.logMain.CustomizationFormText = "Root";
            this.logMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.logMain.GroupBordersVisible = false;
            this.logMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.logDetail,
            this.esiFirst,
            this.lciButtonCancel,
            this.lciButtonSaveInsert,
            this.layoutControlItem5,
            this.lciGroupID});
            this.logMain.Location = new System.Drawing.Point(0, 0);
            this.logMain.Name = "Root";
            this.logMain.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.logMain.Size = new System.Drawing.Size(439, 251);
            this.logMain.Text = "Root";
            this.logMain.TextVisible = false;
            // 
            // logDetail
            // 
            this.logDetail.CustomizationFormText = "Thông Tin Nhóm Người Dùng";
            this.logDetail.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciGroupCode,
            this.lciVNName,
            this.lciNote,
            this.lciIsDefault,
            this.lciActive,
            this.lciENName,
            this.emptySpaceItem1});
            this.logDetail.Location = new System.Drawing.Point(0, 0);
            this.logDetail.Name = "logDetail";
            this.logDetail.Size = new System.Drawing.Size(439, 225);
            this.logDetail.Text = "Thông Tin Nhóm Người Dùng";
            // 
            // lciGroupCode
            // 
            this.lciGroupCode.Control = this.txtGroupCode;
            this.lciGroupCode.CustomizationFormText = "Mã nhóm:";
            this.lciGroupCode.Location = new System.Drawing.Point(0, 0);
            this.lciGroupCode.Name = "lciGroupCode";
            this.lciGroupCode.Size = new System.Drawing.Size(415, 24);
            this.lciGroupCode.Text = "Mã nhóm:";
            this.lciGroupCode.TextSize = new System.Drawing.Size(67, 13);
            // 
            // lciVNName
            // 
            this.lciVNName.Control = this.txtVNName;
            this.lciVNName.CustomizationFormText = "Tên nhóm:";
            this.lciVNName.Location = new System.Drawing.Point(0, 24);
            this.lciVNName.Name = "lciVNName";
            this.lciVNName.Size = new System.Drawing.Size(415, 24);
            this.lciVNName.Text = "Tên nhóm VN:";
            this.lciVNName.TextSize = new System.Drawing.Size(67, 13);
            // 
            // lciNote
            // 
            this.lciNote.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lciNote.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lciNote.Control = this.mmoNote;
            this.lciNote.CustomizationFormText = "Ghi chú:";
            this.lciNote.Location = new System.Drawing.Point(0, 72);
            this.lciNote.Name = "lciNote";
            this.lciNote.Size = new System.Drawing.Size(415, 86);
            this.lciNote.Text = "Ghi chú:";
            this.lciNote.TextSize = new System.Drawing.Size(67, 13);
            // 
            // lciIsDefault
            // 
            this.lciIsDefault.Control = this.chkIsDefault;
            this.lciIsDefault.CustomizationFormText = "lciIsDefault";
            this.lciIsDefault.Location = new System.Drawing.Point(104, 158);
            this.lciIsDefault.Name = "lciIsDefault";
            this.lciIsDefault.Size = new System.Drawing.Size(142, 24);
            this.lciIsDefault.Text = "lciIsDefault";
            this.lciIsDefault.TextSize = new System.Drawing.Size(0, 0);
            this.lciIsDefault.TextToControlDistance = 0;
            this.lciIsDefault.TextVisible = false;
            // 
            // lciActive
            // 
            this.lciActive.Control = this.chkActive;
            this.lciActive.CustomizationFormText = "lciActive";
            this.lciActive.Location = new System.Drawing.Point(246, 158);
            this.lciActive.Name = "lciActive";
            this.lciActive.Padding = new DevExpress.XtraLayout.Utils.Padding(15, 2, 2, 2);
            this.lciActive.Size = new System.Drawing.Size(169, 24);
            this.lciActive.Text = "lciActive";
            this.lciActive.TextSize = new System.Drawing.Size(0, 0);
            this.lciActive.TextToControlDistance = 0;
            this.lciActive.TextVisible = false;
            // 
            // lciENName
            // 
            this.lciENName.Control = this.txtENName;
            this.lciENName.CustomizationFormText = "Tên nhóm EN:";
            this.lciENName.Location = new System.Drawing.Point(0, 48);
            this.lciENName.Name = "lciENName";
            this.lciENName.Size = new System.Drawing.Size(415, 24);
            this.lciENName.Text = "Tên nhóm EN:";
            this.lciENName.TextSize = new System.Drawing.Size(67, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 158);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(104, 24);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // esiFirst
            // 
            this.esiFirst.AllowHotTrack = false;
            this.esiFirst.CustomizationFormText = "esiFirst";
            this.esiFirst.Location = new System.Drawing.Point(0, 225);
            this.esiFirst.MaxSize = new System.Drawing.Size(77, 26);
            this.esiFirst.MinSize = new System.Drawing.Size(77, 26);
            this.esiFirst.Name = "esiFirst";
            this.esiFirst.Size = new System.Drawing.Size(77, 26);
            this.esiFirst.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.esiFirst.Text = "esiFirst";
            this.esiFirst.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciButtonCancel
            // 
            this.lciButtonCancel.Control = this.btnCancel;
            this.lciButtonCancel.CustomizationFormText = "lciButtonCancel";
            this.lciButtonCancel.Location = new System.Drawing.Point(339, 225);
            this.lciButtonCancel.Name = "lciButtonCancel";
            this.lciButtonCancel.Size = new System.Drawing.Size(100, 26);
            this.lciButtonCancel.Text = "lciButtonCancel";
            this.lciButtonCancel.TextSize = new System.Drawing.Size(0, 0);
            this.lciButtonCancel.TextToControlDistance = 0;
            this.lciButtonCancel.TextVisible = false;
            // 
            // lciButtonSaveInsert
            // 
            this.lciButtonSaveInsert.Control = this.btnSaveInsert;
            this.lciButtonSaveInsert.CustomizationFormText = "lciButtonSaveInsert";
            this.lciButtonSaveInsert.Location = new System.Drawing.Point(235, 225);
            this.lciButtonSaveInsert.Name = "lciButtonSaveInsert";
            this.lciButtonSaveInsert.Size = new System.Drawing.Size(104, 26);
            this.lciButtonSaveInsert.Text = "lciButtonSaveInsert";
            this.lciButtonSaveInsert.TextSize = new System.Drawing.Size(0, 0);
            this.lciButtonSaveInsert.TextToControlDistance = 0;
            this.lciButtonSaveInsert.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnSaveClose;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(131, 225);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(104, 26);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // lciGroupID
            // 
            this.lciGroupID.ContentVisible = false;
            this.lciGroupID.Control = this.txtGroupID;
            this.lciGroupID.CustomizationFormText = "lciGroupID";
            this.lciGroupID.Location = new System.Drawing.Point(77, 225);
            this.lciGroupID.MaxSize = new System.Drawing.Size(54, 26);
            this.lciGroupID.MinSize = new System.Drawing.Size(54, 26);
            this.lciGroupID.Name = "lciGroupID";
            this.lciGroupID.Size = new System.Drawing.Size(54, 26);
            this.lciGroupID.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciGroupID.Text = "lciGroupID";
            this.lciGroupID.TextSize = new System.Drawing.Size(0, 0);
            this.lciGroupID.TextToControlDistance = 0;
            this.lciGroupID.TextVisible = false;
            // 
            // uc_GroupUserDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.locMain);
            this.DoubleBuffered = true;
            this.Name = "uc_GroupUserDetail";
            this.Size = new System.Drawing.Size(439, 251);
            ((System.ComponentModel.ISupportInitialize)(this.depError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locMain)).EndInit();
            this.locMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtENName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsDefault.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmoNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVNName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGroupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVNName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciIsDefault)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciENName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonSaveInsert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGroupID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider depError;
        private DevExpress.XtraLayout.LayoutControl locMain;
        private DevExpress.XtraEditors.TextEdit txtGroupID;
        private DevExpress.XtraEditors.SimpleButton btnSaveClose;
        private DevExpress.XtraEditors.SimpleButton btnSaveInsert;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.CheckEdit chkActive;
        private DevExpress.XtraEditors.CheckEdit chkIsDefault;
        private DevExpress.XtraEditors.MemoEdit mmoNote;
        private DevExpress.XtraEditors.TextEdit txtVNName;
        private DevExpress.XtraEditors.TextEdit txtGroupCode;
        private DevExpress.XtraLayout.LayoutControlGroup logMain;
        private DevExpress.XtraLayout.LayoutControlGroup logDetail;
        private DevExpress.XtraLayout.LayoutControlItem lciGroupCode;
        private DevExpress.XtraLayout.LayoutControlItem lciVNName;
        private DevExpress.XtraLayout.LayoutControlItem lciNote;
        private DevExpress.XtraLayout.LayoutControlItem lciIsDefault;
        private DevExpress.XtraLayout.LayoutControlItem lciActive;
        private DevExpress.XtraLayout.EmptySpaceItem esiFirst;
        private DevExpress.XtraLayout.LayoutControlItem lciButtonCancel;
        private DevExpress.XtraLayout.LayoutControlItem lciButtonSaveInsert;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem lciGroupID;
        private DevExpress.XtraEditors.TextEdit txtENName;
        private DevExpress.XtraLayout.LayoutControlItem lciENName;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}