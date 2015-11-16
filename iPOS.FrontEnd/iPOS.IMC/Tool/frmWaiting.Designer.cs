namespace iPOS.IMC.Tool
{
    partial class frmWaiting
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblCaption = new DevExpress.XtraEditors.LabelControl();
            this.lblDescription = new DevExpress.XtraEditors.LabelControl();
            this.picLoading = new DevExpress.XtraEditors.PictureEdit();
            this.tmeTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCaption.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblCaption.Location = new System.Drawing.Point(93, 21);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(155, 13);
            this.lblCaption.TabIndex = 2;
            this.lblCaption.Text = "Vui lòng chờ trong giây lát...";
            // 
            // lblDescription
            // 
            this.lblDescription.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblDescription.Location = new System.Drawing.Point(93, 40);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(100, 13);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Đang xử lý dữ liệu...";
            // 
            // picLoading
            // 
            this.picLoading.Location = new System.Drawing.Point(26, 12);
            this.picLoading.Name = "picLoading";
            this.picLoading.Properties.AllowFocused = false;
            this.picLoading.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picLoading.Properties.Appearance.Options.UseBackColor = true;
            this.picLoading.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picLoading.Properties.NullText = " ";
            this.picLoading.Properties.ShowMenu = false;
            this.picLoading.Size = new System.Drawing.Size(50, 50);
            this.picLoading.TabIndex = 0;
            this.picLoading.Paint += new System.Windows.Forms.PaintEventHandler(this.picLoading_Paint);
            // 
            // tmeTimer
            // 
            this.tmeTimer.Enabled = true;
            this.tmeTimer.Tick += new System.EventHandler(this.tmeTimer_Tick);
            // 
            // frmWaiting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 74);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.picLoading);
            this.DoubleBuffered = true;
            this.Name = "frmWaiting";
            this.ShowIcon = false;
            this.Text = "frmWaiting";
            ((System.ComponentModel.ISupportInitialize)(this.picLoading.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit picLoading;
        private DevExpress.XtraEditors.LabelControl lblCaption;
        private DevExpress.XtraEditors.LabelControl lblDescription;
        private System.Windows.Forms.Timer tmeTimer;
    }
}