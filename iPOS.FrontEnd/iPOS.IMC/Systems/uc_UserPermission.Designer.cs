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
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.sccMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.trlUser = new DevExpress.XtraTreeList.TreeList();
            this.imcGroupUser = new DevExpress.Utils.ImageCollection(this.components);
            this.trlPermission = new DevExpress.XtraTreeList.TreeList();
            this.tlcFunctionName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcAllowAll = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcAllowInsert = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcAllowUpdate = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcAllowDelete = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcAllowAccess = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcAllowPrint = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcAllowImport = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcAllowExport = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcUserLevelID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcNote = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcFunctionID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.chkAllowAll = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.chkAllowInsert = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.chkAllowUpdate = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.chkAllowDelete = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.chkAllowAccess = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.chkAllowPrint = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.chkAllowImport = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.chkAllowExport = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.cboUserLevel = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.txtNote = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.lblCreater = new DevExpress.XtraBars.BarStaticItem();
            this.lblCreaterValue = new DevExpress.XtraBars.BarStaticItem();
            this.lblCreateTime = new DevExpress.XtraBars.BarStaticItem();
            this.lblCreateTimeValue = new DevExpress.XtraBars.BarStaticItem();
            this.lblEditer = new DevExpress.XtraBars.BarStaticItem();
            this.lblEditerValue = new DevExpress.XtraBars.BarStaticItem();
            this.lblEditTime = new DevExpress.XtraBars.BarStaticItem();
            this.lblEditTimeValue = new DevExpress.XtraBars.BarStaticItem();
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
            this.bar3});
            this.barMain.DockControls.Add(this.barDockControlTop);
            this.barMain.DockControls.Add(this.barDockControlBottom);
            this.barMain.DockControls.Add(this.barDockControlLeft);
            this.barMain.DockControls.Add(this.barDockControlRight);
            this.barMain.Form = this;
            this.barMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSave,
            this.btnClose,
            this.lblCreater,
            this.lblCreaterValue,
            this.lblCreateTime,
            this.lblCreateTimeValue,
            this.lblEditer,
            this.lblEditerValue,
            this.lblEditTime,
            this.lblEditTimeValue});
            this.barMain.MainMenu = this.barTop;
            this.barMain.MaxItemId = 10;
            this.barMain.StatusBar = this.bar3;
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
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Đóng";
            this.btnClose.Glyph = global::iPOS.IMC.Properties.Resources.close_16;
            this.btnClose.Id = 1;
            this.btnClose.Name = "btnClose";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lblCreater),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblCreaterValue),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblCreateTime),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblCreateTimeValue),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblEditer),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblEditerValue),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblEditTime),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblEditTimeValue)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
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
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 493);
            this.barDockControlBottom.Size = new System.Drawing.Size(1318, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 42);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 451);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1318, 42);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 451);
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
            this.sccMain.Panel1.ShowCaption = true;
            this.sccMain.Panel1.Text = "Danh Sách Người Dùng";
            this.sccMain.Panel2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sccMain.Panel2.AppearanceCaption.Options.UseFont = true;
            this.sccMain.Panel2.AutoScroll = true;
            this.sccMain.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.sccMain.Panel2.Controls.Add(this.trlPermission);
            this.sccMain.Panel2.ShowCaption = true;
            this.sccMain.Panel2.Text = "Thông Tin Phân Quyền Dữ Liệu";
            this.sccMain.Size = new System.Drawing.Size(1318, 451);
            this.sccMain.SplitterPosition = 243;
            this.sccMain.TabIndex = 4;
            this.sccMain.Text = "splitContainerControl1";
            // 
            // trlUser
            // 
            this.trlUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trlUser.HtmlImages = this.imcGroupUser;
            this.trlUser.Location = new System.Drawing.Point(0, 0);
            this.trlUser.Name = "trlUser";
            this.trlUser.OptionsBehavior.Editable = false;
            this.trlUser.OptionsView.ShowColumns = false;
            this.trlUser.OptionsView.ShowHorzLines = false;
            this.trlUser.SelectImageList = this.imcGroupUser;
            this.trlUser.Size = new System.Drawing.Size(239, 428);
            this.trlUser.TabIndex = 0;
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
            this.tlcFunctionID});
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
            this.trlPermission.Size = new System.Drawing.Size(1066, 428);
            this.trlPermission.TabIndex = 0;
            // 
            // tlcFunctionName
            // 
            this.tlcFunctionName.Caption = "Chức năng";
            this.tlcFunctionName.FieldName = "FunctionName";
            this.tlcFunctionName.Name = "tlcFunctionName";
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
            // chkAllowAll
            // 
            this.chkAllowAll.AutoHeight = false;
            this.chkAllowAll.Name = "chkAllowAll";
            // 
            // chkAllowInsert
            // 
            this.chkAllowInsert.AutoHeight = false;
            this.chkAllowInsert.Name = "chkAllowInsert";
            // 
            // chkAllowUpdate
            // 
            this.chkAllowUpdate.AutoHeight = false;
            this.chkAllowUpdate.Name = "chkAllowUpdate";
            // 
            // chkAllowDelete
            // 
            this.chkAllowDelete.AutoHeight = false;
            this.chkAllowDelete.Name = "chkAllowDelete";
            // 
            // chkAllowAccess
            // 
            this.chkAllowAccess.AutoHeight = false;
            this.chkAllowAccess.Name = "chkAllowAccess";
            // 
            // chkAllowPrint
            // 
            this.chkAllowPrint.AutoHeight = false;
            this.chkAllowPrint.Name = "chkAllowPrint";
            // 
            // chkAllowImport
            // 
            this.chkAllowImport.AutoHeight = false;
            this.chkAllowImport.Name = "chkAllowImport";
            // 
            // chkAllowExport
            // 
            this.chkAllowExport.AutoHeight = false;
            this.chkAllowExport.Name = "chkAllowExport";
            // 
            // cboUserLevel
            // 
            this.cboUserLevel.AutoHeight = false;
            this.cboUserLevel.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboUserLevel.Name = "cboUserLevel";
            // 
            // txtNote
            // 
            this.txtNote.AutoHeight = false;
            this.txtNote.Name = "txtNote";
            // 
            // lblCreater
            // 
            this.lblCreater.Caption = "Người tạo:";
            this.lblCreater.Id = 2;
            this.lblCreater.Name = "lblCreater";
            this.lblCreater.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblCreaterValue
            // 
            this.lblCreaterValue.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.lblCreaterValue.Caption = "<b><color=RED>admin</color></b>";
            this.lblCreaterValue.Id = 3;
            this.lblCreaterValue.Name = "lblCreaterValue";
            this.lblCreaterValue.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.Caption = "Ngày tạo:";
            this.lblCreateTime.Id = 4;
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblCreateTimeValue
            // 
            this.lblCreateTimeValue.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.lblCreateTimeValue.Caption = "<b><color=RED>01/01/2015</color></b>";
            this.lblCreateTimeValue.Id = 5;
            this.lblCreateTimeValue.Name = "lblCreateTimeValue";
            this.lblCreateTimeValue.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblEditer
            // 
            this.lblEditer.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblEditer.Caption = "Người cập nhật:";
            this.lblEditer.Id = 6;
            this.lblEditer.Name = "lblEditer";
            this.lblEditer.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblEditerValue
            // 
            this.lblEditerValue.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.lblEditerValue.Caption = "<b><color=RED>admin</color></b>";
            this.lblEditerValue.Id = 7;
            this.lblEditerValue.Name = "lblEditerValue";
            this.lblEditerValue.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblEditTime
            // 
            this.lblEditTime.Caption = "Ngày cập nhật:";
            this.lblEditTime.Id = 8;
            this.lblEditTime.Name = "lblEditTime";
            this.lblEditTime.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblEditTimeValue
            // 
            this.lblEditTimeValue.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.lblEditTimeValue.Caption = "<b><color=RED>01/01/2015</color></b>";
            this.lblEditTimeValue.Id = 9;
            this.lblEditTimeValue.Name = "lblEditTimeValue";
            this.lblEditTimeValue.TextAlignment = System.Drawing.StringAlignment.Near;
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
        private DevExpress.XtraBars.Bar bar3;
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
        private DevExpress.XtraBars.BarStaticItem lblCreater;
        private DevExpress.XtraBars.BarStaticItem lblCreaterValue;
        private DevExpress.XtraBars.BarStaticItem lblCreateTime;
        private DevExpress.XtraBars.BarStaticItem lblCreateTimeValue;
        private DevExpress.XtraBars.BarStaticItem lblEditer;
        private DevExpress.XtraBars.BarStaticItem lblEditerValue;
        private DevExpress.XtraBars.BarStaticItem lblEditTime;
        private DevExpress.XtraBars.BarStaticItem lblEditTimeValue;
    }
}
