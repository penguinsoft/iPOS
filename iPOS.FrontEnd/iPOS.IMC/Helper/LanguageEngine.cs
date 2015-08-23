using System;
using CaptionEngine = iPOS.Core.Helper.CaptionEngine;
using MessageEngine = iPOS.Core.Helper.MessageEngine;
using ConfigEngine = iPOS.Core.Helper.ConfigEngine;
using BaseConstant = iPOS.Core.Helper.BaseConstant;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using System.Xml.Linq;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraLayout;
using DevExpress.XtraWizard;

namespace iPOS.IMC.Helper
{
    public class LanguageEngine
    {
        public static string GetMessageCaption(string name, string language)
        {
            return MessageEngine.GetMessageCaption(name, language);
        }

        public static string GetOpenFormText(string form_name, string language)
        {
            return CaptionEngine.GetControlCaption(form_name, form_name, BaseConstant.PARENT_TEXT, language);
        }

        public static string GetOpenFormText(string form_name, string language, bool isEdit)
        {
            string temp = "";
            if (isEdit)
                temp = (ConfigEngine.Language == "vi") ? "Cập Nhật" : "Update";
            else temp = (ConfigEngine.Language == "vi") ? "Thêm Mới" : "Add New";
            return string.Format("{0} {1}", temp, CaptionEngine.GetControlCaption(form_name, form_name, BaseConstant.PARENT_TEXT, language));
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
            simple_button.Text = CaptionEngine.GetControlCaption(parent_name, simple_button.Name, BaseConstant.CONTROL_TEXT, language).Replace("$$", "&&");
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

        public static void ChangeCaptionBarLargeButtonItem(string parent_name, string language, BarLargeButtonItem bar_large_button_item)
        {
            bar_large_button_item.Caption = CaptionEngine.GetControlCaption(parent_name, bar_large_button_item.Name, BaseConstant.CONTROL_TEXT, language);
        }

        public static void ChangeCaptionBarLargeButtonItem(string parent_name, string language, BarLargeButtonItem[] bar_large_button_items)
        {
            foreach (BarLargeButtonItem bar_large_button_item in bar_large_button_items)
                ChangeCaptionBarLargeButtonItem(parent_name, language, bar_large_button_item);
        }

        public static void ChangeCaptionBarStaticItem(string parent_name, string language, BarStaticItem bar_static_item)
        {
            bar_static_item.Caption = CaptionEngine.GetControlCaption(parent_name, bar_static_item.Name, BaseConstant.CONTROL_TEXT, language);
        }

        public static void ChangeCaptionBarStaticItem(string parent_name, string language, BarStaticItem[] bar_static_items)
        {
            foreach (BarStaticItem bar_static_item in bar_static_items)
                ChangeCaptionBarStaticItem(parent_name, language, bar_static_item);
        }

        public static void ChangeCaptionGridColumn(string parent_name, string language, GridColumn grid_column)
        {
            grid_column.Caption = CaptionEngine.GetControlCaption(parent_name, grid_column.Name, BaseConstant.CONTROL_TEXT, language);
        }

        public static void ChangeCaptionGridColumn(string parent_name, string language, GridColumn[] grid_columns)
        {
            foreach (GridColumn grid_column in grid_columns)
                ChangeCaptionGridColumn(parent_name, language, grid_column);
        }

        public static void ChangeCaptionGroupPanelTextGridView(string parent_name, string language, GridView grid_view)
        {
            grid_view.GroupPanelText = CaptionEngine.GetControlCaption(parent_name, grid_view.Name, BaseConstant.CONTROL_TEXT, language);
        }

        public static void ChangeCaptionGroupPanelTextGridView(string parent_name, string language, GridView[] grid_views)
        {
            foreach (GridView grid_view in grid_views)
                ChangeCaptionGroupPanelTextGridView(parent_name, language, grid_view);
        }

        public static void ChangeCaptionLayoutControlGroup(string parent_name, string language, LayoutControlGroup layout_control_group)
        {
            layout_control_group.Text = CaptionEngine.GetControlCaption(parent_name, layout_control_group.Name, BaseConstant.CONTROL_TEXT, language);
        }

        public static void ChangeCaptionLayoutControlGroup(string parent_name, string language, LayoutControlGroup[] layout_control_groups)
        {
            foreach (LayoutControlGroup layout_control_group in layout_control_groups)
                ChangeCaptionLayoutControlGroup(parent_name, language, layout_control_group);
        }

        public static void ChangeCaptionLayoutControlItem(string parent_name, string language, LayoutControlItem layout_control_item)
        {
            layout_control_item.Text = CaptionEngine.GetControlCaption(parent_name, layout_control_item.Name, BaseConstant.CONTROL_TEXT, language);
        }

        public static void ChangeCaptionLayoutControlItem(string parent_name, string language, LayoutControlItem[] layout_control_items)
        {
            foreach (LayoutControlItem layout_control_item in layout_control_items)
                ChangeCaptionLayoutControlItem(parent_name, language, layout_control_item);
        }

        public static void ChangeCaptionButtonWizardControl(string parent_name, string language, WizardControl wizard_control)
        {
            string result = CaptionEngine.GetControlCaption(parent_name, wizard_control.Name, BaseConstant.WIZARD_CONTROL, language);
            wizard_control.Text = CaptionEngine.GetControlCaption(parent_name, wizard_control.Name, BaseConstant.CONTROL_TEXT, language);
            try
            {
                string[] arr = result.Split('|');
                wizard_control.NextText = arr[0] + ">";
                wizard_control.CancelText = arr[1];
                wizard_control.FinishText = arr[2];
                wizard_control.PreviousText = "<" + arr[3];
            }
            catch 
            {
                wizard_control.NextText = "Next >";
                wizard_control.CancelText = "Cancel";
                wizard_control.FinishText = "Finish";
                wizard_control.PreviousText = "< Back";
            }
        }

        public static void ChangeCaptionWelcomeWizardPage(string parent_name, string language, WelcomeWizardPage welcome_page)
        {
            welcome_page.Text = CaptionEngine.GetControlCaption(parent_name, welcome_page.Name, BaseConstant.CONTROL_TEXT, language);
        }

        public static void ChangeCaptionWizardPage(string parent_name, string language, WizardPage wizard_page)
        {
            wizard_page.Text = CaptionEngine.GetControlCaption(parent_name, wizard_page.Name, BaseConstant.CONTROL_TEXT, language);
        }

        public static void ChangeCaptionCompletionWizardPage(string parent_name, string language, CompletionWizardPage complete_page)
        {
            complete_page.Text = CaptionEngine.GetControlCaption(parent_name, complete_page.Name, BaseConstant.CONTROL_TEXT, language);
        }
    }
}
