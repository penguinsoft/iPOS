using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iPOS.DTO.Systems;
using iPOS.IMC.Helper;
using iPOS.Core.Helper;
using System.Text.RegularExpressions;
using System.Linq;
using System.Threading.Tasks;
using iPOS.Core.Security;
using iPOS.BUS.Systems;
using iPOS.DRO.Systems;

namespace iPOS.IMC.Systems
{
    public partial class uc_UserDetail : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        private uc_User parent_form;
        #endregion

        #region [Personal Methods]
        private async void Initialize(SYS_tblUserDTO item)
        {
            LanguageEngine.ChangeCaptionLayoutControlGroup(this.Name, ConfigEngine.Language, logDetail);
            LanguageEngine.ChangeCaptionLayoutControlItem(this.Name, ConfigEngine.Language, new DevExpress.XtraLayout.LayoutControlItem[] { lciUsername, lciPassword, lciGroupUser, lciFullName, lciEffectiveDate, lciToDate, lciLockDate, lciUnlockDate, lciEmail, lciNote });
            LanguageEngine.ChangeCaptionSimpleButton(this.Name, ConfigEngine.Language, new SimpleButton[] { btnSaveClose, btnSaveInsert, btnCancel });
            LanguageEngine.ChangeCaptionCheckEdit(this.Name, ConfigEngine.Language, new CheckEdit[] { chkIsEmployee, chkLocked, chkCanNotChangePassword, chkChangePassNextTime, chkPasswordNeverExpired });
            LanguageEngine.ChangeCaptionGridLookUpEdit(this.Name, ConfigEngine.Language, gluGroupUser);

            await LoadGroupUser(item);
            dteEffectiveDate.EditValue = CommonEngine.SystemDateTime;
        }

        public bool CheckValidate()
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                depError.SetError(txtUsername, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                txtUsername.Focus();
                return false;
            }
            if (txtUsername.Text.Contains(" "))
            {
                depError.SetError(txtUsername, LanguageEngine.GetMessageCaption("000004", ConfigEngine.Language));
                txtUsername.Focus();
                return false;
            }
            if (CommonEngine.CheckExistsUnicodeChar(txtUsername.Text))
            {
                depError.SetError(txtUsername, LanguageEngine.GetMessageCaption("000021", ConfigEngine.Language));
                txtUsername.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                depError.SetError(txtPassword, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                txtPassword.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(gluGroupUser.EditValue + ""))
            {
                depError.SetError(gluGroupUser, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                gluGroupUser.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtFullName.Text) && !chkIsEmployee.Checked)
            {
                depError.SetError(txtFullName, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                txtFullName.Focus();
                return false;
            }
            if (chkIsEmployee.Checked && string.IsNullOrEmpty(gluEmployee.EditValue + ""))
            {
                depError.SetError(gluEmployee, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                gluEmployee.Focus();
                return false;
            }
            if (dteToDate.EditValue != null && !CommonEngine.CompareDateEdit(dteEffectiveDate, dteToDate, false))
            {
                depError.SetError(dteToDate, LanguageEngine.GetMessageCaption("000022", ConfigEngine.Language));
                dteToDate.Focus();
                return false;
            }
            if (chkLocked.Checked && dteUnlockDate.EditValue != null && !CommonEngine.CompareDateEdit(dteLockDate, dteUnlockDate, false))
            {
                depError.SetError(dteUnlockDate, LanguageEngine.GetMessageCaption("000023", ConfigEngine.Language));
                dteUnlockDate.Focus();
                return false;
            }
            if (!CommonEngine.CheckValidEmailAddress(txtEmail.Text.Trim()))
            {
                depError.SetError(txtEmail, LanguageEngine.GetMessageCaption("000013", ConfigEngine.Language));
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        private void LoadDataToEdit(SYS_tblUserDTO item)
        {
            txtUsername.EditValue = (item == null) ? null : item.Username;
            txtUsername.Properties.ReadOnly = (item == null) ? false : true;
            txtPassword.EditValue = (item == null) ? null : iPOS.Core.Security.EncryptEngine.Decrypt(item.Password);
            //gluGroupUser.EditValue = "1";// (item == null) ? null : item.GroupID;
            chkIsEmployee.Checked = (item == null) ? false : (!string.IsNullOrEmpty(item.EmpID)) ? true : false;
            txtFullName.EditValue = (item == null) ? null : item.FullName;
            gluEmployee.EditValue = (item == null) ? null : item.EmpID;
            dteEffectiveDate.EditValue = (item == null) ? CommonEngine.SystemDateTime : item.EffectiveDate;
            dteToDate.EditValue = (item == null) ? CommonEngine.SystemDateTime : item.ToDate;
            chkLocked.Checked = (item == null) ? false : item.Locked;
            dteLockDate.EditValue = (item == null) ? CommonEngine.SystemDateTime : item.LockDate;
            dteUnlockDate.EditValue = (item == null) ? CommonEngine.SystemDateTime : item.UnlockDate;
            chkCanNotChangePassword.Checked = (item == null) ? false : item.CanNotChangePassword;
            chkChangePassNextTime.Checked = (item == null) ? false : item.ChangePassNextTime;
            chkPasswordNeverExpired.Checked = (item == null) ? true : item.PassNeverExpired;
            txtEmail.EditValue = item == null ? null : item.Email;
            mmoNote.EditValue = item == null ? null : item.Note;
            if (item == null)
            {
                depError.ClearErrors();
                this.ParentForm.Text = LanguageEngine.GetOpenFormText(this.Name, ConfigEngine.Language, false);
                txtUsername.Focus();
            }
        }

        private async Task LoadGroupUser(SYS_tblUserDTO item)
        {
            SYS_tblGroupUserDRO groupUsers = await iPOS.BUS.Systems.SYS_tblGroupUserBUS.GetAllGroupUsers(CommonEngine.userInfo.Username, ConfigEngine.Language, true, null);
            gluGroupUser.DataBindings.Clear();
            if (groupUsers.ResponseItem.IsError)
            {
                CommonEngine.ShowHTTPErrorMessage(groupUsers.ResponseItem.ErrorCode, groupUsers.ResponseItem.ErrorMessage);
            }
            else gluGroupUser.Properties.DataSource = groupUsers.GroupUserList;
            gluGroupUser.Properties.DisplayMember = "Note";
            gluGroupUser.Properties.ValueMember = "GroupID";

            if (item == null && groupUsers.GroupUserList != null)
            {
                var groupDefault = (from groupUser in groupUsers.GroupUserList
                                    where groupUser.IsDefault.Equals(true)
                                    select groupUser).FirstOrDefault();
                if (groupUsers.GroupUserList.Count > 0)
                    gluGroupUser.EditValue = groupDefault.GroupID;
            }
            else gluGroupUser.EditValue = item.GroupID;
        }

        private async Task<bool> SaveUser(bool isEdit)
        {
            SYS_tblUserDRO result = new SYS_tblUserDRO();
            try
            {
                result = await SYS_tblUserBUS.InsertUpdateUser(new SYS_tblUserDTO
                {
                    Username = txtUsername.Text,
                    Password = EncryptEngine.Encrypt(txtPassword.Text.Trim()),
                    GroupID = gluGroupUser.EditValue + "",
                    EmpID = chkIsEmployee.Checked ? gluEmployee.EditValue + "" : "",
                    FullName = txtFullName.Text,
                    EffectiveDate = dteEffectiveDate.DateTime,
                    ToDate = dteToDate.EditValue == null ? (DateTime?)null : dteToDate.DateTime,
                    Locked = chkLocked.Checked,
                    LockDate = (chkLocked.Checked && dteLockDate.EditValue != null) ? dteLockDate.DateTime : (DateTime?)null,
                    UnlockDate = (chkLocked.Checked && dteUnlockDate.EditValue != null) ? dteUnlockDate.DateTime : (DateTime?)null,
                    CanNotChangePassword = chkCanNotChangePassword.Checked,
                    ChangePassNextTime = chkChangePassNextTime.Checked,
                    PassNeverExpired = chkPasswordNeverExpired.Checked,
                    Email = txtEmail.Text,
                    Note = mmoNote.Text,
                    Activity = (isEdit) ? BaseConstant.UPDATE_COMMAND : BaseConstant.INSERT_COMMAND,
                    UserID = CommonEngine.userInfo.UserID,
                    LanguageID = ConfigEngine.Language
                }, new SYS_tblActionLogDTO
                {
                    Activity = BaseConstant.COMMAND_INSERT_EN,
                    UserID = txtUsername.Text,
                    LanguageID = ConfigEngine.Language,
                    ActionEN = BaseConstant.COMMAND_UPDATE_EN,
                    ActionVN = BaseConstant.COMMAND_UPDATE_VI,
                    FunctionID = "10",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa cập nhật thành công người dùng có tên tài khoản '{1}'.", CommonEngine.userInfo.UserID, txtUsername.Text.Trim()),
                    DescriptionEN = string.Format("Account '{0}' has updated user successfully with username is '{1}'.", CommonEngine.userInfo.UserID, txtUsername.Text.Trim())
                });
                if (!string.IsNullOrEmpty(result.ResponseItem.Message))
                {
                    CommonEngine.ShowMessage(result.ResponseItem.Message, 0);
                    txtUsername.Focus();
                    return false;
                }
                else parent_form.GetAllUsers();
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
        public uc_UserDetail()
        {
            InitializeComponent();
        }

        public uc_UserDetail(uc_User _parent_form, SYS_tblUserDTO item = null)
        {
            InitializeComponent();
            Initialize(item);
            parent_form = _parent_form;
            if (item != null)
                LoadDataToEdit(item);
        }

        private void chkIsEmployee_CheckedChanged(object sender, EventArgs e)
        {
            lciEmployee.Visibility = (chkIsEmployee.Checked) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lciFullName.Visibility = (chkIsEmployee.Checked) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never : DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        private void chkLocked_CheckedChanged(object sender, EventArgs e)
        {
            lciLockDate.Visibility = lciUnlockDate.Visibility = (chkLocked.Checked) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void txtUsername_EditValueChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text.Contains(" "))
                depError.SetError(txtUsername, LanguageEngine.GetMessageCaption("000004", ConfigEngine.Language));
            else if (string.IsNullOrEmpty(txtUsername.Text))
                depError.SetError(txtUsername, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
            else if (CommonEngine.CheckExistsUnicodeChar(txtUsername.Text))
                depError.SetError(txtUsername, LanguageEngine.GetMessageCaption("000021", ConfigEngine.Language));
            else depError.SetError(txtUsername, null);
        }

        private void txtPassword_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text.Contains(" "))
                depError.SetError(txtPassword, LanguageEngine.GetMessageCaption("000004", ConfigEngine.Language));
            else if (string.IsNullOrEmpty(txtPassword.Text))
                depError.SetError(txtPassword, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
            else depError.SetError(txtPassword, null);
        }

        private void gluGroupUser_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(gluGroupUser, string.IsNullOrEmpty(gluGroupUser.EditValue + "") ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : null);
        }

        private void gluEmployee_EditValueChanged(object sender, EventArgs e)
        {
            if (chkIsEmployee.Checked)
                depError.SetError(gluEmployee, string.IsNullOrEmpty(gluEmployee.EditValue + "") ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : null);
            else depError.SetError(gluEmployee, null);
        }

        private void txtEmail_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtEmail, !CommonEngine.CheckValidEmailAddress(txtEmail.Text) ? LanguageEngine.GetMessageCaption("000013", ConfigEngine.Language) : null);
        }

        private void txtFullName_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtFullName, (string.IsNullOrEmpty(txtFullName.Text) && !chkIsEmployee.Checked) ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : null);
        }

        private void dteToDate_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(dteToDate, (!CommonEngine.CompareDateEdit(dteEffectiveDate, dteToDate, false) && dteToDate.EditValue != null) ? LanguageEngine.GetMessageCaption("000022", ConfigEngine.Language) : null);
        }

        private void dteUnlockDate_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(dteUnlockDate, (dteUnlockDate.EditValue != null && chkLocked.Checked && !CommonEngine.CompareDateEdit(dteLockDate, dteUnlockDate, false)) ? LanguageEngine.GetMessageCaption("000023", ConfigEngine.Language) : null);
        }

        private async void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (await SaveUser(txtUsername.Properties.ReadOnly))
                    this.ParentForm.Close();
        }

        private async void btnSaveInsert_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (await SaveUser(txtUsername.Properties.ReadOnly))
                    LoadDataToEdit(null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        #endregion
    }
}
