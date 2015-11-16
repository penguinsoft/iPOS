using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iPOS.IMC.Tool;

namespace iPOS.IMC
{
    public partial class frmOpen : DevExpress.XtraEditors.XtraForm
    {
        frmWaiting frm;
        public frmOpen()
        {
            InitializeComponent();
        }

        public void ShowWaitingForm()
        {
            frm = new frmWaiting();
            frm.Show();
        }

        public void CloseWaitingForm()
        {
            if (frm != null)
            {
                frm.Close();
                frm.Dispose();
            }
        }
    }
}