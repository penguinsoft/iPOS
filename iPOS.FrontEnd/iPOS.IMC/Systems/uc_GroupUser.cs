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
using iPOS.BUS.Systems;
using iPOS.DTO.Systems;
using iPOS.Core.Helper;

public partial class uc_GroupUser : DevExpress.XtraEditors.XtraUserControl
{
    private SYS_tblGroupUserDTO curItem;

    public void ChangeLanguage(string language)
    {
        LanguageEngine.ChangeCaptionBarLargeButtonItem(this.Name, language, new DevExpress.XtraBars.BarLargeButtonItem[] { btnInsert, btnUpdate, btnDelete, btnPrint, btnReload, btnImport, btnExport, btnClose });
        LanguageEngine.ChangeCaptionBarStaticItem(this.Name, language, new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreateTime, lblEditer, lblEditTime });
        LanguageEngine.ChangeCaptionGroupPanelTextGridView(this.Name, language, grvGroupUser);
        LanguageEngine.ChangeCaptionGridColumn(this.Name, language, new DevExpress.XtraGrid.Columns.GridColumn[] { gcolGroupCode, gcolGroupName, gcolActiveString, gcolIsDefaultString, gcolNote });

        GetAllGroupUsers();
    }

    public async void GetAllGroupUsers()
    {
        try
        {
            gridGroupUser.DataBindings.Clear();
            List<iPOS.DTO.Systems.SYS_tblGroupUserDTO> list = new List<iPOS.DTO.Systems.SYS_tblGroupUserDTO>();
            list = await SYS_tblGroupUserBUS.GetAllGroupUsers(CommonEngine.userInfo.UserName, CommonEngine.userInfo.LanguageID);
            gridGroupUser.DataSource = list;
            barBottom.Visible = (list.Count > 0) ? true : false;
        }
        catch (Exception ex)
        {
            CommonEngine.ShowExceptionMessage(ex);
        }
    }

    private void GetCurrentRow()
    {
        try
        {
            curItem = (SYS_tblGroupUserDTO)grvGroupUser.GetFocusedRow();
            if (curItem != null)
            {
                lblCreaterValue.Caption = curItem.Creater;
                lblCreateTimeValue.Caption = curItem.CreateTime.ToString(ConfigEngine.DateTimeFormat);
                lblEditerValue.Caption = curItem.Editer;
                //lblEditTimeValue.Caption = curItem.EditTime.ToString(ConfigEngine.DateTimeFormat);
            }
        }
        catch (Exception ex)
        {
            CommonEngine.ShowExceptionMessage(ex);
        }
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

    private void btnInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        CommonEngine.OpenInputForm(new uc_GroupUserDetail(this), new Size(450, 290));
    }

    private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {

    }

    private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {

    }

    private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {

    }

    private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {

    }

    private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {

    }

    private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {

    }

    private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {

    }

    private void uc_GroupUser_Load(object sender, EventArgs e)
    {
        GetAllGroupUsers();
    }

    private void grvGroupUser_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
    {
        if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            e.Info.DisplayText = e.RowHandle + 1 + "";
    }

    private void grvGroupUser_DoubleClick(object sender, EventArgs e)
    {
        btnUpdate_ItemClick(null, null);
    }

    private void grvGroupUser_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
    {

    }

    private void grvGroupUser_FocusedRowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
    {

    }

    private void grvGroupUser_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
    {

    }
}
