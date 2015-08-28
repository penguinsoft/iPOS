using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LanguageEngine = iPOS.IMC.Helper.LanguageEngine;
using CommonEngine = iPOS.IMC.Helper.CommonEngine;
using iPOS.BUS.Systems;
using iPOS.DTO.Systems;
using iPOS.Core.Helper;

namespace iPOS.IMC.Systems
{
    public partial class uc_GroupUser : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        private List<SYS_tblGroupUserDTO> curItem = new List<SYS_tblGroupUserDTO>();

        private string group_code_list = "", group_id_list = "";
        #endregion

        #region [Personal Methods]
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
                list = await SYS_tblGroupUserBUS.GetAllGroupUsers(CommonEngine.userInfo.UserName, CommonEngine.userInfo.LanguageID, false);
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
                curItem.Clear();
                curItem.Add((SYS_tblGroupUserDTO)grvGroupUser.GetFocusedRow());
                if (curItem != null)
                {
                    CommonEngine.ChangeDateTimeActionToCurrentData<SYS_tblGroupUserDTO>(curItem, new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreaterValue, lblCreateTime, lblCreateTimeValue, lblEditer, lblEditerValue, lblEditTime, lblEditTimeValue });
                }
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
            }
        }

        private async void DeleteGroupUser()
        {
            string strErr = "ready";
            try
            {
                if (group_id_list.Contains("$"))
                {
                    if (CommonEngine.ShowConfirmMessageAlert(LanguageEngine.GetMessageCaption("000012", ConfigEngine.Language).Replace("$Count$", group_id_list.Split('$').Length.ToString())))
                        strErr = await SYS_tblGroupUserBUS.DeleteGroupUser(group_id_list, group_code_list, CommonEngine.userInfo.Username, ConfigEngine.Language);
                }
                else
                {
                    if (CommonEngine.ShowConfirmMessageAlert(LanguageEngine.GetMessageCaption("000005", ConfigEngine.Language)))
                        strErr = await SYS_tblGroupUserBUS.DeleteGroupUser(group_id_list, group_code_list, CommonEngine.userInfo.Username, ConfigEngine.Language);
                }

                if (!strErr.Equals("ready"))
                    if (string.IsNullOrEmpty(strErr)) GetAllGroupUsers();
                    else CommonEngine.ShowMessage(strErr, 0);
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
            }
        }
        #endregion

        #region [Form Events]
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
            CommonEngine.OpenInputForm(new uc_GroupUserDetail(this), new Size(450, 290), false);
        }

        private async void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (curItem.Count > 0)
            {
                SYS_tblGroupUserDTO item = await SYS_tblGroupUserBUS.GetGroupUserItem(CommonEngine.userInfo.Username, ConfigEngine.Language, curItem[0].GroupID);
                if (item != null)
                    CommonEngine.OpenInputForm(new uc_GroupUserDetail(this, item), new Size(450, 290), true);
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteGroupUser();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetAllGroupUsers();
        }

        private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonEngine.OpenImportExcelForm("SYS_GroupUser_FileSelect.xlsx", "SYS_spfrmGroupUserImport", "SYS", "9");
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonEngine.QuickExportGridViewData(ConvertEngine.ConvertObjectListToDataTable<SYS_tblGroupUserDTO>(gridGroupUser.DataSource as List<SYS_tblGroupUserDTO>), grvGroupUser);
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ParentForm.Close();
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
            GetCurrentRow();
        }

        private void grvGroupUser_FocusedRowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {
            GetCurrentRow();
        }

        private void grvGroupUser_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            group_code_list = "";
            group_id_list = "";
            foreach (int index in grvGroupUser.GetSelectedRows())
            {
                group_code_list += grvGroupUser.GetRowCellDisplayText(index, gcolGroupCode) + "$";
                group_id_list += grvGroupUser.GetRowCellDisplayText(index, gcolGroupID) + "$";
            }

            if (group_code_list.Length > 0)
                group_code_list = group_code_list.Substring(0, group_code_list.Length - 1);
            if (group_id_list.Length > 0)
                group_id_list = group_id_list.Substring(0, group_id_list.Length - 1);
        }
        #endregion
    }

}