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
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.ViewInfo;

namespace iPOS.IMC.Systems
{
    public partial class uc_UserPermission : DevExpress.XtraEditors.XtraUserControl
    {
        #region [Declare Variables]
        TreeListNode groupNode, userNode, rootNode = null;
        List<SYS_tblPermissionDTO> oldPermissionList;
        List<SYS_tblGroupUserDTO> groupList;
        List<SYS_tblUserDTO> userList;
        bool isSecondLoad = false;
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
                this.Cursor = Cursors.WaitCursor;
                trlUser.BeginUnboundLoad();
                SYS_tblGroupUserDRO groupUser = await SYS_tblGroupUserBUS.GetAllGroupUsers(CommonEngine.userInfo.UserID, ConfigEngine.Language, false, null);
                if (!CommonEngine.CheckValidResponseItem(groupUser.ResponseItem)) return;
                groupList = groupUser.GroupUserList;
                SYS_tblUserDRO users = await SYS_tblUserBUS.GetAllUsers(CommonEngine.userInfo.UserID, ConfigEngine.Language, null);
                if (!CommonEngine.CheckValidResponseItem(users.ResponseItem)) return;
                userList = users.UserList;
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
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async void LoadAllUserLevel()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                SYS_tblUserLevelDRO userLevel = new SYS_tblUserLevelDRO();
                userLevel = await SYS_tblUserLevelBUS.GetAllUserLevel(CommonEngine.userInfo.UserID, ConfigEngine.Language);
                if (!CommonEngine.CheckValidResponseItem(userLevel.ResponseItem)) return;
                gluUserLevel.DataSource = userLevel.UserLevelList;
                gluUserLevel.DisplayMember = "UserLevelName";
                gluUserLevel.ValueMember = "UserLevelID";
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void LoadAllUser(TreeListNode group_node, string group_id, List<SYS_tblUserDTO> user_list)
        {
            string strFullName = "";
            try
            {
                this.Cursor = Cursors.WaitCursor;
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
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async Task LoadPermission(string id, TreeListNode parent_node, bool is_user)
        {
            try
            {
                if (isSecondLoad) CommonEngine.ShowWaitForm(this);
                trlPermission.BeginUnboundLoad();
                trlPermission.ClearNodes();
                SYS_tblPermissionDRO permissionList = await SYS_tblPermissionBUS.GetPermissionList(CommonEngine.userInfo.UserID, ConfigEngine.Language, id, is_user);
                if (CommonEngine.CheckValidResponseItem(permissionList.ResponseItem))
                {
                    oldPermissionList = new List<SYS_tblPermissionDTO>();
                    foreach (var item in permissionList.PermissionList)
                    {
                        oldPermissionList.Add(item);
                    }
                    LoadPermission(permissionList.PermissionList, "", parent_node);
                }
                trlPermission.EndUnboundLoad();
                trlPermission.ExpandAll();
                if (isSecondLoad) CommonEngine.CloseWaitForm();
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
            }

            if (!isSecondLoad) isSecondLoad = true;
        }

        private void LoadPermission(List<SYS_tblPermissionDTO> permissions, string parent_id, TreeListNode parent_node)
        {
            try
            {
                TreeListNode child_node;
                var tmp = permissions;
                var nodes = (from per in tmp
                             where per.ParentID == parent_id
                             select per).ToList();
                tmp.RemoveAll(per => per.ParentID == parent_id);
                foreach (var node in nodes)
                {
                    child_node = trlPermission.AppendNode(new object[] { node.FunctionName, node.AllowAll, node.AllowInsert, node.AllowUpdate, node.AllowDelete, node.AllowAccess, node.AllowPrint, node.AllowImport, node.AllowExport, node.UserLevelID, node.Note, node.ID, node.FunctionID, node.Creater, node.CreateTime, node.Editer, node.EditTime }, parent_node);
                    LoadPermission(tmp, node.FunctionID, child_node);
                }
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
            }
        }

        private List<SYS_tblPermissionDTO> GetAllPermission(TreeListNodes nodes)
        {
            List<SYS_tblPermissionDTO> permissionList = new List<SYS_tblPermissionDTO>();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                foreach (TreeListNode node in nodes)
                {
                    permissionList.Add(new SYS_tblPermissionDTO
                    {
                        ID = node.GetValue(tlcID) + "",
                        FunctionID = node.GetValue(tlcFunctionID) + "",
                        AllowAll = Convert.ToBoolean(node.GetValue(tlcAllowAll)),
                        AllowInsert = Convert.ToBoolean(node.GetValue(tlcAllowInsert)),
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
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            return permissionList;
        }

        private async Task SavePermission(TreeListNodes nodes, bool is_user)
        {
            List<SYS_tblPermissionDTO> permissionList = new List<SYS_tblPermissionDTO>();
            try
            {
                CommonEngine.ShowWaitForm(this);
                SYS_tblPermissionDRO result = new SYS_tblPermissionDRO();
                permissionList = GetAllPermission(nodes);

                foreach (var item in oldPermissionList)
                {
                    var _item = (from per in permissionList
                                 where per.ID == item.ID && per.FunctionID == item.FunctionID
                                 select per).FirstOrDefault();
                    if (_item != null)
                    {
                        if (_item.AllowInsert == item.AllowInsert && _item.AllowUpdate == item.AllowUpdate
                        && _item.AllowDelete == item.AllowDelete && _item.AllowPrint == item.AllowPrint
                        && _item.AllowImport == item.AllowImport && _item.AllowExport == item.AllowExport
                        && _item.AllowAll == item.AllowAll && _item.AllowAccess == item.AllowAccess
                        && _item.UserLevelID == item.UserLevelID && _item.Note == item.Note)
                            permissionList.Remove(_item);
                    }
                }

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
                CommonEngine.CloseWaitForm();
                if (CommonEngine.CheckValidResponseItem(result.ResponseItem))
                {
                    if (string.IsNullOrEmpty(result.ResponseItem.Message))
                        CommonEngine.ShowMessage(strMessage.Replace("$IsError$", ConfigEngine.Language.Equals("vi") ? "thành công" : "successfully").Trim(), MessageType.Success);
                    else CommonEngine.ShowMessage(strMessage.Replace("$IsError$", ConfigEngine.Language.Equals("vi") ? "thất bại" : "failed").Trim(), MessageType.Error);

                    await LoadPermission(trlUser.FocusedNode.GetDisplayText(tlcCode) + "", rootNode, trlUser.FocusedNode.Level == 0 ? false : true);
                }
                else return;
            }
            catch (Exception ex)
            {
                CommonEngine.ShowExceptionMessage(ex);
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
            CommonEngine.ShowWaitForm(this);
            InitializeComponent();
            ChangeLanguage(language);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CommonEngine.CloseWaitForm();
        }

        private async void trlUser_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                trlPermission.ClearNodes();
                TreeListNode node = trlUser.FocusedNode;
                //CommonEngine.ShowWaitForm(this);
                await LoadPermission(node.GetDisplayText(tlcCode) + "", rootNode, node.Level == 0 ? false : true);
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
            finally
            {
                //CommonEngine.CloseWaitForm();
            }
        }

        private void trlPermission_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            if (e.Column == tlcFunctionName && e.Node == trlPermission.FocusedNode)
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
        }

        private void trlUser_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            if (e.Node == trlUser.FocusedNode)
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
        }

        private async void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await SavePermission(trlPermission.Nodes, trlUser.FocusedNode.Level == 0 ? false : true);
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ParentForm.Close();
        }

        private void ttcUserInfo_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            //if (e.SelectedControl is DevExpress.XtraTreeList.TreeList)
            //{
            //    TreeList tree = (TreeList)e.SelectedControl;
            //    TreeListHitInfo hit = tree.CalcHitInfo(e.ControlMousePosition);
            //    if (hit.HitInfoType == HitInfoType.Cell)
            //    {
            //        object cellInfo = new TreeListCellToolTipInfo(hit.Node, hit.Column, null);
            //        string toolTip = "";
            //        e.Info = new DevExpress.Utils.ToolTipControlInfo(cellInfo, toolTip);
            //        //Group user
            //        if (hit.Node.Level == 0)
            //        {
            //            var groupItem = (from item in groupList
            //                             where item.GroupID == hit.Node.GetValue(tlcCode) + ""
            //                             select item).FirstOrDefault();
            //            e.Info.Title = hit.Node.GetDisplayText(tlcName) + "";
            //            toolTip = string.Format("{0}: {1}\n{2}: {3}");
            //        }

            //        //string toolTip = string.Format("{0} (Column: {1}, Node ID: {2})", hit.Node[hit.Column], hit.Column.Caption, hit.Node.Id);

            //        //e.Info = new DevExpress.Utils.ToolTipControlInfo(cellInfo, toolTip);

            //        //e.Info.Title = "Item";
            //        //e.Info.Text = toolTip;
            //        //e.Info.IconType = DevExpress.Utils.ToolTipIconType.Information;

            //    }

            //}
        }
        #endregion
    }
}