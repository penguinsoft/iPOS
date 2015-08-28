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

namespace iPOS.IMC.Systems
{
    public partial class uc_UserDetail : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        private uc_User parent_form;
        #endregion

        #region [Personal Methods]
        private void Initialize()
        {
            LanguageEngine.ChangeCaptionLayoutControlGroup(this.Name, ConfigEngine.Language, logDetail);
            LanguageEngine.ChangeCaptionLayoutControlItem(this.Name, ConfigEngine.Language, new DevExpress.XtraLayout.LayoutControlItem[] { lciUsername, lciPassword, lciGroupUser, lciFullName, lciEffectiveDate, lciToDate, lciLockDate, lciUnlockDate, lciEmail, lciNote });
            LanguageEngine.ChangeCaptionSimpleButton(this.Name, ConfigEngine.Language, new SimpleButton[] { btnSaveClose, btnSaveInsert, btnCancel });
            LanguageEngine.ChangeCaptionCheckEdit(this.Name, ConfigEngine.Language, new CheckEdit[] { chkIsEmployee, chkLocked, chkCanNotChangePassword, chkChangePassNextTime, chkPasswordNeverExpired });

            LoadGroupUser();
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
            if (string.IsNullOrEmpty(txtFullName.Text))
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
            if (chkLocked.Checked && (dteUnlockDate.EditValue == null || dteLockDate.EditValue == null) && !CommonEngine.CompareDateEdit(dteLockDate, dteUnlockDate, false))
            {
                depError.SetError(dteUnlockDate, LanguageEngine.GetMessageCaption("000023", ConfigEngine.Language));
                dteUnlockDate.Focus();
                return false;
            }

            return true;
        }

        private void LoadDataToEdit(SYS_tblUserDTO item)
        {
            txtUsername.EditValue = (item == null) ? null : item.UserName;
            txtPassword.EditValue = (item == null) ? null : iPOS.Core.Security.EcryptEngine.Decrypt(item.Password);
            gluGroupUser.EditValue = (item == null) ? null : item.GroupID;
            chkIsEmployee.Checked = (item == null) ? false : (!string.IsNullOrEmpty(item.EmpID)) ? true : false;
            txtFullName.EditValue = (item == null) ? null : item.FullName;
            gluEmployee.EditValue = (item == null) ? null : item.EmpID;
            dteEffectiveDate.EditValue = (item == null) ? CommonEngine.SystemDateTime : item.EffectiveDate;
            dteToDate.EditValue = (item == null || (item != null && item.ToDate == null)) ? CommonEngine.SystemDateTime : item.ToDate;
            chkLocked.Checked = (item == null) ? false : item.Locked;
            dteLockDate.EditValue = (item == null || (item != null && item.LockDate == null)) ? CommonEngine.SystemDateTime : item.LockDate;
            dteUnlockDate.EditValue = (item == null || (item != null && item.UnlockDate == null)) ? CommonEngine.SystemDateTime : item.UnlockDate;
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

        private async void LoadGroupUser()
        {
            List<SYS_tblGroupUserDTO> groupUsers = await iPOS.BUS.Systems.SYS_tblGroupUserBUS.GetAllGroupUsers(CommonEngine.userInfo.Username, ConfigEngine.Language, true);
            gluGroupUser.DataBindings.Clear();
            gluGroupUser.Properties.DataSource = groupUsers;
            gluGroupUser.Properties.DisplayMember = "Note";
            gluGroupUser.Properties.ValueMember = "GroupID";

            var groupDefault = (from groupUser in groupUsers
                                where groupUser.IsDefault.Equals(true)
                                select groupUser).FirstOrDefault();
            if (groupUsers.Count > 0)
                gluGroupUser.EditValue = groupDefault.GroupID;
        }
        #endregion

        public uc_UserDetail()
        {
            InitializeComponent();
            Initialize();
        }

        public uc_UserDetail(uc_User _parent_form, SYS_tblUserDTO item = null)
        {
            InitializeComponent();
            Initialize();
            parent_form = _parent_form;
            if (item != null)
                LoadDataToEdit(item);
        }

        private void chkIsEmployee_CheckedChanged(object sender, EventArgs e)
        {
            lciEmployee.Visibility = (chkIsEmployee.Checked) ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
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
        }

        private void txtPassword_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gluGroupUser_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gluEmployee_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveInsert_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
