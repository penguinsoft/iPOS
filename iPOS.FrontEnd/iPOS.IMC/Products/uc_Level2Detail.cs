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
    public partial class uc_Level2Detail : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        private uc_Level2 parent_form;
        #endregion

        #region [Personal Methods]
        private void Initialize()
        {
            LanguageEngine.ChangeCaptionLayoutControlGroup(this.Name, ConfigEngine.Language, logDetail);
            LanguageEngine.ChangeCaptionLayoutControlItem(this.Name, ConfigEngine.Language, new DevExpress.XtraLayout.LayoutControlItem[] { lciLevel2Code, lciLevel2ShortCode, lciVNName, lciENName, lciLevel1, lciRank, lciNote, lciDescription });
            LanguageEngine.ChangeCaptionCheckEdit(this.Name, ConfigEngine.Language, chkUsed);
            LanguageEngine.ChangeCaptionSimpleButton(this.Name, ConfigEngine.Language, new SimpleButton[] { btnSaveClose, btnSaveInsert, btnCancel });
            LanguageEngine.ChangeCaptionGridLookUpEdit(this.Name, ConfigEngine.Language, gluLevel1);

            LoadLevel1();
        }

        private bool CheckValidate()
        {
            if (string.IsNullOrEmpty(txtLevel2Code.Text.Trim()))
            {
                depError.SetError(txtLevel2Code, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                txtLevel2Code.Focus();
                return false;
            }
            else if (txtLevel2Code.Text.Contains(" "))
            {
                depError.SetError(txtLevel2Code, LanguageEngine.GetMessageCaption("000004", ConfigEngine.Language));
                txtLevel2Code.Focus();
                return false;
            }
            else if (CommonEngine.CheckExistsUnicodeChar(txtLevel2Code.Text.Trim()))
            {
                depError.SetError(txtLevel2Code, LanguageEngine.GetMessageCaption("000021", ConfigEngine.Language));
                txtLevel2Code.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtLevel2ShortCode.Text.Trim()))
            {
                depError.SetError(txtLevel2ShortCode, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                txtLevel2ShortCode.Focus();
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
            else if (string.IsNullOrEmpty(gluLevel1.EditValue + "") || gluLevel1.EditValue.Equals("0"))
            {
                depError.SetError(gluLevel1, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                gluLevel1.Focus();
                return false;
            }

            return true;
        }

        private async void LoadLevel1()
        {
            PRO_tblLevel1DRO level1s = await PRO_tblLevel1BUS.GetAllLevel1(CommonEngine.userInfo.UserID, ConfigEngine.Language, true, null);
            gluLevel1.DataBindings.Clear();
            if (level1s.ResponseItem.IsError)
            {
                CommonEngine.ShowHTTPErrorMessage(level1s.ResponseItem);
                return;
            }
            gluLevel1.Properties.DataSource = level1s.Level1List;
            gluLevel1.Properties.ValueMember = "Level1ID";
            gluLevel1.Properties.DisplayMember = "FullLevel1Name";
        }

        private async Task<bool> SaveLevel2(bool isEdit)
        {
            CommonEngine.ShowWaitForm(this);
            PRO_tblLevel2DRO result = new PRO_tblLevel2DRO();
            try
            {
                result = await PRO_tblLevel2BUS.InsertUpdateLevel2(new PRO_tblLevel2DTO
                {
                    Level2ID = isEdit ? txtLevel2ID.Text : "0",
                    Level2Code = txtLevel2Code.Text.Trim(),
                    Level2ShortCode = txtLevel2ShortCode.Text.Trim(),
                    Level1ID = gluLevel1.EditValue + "",
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
                    FunctionID = "21",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa {1} thành công nhóm hàng có mã nhóm hàng là '{2}'.", CommonEngine.userInfo.UserID, isEdit ? "cập nhật" : "thêm mới", txtLevel2Code.Text),
                    DescriptionEN = string.Format("Account '{0}' has {1} product group successfully with group code is '{2}'.", CommonEngine.userInfo.UserID, isEdit ? "updated" : "inserted", txtLevel2Code.Text)
                });

                if (CommonEngine.CheckValidResponseItem(result.ResponseItem))
                {
                    if (!string.IsNullOrEmpty(result.ResponseItem.Message))
                    {
                        CommonEngine.CloseWaitForm();
                        CommonEngine.ShowMessage(result.ResponseItem.Message, 0);
                        txtLevel2Code.Focus();
                        return false;
                    }
                    else if (parent_form != null) parent_form.GetAllLevel2("");
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

        private void LoadDataToEdit(PRO_tblLevel2DTO item)
        {
            txtLevel2ID.EditValue = item == null ? null : item.Level2ID;
            txtLevel2Code.EditValue = item == null ? null : item.Level2Code;
            txtLevel2ShortCode.EditValue = item == null ? null : item.Level2ShortCode;
            txtVNName.EditValue = item == null ? null : item.VNName;
            txtENName.EditValue = item == null ? null : item.ENName;
            speRank.EditValue = item == null ? null : item.Rank;
            chkUsed.Checked = item == null ? true : item.Used;
            mmoDescription.EditValue = item == null ? null : item.Description;
            mmoNote.EditValue = item == null ? null : item.Note;
            gluLevel1.EditValue = item == null ? null : item.Level1ID;
            if (item == null)
            {
                depError.ClearErrors();
                this.ParentForm.Text = LanguageEngine.GetOpenFormText(this.Name, ConfigEngine.Language, false);
                txtLevel2Code.Focus();
            }
        }
        #endregion

        #region [Form Events]
        public uc_Level2Detail()
        {
            InitializeComponent();
            Initialize();
            CommonEngine.LoadUserPermission("21", txtLevel2ID, btnSaveClose, btnSaveInsert);
        }

        public uc_Level2Detail(uc_Level2 _parent_form, PRO_tblLevel2DTO item = null)
        {
            CommonEngine.ShowWaitForm(this);
            InitializeComponent();
            Initialize();
            parent_form = _parent_form;

            if (item != null)
                LoadDataToEdit(item);
            CommonEngine.LoadUserPermission("21", txtLevel2ID, btnSaveClose, btnSaveInsert);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CommonEngine.CloseWaitForm();
            BeginInvoke(new MethodInvoker(() =>
            {
                if (!string.IsNullOrEmpty(txtLevel2ID.Text))
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

        private void txtLevel2Code_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLevel2Code.Text.Trim()))
                depError.SetError(txtLevel2Code, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
            else if (txtLevel2Code.Text.Contains(" "))
                depError.SetError(txtLevel2Code, LanguageEngine.GetMessageCaption("000004", ConfigEngine.Language));
            else if (CommonEngine.CheckExistsUnicodeChar(txtLevel2Code.Text.Trim()))
                depError.SetError(txtLevel2Code, LanguageEngine.GetMessageCaption("000021", ConfigEngine.Language));
            else depError.SetError(txtLevel2Code, null);
        }

        private void txtLevel2ShortCode_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtLevel2ShortCode, string.IsNullOrEmpty(txtLevel2ShortCode.Text.Trim()) ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : null);
        }

        private void txtLevel2ShortCode_Leave(object sender, EventArgs e)
        {
            txtLevel2ShortCode.Text = CommonEngine.OnlyGetNumberText(txtLevel2ShortCode.Text).PadLeft(2, '0');
        }

        private void txtVNName_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtVNName, string.IsNullOrEmpty(txtVNName.Text.Trim()) ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : null);
        }

        private void txtENName_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtENName, string.IsNullOrEmpty(txtENName.Text.Trim()) ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : null);
        }

        private void gluLevel1_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(gluLevel1, (string.IsNullOrEmpty(gluLevel1.EditValue + "") || gluLevel1.EditValue.Equals("0")) ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : null);
        }

        private void gluLevel1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                CommonEngine.OpenInputForm(new uc_Level1Detail(), new Size(450, 300), false);
                LoadLevel1();
            }
        }

        private async void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (await SaveLevel2(!string.IsNullOrEmpty(txtLevel2ID.Text)))
                    this.ParentForm.Close();
        }

        private async void btnSaveInsert_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (await SaveLevel2(!string.IsNullOrEmpty(txtLevel2ID.Text)))
                    LoadDataToEdit(null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        #endregion
    }
}
