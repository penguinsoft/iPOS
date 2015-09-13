using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iPOS.DTO.Products;
using iPOS.IMC.Helper;
using iPOS.BUS.Products;
using iPOS.Core.Helper;
using iPOS.DTO.Systems;
using System.Threading.Tasks;

namespace iPOS.IMC.Products
{
    public partial class uc_Store : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        private List<PRO_tblStoreDTO> curItem = new List<PRO_tblStoreDTO>();

        private string store_id_list = "", store_code_list = "";
        #endregion

        #region [Personal Methods]
        public void ChangeLanguage(string language)
        {
            LanguageEngine.ChangeCaptionBarLargeButtonItem(this.Name, language, new DevExpress.XtraBars.BarLargeButtonItem[] { btnInsert, btnUpdate, btnDelete, btnPrint, btnReload, btnImport, btnExport, btnClose });
            LanguageEngine.ChangeCaptionBarStaticItem(this.Name, language, new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreateTime, lblEditer, lblEditTime });
            LanguageEngine.ChangeCaptionGroupPanelTextGridView(this.Name, language, grvStore);
            LanguageEngine.ChangeCaptionGridColumn(this.Name, language, new DevExpress.XtraGrid.Columns.GridColumn[] { gcolStoreCode, gcolShortCode, gcolStoreName, gcolStoreAddress, gcolBuildDate, gcolFax, gcolIsRootString, gcolNote, gcolPhone, gcolRank, gcolProvinceName, gcolRepresentatives, gcolTaxCode, gcolUsedString, gcolDistrictName });
        }

        public async void GetAllStore()
        {
            try
            {
                gridStore.DataBindings.Clear();
                gridStore.DataSource = await PRO_tblStoreBUS.GetAllStores(CommonEngine.userInfo.UserID, ConfigEngine.Language, false, new SYS_tblActionLogDTO
                {
                    Activity = BaseConstant.COMMAND_INSERT_EN,
                    UserID = CommonEngine.userInfo.UserID,
                    LanguageID = ConfigEngine.Language,
                    ActionEN = BaseConstant.COMMAND_LOAD_ALL_DATA_EN,
                    ActionVN = BaseConstant.COMMAND_LOAD_ALL_DATA_VI,
                    FunctionID = "13",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa tải thành công dữ liệu cửa hàng.", CommonEngine.userInfo.UserID),
                    DescriptionEN = string.Format("Account '{0}' downloaded successfully data of stores.", CommonEngine.userInfo.UserID)
                });
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
                curItem.Add((PRO_tblStoreDTO)grvStore.GetFocusedRow());
                if (curItem != null)
                {
                    CommonEngine.ChangeDateTimeActionToCurrentData<PRO_tblStoreDTO>(curItem, new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreaterValue, lblCreateTime, lblCreateTimeValue, lblEditer, lblEditerValue, lblEditTime, lblEditTimeValue });
                }
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
            }
        }

        private async Task DeleteStore()
        {
            string strErr = "ready";
            try
            {
                if (store_id_list.Contains("$"))
                {
                    if (CommonEngine.ShowConfirmMessageAlert(LanguageEngine.GetMessageCaption("000012", ConfigEngine.Language).Replace("$Count$", store_id_list.Split('$').Length.ToString())))
                        strErr = await PRO_tblStoreBUS.DeleteStore(store_id_list, CommonEngine.userInfo.Username, ConfigEngine.Language, new SYS_tblActionLogDTO
                        {
                            Activity = BaseConstant.COMMAND_INSERT_EN,
                            UserID = CommonEngine.userInfo.UserID,
                            LanguageID = ConfigEngine.Language,
                            ActionVN = BaseConstant.COMMAND_DELETE_VI,
                            ActionEN = BaseConstant.COMMAND_DELETE_EN,
                            FunctionID = "13",
                            DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công những cửa hàng có mã '{1}'.", CommonEngine.userInfo.UserID, store_code_list.Replace("$", ", ")),
                            DescriptionEN = string.Format("Account '{0}' has deleted stores successfully with store codes are '{1}'.", CommonEngine.userInfo.UserID, store_code_list.Replace("$", ", "))
                        });
                }
                else
                {
                    if (CommonEngine.ShowConfirmMessageAlert(LanguageEngine.GetMessageCaption("000005", ConfigEngine.Language)))
                        strErr = await PRO_tblDistrictBUS.DeleteDistrict(store_id_list, CommonEngine.userInfo.Username, ConfigEngine.Language, new SYS_tblActionLogDTO
                        {
                            Activity = BaseConstant.COMMAND_INSERT_EN,
                            UserID = CommonEngine.userInfo.UserID,
                            LanguageID = ConfigEngine.Language,
                            ActionVN = BaseConstant.COMMAND_DELETE_VI,
                            ActionEN = BaseConstant.COMMAND_DELETE_EN,
                            FunctionID = "12",
                            DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công cửa hàng có mã '{1}'.", CommonEngine.userInfo.UserID, store_code_list),
                            DescriptionEN = string.Format("Account '{0}' has deleted store successfully with store code is '{1}'.", CommonEngine.userInfo.UserID, store_code_list)
                        });
                }

                if (!strErr.Equals("ready"))
                    if (string.IsNullOrEmpty(strErr)) GetAllStore();
                    else CommonEngine.ShowMessage(strErr, 0);
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
            }
        }
        #endregion

        public uc_Store()
        {
            InitializeComponent();
        }

        public uc_Store(string language)
        {
            InitializeComponent();
            ChangeLanguage(language);
        }

        private void btnInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private async void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await DeleteStore();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetAllStore();
        }

        private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonEngine.QuickExportGridViewData(ConvertEngine.ConvertObjectListToDataTable<PRO_tblStoreDTO>(gridStore.DataSource as List<PRO_tblStoreDTO>), grvStore);
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ParentForm.Close();
        }

        private void uc_Store_Load(object sender, EventArgs e)
        {
            GetAllStore();
        }

        private void grvStore_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = e.RowHandle + 1 + "";
        }

        private void grvStore_DoubleClick(object sender, EventArgs e)
        {
            btnUpdate_ItemClick(null, null);
        }

        private void grvStore_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetCurrentRow();
        }

        private void grvStore_FocusedRowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {
            GetCurrentRow();
        }

        private void grvStore_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

        }
    }
}
