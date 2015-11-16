using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace iPOS.IMC.Tool
{
    public partial class frmWaiting : DevExpress.XtraWaitForm.WaitForm
    {
        int x = 0;
        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            lblCaption.Text = caption;
        }

        public override void SetDescription(string description)
        {
            if (description.Length > 42)
                description = description.Substring(0, 42);
            description += "...";
            base.SetDescription(description);
            lblDescription.Text = description;
        }

        public frmWaiting()
        {
            InitializeComponent();
        }

        private void picLoading_Paint(object sender, PaintEventArgs e)
        {
            Image newImage = iPOS.IMC.Properties.Resources.loading;

            // Create rectangle for displaying image.
            Rectangle destRect = new Rectangle(0, 0, 48, 48);

            // Create rectangle for source image.
            Rectangle srcRect;
            srcRect = new Rectangle(0, x * 48, 48, 48);
            GraphicsUnit units = GraphicsUnit.Pixel;

            // Draw image to screen.
            e.Graphics.DrawImage(newImage, destRect, srcRect, units);
        }

        private void tmeTimer_Tick(object sender, EventArgs e)
        {
            if (x >= 56) x = -1;
            x += 1;
            Invalidate();
        }
    }
}