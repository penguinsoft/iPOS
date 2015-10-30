using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iPOS.DTO.Products;
using iPOS.IMC.Helper;
using iPOS.DRO.Products;
using iPOS.BUS.Products;
using iPOS.Core.Helper;
using iPOS.DTO.Systems;

namespace iPOS.IMC.Products
{
    public partial class uc_Level1 : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        private List<PRO_tblLevel1DTO> curItem = new List<PRO_tblLevel1DTO>();

        private string level1_id_list = "", level1_code_list = "";
        #endregion

        #region [Personal Methods]
        public void ChangeLanguage(string language)
        {
            LanguageEngine.ChangeCaptionBarLargeButtonItem(this.Name, language, new DevExpress.XtraBars.BarLargeButtonItem[] { btnInsert, btnUpdate, btnDelete, btnPrint, btnReload, btnImport, btnExport, btnClose });
            LanguageEngine.ChangeCaptionBarStaticItem(this.Name, language, new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreateTime, lblEditer, lblEditTime });
            LanguageEngine.ChangeCaptionGridView(this.Name, language, grvLevel1);
        }

        public async void GetAllLevel1()
        {
            try
            {
                gridLevel1.DataBindings.Clear();
                PRO_tblLevel1DRO level1s = await PRO_tblLevel1BUS.GetAllLevel1(CommonEngine.userInfo.UserID, ConfigEngine.Language, false, new DTO.Systems.SYS_tblActionLogDTO
                {
                    Activity = BaseConstant.COMMAND_INSERT_EN,
                    UserID = CommonEngine.userInfo.UserID,
                    LanguageID = ConfigEngine.Language,
                    ActionEN = BaseConstant.COMMAND_LOAD_ALL_DATA_EN,
                    ActionVN = BaseConstant.COMMAND_LOAD_ALL_DATA_VI,
                    FunctionID = "20",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa tải thành công dữ liệu ngành hàng.", CommonEngine.userInfo.UserID),
                    DescriptionEN = string.Format("Account '{0}' downloaded successfully data of product sector.", CommonEngine.userInfo.UserID)
                });
                if (!CommonEngine.CheckValidResponseItem(level1s.ResponseItem)) return;
                gridLevel1.DataSource = level1s.Level1List != null ? level1s.Level1List : null;
                barBottom.Visible = (level1s.Level1List != null && level1s.Level1List.Count > 0) ? true : false;
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
                curItem.Add((PRO_tblLevel1DTO)grvLevel1.GetFocusedRow());
                if (curItem != null)
                {
                    CommonEngine.ChangeDateTimeActionToCurrentData<PRO_tblLevel1DTO>(curItem, new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreaterValue, lblCreateTime, lblCreateTimeValue, lblEditer, lblEditerValue, lblEditTime, lblEditTimeValue });
                }
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
            }
        }

        private async Task DeleteLevel1()
        {
            level1_code_list = "";
            level1_id_list = "";

            foreach (int index in grvLevel1.GetSelectedRows())
            {
                level1_code_list = string.Join("$", level1_code_list, grvLevel1.GetRowCellDisplayText(index, gcolLevel1Code));
                level1_id_list = string.Join("$", level1_id_list, grvLevel1.GetRowCellDisplayText(index, gcolLevel1ID));
            }

            if (level1_code_list.Length > 0) level1_code_list = level1_code_list.Substring(1);
            if (level1_id_list.Length > 0) level1_id_list = level1_id_list.Substring(1);

            if (!string.IsNullOrEmpty(level1_id_list))
            {
                PRO_tblLevel1DRO result = new PRO_tblLevel1DRO();
                result.ResponseItem.Message = "ready";
                try
                {
                    if (level1_id_list.Contains("$"))
                    {
                        if (CommonEngine.ShowConfirmMessageAlert(LanguageEngine.GetMessageCaption("000012", ConfigEngine.Language).Replace("$Count$", level1_id_list.Split('$').Length.ToString())))
                            result = await PRO_tblLevel1BUS.DeleteLevel1(CommonEngine.userInfo.Username, ConfigEngine.Language, level1_id_list, new SYS_tblActionLogDTO
                            {
                                Activity = BaseConstant.COMMAND_INSERT_EN,
                                UserID = CommonEngine.userInfo.UserID,
                                LanguageID = ConfigEngine.Language,
                                ActionVN = BaseConstant.COMMAND_DELETE_VI,
                                ActionEN = BaseConstant.COMMAND_DELETE_EN,
                                FunctionID = "20",
                                DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công những ngành hàng có mã '{1}'.", CommonEngine.userInfo.UserID, level1_code_list.Replace("$", ", ")),
                                DescriptionEN = string.Format("Account '{0}' has deleted product sectors successfully with sector codes are '{1}'.", CommonEngine.userInfo.UserID, level1_code_list.Replace("$", ", "))
                            });
                    }
                    else
                    {
                        if (CommonEngine.ShowConfirmMessageAlert(LanguageEngine.GetMessageCaption("000005", ConfigEngine.Language)))
                            result = await PRO_tblLevel1BUS.DeleteLevel1(CommonEngine.userInfo.Username, ConfigEngine.Language, level1_id_list, new SYS_tblActionLogDTO
                            {
                                Activity = BaseConstant.COMMAND_INSERT_EN,
                                UserID = CommonEngine.userInfo.UserID,
                                LanguageID = ConfigEngine.Language,
                                ActionVN = BaseConstant.COMMAND_DELETE_VI,
                                ActionEN = BaseConstant.COMMAND_DELETE_EN,
                                FunctionID = "20",
                                DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công ngành hàng có mã '{1}'.", CommonEngine.userInfo.UserID, level1_code_list),
                                DescriptionEN = string.Format("Account '{0}' has deleted product sector successfully with sector code is '{1}'.", CommonEngine.userInfo.UserID, level1_code_list)
                            });
                    }

                    if (!CommonEngine.CheckValidResponseItem(result.ResponseItem)) return;
                    if (!result.ResponseItem.Message.Equals("ready"))
                        if (string.IsNullOrEmpty(result.ResponseItem.Message)) GetAllLevel1();
                        else CommonEngine.ShowMessage(result.ResponseItem.Message, 0);
                }
                catch (Exception ex)
                {
                    CommonEngine.ShowExceptionMessage(ex);
                }
            }
            else
            {
                CommonEngine.ShowMessage(LanguageEngine.GetMessageCaption("000027", ConfigEngine.Language), MessageType.Error);
                return;
            }
        }
        #endregion

        public uc_Level1()
        {
            InitializeComponent();
        }

        public uc_Level1(string language)
        {
            InitializeComponent();
            ChangeLanguage(language);
        }

        private void btnInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonEngine.OpenInputForm(new uc_Level1Detail(this), new Size(450, 300), false);
        }

        private async void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (curItem.Count > 0)
            {
                PRO_tblLevel1DRO item = await PRO_tblLevel1BUS.GetLevel1ByID(CommonEngine.userInfo.UserID, ConfigEngine.Language, curItem[0].Level1ID);
                if (item.Level1Item != null)
                    CommonEngine.OpenInputForm(new uc_Level1Detail(this, item.Level1Item), new Size(450, 300), true);
            }
        }

        private async void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await DeleteLevel1();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetAllLevel1();
        }

        private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonEngine.OpenImportExcelForm("PRO_Level1_FileSelect.xlsx", "PRO_spfrmProductGroupLevel1Import", "PRO", "20");
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonEngine.QuickExportGridViewData(ConvertEngine.ConvertObjectListToDataTable<PRO_tblLevel1DTO>(gridLevel1.DataSource as List<PRO_tblLevel1DTO>), grvLevel1, "Product_Sector");
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ParentForm.Close();
        }

        private void uc_Level1_Load(object sender, EventArgs e)
        {
            GetAllLevel1();
        }

        private void grvLevel1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = e.RowHandle + 1 + "";
        }

        private void grvLevel1_DoubleClick(object sender, EventArgs e)
        {
            btnUpdate_ItemClick(null, null);
        }

        private void grvLevel1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetCurrentRow();
        }

        private void grvLevel1_FocusedRowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {
            GetCurrentRow();
        }
    }
}
