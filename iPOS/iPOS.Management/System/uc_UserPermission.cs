using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iPOS.BUS.System;
using iPOS.Management.Common;
using Commons = iPOS.Management.Common.Common;
using iPOS.DTO.System;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;

public partial class uc_UserPermission : DevExpress.XtraEditors.XtraUserControl
{
    SYS_tblUserBUS busUser;
    SYS_tblGroupUserBUS busGroup;
    SYS_tblPermissionBUS busPermission;
    TreeListNode groupNode, userNode, rootNode = null;

    private void Initialize()
    {
        busUser = new SYS_tblUserBUS();
        busGroup = new SYS_tblGroupUserBUS();
        busPermission = new SYS_tblPermissionBUS();

        LoadAllGroupUser();

        chkAll.CheckedChanged += delegate(object sender, EventArgs e) { chkNode_CheckedChanged(sender, e, new TreeListColumn[] { tlcAllowAll, tlcAllowInsert, tlcAllowUpdate, tlcAllowDelete, tlcAllowAccess, tlcAllowPrint, tlcAllowImport, tlcAllowExport }); };
        chkInsert.CheckedChanged += delegate(object sender, EventArgs e) { chkNode_CheckedChanged(sender, e, tlcAllowInsert); };
        chkUpdate.CheckedChanged += delegate(object sender, EventArgs e) { chkNode_CheckedChanged(sender, e, tlcAllowUpdate); };
        chkDelete.CheckedChanged += delegate(object sender, EventArgs e) { chkNode_CheckedChanged(sender, e, tlcAllowDelete); };
        chkAccess.CheckedChanged += delegate(object sender, EventArgs e) { chkNode_CheckedChanged(sender, e, tlcAllowAccess); };
        chkPrint.CheckedChanged += delegate(object sender, EventArgs e) { chkNode_CheckedChanged(sender, e, tlcAllowPrint); };
        chkImport.CheckedChanged += delegate(object sender, EventArgs e) { chkNode_CheckedChanged(sender, e, tlcAllowImport); };
        chkExport.CheckedChanged += delegate(object sender, EventArgs e) { chkNode_CheckedChanged(sender, e, tlcAllowExport); };
    }

    private void LoadAllGroupUser()
    {
        trlUser.ClearNodes();
        try
        {
            trlUser.BeginUnboundLoad();
            DataTable groups = new DataTable();
            groups = busGroup.LoadAllData(User.UserInfo.Username, User.UserInfo.LanguageID);
            foreach (DataRow item in groups.Rows)
            {
                groupNode = trlUser.AppendNode(new object[] { item["GroupCode"] + " - " + item["GroupName"], item["GroupID"] }, -1);
                groupNode.ImageIndex = 0;
                groupNode.SelectImageIndex = 0;
                LoadAllUser(groupNode, item["GroupID"] + "");
            }
            trlUser.EndUnboundLoad();
            trlUser.ExpandAll();
        }
        catch (Exception ex)
        {
            Commons.ShowExceptionMessage(ex);
            return;
        }
    }

    private void LoadAllUser(TreeListNode group_node, string group_id)
    {
        string strFullName = "";
        try
        {
            trlUser.BeginUnboundLoad();
            DataTable users = new DataTable();
            users = busUser.LoadAllData(User.UserInfo.Username, User.UserInfo.LanguageID, group_id);
            foreach (DataRow item in users.Rows)
            {
                strFullName = (!item["FullName"].Equals("")) ? " - " + item["FullName"] : "";
                userNode = trlUser.AppendNode(new object[] { item["Username"] + strFullName, item["Username"] }, group_node);
                userNode.ImageIndex = 1;
                userNode.SelectImageIndex = 1;
            }
            trlUser.EndUnboundLoad();
        }
        catch (Exception ex)
        {
            Commons.ShowExceptionMessage(ex);
            return;
        }
    }

    private void LoadPermission(string id, string parent, TreeListNode parentNode, int type)
    {
        try
        {
            TreeListNode childNode;
            trlPermission.BeginUnboundLoad();
            DataTable dt = new DataTable();
            dt = busPermission.GetDataByGroupOrUser(User.UserInfo.Username, User.UserInfo.LanguageID, id, parent, type);
            foreach (DataRow dr in dt.Rows)
            {
                childNode = trlPermission.AppendNode(new object[] { dr["FunctionName"], dr["AllowAll"], dr["AllowInsert"], dr["AllowUpdate"], dr["AllowDelete"], dr["AllowAccess"], dr["AllowPrint"], dr["AllowImport"], dr["AllowExport"], dr["UserLevelID"], dr["Note"], dr["ID"], dr["FunctionID"] }, parentNode);

                LoadPermission(id, dr["FunctionID"] + "", childNode, type);
            }
            trlPermission.EndUnboundLoad();
            trlPermission.ExpandAll();
        }
        catch (Exception ex)
        {
            Commons.ShowExceptionMessage(ex);
            return;
        }
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

    private bool SaveAllPermission(TreeListNodes parent_node, int type)
    {
        string strError = "";
        try
        {
            SYS_tblPermissionDTO item;
            foreach (TreeListNode node in parent_node)
            {
                item = new SYS_tblPermissionDTO
                {
                    Username = User.UserInfo.Username,
                    LanguageID = User.UserInfo.LanguageID,
                    GroupID = node.GetValue(tlcID) + "",
                    UserName = node.GetValue(tlcID) + "",
                    FunctionID = node.GetValue(tlcFunctionID) + "",
                    AllowInsert = Convert.ToBoolean(node.GetValue(tlcAllowInsert)),
                    AllowUpdate = Convert.ToBoolean(node.GetValue(tlcAllowUpdate)),
                    AllowDelete = Convert.ToBoolean(node.GetValue(tlcAllowDelete)),
                    AllowAccess = Convert.ToBoolean(node.GetValue(tlcAllowAccess)),
                    AllowPrint = Convert.ToBoolean(node.GetValue(tlcAllowPrint)),
                    AllowImport = Convert.ToBoolean(node.GetValue(tlcAllowImport)),
                    AllowExport = Convert.ToBoolean(node.GetValue(tlcAllowExport)),
                    UserLevelID = null,
                    Note = node.GetValue(tlcNote) + ""
                };
                strError = busPermission.SavePermission(item, type);

                SaveAllPermission(node.Nodes, type);
            }
            if (!strError.Equals(""))
            {
                Commons.ShowMessage(strError, 0);
                return false;
            }
        }
        catch (Exception ex)
        {
            Commons.ShowExceptionMessage(ex);
            return false;
        }
        return true;
    }

    public uc_UserPermission()
    {
        InitializeComponent();
        Initialize();
    }

    private void trlUser_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
    {
        try
        {
            trlPermission.ClearNodes();
            TreeListNode node = trlUser.FocusedNode;
            LoadPermission(node.GetDisplayText(tlcCode) + "", "", rootNode, node.Level);
        }
        catch (Exception ex)
        {
            Commons.ShowExceptionMessage(ex);
            return;
        }
    }

    private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        if (SaveAllPermission(trlPermission.Nodes, trlUser.FocusedNode.Level))
            Commons.ShowMessage((User.UserInfo.LanguageID.Equals("VN")) ? "Cập nhật phân quyền dữ liệu thành công." : "Update permission successfully.", 1);
    }
}