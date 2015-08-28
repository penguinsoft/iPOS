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
                List<iPOS.DTO.Systems.SYS_tblUserDTO> list = new List<iPOS.DTO.Systems.SYS_tblUserDTO>();
                list = await SYS_tblUserBUS.GetAllUsers(CommonEngine.userInfo.UserName, CommonEngine.userInfo.LanguageID);
                gridUser.DataSource = list;
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

        private async void DeleteGroupUser()
        {
            string strErr = "ready";
            try
            {
                if (user_code_list.Contains("$"))
                {
                    if (CommonEngine.ShowConfirmMessageAlert(LanguageEngine.GetMessageCaption("000012", ConfigEngine.Language).Replace("$Count$", user_code_list.Split('$').Length.ToString())))
                        strErr = await SYS_tblUserBUS.DeleteUser(user_code_list, CommonEngine.userInfo.Username, ConfigEngine.Language);
                }
                else
                {
                    if (CommonEngine.ShowConfirmMessageAlert(LanguageEngine.GetMessageCaption("000005", ConfigEngine.Language)))
                        strErr = await SYS_tblUserBUS.DeleteUser(user_code_list, CommonEngine.userInfo.Username, ConfigEngine.Language);
                }

                if (!strErr.Equals("ready"))
                    if (string.IsNullOrEmpty(strErr)) GetAllUsers();
                    else CommonEngine.ShowMessage(strErr, 0);
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
            }
        }
        #endregion

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

        private void uc_User_Load(object sender, EventArgs e)
        {

        }

        private void grvUser_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {

        }

        private void grvUser_DoubleClick(object sender, EventArgs e)
        {

        }

        private void grvUser_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        private void grvUser_FocusedRowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {

        }

        private void grvUser_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

        }
    }
}