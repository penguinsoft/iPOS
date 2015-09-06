using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iPOS.IMC.Helper;
using System.Threading.Tasks;
using iPOS.BUS.Products;
using iPOS.DTO.Systems;
using iPOS.Core.Helper;
using iPOS.DTO.Products;

namespace iPOS.IMC.Products
{
    public partial class uc_Province : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        private List<PRO_tblProvinceDTO> curItem = new List<PRO_tblProvinceDTO>();

        private string province_code_list= "", province_id_list = "";
        #endregion

        #region [Personal Methods]
        public void ChangeLanguage(string language)
        {
            LanguageEngine.ChangeCaptionBarLargeButtonItem(this.Name, language, new DevExpress.XtraBars.BarLargeButtonItem[] { btnInsert, btnUpdate, btnDelete, btnPrint, btnReload, btnImport, btnExport, btnClose });
            LanguageEngine.ChangeCaptionBarStaticItem(this.Name, language, new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreateTime, lblEditer, lblEditTime });
            LanguageEngine.ChangeCaptionGroupPanelTextGridView(this.Name, language, grvProvince);
            LanguageEngine.ChangeCaptionGridColumn(this.Name, language, new DevExpress.XtraGrid.Columns.GridColumn[] { gcolProvinceCode, gcolProvinceName, gcolRank, gcolActiveString, gcolNote });

            GetAllProvinces();
        }

        public async void GetAllProvinces()
        {
            try
            {
                gridProvince.DataBindings.Clear();
                List<PRO_tblProvinceDTO> list = await PRO_tblProvinceBUS.GetAllProvinces(CommonEngine.userInfo.UserID, CommonEngine.userInfo.LanguageID, false, new SYS_tblActionLogDTO
                {
                    Activity = BaseConstant.COMMAND_INSERT_EN,
                    UserID = CommonEngine.userInfo.UserID,
                    LanguageID = ConfigEngine.Language,
                    ActionEN = BaseConstant.COMMAND_LOAD_ALL_DATA_EN,
                    ActionVN = BaseConstant.COMMAND_LOAD_ALL_DATA_VI,
                    FunctionID = "8",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa tải thành công dữ liệu tỉnh thành.", CommonEngine.userInfo.UserID),
                    DescriptionEN = string.Format("Account '{0}' downloaded successfully data of provinces.", CommonEngine.userInfo.UserID)
                });
                gridProvince.DataSource = list;
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
                curItem.Add((PRO_tblProvinceDTO)grvProvince.GetFocusedRow());
                if (curItem != null)
                {
                    CommonEngine.ChangeDateTimeActionToCurrentData<PRO_tblProvinceDTO>(curItem, new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreaterValue, lblCreateTime, lblCreateTimeValue, lblEditer, lblEditerValue, lblEditTime, lblEditTimeValue });
                }
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
            }
        }

        private async void DeleteProvince()
        {
            string strErr = "ready";
            try
            {
                if (province_id_list.Contains("$"))
                {
                    if (CommonEngine.ShowConfirmMessageAlert(LanguageEngine.GetMessageCaption("000012", ConfigEngine.Language).Replace("$Count$", province_id_list.Split('$').Length.ToString())))
                        strErr = await PRO_tblProvinceBUS.DeleteProvince(province_id_list, CommonEngine.userInfo.Username, ConfigEngine.Language, new SYS_tblActionLogDTO
                        {
                            Activity = BaseConstant.COMMAND_INSERT_EN,
                            UserID = CommonEngine.userInfo.UserID,
                            LanguageID = ConfigEngine.Language,
                            ActionVN = BaseConstant.COMMAND_DELETE_VI,
                            ActionEN = BaseConstant.COMMAND_DELETE_EN,
                            FunctionID = "8",
                            DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công những tỉnh thành có mã '{1}'.", CommonEngine.userInfo.UserID, province_code_list.Replace("$", ", ")),
                            DescriptionEN = string.Format("Account '{0}' has deleted provinces successfully with province codes are '{1}'.", CommonEngine.userInfo.UserID, province_code_list.Replace("$", ", "))
                        });
                }
                else
                {
                    if (CommonEngine.ShowConfirmMessageAlert(LanguageEngine.GetMessageCaption("000005", ConfigEngine.Language)))
                        strErr = await PRO_tblProvinceBUS.DeleteProvince(province_id_list, CommonEngine.userInfo.Username, ConfigEngine.Language, new SYS_tblActionLogDTO
                        {
                            Activity = BaseConstant.COMMAND_INSERT_EN,
                            UserID = CommonEngine.userInfo.UserID,
                            LanguageID = ConfigEngine.Language,
                            ActionVN = BaseConstant.COMMAND_DELETE_VI,
                            ActionEN = BaseConstant.COMMAND_DELETE_EN,
                            FunctionID = "8",
                            DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công tỉnh thành có mã '{1}'.", CommonEngine.userInfo.UserID, province_code_list),
                            DescriptionEN = string.Format("Account '{0}' has deleted province successfully with province code is '{1}'.", CommonEngine.userInfo.UserID, province_code_list)
                        });
                }

                if (!strErr.Equals("ready"))
                    if (string.IsNullOrEmpty(strErr)) GetAllProvinces();
                    else CommonEngine.ShowMessage(strErr, 0);
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
            }
        }
        #endregion

        public uc_Province()
        {
            InitializeComponent();
        }

        public uc_Province(string language)
        {
            InitializeComponent();
            ChangeLanguage(language);
        }

        private void btnInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonEngine.OpenInputForm(new uc_ProvinceDetail(this), new Size(435, 265), false);
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

        private void uc_Province_Load(object sender, EventArgs e)
        {
            GetAllProvinces();
        }

        private void grvProvince_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = e.RowHandle + 1 + "";
        }

        private void grvProvince_DoubleClick(object sender, EventArgs e)
        {
            btnUpdate_ItemClick(null, null);
        }

        private void grvProvince_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetCurrentRow();
        }

        private void grvProvince_FocusedRowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {
            GetCurrentRow();
        }

        private void grvProvince_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            province_code_list = "";
            province_id_list = "";
            foreach (int index in grvProvince.GetSelectedRows())
            {
                province_code_list += grvProvince.GetRowCellDisplayText(index, gcolProvinceCode) + "$";
                province_id_list += grvProvince.GetRowCellDisplayText(index, gcolProvinceID) + "$";
            }

            if (province_code_list.Length > 0) province_code_list = province_code_list.Substring(0, province_code_list.Length - 1);
            if (province_id_list.Length > 0) province_id_list = province_id_list.Substring(0, province_id_list.Length - 1);
        }
    }
}
