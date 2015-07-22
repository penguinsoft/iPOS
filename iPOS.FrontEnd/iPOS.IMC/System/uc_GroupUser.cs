using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

public partial class uc_GroupUser : DevExpress.XtraEditors.XtraUserControl
{
    public uc_GroupUser()
    {
        InitializeComponent();
    }

    public void Message(string language)
    {
        MessageBox.Show("Hell Demons: " + buttonEdit1.Name + " : " + language);
    }
}
