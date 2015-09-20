namespace iPOS.IMC.Products
{
    partial class uc_Warehouse
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
            this.barMain = new DevExpress.XtraBars.BarManager(this.components);
            this.barHeader = new DevExpress.XtraBars.Bar();
            this.btnInsert = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnUpdate = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnReload = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnImport = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnExport = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barFooter = new DevExpress.XtraBars.Bar();
            this.lblCreater = new DevExpress.XtraBars.BarStaticItem();
            this.lblCreaterValue = new DevExpress.XtraBars.BarStaticItem();
            this.lblCreateTime = new DevExpress.XtraBars.BarStaticItem();
            this.lblCreateTimeValue = new DevExpress.XtraBars.BarStaticItem();
            this.lblEditer = new DevExpress.XtraBars.BarStaticItem();
            this.lblEditerValue = new DevExpress.XtraBars.BarStaticItem();
            this.lblEditTime = new DevExpress.XtraBars.BarStaticItem();
            this.lblEditTimeValue = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridWarehouse = new DevExpress.XtraGrid.GridControl();
            this.grvWarehouse = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcolWarehouseCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolWarehouseName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolStoreName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolWarehouseAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolFax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolDistrictName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolProvinceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolUsedString = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolRank = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolCreater = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolCreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolEditer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolEditTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolWarehouseID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridWarehouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvWarehouse)).BeginInit();
            this.SuspendLayout();
            // 
            // barMain
            // 
            this.barMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barHeader,
            this.barFooter});
            this.barMain.DockControls.Add(this.barDockControlTop);
            this.barMain.DockControls.Add(this.barDockControlBottom);
            this.barMain.DockControls.Add(this.barDockControlLeft);
            this.barMain.DockControls.Add(this.barDockControlRight);
            this.barMain.Form = this;
            this.barMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnInsert,
            this.btnUpdate,
            this.btnDelete,
            this.btnReload,
            this.btnPrint,
            this.btnImport,
            this.btnExport,
            this.btnClose,
            this.lblCreater,
            this.lblCreaterValue,
            this.lblCreateTime,
            this.lblCreateTimeValue,
            this.lblEditer,
            this.lblEditerValue,
            this.lblEditTime,
            this.lblEditTimeValue});
            this.barMain.MainMenu = this.barHeader;
            this.barMain.MaxItemId = 16;
            this.barMain.StatusBar = this.barFooter;
            // 
            // barHeader
            // 
            this.barHeader.BarName = "Main menu";
            this.barHeader.DockCol = 0;
            this.barHeader.DockRow = 0;
            this.barHeader.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barHeader.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnInsert, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnUpdate, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPrint, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnReload, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnImport, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnExport, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnClose, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barHeader.OptionsBar.AllowQuickCustomization = false;
            this.barHeader.OptionsBar.DrawBorder = false;
            this.barHeader.OptionsBar.DrawDragBorder = false;
            this.barHeader.OptionsBar.UseWholeRow = true;
            this.barHeader.Text = "Main menu";
            // 
            // btnInsert
            // 
            this.btnInsert.Caption = "Thêm";
            this.btnInsert.Glyph = global::iPOS.IMC.Properties.Resources.add_16;
            this.btnInsert.Id = 0;
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInsert_ItemClick);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Caption = "Sửa Chữa";
            this.btnUpdate.Glyph = global::iPOS.IMC.Properties.Resources.update_16;
            this.btnUpdate.Id = 1;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUpdate_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Xóa";
            this.btnDelete.Glyph = global::iPOS.IMC.Properties.Resources.delete_16;
            this.btnDelete.Id = 2;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "In";
            this.btnPrint.Glyph = global::iPOS.IMC.Properties.Resources.print_16;
            this.btnPrint.Id = 4;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrint_ItemClick);
            // 
            // btnReload
            // 
            this.btnReload.Caption = "Tải Lại";
            this.btnReload.Glyph = global::iPOS.IMC.Properties.Resources.reload_16;
            this.btnReload.Id = 3;
            this.btnReload.Name = "btnReload";
            this.btnReload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReload_ItemClick);
            // 
            // btnImport
            // 
            this.btnImport.Caption = "Nhập";
            this.btnImport.Glyph = global::iPOS.IMC.Properties.Resources.import_16;
            this.btnImport.Id = 5;
            this.btnImport.Name = "btnImport";
            this.btnImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImport_ItemClick);
            // 
            // btnExport
            // 
            this.btnExport.Caption = "Xuất";
            this.btnExport.Glyph = global::iPOS.IMC.Properties.Resources.export_16;
            this.btnExport.Id = 6;
            this.btnExport.Name = "btnExport";
            this.btnExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExport_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Đóng";
            this.btnClose.Glyph = global::iPOS.IMC.Properties.Resources.close_16;
            this.btnClose.Id = 7;
            this.btnClose.Name = "btnClose";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // barFooter
            // 
            this.barFooter.BarName = "Status bar";
            this.barFooter.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barFooter.DockCol = 0;
            this.barFooter.DockRow = 0;
            this.barFooter.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barFooter.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lblCreater),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblCreaterValue),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblCreateTime),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblCreateTimeValue),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblEditer),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblEditerValue),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblEditTime),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblEditTimeValue)});
            this.barFooter.OptionsBar.AllowQuickCustomization = false;
            this.barFooter.OptionsBar.DrawDragBorder = false;
            this.barFooter.OptionsBar.UseWholeRow = true;
            this.barFooter.Text = "Status bar";
            // 
            // lblCreater
            // 
            this.lblCreater.Caption = "Người tạo:";
            this.lblCreater.Id = 8;
            this.lblCreater.Name = "lblCreater";
            this.lblCreater.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblCreaterValue
            // 
            this.lblCreaterValue.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.lblCreaterValue.Caption = "admin";
            this.lblCreaterValue.Id = 9;
            this.lblCreaterValue.Name = "lblCreaterValue";
            this.lblCreaterValue.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.Caption = "Ngày tạo:";
            this.lblCreateTime.Id = 10;
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblCreateTimeValue
            // 
            this.lblCreateTimeValue.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.lblCreateTimeValue.Caption = "01/01/2015";
            this.lblCreateTimeValue.Id = 11;
            this.lblCreateTimeValue.Name = "lblCreateTimeValue";
            this.lblCreateTimeValue.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblEditer
            // 
            this.lblEditer.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblEditer.Caption = "Người cập nhật:";
            this.lblEditer.Id = 12;
            this.lblEditer.Name = "lblEditer";
            this.lblEditer.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblEditerValue
            // 
            this.lblEditerValue.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.lblEditerValue.Caption = "admin";
            this.lblEditerValue.Id = 13;
            this.lblEditerValue.Name = "lblEditerValue";
            this.lblEditerValue.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblEditTime
            // 
            this.lblEditTime.Caption = "Ngày cập nhật:";
            this.lblEditTime.Id = 14;
            this.lblEditTime.Name = "lblEditTime";
            this.lblEditTime.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblEditTimeValue
            // 
            this.lblEditTimeValue.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.lblEditTimeValue.Caption = "01/01/2015";
            this.lblEditTimeValue.Id = 15;
            this.lblEditTimeValue.Name = "lblEditTimeValue";
            this.lblEditTimeValue.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(910, 42);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 513);
            this.barDockControlBottom.Size = new System.Drawing.Size(910, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 42);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 471);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(910, 42);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 471);
            // 
            // gridWarehouse
            // 
            this.gridWarehouse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridWarehouse.Location = new System.Drawing.Point(0, 42);
            this.gridWarehouse.MainView = this.grvWarehouse;
            this.gridWarehouse.MenuManager = this.barMain;
            this.gridWarehouse.Name = "gridWarehouse";
            this.gridWarehouse.Size = new System.Drawing.Size(910, 471);
            this.gridWarehouse.TabIndex = 13;
            this.gridWarehouse.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvWarehouse});
            // 
            // grvWarehouse
            // 
            this.grvWarehouse.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvWarehouse.Appearance.GroupRow.Options.UseFont = true;
            this.grvWarehouse.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcolWarehouseCode,
            this.gcolWarehouseName,
            this.gcolStoreName,
            this.gcolWarehouseAddress,
            this.gcolPhone,
            this.gcolFax,
            this.gcolDistrictName,
            this.gcolProvinceName,
            this.gcolUsedString,
            this.gcolRank,
            this.gcolNote,
            this.gcolCreater,
            this.gcolCreateTime,
            this.gcolEditer,
            this.gcolEditTime,
            this.gcolWarehouseID});
            this.grvWarehouse.GridControl = this.gridWarehouse;
            this.grvWarehouse.GroupCount = 1;
            this.grvWarehouse.IndicatorWidth = 40;
            this.grvWarehouse.Name = "grvWarehouse";
            this.grvWarehouse.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvWarehouse.OptionsBehavior.Editable = false;
            this.grvWarehouse.OptionsSelection.MultiSelect = true;
            this.grvWarehouse.OptionsView.ColumnAutoWidth = false;
            this.grvWarehouse.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcolStoreName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvWarehouse.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvWarehouse_CustomDrawRowIndicator);
            this.grvWarehouse.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.grvWarehouse_SelectionChanged);
            this.grvWarehouse.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvWarehouse_FocusedRowChanged);
            this.grvWarehouse.FocusedRowLoaded += new DevExpress.XtraGrid.Views.Base.RowEventHandler(this.grvWarehouse_FocusedRowLoaded);
            this.grvWarehouse.DoubleClick += new System.EventHandler(this.grvWarehouse_DoubleClick);
            // 
            // gcolWarehouseCode
            // 
            this.gcolWarehouseCode.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gcolWarehouseCode.AppearanceCell.Options.UseFont = true;
            this.gcolWarehouseCode.Caption = "Mã kho hàng";
            this.gcolWarehouseCode.FieldName = "WarehouseCode";
            this.gcolWarehouseCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gcolWarehouseCode.Name = "gcolWarehouseCode";
            this.gcolWarehouseCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcolWarehouseCode.Visible = true;
            this.gcolWarehouseCode.VisibleIndex = 0;
            this.gcolWarehouseCode.Width = 116;
            // 
            // gcolWarehouseName
            // 
            this.gcolWarehouseName.Caption = "Tên kho hàng";
            this.gcolWarehouseName.FieldName = "WarehouseName";
            this.gcolWarehouseName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gcolWarehouseName.Name = "gcolWarehouseName";
            this.gcolWarehouseName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcolWarehouseName.Visible = true;
            this.gcolWarehouseName.VisibleIndex = 1;
            this.gcolWarehouseName.Width = 240;
            // 
            // gcolStoreName
            // 
            this.gcolStoreName.Caption = "Cửa hàng";
            this.gcolStoreName.FieldName = "StoreName";
            this.gcolStoreName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gcolStoreName.Name = "gcolStoreName";
            this.gcolStoreName.OptionsColumn.AllowMove = false;
            this.gcolStoreName.Visible = true;
            this.gcolStoreName.VisibleIndex = 2;
            this.gcolStoreName.Width = 181;
            // 
            // gcolWarehouseAddress
            // 
            this.gcolWarehouseAddress.Caption = "Địa chỉ kho hàng";
            this.gcolWarehouseAddress.FieldName = "WarehouseAddress";
            this.gcolWarehouseAddress.Name = "gcolWarehouseAddress";
            this.gcolWarehouseAddress.Visible = true;
            this.gcolWarehouseAddress.VisibleIndex = 2;
            this.gcolWarehouseAddress.Width = 301;
            // 
            // gcolPhone
            // 
            this.gcolPhone.Caption = "Số điện thoại";
            this.gcolPhone.FieldName = "Phone";
            this.gcolPhone.Name = "gcolPhone";
            this.gcolPhone.Visible = true;
            this.gcolPhone.VisibleIndex = 3;
            this.gcolPhone.Width = 88;
            // 
            // gcolFax
            // 
            this.gcolFax.Caption = "Fax";
            this.gcolFax.FieldName = "Fax";
            this.gcolFax.Name = "gcolFax";
            this.gcolFax.Visible = true;
            this.gcolFax.VisibleIndex = 4;
            // 
            // gcolDistrictName
            // 
            this.gcolDistrictName.Caption = "Quận huyện";
            this.gcolDistrictName.FieldName = "DistrictName";
            this.gcolDistrictName.Name = "gcolDistrictName";
            this.gcolDistrictName.Visible = true;
            this.gcolDistrictName.VisibleIndex = 5;
            this.gcolDistrictName.Width = 102;
            // 
            // gcolProvinceName
            // 
            this.gcolProvinceName.Caption = "Tỉnh thành";
            this.gcolProvinceName.FieldName = "ProvinceName";
            this.gcolProvinceName.Name = "gcolProvinceName";
            this.gcolProvinceName.Visible = true;
            this.gcolProvinceName.VisibleIndex = 6;
            this.gcolProvinceName.Width = 116;
            // 
            // gcolUsedString
            // 
            this.gcolUsedString.AppearanceCell.Options.UseTextOptions = true;
            this.gcolUsedString.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolUsedString.Caption = "Sử dụng?";
            this.gcolUsedString.FieldName = "UsedString";
            this.gcolUsedString.Name = "gcolUsedString";
            this.gcolUsedString.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcolUsedString.Visible = true;
            this.gcolUsedString.VisibleIndex = 8;
            this.gcolUsedString.Width = 72;
            // 
            // gcolRank
            // 
            this.gcolRank.AppearanceCell.Options.UseTextOptions = true;
            this.gcolRank.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcolRank.Caption = "Thứ tự";
            this.gcolRank.DisplayFormat.FormatString = "N0";
            this.gcolRank.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcolRank.FieldName = "Rank";
            this.gcolRank.Name = "gcolRank";
            this.gcolRank.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcolRank.Visible = true;
            this.gcolRank.VisibleIndex = 7;
            this.gcolRank.Width = 65;
            // 
            // gcolNote
            // 
            this.gcolNote.Caption = "Ghi chú";
            this.gcolNote.FieldName = "Note";
            this.gcolNote.Name = "gcolNote";
            this.gcolNote.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcolNote.Visible = true;
            this.gcolNote.VisibleIndex = 9;
            this.gcolNote.Width = 332;
            // 
            // gcolCreater
            // 
            this.gcolCreater.Caption = "Creater";
            this.gcolCreater.FieldName = "Creater";
            this.gcolCreater.Name = "gcolCreater";
            // 
            // gcolCreateTime
            // 
            this.gcolCreateTime.Caption = "CreateTime";
            this.gcolCreateTime.FieldName = "CreateTime";
            this.gcolCreateTime.Name = "gcolCreateTime";
            // 
            // gcolEditer
            // 
            this.gcolEditer.Caption = "Editer";
            this.gcolEditer.FieldName = "Editer";
            this.gcolEditer.Name = "gcolEditer";
            // 
            // gcolEditTime
            // 
            this.gcolEditTime.Caption = "EditTime";
            this.gcolEditTime.FieldName = "EditTime";
            this.gcolEditTime.Name = "gcolEditTime";
            // 
            // gcolWarehouseID
            // 
            this.gcolWarehouseID.Caption = "WarehouseID";
            this.gcolWarehouseID.FieldName = "WarehouseID";
            this.gcolWarehouseID.Name = "gcolWarehouseID";
            // 
            // uc_Warehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridWarehouse);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.DoubleBuffered = true;
            this.Name = "uc_Warehouse";
            this.Size = new System.Drawing.Size(910, 538);
            this.Load += new System.EventHandler(this.uc_Warehouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridWarehouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvWarehouse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barMain;
        private DevExpress.XtraBars.Bar barHeader;
        private DevExpress.XtraBars.Bar barFooter;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarLargeButtonItem btnInsert;
        private DevExpress.XtraBars.BarLargeButtonItem btnUpdate;
        private DevExpress.XtraBars.BarLargeButtonItem btnDelete;
        private DevExpress.XtraBars.BarLargeButtonItem btnReload;
        private DevExpress.XtraBars.BarLargeButtonItem btnPrint;
        private DevExpress.XtraBars.BarLargeButtonItem btnImport;
        private DevExpress.XtraBars.BarLargeButtonItem btnExport;
        private DevExpress.XtraBars.BarLargeButtonItem btnClose;
        private DevExpress.XtraGrid.GridControl gridWarehouse;
        private DevExpress.XtraGrid.Views.Grid.GridView grvWarehouse;
        private DevExpress.XtraGrid.Columns.GridColumn gcolWarehouseCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcolWarehouseName;
        private DevExpress.XtraGrid.Columns.GridColumn gcolStoreName;
        private DevExpress.XtraGrid.Columns.GridColumn gcolWarehouseAddress;
        private DevExpress.XtraGrid.Columns.GridColumn gcolPhone;
        private DevExpress.XtraGrid.Columns.GridColumn gcolFax;
        private DevExpress.XtraGrid.Columns.GridColumn gcolDistrictName;
        private DevExpress.XtraGrid.Columns.GridColumn gcolProvinceName;
        private DevExpress.XtraGrid.Columns.GridColumn gcolUsedString;
        private DevExpress.XtraGrid.Columns.GridColumn gcolRank;
        private DevExpress.XtraGrid.Columns.GridColumn gcolNote;
        private DevExpress.XtraGrid.Columns.GridColumn gcolCreater;
        private DevExpress.XtraGrid.Columns.GridColumn gcolCreateTime;
        private DevExpress.XtraGrid.Columns.GridColumn gcolEditer;
        private DevExpress.XtraGrid.Columns.GridColumn gcolEditTime;
        private DevExpress.XtraGrid.Columns.GridColumn gcolWarehouseID;
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
