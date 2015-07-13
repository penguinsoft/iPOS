using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using CaptionEngine = iPOS.Core.Helper.CaptionEngine;
using BaseConstant = iPOS.Core.Helper.BaseConstant;
using ConfigEngine = iPOS.Core.Helper.ConfigEngine;

namespace iPOS.IMC.Extension
{
    public class CaptionCore
    {
        public static void ChangeCaptionSimpleButton(string parent_name, string language, SimpleButton simple_button)
        {
            simple_button.Text = CaptionEngine.GetControlCaption(ConfigEngine.CaptionPath, parent_name, simple_button.Name, BaseConstant.CONTROL_TEXT, language);
        }
    }
}
