namespace iPOS.IMC.Products
{
    partial class uc_ProvinceDetail
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
            this.locMain = new DevExpress.XtraLayout.LayoutControl();
            this.txtProvinceID = new DevExpress.XtraEditors.TextEdit();
            this.btnSaveClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveInsert = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.mmoNote = new DevExpress.XtraEditors.MemoEdit();
            this.chkUsed = new DevExpress.XtraEditors.CheckEdit();
            this.speRank = new DevExpress.XtraEditors.SpinEdit();
            this.txtENName = new DevExpress.XtraEditors.TextEdit();
            this.txtVNName = new DevExpress.XtraEditors.TextEdit();
            this.txtProvinceCode = new DevExpress.XtraEditors.TextEdit();
            this.logMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.logDetail = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciProvinceCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciVNName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciENName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciRank = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciActive = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciNote = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciProvinceID = new DevExpress.XtraLayout.LayoutControlItem();
            this.depError = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.locMain)).BeginInit();
            this.locMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProvinceID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmoNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUsed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speRank.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtENName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVNName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProvinceCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciProvinceCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVNName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciENName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciProvinceID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depError)).BeginInit();
            this.SuspendLayout();
            // 
            // locMain
            // 
            this.locMain.Controls.Add(this.txtProvinceID);
            this.locMain.Controls.Add(this.btnSaveClose);
            this.locMain.Controls.Add(this.btnSaveInsert);
            this.locMain.Controls.Add(this.btnCancel);
            this.locMain.Controls.Add(this.mmoNote);
            this.locMain.Controls.Add(this.chkUsed);
            this.locMain.Controls.Add(this.speRank);
            this.locMain.Controls.Add(this.txtENName);
            this.locMain.Controls.Add(this.txtVNName);
            this.locMain.Controls.Add(this.txtProvinceCode);
            this.locMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.locMain.Location = new System.Drawing.Point(0, 0);
            this.locMain.Name = "locMain";
            this.locMain.Root = this.logMain;
            this.locMain.Size = new System.Drawing.Size(431, 254);
            this.locMain.TabIndex = 0;
            this.locMain.Text = "layoutControl1";
            // 
            // txtProvinceID
            // 
            this.txtProvinceID.Location = new System.Drawing.Point(2, 230);
            this.txtProvinceID.Name = "txtProvinceID";
            this.txtProvinceID.Size = new System.Drawing.Size(127, 20);
            this.txtProvinceID.StyleController = this.locMain;
            this.txtProvinceID.TabIndex = 13;
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Image = global::iPOS.IMC.Properties.Resources.save_end_16;
            this.btnSaveClose.Location = new System.Drawing.Point(133, 230);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(96, 22);
            this.btnSaveClose.StyleController = this.locMain;
            this.btnSaveClose.TabIndex = 12;
            this.btnSaveClose.Text = "Lưu && Đóng";
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // btnSaveInsert
            // 
            this.btnSaveInsert.Image = global::iPOS.IMC.Properties.Resources.save_add_16;
            this.btnSaveInsert.Location = new System.Drawing.Point(233, 230);
            this.btnSaveInsert.Name = "btnSaveInsert";
            this.btnSaveInsert.Size = new System.Drawing.Size(96, 22);
            this.btnSaveInsert.StyleController = this.locMain;
            this.btnSaveInsert.TabIndex = 11;
            this.btnSaveInsert.Text = "Lưu && Thêm";
            this.btnSaveInsert.Click += new System.EventHandler(this.btnSaveInsert_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::iPOS.IMC.Properties.Resources.cancel_16;
            this.btnCancel.Location = new System.Drawing.Point(333, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 22);
            this.btnCancel.StyleController = this.locMain;
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // mmoNote
            // 
            this.mmoNote.Location = new System.Drawing.Point(107, 129);
            this.mmoNote.Name = "mmoNote";
            this.mmoNote.Size = new System.Drawing.Size(310, 85);
            this.mmoNote.StyleController = this.locMain;
            this.mmoNote.TabIndex = 9;
            // 
            // chkUsed
            // 
            this.chkUsed.EditValue = true;
            this.chkUsed.Location = new System.Drawing.Point(300, 105);
            this.chkUsed.Name = "chkUsed";
            this.chkUsed.Properties.Caption = "Đang sử dụng?";
            this.chkUsed.Size = new System.Drawing.Size(117, 19);
            this.chkUsed.StyleController = this.locMain;
            this.chkUsed.TabIndex = 8;
            // 
            // speRank
            // 
            this.speRank.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.speRank.Location = new System.Drawing.Point(107, 105);
            this.speRank.Name = "speRank";
            this.speRank.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.speRank.Size = new System.Drawing.Size(181, 20);
            this.speRank.StyleController = this.locMain;
            this.speRank.TabIndex = 7;
            // 
            // txtENName
            // 
            this.txtENName.Location = new System.Drawing.Point(107, 81);
            this.txtENName.Name = "txtENName";
            this.txtENName.Size = new System.Drawing.Size(310, 20);
            this.txtENName.StyleController = this.locMain;
            this.txtENName.TabIndex = 6;
            this.txtENName.EditValueChanged += new System.EventHandler(this.txtENName_EditValueChanged);
            // 
            // txtVNName
            // 
            this.txtVNName.Location = new System.Drawing.Point(107, 57);
            this.txtVNName.Name = "txtVNName";
            this.txtVNName.Size = new System.Drawing.Size(310, 20);
            this.txtVNName.StyleController = this.locMain;
            this.txtVNName.TabIndex = 5;
            this.txtVNName.EditValueChanged += new System.EventHandler(this.txtVNName_EditValueChanged);
            // 
            // txtProvinceCode
            // 
            this.txtProvinceCode.Location = new System.Drawing.Point(107, 33);
            this.txtProvinceCode.Name = "txtProvinceCode";
            this.txtProvinceCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtProvinceCode.Properties.Appearance.Options.UseFont = true;
            this.txtProvinceCode.Properties.MaxLength = 20;
            this.txtProvinceCode.Size = new System.Drawing.Size(310, 20);
            this.txtProvinceCode.StyleController = this.locMain;
            this.txtProvinceCode.TabIndex = 4;
            this.txtProvinceCode.EditValueChanged += new System.EventHandler(this.txtProvinceCode_EditValueChanged);
            // 
            // logMain
            // 
            this.logMain.CustomizationFormText = "logMain";
            this.logMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.logMain.GroupBordersVisible = false;
            this.logMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.logDetail,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.lciProvinceID});
            this.logMain.Location = new System.Drawing.Point(0, 0);
            this.logMain.Name = "logMain";
            this.logMain.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.logMain.Size = new System.Drawing.Size(431, 254);
            this.logMain.Text = "logMain";
            this.logMain.TextVisible = false;
            // 
            // logDetail
            // 
            this.logDetail.CustomizationFormText = "Thông Tin Tỉnh Thành";
            this.logDetail.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciProvinceCode,
            this.lciVNName,
            this.lciENName,
            this.lciRank,
            this.lciActive,
            this.lciNote});
            this.logDetail.Location = new System.Drawing.Point(0, 0);
            this.logDetail.Name = "logDetail";
            this.logDetail.Size = new System.Drawing.Size(431, 228);
            this.logDetail.Text = "Thông Tin Tỉnh Thành";
            // 
            // lciProvinceCode
            // 
            this.lciProvinceCode.Control = this.txtProvinceCode;
            this.lciProvinceCode.CustomizationFormText = "Mã tỉnh thành:";
            this.lciProvinceCode.Location = new System.Drawing.Point(0, 0);
            this.lciProvinceCode.Name = "lciProvinceCode";
            this.lciProvinceCode.Size = new System.Drawing.Size(407, 24);
            this.lciProvinceCode.Text = "Mã tỉnh thành:";
            this.lciProvinceCode.TextSize = new System.Drawing.Size(90, 13);
            // 
            // lciVNName
            // 
            this.lciVNName.Control = this.txtVNName;
            this.lciVNName.CustomizationFormText = "Tên tỉnh thành VN:";
            this.lciVNName.Location = new System.Drawing.Point(0, 24);
            this.lciVNName.Name = "lciVNName";
            this.lciVNName.Size = new System.Drawing.Size(407, 24);
            this.lciVNName.Text = "Tên tỉnh thành VN:";
            this.lciVNName.TextSize = new System.Drawing.Size(90, 13);
            // 
            // lciENName
            // 
            this.lciENName.Control = this.txtENName;
            this.lciENName.CustomizationFormText = "Tên tỉnh thành EN:";
            this.lciENName.Location = new System.Drawing.Point(0, 48);
            this.lciENName.Name = "lciENName";
            this.lciENName.Size = new System.Drawing.Size(407, 24);
            this.lciENName.Text = "Tên tỉnh thành EN:";
            this.lciENName.TextSize = new System.Drawing.Size(90, 13);
            // 
            // lciRank
            // 
            this.lciRank.Control = this.speRank;
            this.lciRank.CustomizationFormText = "layoutControlItem1";
            this.lciRank.Location = new System.Drawing.Point(0, 72);
            this.lciRank.Name = "lciRank";
            this.lciRank.Size = new System.Drawing.Size(278, 24);
            this.lciRank.Text = "Thứ tự:";
            this.lciRank.TextSize = new System.Drawing.Size(90, 13);
            // 
            // lciActive
            // 
            this.lciActive.Control = this.chkUsed;
            this.lciActive.CustomizationFormText = "lciActive";
            this.lciActive.Location = new System.Drawing.Point(278, 72);
            this.lciActive.Name = "lciActive";
            this.lciActive.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2);
            this.lciActive.Size = new System.Drawing.Size(129, 24);
            this.lciActive.Text = "lciActive";
            this.lciActive.TextSize = new System.Drawing.Size(0, 0);
            this.lciActive.TextToControlDistance = 0;
            this.lciActive.TextVisible = false;
            // 
            // lciNote
            // 
            this.lciNote.Control = this.mmoNote;
            this.lciNote.CustomizationFormText = "Ghi chú:";
            this.lciNote.Location = new System.Drawing.Point(0, 96);
            this.lciNote.Name = "lciNote";
            this.lciNote.Size = new System.Drawing.Size(407, 89);
            this.lciNote.Text = "Ghi chú:";
            this.lciNote.TextSize = new System.Drawing.Size(90, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnCancel;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(331, 228);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(100, 26);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnSaveInsert;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(231, 228);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(100, 26);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnSaveClose;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(131, 228);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(100, 26);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // lciProvinceID
            // 
            this.lciProvinceID.ContentVisible = false;
            this.lciProvinceID.Control = this.txtProvinceID;
            this.lciProvinceID.CustomizationFormText = "lciProvinceID";
            this.lciProvinceID.Location = new System.Drawing.Point(0, 228);
            this.lciProvinceID.MaxSize = new System.Drawing.Size(131, 26);
            this.lciProvinceID.MinSize = new System.Drawing.Size(131, 26);
            this.lciProvinceID.Name = "lciProvinceID";
            this.lciProvinceID.Size = new System.Drawing.Size(131, 26);
            this.lciProvinceID.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciProvinceID.Text = "lciProvinceID";
            this.lciProvinceID.TextSize = new System.Drawing.Size(0, 0);
            this.lciProvinceID.TextToControlDistance = 0;
            this.lciProvinceID.TextVisible = false;
            // 
            // depError
            // 
            this.depError.ContainerControl = this;
            // 
            // uc_ProvinceDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.locMain);
            this.DoubleBuffered = true;
            this.Name = "uc_ProvinceDetail";
            this.Size = new System.Drawing.Size(431, 254);
            ((System.ComponentModel.ISupportInitialize)(this.locMain)).EndInit();
            this.locMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtProvinceID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmoNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUsed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speRank.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtENName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVNName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProvinceCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciProvinceCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVNName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciENName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciProvinceID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl locMain;
        private DevExpress.XtraLayout.LayoutControlGroup logMain;
        private DevExpress.XtraLayout.LayoutControlGroup logDetail;
        private DevExpress.XtraEditors.TextEdit txtProvinceCode;
        private DevExpress.XtraLayout.LayoutControlItem lciProvinceCode;
        private DevExpress.XtraEditors.TextEdit txtVNName;
        private DevExpress.XtraLayout.LayoutControlItem lciVNName;
        private DevExpress.XtraEditors.TextEdit txtENName;
        private DevExpress.XtraLayout.LayoutControlItem lciENName;
        private DevExpress.XtraEditors.SpinEdit speRank;
        private DevExpress.XtraLayout.LayoutControlItem lciRank;
        private DevExpress.XtraEditors.CheckEdit chkUsed;
        private DevExpress.XtraLayout.LayoutControlItem lciActive;
        private DevExpress.XtraEditors.MemoEdit mmoNote;
        private DevExpress.XtraLayout.LayoutControlItem lciNote;
        private DevExpress.XtraEditors.TextEdit txtProvinceID;
        private DevExpress.XtraEditors.SimpleButton btnSaveClose;
        private DevExpress.XtraEditors.SimpleButton btnSaveInsert;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem lciProvinceID;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider depError;
    }
}
