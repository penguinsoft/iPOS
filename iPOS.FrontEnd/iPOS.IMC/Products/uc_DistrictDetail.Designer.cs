namespace iPOS.IMC.Products
{
    partial class uc_DistrictDetail
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
            this.logDetail = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciDistrictCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtDistrictCode = new DevExpress.XtraEditors.TextEdit();
            this.locMain = new DevExpress.XtraLayout.LayoutControl();
            this.txtDistrictID = new DevExpress.XtraEditors.TextEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveInsert = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveClose = new DevExpress.XtraEditors.SimpleButton();
            this.chkUsed = new DevExpress.XtraEditors.CheckEdit();
            this.speRank = new DevExpress.XtraEditors.SpinEdit();
            this.mmoNote = new DevExpress.XtraEditors.MemoEdit();
            this.gluProvince = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gluProvinceView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcolProvinceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolProvinceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolFullProvinceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolProvinceID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtENName = new DevExpress.XtraEditors.TextEdit();
            this.txtVNName = new DevExpress.XtraEditors.TextEdit();
            this.logMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciButtonSaveClose = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciButtonSaveInsert = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciButtonCancel = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciDistrictID = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciVNName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciENName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciProvince = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciRank = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciUsed = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciNote = new DevExpress.XtraLayout.LayoutControlItem();
            this.depError = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.logDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDistrictCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistrictCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locMain)).BeginInit();
            this.locMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistrictID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUsed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speRank.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmoNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gluProvince.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gluProvinceView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtENName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVNName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonSaveClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonSaveInsert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDistrictID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVNName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciENName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciProvince)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUsed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depError)).BeginInit();
            this.SuspendLayout();
            // 
            // logDetail
            // 
            this.logDetail.CustomizationFormText = "layoutControlGroup1";
            this.logDetail.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciDistrictCode,
            this.lciVNName,
            this.lciENName,
            this.lciProvince,
            this.lciRank,
            this.lciUsed,
            this.lciNote});
            this.logDetail.Location = new System.Drawing.Point(0, 0);
            this.logDetail.Name = "logDetail";
            this.logDetail.Size = new System.Drawing.Size(431, 243);
            // 
            // lciDistrictCode
            // 
            this.lciDistrictCode.Control = this.txtDistrictCode;
            this.lciDistrictCode.CustomizationFormText = "Mã quận huyện:";
            this.lciDistrictCode.Location = new System.Drawing.Point(0, 0);
            this.lciDistrictCode.Name = "lciDistrictCode";
            this.lciDistrictCode.Size = new System.Drawing.Size(407, 24);
            this.lciDistrictCode.Text = "Mã quận huyện:";
            this.lciDistrictCode.TextSize = new System.Drawing.Size(98, 13);
            // 
            // txtDistrictCode
            // 
            this.txtDistrictCode.EnterMoveNextControl = true;
            this.txtDistrictCode.Location = new System.Drawing.Point(115, 32);
            this.txtDistrictCode.Name = "txtDistrictCode";
            this.txtDistrictCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDistrictCode.Properties.Appearance.Options.UseFont = true;
            this.txtDistrictCode.Properties.MaxLength = 20;
            this.txtDistrictCode.Size = new System.Drawing.Size(302, 20);
            this.txtDistrictCode.StyleController = this.locMain;
            this.txtDistrictCode.TabIndex = 4;
            this.txtDistrictCode.EditValueChanged += new System.EventHandler(this.txtDistrictCode_EditValueChanged);
            // 
            // locMain
            // 
            this.locMain.Controls.Add(this.txtDistrictID);
            this.locMain.Controls.Add(this.btnCancel);
            this.locMain.Controls.Add(this.btnSaveInsert);
            this.locMain.Controls.Add(this.btnSaveClose);
            this.locMain.Controls.Add(this.chkUsed);
            this.locMain.Controls.Add(this.speRank);
            this.locMain.Controls.Add(this.mmoNote);
            this.locMain.Controls.Add(this.gluProvince);
            this.locMain.Controls.Add(this.txtENName);
            this.locMain.Controls.Add(this.txtVNName);
            this.locMain.Controls.Add(this.txtDistrictCode);
            this.locMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.locMain.Location = new System.Drawing.Point(0, 0);
            this.locMain.Name = "locMain";
            this.locMain.Root = this.logMain;
            this.locMain.Size = new System.Drawing.Size(431, 269);
            this.locMain.TabIndex = 1;
            this.locMain.Text = "layoutControl1";
            // 
            // txtDistrictID
            // 
            this.txtDistrictID.Location = new System.Drawing.Point(60, 245);
            this.txtDistrictID.Name = "txtDistrictID";
            this.txtDistrictID.Size = new System.Drawing.Size(69, 20);
            this.txtDistrictID.StyleController = this.locMain;
            this.txtDistrictID.TabIndex = 14;
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::iPOS.IMC.Properties.Resources.cancel_16;
            this.btnCancel.Location = new System.Drawing.Point(333, 245);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 22);
            this.btnCancel.StyleController = this.locMain;
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Hủy Bỏ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveInsert
            // 
            this.btnSaveInsert.Image = global::iPOS.IMC.Properties.Resources.save_add_16;
            this.btnSaveInsert.Location = new System.Drawing.Point(233, 245);
            this.btnSaveInsert.Name = "btnSaveInsert";
            this.btnSaveInsert.Size = new System.Drawing.Size(96, 22);
            this.btnSaveInsert.StyleController = this.locMain;
            this.btnSaveInsert.TabIndex = 12;
            this.btnSaveInsert.Text = "Lưu && Thêm";
            this.btnSaveInsert.Click += new System.EventHandler(this.btnSaveInsert_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Image = global::iPOS.IMC.Properties.Resources.save_end_16;
            this.btnSaveClose.Location = new System.Drawing.Point(133, 245);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(96, 22);
            this.btnSaveClose.StyleController = this.locMain;
            this.btnSaveClose.TabIndex = 11;
            this.btnSaveClose.Text = "Lưu && Đóng";
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // chkUsed
            // 
            this.chkUsed.EditValue = true;
            this.chkUsed.EnterMoveNextControl = true;
            this.chkUsed.Location = new System.Drawing.Point(235, 128);
            this.chkUsed.Name = "chkUsed";
            this.chkUsed.Properties.Caption = "Đang sử dụng?";
            this.chkUsed.Size = new System.Drawing.Size(182, 19);
            this.chkUsed.StyleController = this.locMain;
            this.chkUsed.TabIndex = 10;
            // 
            // speRank
            // 
            this.speRank.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.speRank.EnterMoveNextControl = true;
            this.speRank.Location = new System.Drawing.Point(115, 128);
            this.speRank.Name = "speRank";
            this.speRank.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.speRank.Size = new System.Drawing.Size(108, 20);
            this.speRank.StyleController = this.locMain;
            this.speRank.TabIndex = 9;
            // 
            // mmoNote
            // 
            this.mmoNote.Location = new System.Drawing.Point(115, 152);
            this.mmoNote.Name = "mmoNote";
            this.mmoNote.Size = new System.Drawing.Size(302, 77);
            this.mmoNote.StyleController = this.locMain;
            this.mmoNote.TabIndex = 8;
            // 
            // gluProvince
            // 
            this.gluProvince.EnterMoveNextControl = true;
            this.gluProvince.Location = new System.Drawing.Point(115, 104);
            this.gluProvince.Name = "gluProvince";
            this.gluProvince.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.gluProvince.Properties.NullText = "[Chọn tỉnh thành]";
            this.gluProvince.Properties.View = this.gluProvinceView;
            this.gluProvince.Size = new System.Drawing.Size(302, 20);
            this.gluProvince.StyleController = this.locMain;
            this.gluProvince.TabIndex = 7;
            this.gluProvince.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.gluProvince_ButtonClick);
            this.gluProvince.EditValueChanged += new System.EventHandler(this.gluProvince_EditValueChanged);
            // 
            // gluProvinceView
            // 
            this.gluProvinceView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcolProvinceCode,
            this.gcolProvinceName,
            this.gcolFullProvinceName,
            this.gcolProvinceID});
            this.gluProvinceView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gluProvinceView.Name = "gluProvinceView";
            this.gluProvinceView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gluProvinceView.OptionsView.ShowAutoFilterRow = true;
            this.gluProvinceView.OptionsView.ShowGroupPanel = false;
            // 
            // gcolProvinceCode
            // 
            this.gcolProvinceCode.Caption = "Mã tỉnh thành";
            this.gcolProvinceCode.FieldName = "ProvinceCode";
            this.gcolProvinceCode.Name = "gcolProvinceCode";
            this.gcolProvinceCode.OptionsColumn.AllowEdit = false;
            this.gcolProvinceCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcolProvinceCode.Visible = true;
            this.gcolProvinceCode.VisibleIndex = 0;
            this.gcolProvinceCode.Width = 355;
            // 
            // gcolProvinceName
            // 
            this.gcolProvinceName.Caption = "Tên tỉnh thành";
            this.gcolProvinceName.FieldName = "ProvinceName";
            this.gcolProvinceName.Name = "gcolProvinceName";
            this.gcolProvinceName.OptionsColumn.AllowEdit = false;
            this.gcolProvinceName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcolProvinceName.Visible = true;
            this.gcolProvinceName.VisibleIndex = 1;
            this.gcolProvinceName.Width = 763;
            // 
            // gcolFullProvinceName
            // 
            this.gcolFullProvinceName.Caption = "FullProvinceName";
            this.gcolFullProvinceName.FieldName = "FullProvinceName";
            this.gcolFullProvinceName.Name = "gcolFullProvinceName";
            // 
            // gcolProvinceID
            // 
            this.gcolProvinceID.Caption = "ProvinceID";
            this.gcolProvinceID.FieldName = "ProvinceID";
            this.gcolProvinceID.Name = "gcolProvinceID";
            // 
            // txtENName
            // 
            this.txtENName.EnterMoveNextControl = true;
            this.txtENName.Location = new System.Drawing.Point(115, 80);
            this.txtENName.Name = "txtENName";
            this.txtENName.Properties.MaxLength = 150;
            this.txtENName.Size = new System.Drawing.Size(302, 20);
            this.txtENName.StyleController = this.locMain;
            this.txtENName.TabIndex = 6;
            this.txtENName.EditValueChanged += new System.EventHandler(this.txtENName_EditValueChanged);
            // 
            // txtVNName
            // 
            this.txtVNName.EnterMoveNextControl = true;
            this.txtVNName.Location = new System.Drawing.Point(115, 56);
            this.txtVNName.Name = "txtVNName";
            this.txtVNName.Properties.MaxLength = 150;
            this.txtVNName.Size = new System.Drawing.Size(302, 20);
            this.txtVNName.StyleController = this.locMain;
            this.txtVNName.TabIndex = 5;
            this.txtVNName.EditValueChanged += new System.EventHandler(this.txtVNName_EditValueChanged);
            // 
            // logMain
            // 
            this.logMain.CustomizationFormText = "logMain";
            this.logMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.logMain.GroupBordersVisible = false;
            this.logMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.logDetail,
            this.lciButtonSaveClose,
            this.lciButtonSaveInsert,
            this.lciButtonCancel,
            this.lciDistrictID});
            this.logMain.Location = new System.Drawing.Point(0, 0);
            this.logMain.Name = "logMain";
            this.logMain.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.logMain.Size = new System.Drawing.Size(431, 269);
            this.logMain.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 243);
            this.emptySpaceItem2.MaxSize = new System.Drawing.Size(58, 26);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(58, 26);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(58, 26);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciButtonSaveClose
            // 
            this.lciButtonSaveClose.Control = this.btnSaveClose;
            this.lciButtonSaveClose.CustomizationFormText = "lciButtonSaveClose";
            this.lciButtonSaveClose.Location = new System.Drawing.Point(131, 243);
            this.lciButtonSaveClose.Name = "lciButtonSaveClose";
            this.lciButtonSaveClose.Size = new System.Drawing.Size(100, 26);
            this.lciButtonSaveClose.TextSize = new System.Drawing.Size(0, 0);
            this.lciButtonSaveClose.TextVisible = false;
            // 
            // lciButtonSaveInsert
            // 
            this.lciButtonSaveInsert.Control = this.btnSaveInsert;
            this.lciButtonSaveInsert.CustomizationFormText = "lciButtonSaveInsert";
            this.lciButtonSaveInsert.Location = new System.Drawing.Point(231, 243);
            this.lciButtonSaveInsert.Name = "lciButtonSaveInsert";
            this.lciButtonSaveInsert.Size = new System.Drawing.Size(100, 26);
            this.lciButtonSaveInsert.TextSize = new System.Drawing.Size(0, 0);
            this.lciButtonSaveInsert.TextVisible = false;
            // 
            // lciButtonCancel
            // 
            this.lciButtonCancel.Control = this.btnCancel;
            this.lciButtonCancel.CustomizationFormText = "lciButtonCancel";
            this.lciButtonCancel.Location = new System.Drawing.Point(331, 243);
            this.lciButtonCancel.Name = "lciButtonCancel";
            this.lciButtonCancel.Size = new System.Drawing.Size(100, 26);
            this.lciButtonCancel.TextSize = new System.Drawing.Size(0, 0);
            this.lciButtonCancel.TextVisible = false;
            // 
            // lciDistrictID
            // 
            this.lciDistrictID.ContentVisible = false;
            this.lciDistrictID.Control = this.txtDistrictID;
            this.lciDistrictID.CustomizationFormText = "lciDistrictID";
            this.lciDistrictID.Location = new System.Drawing.Point(58, 243);
            this.lciDistrictID.MaxSize = new System.Drawing.Size(73, 26);
            this.lciDistrictID.MinSize = new System.Drawing.Size(73, 26);
            this.lciDistrictID.Name = "lciDistrictID";
            this.lciDistrictID.Size = new System.Drawing.Size(73, 26);
            this.lciDistrictID.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciDistrictID.TextSize = new System.Drawing.Size(0, 0);
            this.lciDistrictID.TextVisible = false;
            // 
            // lciVNName
            // 
            this.lciVNName.Control = this.txtVNName;
            this.lciVNName.CustomizationFormText = "Tên quận huyện VN:";
            this.lciVNName.Location = new System.Drawing.Point(0, 24);
            this.lciVNName.Name = "lciVNName";
            this.lciVNName.Size = new System.Drawing.Size(407, 24);
            this.lciVNName.Text = "Tên quận huyện VN:";
            this.lciVNName.TextSize = new System.Drawing.Size(98, 13);
            // 
            // lciENName
            // 
            this.lciENName.Control = this.txtENName;
            this.lciENName.CustomizationFormText = "Tên quận huyện EN:";
            this.lciENName.Location = new System.Drawing.Point(0, 48);
            this.lciENName.Name = "lciENName";
            this.lciENName.Size = new System.Drawing.Size(407, 24);
            this.lciENName.Text = "Tên quận huyện EN:";
            this.lciENName.TextSize = new System.Drawing.Size(98, 13);
            // 
            // lciProvince
            // 
            this.lciProvince.Control = this.gluProvince;
            this.lciProvince.CustomizationFormText = "Tỉnh thành:";
            this.lciProvince.Location = new System.Drawing.Point(0, 72);
            this.lciProvince.Name = "lciProvince";
            this.lciProvince.Size = new System.Drawing.Size(407, 24);
            this.lciProvince.Text = "Tỉnh thành:";
            this.lciProvince.TextSize = new System.Drawing.Size(98, 13);
            // 
            // lciRank
            // 
            this.lciRank.Control = this.speRank;
            this.lciRank.CustomizationFormText = "layoutControlItem1";
            this.lciRank.Location = new System.Drawing.Point(0, 96);
            this.lciRank.Name = "lciRank";
            this.lciRank.Size = new System.Drawing.Size(213, 24);
            this.lciRank.Text = "Thứ tự:";
            this.lciRank.TextSize = new System.Drawing.Size(98, 13);
            // 
            // lciUsed
            // 
            this.lciUsed.Control = this.chkUsed;
            this.lciUsed.CustomizationFormText = "layoutControlItem2";
            this.lciUsed.Location = new System.Drawing.Point(213, 96);
            this.lciUsed.Name = "lciUsed";
            this.lciUsed.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2);
            this.lciUsed.Size = new System.Drawing.Size(194, 24);
            this.lciUsed.TextSize = new System.Drawing.Size(0, 0);
            this.lciUsed.TextVisible = false;
            // 
            // lciNote
            // 
            this.lciNote.Control = this.mmoNote;
            this.lciNote.CustomizationFormText = "lciNote";
            this.lciNote.Location = new System.Drawing.Point(0, 120);
            this.lciNote.Name = "lciNote";
            this.lciNote.Size = new System.Drawing.Size(407, 81);
            this.lciNote.Text = "Ghi chú:";
            this.lciNote.TextSize = new System.Drawing.Size(98, 13);
            // 
            // depError
            // 
            this.depError.ContainerControl = this;
            // 
            // uc_DistrictDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.locMain);
            this.DoubleBuffered = true;
            this.Name = "uc_DistrictDetail";
            this.Size = new System.Drawing.Size(431, 269);
            ((System.ComponentModel.ISupportInitialize)(this.logDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDistrictCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistrictCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locMain)).EndInit();
            this.locMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDistrictID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUsed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speRank.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmoNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gluProvince.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gluProvinceView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtENName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVNName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonSaveClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonSaveInsert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDistrictID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVNName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciENName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciProvince)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUsed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControlGroup logDetail;
        private DevExpress.XtraLayout.LayoutControlItem lciDistrictCode;
        private DevExpress.XtraEditors.TextEdit txtDistrictCode;
        private DevExpress.XtraLayout.LayoutControl locMain;
        private DevExpress.XtraEditors.TextEdit txtDistrictID;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSaveInsert;
        private DevExpress.XtraEditors.SimpleButton btnSaveClose;
        private DevExpress.XtraEditors.CheckEdit chkUsed;
        private DevExpress.XtraEditors.SpinEdit speRank;
        private DevExpress.XtraEditors.MemoEdit mmoNote;
        private DevExpress.XtraEditors.GridLookUpEdit gluProvince;
        private DevExpress.XtraGrid.Views.Grid.GridView gluProvinceView;
        private DevExpress.XtraGrid.Columns.GridColumn gcolProvinceCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcolProvinceName;
        private DevExpress.XtraGrid.Columns.GridColumn gcolFullProvinceName;
        private DevExpress.XtraGrid.Columns.GridColumn gcolProvinceID;
        private DevExpress.XtraEditors.TextEdit txtENName;
        private DevExpress.XtraEditors.TextEdit txtVNName;
        private DevExpress.XtraLayout.LayoutControlGroup logMain;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem lciButtonSaveClose;
        private DevExpress.XtraLayout.LayoutControlItem lciButtonSaveInsert;
        private DevExpress.XtraLayout.LayoutControlItem lciButtonCancel;
        private DevExpress.XtraLayout.LayoutControlItem lciDistrictID;
        private DevExpress.XtraLayout.LayoutControlItem lciVNName;
        private DevExpress.XtraLayout.LayoutControlItem lciENName;
        private DevExpress.XtraLayout.LayoutControlItem lciProvince;
        private DevExpress.XtraLayout.LayoutControlItem lciNote;
        private DevExpress.XtraLayout.LayoutControlItem lciRank;
        private DevExpress.XtraLayout.LayoutControlItem lciUsed;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider depError;
    }
}
