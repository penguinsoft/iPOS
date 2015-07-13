using System;
using System.Collections.Generic;
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

            Application.Run(new frmLogin(ConfigEngine.Language));
        }
    }
}