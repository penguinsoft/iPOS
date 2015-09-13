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
using System.Threading.Tasks;
using iPOS.DTO.Products;

namespace iPOS.IMC.Products
{
    public partial class uc_DistrictDetail : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        private uc_District parent_form;
        #endregion

        #region [Personal Methods]
        private async void Initialize()
        {
            LanguageEngine.ChangeCaptionLayoutControlItem(this.Name, ConfigEngine.Language, new DevExpress.XtraLayout.LayoutControlItem[] { lciDistrictCode, lciVNName, lciENName, lciProvince, lciNote, lciRank });
            LanguageEngine.ChangeCaptionLayoutControlGroup(this.Name, ConfigEngine.Language, logDetail);
            LanguageEngine.ChangeCaptionCheckEdit(this.Name, ConfigEngine.Language, chkUsed);
            LanguageEngine.ChangeCaptionSimpleButton(this.Name, ConfigEngine.Language, new SimpleButton[] { btnSaveClose, btnSaveInsert, btnCancel });
            LanguageEngine.ChangeCaptionGridLookUpEdit(this.Name, ConfigEngine.Language, gluProvince);

            await LoadProvince();
        }

        private bool CheckValidate()
        {
            if (string.IsNullOrEmpty(txtDistrictCode.Text))
            {
                depError.SetError(txtDistrictCode, LanguageEngine.GetMessageCaption("000003",ConfigEngine.Language));
                txtDistrictCode.Focus();
                return false;
            }
            if (txtDistrictCode.Text.Contains(" "))
            {
                depError.SetError(txtDistrictCode, LanguageEngine.GetMessageCaption("000004", ConfigEngine.Language));
                txtDistrictCode.Focus();
                return false;
            }
            if (CommonEngine.CheckExistsUnicodeChar(txtDistrictCode.Text))
            {
                depError.SetError(txtDistrictCode, LanguageEngine.GetMessageCaption("000021", ConfigEngine.Language));
                txtDistrictCode.Focus();
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
            if (string.IsNullOrEmpty(gluProvince.EditValue + "") || gluProvince.EditValue.Equals("0"))
            {
                depError.SetError(gluProvince, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                gluProvince.Focus();
                return false;
            }

            return true;
        }

        private async Task LoadProvince()
        {
            gluProvince.DataBindings.Clear();
            gluProvince.Properties.DataSource = await iPOS.BUS.Products.PRO_tblProvinceBUS.GetAllProvinces(CommonEngine.userInfo.UserID, ConfigEngine.Language, true, null);
            gluProvince.Properties.ValueMember = "ProvinceID";
            gluProvince.Properties.DisplayMember = "FullProvinceName";
        }

        private async Task<bool> SaveDistrict(bool isEdit)
        {
            string strError = "";
            try
            {
                PRO_tblDistrictDTO item = new PRO_tblDistrictDTO
                {
                    DistrictID = isEdit ? txtDistrictID.Text : "0",
                    DistrictCode = txtDistrictCode.Text,
                    VNName = txtVNName.Text,
                    ENName = txtENName.Text,
                    ProvinceID = gluProvince.EditValue + "",
                    Rank = speRank.EditValue != null ? Convert.ToInt32(speRank.Value) : (Int32?)null,
                    Used = chkUsed.Checked,
                    Note = mmoNote.Text,
                    UserID = CommonEngine.userInfo.UserID,
                    Activity = (isEdit) ? BaseConstant.COMMAND_UPDATE_EN : BaseConstant.COMMAND_INSERT_EN,
                    LanguageID = ConfigEngine.Language
                };
                strError = await iPOS.BUS.Products.PRO_tblDistrictBUS.InsertUpdateDistrict(item, new DTO.Systems.SYS_tblActionLogDTO
                {
                    Activity = BaseConstant.COMMAND_INSERT_EN,
                    UserID = CommonEngine.userInfo.UserID,
                    LanguageID = ConfigEngine.Language,
                    ActionEN = isEdit ? BaseConstant.COMMAND_UPDATE_EN : BaseConstant.COMMAND_INSERT_EN,
                    ActionVN = isEdit ? BaseConstant.COMMAND_UPDATE_VI : BaseConstant.COMMAND_INSERT_VI,
                    FunctionID = "12",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa {1} thành công quận huyện có mã quận huyện là '{2}'.", item.UserID, isEdit ? "cập nhật" : "thêm mới", txtDistrictCode.Text),
                    DescriptionEN = string.Format("Account '{0}' has {1} district successfully with district code is '{2}'.", item.UserID, isEdit ? "updated" : "inserted", txtDistrictCode.Text)
                });
                if (!string.IsNullOrEmpty(strError))
                {
                    CommonEngine.ShowMessage(strError, 0);
                    txtDistrictCode.Focus();
                    return false;
                }
                else parent_form.GetAllDistrict();
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
                return false;
            }

            return true;
        }

        private void LoadDataToEdit(PRO_tblDistrictDTO item)
        {
            txtDistrictID.EditValue = (item == null) ? null : item.DistrictID;
            txtDistrictCode.EditValue = (item == null) ? null : item.DistrictCode;
            txtDistrictCode.Properties.ReadOnly = (item == null) ? false : true;
            txtVNName.EditValue = (item == null) ? null : item.VNName;
            txtENName.EditValue = (item == null) ? null : item.ENName;
            gluProvince.EditValue = (item == null) ? null : item.ProvinceID;
            speRank.EditValue = (item == null) ? null : item.Rank;
            chkUsed.Checked = (item == null) ? true : item.Used;
            mmoNote.EditValue = (item == null) ? null : item.Note;
            if (item == null)
            {
                depError.ClearErrors();
                this.ParentForm.Text = LanguageEngine.GetOpenFormText(this.Name, ConfigEngine.Language, false);
                txtDistrictCode.Focus();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            BeginInvoke(new MethodInvoker(() =>
            {
                if (!string.IsNullOrEmpty(txtDistrictID.Text))
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
        public uc_DistrictDetail()
        {
            InitializeComponent();
            Initialize();
        }

        public uc_DistrictDetail(uc_District _parent_form, PRO_tblDistrictDTO item = null)
        {
            InitializeComponent();
            Initialize();
            parent_form = _parent_form;
            if (item != null)
                LoadDataToEdit(item);
        }

        private void txtDistrictCode_EditValueChanged(object sender, EventArgs e)
        {
            if (txtDistrictCode.Text.Contains(" "))
                depError.SetError(txtDistrictCode, LanguageEngine.GetMessageCaption("000004", ConfigEngine.Language));
            else if (string.IsNullOrEmpty(txtDistrictCode.Text))
                depError.SetError(txtDistrictCode, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
            else if (CommonEngine.CheckExistsUnicodeChar(txtDistrictCode.Text))
                depError.SetError(txtDistrictCode, LanguageEngine.GetMessageCaption("000021", ConfigEngine.Language));
            else depError.SetError(txtDistrictCode, null);
        }

        private void txtVNName_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtVNName, string.IsNullOrEmpty(txtVNName.Text.Trim()) ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : null);
        }

        private void txtENName_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtENName, string.IsNullOrEmpty(txtENName.Text.Trim()) ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : null);
        }

        private void gluProvince_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(gluProvince, (string.IsNullOrEmpty(gluProvince.EditValue + "") || gluProvince.EditValue.Equals("0")) ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : null);
        }

        private async void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (await SaveDistrict(!string.IsNullOrEmpty(txtDistrictID.Text)))
                    this.ParentForm.Close();
        }

        private async void btnSaveInsert_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (await SaveDistrict(!string.IsNullOrEmpty(txtDistrictID.Text)))
                    LoadDataToEdit(null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        #endregion
    }
}
