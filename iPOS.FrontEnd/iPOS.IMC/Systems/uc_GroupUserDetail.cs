using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LanguageEngine = iPOS.IMC.Helper.LanguageEngine;
using iPOS.Core.Helper;
using iPOS.IMC.Helper;
using iPOS.DTO.Systems;
using iPOS.BUS.Systems;
using System.Threading.Tasks;
using iPOS.DRO.Systems;

namespace iPOS.IMC.Systems
{

    public partial class uc_GroupUserDetail : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        private uc_GroupUser parent_form;
        #endregion

        #region [Personal Methods]
        private void Initialize()
        {
            LanguageEngine.ChangeCaptionLayoutControlGroup(this.Name, ConfigEngine.Language, logDetail);
            LanguageEngine.ChangeCaptionSimpleButton(this.Name, ConfigEngine.Language, new SimpleButton[] { btnSaveClose, btnSaveInsert, btnCancel });
            LanguageEngine.ChangeCaptionLayoutControlItem(this.Name, ConfigEngine.Language, new DevExpress.XtraLayout.LayoutControlItem[] { lciGroupCode, lciVNName, lciENName, lciNote });
            LanguageEngine.ChangeCaptionCheckEdit(this.Name, ConfigEngine.Language, new CheckEdit[] { chkIsDefault, chkActive });
        }

        private bool CheckValidate()
        {
            if (txtGroupCode.Text.Equals(""))
            {
                depError.SetError(txtGroupCode, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                txtGroupCode.Focus();
                return false;
            }
            if (txtGroupCode.Text.Contains(" "))
            {
                depError.SetError(txtGroupCode, LanguageEngine.GetMessageCaption("000004", ConfigEngine.Language));
                txtGroupCode.Focus();
                return false;
            }
            if (CommonEngine.CheckExistsUnicodeChar(txtGroupCode.Text))
            {
                depError.SetError(txtGroupCode, LanguageEngine.GetMessageCaption("000021", ConfigEngine.Language));
                txtGroupCode.Focus();
                return false;
            }
            if (txtVNName.Text.Trim().Equals(""))
            {
                depError.SetError(txtVNName, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                txtVNName.Focus();
                return false;
            }
            if (txtENName.Text.Trim().Equals(""))
            {
                depError.SetError(txtENName, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                txtENName.Focus();
                return false;
            }

            return true;
        }

        private void LoadDataToEdit(SYS_tblGroupUserDTO item)
        {
            txtGroupID.EditValue = (item == null) ? null : item.GroupID;
            txtGroupCode.EditValue = (item == null) ? null : item.GroupCode;
            //txtGroupCode.Properties.ReadOnly = (item == null) ? false : true;
            txtVNName.EditValue = (item == null) ? null : item.VNName;
            txtENName.EditValue = (item == null) ? null : item.ENName;
            mmoNote.EditValue = (item == null) ? null : item.Note;
            chkIsDefault.Checked = (item == null) ? false : item.IsDefault;
            chkActive.Checked = (item == null) ? true : item.Active;
            if (item == null)
            {
                depError.ClearErrors();
                this.ParentForm.Text = LanguageEngine.GetOpenFormText(this.Name, ConfigEngine.Language, false);
                txtGroupCode.Focus();
            }
            CommonEngine.LoadUserPermission("9", txtGroupID, btnSaveClose, btnSaveInsert);
        }

        private async Task<bool> SaveGroupUser(bool isEdit)
        {
            try
            {
                SYS_tblGroupUserDRO result = await SYS_tblGroupUserBUS.InsertUpdateGroupUser(new SYS_tblGroupUserDTO
                {
                    GroupID = txtGroupID.Text,
                    GroupCode = txtGroupCode.Text,
                    VNName = txtVNName.Text,
                    ENName = txtENName.Text,
                    Note = mmoNote.Text,
                    IsDefault = chkIsDefault.Checked,
                    Active = chkActive.Checked,
                    Activity = (isEdit) ? BaseConstant.UPDATE_COMMAND : BaseConstant.INSERT_COMMAND,
                    UserID = CommonEngine.userInfo.UserID,
                    LanguageID = ConfigEngine.Language
                }, new SYS_tblActionLogDTO
                {
                    Activity = BaseConstant.COMMAND_INSERT_EN,
                    UserID = CommonEngine.userInfo.UserID,
                    LanguageID = ConfigEngine.Language,
                    ActionEN = (isEdit) ? BaseConstant.COMMAND_UPDATE_EN : BaseConstant.COMMAND_INSERT_EN,
                    ActionVN = (isEdit) ? BaseConstant.COMMAND_UPDATE_VI : BaseConstant.COMMAND_INSERT_VI,
                    FunctionID = "9",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa thêm mới thành công nhóm người dùng có mã '{1}'.", CommonEngine.userInfo.UserID, txtGroupCode.Text),
                    DescriptionEN = string.Format("Account '{0}' has inserted new group user successfully with group code is '{1}'.", CommonEngine.userInfo.UserID, txtGroupCode.Text)
                });
                if (!string.IsNullOrEmpty(result.ResponseItem.Message))
                {
                    CommonEngine.ShowMessage(result.ResponseItem.Message, 0);
                    txtGroupCode.Focus();
                    return false;
                }
                else parent_form.GetAllGroupUsers();
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
                return false;
            }
            return true;
        }
        #endregion

        #region [Form Events]
        public uc_GroupUserDetail()
        {
            InitializeComponent();
            Initialize();
        }

        public uc_GroupUserDetail(uc_GroupUser _parent_form, SYS_tblGroupUserDTO item = null)
        {
            InitializeComponent();
            Initialize();
            CommonEngine.LoadUserPermission("9", txtGroupID, btnSaveClose, btnSaveInsert);
            parent_form = _parent_form;

            if (item != null)
                LoadDataToEdit(item);
        }

        private void txtGroupCode_EditValueChanged(object sender, EventArgs e)
        {
            if (txtGroupCode.Text.Contains(" "))
                depError.SetError(txtGroupCode, LanguageEngine.GetMessageCaption("000004", ConfigEngine.Language));
            else if (string.IsNullOrEmpty(txtGroupCode.Text))
                depError.SetError(txtGroupCode, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
            else if (CommonEngine.CheckExistsUnicodeChar(txtGroupCode.Text))
                depError.SetError(txtGroupCode, LanguageEngine.GetMessageCaption("000021", ConfigEngine.Language));
            else depError.SetError(txtGroupCode, null);
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
                if (await SaveGroupUser(txtGroupID.Text.Equals("") ? false : true))
                    this.ParentForm.Close();
        }

        private async void btnSaveInsert_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (await SaveGroupUser(txtGroupID.Text.Equals("") ? false : true))
                    LoadDataToEdit(null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        #endregion
    }
}