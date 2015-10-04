﻿using System;
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
using System.Threading.Tasks;
using iPOS.DRO.Systems;

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
                SYS_tblGroupUserDRO list = await SYS_tblGroupUserBUS.GetAllGroupUsers(CommonEngine.userInfo.UserID, CommonEngine.userInfo.LanguageID, false, new SYS_tblActionLogDTO
                {
                    Activity = BaseConstant.COMMAND_INSERT_EN,
                    UserID = CommonEngine.userInfo.UserID,
                    LanguageID = ConfigEngine.Language,
                    ActionEN = BaseConstant.COMMAND_LOAD_ALL_DATA_EN,
                    ActionVN = BaseConstant.COMMAND_LOAD_ALL_DATA_VI,
                    FunctionID = "9",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa tải thành công dữ liệu nhóm người dùng.", CommonEngine.userInfo.UserID),
                    DescriptionEN = string.Format("Account '{0}' downloaded successfully data of group users.", CommonEngine.userInfo.UserID)
                });
                if (list.ResponseItem.IsError)
                {
                    CommonEngine.ShowHTTPErrorMessage(list.ResponseItem);
                    return;
                }
                else gridGroupUser.DataSource = list.GroupUserList;
                barBottom.Visible = (list != null && list.GroupUserList.Count > 0) ? true : false;
                CommonEngine.LoadUserPermission("9", btnDelete, btnPrint, btnImport, btnExport);
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

        private async Task DeleteGroupUser()
        {
            group_code_list = "";
            group_id_list = "";
            foreach (int index in grvGroupUser.GetSelectedRows())
            {
                group_code_list = string.Join("$", group_code_list, grvGroupUser.GetRowCellDisplayText(index, gcolGroupCode));
                group_id_list = string.Join("$", group_id_list, grvGroupUser.GetRowCellDisplayText(index, gcolGroupID));
            }

            if (group_code_list.Length > 0) group_code_list = group_code_list.Substring(1);
            if (group_id_list.Length > 0) group_id_list = group_id_list.Substring(1);

            SYS_tblGroupUserDRO result = new SYS_tblGroupUserDRO();
            result.ResponseItem.Message = "ready";
            if (!string.IsNullOrEmpty(group_id_list))
            {
                try
                {
                    if (group_id_list.Contains("$"))
                    {
                        if (CommonEngine.ShowConfirmMessageAlert(LanguageEngine.GetMessageCaption("000012", ConfigEngine.Language).Replace("$Count$", group_id_list.Split('$').Length.ToString())))
                            result = await SYS_tblGroupUserBUS.DeleteGroupUser(group_id_list, group_code_list, CommonEngine.userInfo.UserID, ConfigEngine.Language, new SYS_tblActionLogDTO
                            {
                                Activity = BaseConstant.COMMAND_INSERT_EN,
                                UserID = CommonEngine.userInfo.UserID,
                                LanguageID = ConfigEngine.Language,
                                ActionEN = BaseConstant.COMMAND_DELETE_LIST_EN,
                                ActionVN = BaseConstant.COMMAND_DELETE_LIST_VI,
                                FunctionID = "9",
                                DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công nhóm người dùng có mã '{1}'.", CommonEngine.userInfo.UserID, group_code_list.Replace("$", ", ")),
                                DescriptionEN = string.Format("Account '{0}' has deleted group user successfully with group code are '{1}'.", CommonEngine.userInfo.UserID, group_code_list.Replace("$", ", "))
                            });
                    }
                    else
                    {
                        if (CommonEngine.ShowConfirmMessageAlert(LanguageEngine.GetMessageCaption("000005", ConfigEngine.Language)))
                            result = await SYS_tblGroupUserBUS.DeleteGroupUser(group_id_list, group_code_list, CommonEngine.userInfo.UserID, ConfigEngine.Language, new SYS_tblActionLogDTO
                            {
                                Activity = BaseConstant.COMMAND_DELETE_EN,
                                UserID = CommonEngine.userInfo.UserID,
                                LanguageID = ConfigEngine.Language,
                                ActionEN = BaseConstant.COMMAND_DELETE_EN,
                                ActionVN = BaseConstant.COMMAND_DELETE_VI,
                                FunctionID = "9",
                                DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công nhóm người dùng có mã '{1}'.", CommonEngine.userInfo.UserID, group_code_list),
                                DescriptionEN = string.Format("Account '{0}' has deleted group user successfully with group code is '{1}'.", CommonEngine.userInfo.UserID, group_code_list)
                            });
                    }

                    if (result.ResponseItem.IsError)
                    {
                        CommonEngine.ShowHTTPErrorMessage(result.ResponseItem);
                        return;
                    }
                    if (!result.ResponseItem.Message.Equals("ready"))
                        if (string.IsNullOrEmpty(result.ResponseItem.Message)) GetAllGroupUsers();
                        else CommonEngine.ShowMessage(result.ResponseItem.Message, 0);
                }
                catch (Exception ex)
                {
                    CommonEngine.ShowExceptionMessage(ex);
                }
            }
            else CommonEngine.ShowMessage("000027", IMC.Helper.MessageType.Warning, true);
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
                SYS_tblGroupUserDRO item = await SYS_tblGroupUserBUS.GetGroupUserItem(CommonEngine.userInfo.Username, ConfigEngine.Language, curItem[0].GroupID);
                if (item != null && item.GroupUserItem != null)
                    CommonEngine.OpenInputForm(new uc_GroupUserDetail(this, item.GroupUserItem), new Size(450, 290), true);
            }
        }

        private async void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await DeleteGroupUser();
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
            CommonEngine.QuickExportGridViewData(ConvertEngine.ConvertObjectListToDataTable<SYS_tblGroupUserDTO>(gridGroupUser.DataSource as List<SYS_tblGroupUserDTO>), grvGroupUser, "GroupUser");
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
        #endregion
    }
}