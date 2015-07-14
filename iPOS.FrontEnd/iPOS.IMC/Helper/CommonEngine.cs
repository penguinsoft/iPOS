using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iPOS.Core.Logger;
using ConfigEngine = iPOS.Core.Helper.ConfigEngine;

namespace iPOS.IMC.Helper
{
    public class CommonEngine
    {
        public static iPOS.DTO.System.SYS_tblUserDTO userInfo;
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
    }
}
