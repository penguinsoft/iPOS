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
using iPOS.BUS.Products;

namespace iPOS.IMC.Products
{
    public partial class uc_StoreDetail : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        private uc_Store parent_form;

        private string new_file_path = "";
        #endregion

        #region [Personal Methods]
        private void Initialize()
        {
            LanguageEngine.ChangeCaptionLayoutControlGroup(this.Name, ConfigEngine.Language, logDetail);
            LanguageEngine.ChangeCaptionLayoutControlItem(this.Name, ConfigEngine.Language, new DevExpress.XtraLayout.LayoutControlItem[] { lciStoreCode, lciShortCode, lciVNName, lciENName, lciBuildDate, lciEndDate, lciAddressVN, lciAddressEN, lciProvince, lciDistrict, lciPhone, lciFax, lciTaxCode, lciRank, lciRepresentives, lciNote });
            LanguageEngine.ChangeCaptionCheckEdit(this.Name, ConfigEngine.Language, new CheckEdit[] { chkIsRoot, chkUsed });
            LanguageEngine.ChangeCaptionGridLookUpEdit(this.Name, ConfigEngine.Language, new GridLookUpEdit[] { gluProvince, gluDistrict });
            LanguageEngine.ChangeCaptionPictureEdit(this.Name, ConfigEngine.Language, picPhoto);

            LoadProvince();
        }

        private bool CheckValidate()
        {
            if (string.IsNullOrEmpty(txtStoreCode.Text.Trim()))
            {
                depError.SetError(txtStoreCode, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                txtStoreCode.Focus();
                return false;
            }
            if (txtStoreCode.Text.Contains(" "))
            {
                depError.SetError(txtStoreCode, LanguageEngine.GetMessageCaption("000004", ConfigEngine.Language));
                txtStoreCode.Focus();
                return false;
            }
            if (CommonEngine.CheckExistsUnicodeChar(txtStoreCode.Text))
            {
                depError.SetError(txtStoreCode, LanguageEngine.GetMessageCaption("000021", ConfigEngine.Language));
                txtStoreCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtShortCode.Text.Trim()))
            {
                depError.SetError(txtShortCode, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                txtShortCode.Focus();
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
            if (dteEndDate.EditValue != null && !CommonEngine.CompareDateEdit(dteBuildDate, dteEndDate, false))
            {
                depError.SetError(dteEndDate, LanguageEngine.GetMessageCaption("000025", ConfigEngine.Language));
                dteEndDate.Focus();
                return false;
            }

            return true;
        }

        private async void LoadProvince()
        {
            gluProvince.DataBindings.Clear();
            gluProvince.Properties.DataSource = await iPOS.BUS.Products.PRO_tblProvinceBUS.GetAllProvinces(CommonEngine.userInfo.UserID, ConfigEngine.Language, true, null);
            gluProvince.Properties.ValueMember = "ProvinceID";
            gluProvince.Properties.DisplayMember = "FullProvinceName";
        }

        private async void LoadDistrictByProvince(string province_id)
        {
            gluDistrict.DataBindings.Clear();
            gluDistrict.Properties.DataSource = await iPOS.BUS.Products.PRO_tblDistrictBUS.GetAllDistricts(CommonEngine.userInfo.UserID, ConfigEngine.Language, true, province_id, null);
            gluDistrict.Properties.ValueMember = "DistrictID";
            gluDistrict.Properties.DisplayMember = "FullDistrictName";

        }

        private async Task<bool> SaveStore(bool isEdit)
        {
            string strError = "", file_name = "";
            try
            {
                if (!string.IsNullOrEmpty(new_file_path))
                {
                    Bitmap image = (Bitmap)Bitmap.FromFile(new_file_path);
                    file_name = await iPOS.BUS.Tools.OBJ_FileBUS.UploadImageFile(image, "Stores");
                }

                strError = await PRO_tblStoreBUS.InsertUpdateStore(new PRO_tblStoreDTO
                {
                    StoreID = isEdit ? txtStoreID.Text : "0",
                    StoreCode = txtStoreCode.Text,
                    ShortCode = txtShortCode.Text,
                    VNName = txtVNName.Text,
                    ENName = txtENName.Text,
                    BuildDate = dteBuildDate.EditValue != null ? dteBuildDate.DateTime : (DateTime?)null,
                    EndDate = dteEndDate.EditValue != null ? dteEndDate.DateTime : (DateTime?)null,
                    AddressEN = txtAddressEN.Text,
                    AddressVN = txtAddressVN.Text,
                    ProvinceID = gluProvince.EditValue + "",
                    DistrictID = gluDistrict.EditValue + "",
                    Phone = txtPhone.Text,
                    Fax = txtFax.Text,
                    TaxCode = txtTaxCode.Text,
                    Rank = speRank.EditValue != null ? Convert.ToInt32(speRank.EditValue) : (Int32?)null,
                    Representatives = txtRepresentives.Text,
                    IsRoot = chkIsRoot.Checked,
                    Used = chkUsed.Checked,
                    Note = mmoNote.Text,
                    Photo = file_name,
                    UserID = CommonEngine.userInfo.UserID,
                    LanguageID = ConfigEngine.Language,
                    Activity = isEdit ? BaseConstant.COMMAND_UPDATE_EN : BaseConstant.COMMAND_INSERT_EN
                }, new DTO.Systems.SYS_tblActionLogDTO
                {
                    Activity = BaseConstant.COMMAND_INSERT_EN,
                    UserID = CommonEngine.userInfo.UserID,
                    LanguageID = ConfigEngine.Language,
                    ActionEN = isEdit ? BaseConstant.COMMAND_UPDATE_EN : BaseConstant.COMMAND_INSERT_EN,
                    ActionVN = isEdit ? BaseConstant.COMMAND_UPDATE_VI : BaseConstant.COMMAND_INSERT_VI,
                    FunctionID = "13",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa {1} thành công cửa hàng có mã cửa hàng là '{2}'.", CommonEngine.userInfo.UserID, isEdit ? "cập nhật" : "thêm mới", txtStoreCode.Text),
                    DescriptionEN = string.Format("Account '{0}' has {1} store successfully with store code is '{2}'.", CommonEngine.userInfo.UserID, isEdit ? "updated" : "inserted", txtStoreCode.Text)
                });
                if (!string.IsNullOrEmpty(strError))
                {
                    CommonEngine.ShowMessage(strError, 0);
                    txtStoreCode.Focus();
                    return false;
                }
                else parent_form.GetAllStore();
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
                return false;
            }

            return true;
        }

        private void LoadDataToEdit(PRO_tblStoreDTO item)
        {
            txtStoreID.EditValue = (item == null) ? null : item.StoreID;
            txtStoreCode.EditValue = (item == null) ? null : item.StoreCode;
            //txtStoreCode.Properties.ReadOnly = (item == null) ? false : true;
            txtShortCode.EditValue = (item == null) ? null : item.ShortCode;
            txtVNName.EditValue = (item == null) ? null : item.VNName;
            txtENName.EditValue = (item == null) ? null : item.ENName;
            dteBuildDate.EditValue = (item == null) ? null : item.BuildDate;
            dteEndDate.EditValue = (item == null) ? null : item.EndDate;
            txtAddressVN.EditValue = (item == null) ? null : item.AddressVN;
            txtAddressEN.EditValue = (item == null) ? null : item.AddressEN;
            gluProvince.EditValue = (item == null) ? null : item.ProvinceID;
            gluDistrict.EditValue = (item == null) ? null : item.DistrictID;
            txtPhone.EditValue = (item == null) ? null : item.Phone;
            txtFax.EditValue = (item == null) ? null : item.Fax;
            txtTaxCode.EditValue = (item == null) ? null : item.TaxCode;
            speRank.EditValue = (item == null) ? null : item.Rank;
            txtRepresentives.EditValue = (item == null) ? null : item.Representatives;
            chkIsRoot.Checked = (item == null) ? false : item.IsRoot;
            chkUsed.Checked = (item == null) ? true : item.Used;
            mmoNote.EditValue = (item == null) ? null : item.Note;
            if (item != null && !string.IsNullOrEmpty(item.PhotoUri))
                picPhoto.LoadAsync(item.PhotoUri);
            else picPhoto.EditValue = null;
            if (item == null)
            {
                depError.ClearErrors();
                this.ParentForm.Text = LanguageEngine.GetOpenFormText(this.Name, ConfigEngine.Language, false);
                txtStoreCode.Focus();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            BeginInvoke(new MethodInvoker(() =>
            {
                if (!string.IsNullOrEmpty(txtStoreID.Text))
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

        #region [Form Events]
        public uc_StoreDetail()
        {
            InitializeComponent();
        }

        public uc_StoreDetail(uc_Store _parent_form, PRO_tblStoreDTO item = null)
        {
            InitializeComponent();
            Initialize();
            parent_form = _parent_form;
            if (item != null)
                LoadDataToEdit(item);
        }

        private void txtStoreCode_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStoreCode.Text.Trim()))
                depError.SetError(txtStoreCode, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
            else if (txtStoreCode.Text.Contains(" "))
                depError.SetError(txtStoreCode, LanguageEngine.GetMessageCaption("000004", ConfigEngine.Language));
            else if (CommonEngine.CheckExistsUnicodeChar(txtStoreCode.Text))
                depError.SetError(txtStoreCode, LanguageEngine.GetMessageCaption("000021", ConfigEngine.Language));
            else depError.SetError(txtStoreCode, null);
        }

        private void txtShortCode_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtShortCode, string.IsNullOrEmpty(txtShortCode.Text.Trim()) ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : null);
        }

        private void txtShortCode_Leave(object sender, EventArgs e)
        {
            txtShortCode.Text = CommonEngine.OnlyGetNumberText(txtShortCode.Text).PadLeft(3, '0');
        }

        private void txtVNName_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtVNName, string.IsNullOrEmpty(txtVNName.Text.Trim()) ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : null);
        }

        private void txtENName_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtENName, string.IsNullOrEmpty(txtENName.Text.Trim()) ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : null);
        }

        private void dteEndDate_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(dteEndDate, (!CommonEngine.CompareDateEdit(dteBuildDate, dteEndDate, false) && dteEndDate.EditValue != null) ? LanguageEngine.GetMessageCaption("000025", ConfigEngine.Language) : null);
        }

        private void gluProvince_EditValueChanged(object sender, EventArgs e)
        {
            if (gluProvince.EditValue != null && !gluProvince.EditValue.Equals("0"))
                LoadDistrictByProvince(gluProvince.EditValue + "");
        }

        private void picPhoto_DoubleClick(object sender, EventArgs e)
        {
            CommonEngine.ChooseImage(ref picPhoto, ref new_file_path);
        }

        private async void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (await SaveStore(!string.IsNullOrEmpty(txtStoreID.Text)))
                    this.ParentForm.Close();
        }

        private async void btnSaveInsert_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (await SaveStore(!string.IsNullOrEmpty(txtStoreID.Text)))
                    LoadDataToEdit(null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        #endregion
    }
}
