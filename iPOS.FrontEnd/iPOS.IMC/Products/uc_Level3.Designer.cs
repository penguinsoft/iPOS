﻿namespace iPOS.IMC.Products
{
    partial class uc_Level3
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
            this.btnPrint = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnImport = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnExport = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barBottom = new DevExpress.XtraBars.Bar();
            this.lblCreater = new DevExpress.XtraBars.BarStaticItem();
            this.lblCreaterValue = new DevExpress.XtraBars.BarStaticItem();
            this.lblCreateTime = new DevExpress.XtraBars.BarStaticItem();
            this.lblCreateTimeValue = new DevExpress.XtraBars.BarStaticItem();
            this.lblEditer = new DevExpress.XtraBars.BarStaticItem();
            this.lblEditerValue = new DevExpress.XtraBars.BarStaticItem();
            this.lblEditTime = new DevExpress.XtraBars.BarStaticItem();
            this.lblEditTimeValue = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.btnReload = new DevExpress.XtraBars.BarLargeButtonItem();
            this.gcolLevel1Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDelete = new DevExpress.XtraBars.BarLargeButtonItem();
            this.gridLevel3 = new DevExpress.XtraGrid.GridControl();
            this.grvLevel3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcolLevel2Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolLevel3Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolLevel3ShortCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolLevel3Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolRank = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolUsedString = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolCreater = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolCreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolEditer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolEditTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolLevel3ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barMain = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.btnInsert = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnUpdate = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridLevel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLevel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "In";
            this.btnPrint.Glyph = global::iPOS.IMC.Properties.Resources.print_16;
            this.btnPrint.Id = 3;
            this.btnPrint.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrint_ItemClick);
            // 
            // btnImport
            // 
            this.btnImport.Caption = "Nhập";
            this.btnImport.Glyph = global::iPOS.IMC.Properties.Resources.import_16;
            this.btnImport.Id = 5;
            this.btnImport.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I));
            this.btnImport.Name = "btnImport";
            this.btnImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImport_ItemClick);
            // 
            // btnExport
            // 
            this.btnExport.Caption = "Xuất";
            this.btnExport.Glyph = global::iPOS.IMC.Properties.Resources.export_16;
            this.btnExport.Id = 6;
            this.btnExport.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E));
            this.btnExport.Name = "btnExport";
            this.btnExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExport_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Đóng";
            this.btnClose.Glyph = global::iPOS.IMC.Properties.Resources.close_16;
            this.btnClose.Id = 7;
            this.btnClose.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W));
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
            this.barBottom.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lblCreater),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblCreaterValue),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblCreateTime),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblCreateTimeValue),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblEditer),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblEditerValue),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblEditTime),
            new DevExpress.XtraBars.LinkPersistInfo(this.lblEditTimeValue)});
            this.barBottom.OptionsBar.AllowQuickCustomization = false;
            this.barBottom.OptionsBar.DrawDragBorder = false;
            this.barBottom.OptionsBar.UseWholeRow = true;
            this.barBottom.Text = "Status bar";
            this.barBottom.Visible = false;
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
            this.lblCreaterValue.Caption = "<b><color=RED>admin</color></b>";
            this.lblCreaterValue.Id = 9;
            this.lblCreaterValue.Name = "lblCreaterValue";
            this.lblCreaterValue.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.lblCreateTime.Caption = "Ngày tạo:";
            this.lblCreateTime.Id = 12;
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblCreateTimeValue
            // 
            this.lblCreateTimeValue.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.lblCreateTimeValue.Caption = "<b><color=RED>01/01/2015</color></b>";
            this.lblCreateTimeValue.Id = 13;
            this.lblCreateTimeValue.Name = "lblCreateTimeValue";
            this.lblCreateTimeValue.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblEditer
            // 
            this.lblEditer.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblEditer.Caption = "Người cập nhật:";
            this.lblEditer.Id = 10;
            this.lblEditer.Name = "lblEditer";
            this.lblEditer.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblEditerValue
            // 
            this.lblEditerValue.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblEditerValue.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.lblEditerValue.Caption = "<b><color=RED>admin</color></b>";
            this.lblEditerValue.Id = 11;
            this.lblEditerValue.Name = "lblEditerValue";
            this.lblEditerValue.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblEditTime
            // 
            this.lblEditTime.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblEditTime.Caption = "Ngày cập nhật:";
            this.lblEditTime.Id = 14;
            this.lblEditTime.Name = "lblEditTime";
            this.lblEditTime.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblEditTimeValue
            // 
            this.lblEditTimeValue.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblEditTimeValue.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.lblEditTimeValue.Caption = "<b><color=RED>01/01/2015</color></b>";
            this.lblEditTimeValue.Id = 15;
            this.lblEditTimeValue.Name = "lblEditTimeValue";
            this.lblEditTimeValue.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 462);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 502);
            this.barDockControlBottom.Size = new System.Drawing.Size(882, 25);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(882, 40);
            // 
            // btnReload
            // 
            this.btnReload.Caption = "Tải Lại";
            this.btnReload.Glyph = global::iPOS.IMC.Properties.Resources.reload_16;
            this.btnReload.Id = 4;
            this.btnReload.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.btnReload.Name = "btnReload";
            this.btnReload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReload_ItemClick);
            // 
            // gcolLevel1Name
            // 
            this.gcolLevel1Name.Caption = "Ngành hàng";
            this.gcolLevel1Name.FieldName = "Level1Name";
            this.gcolLevel1Name.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gcolLevel1Name.Name = "gcolLevel1Name";
            this.gcolLevel1Name.Visible = true;
            this.gcolLevel1Name.VisibleIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Xóa";
            this.btnDelete.Glyph = global::iPOS.IMC.Properties.Resources.delete_16;
            this.btnDelete.Id = 2;
            this.btnDelete.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Delete);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // gridLevel3
            // 
            this.gridLevel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLevel3.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridLevel3.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridLevel3.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridLevel3.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridLevel3.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridLevel3.EmbeddedNavigator.TextStringFormat = "{0}/{1}";
            this.gridLevel3.Location = new System.Drawing.Point(0, 40);
            this.gridLevel3.MainView = this.grvLevel3;
            this.gridLevel3.MenuManager = this.barMain;
            this.gridLevel3.Name = "gridLevel3";
            this.gridLevel3.Size = new System.Drawing.Size(882, 462);
            this.gridLevel3.TabIndex = 8;
            this.gridLevel3.UseEmbeddedNavigator = true;
            this.gridLevel3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLevel3});
            // 
            // grvLevel3
            // 
            this.grvLevel3.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvLevel3.Appearance.GroupRow.Options.UseFont = true;
            this.grvLevel3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcolLevel1Name,
            this.gcolLevel2Name,
            this.gcolLevel3Code,
            this.gcolLevel3ShortCode,
            this.gcolLevel3Name,
            this.gcolRank,
            this.gcolUsedString,
            this.gcolDescription,
            this.gcolNote,
            this.gcolCreater,
            this.gcolCreateTime,
            this.gcolEditer,
            this.gcolEditTime,
            this.gcolLevel3ID});
            this.grvLevel3.GridControl = this.gridLevel3;
            this.grvLevel3.GroupCount = 2;
            this.grvLevel3.IndicatorWidth = 40;
            this.grvLevel3.Name = "grvLevel3";
            this.grvLevel3.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvLevel3.OptionsBehavior.Editable = false;
            this.grvLevel3.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.grvLevel3.OptionsSelection.MultiSelect = true;
            this.grvLevel3.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grvLevel3.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.grvLevel3.OptionsView.ShowAutoFilterRow = true;
            this.grvLevel3.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcolLevel1Name, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcolLevel2Name, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvLevel3.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvLevel3_CustomDrawRowIndicator);
            this.grvLevel3.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvLevel3_FocusedRowChanged);
            this.grvLevel3.FocusedRowLoaded += new DevExpress.XtraGrid.Views.Base.RowEventHandler(this.grvLevel3_FocusedRowLoaded);
            this.grvLevel3.DoubleClick += new System.EventHandler(this.grvLevel3_DoubleClick);
            // 
            // gcolLevel2Name
            // 
            this.gcolLevel2Name.Caption = "Nhóm hàng";
            this.gcolLevel2Name.FieldName = "Level2Name";
            this.gcolLevel2Name.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gcolLevel2Name.Name = "gcolLevel2Name";
            this.gcolLevel2Name.Visible = true;
            this.gcolLevel2Name.VisibleIndex = 4;
            // 
            // gcolLevel3Code
            // 
            this.gcolLevel3Code.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gcolLevel3Code.AppearanceCell.Options.UseFont = true;
            this.gcolLevel3Code.Caption = "Mã phân nhóm";
            this.gcolLevel3Code.FieldName = "Level3Code";
            this.gcolLevel3Code.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gcolLevel3Code.Name = "gcolLevel3Code";
            this.gcolLevel3Code.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcolLevel3Code.Visible = true;
            this.gcolLevel3Code.VisibleIndex = 1;
            this.gcolLevel3Code.Width = 103;
            // 
            // gcolLevel3ShortCode
            // 
            this.gcolLevel3ShortCode.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gcolLevel3ShortCode.AppearanceCell.Options.UseFont = true;
            this.gcolLevel3ShortCode.AppearanceCell.Options.UseTextOptions = true;
            this.gcolLevel3ShortCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolLevel3ShortCode.Caption = "Mã tắt";
            this.gcolLevel3ShortCode.FieldName = "Level3ShortCode";
            this.gcolLevel3ShortCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gcolLevel3ShortCode.Name = "gcolLevel3ShortCode";
            this.gcolLevel3ShortCode.Visible = true;
            this.gcolLevel3ShortCode.VisibleIndex = 2;
            this.gcolLevel3ShortCode.Width = 93;
            // 
            // gcolLevel3Name
            // 
            this.gcolLevel3Name.Caption = "Tên phân nhóm";
            this.gcolLevel3Name.FieldName = "Level3Name";
            this.gcolLevel3Name.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gcolLevel3Name.Name = "gcolLevel3Name";
            this.gcolLevel3Name.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcolLevel3Name.Visible = true;
            this.gcolLevel3Name.VisibleIndex = 3;
            this.gcolLevel3Name.Width = 187;
            // 
            // gcolRank
            // 
            this.gcolRank.AppearanceCell.Options.UseTextOptions = true;
            this.gcolRank.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcolRank.Caption = "Thứ tự";
            this.gcolRank.FieldName = "Rank";
            this.gcolRank.Name = "gcolRank";
            this.gcolRank.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcolRank.Visible = true;
            this.gcolRank.VisibleIndex = 4;
            this.gcolRank.Width = 59;
            // 
            // gcolUsedString
            // 
            this.gcolUsedString.AppearanceCell.Options.UseTextOptions = true;
            this.gcolUsedString.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcolUsedString.Caption = "Kích hoạt?";
            this.gcolUsedString.FieldName = "UsedString";
            this.gcolUsedString.Name = "gcolUsedString";
            this.gcolUsedString.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcolUsedString.Visible = true;
            this.gcolUsedString.VisibleIndex = 5;
            this.gcolUsedString.Width = 63;
            // 
            // gcolDescription
            // 
            this.gcolDescription.Caption = "Mô tả";
            this.gcolDescription.FieldName = "Description";
            this.gcolDescription.Name = "gcolDescription";
            this.gcolDescription.Visible = true;
            this.gcolDescription.VisibleIndex = 6;
            this.gcolDescription.Width = 129;
            // 
            // gcolNote
            // 
            this.gcolNote.Caption = "Ghi chú";
            this.gcolNote.FieldName = "Note";
            this.gcolNote.Name = "gcolNote";
            this.gcolNote.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gcolNote.Visible = true;
            this.gcolNote.VisibleIndex = 7;
            this.gcolNote.Width = 152;
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
            // gcolLevel3ID
            // 
            this.gcolLevel3ID.Caption = "Level3ID";
            this.gcolLevel3ID.FieldName = "Level3ID";
            this.gcolLevel3ID.Name = "gcolLevel3ID";
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
            this.btnInsert,
            this.btnUpdate,
            this.btnDelete,
            this.btnPrint,
            this.btnReload,
            this.btnImport,
            this.btnExport,
            this.btnClose,
            this.lblCreater,
            this.lblCreaterValue,
            this.lblEditer,
            this.lblEditerValue,
            this.lblCreateTime,
            this.lblCreateTimeValue,
            this.lblEditTime,
            this.lblEditTimeValue});
            this.barMain.MainMenu = this.barTop;
            this.barMain.MaxItemId = 16;
            this.barMain.StatusBar = this.barBottom;
            // 
            // barTop
            // 
            this.barTop.BarName = "Main menu";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.KeyTip, this.btnInsert, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.Standard, "FSDFSD", ""),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnUpdate, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPrint, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle | DevExpress.XtraBars.BarLinkUserDefines.KeyTip))), this.btnReload, "", false, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph, "", ""),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnImport, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnExport, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnClose, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barTop.OptionsBar.AllowQuickCustomization = false;
            this.barTop.OptionsBar.DisableClose = true;
            this.barTop.OptionsBar.DisableCustomization = true;
            this.barTop.OptionsBar.DrawBorder = false;
            this.barTop.OptionsBar.DrawDragBorder = false;
            this.barTop.OptionsBar.MultiLine = true;
            this.barTop.OptionsBar.UseWholeRow = true;
            this.barTop.Text = "Main menu";
            // 
            // btnInsert
            // 
            this.btnInsert.Caption = "Thêm";
            this.btnInsert.Glyph = global::iPOS.IMC.Properties.Resources.add_16;
            this.btnInsert.Id = 0;
            this.btnInsert.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnInsert.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInsert_ItemClick);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Caption = "Cập Nhật";
            this.btnUpdate.Glyph = global::iPOS.IMC.Properties.Resources.update_16;
            this.btnUpdate.Id = 1;
            this.btnUpdate.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUpdate_ItemClick);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(882, 40);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 462);
            // 
            // uc_Level3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridLevel3);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.DoubleBuffered = true;
            this.Name = "uc_Level3";
            this.Size = new System.Drawing.Size(882, 527);
            this.Load += new System.EventHandler(this.uc_Level3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridLevel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLevel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarLargeButtonItem btnPrint;
        private DevExpress.XtraBars.BarLargeButtonItem btnImport;
        private DevExpress.XtraBars.BarLargeButtonItem btnExport;
        private DevExpress.XtraBars.BarLargeButtonItem btnClose;
        private DevExpress.XtraBars.Bar barBottom;
        private DevExpress.XtraBars.BarStaticItem lblCreater;
        private DevExpress.XtraBars.BarStaticItem lblCreaterValue;
        private DevExpress.XtraBars.BarStaticItem lblCreateTime;
        private DevExpress.XtraBars.BarStaticItem lblCreateTimeValue;
        private DevExpress.XtraBars.BarStaticItem lblEditer;
        private DevExpress.XtraBars.BarStaticItem lblEditerValue;
        private DevExpress.XtraBars.BarStaticItem lblEditTime;
        private DevExpress.XtraBars.BarStaticItem lblEditTimeValue;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarLargeButtonItem btnReload;
        private DevExpress.XtraGrid.Columns.GridColumn gcolLevel1Name;
        private DevExpress.XtraBars.BarLargeButtonItem btnDelete;
        private DevExpress.XtraGrid.GridControl gridLevel3;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLevel3;
        private DevExpress.XtraGrid.Columns.GridColumn gcolLevel3Code;
        private DevExpress.XtraGrid.Columns.GridColumn gcolLevel3ShortCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcolLevel3Name;
        private DevExpress.XtraGrid.Columns.GridColumn gcolRank;
        private DevExpress.XtraGrid.Columns.GridColumn gcolUsedString;
        private DevExpress.XtraGrid.Columns.GridColumn gcolDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gcolNote;
        private DevExpress.XtraGrid.Columns.GridColumn gcolCreater;
        private DevExpress.XtraGrid.Columns.GridColumn gcolCreateTime;
        private DevExpress.XtraGrid.Columns.GridColumn gcolEditer;
        private DevExpress.XtraGrid.Columns.GridColumn gcolEditTime;
        private DevExpress.XtraGrid.Columns.GridColumn gcolLevel3ID;
        private DevExpress.XtraBars.BarManager barMain;
        private DevExpress.XtraBars.Bar barTop;
        private DevExpress.XtraBars.BarLargeButtonItem btnInsert;
        private DevExpress.XtraBars.BarLargeButtonItem btnUpdate;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.Columns.GridColumn gcolLevel2Name;
    }
}
