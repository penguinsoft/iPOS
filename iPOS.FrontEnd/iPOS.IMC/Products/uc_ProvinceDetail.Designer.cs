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
            this.locMain = new DevExpress.XtraLayout.LayoutControl();
            this.logMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.logDetail = new DevExpress.XtraLayout.LayoutControlGroup();
            this.txtProvinceCode = new DevExpress.XtraEditors.TextEdit();
            this.lciProvinceCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtVNName = new DevExpress.XtraEditors.TextEdit();
            this.lciVNName = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtENName = new DevExpress.XtraEditors.TextEdit();
            this.lciENName = new DevExpress.XtraLayout.LayoutControlItem();
            this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
            this.lciRank = new DevExpress.XtraLayout.LayoutControlItem();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.lciActive = new DevExpress.XtraLayout.LayoutControlItem();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.lciNote = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtProvinceID = new DevExpress.XtraEditors.TextEdit();
            this.lciProvinceID = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.locMain)).BeginInit();
            this.locMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProvinceCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciProvinceCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVNName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVNName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtENName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciENName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProvinceID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciProvinceID)).BeginInit();
            this.SuspendLayout();
            // 
            // locMain
            // 
            this.locMain.Controls.Add(this.txtProvinceID);
            this.locMain.Controls.Add(this.simpleButton3);
            this.locMain.Controls.Add(this.simpleButton2);
            this.locMain.Controls.Add(this.simpleButton1);
            this.locMain.Controls.Add(this.memoEdit1);
            this.locMain.Controls.Add(this.checkEdit1);
            this.locMain.Controls.Add(this.spinEdit1);
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
            // txtProvinceCode
            // 
            this.txtProvinceCode.Location = new System.Drawing.Point(108, 33);
            this.txtProvinceCode.Name = "txtProvinceCode";
            this.txtProvinceCode.Size = new System.Drawing.Size(309, 20);
            this.txtProvinceCode.StyleController = this.locMain;
            this.txtProvinceCode.TabIndex = 4;
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
            // txtVNName
            // 
            this.txtVNName.Location = new System.Drawing.Point(108, 57);
            this.txtVNName.Name = "txtVNName";
            this.txtVNName.Size = new System.Drawing.Size(309, 20);
            this.txtVNName.StyleController = this.locMain;
            this.txtVNName.TabIndex = 5;
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
            // txtENName
            // 
            this.txtENName.Location = new System.Drawing.Point(108, 81);
            this.txtENName.Name = "txtENName";
            this.txtENName.Size = new System.Drawing.Size(309, 20);
            this.txtENName.StyleController = this.locMain;
            this.txtENName.TabIndex = 6;
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
            // spinEdit1
            // 
            this.spinEdit1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit1.Location = new System.Drawing.Point(108, 105);
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit1.Size = new System.Drawing.Size(180, 20);
            this.spinEdit1.StyleController = this.locMain;
            this.spinEdit1.TabIndex = 7;
            // 
            // lciRank
            // 
            this.lciRank.Control = this.spinEdit1;
            this.lciRank.CustomizationFormText = "layoutControlItem1";
            this.lciRank.Location = new System.Drawing.Point(0, 72);
            this.lciRank.Name = "lciRank";
            this.lciRank.Size = new System.Drawing.Size(278, 24);
            this.lciRank.Text = "Thứ tự:";
            this.lciRank.TextSize = new System.Drawing.Size(90, 13);
            // 
            // checkEdit1
            // 
            this.checkEdit1.EditValue = true;
            this.checkEdit1.Location = new System.Drawing.Point(300, 105);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Đang sử dụng?";
            this.checkEdit1.Size = new System.Drawing.Size(117, 19);
            this.checkEdit1.StyleController = this.locMain;
            this.checkEdit1.TabIndex = 8;
            // 
            // lciActive
            // 
            this.lciActive.Control = this.checkEdit1;
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
            // memoEdit1
            // 
            this.memoEdit1.Location = new System.Drawing.Point(108, 129);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(309, 85);
            this.memoEdit1.StyleController = this.locMain;
            this.memoEdit1.TabIndex = 9;
            // 
            // lciNote
            // 
            this.lciNote.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lciNote.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lciNote.Control = this.memoEdit1;
            this.lciNote.CustomizationFormText = "Ghi chú:";
            this.lciNote.Location = new System.Drawing.Point(0, 96);
            this.lciNote.Name = "lciNote";
            this.lciNote.Size = new System.Drawing.Size(407, 89);
            this.lciNote.Text = "Ghi chú:";
            this.lciNote.TextSize = new System.Drawing.Size(90, 13);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(351, 230);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(78, 22);
            this.simpleButton1.StyleController = this.locMain;
            this.simpleButton1.TabIndex = 10;
            this.simpleButton1.Text = "simpleButton1";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.simpleButton1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(349, 228);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(82, 26);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(269, 230);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(78, 22);
            this.simpleButton2.StyleController = this.locMain;
            this.simpleButton2.TabIndex = 11;
            this.simpleButton2.Text = "simpleButton2";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.simpleButton2;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(267, 228);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(82, 26);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(187, 230);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(78, 22);
            this.simpleButton3.StyleController = this.locMain;
            this.simpleButton3.TabIndex = 12;
            this.simpleButton3.Text = "simpleButton3";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.simpleButton3;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(185, 228);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(82, 26);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // txtProvinceID
            // 
            this.txtProvinceID.Location = new System.Drawing.Point(2, 230);
            this.txtProvinceID.Name = "txtProvinceID";
            this.txtProvinceID.Size = new System.Drawing.Size(181, 20);
            this.txtProvinceID.StyleController = this.locMain;
            this.txtProvinceID.TabIndex = 13;
            // 
            // lciProvinceID
            // 
            this.lciProvinceID.ContentVisible = false;
            this.lciProvinceID.Control = this.txtProvinceID;
            this.lciProvinceID.CustomizationFormText = "lciProvinceID";
            this.lciProvinceID.Location = new System.Drawing.Point(0, 228);
            this.lciProvinceID.Name = "lciProvinceID";
            this.lciProvinceID.Size = new System.Drawing.Size(185, 26);
            this.lciProvinceID.Text = "lciProvinceID";
            this.lciProvinceID.TextSize = new System.Drawing.Size(0, 0);
            this.lciProvinceID.TextToControlDistance = 0;
            this.lciProvinceID.TextVisible = false;
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
            ((System.ComponentModel.ISupportInitialize)(this.logMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProvinceCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciProvinceCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVNName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVNName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtENName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciENName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProvinceID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciProvinceID)).EndInit();
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
        private DevExpress.XtraEditors.SpinEdit spinEdit1;
        private DevExpress.XtraLayout.LayoutControlItem lciRank;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraLayout.LayoutControlItem lciActive;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraLayout.LayoutControlItem lciNote;
        private DevExpress.XtraEditors.TextEdit txtProvinceID;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem lciProvinceID;
    }
}
