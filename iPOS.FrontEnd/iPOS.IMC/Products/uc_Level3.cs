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
using iPOS.IMC.Helper;
using iPOS.DTO.Products;
using iPOS.BUS.Products;
using iPOS.DRO.Products;
using iPOS.Core.Helper;
using iPOS.DTO.Systems;

namespace iPOS.IMC.Products
{
    public partial class uc_Level3 : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        private List<PRO_tblLevel3DTO> curItem = new List<PRO_tblLevel3DTO>();

        private string level3_id_list = "", level3_code_list = "";
        #endregion

        #region [Personal Methods]
        public void ChangeLanguage(string language)
        {
            LanguageEngine.ChangeCaptionBarLargeButtonItem(this.Name, language, new DevExpress.XtraBars.BarLargeButtonItem[] { btnInsert, btnUpdate, btnDelete, btnPrint, btnReload, btnImport, btnExport, btnClose });
            LanguageEngine.ChangeCaptionBarStaticItem(this.Name, language, new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreateTime, lblEditer, lblEditTime });
            LanguageEngine.ChangeCaptionGridView(this.Name, language, grvLevel3);
        }

        public async void GetAllLevel3(string level1_id = "", string level2_id = "")
        {
            try
            {
                gridLevel3.DataBindings.Clear();
                PRO_tblLevel3DRO level3s = await PRO_tblLevel3BUS.GetAllLevel3(CommonEngine.userInfo.UserID, ConfigEngine.Language, level1_id, level2_id, false, new DTO.Systems.SYS_tblActionLogDTO
                {
                    Activity = BaseConstant.COMMAND_INSERT_EN,
                    UserID = CommonEngine.userInfo.UserID,
                    LanguageID = ConfigEngine.Language,
                    ActionEN = BaseConstant.COMMAND_LOAD_ALL_DATA_EN,
                    ActionVN = BaseConstant.COMMAND_LOAD_ALL_DATA_VI,
                    FunctionID = "22",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa tải thành công dữ liệu phân nhóm hàng.", CommonEngine.userInfo.UserID),
                    DescriptionEN = string.Format("Account '{0}' downloaded successfully data of product subgroup.", CommonEngine.userInfo.UserID)
                });
                if (level3s.ResponseItem.IsError)
                    CommonEngine.ShowHTTPErrorMessage(level3s.ResponseItem);
                gridLevel3.DataSource = level3s.Level3List != null ? level3s.Level3List : null;
                barBottom.Visible = (level3s.Level3List != null && level3s.Level3List.Count > 0) ? true : false;
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
                curItem.Add((PRO_tblLevel3DTO)grvLevel3.GetFocusedRow());
                if (curItem != null)
                {
                    CommonEngine.ChangeDateTimeActionToCurrentData<PRO_tblLevel3DTO>(curItem, new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreaterValue, lblCreateTime, lblCreateTimeValue, lblEditer, lblEditerValue, lblEditTime, lblEditTimeValue });
                }
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
            }
        }

        private async Task DeleteLevel3()
        {
            level3_code_list = "";
            level3_id_list = "";

            foreach (int index in grvLevel3.GetSelectedRows())
            {
                if (index >= 0)
                {
                    level3_code_list = string.Join("$", level3_code_list, grvLevel3.GetRowCellDisplayText(index, gcolLevel3Code));
                    level3_id_list = string.Join("$", level3_id_list, grvLevel3.GetRowCellDisplayText(index, gcolLevel3ID));
                }
            }

            if (level3_code_list.Length > 0) level3_code_list = level3_code_list.Substring(1);
            if (level3_id_list.Length > 0) level3_id_list = level3_id_list.Substring(1);

            if (!string.IsNullOrEmpty(level3_id_list))
            {
                PRO_tblLevel2DRO result = new PRO_tblLevel2DRO();
                result.ResponseItem.Message = "ready";
                try
                {
                    if (level3_id_list.Contains("$"))
                    {
                        if (CommonEngine.ShowConfirmMessageAlert(LanguageEngine.GetMessageCaption("000012", ConfigEngine.Language).Replace("$Count$", level3_id_list.Split('$').Length.ToString())))
                            result = await PRO_tblLevel2BUS.DeleteLevel2(CommonEngine.userInfo.Username, ConfigEngine.Language, level3_id_list, new SYS_tblActionLogDTO
                            {
                                Activity = BaseConstant.COMMAND_INSERT_EN,
                                UserID = CommonEngine.userInfo.UserID,
                                LanguageID = ConfigEngine.Language,
                                ActionVN = BaseConstant.COMMAND_DELETE_VI,
                                ActionEN = BaseConstant.COMMAND_DELETE_EN,
                                FunctionID = "22",
                                DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công những phân nhóm hàng có mã '{1}'.", CommonEngine.userInfo.UserID, level3_code_list.Replace("$", ", ")),
                                DescriptionEN = string.Format("Account '{0}' has deleted product subgroups successfully with subgroup codes are '{1}'.", CommonEngine.userInfo.UserID, level3_code_list.Replace("$", ", "))
                            });
                    }
                    else
                    {
                        if (CommonEngine.ShowConfirmMessageAlert(LanguageEngine.GetMessageCaption("000005", ConfigEngine.Language)))
                            result = await PRO_tblLevel2BUS.DeleteLevel2(CommonEngine.userInfo.Username, ConfigEngine.Language, level3_id_list, new SYS_tblActionLogDTO
                            {
                                Activity = BaseConstant.COMMAND_INSERT_EN,
                                UserID = CommonEngine.userInfo.UserID,
                                LanguageID = ConfigEngine.Language,
                                ActionVN = BaseConstant.COMMAND_DELETE_VI,
                                ActionEN = BaseConstant.COMMAND_DELETE_EN,
                                FunctionID = "22",
                                DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công phân nhóm hàng có mã '{1}'.", CommonEngine.userInfo.UserID, level3_code_list),
                                DescriptionEN = string.Format("Account '{0}' has deleted product subgroup successfully with subgroup code is '{1}'.", CommonEngine.userInfo.UserID, level3_code_list)
                            });
                    }

                    if (result.ResponseItem.IsError)
                    {
                        CommonEngine.ShowHTTPErrorMessage(result.ResponseItem);
                        return;
                    }
                    if (!result.ResponseItem.Message.Equals("ready"))
                        if (string.IsNullOrEmpty(result.ResponseItem.Message)) GetAllLevel3();
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

        public uc_Level3()
        {
            InitializeComponent();
        }

        public uc_Level3(string language)
        {
            InitializeComponent();
            ChangeLanguage(language);
        }

        private void btnInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonEngine.OpenInputForm(new uc_Level3Detail(this), new Size(450, 350), false);
        }

        private async void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (curItem.Count > 0)
            {
                PRO_tblLevel3DRO item = await PRO_tblLevel3BUS.GetLevel3ByID(CommonEngine.userInfo.UserID, ConfigEngine.Language, curItem[0].Level3ID);
                if (item.Level3Item != null)
                    CommonEngine.OpenInputForm(new uc_Level3Detail(this, item.Level3Item), new Size(450, 320), true);
            }
        }

        private async void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await DeleteLevel3();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetAllLevel3();
        }

        private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonEngine.OpenImportExcelForm("PRO_Level3_FileSelect.xlsx", "PRO_spfrmProductGroupLevel3Import", "PRO", "22");
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonEngine.QuickExportGridViewData(ConvertEngine.ConvertObjectListToDataTable<PRO_tblLevel3DTO>(gridLevel3.DataSource as List<PRO_tblLevel3DTO>), grvLevel3, "Product_SubGroup");
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ParentForm.Close();
        }

        private void uc_Level3_Load(object sender, EventArgs e)
        {
            GetAllLevel3();
        }

        private void grvLevel3_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = e.RowHandle + 1 + "";
        }

        private void grvLevel3_DoubleClick(object sender, EventArgs e)
        {
            btnUpdate_ItemClick(null, null);
        }

        private void grvLevel3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetCurrentRow();
        }

        private void grvLevel3_FocusedRowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {
            GetCurrentRow();
        }
    }
}
