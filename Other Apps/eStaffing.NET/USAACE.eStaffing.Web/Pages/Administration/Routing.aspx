<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Routing.aspx.cs" Inherits="USAACE.eStaffing.Web.Pages.Administration.Routing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h1 class="formTitle">Organization Routing Settings</h1>
    <table class="formTable">
        <colgroup>
            <col style="width: 18em;" />
            <col style="width: auto;" />
            <col style="width: 18em;" />
            <col style="width: auto;" />
        </colgroup>
        <tbody>
            <tr>
                <td class="label required">
                    Select an Organization:
                </td>
                <td>
                    <eStaffing:DropDownControl runat="server" ID="ddlOrganization" AutoPostBack="true" OnSelectedIndexChanged="ddlOrganizationFormType_SelectedIndexChanged" />
                </td>
                <td class="label required">
                    Select a Form Type:
                </td>
                <td>
                    <eStaffing:DropDownControl runat="server" ID="ddlFormType" AutoPostBack="true" OnSelectedIndexChanged="ddlOrganizationFormType_SelectedIndexChanged" />
                </td>
            </tr>
        </tbody>
    </table>
    <asp:Panel runat="server" ID="pnlData">
        <h2 class="formTitle">Organization Preset Routing Chains</h2>
        <table class="formGrid">
            <colgroup>
                <col style="width: 20em;" />
                <col style="width: auto;" />
                <col style="width: 5em;" />
                <col style="width: 5em;" />
            </colgroup>
            <thead>
                <tr>
                    <th class="left">Name</th>
                    <th class="left">Routing Chain</th>
                    <th class="center">Edit</th>
                    <th class="center">Delete</th>
                </tr>
            </thead>
            <tbody>
        <eStaffing:RepeaterListControl runat="server" ID="dlOrganizationFormRoutings" OnItemDataBound="dlOrganizationFormRoutings_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td class="left">
                        <asp:Literal runat="server" ID="ltrRoutingChainName" />
                    </td>
                    <td class="left">
                        <asp:Literal runat="server" ID="ltrRoutingChainReviewers" />
                    </td>
                    <td class="center">
                        <asp:ImageButton runat="server" ID="imbEditRoutingChain" ImageUrl="~/images/edit.gif" OnCommand="imbEditRoutingChain_Command" />
                    </td>
                    <td class="center">
                        <asp:ImageButton runat="server" ID="imbDeleteRoutingChain" ImageUrl="~/images/delete.gif" OnCommand="imbDeleteRoutingChain_Command" />
                    </td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <tr>
                    <td class="left" colspan="4">There are no routing chains for this organization and form type.</td>
                </tr>
            </EmptyDataTemplate>
        </eStaffing:RepeaterListControl>
            </tbody>
        </table>
        <div class="right">
            <asp:LinkButton runat="server" ID="btnAddRoutingChain" CssClass="button add" Text="Add Routing Chain" OnClick="btnAddRoutingChain_Click" />
        </div>
        <h2 class="formTitle">Organization Forwarding Acceptance</h2>
        <table class="formGrid">
            <colgroup>
                <col style="width: 20em;" />
                <col style="width: auto;" />
                <col style="width: 5em;" />
                <col style="width: 5em;" />
            </colgroup>
            <thead>
                <tr>
                    <th class="left">Organization</th>
                    <th class="left">Routing Chain Name</th>
                    <th class="center">Edit</th>
                    <th class="center">Delete</th>
                </tr>
            </thead>
            <tbody>
        <eStaffing:RepeaterListControl runat="server" ID="dlOrganizationForwards" OnItemDataBound="dlOrganizationForwards_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td class="left">
                        <asp:Literal runat="server" ID="ltrForwardOrganizationName" />
                    </td>
                    <td class="left">
                        <asp:Literal runat="server" ID="ltrForwardRoutingChain" />
                    </td>
                    <td class="center">
                        <asp:ImageButton runat="server" ID="imbEditForwardRoutingChain" ImageUrl="~/images/edit.gif" OnCommand="imbEditForwardRoutingChain_Command" />
                    </td>
                    <td class="center">
                        <asp:ImageButton runat="server" ID="imbDeleteForwardRoutingChain" ImageUrl="~/images/delete.gif" OnCommand="imbDeleteForwardRoutingChain_Command" />
                    </td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <tr>
                    <td class="left" colspan="4">There are no forwarded packets accepted by this organization for this form type.</td>
                </tr>
            </EmptyDataTemplate>
        </eStaffing:RepeaterListControl>
            </tbody>
        </table>
        <div class="right">
            <asp:LinkButton runat="server" ID="btnAddForward" CssClass="button add" Text="Add Forward Acceptance" OnClick="btnAddForward_Click" />
        </div>
        <div class="right marginTop">
            <asp:LinkButton runat="server" ID="btnSaveRouting" CssClass="button save" Text="Save Routing" OnClick="btnSaveRouting_Click" />
        </div>
    </asp:Panel>
    <eStaffing:ModalPopup runat="server" ID="mpModifyReviewChain" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
        <div class="modalPopupTitle">Modify Review Chain</div>
        <table class="formTable">
            <colgroup>
                <col style="width: 16em;" />
                <col style="width: auto;" />
            </colgroup>
            <tbody>
                <tr>
                    <td class="label">
                        Routing Chain Name:
                    </td>
                    <td>
                        <eStaffing:TextControl runat="server" ID="txtRoutingChain" Width="100%" />
                    </td>
                </tr>
            </tbody>
        </table>
        <table class="formGrid">
            <colgroup>
                <col style="width: 2em;" />
                <col style="width: 2em;" />
                <col style="width: 5em;" />
                <col style="width: auto;" />
                <col style="width: 14em;" />
                <col class="hidePrint scrollCol" />
            </colgroup>
            <thead>
                <tr>
                    <th colspan="2" class="label center">Move</th>
                    <th class="label center">Delete</th>
                    <th class="label left">Duty</th>
                    <th class="label left">Role</th>
                    <th class="hidePrint"></th>
                </tr>
            </thead>
        </table>
        <div class="scrollGrid smallGrid">
            <table class="formGrid">
                <colgroup>
                    <col style="width: 2em;" />
                    <col style="width: 2em;" />
                    <col style="width: 5em;" />
                    <col style="width: auto;" />
                    <col style="width: 14em;" />
                </colgroup>
                <tbody>
                    <eStaffing:RepeaterListControl runat="server" ID="dlReviewOrder" OnItemDataBound="dlReviewOrder_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td class="center">
                                    <asp:ImageButton runat="server" ID="imbReviewOrderMoveUp" ImageUrl="~/images/moveup.gif" OnCommand="imbReviewOrderMoveUp_Command" />
                                </td>
                                <td class="center">
                                    <asp:ImageButton runat="server" ID="imbReviewOrderMoveDown" ImageUrl="~/images/movedown.gif" OnCommand="imbReviewOrderMoveDown_Command" />
                                </td>
                                <td class="center">
                                    <asp:ImageButton runat="server" ID="imbReviewOrderDelete" ImageUrl="~/images/delete.gif" OnCommand="imbReviewOrderDelete_Command" />
                                </td>
                                <td class="left"><asp:Literal runat="server" ID="ltrReviewOrderDuty" /></td>
                                <td class="left">
                                    <eStaffing:DropDownControl runat="server" ID="ddlReviewOrderRole" AutoPostBack="true" OnCommand="ddlReviewOrderRole_Command" Width="100%" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </eStaffing:RepeaterListControl>
                </tbody>
            </table>
        </div>
        <table class="formTable marginTopSmall">
            <colgroup>
                <col style="width: 13em;" />
                <col style="width: auto;" />
                <col style="width: 6em;" />
                <col style="width: 14em;" />
                <col style="width: 5em;" />
            </colgroup>
            <tr>
                <td>
                    <div class="label required">Add Reviewer(s):</div>
                    <div class="right">(<asp:LinkButton runat="server" ID="lkbReviewSelectAll" OnClick="lkbReviewSelectAll_Click" Text="All" /> | <asp:LinkButton runat="server" ID="lkbReviewUnselectAll" OnClick="lkbReviewUnselectAll_Click" Text="None" />)</div>
                </td>
                <td><eStaffing:CheckBoxListControl runat="server" ID="cklReviewOrderAdd" Width="100%" RepeatLayout="UnorderedList" CssClass="reviewerFilter" /></td>
                <td class="label required">Role:</td>
                <td>
                    <eStaffing:DropDownControl runat="server" ID="ddlReviewOrderRole" Width="100%" />
                </td>
                <td>
                    <asp:LinkButton runat="server" ID="btnAddReviewOrder" Text="Add" CssClass="button add" OnClick="btnAddReviewOrder_Click" />
                </td>
            </tr>
        </table>
        <div class="right marginTop">
            <asp:LinkButton runat="server" ID="btnSaveReviewOrder" Text="Save" CssClass="button save" OnClick="btnSaveReviewOrder_Click" />
            <asp:LinkButton runat="server" ID="btnCancelReviewOrder" Text="Cancel" CssClass="button delete" OnClick="btnCancelReviewOrder_Click" />
        </div>
    </eStaffing:ModalPopup>
    <eStaffing:ModalPopup runat="server" ID="mpModifyForward" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
        <div class="modalPopupTitle">Forwarded Packet Acceptance</div>
        <table class="formTable">
            <colgroup>
                <col style="width: 18em;" />
                <col style="width: auto;" />
            </colgroup>
            <tbody>
                <tr>
                    <td class="label">
                        Submitting Organization:
                    </td>
                    <td>
                        <eStaffing:DropDownControl runat="server" ID="ddlForwardOrganization" />
                    </td>
                </tr>
                <tr>
                    <td class="label">
                        Routing Chain Name:
                    </td>
                    <td>
                        <eStaffing:DropDownControl runat="server" ID="ddlForwardRouting" />
                    </td>
                </tr>
            </tbody>
        </table>
        <div class="right marginTop">
            <asp:LinkButton runat="server" ID="btnSaveReviewForward" Text="Save" CssClass="button save" OnClick="btnSaveReviewForward_Click" />
            <asp:LinkButton runat="server" ID="btnCancelReviewForward" Text="Cancel" CssClass="button delete" OnClick="btnCancelReviewForward_Click" />
        </div>
    </eStaffing:ModalPopup>
</asp:Content>
