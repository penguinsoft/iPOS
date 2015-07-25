using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LanguageEngine = iPOS.IMC.Helper.LanguageManage;
using iPOS.Core.Helper;
using iPOS.IMC.Helper;
using iPOS.DTO.System;
using iPOS.BUS.System;
using System.Threading.Tasks;

public partial class uc_GroupUserDetail : DevExpress.XtraEditors.XtraUserControl
{
    private uc_GroupUser parent_form;

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

    private async Task<bool> SaveGroupUser(bool isEdit)
    {
        string strErr = "";
        try
        {
            SYS_tblGroupUserDTO item = new SYS_tblGroupUserDTO
            {
                GroupID = txtGroupID.Text,
                GroupCode = txtGroupCode.Text,
                VNName = txtVNName.Text,
                ENName = txtENName.Text,
                Note = mmoNote.Text,
                IsDefault = chkIsDefault.Checked,
                Active = chkActive.Checked,
                Activity = (isEdit) ? BaseConstant.UPDATE_COMMAND : BaseConstant.INSERT_COMMAND,
                Username = CommonEngine.userInfo.Username,
                LanguageID = ConfigEngine.Language
            };
            strErr = await SYS_tblGroupUserBUS.InsertUpdateGroupUser(item);
            if (!string.IsNullOrEmpty(strErr))
            {
                CommonEngine.ShowMessage(strErr, 0);
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

    public uc_GroupUserDetail()
    {
        InitializeComponent();
        Initialize();
    }

    public uc_GroupUserDetail(uc_GroupUser _parent_form)
    {
        InitializeComponent();
        Initialize();
        parent_form = _parent_form;
    }

    private void txtGroupCode_EditValueChanged(object sender, EventArgs e)
    {
        if (txtGroupCode.Text.Contains(" "))
            depError.SetError(txtGroupCode, LanguageEngine.GetMessageCaption("000004", ConfigEngine.Language));
        else depError.SetError(txtGroupCode, (string.IsNullOrEmpty(txtGroupCode.Text)) ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : null);
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
}