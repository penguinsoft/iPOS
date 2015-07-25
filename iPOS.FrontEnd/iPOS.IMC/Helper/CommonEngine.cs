using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraTabbedMdi;
using iPOS.Core.Logger;
using ConfigEngine = iPOS.Core.Helper.ConfigEngine;

namespace iPOS.IMC.Helper
{
    public class CommonEngine
    {
        public static iPOS.DTO.Systems.SYS_tblUserDTO userInfo;
        public static DateTime SystemDateTime;
        protected static ILogEngine logger = new LogEngine();

        public static void ShowMessage(string message, byte type)
        {
            string title = "";
            title = LanguageManage.GetMessageCaption((type == 0) ? "ERROR_TITLE_CAPTION" : "MESSAGE_TITLE_CAPTION", ConfigEngine.Language);
            if (type == 0)
                logger.Error(message);
            XtraMessageBox.Show(message, title, MessageBoxButtons.OK, (type == 1) ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }

        public static void ShowExceptionMessage(Exception ex)
        {
            logger.Error(ex);
            XtraMessageBox.Show(ex.Message, LanguageManage.GetMessageCaption("ERROR_SYSTEM_TITLE_CAPTION", ConfigEngine.Language), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void OpenInputForm(XtraUserControl uc, Size size)
        {
            frmOpen frm = new frmOpen();
            frm.Text = LanguageManage.GetOpenFormText(uc.Name, ConfigEngine.Language);
            frm.Size = size;
            frm.MaximumSize = size;
            frm.MinimumSize = size;
            frm.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            frm.Controls.Add(uc);
            uc.Show();
            frm.ShowDialog();
        }

        public static void OpenMdiChildForm(RibbonForm index, XtraUserControl uc, XtraTabbedMdiManager tab)
        {
            bool found = false;
            foreach(XtraForm frm in index.MdiChildren)
                if (frm.Name.Equals(uc.Name))
                {
                    found = true;
                    break;
                }

            if (found)
            {
                foreach (XtraMdiTabPage _tab in tab.Pages)
                    if (_tab.Text.ToLower().Equals(LanguageManage.GetOpenFormText(uc.Name, ConfigEngine.Language).ToLower()))
                    {
                        tab.SelectedPage = _tab;
                        break;
                    }
            }
            else
            {
                XtraForm frm = new XtraForm();
                frm.Text = LanguageManage.GetOpenFormText(uc.Name, ConfigEngine.Language);
                frm.Name = uc.Name;
                frm.MdiParent = index;
                uc.Dock = DockStyle.Fill;
                frm.Controls.Clear();
                frm.Controls.Add(uc);
                frm.Show();
            }
        }
    }
}
