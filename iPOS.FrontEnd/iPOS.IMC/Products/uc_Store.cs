﻿using System;
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
using iPOS.DRO.Products;

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
            LanguageEngine.ChangeCaptionBarLargeButtonItem(this.Name, language, new DevExpress.XtraBars.BarLargeButtonItem[] { btnInsert, btnDuplicated, btnUpdate, btnDelete, btnPrint, btnReload, btnImport, btnExport, btnClose });
            LanguageEngine.ChangeCaptionBarStaticItem(this.Name, language, new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreateTime, lblEditer, lblEditTime });
            LanguageEngine.ChangeCaptionGridView(this.Name, language, grvStore);
        }

        public async void GetAllStore()
        {
            try
            {
                gridStore.DataBindings.Clear();
                PRO_tblStoreDRO stores = await PRO_tblStoreBUS.GetAllStores(CommonEngine.userInfo.UserID, ConfigEngine.Language, false, new SYS_tblActionLogDTO
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
                if (!CommonEngine.CheckValidResponseItem(stores.ResponseItem)) return;
                gridStore.DataSource = stores.StoreList != null ? stores.StoreList : null;
                barFooter.Visible = (stores.StoreList != null && stores.StoreList.Count > 0) ? true : false;
                CommonEngine.LoadUserPermission("13", btnDelete, btnPrint, btnImport, btnExport);
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
            store_code_list = "";
            store_id_list = "";

            foreach (int index in grvStore.GetSelectedRows())
            {
                store_code_list = string.Join("$", store_code_list, grvStore.GetRowCellDisplayText(index, gcolStoreCode));
                store_id_list = string.Join("$", store_id_list, grvStore.GetRowCellDisplayText(index, gcolStoreID));
            }

            if (store_code_list.Length > 0) store_code_list = store_code_list.Substring(1);
            if (store_id_list.Length > 0) store_id_list = store_id_list.Substring(1);

            PRO_tblStoreDRO result = new PRO_tblStoreDRO();
            result.ResponseItem.Message = "ready";
            if (!string.IsNullOrEmpty(store_id_list))
            {
                try
                {
                    if (store_id_list.Contains("$"))
                    {
                        if (CommonEngine.ShowConfirmMessageAlert(LanguageEngine.GetMessageCaption("000012", ConfigEngine.Language).Replace("$Count$", store_id_list.Split('$').Length.ToString())))
                        {
                            CommonEngine.ShowWaitForm(this);
                            result = await PRO_tblStoreBUS.DeleteStore(CommonEngine.userInfo.Username, ConfigEngine.Language, store_id_list, new SYS_tblActionLogDTO
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
                    }
                    else
                    {
                        if (CommonEngine.ShowConfirmMessageAlert(LanguageEngine.GetMessageCaption("000005", ConfigEngine.Language)))
                        {
                            CommonEngine.ShowWaitForm(this);
                            result = await PRO_tblStoreBUS.DeleteStore(CommonEngine.userInfo.Username, ConfigEngine.Language, store_id_list, new SYS_tblActionLogDTO
                            {
                                Activity = BaseConstant.COMMAND_INSERT_EN,
                                UserID = CommonEngine.userInfo.UserID,
                                LanguageID = ConfigEngine.Language,
                                ActionVN = BaseConstant.COMMAND_DELETE_VI,
                                ActionEN = BaseConstant.COMMAND_DELETE_EN,
                                FunctionID = "13",
                                DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công cửa hàng có mã '{1}'.", CommonEngine.userInfo.UserID, store_code_list),
                                DescriptionEN = string.Format("Account '{0}' has deleted store successfully with store code is '{1}'.", CommonEngine.userInfo.UserID, store_code_list)
                            });
                        }
                    }

                    if (result.ResponseItem.IsError)
                    {
                        CommonEngine.ShowHTTPErrorMessage(result.ResponseItem);
                        return;
                    }
                    if (!result.ResponseItem.Message.Equals("ready"))
                        if (string.IsNullOrEmpty(result.ResponseItem.Message)) GetAllStore();
                        else CommonEngine.ShowMessage(result.ResponseItem.Message, 0);
                }
                catch (Exception ex)
                {
                    CommonEngine.ShowExceptionMessage(ex);
                }
            } else CommonEngine.ShowMessage("000027", IMC.Helper.MessageType.Warning, true);
        }
        #endregion

        #region [Form Events]
        public uc_Store()
        {
            InitializeComponent();
        }

        public uc_Store(string language)
        {
            CommonEngine.ShowWaitForm(this);
            InitializeComponent();
            ChangeLanguage(language);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CommonEngine.CloseWaitForm();
        }

        private void btnInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonEngine.OpenInputForm(new uc_StoreDetail(this), new Size(660, 400), false);
        }

        private async void btnDuplicated_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (curItem.Count > 0)
            {
                PRO_tblStoreDRO item = await PRO_tblStoreBUS.GetStoreItem(CommonEngine.userInfo.UserID, ConfigEngine.Language, curItem[0].StoreID);
                if (!CommonEngine.CheckValidResponseItem(item.ResponseItem)) return;

                if (item != null && item.StoreItem != null)
                {
                    item.StoreItem.StoreID = "";
                    CommonEngine.OpenInputForm(new uc_StoreDetail(this, item.StoreItem), new Size(660, 400), false);
                }
            }
        }

        private async void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (curItem.Count > 0)
            {
                PRO_tblStoreDRO item = await PRO_tblStoreBUS.GetStoreItem(CommonEngine.userInfo.UserID, ConfigEngine.Language, curItem[0].StoreID);
                if (!CommonEngine.CheckValidResponseItem(item.ResponseItem)) return;

                if (item != null && item.StoreItem != null)
                    CommonEngine.OpenInputForm(new uc_StoreDetail(this, item.StoreItem), new Size(660, 400), true);
            }
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
            CommonEngine.ShowWaitForm(this);
            GetAllStore();
            CommonEngine.CloseWaitForm();
        }

        private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonEngine.OpenImportExcelForm("PRO_Store_FileSelect.xlsx", "PRO_spfrmStoreImport", "PRO", "13");
            btnReload_ItemClick(null, null);
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonEngine.QuickExportGridViewData(ConvertEngine.ConvertObjectListToDataTable<PRO_tblStoreDTO>(gridStore.DataSource as List<PRO_tblStoreDTO>), grvStore, "Store");
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
        #endregion
    }
}
