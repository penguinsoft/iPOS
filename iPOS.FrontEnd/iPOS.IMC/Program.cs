using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using ConfigEngine = iPOS.Core.Helper.ConfigEngine;

namespace iPOS.IMC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            //UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            UserLookAndFeel.Default.SetSkinStyle("Office 2007 Blue");

            if (!File.Exists(Application.StartupPath + @"\Config.ini"))
            {
                MessageBox.Show("Thieu file Config");
                return;
            }
            else
            {
                frmLogin frm = new frmLogin(ConfigEngine.Language);
                if (frm.ShowDialog() == DialogResult.OK)
                    Application.Run(new frmMain(ConfigEngine.Language));
                else Application.Exit();
                //iPOS.Core.Helper.CaptionEngine.GetControlCaption("uc_GroupUser", "gridGroupUser", iPOS.Core.Helper.BaseConstant.GRID_CONTROL, "vi");
            }
        }
    }
}