using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iPOS.IMC.Helper;
using iPOS.Core.Helper;
using iPOS.DTO.Products;
using System.Threading.Tasks;
using iPOS.DRO.Products;
using iPOS.BUS.Products;

namespace iPOS.IMC.Products
{
    public partial class uc_WarehouseDetail : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        private uc_Warehouse parent_form;
        #endregion

        #region [Personal Methods]
        private void Initialize()
        {
            LanguageEngine.ChangeCaptionLayoutControlGroup(this.Name, ConfigEngine.Language, logDetail);
            LanguageEngine.ChangeCaptionLayoutControlItem(this.Name, ConfigEngine.Language, new DevExpress.XtraLayout.LayoutControlItem[] { lciWarehouseCode, lciVNName, lciENName, lciStore, lciAddressEN, lciAddressVN, lciPhone, lciFax, lciProvince, lciDistrict, lciRank, lciNote });
            LanguageEngine.ChangeCaptionCheckEdit(this.Name, ConfigEngine.Language, chkUsed);
            LanguageEngine.ChangeCaptionGridLookUpEdit(this.Name, ConfigEngine.Language, new GridLookUpEdit[] { gluProvince, gluDistrict, gluStore });
            LanguageEngine.ChangeCaptionSimpleButton(this.Name, ConfigEngine.Language, new SimpleButton[] { btnSaveClose, btnSaveInsert, btnCancel });

            LoadStore();
            LoadProvince();
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

        private async void LoadProvince()
        {
            gluProvince.DataBindings.Clear();
            PRO_tblProvinceDRO provinces = await PRO_tblProvinceBUS.GetAllProvinces(CommonEngine.userInfo.UserID, ConfigEngine.Language, true, null);
            if (provinces.ResponseItem.IsError)
            {
                CommonEngine.ShowHTTPErrorMessage(provinces.ResponseItem);
                gluProvince.Properties.DataSource = null;
                return;
            }
            gluProvince.Properties.DataSource = provinces.ProvinceList;
            gluProvince.Properties.ValueMember = "ProvinceID";
            gluProvince.Properties.DisplayMember = "FullProvinceName";
        }

        private async void LoadDistrictByProvince(string province_id)
        {
            gluDistrict.DataBindings.Clear();
            PRO_tblDistrictDRO districts = await PRO_tblDistrictBUS.GetAllDistricts(CommonEngine.userInfo.UserID, ConfigEngine.Language, true, province_id, null);
            if (districts.ResponseItem.IsError)
            {
                CommonEngine.ShowHTTPErrorMessage(districts.ResponseItem);
                gluDistrict.Properties.DataSource = null;
                return;
            }
            gluDistrict.Properties.DataSource = districts.DistrictList;
            gluDistrict.Properties.ValueMember = "DistrictID";
            gluDistrict.Properties.DisplayMember = "FullDistrictName";

        }

        private bool CheckValidate()
        {
            if (string.IsNullOrEmpty(txtWarehouseCode.Text.Trim()))
            {
                depError.SetError(txtWarehouseCode, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                txtWarehouseCode.Focus();
                return false;
            }
            if (txtWarehouseCode.Text.Contains(" "))
            {
                depError.SetError(txtWarehouseCode, LanguageEngine.GetMessageCaption("000004", ConfigEngine.Language));
                txtWarehouseCode.Focus();
                return false;
            }
            if (CommonEngine.CheckExistsUnicodeChar(txtWarehouseCode.Text))
            {
                depError.SetError(txtWarehouseCode, LanguageEngine.GetMessageCaption("000021", ConfigEngine.Language));
                txtWarehouseCode.Focus();
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

            return true;
        }

        private async Task<bool> SaveWarehouse(bool isEdit)
        {
            PRO_tblWarehouseDRO result = new PRO_tblWarehouseDRO();
            try
            {
                result = await iPOS.BUS.Products.PRO_tblWarehouseBUS.InsertUpdateStore(new PRO_tblWarehouseDTO
                {
                    WarehouseID = isEdit ? txtWarehouseID.Text : "0",
                    WarehouseCode = txtWarehouseCode.Text,
                    VNName = txtVNName.Text.Trim(),
                    ENName = txtENName.Text.Trim(),
                    StoreID = gluStore.EditValue + "",
                    AddressVN = txtAddressVN.Text.Trim(),
                    AddressEN = txtAddressEN.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Fax = txtFax.Text.Trim(),
                    ProvinceID = gluProvince.EditValue + "",
                    DistrictID = gluDistrict.EditValue + "",
                    Rank = (string.IsNullOrEmpty(speRank.EditValue + "")) ? (Int32?)null : Convert.ToInt32(speRank.EditValue),
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
                    FunctionID = "18",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa {1} thành công kho hàng có mã kho hàng là '{2}'.", CommonEngine.userInfo.UserID, isEdit ? "cập nhật" : "thêm mới", txtWarehouseCode.Text),
                    DescriptionEN = string.Format("Account '{0}' has {1} warehouse successfully with warehouse code is '{2}'.", CommonEngine.userInfo.UserID, isEdit ? "updated" : "inserted", txtWarehouseCode.Text)
                });

                if (result.ResponseItem.IsError)
                {
                    CommonEngine.ShowHTTPErrorMessage(result.ResponseItem);
                    txtWarehouseCode.Focus();
                    return false;
                }
                if (!string.IsNullOrEmpty(result.ResponseItem.Message))
                {
                    CommonEngine.ShowMessage(result.ResponseItem.Message, 0);
                    txtWarehouseCode.Focus();
                    return false;
                }
                else parent_form.GetAllWarehouse("");
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
                return false;
            }

            return true;
        }

        private void LoadDataToEdit(PRO_tblWarehouseDTO item)
        {
            txtWarehouseID.EditValue = (item == null) ? null : item.WarehouseID;
            txtWarehouseCode.EditValue = (item == null) ? null : item.WarehouseCode;
            //txtWarehouseCode.Properties.ReadOnly = (item == null) ? false : true;
            txtVNName.EditValue = (item == null) ? null : item.VNName;
            txtENName.EditValue = (item == null) ? null : item.ENName;
            gluStore.EditValue = (item == null) ? null : item.StoreID;
            txtAddressEN.EditValue = (item == null) ? null : item.AddressEN;
            txtAddressVN.EditValue = (item == null) ? null : item.AddressVN;
            gluProvince.EditValue = (item == null) ? null : item.ProvinceID;
            gluDistrict.EditValue = (item == null) ? null : item.DistrictID;
            txtPhone.EditValue = (item == null) ? null : item.Phone;
            txtFax.EditValue = (item == null) ? null : item.Fax;
            speRank.EditValue = (item == null) ? null : item.Rank;
            chkUsed.Checked = (item == null) ? true : item.Used;
            mmoNote.EditValue = (item == null) ? null : item.Note;
            if (item == null)
            {
                depError.ClearErrors();
                this.ParentForm.Text = LanguageEngine.GetOpenFormText(this.Name, ConfigEngine.Language, false);
                txtWarehouseCode.Focus();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            BeginInvoke(new MethodInvoker(() =>
            {
                if (!string.IsNullOrEmpty(txtWarehouseID.Text))
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
        #endregion

        public uc_WarehouseDetail()
        {
            InitializeComponent();
        }

        public uc_WarehouseDetail(uc_Warehouse _parent_form, PRO_tblWarehouseDTO item = null)
        {
            InitializeComponent();
            Initialize();
            parent_form = _parent_form;
            if (item != null)
                LoadDataToEdit(item);
        }

        private void txtWarehouseCode_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtWarehouseCode.Text.Trim()))
                depError.SetError(txtWarehouseCode, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
            else if (txtWarehouseCode.Text.Contains(" "))
                depError.SetError(txtWarehouseCode, LanguageEngine.GetMessageCaption("000004", ConfigEngine.Language));
            else if (CommonEngine.CheckExistsUnicodeChar(txtWarehouseCode.Text))
                depError.SetError(txtWarehouseCode, LanguageEngine.GetMessageCaption("000021", ConfigEngine.Language));
            else depError.SetError(txtWarehouseCode, null);
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
            depError.SetError(gluStore, (gluStore.EditValue == null || gluStore.EditValue.Equals("0")) ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : null);
        }

        private void gluProvince_EditValueChanged(object sender, EventArgs e)
        {
            if (gluProvince.EditValue != null && !gluProvince.EditValue.Equals("0"))
                LoadDistrictByProvince(gluProvince.EditValue + "");
        }

        private async void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (await SaveWarehouse(!string.IsNullOrEmpty(txtWarehouseID.Text)))
                    this.ParentForm.Close();
        }

        private async void btnSaveInsert_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (await SaveWarehouse(!string.IsNullOrEmpty(txtWarehouseID.Text)))
                    LoadDataToEdit(null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
