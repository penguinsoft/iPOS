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
    public partial class uc_Level3Detail : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        private uc_Level3 parent_form;
        #endregion

        #region [Personal Methods]
        private void Initialize()
        {
            LanguageEngine.ChangeCaptionLayoutControlGroup(this.Name, ConfigEngine.Language, logDetail);
            LanguageEngine.ChangeCaptionLayoutControlItem(this.Name, ConfigEngine.Language, new DevExpress.XtraLayout.LayoutControlItem[] { lciLevel3Code, lciLevel3ShortCode, lciVNName, lciENName, lciLevel1, lciLevel2, lciRank, lciNote, lciDescription });
            LanguageEngine.ChangeCaptionCheckEdit(this.Name, ConfigEngine.Language, chkUsed);
            LanguageEngine.ChangeCaptionSimpleButton(this.Name, ConfigEngine.Language, new SimpleButton[] { btnSaveClose, btnSaveInsert, btnCancel });
            LanguageEngine.ChangeCaptionGridLookUpEdit(this.Name, ConfigEngine.Language, new GridLookUpEdit[] { gluLevel1, gluLevel2 });

            LoadLevel1();
        }

        private bool CheckValidate()
        {
            if (string.IsNullOrEmpty(txtLevel3Code.Text.Trim()))
            {
                depError.SetError(txtLevel3Code, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                txtLevel3Code.Focus();
                return false;
            }
            else if (txtLevel3Code.Text.Contains(" "))
            {
                depError.SetError(txtLevel3Code, LanguageEngine.GetMessageCaption("000004", ConfigEngine.Language));
                txtLevel3Code.Focus();
                return false;
            }
            else if (CommonEngine.CheckExistsUnicodeChar(txtLevel3Code.Text.Trim()))
            {
                depError.SetError(txtLevel3Code, LanguageEngine.GetMessageCaption("000021", ConfigEngine.Language));
                txtLevel3Code.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtLevel3ShortCode.Text.Trim()))
            {
                depError.SetError(txtLevel3ShortCode, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
                txtLevel3ShortCode.Focus();
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
            else if (string.IsNullOrEmpty(gluLevel2.EditValue + "") || gluLevel2.EditValue.Equals("0"))
            {
                depError.SetError(gluLevel2, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
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

        private async void LoadLevel2(string level1_id)
        {
            PRO_tblLevel2DRO level2s = await PRO_tblLevel2BUS.GetAllLevel2(CommonEngine.userInfo.UserID, ConfigEngine.Language, level1_id, true, null);
            gluLevel1.DataBindings.Clear();
            if (level2s.ResponseItem.IsError)
            {
                CommonEngine.ShowHTTPErrorMessage(level2s.ResponseItem);
                return;
            }
            gluLevel2.Properties.DataSource = level2s.Level2List;
            gluLevel2.Properties.ValueMember = "Level2ID";
            gluLevel2.Properties.DisplayMember = "FullLevel2Name";
        }

        private async Task<bool> SaveLevel3(bool isEdit)
        {
            PRO_tblLevel3DRO result = new PRO_tblLevel3DRO();
            try
            {
                result = await PRO_tblLevel3BUS.InsertUpdateLevel3(new PRO_tblLevel3DTO
                {
                    Level3ID = isEdit ? txtLevel3ID.Text : "0",
                    Level3Code = txtLevel3Code.Text.Trim(),
                    Level3ShortCode = txtLevel3ShortCode.Text.Trim(),
                    Level1ID = gluLevel1.EditValue + "",
                    Level2ID = gluLevel2.EditValue + "",
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
                    FunctionID = "22",
                    DescriptionVN = string.Format("Tài khoản '{0}' vừa {1} thành công phân nhóm có mã phân nhóm là '{2}'.", CommonEngine.userInfo.UserID, isEdit ? "cập nhật" : "thêm mới", txtLevel3Code.Text),
                    DescriptionEN = string.Format("Account '{0}' has {1} product subgroup successfully with subgroup code is '{2}'.", CommonEngine.userInfo.UserID, isEdit ? "updated" : "inserted", txtLevel3Code.Text)
                });

                if (result.ResponseItem.IsError)
                {
                    CommonEngine.ShowHTTPErrorMessage(result.ResponseItem);
                    txtLevel3Code.Focus();
                    return false;
                }
                if (!string.IsNullOrEmpty(result.ResponseItem.Message))
                {
                    CommonEngine.ShowMessage(result.ResponseItem.Message, MessageType.Error);
                    txtLevel3Code.Focus();
                    return false;
                }
                else parent_form.GetAllLevel3();
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
                return false;
            }

            return true;
        }

        private void LoadDataToEdit(PRO_tblLevel3DTO item)
        {
            txtLevel3ID.EditValue = item == null ? null : item.Level3ID;
            txtLevel3Code.EditValue = item == null ? null : item.Level3Code;
            txtLevel3ShortCode.EditValue = item == null ? null : item.Level3ShortCode;
            txtVNName.EditValue = item == null ? null : item.VNName;
            txtENName.EditValue = item == null ? null : item.ENName;
            speRank.EditValue = item == null ? null : item.Rank;
            chkUsed.Checked = item == null ? true : item.Used;
            mmoDescription.EditValue = item == null ? null : item.Description;
            mmoNote.EditValue = item == null ? null : item.Note;
            gluLevel1.EditValue = item == null ? null : item.Level1ID;
            gluLevel2.EditValue = item == null ? null : item.Level2ID;
            if (item == null)
            {
                depError.ClearErrors();
                this.ParentForm.Text = LanguageEngine.GetOpenFormText(this.Name, ConfigEngine.Language, false);
                txtLevel3Code.Focus();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            BeginInvoke(new MethodInvoker(() =>
            {
                if (!string.IsNullOrEmpty(txtLevel3ID.Text))
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

        public uc_Level3Detail()
        {
            InitializeComponent();
        }

        public uc_Level3Detail(uc_Level3 _parent_form, PRO_tblLevel3DTO item = null)
        {
            InitializeComponent();
            Initialize();
            parent_form = _parent_form;

            if (item != null)
                LoadDataToEdit(item);
        }

        private void txtLevel3Code_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLevel3Code.Text.Trim()))
                depError.SetError(txtLevel3Code, LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language));
            else if (txtLevel3Code.Text.Contains(" "))
                depError.SetError(txtLevel3Code, LanguageEngine.GetMessageCaption("000004", ConfigEngine.Language));
            else if (CommonEngine.CheckExistsUnicodeChar(txtLevel3Code.Text.Trim()))
                depError.SetError(txtLevel3Code, LanguageEngine.GetMessageCaption("000021", ConfigEngine.Language));
            else depError.SetError(txtLevel3Code, null);
        }

        private void txtLevel3ShortCode_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(txtLevel3ShortCode, string.IsNullOrEmpty(txtLevel3ShortCode.Text.Trim()) ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : null);
        }

        private void txtLevel3ShortCode_Leave(object sender, EventArgs e)
        {
            txtLevel3ShortCode.Text = CommonEngine.OnlyGetNumberText(txtLevel3ShortCode.Text).PadLeft(2, '0');
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
            if (gluLevel1.EditValue != null)
                LoadLevel2(gluLevel1.EditValue + "");
        }

        private void gluLevel2_EditValueChanged(object sender, EventArgs e)
        {
            depError.SetError(gluLevel2, (string.IsNullOrEmpty(gluLevel2.EditValue + "") || gluLevel2.EditValue.Equals("0")) ? LanguageEngine.GetMessageCaption("000003", ConfigEngine.Language) : null);
        }

        private void gluLevel1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                CommonEngine.OpenInputForm(new uc_Level1Detail(), new Size(450, 300), false);
                LoadLevel1();
            }
        }

        private void gluLevel2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                CommonEngine.OpenInputForm(new uc_Level2Detail(), new Size(450, 320), false);
                LoadLevel2(gluLevel1.EditValue + "");
            }
        }

        private async void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (await SaveLevel3(!string.IsNullOrEmpty(txtLevel3ID.Text)))
                    this.ParentForm.Close();
        }

        private async void btnSaveInsert_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
                if (await SaveLevel3(!string.IsNullOrEmpty(txtLevel3ID.Text)))
                    LoadDataToEdit(null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}