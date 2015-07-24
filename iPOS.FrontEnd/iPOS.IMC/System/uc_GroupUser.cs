using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LanguageEngine = iPOS.IMC.Helper.LanguageManage;
using CommonEngine = iPOS.IMC.Helper.CommonEngine;
using iPOS.BUS.System;

public partial class uc_GroupUser : DevExpress.XtraEditors.XtraUserControl
{
    public void ChangeLanguage(string language)
    {
        LanguageEngine.ChangeCaptionBarLargeButtonItem(this.Name, language, new DevExpress.XtraBars.BarLargeButtonItem[] { btnInsert, btnUpdate, btnDelete, btnPrint, btnReload, btnImport, btnExport, btnClose });
        LanguageEngine.ChangeCaptionBarStaticItem(this.Name, language, new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreateTime, lblEditer, lblEditTime });
        LanguageEngine.ChangeCaptionGroupPanelTextGridView(this.Name, language, grvGroupUser);
        LanguageEngine.ChangeCaptionGridColumn(this.Name, language, new DevExpress.XtraGrid.Columns.GridColumn[] { gcolGroupCode, gcolGroupName, gcolActiveString, gcolIsDefaultString, gcolNote });

        GetAllGroupUsers();
    }

    public uc_GroupUser()
    {
        InitializeComponent();
    }

    public uc_GroupUser(string language)
    {
        InitializeComponent();
        ChangeLanguage(language);
    }

    private async void GetAllGroupUsers()
    {
        gridGroupUser.DataBindings.Clear();
        List<iPOS.DTO.System.SYS_tblGroupUserDTO> list = new List<iPOS.DTO.System.SYS_tblGroupUserDTO>();
        list = await SYS_tblGroupUserBUS.GetAllGroupUsers(CommonEngine.userInfo.UserName, CommonEngine.userInfo.LanguageID);
        gridGroupUser.DataSource = list;
    }
}
