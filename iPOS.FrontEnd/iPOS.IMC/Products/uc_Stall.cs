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
    public partial class uc_Stall : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        private List<PRO_tblStallDTO> curItem = new List<PRO_tblStallDTO>();

        private string stall_id_list = "", stall_code_list = "";
        #endregion

        #region [Personal Methods]
        public void ChangeLanguage(string language)
        {
            LanguageEngine.ChangeCaptionBarLargeButtonItem(this.Name, language, new DevExpress.XtraBars.BarLargeButtonItem[] { btnInsert, btnUpdate, btnDelete, btnReload, btnPrint, btnImport, btnExport, btnClose });
            LanguageEngine.ChangeCaptionBarStaticItem(this.Name, language, new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreateTime, lblEditer, lblEditTime });
            LanguageEngine.ChangeCaptionGridView(this.Name, language, grvStall);
        }

        public async void GetAllStall(string store_id, string warehouse_id)
        {
            try
            {
                gridStall.DataBindings.Clear();
                List<PRO_tblStallDTO> stalls = await PRO_tblStallBUS.GetAllStall(CommonEngine.userInfo.UserID, ConfigEngine.Language, false, store_id, warehouse_id, new SYS_tblActionLogDTO
                {
                    Activity = BaseConstant.COMMAND_INSERT_EN,
                    UserID = CommonEngine.userInfo.UserID,
                    LanguageID = ConfigEngine.Language,
                    ActionEN = BaseConstant.COMMAND_LOAD_ALL_DATA_EN,
                    ActionVN = BaseConstant.COMMAND_LOAD_ALL_DATA_VI,
                    FunctionID = "19",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa tải thành công dữ liệu quầy bán.", CommonEngine.userInfo.UserID),
                    DescriptionEN = string.Format("Account '{0}' downloaded successfully data of stalls.", CommonEngine.userInfo.UserID)
                });
                gridStall.DataSource = stalls;
                barFooter.Visible = (stalls.Count > 0) ? true : false;
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
                curItem.Add((PRO_tblStallDTO)grvStall.GetFocusedRow());
                if (curItem != null)
                {
                    CommonEngine.ChangeDateTimeActionToCurrentData<PRO_tblStallDTO>(curItem, new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreaterValue, lblCreateTime, lblCreateTimeValue, lblEditer, lblEditerValue, lblEditTime, lblEditTimeValue });
                }
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
            }
        }

        private async Task DeleteStall()
        {
            string strErr = "ready";
            try
            {
                if (stall_id_list.Contains("$"))
                {
                    if (CommonEngine.ShowConfirmMessageAlert(LanguageEngine.GetMessageCaption("000012", ConfigEngine.Language).Replace("$Count$", stall_id_list.Split('$').Length.ToString())))
                        strErr = await PRO_tblStallBUS.DeleteStall(stall_id_list, CommonEngine.userInfo.Username, ConfigEngine.Language, new SYS_tblActionLogDTO
                        {
                            Activity = BaseConstant.COMMAND_INSERT_EN,
                            UserID = CommonEngine.userInfo.UserID,
                            LanguageID = ConfigEngine.Language,
                            ActionVN = BaseConstant.COMMAND_DELETE_VI,
                            ActionEN = BaseConstant.COMMAND_DELETE_EN,
                            FunctionID = "19",
                            DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công những quầy bán có mã '{1}'.", CommonEngine.userInfo.UserID, stall_code_list.Replace("$", ", ")),
                            DescriptionEN = string.Format("Account '{0}' has deleted stalls successfully with stall codes are '{1}'.", CommonEngine.userInfo.UserID, stall_code_list.Replace("$", ", "))
                        });
                }
                else
                {
                    if (CommonEngine.ShowConfirmMessageAlert(LanguageEngine.GetMessageCaption("000005", ConfigEngine.Language)))
                        strErr = await PRO_tblStallBUS.DeleteStall(stall_id_list, CommonEngine.userInfo.Username, ConfigEngine.Language, new SYS_tblActionLogDTO
                        {
                            Activity = BaseConstant.COMMAND_INSERT_EN,
                            UserID = CommonEngine.userInfo.UserID,
                            LanguageID = ConfigEngine.Language,
                            ActionVN = BaseConstant.COMMAND_DELETE_VI,
                            ActionEN = BaseConstant.COMMAND_DELETE_EN,
                            FunctionID = "19",
                            DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công quầy bán có mã '{1}'.", CommonEngine.userInfo.UserID, stall_code_list),
                            DescriptionEN = string.Format("Account '{0}' has deleted stall successfully with stall code is '{1}'.", CommonEngine.userInfo.UserID, stall_code_list)
                        });
                }

                if (!strErr.Equals("ready"))
                    if (string.IsNullOrEmpty(strErr)) GetAllStall("", "");
                    else CommonEngine.ShowMessage(strErr, 0);
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
            }
        }
        #endregion

        public uc_Stall()
        {
            InitializeComponent();
        }

        public uc_Stall(string language)
        {
            InitializeComponent();
            ChangeLanguage(language);
        }

        private void btnInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonEngine.OpenInputForm(new uc_StallDetail(this), new Size(395, 300), false);
        }

        private async void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (curItem.Count > 0)
            {
                PRO_tblStallDTO item = await PRO_tblStallBUS.GetStallItem(CommonEngine.userInfo.UserID, ConfigEngine.Language, curItem[0].StallID);
                if (item != null)
                    CommonEngine.OpenInputForm(new uc_StallDetail(this, item), new Size(395, 300), true);
            }
        }

        private async void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await DeleteStall();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetAllStall("", "");
        }

        private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonEngine.OpenImportExcelForm("PRO_Stall_FileSelect.xlsx", "PRO_spfrmStallImport", "PRO", "19");
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonEngine.QuickExportGridViewData(ConvertEngine.ConvertObjectListToDataTable<PRO_tblStallDTO>(gridStall.DataSource as List<PRO_tblStallDTO>), grvStall);
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ParentForm.Close();
        }

        private void uc_Stall_Load(object sender, EventArgs e)
        {
            GetAllStall("", "");
        }

        private void grvStall_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = e.RowHandle + 1 + "";
        }

        private void grvStall_DoubleClick(object sender, EventArgs e)
        {
            btnUpdate_ItemClick(null, null);
        }

        private void grvStall_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetCurrentRow();
        }

        private void grvStall_FocusedRowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {
            GetCurrentRow();
        }

        private void grvStall_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            stall_code_list = "";
            stall_id_list = "";
            foreach (int index in grvStall.GetSelectedRows())
            {
                stall_code_list = string.Join("$", stall_code_list, grvStall.GetRowCellDisplayText(index, gcolStallCode));
                stall_id_list = string.Join("$", stall_id_list, grvStall.GetRowCellDisplayText(index, gcolStallID));
            }

            if (stall_code_list.Length > 0) stall_code_list = stall_code_list.Substring(1);
            if (stall_id_list.Length > 0) stall_id_list = stall_id_list.Substring(1);
        }
    }
}
