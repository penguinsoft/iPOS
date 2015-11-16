using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPOS.IMC
{
    public class MyWaitForm : DevExpress.XtraWaitForm.WaitForm
    {
        int x = 0;
        private DevExpress.XtraEditors.LabelControl lbCaption;
        private DevExpress.XtraEditors.PictureEdit picLoading;
        private System.Windows.Forms.Timer tmeMain;
        private System.ComponentModel.IContainer components;
        private DevExpress.XtraEditors.LabelControl lbDescription;
    
        public MyWaitForm()
        {
            InitializeComponent();
        }

        public override void SetDescription(string description)
        {
            base.SetDescription(description);

            lbDescription.Text = description;
        }

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);

            lbCaption.Text = caption;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbDescription = new DevExpress.XtraEditors.LabelControl();
            this.lbCaption = new DevExpress.XtraEditors.LabelControl();
            this.picLoading = new DevExpress.XtraEditors.PictureEdit();
            this.tmeMain = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbDescription
            // 
            this.lbDescription.Location = new System.Drawing.Point(182, 186);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(61, 13);
            this.lbDescription.TabIndex = 0;
            this.lbDescription.Text = "lbDescription";
            // 
            // lbCaption
            // 
            this.lbCaption.Location = new System.Drawing.Point(198, 126);
            this.lbCaption.Name = "lbCaption";
            this.lbCaption.Size = new System.Drawing.Size(45, 13);
            this.lbCaption.TabIndex = 0;
            this.lbCaption.Text = "lbCaption";
            // 
            // picLoading
            // 
            this.picLoading.Location = new System.Drawing.Point(77, 99);
            this.picLoading.Name = "picLoading";
            this.picLoading.Properties.AllowFocused = false;
            this.picLoading.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picLoading.Properties.Appearance.Options.UseBackColor = true;
            this.picLoading.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picLoading.Properties.NullText = " ";
            this.picLoading.Size = new System.Drawing.Size(50, 50);
            this.picLoading.TabIndex = 1;
            this.picLoading.Paint += new System.Windows.Forms.PaintEventHandler(this.picLoading_Paint);
            // 
            // tmeMain
            // 
            this.tmeMain.Enabled = true;
            this.tmeMain.Tick += new System.EventHandler(this.tmeMain_Tick);
            // 
            // MyWaitForm
            // 
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.picLoading);
            this.Controls.Add(this.lbCaption);
            this.Controls.Add(this.lbDescription);
            this.DoubleBuffered = true;
            this.Name = "MyWaitForm";
            ((System.ComponentModel.ISupportInitialize)(this.picLoading.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void picLoading_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Image newImage = Image.FromFile(@"loading.png");

            // Create rectangle for displaying image.
            Rectangle destRect = new Rectangle(0, 0, 48, 48);

            // Create rectangle for source image.
            Rectangle srcRect;
            srcRect = new Rectangle(0, x * 48, 48, 48);
            GraphicsUnit units = GraphicsUnit.Pixel;

            // Draw image to screen.
            e.Graphics.DrawImage(newImage, destRect, srcRect, units);
        }

        private void tmeMain_Tick(object sender, EventArgs e)
        {
            if (x >= 54) x = -1;
            x += 1;
            Invalidate();
        }
    }
}
