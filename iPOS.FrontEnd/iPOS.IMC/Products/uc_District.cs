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
    public partial class uc_District : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        private List<PRO_tblDistrictDTO> curItem = new List<PRO_tblDistrictDTO>();

        private string district_id_list = "", district_code_list = "";
        #endregion

        #region [Personal Methods]
        public void ChangeLanguage(string language)
        {
            LanguageEngine.ChangeCaptionBarLargeButtonItem(this.Name, language, new DevExpress.XtraBars.BarLargeButtonItem[] { btnInsert, btnUpdate, btnDelete, btnReload, btnPrint, btnImport, btnExport, btnClose });
            LanguageEngine.ChangeCaptionBarStaticItem(this.Name, language, new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreateTime, lblEditer, lblEditTime });
            LanguageEngine.ChangeCaptionGroupPanelTextGridView(this.Name, language, grvDistrict);
            LanguageEngine.ChangeCaptionGridColumn(this.Name, language, new DevExpress.XtraGrid.Columns.GridColumn[] { gcolProvinceName, gcolDistrictCode, gcolDistrictName, gcolRank, gcolActiveString, gcolNote });

            GetAllDistrict();
        }

        public async void GetAllDistrict()
        {
            try
            {
                gridDistrict.DataBindings.Clear();
                gridDistrict.DataSource = await PRO_tblDistrictBUS.GetAllDistricts(CommonEngine.userInfo.UserID, ConfigEngine.Language, false, "", new SYS_tblActionLogDTO
                {
                    Activity = BaseConstant.COMMAND_INSERT_EN,
                    UserID = CommonEngine.userInfo.UserID,
                    LanguageID = ConfigEngine.Language,
                    ActionEN = BaseConstant.COMMAND_LOAD_ALL_DATA_EN,
                    ActionVN = BaseConstant.COMMAND_LOAD_ALL_DATA_VI,
                    FunctionID = "12",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa tải thành công dữ liệu quận huyện.", CommonEngine.userInfo.UserID),
                    DescriptionEN = string.Format("Account '{0}' downloaded successfully data of districts.", CommonEngine.userInfo.UserID)
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
                curItem.Add((PRO_tblDistrictDTO)grvDistrict.GetFocusedRow());
                if (curItem != null)
                {
                    CommonEngine.ChangeDateTimeActionToCurrentData<PRO_tblDistrictDTO>(curItem, new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreaterValue, lblCreateTime, lblCreateTimeValue, lblEditer, lblEditerValue, lblEditTime, lblEditTimeValue });
                }
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
            }
        }

        private async Task DeleteDistrict()
        {
            string strErr = "ready";
            try
            {
                if (district_id_list.Contains("$"))
                {
                    if (CommonEngine.ShowConfirmMessageAlert(LanguageEngine.GetMessageCaption("000012", ConfigEngine.Language).Replace("$Count$", district_id_list.Split('$').Length.ToString())))
                        strErr = await PRO_tblDistrictBUS.DeleteDistrict(district_id_list, CommonEngine.userInfo.Username, ConfigEngine.Language, new SYS_tblActionLogDTO
                        {
                            Activity = BaseConstant.COMMAND_INSERT_EN,
                            UserID = CommonEngine.userInfo.UserID,
                            LanguageID = ConfigEngine.Language,
                            ActionVN = BaseConstant.COMMAND_DELETE_VI,
                            ActionEN = BaseConstant.COMMAND_DELETE_EN,
                            FunctionID = "12",
                            DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công những quận huyện có mã '{1}'.", CommonEngine.userInfo.UserID, district_code_list.Replace("$", ", ")),
                            DescriptionEN = string.Format("Account '{0}' has deleted districts successfully with district codes are '{1}'.", CommonEngine.userInfo.UserID, district_code_list.Replace("$", ", "))
                        });
                }
                else
                {
                    if (CommonEngine.ShowConfirmMessageAlert(LanguageEngine.GetMessageCaption("000005", ConfigEngine.Language)))
                        strErr = await PRO_tblDistrictBUS.DeleteDistrict(district_id_list, CommonEngine.userInfo.Username, ConfigEngine.Language, new SYS_tblActionLogDTO
                        {
                            Activity = BaseConstant.COMMAND_INSERT_EN,
                            UserID = CommonEngine.userInfo.UserID,
                            LanguageID = ConfigEngine.Language,
                            ActionVN = BaseConstant.COMMAND_DELETE_VI,
                            ActionEN = BaseConstant.COMMAND_DELETE_EN,
                            FunctionID = "12",
                            DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công quận huyện có mã '{1}'.", CommonEngine.userInfo.UserID, district_code_list),
                            DescriptionEN = string.Format("Account '{0}' has deleted district successfully with district code is '{1}'.", CommonEngine.userInfo.UserID, district_code_list)
                        });
                }

                if (!strErr.Equals("ready"))
                    if (string.IsNullOrEmpty(strErr)) GetAllDistrict();
                    else CommonEngine.ShowMessage(strErr, 0);
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
            }
        }
        #endregion

        #region [Form Events]
        public uc_District()
        {
            InitializeComponent();
        }

        public uc_District(string language)
        {
            InitializeComponent();
            ChangeLanguage(language);
        }

        private void btnInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonEngine.OpenInputForm(new uc_DistrictDetail(this), new Size(435, 270), false);
        }

        private async void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (curItem.Count > 0)
            {
                PRO_tblDistrictDTO item = await PRO_tblDistrictBUS.GetDistrictItem(CommonEngine.userInfo.UserID, ConfigEngine.Language, curItem[0].DistrictID);
                if (item != null)
                    CommonEngine.OpenInputForm(new uc_DistrictDetail(this, item), new Size(435, 270), true);
            }
        }

        private async void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await DeleteDistrict();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetAllDistrict();
        }

        private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonEngine.OpenImportExcelForm("PRO_District_FileSelect.xlsx", "PRO_spfrmDistrictImport", "PRO", "12");
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonEngine.QuickExportGridViewData(ConvertEngine.ConvertObjectListToDataTable<PRO_tblDistrictDTO>(gridDistrict.DataSource as List<PRO_tblDistrictDTO>), grvDistrict);
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ParentForm.Close();
        }

        private void uc_District_Load(object sender, EventArgs e)
        {
            GetAllDistrict();
        }

        private void grvDistrict_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = e.RowHandle + 1 + "";
        }

        private void grvDistrict_DoubleClick(object sender, EventArgs e)
        {
            btnUpdate_ItemClick(null, null);
        }

        private void grvDistrict_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetCurrentRow();
        }

        private void grvDistrict_FocusedRowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {
            GetCurrentRow();
        }

        private void grvDistrict_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            district_code_list = "";
            district_id_list = "";

            foreach (int index in grvDistrict.GetSelectedRows())
            {
                district_code_list = string.Join("$", district_code_list, grvDistrict.GetRowCellDisplayText(index, gcolDistrictCode));
                district_id_list = string.Join("$", district_id_list, grvDistrict.GetRowCellDisplayText(index, gcolDistrictID));
            }

            if (district_code_list.Length > 0) district_code_list = district_code_list.Substring(1);
            if (district_id_list.Length > 0) district_id_list = district_id_list.Substring(1);
        }
        #endregion
    }
}
