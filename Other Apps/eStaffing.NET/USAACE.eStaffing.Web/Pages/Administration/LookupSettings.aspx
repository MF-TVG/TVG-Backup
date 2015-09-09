<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LookupSettings.aspx.cs" Inherits="USAACE.eStaffing.Web.Pages.Administration.LookupSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h1 class="formTitle">Lookup Settings</h1>
    <table class="formTable">
        <colgroup>
            <col style="width: 20em;" />
            <col style="width: auto;" />
        </colgroup>
        <tbody>
            <tr>
                <td class="label required">Select a Form Type:</td>
                <td><eStaffing:DropDownControl runat="server" ID="ddlFormType" AutoPostBack="true" OnSelectedIndexChanged="ddlFormType_SelectedIndexChanged" /></td>
            </tr>
            <tr>
                <td class="label required">Select a Form Type Lookup:</td>
                <td><eStaffing:DropDownControl runat="server" ID="ddlFormTypeLookup" AutoPostBack="true" OnSelectedIndexChanged="ddlFormTypeLookup_SelectedIndexChanged" /></td>
            </tr>
            <tr>
                <td class="label required">Select an Organization:</td>
                <td><eStaffing:DropDownControl runat="server" ID="ddlOrganization" AutoPostBack="true" OnSelectedIndexChanged="ddlFormTypeLookup_SelectedIndexChanged" /></td>
            </tr>
        </tbody>
    </table>
    <h2 class="formTitle">Lookup Values</h2>
    <asp:GridView runat="server" ID="gvLookupValues" AutoGenerateColumns="false" CssClass="formGrid" ShowHeaderWhenEmpty="true" GridLines="None"
        OnRowCommand="gvLookupValues_RowCommand" />
    <div class="right">
        <asp:LinkButton runat="server" ID="btnAddLookupValue" CssClass="button add" Text="Add Lookup Value" OnClick="btnAddLookupValue_Click" />
    </div>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnSaveFormTypeLookup" CssClass="button save" Text="Save Lookup" OnClick="btnSaveFormTypeLookup_Click" />
    </div>
    <eStaffing:ModalPopup runat="server" ID="mpEditLookupValue" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
        <div class="modalPopupTitle">Add/Edit Lookup Value</div>
        <eStaffing:RepeaterListControl runat="server" ID="dlLookupValueFields" OnItemDataBound="dlLookupValueFields_ItemDataBound">
            <ItemTemplate>
                <div class="label left marginTopSmall"><asp:Literal runat="server" ID="ltrFieldName" />:</div>
                <div><eStaffing:TextControl runat="server" ID="txtFieldValue" Width="100%" /></div>
            </ItemTemplate>
        </eStaffing:RepeaterListControl>
        <div class="right marginTop">
            <asp:LinkButton runat="server" ID="btnSaveLookupValue" Text="Save" CssClass="button save" OnClick="btnSaveLookupValue_Click" />
            <asp:LinkButton runat="server" ID="btnCancelLookupValue" Text="Cancel" CssClass="button delete" OnClick="btnCancelLookupValue_Click" />
        </div>
    </eStaffing:ModalPopup>
    <eStaffing:ModalPopup runat="server" ID="mpDeleteLookupValueConfirm" CssClass="modalPopup notice" BackgroundCssClass="modalPopupBackground notice">
        <div class="modalPopupTitle">Confirm</div>
        <div>Are you sure you want to delete this lookup value?</div>
        <div class="right marginTop">
            <asp:LinkButton runat="server" ID="btnDeleteLookupValueConfirm" Text="OK" CssClass="button ok" OnClick="btnDeleteLookupValueConfirm_Click" />
            <asp:LinkButton runat="server" ID="btnDeleteLookupValueCancel" Text="Cancel" CssClass="button delete" OnClick="btnDeleteLookupValueCancel_Click" />
        </div>
    </eStaffing:ModalPopup>
</asp:Content>
