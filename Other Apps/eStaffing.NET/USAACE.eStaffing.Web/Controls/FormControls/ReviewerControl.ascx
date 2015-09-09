<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReviewerControl.ascx.cs" Inherits="USAACE.eStaffing.Web.Controls.FormControls.ReviewerControl" %>
<h1 class="formTitle">Review Process</h1>
<asp:Menu runat="server" ID="mnuReviewMenu" Orientation="Horizontal" SkipLinkText="" CssClass="reviewMenu hidePrint" OnMenuItemClick="mnuReviewMenu_MenuItemClick" />
<asp:Panel runat="server" ID="pnlReviewGrid" CssClass="hidePrint">
    <table class="formGrid">
        <colgroup>
            <col style="width: 3em;" />
            <col style="width: 12em;" />
            <col style="width: 8em;" />
            <col style="width: 10em;" />
            <col style="width: 6em;" />
            <col style="width: auto;" />
        </colgroup>
        <thead>
            <tr>
                <th></th>
                <th class="label left">Duty</th>
                <th class="label center">Action</th>
                <th class="label center">Date</th>
                <th class="label center">Signed</th>
                <th class="label left">Remarks</th>
            </tr>
        </thead>
        <tbody>
            <eStaffing:RepeaterListControl runat="server" ID="dlReviewers" OnItemDataBound="dlReviewers_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td class="left">
                            <asp:ImageButton runat="server" ID="imbReviewerEdit" ImageUrl="~/images/edit.gif" OnCommand="imbReviewerEdit_Command" ToolTip="Edit Review" />
                        </td>
                        <td class="left"><asp:Literal runat="server" ID="ltrReviewerDuty" /></td>
                        <td class="center"><asp:Literal runat="server" ID="ltrReviewerAction" /></td>
                        <td class="center"><asp:Literal runat="server" ID="ltrReviewerDate" /></td>
                        <td class="center">
                            <asp:ImageButton runat="server" ID="imbReviewerSigned" ImageUrl="~/images/sign.gif" OnCommand="imbReviewerSigned_Command" ToolTip="Digital Signature" />
                            <asp:Image runat="server" ID="imgReviewerDocumentSigned" ImageUrl="~/images/docsigned.gif" ToolTip="Documents Signed" />
                            <asp:Image runat="server" ID="imgReviewerAutopen" ImageUrl="~/images/autopen.gif" ToolTip="Autopen Authorized" />
                        </td>
                        <td class="left">
                            <asp:Literal runat="server" ID="ltrReviewerRemarks" />
                            <asp:TreeView runat="server" ID="trvReviewerAttachments" SkipLinkText="" ShowLines="false" Visible="false" CssClass="treeView">
                                <Nodes>
                                    <asp:TreeNode Text="Supporting Documentation" Expanded="false" SelectAction="None" />
                                </Nodes>
                            </asp:TreeView>
                        </td>
                    </tr>
                </ItemTemplate>
            </eStaffing:RepeaterListControl>
        </tbody>
    </table>
    <div class="right">
        <asp:LinkButton runat="server" ID="btnModifyOrder" Text="Modify Review Chain" CssClass="button edit" OnClick="btnModifyOrder_Click" />
        <asp:LinkButton runat="server" ID="btnForwardPacket" Text="Forward Packet" CssClass="button submit" OnClick="btnForwardPacket_Click" />
    </div>
</asp:Panel>
<asp:Panel runat="server" ID="pnlActionLog" CssClass="hidePrint">
    <table class="formGrid">
        <colgroup>
            <col style="width: 16em;" />
            <col style="width: 10em;" />
            <col style="width: 12em;" />
            <col style="width: 20em;" />
            <col style="width: auto;" />
        </colgroup>
        <thead>
            <tr>
                <th class="label left">Date</th>
                <th class="label center">Action</th>
                <th class="label center">Duty</th>
                <th class="label left">User</th>
                <th class="label left">Notes</th>
            </tr>
        </thead>
        <tbody>
            <eStaffing:RepeaterListControl runat="server" ID="dlActionLog" OnItemDataBound="dlActionLog_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td class="left"><asp:Literal runat="server" ID="ltrActionDate" /></td>
                        <td class="center"><asp:Literal runat="server" ID="ltrActionAction" /></td>
                        <td class="center"><asp:Literal runat="server" ID="ltrActionRole" /></td>
                        <td class="left"><asp:Literal runat="server" ID="ltrActionUser" /></td>
                        <td class="left"><asp:Literal runat="server" ID="ltrActionNotes" /></td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <tr>
                        <td class="left" colspan="5">There are no logged actions.</td>
                    </tr>
                </EmptyDataTemplate>
            </eStaffing:RepeaterListControl>
        </tbody>
    </table>
</asp:Panel>
<asp:Panel runat="server" ID="pnlAllReviewers" CssClass="showPrint">
    <table class="formGrid">
        <colgroup>
            <col style="width: 12em;" />
            <col style="width: 8em;" />
            <col style="width: 8em;" />
            <col style="width: 6em;" />
            <col style="width: auto;" />
        </colgroup>
        <thead>
            <tr>
                <th class="label left">Duty</th>
                <th class="label center">Action</th>
                <th class="label center">Date</th>
                <th class="label center">Signed</th>
                <th class="label left">Remarks</th>
            </tr>
        </thead>
        <tbody>
            <eStaffing:RepeaterListControl runat="server" ID="dlAllReviewers" OnItemDataBound="dlReviewers_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td class="left"><asp:Literal runat="server" ID="ltrReviewerDuty" /></td>
                        <td class="center"><asp:Literal runat="server" ID="ltrReviewerAction" /></td>
                        <td class="center"><asp:Literal runat="server" ID="ltrReviewerDate" /></td>
                        <td class="center">
                            <asp:ImageButton runat="server" ID="imbReviewerSigned" ImageUrl="~/images/sign.gif" ToolTip="Digital Signature" />
                            <asp:Image runat="server" ID="imgReviewerDocumentSigned" ImageUrl="~/images/docsigned.gif" ToolTip="Documents Signed" />
                            <asp:Image runat="server" ID="imgReviewerAutopen" ImageUrl="~/images/autopen.gif" ToolTip="Autopen Authorized" />
                        </td>
                        <td class="left"><asp:Literal runat="server" ID="ltrReviewerRemarks" /></td>
                    </tr>
                </ItemTemplate>
            </eStaffing:RepeaterListControl>
        </tbody>
    </table>
</asp:Panel>
<eStaffing:ModalPopup runat="server" ID="mpEditReview" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
    <div class="modalPopupTitle">Edit Review</div>
    <table class="formTable">
        <colgroup>
            <col style="width: 10em;" />
            <col style="width: auto;" />
            <col style="width: 10em;" />
            <col style="width: auto;" />
        </colgroup>
        <tbody>
            <tr>
                <td colspan="4">
                    <asp:ValidationSummary runat="server" ID="vsReviewStatus" ValidationGroup="ReviewStatus" CssClass="validationError" />
                </td>
            </tr>
            <tr>
                <td class="label required">Duty:</td>
                <td colspan="3"><asp:Literal runat="server" ID="ltrReviewDuty" /></td>
            </tr>
            <tr>
                <td class="label required">Action:</td>
                <td><eStaffing:DropDownControl runat="server" ID="ddlReviewAction" AutoPostBack="true" OnSelectedIndexChanged="ddlReviewAction_SelectedIndexChanged" /></td>
                <td class="label required">Action Date:</td>
                <td><asp:Literal runat="server" ID="ltrReviewDate" /></td>
            </tr>
            <tr>
                <td colspan="2"><asp:CheckBox runat="server" ID="chkReviewSigned" Text="I have signed documents (as needed)" /></td>
                <td colspan="2"><asp:CheckBox runat="server" ID="chkReviewAutopen" Text="I am authorizing autopen" /></td>
            </tr>
            <tr>
                <td colspan="4" class="label left required">Remarks:<asp:CustomValidator runat="server" ID="cvReviewRemarks" Text="*" ErrorMessage="Review Remarks is a required field if action is Reject." ValidationGroup="ReviewStatus" EnableClientScript="false" OnServerValidate="cvReviewRemarks_ServerValidate" CssClass="validationError" /></td>
            </tr>
            <tr>
                <td colspan="4"><eStaffing:HTMLEditor runat="server" ID="hteReviewRemarks" Height="150" /></td>
            </tr>
        </tbody>
    </table>
    <div class="marginTop label left required">Supporting Documents:</div>
    <div class="marginTopSmall">
        <eStaffing:FileControl runat="server" ID="ucFileControl" />
    </div>
    <asp:Panel runat="server" ID="pnlDigitalSignature">
        <div class="marginTop label left required">Digital Signature</div>
        <div class="marginTopSmall">
            * - Note: Signing this will automatically save your review and can not be edited unless you remove your signature.
        </div>
        <asp:Panel runat="server" ID="pnlSignature" CssClass="marginTopSmall">
            <asp:HiddenField runat="server" ID="hdfSignatureData" />
            <asp:Panel runat="server" ID="pnlSignatureData" Visible="false" style="display: inline-block;">
                <asp:Image runat="server" ID="imgSignatureValid" />
                <asp:Label runat="server" ID="lblSignatureName" />
                <asp:Label runat="server" ID="lblSignatureDate" />
                <asp:LinkButton runat="server" ID="btnUnsignReview" Text="Remove" CssClass="button delete" OnClick="btnUnsignReview_Click" />
                <div class="marginTopSmall">
                    <asp:Literal runat="server" ID="ltrSignatureValidText" />
                </div>
            </asp:Panel>
            <asp:LinkButton runat="server" ID="btnSignReview" Text="Sign" CssClass="button sign" OnClick="btnSignReview_Click" Visible="false" />
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlSignatureDisable" CssClass="marginTopSmall">
            Digital signature is only enabled after a review action is taken. 
        </asp:Panel>
    </asp:Panel>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnResetReview" Text="Reset" CssClass="button refresh" OnClick="btnResetReview_Click" />
        <asp:LinkButton runat="server" ID="btnNotifyReview" Text="Force Notify" CssClass="button mail" OnClick="btnNotifyReview_Click" />
        <asp:LinkButton runat="server" ID="btnSaveReview" Text="Save" CssClass="button save" OnClick="btnSaveReview_Click" />
        <asp:LinkButton runat="server" ID="btnCancelReview" Text="Cancel" CssClass="button delete" OnClick="btnCancelReview_Click" />
        <asp:LinkButton runat="server" ID="btnCloseReview" Text="Close" CssClass="button delete" OnClick="btnCancelReview_Click" />
    </div>
</eStaffing:ModalPopup>
<eStaffing:ModalPopup runat="server" ID="mpModifyReviewOrder" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
    <div class="modalPopupTitle">Modify Review Order</div>
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
            <td><eStaffing:DropDownControl runat="server" ID="ddlReviewOrderRole" Width="100%" /></td>
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
<eStaffing:ModalPopup runat="server" ID="mpForwardPacket" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
    <div class="modalPopupTitle">Forward Packet</div>
    <table class="formTable">
        <colgroup>
            <col style="width: 24em;" />
            <col style="width: auto;" />
        </colgroup>
        <tr>
            <td class="label required">Select Destination Organization:</td>
            <td><eStaffing:DropDownControl runat="server" ID="ddlForwardOrganization" AutoPostBack="true" /></td>
        </tr>
        <tr>
            <td class="label required">Select the Routing Chain:</td>
            <td><eStaffing:RadioButtonListControl runat="server" ID="rblForwardRoutingChain" RepeatLayout="Flow" /></td>
        </tr>
    </table>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnSaveForwardPacket" Text="Forward" CssClass="button submit" OnClick="btnSaveForwardPacket_Click" />
        <asp:LinkButton runat="server" ID="btnCancelForwardPacket" Text="Cancel" CssClass="button delete" OnClick="btnCancelForwardPacket_Click" />
    </div>
</eStaffing:ModalPopup>
<eStaffing:ModalPopup runat="server" ID="mpReviewResetConfirm" CssClass="modalPopup notice" BackgroundCssClass="modalPopupBackground notice">
    <div class="modalPopupTitle">Confirm Review Reset</div>
    <div>This is a permanent action and cannot be undone. Any digital signature present will be deleted as well. Continue with review reset?</div>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnResetReviewConfirm" Text="OK" CssClass="button ok" OnClick="btnResetReviewConfirm_Click" />
        <asp:LinkButton runat="server" ID="btnResetReviewCancel" Text="Cancel" CssClass="button delete" OnClick="btnResetReviewCancel_Click" />
    </div>
</eStaffing:ModalPopup>
<eStaffing:ModalPopup runat="server" ID="mpUnsignConfirm" CssClass="modalPopup notice" BackgroundCssClass="modalPopupBackground notice">
    <div class="modalPopupTitle">Confirm Signature Removal</div>
    <div>This is a permanent action and cannot be undone. Continue with signature removal?</div>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnUnsignConfirm" Text="OK" CssClass="button ok" OnClick="btnUnsignConfirm_Click" />
        <asp:LinkButton runat="server" ID="btnUnsignCancel" Text="Cancel" CssClass="button delete" OnClick="btnUnsignCancel_Click" />
    </div>
</eStaffing:ModalPopup>
<eStaffing:ModalPopup runat="server" ID="mpViewDigitalSignature" CssClass="modalPopup notice" BackgroundCssClass="modalPopupBackground notice">
    <div class="modalPopupTitle">Digital Signature Information</div>
    <asp:Image runat="server" ID="imgViewSignatureValid" />
    <asp:Label runat="server" ID="lblViewSignatureName" />
    <asp:Label runat="server" ID="lblViewSignatureDate" />
    <div class="marginTopSmall">
        <asp:Literal runat="server" ID="ltrViewSignatureValidText" />
    </div>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnViewSignatureConfirm" Text="OK" CssClass="button ok" OnClick="btnViewSignatureConfirm_Click" />
    </div>
</eStaffing:ModalPopup>