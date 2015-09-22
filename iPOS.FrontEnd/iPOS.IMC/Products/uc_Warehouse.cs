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

namespace iPOS.IMC.Products
{
    public partial class uc_Warehouse : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        private List<PRO_tblWarehouseDTO> curItem = new List<PRO_tblWarehouseDTO>();

        private string warehouse_id_list = "", warehouse_code_list = "";
        #endregion

        #region [Personal Methods]
        public void ChangeLanguage(string language)
        {
            LanguageEngine.ChangeCaptionBarLargeButtonItem(this.Name, language, new DevExpress.XtraBars.BarLargeButtonItem[] { btnInsert, btnUpdate, btnDelete, btnReload, btnPrint, btnImport, btnExport, btnClose });
            LanguageEngine.ChangeCaptionBarStaticItem(this.Name, language, new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreateTime, lblEditer, lblEditTime });
            LanguageEngine.ChangeCaptionGridView(this.Name, language, grvWarehouse);
            GetAllWarehouse("");
        }

        public async void GetAllWarehouse(string store_id)
        {
            try
            {
                gridWarehouse.DataBindings.Clear();
                List<PRO_tblWarehouseDTO> warehouses = await PRO_tblWarehouseBUS.GetAllWarehouses(CommonEngine.userInfo.UserID, ConfigEngine.Language, false, store_id, "", "", new SYS_tblActionLogDTO
                {
                    Activity = BaseConstant.COMMAND_INSERT_EN,
                    UserID = CommonEngine.userInfo.UserID,
                    LanguageID = ConfigEngine.Language,
                    ActionEN = BaseConstant.COMMAND_LOAD_ALL_DATA_EN,
                    ActionVN = BaseConstant.COMMAND_LOAD_ALL_DATA_VI,
                    FunctionID = "18",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa tải thành công dữ liệu kho hàng.", CommonEngine.userInfo.UserID),
                    DescriptionEN = string.Format("Account '{0}' downloaded successfully data of warehouses.", CommonEngine.userInfo.UserID)
                });
                gridWarehouse.DataSource = warehouses;
                barFooter.Visible = (warehouses.Count > 0) ? true : false;
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
                curItem.Add((PRO_tblWarehouseDTO)grvWarehouse.GetFocusedRow());
                if (curItem != null)
                {
                    CommonEngine.ChangeDateTimeActionToCurrentData<PRO_tblWarehouseDTO>(curItem, new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreaterValue, lblCreateTime, lblCreateTimeValue, lblEditer, lblEditerValue, lblEditTime, lblEditTimeValue });
                }
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
            }
        }

        private async Task DeleteWarehouse()
        {
            string strErr = "ready";
            try
            {
                if (warehouse_id_list.Contains("$"))
                {
                    if (CommonEngine.ShowConfirmMessageAlert(LanguageEngine.GetMessageCaption("000012", ConfigEngine.Language).Replace("$Count$", warehouse_id_list.Split('$').Length.ToString())))
                        strErr = await PRO_tblWarehouseBUS.DeleteWarehouse(warehouse_id_list, CommonEngine.userInfo.Username, ConfigEngine.Language, new SYS_tblActionLogDTO
                        {
                            Activity = BaseConstant.COMMAND_INSERT_EN,
                            UserID = CommonEngine.userInfo.UserID,
                            LanguageID = ConfigEngine.Language,
                            ActionVN = BaseConstant.COMMAND_DELETE_VI,
                            ActionEN = BaseConstant.COMMAND_DELETE_EN,
                            FunctionID = "18",
                            DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công những kho hàng có mã '{1}'.", CommonEngine.userInfo.UserID, warehouse_code_list.Replace("$", ", ")),
                            DescriptionEN = string.Format("Account '{0}' has deleted warehouses successfully with warehouse codes are '{1}'.", CommonEngine.userInfo.UserID, warehouse_code_list.Replace("$", ", "))
                        });
                }
                else
                {
                    if (CommonEngine.ShowConfirmMessageAlert(LanguageEngine.GetMessageCaption("000005", ConfigEngine.Language)))
                        strErr = await PRO_tblWarehouseBUS.DeleteWarehouse(warehouse_id_list, CommonEngine.userInfo.Username, ConfigEngine.Language, new SYS_tblActionLogDTO
                        {
                            Activity = BaseConstant.COMMAND_INSERT_EN,
                            UserID = CommonEngine.userInfo.UserID,
                            LanguageID = ConfigEngine.Language,
                            ActionVN = BaseConstant.COMMAND_DELETE_VI,
                            ActionEN = BaseConstant.COMMAND_DELETE_EN,
                            FunctionID = "18",
                            DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công kho hàng có mã '{1}'.", CommonEngine.userInfo.UserID, warehouse_code_list),
                            DescriptionEN = string.Format("Account '{0}' has deleted warehouse successfully with warehouse code is '{1}'.", CommonEngine.userInfo.UserID, warehouse_code_list)
                        });
                }

                if (!strErr.Equals("ready"))
                    if (string.IsNullOrEmpty(strErr)) GetAllWarehouse("");
                    else CommonEngine.ShowMessage(strErr, 0);
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
            }
        }
        #endregion

        public uc_Warehouse()
        {
            InitializeComponent();
        }

        public uc_Warehouse(string language)
        {
            InitializeComponent();
            ChangeLanguage(language);
        }

        private void btnInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonEngine.OpenInputForm(new uc_WarehouseDetail(this), new Size(410, 400), false);
        }

        private async void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (curItem.Count > 0)
            {
                PRO_tblWarehouseDTO item = await PRO_tblWarehouseBUS.GetWarehouseItem(CommonEngine.userInfo.UserID, ConfigEngine.Language, curItem[0].WarehouseID);
                if (item != null)
                    CommonEngine.OpenInputForm(new uc_WarehouseDetail(this, item), new Size(410, 400), true);
            }
        }

        private async void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await DeleteWarehouse();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetAllWarehouse("");
        }

        private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonEngine.OpenImportExcelForm("PRO_Warehouse_FileSelect.xlsx", "PRO_spfrmWarehouseImport", "PRO", "18");
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonEngine.QuickExportGridViewData(ConvertEngine.ConvertObjectListToDataTable<PRO_tblWarehouseDTO>(gridWarehouse.DataSource as List<PRO_tblWarehouseDTO>), grvWarehouse);
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ParentForm.Close();
        }

        private void uc_Warehouse_Load(object sender, EventArgs e)
        {
            GetAllWarehouse("");
        }

        private void grvWarehouse_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = e.RowHandle + 1 + "";
        }

        private void grvWarehouse_DoubleClick(object sender, EventArgs e)
        {
            btnUpdate_ItemClick(null, null);
        }

        private void grvWarehouse_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetCurrentRow();
        }

        private void grvWarehouse_FocusedRowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {
            GetCurrentRow();
        }

        private void grvWarehouse_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            warehouse_code_list = "";
            warehouse_id_list = "";
            foreach (int index in grvWarehouse.GetSelectedRows())
            {
                warehouse_code_list = string.Join("$", warehouse_code_list, grvWarehouse.GetRowCellDisplayText(index, gcolWarehouseCode));
                warehouse_id_list = string.Join("$", warehouse_id_list, grvWarehouse.GetRowCellDisplayText(index, gcolWarehouseID));
            }

            if (warehouse_code_list.Length > 0) warehouse_code_list = warehouse_code_list.Substring(1);
            if (warehouse_id_list.Length > 0) warehouse_id_list = warehouse_id_list.Substring(1);
        }
    }
}
