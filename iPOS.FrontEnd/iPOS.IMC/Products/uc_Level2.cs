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
    public partial class uc_Level2 : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        private List<PRO_tblLevel2DTO> curItem = new List<PRO_tblLevel2DTO>();

        private string level2_id_list = "", level2_code_list = "";
        #endregion

        #region [Personal Methods]
        public void ChangeLanguage(string language)
        {
            LanguageEngine.ChangeCaptionBarLargeButtonItem(this.Name, language, new DevExpress.XtraBars.BarLargeButtonItem[] { btnInsert, btnDuplicated, btnUpdate, btnDelete, btnPrint, btnReload, btnImport, btnExport, btnClose });
            LanguageEngine.ChangeCaptionBarStaticItem(this.Name, language, new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreateTime, lblEditer, lblEditTime });
            LanguageEngine.ChangeCaptionGridView(this.Name, language, grvLevel2);
        }

        public async void GetAllLevel2(string level1_id = "")
        {
            try
            {
                gridLevel2.DataBindings.Clear();
                PRO_tblLevel2DRO level2s = await PRO_tblLevel2BUS.GetAllLevel2(CommonEngine.userInfo.UserID, ConfigEngine.Language, level1_id, false, new DTO.Systems.SYS_tblActionLogDTO
                {
                    Activity = BaseConstant.COMMAND_INSERT_EN,
                    UserID = CommonEngine.userInfo.UserID,
                    LanguageID = ConfigEngine.Language,
                    ActionEN = BaseConstant.COMMAND_LOAD_ALL_DATA_EN,
                    ActionVN = BaseConstant.COMMAND_LOAD_ALL_DATA_VI,
                    FunctionID = "21",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa tải thành công dữ liệu nhóm hàng.", CommonEngine.userInfo.UserID),
                    DescriptionEN = string.Format("Account '{0}' downloaded successfully data of product group.", CommonEngine.userInfo.UserID)
                });
                if (!CommonEngine.CheckValidResponseItem(level2s.ResponseItem)) return;
                gridLevel2.DataSource = level2s.Level2List != null ? level2s.Level2List : null;
                barBottom.Visible = (level2s.Level2List != null && level2s.Level2List.Count > 0) ? true : false;
                CommonEngine.LoadUserPermission("21", btnDelete, btnPrint, btnImport, btnExport);
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
                curItem.Add((PRO_tblLevel2DTO)grvLevel2.GetFocusedRow());
                if (curItem != null)
                {
                    CommonEngine.ChangeDateTimeActionToCurrentData<PRO_tblLevel2DTO>(curItem, new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreaterValue, lblCreateTime, lblCreateTimeValue, lblEditer, lblEditerValue, lblEditTime, lblEditTimeValue });
                }
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
            }
        }

        private async Task DeleteLevel2()
        {
            level2_code_list = "";
            level2_id_list = "";

            foreach (int index in grvLevel2.GetSelectedRows())
            {
                if (index >= 0)
                {
                    level2_code_list = string.Join("$", level2_code_list, grvLevel2.GetRowCellDisplayText(index, gcolLevel2Code));
                    level2_id_list = string.Join("$", level2_id_list, grvLevel2.GetRowCellDisplayText(index, gcolLevel2ID));
                }
            }

            if (level2_code_list.Length > 0) level2_code_list = level2_code_list.Substring(1);
            if (level2_id_list.Length > 0) level2_id_list = level2_id_list.Substring(1);

            if (!string.IsNullOrEmpty(level2_id_list))
            {
                PRO_tblLevel2DRO result = new PRO_tblLevel2DRO();
                result.ResponseItem.Message = "ready";
                try
                {
                    if (level2_id_list.Contains("$"))
                    {
                        if (CommonEngine.ShowConfirmMessageAlert(LanguageEngine.GetMessageCaption("000012", ConfigEngine.Language).Replace("$Count$", level2_id_list.Split('$').Length.ToString())))
                        {
                            CommonEngine.ShowWaitForm(this);
                            result = await PRO_tblLevel2BUS.DeleteLevel2(CommonEngine.userInfo.Username, ConfigEngine.Language, level2_id_list, new SYS_tblActionLogDTO
                            {
                                Activity = BaseConstant.COMMAND_INSERT_EN,
                                UserID = CommonEngine.userInfo.UserID,
                                LanguageID = ConfigEngine.Language,
                                ActionVN = BaseConstant.COMMAND_DELETE_VI,
                                ActionEN = BaseConstant.COMMAND_DELETE_EN,
                                FunctionID = "21",
                                DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công những nhóm hàng có mã '{1}'.", CommonEngine.userInfo.UserID, level2_code_list.Replace("$", ", ")),
                                DescriptionEN = string.Format("Account '{0}' has deleted product groups successfully with group codes are '{1}'.", CommonEngine.userInfo.UserID, level2_code_list.Replace("$", ", "))
                            });
                        }
                    }
                    else
                    {
                        if (CommonEngine.ShowConfirmMessageAlert(LanguageEngine.GetMessageCaption("000005", ConfigEngine.Language)))
                        {
                            CommonEngine.ShowWaitForm(this);
                            result = await PRO_tblLevel2BUS.DeleteLevel2(CommonEngine.userInfo.Username, ConfigEngine.Language, level2_id_list, new SYS_tblActionLogDTO
                            {
                                Activity = BaseConstant.COMMAND_INSERT_EN,
                                UserID = CommonEngine.userInfo.UserID,
                                LanguageID = ConfigEngine.Language,
                                ActionVN = BaseConstant.COMMAND_DELETE_VI,
                                ActionEN = BaseConstant.COMMAND_DELETE_EN,
                                FunctionID = "21",
                                DescriptionVN = string.Format("Tài khoản '{0}' vừa xóa thành công nhóm hàng có mã '{1}'.", CommonEngine.userInfo.UserID, level2_code_list),
                                DescriptionEN = string.Format("Account '{0}' has deleted product group successfully with group code is '{1}'.", CommonEngine.userInfo.UserID, level2_code_list)
                            });
                        }
                    }

                    if (!CommonEngine.CheckValidResponseItem(result.ResponseItem)) return;
                    if (!result.ResponseItem.Message.Equals("ready"))
                        if (string.IsNullOrEmpty(result.ResponseItem.Message)) GetAllLevel2();
                        else CommonEngine.ShowMessage(result.ResponseItem.Message, 0);
                }
                catch (Exception ex)
                {
                    CommonEngine.ShowExceptionMessage(ex);
                }
                finally
                {
                    CommonEngine.CloseWaitForm();
                }
            }
            else CommonEngine.ShowMessage(LanguageEngine.GetMessageCaption("000027", ConfigEngine.Language), MessageType.Error);
        }
        #endregion

        #region [Form Events]
        public uc_Level2()
        {
            InitializeComponent();
        }

        public uc_Level2(string language)
        {
            InitializeComponent();
            ChangeLanguage(language);
        }

        private void btnInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonEngine.OpenInputForm(new uc_Level2Detail(this), new Size(450, 320), false);
        }

        private async void btnDuplicated_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (curItem.Count > 0)
            {
                PRO_tblLevel2DRO item = await PRO_tblLevel2BUS.GetLevel2ByID(CommonEngine.userInfo.UserID, ConfigEngine.Language, curItem[0].Level2ID);
                if (!CommonEngine.CheckValidResponseItem(item.ResponseItem)) return;

                if (item != null && item.Level2Item != null)
                {
                    item.Level2Item.Level2ID = "";
                    CommonEngine.OpenInputForm(new uc_Level2Detail(this, item.Level2Item), new Size(450, 320), false);
                }
            }
        }

        private async void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (curItem.Count > 0)
            {
                PRO_tblLevel2DRO item = await PRO_tblLevel2BUS.GetLevel2ByID(CommonEngine.userInfo.UserID, ConfigEngine.Language, curItem[0].Level2ID);
                if (!CommonEngine.CheckValidResponseItem(item.ResponseItem)) return;

                if (item != null && item.Level2Item != null)
                    CommonEngine.OpenInputForm(new uc_Level2Detail(this, item.Level2Item), new Size(450, 320), true);
            }
        }

        private async void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await DeleteLevel2();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonEngine.ShowWaitForm(this);
            GetAllLevel2();
            CommonEngine.CloseWaitForm();
        }

        private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonEngine.OpenImportExcelForm("PRO_Level2_FileSelect.xlsx", "PRO_spfrmProductGroupLevel2Import", "PRO", "21");
            btnReload_ItemClick(null, null);
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommonEngine.QuickExportGridViewData(ConvertEngine.ConvertObjectListToDataTable<PRO_tblLevel2DTO>(gridLevel2.DataSource as List<PRO_tblLevel2DTO>), grvLevel2, "Product_Group");
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ParentForm.Close();
        }

        private void uc_Level2_Load(object sender, EventArgs e)
        {
            GetAllLevel2();
        }

        private void grvLevel2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = e.RowHandle + 1 + "";
        }

        private void grvLevel2_DoubleClick(object sender, EventArgs e)
        {
            btnUpdate_ItemClick(null, null);
        }

        private void grvLevel2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetCurrentRow();
        }

        private void grvLevel2_FocusedRowLoaded(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {
            GetCurrentRow();
        }
        #endregion
    }
}
