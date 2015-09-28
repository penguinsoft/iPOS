 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iPOS.DTO.Systems;
using iPOS.IMC.Helper;
using iPOS.BUS.Systems;
using iPOS.Core.Helper;
using System.Threading.Tasks;
using iPOS.DRO.Systems;

namespace iPOS.IMC.Systems
{
    public partial class uc_User : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        private List<SYS_tblUserDTO> curItem = new List<SYS_tblUserDTO>();

        private string user_code_list = "";
        #endregion

        #region [Personal Methods]
        public void ChangeLanguage(string language)
        {
            LanguageEngine.ChangeCaptionBarLargeButtonItem(this.Name, language, new DevExpress.XtraBars.BarLargeButtonItem[] { btnInsert, btnUpdate, btnDelete, btnPrint, btnReload, btnImport, btnExport, btnClose });
            LanguageEngine.ChangeCaptionBarStaticItem(this.Name, language, new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreateTime, lblEditer, lblEditTime });
            LanguageEngine.ChangeCaptionGroupPanelTextGridView(this.Name, language, grvUser);
            LanguageEngine.ChangeCaptionGridColumn(this.Name, language, new DevExpress.XtraGrid.Columns.GridColumn[] { gcolUsername, gcolGroupName, gcolFullName, gcolEmpCode, gcolEffectiveDate, gcolEmail, gcolNote });

            GetAllUsers();
        }

        public async void GetAllUsers()
        {
            try
            {
                gridUser.DataBindings.Clear();
                SYS_tblUserDRO users = new SYS_tblUserDRO();
                users = await SYS_tblUserBUS.GetAllUsers(CommonEngine.userInfo.UserID, CommonEngine.userInfo.LanguageID, new SYS_tblActionLogDTO
                {
                    Activity = BaseConstant.COMMAND_INSERT_EN,
                    UserID = CommonEngine.userInfo.UserID,
                    LanguageID = ConfigEngine.Language,
                    ActionEN = BaseConstant.COMMAND_LOAD_ALL_DATA_EN,
                    ActionVN = BaseConstant.COMMAND_LOAD_ALL_DATA_VI,
                    FunctionID = "10",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa tải thành công dữ liệu người dùng.", CommonEngine.userInfo.UserID),
                    DescriptionEN = string.Format("Account '{0}' downloaded successfully data of users.", CommonEngine.userInfo.UserID)
                });
                if (users.ResponseItem.IsError)
                {
                    CommonEngine.ShowHTTPErrorMessage(users.ResponseItem.ErrorCode, users.ResponseItem.ErrorMessage);
                    return;
                }
                else gridUser.DataSource = users.UserList;
                barBottom.Visible = (users != null && users.UserList.Count > 0) ? true : false;
                CommonEngine.LoadUserPermission("10", btnDelete, btnPrint, btnImport, btnExport);
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
                curItem.Add((SYS_tblUserDTO)grvUser.GetFocusedRow());
                if (curItem != null)
                {
                    CommonEngine.ChangeDateTimeActionToCurrentData<SYS_tblUserDTO>(curItem, new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreaterValue, lblCreateTime, lblCreateTimeValue, lblEditer, lblEditerValue, lblEditTime, lblEditTimeValue });
                }
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
            }
        }

        private async Task DeleteUser()
        {
            user_code_list = "";
            foreach (int index in grvUser.GetSelectedRows())
                user_code_list = string.Join("$", user_code_list, grvUser.GetRowCellDisplayText(index, gcolUsername));

            if (user_code_list.Length > 0) user_code_list = user_code_list.Substring(1);

            SYS_tblUserDRO result = new SYS_tblUserDRO();
            result.ResponseItem.Message = "ready";
            try
            {
                if (user_code_list.Contains("$"))
                {
                    if (CommonEngine.ShowConfirmMessageAlert(LanguageEngine.GetMessageCaption("000012", ConfigEngine.Language).Replace("$Count$", user_code_list.Split('$').Length.ToString())))
                        result = await SYS_tblUserBUS.DeleteUser(user_code_list, CommonEngine.userInfo.Username, ConfigEngine.Language, new SYS_tblActionLogDTO
                        {
                            Activity = BaseConstant.COMMAND_INSERT_EN,
                            UserID = CommonEngine.userInfo.UserID,
                            LanguageID = ConfigEngine.Language,
                            ActionVN = BaseConstant.COMMAND_DELETE_VI,
                            ActionEN = BaseConstant.COMMAND_DELETE_EN,
                            FunctionID = "10",
                            DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công người dùng có các tên tài khoản '{1}'.", CommonEngine.userInfo.UserID, user_code_list.Replace("$", ", ")),
                            DescriptionEN = string.Format("Account '{0}' has deleted user successfully with username are '{1}'.", CommonEngine.userInfo.UserID, user_code_list.Replace("$", ", "))
                        });
                }
                else
                {
                    if (CommonEngine.ShowConfirmMessageAlert(LanguageEngine.GetMessageCaption("000005", ConfigEngine.Language)))
                        result = await SYS_tblUserBUS.DeleteUser(user_code_list, CommonEngine.userInfo.Username, ConfigEngine.Language, new SYS_tblActionLogDTO
                        {
                            Activity = BaseConstant.COMMAND_INSERT_EN,
                            UserID = CommonEngine.userInfo.UserID,
                            LanguageID = ConfigEngine.Language,
                            ActionVN = BaseConstant.COMMAND_DELETE_VI,
                            ActionEN = BaseConstant.COMMAND_DELETE_EN,
                            FunctionID = "10",
                            DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công người dùng có tên tài khoản '{1}'.", CommonEngine.userInfo.UserID, user_code_list),
                            DescriptionEN = string.Format("Account '{0}' has deleted user successfully with username is '{1}'.", CommonEngine.userInfo.UserID, user_code_list)
                        });
                }

                if (result.ResponseItem.IsError)
                {
                    CommonEngine.ShowHTTPErrorMessage(result.ResponseItem.ErrorCode, result.ResponseItem.ErrorMessage);
                    return;
                }
                if (!result.ResponseItem.Message.Equals("ready"))
                    if (string.IsNullOrEmpty(result.ResponseItem.Message)) GetAllUsers();
                    else CommonEngine.ShowMessage(result.ResponseItem.Message, 0);
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
            }
        }
        #endregion

        #region [Form Events]
        public uc_User()
        {
            InitializeComponent();
        }

        public uc_User(string language)
        {
            InitializeComponent();
            ChangeLanguage(language);
        }

        private void btnInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonEngine.OpenInputForm(new uc_UserDetail(this), new Size(455, 460), false);
        }

        private async void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (curItem.Count > 0)
            {
                SYS_tblUserDRO item = await SYS_tblUserBUS.GetUserItem(CommonEngine.userInfo.UserID, ConfigEngine.Language, curItem[0].Username);
                if (item != null && item.UserItem != null)
                    CommonEngine.OpenInputForm(new uc_UserDetail(this, item.UserItem), new Size(455, 460), true);
            }
        }

        private async void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await DeleteUser();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetAllUsers();
        }

        private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonEngine.OpenImportExcelForm("SYS_User_FileSelect.xlsx", "SYS_spfrmUserImport", "SYS", "10");
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonEngine.QuickExportGridViewData(ConvertEngine.ConvertObjectListToDataTable<SYS_tblUserDTO>(gridUser.DataSource as List<SYS_tblUserDTO>), grvUser, "User");
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ParentForm.Close();
        }

        private void uc_User_Load(object sender, EventArgs e)
        {
            GetAllUsers();
        }

        private void grvUser_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0 && e.Info.IsRowIndicator)
                e.Info.DisplayText = e.RowHandle + 1 + "";
        }

        private void grvUser_DoubleClick(object sender, EventArgs e)
        {
            btnUpdate_ItemClick(null, null);
        }

        private void grvUser_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetCurrentRow();
        }

        private void grvUser_FocusedRowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {
            GetCurrentRow();
        }
        #endregion
    }
}