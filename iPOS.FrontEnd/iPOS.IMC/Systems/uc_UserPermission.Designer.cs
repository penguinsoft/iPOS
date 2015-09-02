namespace iPOS.IMC.Systems
{
    partial class uc_UserPermission
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_UserPermission));
            this.barMain = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.btnSave = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barBottom = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.sccMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.trlUser = new DevExpress.XtraTreeList.TreeList();
            this.tlcName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imcGroupUser = new DevExpress.Utils.ImageCollection(this.components);
            this.trlPermission = new DevExpress.XtraTreeList.TreeList();
            this.tlcFunctionName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcAllowAll = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.chkAllowAll = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tlcAllowInsert = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.chkAllowInsert = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tlcAllowUpdate = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.chkAllowUpdate = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tlcAllowDelete = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.chkAllowDelete = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tlcAllowAccess = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.chkAllowAccess = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tlcAllowPrint = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.chkAllowPrint = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tlcAllowImport = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.chkAllowImport = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tlcAllowExport = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.chkAllowExport = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tlcUserLevelID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.cboUserLevel = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.tlcNote = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.txtNote = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.tlcID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcFunctionID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcCreater = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcCreateTime = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcEditer = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcEditTime = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sccMain)).BeginInit();
            this.sccMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trlUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imcGroupUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trlPermission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowInsert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowAccess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUserLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote)).BeginInit();
            this.SuspendLayout();
            // 
            // barMain
            // 
            this.barMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barTop,
            this.barBottom});
            this.barMain.DockControls.Add(this.barDockControlTop);
            this.barMain.DockControls.Add(this.barDockControlBottom);
            this.barMain.DockControls.Add(this.barDockControlLeft);
            this.barMain.DockControls.Add(this.barDockControlRight);
            this.barMain.Form = this;
            this.barMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSave,
            this.btnClose});
            this.barMain.MainMenu = this.barTop;
            this.barMain.MaxItemId = 10;
            this.barMain.StatusBar = this.barBottom;
            // 
            // barTop
            // 
            this.barTop.BarName = "Main menu";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnClose, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barTop.OptionsBar.DisableClose = true;
            this.barTop.OptionsBar.DisableCustomization = true;
            this.barTop.OptionsBar.DrawBorder = false;
            this.barTop.OptionsBar.DrawDragBorder = false;
            this.barTop.OptionsBar.UseWholeRow = true;
            this.barTop.Text = "Main menu";
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Lưu Lại";
            this.btnSave.Glyph = global::iPOS.IMC.Properties.Resources.save_end_16;
            this.btnSave.Id = 0;
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Đóng";
            this.btnClose.Glyph = global::iPOS.IMC.Properties.Resources.close_16;
            this.btnClose.Id = 1;
            this.btnClose.Name = "btnClose";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // barBottom
            // 
            this.barBottom.BarName = "Status bar";
            this.barBottom.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barBottom.DockCol = 0;
            this.barBottom.DockRow = 0;
            this.barBottom.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barBottom.OptionsBar.AllowQuickCustomization = false;
            this.barBottom.OptionsBar.DrawDragBorder = false;
            this.barBottom.OptionsBar.UseWholeRow = true;
            this.barBottom.Text = "Status bar";
            this.barBottom.Visible = false;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1318, 42);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 495);
            this.barDockControlBottom.Size = new System.Drawing.Size(1318, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 42);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 453);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1318, 42);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 453);
            // 
            // sccMain
            // 
            this.sccMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sccMain.Location = new System.Drawing.Point(0, 42);
            this.sccMain.Name = "sccMain";
            this.sccMain.Panel1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sccMain.Panel1.AppearanceCaption.Options.UseFont = true;
            this.sccMain.Panel1.AutoScroll = true;
            this.sccMain.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.sccMain.Panel1.Controls.Add(this.trlUser);
            this.sccMain.Panel1.MinSize = 250;
            this.sccMain.Panel1.ShowCaption = true;
            this.sccMain.Panel1.Text = "Danh Sách Người Dùng";
            this.sccMain.Panel2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sccMain.Panel2.AppearanceCaption.Options.UseFont = true;
            this.sccMain.Panel2.AutoScroll = true;
            this.sccMain.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.sccMain.Panel2.Controls.Add(this.trlPermission);
            this.sccMain.Panel2.MinSize = 500;
            this.sccMain.Panel2.ShowCaption = true;
            this.sccMain.Panel2.Text = "Thông Tin Phân Quyền Dữ Liệu";
            this.sccMain.Size = new System.Drawing.Size(1318, 453);
            this.sccMain.SplitterPosition = 281;
            this.sccMain.TabIndex = 4;
            this.sccMain.Text = "splitContainerControl1";
            // 
            // trlUser
            // 
            this.trlUser.Appearance.FocusedCell.BackColor = System.Drawing.Color.Wheat;
            this.trlUser.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Orange;
            this.trlUser.Appearance.FocusedCell.BorderColor = System.Drawing.Color.Red;
            this.trlUser.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.trlUser.Appearance.FocusedCell.Options.UseBackColor = true;
            this.trlUser.Appearance.FocusedCell.Options.UseBorderColor = true;
            this.trlUser.Appearance.FocusedCell.Options.UseForeColor = true;
            this.trlUser.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.trlUser.Appearance.FocusedRow.Options.UseFont = true;
            this.trlUser.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tlcName,
            this.tlcCode});
            this.trlUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trlUser.HtmlImages = this.imcGroupUser;
            this.trlUser.Location = new System.Drawing.Point(0, 0);
            this.trlUser.Name = "trlUser";
            this.trlUser.OptionsBehavior.Editable = false;
            this.trlUser.OptionsView.ShowColumns = false;
            this.trlUser.OptionsView.ShowHorzLines = false;
            this.trlUser.SelectImageList = this.imcGroupUser;
            this.trlUser.Size = new System.Drawing.Size(277, 430);
            this.trlUser.TabIndex = 0;
            this.trlUser.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.trlUser_FocusedNodeChanged);
            // 
            // tlcName
            // 
            this.tlcName.FieldName = "Name";
            this.tlcName.MinWidth = 33;
            this.tlcName.Name = "tlcName";
            this.tlcName.Visible = true;
            this.tlcName.VisibleIndex = 0;
            this.tlcName.Width = 110;
            // 
            // tlcCode
            // 
            this.tlcCode.Caption = "Code";
            this.tlcCode.FieldName = "Code";
            this.tlcCode.Name = "tlcCode";
            // 
            // imcGroupUser
            // 
            this.imcGroupUser.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imcGroupUser.ImageStream")));
            this.imcGroupUser.InsertImage(global::iPOS.IMC.Properties.Resources.group_user_16, "group_user_16", typeof(global::iPOS.IMC.Properties.Resources), 0);
            this.imcGroupUser.Images.SetKeyName(0, "group_user_16");
            this.imcGroupUser.InsertImage(global::iPOS.IMC.Properties.Resources.user_16, "user_16", typeof(global::iPOS.IMC.Properties.Resources), 1);
            this.imcGroupUser.Images.SetKeyName(1, "user_16");
            // 
            // trlPermission
            // 
            this.trlPermission.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tlcFunctionName,
            this.tlcAllowAll,
            this.tlcAllowInsert,
            this.tlcAllowUpdate,
            this.tlcAllowDelete,
            this.tlcAllowAccess,
            this.tlcAllowPrint,
            this.tlcAllowImport,
            this.tlcAllowExport,
            this.tlcUserLevelID,
            this.tlcNote,
            this.tlcID,
            this.tlcFunctionID,
            this.tlcCreater,
            this.tlcCreateTime,
            this.tlcEditer,
            this.tlcEditTime});
            this.trlPermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trlPermission.Location = new System.Drawing.Point(0, 0);
            this.trlPermission.Name = "trlPermission";
            this.trlPermission.OptionsBehavior.PopulateServiceColumns = true;
            this.trlPermission.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkAllowAll,
            this.chkAllowInsert,
            this.chkAllowUpdate,
            this.chkAllowDelete,
            this.chkAllowAccess,
            this.chkAllowPrint,
            this.chkAllowImport,
            this.chkAllowExport,
            this.cboUserLevel,
            this.txtNote});
            this.trlPermission.Size = new System.Drawing.Size(1028, 430);
            this.trlPermission.TabIndex = 0;
            // 
            // tlcFunctionName
            // 
            this.tlcFunctionName.Caption = "Chức năng";
            this.tlcFunctionName.FieldName = "FunctionName";
            this.tlcFunctionName.Name = "tlcFunctionName";
            this.tlcFunctionName.OptionsColumn.AllowEdit = false;
            this.tlcFunctionName.Visible = true;
            this.tlcFunctionName.VisibleIndex = 0;
            this.tlcFunctionName.Width = 374;
            // 
            // tlcAllowAll
            // 
            this.tlcAllowAll.AppearanceHeader.Options.UseTextOptions = true;
            this.tlcAllowAll.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcAllowAll.Caption = "Tất cả";
            this.tlcAllowAll.ColumnEdit = this.chkAllowAll;
            this.tlcAllowAll.FieldName = "AllowAll";
            this.tlcAllowAll.Name = "tlcAllowAll";
            this.tlcAllowAll.Visible = true;
            this.tlcAllowAll.VisibleIndex = 1;
            this.tlcAllowAll.Width = 54;
            // 
            // chkAllowAll
            // 
            this.chkAllowAll.AutoHeight = false;
            this.chkAllowAll.Name = "chkAllowAll";
            // 
            // tlcAllowInsert
            // 
            this.tlcAllowInsert.AppearanceHeader.Options.UseTextOptions = true;
            this.tlcAllowInsert.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcAllowInsert.Caption = "Thêm";
            this.tlcAllowInsert.ColumnEdit = this.chkAllowInsert;
            this.tlcAllowInsert.FieldName = "AllowInsert";
            this.tlcAllowInsert.Name = "tlcAllowInsert";
            this.tlcAllowInsert.Visible = true;
            this.tlcAllowInsert.VisibleIndex = 2;
            this.tlcAllowInsert.Width = 54;
            // 
            // chkAllowInsert
            // 
            this.chkAllowInsert.AutoHeight = false;
            this.chkAllowInsert.Name = "chkAllowInsert";
            // 
            // tlcAllowUpdate
            // 
            this.tlcAllowUpdate.AppearanceHeader.Options.UseTextOptions = true;
            this.tlcAllowUpdate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcAllowUpdate.Caption = "Cập nhật";
            this.tlcAllowUpdate.ColumnEdit = this.chkAllowUpdate;
            this.tlcAllowUpdate.FieldName = "AllowUpdate";
            this.tlcAllowUpdate.Name = "tlcAllowUpdate";
            this.tlcAllowUpdate.Visible = true;
            this.tlcAllowUpdate.VisibleIndex = 3;
            this.tlcAllowUpdate.Width = 54;
            // 
            // chkAllowUpdate
            // 
            this.chkAllowUpdate.AutoHeight = false;
            this.chkAllowUpdate.Name = "chkAllowUpdate";
            // 
            // tlcAllowDelete
            // 
            this.tlcAllowDelete.AppearanceHeader.Options.UseTextOptions = true;
            this.tlcAllowDelete.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcAllowDelete.Caption = "Xóa";
            this.tlcAllowDelete.ColumnEdit = this.chkAllowDelete;
            this.tlcAllowDelete.FieldName = "AllowDelete";
            this.tlcAllowDelete.Name = "tlcAllowDelete";
            this.tlcAllowDelete.Visible = true;
            this.tlcAllowDelete.VisibleIndex = 4;
            this.tlcAllowDelete.Width = 54;
            // 
            // chkAllowDelete
            // 
            this.chkAllowDelete.AutoHeight = false;
            this.chkAllowDelete.Name = "chkAllowDelete";
            // 
            // tlcAllowAccess
            // 
            this.tlcAllowAccess.AppearanceHeader.Options.UseTextOptions = true;
            this.tlcAllowAccess.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcAllowAccess.Caption = "Truy cập";
            this.tlcAllowAccess.ColumnEdit = this.chkAllowAccess;
            this.tlcAllowAccess.FieldName = "AllowAccess";
            this.tlcAllowAccess.Name = "tlcAllowAccess";
            this.tlcAllowAccess.Visible = true;
            this.tlcAllowAccess.VisibleIndex = 5;
            this.tlcAllowAccess.Width = 54;
            // 
            // chkAllowAccess
            // 
            this.chkAllowAccess.AutoHeight = false;
            this.chkAllowAccess.Name = "chkAllowAccess";
            // 
            // tlcAllowPrint
            // 
            this.tlcAllowPrint.AppearanceHeader.Options.UseTextOptions = true;
            this.tlcAllowPrint.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcAllowPrint.Caption = "In";
            this.tlcAllowPrint.ColumnEdit = this.chkAllowPrint;
            this.tlcAllowPrint.FieldName = "AllowPrint";
            this.tlcAllowPrint.Name = "tlcAllowPrint";
            this.tlcAllowPrint.Visible = true;
            this.tlcAllowPrint.VisibleIndex = 6;
            this.tlcAllowPrint.Width = 54;
            // 
            // chkAllowPrint
            // 
            this.chkAllowPrint.AutoHeight = false;
            this.chkAllowPrint.Name = "chkAllowPrint";
            // 
            // tlcAllowImport
            // 
            this.tlcAllowImport.AppearanceHeader.Options.UseTextOptions = true;
            this.tlcAllowImport.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcAllowImport.Caption = "Nhập";
            this.tlcAllowImport.ColumnEdit = this.chkAllowImport;
            this.tlcAllowImport.FieldName = "AllowImport";
            this.tlcAllowImport.Name = "tlcAllowImport";
            this.tlcAllowImport.Visible = true;
            this.tlcAllowImport.VisibleIndex = 7;
            this.tlcAllowImport.Width = 54;
            // 
            // chkAllowImport
            // 
            this.chkAllowImport.AutoHeight = false;
            this.chkAllowImport.Name = "chkAllowImport";
            // 
            // tlcAllowExport
            // 
            this.tlcAllowExport.AppearanceHeader.Options.UseTextOptions = true;
            this.tlcAllowExport.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlcAllowExport.Caption = "Xuất";
            this.tlcAllowExport.ColumnEdit = this.chkAllowExport;
            this.tlcAllowExport.FieldName = "AllowExport";
            this.tlcAllowExport.Name = "tlcAllowExport";
            this.tlcAllowExport.Visible = true;
            this.tlcAllowExport.VisibleIndex = 8;
            this.tlcAllowExport.Width = 54;
            // 
            // chkAllowExport
            // 
            this.chkAllowExport.AutoHeight = false;
            this.chkAllowExport.Name = "chkAllowExport";
            // 
            // tlcUserLevelID
            // 
            this.tlcUserLevelID.Caption = "Cấp độ quyền";
            this.tlcUserLevelID.ColumnEdit = this.cboUserLevel;
            this.tlcUserLevelID.FieldName = "Cấp độ quyền";
            this.tlcUserLevelID.Name = "tlcUserLevelID";
            this.tlcUserLevelID.Visible = true;
            this.tlcUserLevelID.VisibleIndex = 9;
            this.tlcUserLevelID.Width = 90;
            // 
            // cboUserLevel
            // 
            this.cboUserLevel.AutoHeight = false;
            this.cboUserLevel.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboUserLevel.Name = "cboUserLevel";
            // 
            // tlcNote
            // 
            this.tlcNote.Caption = "Ghi chú";
            this.tlcNote.ColumnEdit = this.txtNote;
            this.tlcNote.FieldName = "Note";
            this.tlcNote.Name = "tlcNote";
            this.tlcNote.Visible = true;
            this.tlcNote.VisibleIndex = 10;
            this.tlcNote.Width = 152;
            // 
            // txtNote
            // 
            this.txtNote.AutoHeight = false;
            this.txtNote.Name = "txtNote";
            // 
            // tlcID
            // 
            this.tlcID.Caption = "ID";
            this.tlcID.FieldName = "ID";
            this.tlcID.Name = "tlcID";
            // 
            // tlcFunctionID
            // 
            this.tlcFunctionID.Caption = "FunctionID";
            this.tlcFunctionID.FieldName = "FunctionID";
            this.tlcFunctionID.Name = "tlcFunctionID";
            // 
            // tlcCreater
            // 
            this.tlcCreater.Caption = "Creater";
            this.tlcCreater.FieldName = "Creater";
            this.tlcCreater.Name = "tlcCreater";
            // 
            // tlcCreateTime
            // 
            this.tlcCreateTime.Caption = "CreateTime";
            this.tlcCreateTime.FieldName = "CreateTime";
            this.tlcCreateTime.Name = "tlcCreateTime";
            // 
            // tlcEditer
            // 
            this.tlcEditer.Caption = "Editer";
            this.tlcEditer.FieldName = "Editer";
            this.tlcEditer.Name = "tlcEditer";
            // 
            // tlcEditTime
            // 
            this.tlcEditTime.Caption = "EditTime";
            this.tlcEditTime.FieldName = "EditTime";
            this.tlcEditTime.Name = "tlcEditTime";
            // 
            // uc_UserPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sccMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "uc_UserPermission";
            this.Size = new System.Drawing.Size(1318, 518);
            ((System.ComponentModel.ISupportInitialize)(this.barMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sccMain)).EndInit();
            this.sccMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trlUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imcGroupUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trlPermission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowInsert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowAccess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUserLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barMain;
        private DevExpress.XtraBars.Bar barTop;
        private DevExpress.XtraBars.Bar barBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarLargeButtonItem btnSave;
        private DevExpress.XtraBars.BarLargeButtonItem btnClose;
        private DevExpress.XtraEditors.SplitContainerControl sccMain;
        private DevExpress.XtraTreeList.TreeList trlUser;
        private DevExpress.Utils.ImageCollection imcGroupUser;
        private DevExpress.XtraTreeList.TreeList trlPermission;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcFunctionName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcAllowAll;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkAllowAll;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcAllowInsert;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkAllowInsert;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcAllowUpdate;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkAllowUpdate;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcAllowDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkAllowDelete;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcAllowAccess;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkAllowAccess;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcAllowPrint;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkAllowPrint;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcAllowImport;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkAllowImport;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcAllowExport;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkAllowExport;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcUserLevelID;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboUserLevel;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcNote;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtNote;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcFunctionID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcCreater;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcCreateTime;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcEditer;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcEditTime;
    }
}
