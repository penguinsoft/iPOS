using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iPOS.Core.Helper;
using LanguageEngine = iPOS.IMC.Helper.LanguageManage;

namespace iPOS.IMC.Tool
{
    public partial class uc_ImportExcel : DevExpress.XtraEditors.XtraUserControl
    {
        public void ChangeLanguage(string language)
        {
            LanguageEngine.ChangeCaptionLayoutControlGroup(this.Name, language, new DevExpress.XtraLayout.LayoutControlGroup[] { logSelectedFiles, logGridMainData });
            LanguageEngine.ChangeCaptionLayoutControlItem(this.Name, language, new DevExpress.XtraLayout.LayoutControlItem[] { lciBrowseFile, lciFileList });
            LanguageEngine.ChangeCaptionSimpleButton(this.Name, language, new SimpleButton[] { btnDownloadTemplate, btnCheckValid, btnImportAllFiles, btnImportSelectedFile });
            LanguageEngine.ChangeCaptionLabelControl(this.Name, language, new LabelControl[] { lblResult3, lblResult4, lblResult5, lblResult6 });
            LanguageEngine.ChangeCaptionGroupPanelTextGridView(this.Name, language, grvSeletedFiles);
            LanguageEngine.ChangeCaptionGridColumn(this.Name, language, new DevExpress.XtraGrid.Columns.GridColumn[] { gcolSelectedFileName, gcolSelectedFileSize, gcolSelectedDateModified, gcolSelectedNote, gcolSeletedFilePath });
            LanguageEngine.ChangeCaptionButtonWizardControl(this.Name, language, wzcMain);
            LanguageEngine.ChangeCaptionWelcomeWizardPage(this.Name, language, wwpStepOne);
        }

        public uc_ImportExcel()
        {
            InitializeComponent();
        }

        public uc_ImportExcel(string template_name, string store_procedure, string module_id, string function_id)
        {
            InitializeComponent();
            ChangeLanguage(ConfigEngine.Language);
        }
    }
}
