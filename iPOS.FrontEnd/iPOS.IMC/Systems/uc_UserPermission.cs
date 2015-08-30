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

namespace iPOS.IMC.Systems
{
    public partial class uc_UserPermission : DevExpress.XtraEditors.XtraUserControl
    {
        TreeListNode groupNode, userNode, rootNode = null;

        public void ChangeLanguage(string language)
        {
            LanguageEngine.ChangeCaptionBarLargeButtonItem(this.Name, language, new DevExpress.XtraBars.BarLargeButtonItem[] { btnSave, btnClose });
            LanguageEngine.ChangeCaptionSplitContainerControl(this.Name, language, sccMain);
            LanguageEngine.ChangeCaptionTreeListColumn(this.Name, language, new DevExpress.XtraTreeList.Columns.TreeListColumn[] { tlcFunctionName, tlcAllowAll, tlcAllowInsert, tlcAllowUpdate, tlcAllowDelete, tlcAllowAccess, tlcAllowPrint, tlcAllowImport, tlcAllowExport, tlcUserLevelID, tlcNote });
            LanguageEngine.ChangeCaptionBarStaticItem(this.Name, language, new DevExpress.XtraBars.BarStaticItem[] { lblCreater, lblCreateTime, lblEditer, lblEditTime });

            LoadAllGroupUser();

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
                List<SYS_tblGroupUserDTO> groupUserList = await SYS_tblGroupUserBUS.GetAllGroupUsers(CommonEngine.userInfo.UserID, ConfigEngine.Language, false, null);
                List<SYS_tblUserDTO> userList = await SYS_tblUserBUS.GetAllUsers(CommonEngine.userInfo.UserID, ConfigEngine.Language, null);
                foreach (var item in groupUserList)
                {
                    groupNode = trlUser.AppendNode(new object[] { string.Format(@"{0} - {1}", item.GroupCode, item.GroupName), item.GroupID }, -1);
                    groupNode.ImageIndex = 0;
                    groupNode.SelectImageIndex = 0;
                    LoadAllUser(groupNode, item.GroupID, userList);
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

        public uc_UserPermission()
        {
            InitializeComponent();
        }

        public uc_UserPermission(string language)
        {
            InitializeComponent();
            ChangeLanguage(language);
        }
    }
}
