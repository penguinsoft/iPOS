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
using iPOS.Core.Helper;
using System.Threading.Tasks;
using iPOS.DRO.Products;
using iPOS.BUS.Products;

namespace iPOS.IMC.Products
{
    public partial class uc_StallDetail : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        private uc_Stall parent_form;
        #endregion

        #region [Personal Methods]
        private void Initialize()
        {
            LanguageEngine.ChangeCaptionLayoutControlGroup(this.Name, ConfigEngine.Language, logDetail);
            LanguageEngine.ChangeCaptionLayoutControlItem(this.Name, ConfigEngine.Language, new DevExpress.XtraLayout.LayoutControlItem[] { lciStallCode, lciVNName, lciENName, lciStore, lciWarehouse, lciRank, lciNote });
            LanguageEngine.ChangeCaptionGridLookUpEdit(this.Name, ConfigEngine.Language, new GridLookUpEdit[] { gluStore, gluWarehouse });
            LanguageEngine.ChangeCaptionCheckEdit(this.Name, ConfigEngine.Language, chkUsed);
            LanguageEngine.ChangeCaptionSimpleButton(this.Name, ConfigEngine.Language, new SimpleButton[] { btnSaveClose, btnSaveInsert, btnCancel });

            LoadStore();
        }

        private async void LoadStore()
        {
            gluStore.DataBindings.Clear();
            PRO_tblStoreDRO stores = await PRO_tblStoreBUS.GetAllStores(CommonEngine.userInfo.UserID, ConfigEngine.Language, true, null);
            if (stores.ResponseItem.IsError)
            {
                CommonEngine.ShowHTTPErrorMessage(stores.ResponseItem);
                gluStore.Properties.DataSource = null;
                return;
            }
            gluStore.Properties.DataSource = stores.StoreList;
            gluStore.Properties.ValueMember = "StoreID";
            gluStore.Properties.DisplayMember = "FullStoreName";
        }

        private async void LoadWarehouseByStoreID(string store_id)
        {
            gluWarehouse.DataBindings.Clear();
            PRO_tblWarehouseDRO warehouses = await PRO_tblWarehouseBUS.GetAllWarehouses(CommonEngine.userInfo.UserID, ConfigEngine.Language, true, store_id, "", "", null);
            if (warehouses.ResponseItem.IsError)
            {
                CommonEngine.ShowHTTPErrorMessage(warehouses.ResponseItem);
                gluWarehouse.Properties.DataSource = null;
                return;
            }
            gluWarehouse.Properties.DataSource = warehouses.WarehouseList;
            gluWarehouse.Properties.ValueMember = "WarehouseID";
            gluWarehouse.Properties.DisplayMember = "FullWarehouseName";
        }

        private bool CheckValidate()
        {
            if (string.IsNullOrEmpty(txtStallCode.Text.Trim()))
            {
                depError.SetError(txtStallCode, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                txtStallCode.Focus();
                return false;
            }
            if (txtStallCode.Text.Contains(" "))
            {
                depError.SetError(txtStallCode, LanguageEngine.GetMessageCaption("000004", ConfigEngine.Language));
                txtStallCode.Focus();
                return false;
            }
            if (CommonEngine.CheckExistsUnicodeChar(txtStallCode.Text))
            {
                depError.SetError(txtStallCode, LanguageEngine.GetMessageCaption("000021", ConfigEngine.Language));
                txtStallCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtVNName.Text.Trim()))
            {
                depError.SetError(txtVNName, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                txtVNName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtENName.Text.Trim()))
            {
                depError.SetError(txtENName, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                txtENName.Focus();
                return false;
            }
            if (gluStore.EditValue == null || gluStore.EditValue.Equals("0"))
            {
                depError.SetError(gluStore, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                gluStore.Focus();
                return false;
            }
            if (gluWarehouse.EditValue == null || gluWarehouse.EditValue.Equals("0"))
            {
                depError.SetError(gluWarehouse, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                gluWarehouse.Focus();
                return false;
            }


            return true;
        }

        private async Task<bool> SaveStall(bool isEdit)
        {
            CommonEngine.ShowWaitForm(this);
            PRO_tblStallDRO result = new PRO_tblStallDRO();
            try
            {
                result = await iPOS.BUS.Products.PRO_tblStallBUS.InsertUpdateStall(new PRO_tblStallDTO
                {
                    StallID = isEdit ? txtStallID.Text : "0",
                    StallCode = txtStallCode.Text.Trim(),
                    VNName = txtVNName.Text.Trim(),
                    ENName = txtENName.Text.Trim(),
                    StoreID = gluStore.EditValue + "",
                    WarehouseID = gluWarehouse.EditValue + "",
                    Rank = speRank.EditValue + "",
                    Used = chkUsed.Checked,
                    Note = mmoNote.Text.Trim(),
                    UserID = CommonEngine.userInfo.UserID,
                    Activity = isEdit ? BaseConstant.COMMAND_UPDATE_EN : BaseConstant.COMMAND_INSERT_EN,
                    LanguageID = ConfigEngine.Language
                }, new DTO.Systems.SYS_tblActionLogDTO
                {
                    Activity = BaseConstant.COMMAND_INSERT_EN,
                    UserID = CommonEngine.userInfo.UserID,
                    LanguageID = ConfigEngine.Language,
                    ActionEN = isEdit ? BaseConstant.COMMAND_UPDATE_EN : BaseConstant.COMMAND_INSERT_EN,
                    ActionVN = isEdit ? BaseConstant.COMMAND_UPDATE_VI : BaseConstant.COMMAND_INSERT_VI,
                    FunctionID = "19",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa {1} thành công quầy bán có mã quầy là '{2}'.", CommonEngine.userInfo.UserID, isEdit ? "cập nhật" : "thêm mới", txtStallCode.Text),
                    DescriptionEN = string.Format("Account '{0}' has {1} stall successfully with stall code is '{2}'.", CommonEngine.userInfo.UserID, isEdit ? "updated" : "inserted", txtStallCode.Text)
                });

                if (CommonEngine.CheckValidResponseItem(result.ResponseItem))
                {
                    if (!string.IsNullOrEmpty(result.ResponseItem.Message))
                    {
                        CommonEngine.CloseWaitForm();
                        CommonEngine.ShowMessage(result.ResponseItem.Message, 0);
                        txtStallCode.Focus();
                        return false;
                    }
                    else if (parent_form != null) parent_form.GetAllStall("", "");
                }
                else
                {
                    CommonEngine.CloseWaitForm();
                    return false;
                }
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
                return false;
            }
            finally
            {
                CommonEngine.CloseWaitForm();
            }

            return true;
        }

        private void LoadDataToEdit(PRO_tblStallDTO item)
        {
            txtStallID.EditValue = (item == null) ? null : item.StallID;
            txtStallCode.EditValue = (item == null) ? null : item.StallCode;
            //txtStallCode.Properties.ReadOnly = (item == null) ? false : true;
            txtVNName.EditValue = (item == null) ? null : item.VNName;
            txtENName.EditValue = (item == null) ? null : item.ENName;
            gluStore.EditValue = (item == null) ? null : item.StoreID;
            gluWarehouse.EditValue = (item == null) ? null : item.WarehouseID;
            speRank.EditValue = (item == null) ? null : item.Rank;
            mmoNote.EditValue = (item == null) ? null : item.Note;
            if (item == null)
            {
                depError.ClearErrors();
                this.ParentForm.Text = LanguageEngine.GetOpenFormText(this.Name, ConfigEngine.Language, false);
                txtStallCode.Focus();
            }
        }
        #endregion

        #region [Form Events]
        public uc_StallDetail()
        {
            InitializeComponent();
            CommonEngine.LoadUserPermission("19", txtStallID, btnSaveClose, btnSaveInsert);
        }

        public uc_StallDetail(uc_Stall _parent_form, PRO_tblStallDTO item = null)
        {
            CommonEngine.ShowWaitForm(this);
            InitializeComponent();
            Initialize();
            parent_form = _parent_form;
            if (item != null)
                LoadDataToEdit(item);
            CommonEngine.LoadUserPermission("19", txtStallID, btnSaveClose, btnSaveInsert);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CommonEngine.CloseWaitForm();
            BeginInvoke(new MethodInvoker(() =>
            {
                if (!string.IsNullOrEmpty(txtStallID.Text))
                    txtVNName.Focus();
            }));
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                btnSaveClose_Click(null, null);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.Shift | Keys.S))
            {
                btnSaveInsert_Click(null, null);
                return true;
            }
            else if (keyData == Keys.Escape)
            {
                btnCancel_Click(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);

        }

        private void txtStallCode_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStallCode.Text.Trim()))
                depError.SetError(txtStallCode, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
            else if (txtStallCode.Text.Contains(" "))
                depError.SetError(txtStallCode, LanguageEngine.GetMessageCaption("000004", ConfigEngine.Language));
            else if (CommonEngine.CheckExistsUnicodeChar(txtStallCode.Text))
                depError.SetError(txtStallCode, LanguageEngine.GetMessageCaption("000021", ConfigEngine.Language));
            else depError.SetError(txtStallCode, null);
        }

        private void txtVNName_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtVNName, string.IsNullOrEmpty(txtVNName.Text.Trim()) ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : null);
        }

        private void txtENName_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtENName, string.IsNullOrEmpty(txtENName.Text.Trim()) ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : null);
        }

        private void gluStore_EditValueChanged(object sender, EventArgs e)
        {
            if (gluStore.EditValue == null || gluStore.EditValue.Equals("0"))
                depError.SetError(gluStore, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
            else
            {
                LoadWarehouseByStoreID(gluStore.EditValue + "");
                depError.SetError(gluStore, null);
            }
        }

        private void gluWarehouse_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(gluWarehouse, gluWarehouse.EditValue == null || gluWarehouse.EditValue.Equals("0") ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : null);
        }

        private async void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (await SaveStall(!string.IsNullOrEmpty(txtStallID.Text)))
                    this.ParentForm.Close();
        }

        private async void btnSaveInsert_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (await SaveStall(!string.IsNullOrEmpty(txtStallID.Text)))
                    LoadDataToEdit(null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        #endregion
    }
}
