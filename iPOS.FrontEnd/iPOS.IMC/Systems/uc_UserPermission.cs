using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iPOS.IMC.Helper;
using DevExpress.XtraTreeList.Nodes;
using iPOS.IMC.Tool;
using DevExpress.XtraTreeList.Columns;
using iPOS.DTO.Systems;
using iPOS.BUS.Systems;
using iPOS.Core.Helper;
using System.Linq;
using System.Threading.Tasks;
using iPOS.DRO.Systems;

namespace iPOS.IMC.Systems
{
    public partial class uc_UserPermission : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        TreeListNode groupNode, userNode, rootNode = null;
        #endregion

        #region [Personal Methods]
        public void ChangeLanguage(string language)
        {
            LanguageEngine.ChangeCaptionBarLargeButtonItem(this.Name, language, new DevExpress.XtraBars.BarLargeButtonItem[] { btnSave, btnClose });
            LanguageEngine.ChangeCaptionTreeList(this.Name, language, trlPermission);
            LanguageEngine.ChangeCaptionDockPanel(this.Name, language, dplLeft);
            LanguageEngine.ChangeCaptionGroupControl(this.Name, language, grpMain);

            LoadAllGroupUser();
            LoadAllUserLevel();

            chkAllowAll.CheckedChanged += delegate(object sender, EventArgs e) { chkNode_CheckedChanged(sender, e, new TreeListColumn[] { tlcAllowAll, tlcAllowInsert, tlcAllowUpdate, tlcAllowDelete, tlcAllowAccess, tlcAllowPrint, tlcAllowImport, tlcAllowExport }); };
            chkAllowInsert.CheckedChanged += delegate(object sender, EventArgs e) { chkNode_CheckedChanged(sender, e, tlcAllowInsert); };
            chkAllowUpdate.CheckedChanged += delegate(object sender, EventArgs e) { chkNode_CheckedChanged(sender, e, tlcAllowUpdate); };
            chkAllowDelete.CheckedChanged += delegate(object sender, EventArgs e) { chkNode_CheckedChanged(sender, e, tlcAllowDelete); };
            chkAllowAccess.CheckedChanged += delegate(object sender, EventArgs e) { chkNode_CheckedChanged(sender, e, tlcAllowAccess); };
            chkAllowPrint.CheckedChanged += delegate(object sender, EventArgs e) { chkNode_CheckedChanged(sender, e, tlcAllowPrint); };
            chkAllowImport.CheckedChanged += delegate(object sender, EventArgs e) { chkNode_CheckedChanged(sender, e, tlcAllowImport); };
            chkAllowExport.CheckedChanged += delegate(object sender, EventArgs e) { chkNode_CheckedChanged(sender, e, tlcAllowExport); };
        }

        private void chkNode_CheckedChanged(object sender, EventArgs e, TreeListColumn column)
        {
            trlPermission.PostEditor();
            TreeListNode node = trlPermission.FocusedNode;
            TreeListChangeChildNodesOperation operation = new TreeListChangeChildNodesOperation(column, node, (sender as CheckEdit).Checked);
            trlPermission.NodesIterator.DoOperation(operation);
        }

        private void chkNode_CheckedChanged(object sender, EventArgs e, TreeListColumn[] columns)
        {
            trlPermission.PostEditor();
            TreeListNode node = trlPermission.FocusedNode;
            TreeListChangeChildNodesOperation operation;
            foreach (TreeListColumn column in columns)
            {
                operation = new TreeListChangeChildNodesOperation(column, node, (sender as CheckEdit).Checked);
                trlPermission.NodesIterator.DoOperation(operation);
                node.SetValue(column, (sender as CheckEdit).Checked);
            }
        }

        private async void LoadAllGroupUser()
        {
            trlUser.ClearNodes();
            try
            {
                trlUser.BeginUnboundLoad();
                SYS_tblGroupUserDRO groupUser = await SYS_tblGroupUserBUS.GetAllGroupUsers(CommonEngine.userInfo.UserID, ConfigEngine.Language, false, null);
                if (!CommonEngine.CheckValidResponseItem(groupUser.ResponseItem)) return;
                SYS_tblUserDRO users = await SYS_tblUserBUS.GetAllUsers(CommonEngine.userInfo.UserID, ConfigEngine.Language, null);
                if (!CommonEngine.CheckValidResponseItem(users.ResponseItem)) return;
                foreach (var item in groupUser.GroupUserList)
                {
                    groupNode = trlUser.AppendNode(new object[] { string.Format(@"{0} - {1}", item.GroupCode, item.GroupName), item.GroupID }, -1);
                    groupNode.ImageIndex = 0;
                    groupNode.SelectImageIndex = 0;
                    LoadAllUser(groupNode, item.GroupID, users.UserList);
                }
                trlUser.EndUnboundLoad();
                trlUser.ExpandAll();
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
                return;
            }
        }

        private async void LoadAllUserLevel()
        {
            SYS_tblUserLevelDRO userLevel = new SYS_tblUserLevelDRO();
            userLevel = await SYS_tblUserLevelBUS.GetAllUserLevel(CommonEngine.userInfo.UserID, ConfigEngine.Language);
            if (!CommonEngine.CheckValidResponseItem(userLevel.ResponseItem)) return;
            gluUserLevel.DataSource = userLevel.UserLevelList;
            gluUserLevel.DisplayMember = "UserLevelName";
            gluUserLevel.ValueMember = "UserLevelID";
        }

        private void LoadAllUser(TreeListNode group_node, string group_id, List<SYS_tblUserDTO> user_list)
        {
            string strFullName = "";
            try
            {
                trlUser.BeginUnboundLoad();
                var users = (from user in user_list
                             where user.GroupID.Equals(group_id)
                             select user).ToList();
                foreach (var user in users)
                {
                    strFullName = (!string.IsNullOrEmpty(user.FullName)) ? " - " + user.FullName : "";
                    userNode = trlUser.AppendNode(new object[] { string.Format(@"{0}{1}", user.Username, strFullName), user.Username }, group_node);
                    userNode.ImageIndex = 1;
                    userNode.SelectImageIndex = 1;
                }
                trlUser.EndUnboundLoad();
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
                return;
            }
        }

        private async Task LoadPermission(string id, string parent_id, TreeListNode parent_node, bool is_user)
        {
            try
            {
                TreeListNode child_node;
                trlPermission.BeginUnboundLoad();
                SYS_tblPermissionDRO permissionList = await SYS_tblPermissionBUS.GetPermissionList(CommonEngine.userInfo.UserID, ConfigEngine.Language, id, parent_id, is_user);
                if (CommonEngine.CheckValidResponseItem(permissionList.ResponseItem))
                {
                    foreach (var item in permissionList.PermissionList)
                    {
                        child_node = trlPermission.AppendNode(new object[] { item.FunctionName, item.AllowAll, item.AllowInsert, item.AllowUpdate, item.AllowDelete, item.AllowAccess, item.AllowPrint, item.AllowImport, item.AllowExport, item.UserLevelID, item.Note, item.ID, item.FunctionID, item.Creater, item.CreateTime, item.Editer, item.EditTime }, parent_node);
                        await LoadPermission(id, item.FunctionID, child_node, is_user);
                    }
                }
                trlPermission.EndUnboundLoad();
                trlPermission.ExpandAll();
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
                return;
            }
        }

        private List<SYS_tblPermissionDTO> GetAllPermission(TreeListNodes nodes)
        {
            List<SYS_tblPermissionDTO> permissionList = new List<SYS_tblPermissionDTO>();
            foreach (TreeListNode node in nodes)
            {
                permissionList.Add(new SYS_tblPermissionDTO
                {
                    ID = node.GetValue(tlcID) + "",
                    FunctionID = node.GetValue(tlcFunctionID) + "",
                    AllowAll = Convert.ToBoolean(node.GetValue(tlcAllowAll)),
                    AllowInsert = Convert.ToBoolean(node.GetValue(tlcAllowAll)),
                    AllowUpdate = Convert.ToBoolean(node.GetValue(tlcAllowUpdate)),
                    AllowDelete = Convert.ToBoolean(node.GetValue(tlcAllowDelete)),
                    AllowAccess = Convert.ToBoolean(node.GetValue(tlcAllowAccess)),
                    AllowPrint = Convert.ToBoolean(node.GetValue(tlcAllowPrint)),
                    AllowImport = Convert.ToBoolean(node.GetValue(tlcAllowImport)),
                    AllowExport = Convert.ToBoolean(node.GetValue(tlcAllowExport)),
                    UserLevelID = node.GetValue(tlcUserLevel) + "",
                    Note = node.GetValue(tlcNote) + ""
                });

                permissionList.AddRange(GetAllPermission(node.Nodes));
            }

            return permissionList;
        }

        private async Task SavePermission(TreeListNodes nodes, bool is_user)
        {
            List<SYS_tblPermissionDTO> permissionList = new List<SYS_tblPermissionDTO>();
            try
            {
                SYS_tblPermissionDRO result = new SYS_tblPermissionDRO();
                permissionList = GetAllPermission(nodes);
                string strMessage = LanguageEngine.GetMessageCaption("000024", ConfigEngine.Language).Replace("$Type$", is_user ? (ConfigEngine.Language.Equals("vi") ? "người dùng" : "user") : (ConfigEngine.Language.Equals("vi") ? "nhóm người dùng" : "group user")).Replace("$Name$", trlUser.FocusedNode.GetDisplayText(tlcName));

                result = await SYS_tblPermissionBUS.UpdatePermission(CommonEngine.userInfo.UserID, ConfigEngine.Language, permissionList, is_user, new SYS_tblActionLogDTO
                {
                    Activity = BaseConstant.COMMAND_INSERT_EN,
                    UserID = CommonEngine.userInfo.UserID,
                    LanguageID = ConfigEngine.Language,
                    ActionEN = BaseConstant.COMMAND_UPDATE_EN,
                    ActionVN = BaseConstant.COMMAND_UPDATE_VI,
                    FunctionID = "24",
                    DescriptionVN = strMessage.Replace("$IsError$", "thành công"),
                    DescriptionEN = strMessage.Replace("$IsError$", "successfully")
                });
                if (CommonEngine.CheckValidResponseItem(result.ResponseItem))
                {
                    if (string.IsNullOrEmpty(result.ResponseItem.Message))
                        CommonEngine.ShowMessage(strMessage.Replace("$IsError$", ConfigEngine.Language.Equals("vi") ? "thành công" : "successfully").Trim(), MessageType.Success);
                    else CommonEngine.ShowMessage(strMessage.Replace("$IsError$", ConfigEngine.Language.Equals("vi") ? "thất bại" : "failed").Trim(), MessageType.Error);
                }
                else return;
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
                return;
            }
        }
        #endregion

        #region [Form Events]
        public uc_UserPermission()
        {
            InitializeComponent();
        }

        public uc_UserPermission(string language)
        {
            InitializeComponent();
            ChangeLanguage(language);
        }

        private async void trlUser_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                trlPermission.ClearNodes();
                TreeListNode node = trlUser.FocusedNode;
                await LoadPermission(node.GetDisplayText(tlcCode) + "", "", rootNode, node.Level == 0 ? false : true);
                string result = "", tmpGroup = "", tmpUser = "";
                if (node.Level.Equals(0))
                {
                    tmpGroup = string.Format(@"  {0}: {1}", ConfigEngine.Language.Equals("vi") ? "Nhóm" : "Group", node.GetDisplayText(tlcName));
                    tmpUser = "";
                }
                else
                {
                    tmpGroup = string.Format(@"  {0}: {1}", ConfigEngine.Language.Equals("vi") ? "Nhóm" : "Group", node.ParentNode.GetDisplayText(tlcName));
                    tmpUser = string.Format(@"<br>  {0}: {1}", ConfigEngine.Language.Equals("vi") ? "Người dùng" : "User", node.GetDisplayText(tlcName));
                }
                result = string.Format(@"{0}{1}", tmpGroup, tmpUser);
                lblUserInfo.Caption = result;
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
                return;
            }
        }

        private async void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await SavePermission(trlPermission.Nodes, trlUser.FocusedNode.Level == 0 ? false : true);
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ParentForm.Close();
        }
        #endregion
    }
}
