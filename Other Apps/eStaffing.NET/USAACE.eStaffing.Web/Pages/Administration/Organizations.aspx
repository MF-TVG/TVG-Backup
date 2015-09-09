<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Organizations.aspx.cs" Inherits="USAACE.eStaffing.Web.Pages.Administration.Organizations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h1 class="formTitle">Organization Settings</h1>
    <table class="formTable">
        <colgroup>
            <col style="width: 18em;" />
            <col style="width: auto;" />
        </colgroup>
        <tbody>
            <tr>
                <td class="label required">
                    Select an Organization:
                </td>
                <td>
                    <eStaffing:DropDownControl runat="server" ID="ddlOrganization" AutoPostBack="true" OnSelectedIndexChanged="ddlOrganization_SelectedIndexChanged" />
                </td>
            </tr>
        </tbody>
    </table>
    <h2 class="formTitle">Basic Organization Information</h2>
    <div class="label left">Organization Name:</div>
    <div><eStaffing:TextControl runat="server" ID="txtOrganizationName" MaxLength="50" Width="500" /></div>
    <h2 class="formTitle">Organization Groups</h2>
    <table class="formGrid">
        <colgroup>
            <col style="width: auto;" />
            <col style="width: 16em;" />
            <col style="width: 5em;" />
            <col style="width: 5em;" />
        </colgroup>
        <thead>
            <tr>
                <th class="left">Name</th>
                <th>User Group</th>
                <th>Edit</th>
                <th>Delete</th>
            </tr>
        </thead>
        <tbody>
            <eStaffing:RepeaterListControl runat="server" ID="dlOrganizationGroups" OnItemDataBound="dlOrganizationGroups_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td class="left"><asp:Literal runat="server" ID="ltrOrganizationGroupName" /></td>
                        <td><asp:Literal runat="server" ID="ltrOrganizationGroupGroup" /></td>
                        <td><asp:ImageButton runat="server" ID="imbEditOrganizationGroup" ImageUrl="~/images/edit.gif" OnCommand="imbEditOrganizationGroup_Command" /></td>
                        <td><asp:ImageButton runat="server" ID="imbDeleteOrganizationGroup" ImageUrl="~/images/delete.gif" OnCommand="imbDeleteOrganizationGroup_Command" /></td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <tr>
                        <td class="left" colspan="4">There are no organization groups in this organization.</td>
                    </tr>
                </EmptyDataTemplate>
            </eStaffing:RepeaterListControl>
        </tbody>
    </table>
    <div class="right">
        <asp:LinkButton runat="server" ID="btnAddOrganizationGroup" CssClass="button add" Text="Add Organization Group" OnClick="btnAddOrganizationGroup_Click" />
    </div>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnSaveOrganization" CssClass="button save" Text="Save Organization" OnClick="btnSaveOrganization_Click" />
    </div>
    <eStaffing:ModalPopup runat="server" ID="mpEditOrganizationGroup" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
        <div class="modalPopupTitle">Add/Edit Organization Group</div>
        <div>Organization Group Name:</div>
        <div><eStaffing:TextControl runat="server" ID="txtOrganizationGroupName" MaxLength="50" Width="100%" /></div>
        <div>Permission Group:</div>
        <div><eStaffing:DropDownControl runat="server" ID="ddlGroup" Width="100%" /></div>
        <div class="right marginTop">
            <asp:LinkButton runat="server" ID="btnSaveOrganizationGroup" Text="Save" CssClass="button save" OnClick="btnSaveOrganizationGroup_Click" />
            <asp:LinkButton runat="server" ID="btnCancelOrganizationGroup" Text="Cancel" CssClass="button delete" OnClick="btnCancelOrganizationGroup_Click" />
        </div>
    </eStaffing:ModalPopup>
    <eStaffing:ModalPopup runat="server" ID="mpDeleteOrganizationGroupConfirm" CssClass="modalPopup notice" BackgroundCssClass="modalPopupBackground notice">
        <div class="modalPopupTitle">Confirm</div>
        <div>Are you sure you want to delete this organization group?</div>
        <div class="right marginTop">
            <asp:LinkButton runat="server" ID="btnDeleteOrganizationGroupConfirm" Text="OK" CssClass="button ok" OnClick="btnDeleteOrganizationGroupConfirm_Click" />
            <asp:LinkButton runat="server" ID="btnDeleteOrganizationGroupCancel" Text="Cancel" CssClass="button delete" OnClick="btnDeleteOrganizationGroupCancel_Click" />
        </div>
    </eStaffing:ModalPopup>
</asp:Content>
