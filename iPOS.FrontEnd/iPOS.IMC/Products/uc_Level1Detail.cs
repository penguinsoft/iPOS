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
using iPOS.Core.Helper;
using iPOS.DRO.Products;
using iPOS.BUS.Products;

namespace iPOS.IMC.Products
{
    public partial class uc_Level1Detail : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        uc_Level1 parent_form;
        #endregion

        #region [Personal Methods]
        private void Initialize()
        {
            LanguageEngine.ChangeCaptionLayoutControlGroup(this.Name, ConfigEngine.Language, logDetail);
            LanguageEngine.ChangeCaptionLayoutControlItem(this.Name, ConfigEngine.Language, new DevExpress.XtraLayout.LayoutControlItem[] { lciLevel1Code, lciLevel1ShortCode, lciVNName, lciENName, lciRank, lciNote, lciDescription });
            LanguageEngine.ChangeCaptionCheckEdit(this.Name, ConfigEngine.Language, chkUsed);
            LanguageEngine.ChangeCaptionSimpleButton(this.Name, ConfigEngine.Language, new SimpleButton[] { btnSaveClose, btnSaveInsert, btnCancel });
        }

        private bool CheckValidate()
        {
            if (string.IsNullOrEmpty(txtLevel1Code.Text.Trim()))
            {
                depError.SetError(txtLevel1Code, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                txtLevel1Code.Focus();
                return false;
            }
            else if (txtLevel1Code.Text.Contains(" "))
            {
                depError.SetError(txtLevel1ShortCode, LanguageEngine.GetMessageCaption("000004", ConfigEngine.Language));
                txtLevel1ShortCode.Focus();
                return false;
            }
            else if (CommonEngine.CheckExistsUnicodeChar(txtLevel1Code.Text.Trim()))
            {
                depError.SetError(txtLevel1Code, LanguageEngine.GetMessageCaption("000021", ConfigEngine.Language));
                txtLevel1Code.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtLevel1ShortCode.Text.Trim()))
            {
                depError.SetError(txtLevel1ShortCode, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                txtLevel1ShortCode.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtVNName.Text.Trim()))
            {
                depError.SetError(txtVNName, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                txtVNName.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtENName.Text.Trim()))
            {
                depError.SetError(txtENName, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                txtENName.Focus();
                return false;
            }

            return true;
        }

        private async Task<bool> SaveLevel1(bool isEdit)
        {
            PRO_tblLevel1DRO result = new PRO_tblLevel1DRO();
            try
            {
                result = await PRO_tblLevel1BUS.InsertUpdateLevel1(new PRO_tblLevel1DTO
                {
                    Level1ID = isEdit ? txtLevel1ID.Text : "0",
                    Level1Code = txtLevel1Code.Text.Trim(),
                    Level1ShortCode = txtLevel1ShortCode.Text.Trim(),
                    VNName = txtVNName.Text.Trim(),
                    ENName = txtENName.Text.Trim(),
                    Rank = speRank.Text.Trim(),
                    Used = chkUsed.Checked,
                    Note = mmoNote.Text.Trim(),
                    Description = mmoDescription.Text.Trim(),
                    Activity = isEdit ? BaseConstant.COMMAND_UPDATE_EN : BaseConstant.COMMAND_INSERT_EN,
                    UserID = CommonEngine.userInfo.UserID,
                    LanguageID = ConfigEngine.Language
                }, new DTO.Systems.SYS_tblActionLogDTO
                {
                    Activity = BaseConstant.COMMAND_INSERT_EN,
                    UserID = CommonEngine.userInfo.UserID,
                    LanguageID = ConfigEngine.Language,
                    ActionEN = isEdit ? BaseConstant.COMMAND_UPDATE_EN : BaseConstant.COMMAND_INSERT_EN,
                    ActionVN = isEdit ? BaseConstant.COMMAND_UPDATE_VI : BaseConstant.COMMAND_INSERT_VI,
                    FunctionID = "20",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa {1} thành công ngành hàng có mã ngành hàng là '{2}'.", CommonEngine.userInfo.UserID, isEdit ? "cập nhật" : "thêm mới", txtLevel1Code.Text),
                    DescriptionEN = string.Format("Account '{0}' has {1} product sector successfully with sector code is '{2}'.", CommonEngine.userInfo.UserID, isEdit ? "updated" : "inserted", txtLevel1Code.Text)
                });

                if (result.ResponseItem.IsError)
                {
                    CommonEngine.ShowHTTPErrorMessage(result.ResponseItem);
                    txtLevel1Code.Focus();
                    return false;
                }
                if (!string.IsNullOrEmpty(result.ResponseItem.Message))
                {
                    CommonEngine.ShowMessage(result.ResponseItem.Message, MessageType.Error);
                    txtLevel1Code.Focus();
                    return false;
                }
                else parent_form.GetAllLevel1();
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
                return false;
            }

            return true;
        }

        private void LoadDataToEdit(PRO_tblLevel1DTO item)
        {
            txtLevel1ID.EditValue = (item == null) ? null : item.Level1ID;
            txtLevel1Code.EditValue = (item == null) ? null : item.Level1Code;
            //txtLevel1Code.Properties.ReadOnly = (item == null) ? false : true;
            txtLevel1ShortCode.Text = (item == null) ? null : item.Level1ShortCode;
            txtVNName.EditValue = (item == null) ? null : item.VNName;
            txtENName.EditValue = (item == null) ? null : item.ENName;
            speRank.EditValue = (item == null) ? null : item.Rank;
            chkUsed.Checked = (item == null) ? true : item.Used;
            mmoDescription.EditValue = (item == null) ? null : item.Description;
            mmoNote.EditValue = (item == null) ? null : item.Note;
            if (item == null)
            {
                depError.ClearErrors();
                this.ParentForm.Text = LanguageEngine.GetOpenFormText(this.Name, ConfigEngine.Language, false);
                txtLevel1Code.Focus();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            BeginInvoke(new MethodInvoker(() =>
            {
                if (!string.IsNullOrEmpty(txtLevel1ID.Text))
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
        public uc_Level1Detail()
        {
            InitializeComponent();
        }

        public uc_Level1Detail(uc_Level1 _parent_form, PRO_tblLevel1DTO item = null)
        {
            InitializeComponent();
            parent_form = _parent_form;

            if (item != null)
                LoadDataToEdit(item);
        }

        private void txtLevel1Code_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLevel1Code.Text.Trim()))
                depError.SetError(txtLevel1Code, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
            else if (txtLevel1Code.Text.Contains(" "))
                depError.SetError(txtLevel1Code, LanguageEngine.GetMessageCaption("000004", ConfigEngine.Language));
            else if (CommonEngine.CheckExistsUnicodeChar(txtLevel1Code.Text.Trim()))
                depError.SetError(txtLevel1Code, LanguageEngine.GetMessageCaption("000021", ConfigEngine.Language));
            else depError.SetError(txtLevel1Code, null);
        }

        private void txtLevel1ShortCode_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtLevel1ShortCode, string.IsNullOrEmpty(txtLevel1ShortCode.Text.Trim()) ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : null);
        }

        private void txtLevel1ShortCode_Leave(object sender, EventArgs e)
        {
            txtLevel1ShortCode.Text = CommonEngine.OnlyGetNumberText(txtLevel1ShortCode.Text).PadLeft(2, '0');
        }

        private void txtVNName_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtVNName, string.IsNullOrEmpty(txtVNName.Text.Trim()) ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : null);
        }

        private void txtENName_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtENName, string.IsNullOrEmpty(txtENName.Text.Trim()) ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : null);
        }

        private async void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (await SaveLevel1(!string.IsNullOrEmpty(txtLevel1ID.Text)))
                    this.ParentForm.Close();
        }

        private async void btnSaveInsert_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (await SaveLevel1(!string.IsNullOrEmpty(txtLevel1ID.Text)))
                    LoadDataToEdit(null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        #endregion
    }
}
