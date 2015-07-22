﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

public partial class uc_User : DevExpress.XtraEditors.XtraUserControl
{
    public uc_User()
    {
        InitializeComponent();
    }

    public void Message(string language)
    {
        MessageBox.Show("Hell Demons: " + simpleButton1.Name + " : " + language);
        iPOS.IMC.Helper.LanguageManage.ChangeCaptionSimpleButton(this.Name, language, simpleButton1);
    }
}