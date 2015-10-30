namespace iPOS.IMC.Products
{
    partial class uc_UnitDetail
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
            this.locMain = new DevExpress.XtraLayout.LayoutControl();
            this.logMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.logDetail = new DevExpress.XtraLayout.LayoutControlGroup();
            this.txtUnitCode = new DevExpress.XtraEditors.TextEdit();
            this.lciUnitCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtVNName = new DevExpress.XtraEditors.TextEdit();
            this.lciVNName = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtENName = new DevExpress.XtraEditors.TextEdit();
            this.lciENName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lueUnitType = new DevExpress.XtraEditors.LookUpEdit();
            this.lciUnitType = new DevExpress.XtraLayout.LayoutControlItem();
            this.speRank = new DevExpress.XtraEditors.SpinEdit();
            this.lciRank = new DevExpress.XtraLayout.LayoutControlItem();
            this.chkUsed = new DevExpress.XtraEditors.CheckEdit();
            this.lciUsed = new DevExpress.XtraLayout.LayoutControlItem();
            this.mmoNote = new DevExpress.XtraEditors.MemoEdit();
            this.lciNote = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.lciButtonCancel = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.lciButtonSaveInsert = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.lciButtonSaveClose = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtUnitID = new DevExpress.XtraEditors.TextEdit();
            this.lciUnitID = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.locMain)).BeginInit();
            this.locMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUnitCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVNName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVNName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtENName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciENName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueUnitType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUnitType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speRank.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUsed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUsed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmoNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonSaveInsert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonSaveClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUnitID)).BeginInit();
            this.SuspendLayout();
            // 
            // locMain
            // 
            this.locMain.Controls.Add(this.txtUnitID);
            this.locMain.Controls.Add(this.simpleButton3);
            this.locMain.Controls.Add(this.simpleButton2);
            this.locMain.Controls.Add(this.simpleButton1);
            this.locMain.Controls.Add(this.mmoNote);
            this.locMain.Controls.Add(this.chkUsed);
            this.locMain.Controls.Add(this.speRank);
            this.locMain.Controls.Add(this.lueUnitType);
            this.locMain.Controls.Add(this.txtENName);
            this.locMain.Controls.Add(this.txtVNName);
            this.locMain.Controls.Add(this.txtUnitCode);
            this.locMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.locMain.Location = new System.Drawing.Point(0, 0);
            this.locMain.Name = "locMain";
            this.locMain.Root = this.logMain;
            this.locMain.Size = new System.Drawing.Size(450, 251);
            this.locMain.TabIndex = 0;
            this.locMain.Text = "layoutControl1";
            // 
            // logMain
            // 
            this.logMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.logMain.GroupBordersVisible = false;
            this.logMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.logDetail,
            this.lciButtonCancel,
            this.lciButtonSaveInsert,
            this.lciButtonSaveClose,
            this.lciUnitID});
            this.logMain.Location = new System.Drawing.Point(0, 0);
            this.logMain.Name = "logMain";
            this.logMain.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.logMain.Size = new System.Drawing.Size(450, 251);
            this.logMain.TextVisible = false;
            // 
            // logDetail
            // 
            this.logDetail.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciUnitCode,
            this.lciVNName,
            this.lciENName,
            this.lciUnitType,
            this.lciRank,
            this.lciUsed,
            this.lciNote});
            this.logDetail.Location = new System.Drawing.Point(0, 0);
            this.logDetail.Name = "logDetail";
            this.logDetail.Size = new System.Drawing.Size(450, 225);
            // 
            // txtUnitCode
            // 
            this.txtUnitCode.Location = new System.Drawing.Point(87, 32);
            this.txtUnitCode.Name = "txtUnitCode";
            this.txtUnitCode.Size = new System.Drawing.Size(121, 20);
            this.txtUnitCode.StyleController = this.locMain;
            this.txtUnitCode.TabIndex = 4;
            // 
            // lciUnitCode
            // 
            this.lciUnitCode.Control = this.txtUnitCode;
            this.lciUnitCode.Location = new System.Drawing.Point(0, 0);
            this.lciUnitCode.Name = "lciUnitCode";
            this.lciUnitCode.Size = new System.Drawing.Size(198, 24);
            this.lciUnitCode.Text = "Mã đơn vị:";
            this.lciUnitCode.TextSize = new System.Drawing.Size(70, 13);
            // 
            // txtVNName
            // 
            this.txtVNName.Location = new System.Drawing.Point(87, 56);
            this.txtVNName.Name = "txtVNName";
            this.txtVNName.Size = new System.Drawing.Size(349, 20);
            this.txtVNName.StyleController = this.locMain;
            this.txtVNName.TabIndex = 5;
            // 
            // lciVNName
            // 
            this.lciVNName.Control = this.txtVNName;
            this.lciVNName.Location = new System.Drawing.Point(0, 24);
            this.lciVNName.Name = "lciVNName";
            this.lciVNName.Size = new System.Drawing.Size(426, 24);
            this.lciVNName.Text = "Tên đơn vị VN:";
            this.lciVNName.TextSize = new System.Drawing.Size(70, 13);
            // 
            // txtENName
            // 
            this.txtENName.Location = new System.Drawing.Point(87, 80);
            this.txtENName.Name = "txtENName";
            this.txtENName.Size = new System.Drawing.Size(349, 20);
            this.txtENName.StyleController = this.locMain;
            this.txtENName.TabIndex = 6;
            // 
            // lciENName
            // 
            this.lciENName.Control = this.txtENName;
            this.lciENName.Location = new System.Drawing.Point(0, 48);
            this.lciENName.Name = "lciENName";
            this.lciENName.Size = new System.Drawing.Size(426, 24);
            this.lciENName.Text = "Tên đơn vị EN:";
            this.lciENName.TextSize = new System.Drawing.Size(70, 13);
            // 
            // lueUnitType
            // 
            this.lueUnitType.Location = new System.Drawing.Point(285, 32);
            this.lueUnitType.Name = "lueUnitType";
            this.lueUnitType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueUnitType.Size = new System.Drawing.Size(151, 20);
            this.lueUnitType.StyleController = this.locMain;
            this.lueUnitType.TabIndex = 7;
            // 
            // lciUnitType
            // 
            this.lciUnitType.Control = this.lueUnitType;
            this.lciUnitType.Location = new System.Drawing.Point(198, 0);
            this.lciUnitType.Name = "lciUnitType";
            this.lciUnitType.Size = new System.Drawing.Size(228, 24);
            this.lciUnitType.Text = "Loại đơn vị:";
            this.lciUnitType.TextSize = new System.Drawing.Size(70, 13);
            // 
            // speRank
            // 
            this.speRank.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.speRank.Location = new System.Drawing.Point(87, 104);
            this.speRank.Name = "speRank";
            this.speRank.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.speRank.Size = new System.Drawing.Size(172, 20);
            this.speRank.StyleController = this.locMain;
            this.speRank.TabIndex = 8;
            // 
            // lciRank
            // 
            this.lciRank.Control = this.speRank;
            this.lciRank.Location = new System.Drawing.Point(0, 72);
            this.lciRank.Name = "lciRank";
            this.lciRank.Size = new System.Drawing.Size(249, 24);
            this.lciRank.Text = "Thứ tự:";
            this.lciRank.TextSize = new System.Drawing.Size(70, 13);
            // 
            // chkUsed
            // 
            this.chkUsed.Location = new System.Drawing.Point(271, 104);
            this.chkUsed.Name = "chkUsed";
            this.chkUsed.Properties.Caption = "Đang sử dụng?";
            this.chkUsed.Size = new System.Drawing.Size(165, 19);
            this.chkUsed.StyleController = this.locMain;
            this.chkUsed.TabIndex = 9;
            // 
            // lciUsed
            // 
            this.lciUsed.Control = this.chkUsed;
            this.lciUsed.Location = new System.Drawing.Point(249, 72);
            this.lciUsed.Name = "lciUsed";
            this.lciUsed.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2);
            this.lciUsed.Size = new System.Drawing.Size(177, 24);
            this.lciUsed.TextSize = new System.Drawing.Size(0, 0);
            this.lciUsed.TextVisible = false;
            // 
            // mmoNote
            // 
            this.mmoNote.Location = new System.Drawing.Point(87, 128);
            this.mmoNote.Name = "mmoNote";
            this.mmoNote.Size = new System.Drawing.Size(349, 83);
            this.mmoNote.StyleController = this.locMain;
            this.mmoNote.TabIndex = 10;
            // 
            // lciNote
            // 
            this.lciNote.Control = this.mmoNote;
            this.lciNote.Location = new System.Drawing.Point(0, 96);
            this.lciNote.Name = "lciNote";
            this.lciNote.Size = new System.Drawing.Size(426, 87);
            this.lciNote.Text = "Ghi chú:";
            this.lciNote.TextSize = new System.Drawing.Size(70, 13);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(352, 227);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(96, 22);
            this.simpleButton1.StyleController = this.locMain;
            this.simpleButton1.TabIndex = 11;
            this.simpleButton1.Text = "simpleButton1";
            // 
            // lciButtonCancel
            // 
            this.lciButtonCancel.Control = this.simpleButton1;
            this.lciButtonCancel.Location = new System.Drawing.Point(350, 225);
            this.lciButtonCancel.Name = "lciButtonCancel";
            this.lciButtonCancel.Size = new System.Drawing.Size(100, 26);
            this.lciButtonCancel.TextSize = new System.Drawing.Size(0, 0);
            this.lciButtonCancel.TextVisible = false;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(252, 227);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(96, 22);
            this.simpleButton2.StyleController = this.locMain;
            this.simpleButton2.TabIndex = 12;
            this.simpleButton2.Text = "simpleButton2";
            // 
            // lciButtonSaveInsert
            // 
            this.lciButtonSaveInsert.Control = this.simpleButton2;
            this.lciButtonSaveInsert.Location = new System.Drawing.Point(250, 225);
            this.lciButtonSaveInsert.Name = "lciButtonSaveInsert";
            this.lciButtonSaveInsert.Size = new System.Drawing.Size(100, 26);
            this.lciButtonSaveInsert.TextSize = new System.Drawing.Size(0, 0);
            this.lciButtonSaveInsert.TextVisible = false;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(152, 227);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(96, 22);
            this.simpleButton3.StyleController = this.locMain;
            this.simpleButton3.TabIndex = 13;
            this.simpleButton3.Text = "simpleButton3";
            // 
            // lciButtonSaveClose
            // 
            this.lciButtonSaveClose.Control = this.simpleButton3;
            this.lciButtonSaveClose.Location = new System.Drawing.Point(150, 225);
            this.lciButtonSaveClose.Name = "lciButtonSaveClose";
            this.lciButtonSaveClose.Size = new System.Drawing.Size(100, 26);
            this.lciButtonSaveClose.TextSize = new System.Drawing.Size(0, 0);
            this.lciButtonSaveClose.TextVisible = false;
            // 
            // txtUnitID
            // 
            this.txtUnitID.Location = new System.Drawing.Point(2, 227);
            this.txtUnitID.Name = "txtUnitID";
            this.txtUnitID.Size = new System.Drawing.Size(146, 20);
            this.txtUnitID.StyleController = this.locMain;
            this.txtUnitID.TabIndex = 14;
            // 
            // lciUnitID
            // 
            this.lciUnitID.ContentVisible = false;
            this.lciUnitID.Control = this.txtUnitID;
            this.lciUnitID.Location = new System.Drawing.Point(0, 225);
            this.lciUnitID.MaxSize = new System.Drawing.Size(150, 26);
            this.lciUnitID.MinSize = new System.Drawing.Size(150, 26);
            this.lciUnitID.Name = "lciUnitID";
            this.lciUnitID.Size = new System.Drawing.Size(150, 26);
            this.lciUnitID.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciUnitID.TextSize = new System.Drawing.Size(0, 0);
            this.lciUnitID.TextVisible = false;
            // 
            // uc_UnitDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.locMain);
            this.DoubleBuffered = true;
            this.Name = "uc_UnitDetail";
            this.Size = new System.Drawing.Size(450, 251);
            ((System.ComponentModel.ISupportInitialize)(this.locMain)).EndInit();
            this.locMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUnitCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVNName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVNName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtENName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciENName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueUnitType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUnitType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speRank.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUsed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUsed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmoNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonSaveInsert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtonSaveClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUnitID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl locMain;
        private DevExpress.XtraLayout.LayoutControlGroup logMain;
        private DevExpress.XtraLayout.LayoutControlGroup logDetail;
        private DevExpress.XtraEditors.TextEdit txtENName;
        private DevExpress.XtraEditors.TextEdit txtVNName;
        private DevExpress.XtraEditors.TextEdit txtUnitCode;
        private DevExpress.XtraLayout.LayoutControlItem lciUnitCode;
        private DevExpress.XtraLayout.LayoutControlItem lciVNName;
        private DevExpress.XtraLayout.LayoutControlItem lciENName;
        private DevExpress.XtraEditors.LookUpEdit lueUnitType;
        private DevExpress.XtraLayout.LayoutControlItem lciUnitType;
        private DevExpress.XtraEditors.MemoEdit mmoNote;
        private DevExpress.XtraEditors.CheckEdit chkUsed;
        private DevExpress.XtraEditors.SpinEdit speRank;
        private DevExpress.XtraLayout.LayoutControlItem lciRank;
        private DevExpress.XtraLayout.LayoutControlItem lciUsed;
        private DevExpress.XtraLayout.LayoutControlItem lciNote;
        private DevExpress.XtraEditors.TextEdit txtUnitID;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.LayoutControlItem lciButtonCancel;
        private DevExpress.XtraLayout.LayoutControlItem lciButtonSaveInsert;
        private DevExpress.XtraLayout.LayoutControlItem lciButtonSaveClose;
        private DevExpress.XtraLayout.LayoutControlItem lciUnitID;
    }
}
