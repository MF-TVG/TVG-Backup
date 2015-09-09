<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Groups.aspx.cs" Inherits="USAACE.eStaffing.Web.Pages.Administration.Groups" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <asp:HiddenField runat="server" ID="hdfSelectedGroupUser" />
    <h1 class="formTitle">Group Settings</h1>
    <table class="formTable">
        <colgroup>
            <col style="width: 8em;" />
            <col style="width: auto;" />
        </colgroup>
        <tbody>
            <tr>
                <td class="label">
                    Group:
                </td>
                <td>
                    <eStaffing:DropDownControl runat="server" ID="ddlGroup" AutoPostBack="true" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged" />
                </td>
            </tr>
        </tbody>
    </table>
    <h2 class="formTitle">Basic Group Settings</h2>
    <table class="formTable">
        <colgroup>
            <col style="width: 10em;" />
            <col style="width: auto;" />
        </colgroup>
        <tbody>
            <tr>
                <td class="label">
                    Group Name:
                </td>
                <td>
                    <eStaffing:TextControl runat="server" ID="txtGroupName" MaxLength="50" Width="100%" />
                </td>
            </tr>
        </tbody>
    </table>
    <h2 class="formTitle">Group Members</h2>
    <table class="formGrid">
        <colgroup>
            <col style="width: auto;" />
            <col style="width: 7em;" />
            <col style="width: auto;" />
            <col style="width: auto;" />
            <col style="width: 6em;" />
            <col style="width: 6em;" />
            <col style="width: 5em;" />
            <col style="width: 5em;" />
        </colgroup>
        <thead>
            <tr>
                <th class="left">User Name</th>
                <th>User ID</th>
                <th>Display Name</th>
                <th>E-mail Address</th>
                <th>Member</th>
                <th>Admin</th>
                <th>Edit</th>
                <th>Delete</th>
            </tr>
        </thead>
        <tbody>
    <eStaffing:RepeaterListControl runat="server" ID="dlGroupUsers" OnItemDataBound="dlGroupUsers_ItemDataBound">
        <ItemTemplate>
            <tr>
                <td class="left"><asp:Literal runat="server" ID="ltrUserName" /></td>
                <td><asp:Literal runat="server" ID="ltrUserID" /></td>
                <td><asp:Literal runat="server" ID="ltrUserDisplayName" /></td>
                <td><asp:Literal runat="server" ID="ltrUserEmailAddress" /></td>
                <td><asp:Image runat="server" ID="imgUserMember" ImageUrl="~/images/ok.gif" /></td>
                <td><asp:Image runat="server" ID="imgUserAdmin" ImageUrl="~/images/ok.gif" /></td>
                <td><asp:ImageButton runat="server" ID="imbEditGroupUser" ImageUrl="~/images/edit.gif" OnCommand="imbEditGroupUser_Command" /></td>
                <td><asp:ImageButton runat="server" ID="imbDeleteGroupUser" ImageUrl="~/images/delete.gif" OnCommand="imbDeleteGroupUser_Command" /></td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <tr>
                <td class="left" colspan="8">There are no users in this group.</td>
            </tr>
        </EmptyDataTemplate>
    </eStaffing:RepeaterListControl>
        </tbody>
    </table>
    <div class="right">
        <asp:LinkButton runat="server" ID="btnAddGroupUser" CssClass="button add" Text="Add User" OnClick="btnAddGroupUser_Click" />
    </div>
    <eStaffing:ModalPopup runat="server" ID="mpEditUser" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
        <asp:HiddenField runat="server" ID="hdfUserSID" />
        <asp:HiddenField runat="server" ID="hdfUserAuthenticationType" />
        <asp:HiddenField runat="server" ID="hdfUserIsADGroup" />
        <div class="modalPopupTitle">Add/Edit Group User</div>
        <table class="formTable">
            <colgroup>
                <col style="width: 12em;" />
                <col style="width: auto;" />
            </colgroup>
            <tbody>
                <tr runat="server" id="trFindNewUser" style="margin-bottom: 2em;">
                    <td>Find New User:</td>
                    <td style="position: relative;">
                        <eStaffing:TextControl runat="server" ID="txtUserName" Width="300" MaxLength="50" />
                        <asp:ImageButton runat="server" ID="imgUserCheck" ImageUrl="~/images/ok.gif" OnClick="imgUserCheck_Click" /><br />
                        <asp:ListBox runat="server" ID="lstUsers" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="lstUsers_SelectedIndexChanged"
                             style="position: absolute; top: 2em; width: 30em; height: 9em;" />
                    </td>
                </tr>
                <tr>
                    <td class="label">User ID:</td>
                    <td><asp:Label runat="server" ID="lblUserID" /></td>
                </tr>
                <tr>
                    <td class="label">Display Name:</td>
                    <td><asp:Label runat="server" ID="lblUserDisplayName" /></td>
                </tr>
                <tr>
                    <td class="label">E-mail Address:</td>
                    <td><asp:Label runat="server" ID="lblUserEmailAddress" /></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:CheckBox runat="server" ID="chkUserMember" Text="This user is a member of the group and should be able to take actions on behalf of this group" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:CheckBox runat="server" ID="chkUserAdmin" Text="This user is an admin for this group and can alter the members of the group" />
                    </td>
                </tr>
            </tbody>
        </table>
        <div class="right">
            <asp:LinkButton runat="server" ID="btnSaveUser" Text="Save" CssClass="button add" OnClick="btnSaveUser_Click" />
            <asp:LinkButton runat="server" ID="btnCancelUser" Text="Cancel" CssClass="button delete" CausesValidation="false" OnClick="btnCancelUser_Click" />
        </div>
    </eStaffing:ModalPopup>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnDeleteGroup" CssClass="button delete" Text="Delete Group" OnClick="btnDeleteGroup_Click" />
        <asp:LinkButton runat="server" ID="btnSaveGroup" CssClass="button save" Text="Save Group" OnClick="btnSaveGroup_Click" />
    </div>
    <eStaffing:ModalPopup runat="server" ID="mpDeleteGroupUserConfirm" CssClass="modalPopup notice" BackgroundCssClass="modalPopupBackground notice">
        <div class="modalPopupTitle">Confirm</div>
        <div>Are you sure you want to delete this user from this group?</div>
        <div class="right marginTop">
            <asp:LinkButton runat="server" ID="btnDeleteGroupUserConfirm" Text="OK" CssClass="button ok" OnClick="btnDeleteGroupUserConfirm_Click" />
            <asp:LinkButton runat="server" ID="btnDeleteGroupUserCancel" Text="Cancel" CssClass="button delete" OnClick="btnDeleteGroupUserCancel_Click" />
        </div>
    </eStaffing:ModalPopup>
    <eStaffing:ModalPopup runat="server" ID="mpDeleteGroupConfirm" CssClass="modalPopup notice" BackgroundCssClass="modalPopupBackground notice">
        <div class="modalPopupTitle">Confirm</div>
        <div>Are you sure you want to delete this group?</div>
        <div class="right marginTop">
            <asp:LinkButton runat="server" ID="btnDeleteGroupConfirm" Text="OK" CssClass="button ok" OnClick="btnDeleteGroupConfirm_Click" />
            <asp:LinkButton runat="server" ID="btnDeleteGroupCancel" Text="Cancel" CssClass="button delete" OnClick="btnDeleteGroupCancel_Click" />
        </div>
    </eStaffing:ModalPopup>
</asp:Content>
