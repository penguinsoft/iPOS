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

            System.Diagnostics.Stopwatch sw1 = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch sw2 = new System.Diagnostics.Stopwatch();
            sw1.Start();
            int n = 1351264234, m = 11234576;
            while (n != m)
            {
                if (n > m) n -= m;
                else m -= n;
            }
            int ucln1 = m;
            sw1.Stop();

            string time1 = sw1.Elapsed.ToString();
            sw2.Start();
            n = 1351264234;
            m = 11234576;
            int i = 1, ucln2 = 0;
            int gioi_han = 0;
            if (n >= m) gioi_han = m;
            else gioi_han = n;
            while (i <= gioi_han)
            {
                if (n % i == 0 && m % i == 0)
                    ucln2 = i;
                i += 1;
            }
            sw2.Stop();
            string time2 = sw2.Elapsed.ToString();

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
            }
        }
    }
}