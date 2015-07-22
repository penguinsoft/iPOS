using System;
using CaptionEngine = iPOS.Core.Helper.CaptionEngine;
using MessageEngine = iPOS.Core.Helper.MessageEngine;
using ConfigEngine = iPOS.Core.Helper.ConfigEngine;
using BaseConstant = iPOS.Core.Helper.BaseConstant;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;

namespace iPOS.IMC.Helper
{
    public class LanguageManage
    {
        public static string GetMessageCaption(string name, string language)
        {
            return MessageEngine.GetMessageCaption(name, language);
        }

        public static string GetOpenFormText(string form_name, string language)
        {
            return CaptionEngine.GetControlCaption(form_name, form_name, BaseConstant.PARENT_TEXT, language);
        }

        public static void ChangeTextXtraForm(XtraForm form, string language)
        {
            form.Text = CaptionEngine.GetControlCaption(form.Name, form.Name, BaseConstant.PARENT_TEXT, language);
        }

        public static void ChangeTextRibbonForm(RibbonForm form, string language)
        {
            form.Text = CaptionEngine.GetControlCaption(form.Name, form.Name, BaseConstant.PARENT_TEXT, language);
        }

        public static void ChangeCaptionSimpleButton(string parent_name, string language, SimpleButton simple_button)
        {
            simple_button.Text = CaptionEngine.GetControlCaption(parent_name, simple_button.Name, BaseConstant.CONTROL_TEXT, language);
        }

        public static void ChangeCaptionSimpleButton(string parent_name, string language, SimpleButton[] simple_buttons)
        {
            foreach (SimpleButton button in simple_buttons)
                ChangeCaptionSimpleButton(parent_name, language, button);
        }

        public static void ChangeCaptionLabelControl(string parent_name, string language, LabelControl label_control)
        {
            label_control.Text = CaptionEngine.GetControlCaption(parent_name, label_control.Name, BaseConstant.CONTROL_TEXT, language);
        }

        public static void ChangeCaptionLabelControl(string parent_name, string language, LabelControl[] label_controls)
        {
            foreach (LabelControl label in label_controls)
                ChangeCaptionLabelControl(parent_name, language, label);
        }

        public static void ChangeCaptionHyperLinkEdit(string parent_name, string language, HyperLinkEdit hyper_link_edit)
        {
            hyper_link_edit.Text = CaptionEngine.GetControlCaption(parent_name, hyper_link_edit.Name, BaseConstant.CONTROL_TEXT, language);
        }

        public static void ChangeCaptionHyperLinkEdit(string parent_name, string language, HyperLinkEdit[] hyper_link_edits)
        {
            foreach (HyperLinkEdit hyper_link_edit in hyper_link_edits)
                ChangeCaptionHyperLinkEdit(parent_name, language, hyper_link_edit);
        }

        public static void ChangeCaptionCheckEdit(string parent_name, string language, CheckEdit check_edit)
        {
            check_edit.Text = CaptionEngine.GetControlCaption(parent_name, check_edit.Name, BaseConstant.CONTROL_TEXT, language);
        }

        public static void ChangeCaptionCheckEdit(string parent_name, string language, CheckEdit[] check_edits)
        {
            foreach (CheckEdit check_edit in check_edits)
                ChangeCaptionCheckEdit(parent_name, language, check_edit);
        }

        public static void ChangeCaptionImageComboBoxEdit(string parent_name, string language, ImageComboBoxEdit image_combobox_edit)
        {
            string temp = CaptionEngine.GetControlCaption(parent_name, image_combobox_edit.Name, BaseConstant.IMAGE_COMBOBOX_EDIT, language);
            if (temp != null && !string.IsNullOrEmpty(temp))
            {
                if (temp.StartsWith("@")) temp = temp.Substring(1);
                if (temp.EndsWith("@")) temp = temp.Substring(0, temp.Length - 1);
                string[] arr;
                if (temp.Contains("@"))
                {
                    arr = temp.Split('@');
                    for (int i = 0; i < image_combobox_edit.Properties.Items.Count; i++)
                    {
                        if (i <= arr.Length + 1)
                            image_combobox_edit.Properties.Items[i].Description = arr[i];
                    }
                }
            }
        }

        public static void ChangeCaptionImageComboBoxEdit(string parent_name, string language, ImageComboBoxEdit[] image_combobox_edits)
        {
            foreach (ImageComboBoxEdit image_combobox_edit in image_combobox_edits)
                ChangeCaptionImageComboBoxEdit(parent_name, language, image_combobox_edit);
        }

        public static void ChangeCaptionRibbonPage(string parent_name, string language, RibbonPage ribbon_page)
        {
            ribbon_page.Text = CaptionEngine.GetControlCaption(parent_name, ribbon_page.Name, BaseConstant.CONTROL_TEXT, language);
        }

        public static void ChangeCaptionRibbonPage(string parent_name, string language, RibbonPage[] ribbon_pages)
        {
            foreach (RibbonPage ribbon_page in ribbon_pages)
                ChangeCaptionRibbonPage(parent_name, language, ribbon_page);
        }

        public static void ChangeCaptionRibbonPageGroup(string parent_name, string language, RibbonPageGroup ribbon_page_group)
        {
            ribbon_page_group.Text = CaptionEngine.GetControlCaption(parent_name, ribbon_page_group.Name, BaseConstant.CONTROL_TEXT, language);
        }

        public static void ChangeCaptionRibbonPageGroup(string parent_name, string language, RibbonPageGroup[] ribbon_page_groups)
        {
            foreach (RibbonPageGroup ribbon_page_group in ribbon_page_groups)
                ChangeCaptionRibbonPageGroup(parent_name, language, ribbon_page_group);
        }

        public static void ChangeCaptionBarButtonItem(string parent_name, string language, BarButtonItem bar_button_item)
        {
            bar_button_item.Caption = CaptionEngine.GetControlCaption(parent_name, bar_button_item.Name, BaseConstant.CONTROL_TEXT, language);
        }

        public static void ChangeCaptionBarButtonItem(string parent_name, string language, BarButtonItem[] bar_button_items)
        {
            foreach (BarButtonItem bar_button_item in bar_button_items)
                ChangeCaptionBarButtonItem(parent_name, language, bar_button_item);
        }
    }
}
