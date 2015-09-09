<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Form4610RSheet.ascx.cs" Inherits="USAACE.eStaffing.Web.Controls.Forms.Form4610RSheet" %>
<table class="formTable">
    <colgroup>
        <col style="width: 60%;" />
        <col style="width: 20%;" />
        <col style="width: 20%;" />
    </colgroup>
    <tbody>
        <tr>
            <td class="label left" colspan="2">Title of Functional Area</td>
            <td class="label left">UIC</td>
        </tr>
        <tr>
            <td colspan="2"><eStaffing:TextControl runat="server" ID="txtTitle" Width="100%" /></td>
            <td><eStaffing:TextControl runat="server" ID="txtUIC" Width="100%" /></td>
        </tr>
        <tr>
            <td class="label left">Unit Designation</td>
            <td class="label left">MTOE/TDA Number</td>
            <td class="label left">CCNUM</td>
        </tr>
        <tr>
            <td><eStaffing:TextControl runat="server" ID="txtUnit" Width="100%" /></td>
            <td><eStaffing:TextControl runat="server" ID="txtTDANumber" Width="100%" /></td>
            <td><eStaffing:TextControl runat="server" ID="txtCCNumber" Width="100%" /></td>
        </tr>
    </tbody>
</table>
<h2 class="formTitle center">Part I - Equipment</h2>
<h3 class="formTitle center">Section A - Items to be Added and/or Deleted</h3>
<table class="formGrid">
    <colgroup>
        <col style="width: 3em;" />
        <col style="width: 4em;" />
        <col style="width: 4em;" />
        <col style="width: 4em;" />
        <col style="width: 8em;" />
        <col style="width: 8em;" />
        <col style="width: 6em;" />
        <col style="width: 4em;" />
        <col style="width: 4em;" />
        <col style="width: 4em;" />
        <col style="width: 4em;" />
        <col style="width: 4em;" />
        <col style="width: 4em;" />
        <col style="width: 4em;" />
        <col style="width: 4em;" />
        <col style="width: 8em;" />
        <col class="hidePrint" style="width: 5em;" />
        <col class="hidePrint" style="width: 5em;" />
    </colgroup>
    <thead>
        <tr>
            <th rowspan="2"></th>
            <th rowspan="2">Para</th>
            <th rowspan="2">Lin</th>
            <th rowspan="2">ERC</th>
            <th rowspan="2">SB 700-20 Chapter</th>
            <th rowspan="2">Nomenclature</th>
            <th rowspan="2">Cost</th>
            <th colspan="2">Quantity Added</th>
            <th colspan="2">Quantity Deleted</th>
            <th colspan="2">New Para Qty</th>
            <th colspan="2">New Recap Qty</th>
            <th rowspan="2">Qty On Hand Not Auth</th>
            <th rowspan="2" class="hidePrint">Edit</th>
            <th rowspan="2" class="hidePrint">Delete</th>
        </tr>
        <tr>
            <th>Req</th>
            <th>Auth</th>
            <th>Req</th>
            <th>Auth</th>
            <th>Req</th>
            <th>Auth</th>
            <th>Req</th>
            <th>Auth</th>
        </tr>
    </thead>
    <tbody>
        <eStaffing:RepeaterListControl runat="server" ID="dlItemChanges" OnItemDataBound="dlItemChanges_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td><asp:Literal runat="server" ID="ltrItem" /></td>
                    <td><asp:Literal runat="server" ID="ltrParagraphNumber" /></td>
                    <td><asp:Literal runat="server" ID="ltrLineNumber" /></td>
                    <td><asp:Literal runat="server" ID="ltrERC" /></td>
                    <td><asp:Literal runat="server" ID="ltrChapter" /></td>
                    <td><asp:Literal runat="server" ID="ltrNomenclature" /></td>
                    <td><asp:Literal runat="server" ID="ltrCost" /></td>
                    <td><asp:Literal runat="server" ID="ltrQuantityAddReq" /></td>
                    <td><asp:Literal runat="server" ID="ltrQuantityAddAuth" /></td>
                    <td><asp:Literal runat="server" ID="ltrQuantityDeleteReq" /></td>
                    <td><asp:Literal runat="server" ID="ltrQuantityDeleteAuth" /></td>
                    <td><asp:Literal runat="server" ID="ltrNewParaQtyReq" /></td>
                    <td><asp:Literal runat="server" ID="ltrNewParaQtyAuth" /></td>
                    <td><asp:Literal runat="server" ID="ltrNewRecapQtyReq" /></td>
                    <td><asp:Literal runat="server" ID="ltrNewRecapQtyAuth" /></td>
                    <td><asp:Literal runat="server" ID="ltrQtyOnHand" /></td>
                    <td class="hidePrint">
                        <asp:ImageButton runat="server" ID="imbEditItemChange" ImageUrl="~/images/edit.gif" OnCommand="imbEditItemChange_Command" />
                    </td>
                    <td class="hidePrint">
                        <asp:ImageButton runat="server" ID="imbDeleteItemChange" ImageUrl="~/images/delete.gif" OnCommand="imbDeleteItemChange_Command" />
                    </td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <tr>
                    <td class="left" colspan="18">There are no item changes.</td>
                </tr>
            </EmptyDataTemplate>
        </eStaffing:RepeaterListControl>
    </tbody>
</table>
<div class="right">
    <asp:LinkButton runat="server" ID="btnAddItemChange" OnClick="btnAddItemChange_Click" Text="Add Item Change" CssClass="button add" />
</div>
<h3 class="formTitle center">Section B - Items to be Deleted From Other MTOE/TDA</h3>
<table class="formGrid">
    <colgroup>
        <col style="width: 3em;" />
        <col style="width: 4em;" />
        <col style="width: 4em;" />
        <col style="width: 4em;" />
        <col style="width: 8em;" />
        <col style="width: 8em;" />
        <col style="width: 6em;" />
        <col style="width: 4em;" />
        <col style="width: 4em;" />
        <col style="width: 6em;" />
        <col style="width: 8em;" />
        <col style="width: 6em;" />
        <col style="width: 4em;" />
        <col style="width: 4em;" />
        <col style="width: 8em;" />
        <col class="hidePrint" style="width: 5em;" />
        <col class="hidePrint" style="width: 5em;" />
    </colgroup>
    <thead>
        <tr>
            <th rowspan="2"></th>
            <th rowspan="2">Para</th>
            <th rowspan="2">Lin</th>
            <th rowspan="2">ERC</th>
            <th rowspan="2">SB 700-20 Chapter</th>
            <th rowspan="2">Nomenclature</th>
            <th rowspan="2">Cost</th>
            <th colspan="2">Quantity Deleted</th>
            <th rowspan="2">UIC</th>
            <th rowspan="2">MTOE/TDA Number</th>
            <th rowspan="2">CCNUM</th>
            <th colspan="2">Asset to be Trf</th>
            <th rowspan="2">Remarks</th>
            <th rowspan="2" class="hidePrint">Edit</th>
            <th rowspan="2" class="hidePrint">Delete</th>
        </tr>
        <tr>
            <th>Req</th>
            <th>Auth</th>
            <th>Yes</th>
            <th>No</th>
        </tr>
    </thead>
    <tbody>
        <eStaffing:RepeaterListControl runat="server" ID="dlOtherItemDeletions" OnItemDataBound="dlOtherItemDeletions_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td><asp:Literal runat="server" ID="ltrItem" /></td>
                    <td><asp:Literal runat="server" ID="ltrParagraphNumber" /></td>
                    <td><asp:Literal runat="server" ID="ltrLineNumber" /></td>
                    <td><asp:Literal runat="server" ID="ltrERC" /></td>
                    <td><asp:Literal runat="server" ID="ltrChapter" /></td>
                    <td><asp:Literal runat="server" ID="ltrNomenclature" /></td>
                    <td><asp:Literal runat="server" ID="ltrCost" /></td>
                    <td><asp:Literal runat="server" ID="ltrQuantityDeleteReq" /></td>
                    <td><asp:Literal runat="server" ID="ltrQuantityDeleteAuth" /></td>
                    <td><asp:Literal runat="server" ID="ltrUIC" /></td>
                    <td><asp:Literal runat="server" ID="ltrTDANumber" /></td>
                    <td><asp:Literal runat="server" ID="ltrCCNumber" /></td>
                    <td><asp:Image runat="server" ID="imgAssetTrfYes" ImageUrl="~/images/ok.gif" /></td>
                    <td><asp:Image runat="server" ID="imgAssetTrfNo" ImageUrl="~/images/ok.gif" /></td>
                    <td><asp:Literal runat="server" ID="ltrRemarks" /></td>
                    <td class="hidePrint">
                        <asp:ImageButton runat="server" ID="imbEditOtherItemDeletion" ImageUrl="~/images/edit.gif" OnCommand="imbEditOtherItemDeletion_Command" />
                    </td>
                    <td class="hidePrint">
                        <asp:ImageButton runat="server" ID="imbDeleteOtherItemDeletion" ImageUrl="~/images/delete.gif" OnCommand="imbDeleteOtherItemDeletion_Command" />
                    </td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <tr>
                    <td class="left" colspan="17">There are no other item deletions.</td>
                </tr>
            </EmptyDataTemplate>
        </eStaffing:RepeaterListControl>
    </tbody>
</table>
<div class="right">
    <asp:LinkButton runat="server" ID="btnAddOtherItemDeletion" OnClick="btnAddOtherItemDeletion_Click" Text="Add Other Item Deletion" CssClass="button add" />
</div>
<h2 class="formTitle center">Part II - Personnel -- Number of Positions to be Added and/or Deleted</h2>
<table class="formGrid">
    <colgroup>
        <col style="width: 3em;" />
        <col style="width: 4em;" />
        <col style="width: 4em;" />
        <col style="width: 8em;" />
        <col style="width: 8em;" />
        <col style="width: 4em;" />
        <col style="width: 6em;" />
        <col style="width: 6em;" />
        <col style="width: 8em;" />
        <col style="width: 4em;" />
        <col style="width: 8em;" />
        <col style="width: 4em;" />
        <col style="width: 4em;" />
        <col class="hidePrint" style="width: 5em;" />
        <col class="hidePrint" style="width: 5em;" />
    </colgroup>
    <thead>
        <tr>
            <th rowspan="2"></th>
            <th rowspan="2">Para</th>
            <th rowspan="2">Lin</th>
            <th rowspan="2">No. Positions (A)/(D)</th>
            <th rowspan="2">Description</th>
            <th rowspan="2">GR</th>
            <th rowspan="2">MOS</th>
            <th rowspan="2">ASI/LIC</th>
            <th rowspan="2">BR</th>
            <th rowspan="2">ID</th>
            <th rowspan="2">AMSC</th>
            <th colspan="2">New Recap</th>
            <th rowspan="2" class="hidePrint">Edit</th>
            <th rowspan="2" class="hidePrint">Delete</th>
        </tr>
        <tr>
            <th>Req</th>
            <th>Auth</th>
        </tr>
    </thead>
    <tbody>
        <eStaffing:RepeaterListControl runat="server" ID="dlPositionChanges" OnItemDataBound="dlPositionChanges_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td><asp:Literal runat="server" ID="ltrItem" /></td>
                    <td><asp:Literal runat="server" ID="ltrParagraphNumber" /></td>
                    <td><asp:Literal runat="server" ID="ltrLineNumber" /></td>
                    <td><asp:Literal runat="server" ID="ltrPositionAdd" /> / <asp:Literal runat="server" ID="ltrPositionDelete" /></td>
                    <td><asp:Literal runat="server" ID="ltrDescription" /></td>
                    <td><asp:Literal runat="server" ID="ltrGR" /></td>
                    <td><asp:Literal runat="server" ID="ltrMOS" /></td>
                    <td><asp:Literal runat="server" ID="ltrASILIC" /></td>
                    <td><asp:Literal runat="server" ID="ltrBR" /></td>
                    <td><asp:Literal runat="server" ID="ltrID" /></td>
                    <td><asp:Literal runat="server" ID="ltrAMSC" /></td>
                    <td><asp:Literal runat="server" ID="ltrNewRecapQtyReq" /></td>
                    <td><asp:Literal runat="server" ID="ltrNewRecapQtyAuth" /></td>
                    <td class="hidePrint">
                        <asp:ImageButton runat="server" ID="imbEditPositionChange" ImageUrl="~/images/edit.gif" OnCommand="imbEditPositionChange_Command" />
                    </td>
                    <td class="hidePrint">
                        <asp:ImageButton runat="server" ID="imbDeletePositionChange" ImageUrl="~/images/delete.gif" OnCommand="imbDeletePositionChange_Command" />
                    </td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <tr>
                    <td class="left" colspan="15">There are no personnel position changes.</td>
                </tr>
            </EmptyDataTemplate>
        </eStaffing:RepeaterListControl>
    </tbody>
</table>
<div class="right">
    <asp:LinkButton runat="server" ID="btnAddPositionChange" OnClick="btnAddPositionChange_Click" Text="Add Personnel Position Change" CssClass="button add" />
</div>
<h2 class="formTitle center">Part III - Justification</h2>
<div><eStaffing:HTMLEditor runat="server" ID="hteJustification" Height="150" /></div>
<eStaffing:ModalPopup runat="server" ID="mpEditItemChange" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
    <div class="modalPopupTitle">Add/Edit Item Change</div>
    <table class="formTable">
        <colgroup>
            <col style="width: 16em;" />
            <col style="width: 6em;" />
            <col style="width: 8em;" />
            <col style="width: 6em;" />
            <col style="width: 8em;" />
        </colgroup>
        <tbody>
            <tr>
                <td class="label left">Paragraph Number:</td>
                <td colspan="4"><eStaffing:TextControl runat="server" ID="txtItemParagraphNumber" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">Line Number:</td>
                <td colspan="4"><eStaffing:TextControl runat="server" ID="txtItemLineNumber" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">ERC:</td>
                <td colspan="4"><eStaffing:TextControl runat="server" ID="txtItemERC" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">SB 700-20 Chapter:</td>
                <td colspan="4"><eStaffing:TextControl runat="server" ID="txtItemChapter" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">Nomenclature:</td>
                <td colspan="4"><eStaffing:TextControl runat="server" ID="txtItemNomenclature" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">Cost:</td>
                <td colspan="4"><eStaffing:TextControl runat="server" ID="txtItemCost" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">Quantity Add:</td>
                <td class="label">Req</td>
                <td><eStaffing:TextControl runat="server" ID="txtItemQuantityAddReq" Width="100%" /></td>
                <td class="label">Auth</td>
                <td><eStaffing:TextControl runat="server" ID="txtItemQuantityAddAuth" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">Quantity Delete:</td>
                <td class="label">Req</td>
                <td><eStaffing:TextControl runat="server" ID="txtItemQuantityDeleteReq" Width="100%" /></td>
                <td class="label">Auth</td>
                <td><eStaffing:TextControl runat="server" ID="txtItemQuantityDeleteAuth" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">New Paragraph Quantity:</td>
                <td class="label">Req</td>
                <td><eStaffing:TextControl runat="server" ID="txtItemNewParaQtyReq" Width="100%" /></td>
                <td class="label">Auth</td>
                <td><eStaffing:TextControl runat="server" ID="txtItemNewParaQtyAuth" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">New Recap Quantity:</td>
                <td class="label">Req</td>
                <td><eStaffing:TextControl runat="server" ID="txtItemNewRecapQtyReq" Width="100%" /></td>
                <td class="label">Auth</td>
                <td><eStaffing:TextControl runat="server" ID="txtItemNewRecapQtyAuth" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left" colspan="2">Quantity on Hand Not Authorized:</td>
                <td colspan="3"><eStaffing:TextControl runat="server" ID="txtItemQtyOnHand" Width="100%" /></td>
            </tr>
        </tbody>
    </table>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnSaveItemChange" Text="Save" CssClass="button save" OnClick="btnSaveItemChange_Click" />
        <asp:LinkButton runat="server" ID="btnCancelItemChange" Text="Cancel" CssClass="button delete" OnClick="btnCancelItemChange_Click" />
    </div>
</eStaffing:ModalPopup>
<eStaffing:ModalPopup runat="server" ID="mpDeleteItemChangeConfirm" CssClass="modalPopup notice" BackgroundCssClass="modalPopupBackground notice">
    <div class="modalPopupTitle">Confirm</div>
    <div>Are you sure you want to delete this item change?</div>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnDeleteItemChangeConfirm" Text="OK" CssClass="button ok" OnClick="btnDeleteItemChangeConfirm_Click" />
        <asp:LinkButton runat="server" ID="btnDeleteItemChangeCancel" Text="Cancel" CssClass="button delete" OnClick="btnDeleteItemChangeCancel_Click" />
    </div>
</eStaffing:ModalPopup>
<eStaffing:ModalPopup runat="server" ID="mpEditOtherItemDeletion" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
    <div class="modalPopupTitle">Add/Edit Other Item Deletion</div>
    <table class="formTable">
        <colgroup>
            <col style="width: 14em;" />
            <col style="width: 6em;" />
            <col style="width: 8em;" />
            <col style="width: 6em;" />
            <col style="width: 8em;" />
        </colgroup>
        <tbody>
            <tr>
                <td class="label left">Paragraph Number:</td>
                <td colspan="4"><eStaffing:TextControl runat="server" ID="txtOtherItemParagraphNumber" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">Line Number:</td>
                <td colspan="4"><eStaffing:TextControl runat="server" ID="txtOtherItemLineNumber" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">ERC:</td>
                <td colspan="4"><eStaffing:TextControl runat="server" ID="txtOtherItemERC" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">Chapter:</td>
                <td colspan="4"><eStaffing:TextControl runat="server" ID="txtOtherItemChapter" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">Nomenclature:</td>
                <td colspan="4"><eStaffing:TextControl runat="server" ID="txtOtherItemNomenclature" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">Cost:</td>
                <td colspan="4"><eStaffing:TextControl runat="server" ID="txtOtherItemCost" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">Quantity Delete:</td>
                <td class="label">Req</td>
                <td><eStaffing:TextControl runat="server" ID="txtOtherItemQuantityDeleteReq" Width="100%" /></td>
                <td class="label">Auth</td>
                <td><eStaffing:TextControl runat="server" ID="txtOtherItemQuantityDeleteAuth" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">UIC:</td>
                <td colspan="4"><eStaffing:TextControl runat="server" ID="txtOtherItemUIC" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">MTOE/TDA Number:</td>
                <td colspan="4"><eStaffing:TextControl runat="server" ID="txtOtherItemTDANumber" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">CCNUM:</td>
                <td colspan="4"><eStaffing:TextControl runat="server" ID="txtOtherItemCCNumber" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">Asset to be Trf:</td>
                <td colspan="4"><eStaffing:RadioButtonListControl runat="server" ID="rblOtherItemAssetTrf" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="radioButtonList" /></td>
            </tr>
            <tr>
                <td class="label left">Remarks:</td>
                <td colspan="4"><eStaffing:TextControl runat="server" ID="txtOtherItemRemarks" Width="100%" /></td>
            </tr>
        </tbody>
    </table>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnSaveOtherItemDeletion" Text="Save" CssClass="button save" OnClick="btnSaveOtherItemDeletion_Click" />
        <asp:LinkButton runat="server" ID="btnCancelOtherItemDeletion" Text="Cancel" CssClass="button delete" OnClick="btnCancelOtherItemDeletion_Click" />
    </div>
</eStaffing:ModalPopup>
<eStaffing:ModalPopup runat="server" ID="mpDeleteOtherItemDeletionConfirm" CssClass="modalPopup notice" BackgroundCssClass="modalPopupBackground notice">
    <div class="modalPopupTitle">Confirm</div>
    <div>Are you sure you want to delete this other item deletion?</div>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnDeleteOtherItemDeletionConfirm" Text="OK" CssClass="button ok" OnClick="btnDeleteOtherItemDeletionConfirm_Click" />
        <asp:LinkButton runat="server" ID="btnDeleteOtherItemDeletionCancel" Text="Cancel" CssClass="button delete" OnClick="btnDeleteOtherItemDeletionCancel_Click" />
    </div>
</eStaffing:ModalPopup>
<eStaffing:ModalPopup runat="server" ID="mpEditPositionChange" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
    <div class="modalPopupTitle">Add/Edit Personnel Position Change</div>
    <table class="formTable">
        <colgroup>
            <col style="width: 14em;" />
            <col style="width: 6em;" />
            <col style="width: 8em;" />
            <col style="width: 6em;" />
            <col style="width: 8em;" />
        </colgroup>
        <tbody>
            <tr>
                <td class="label left">Paragraph Number:</td>
                <td colspan="4"><eStaffing:TextControl runat="server" ID="txtPositionParagraphNumber" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">Line Number:</td>
                <td colspan="4"><eStaffing:TextControl runat="server" ID="txtPositionLineNumber" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">Number of Positions:</td>
                <td class="label">Add</td>
                <td><eStaffing:TextControl runat="server" ID="txtPositionCountAdd" Width="100%" /></td>
                <td class="label">Delete</td>
                <td><eStaffing:TextControl runat="server" ID="txtPositionCountDelete" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">Description:</td>
                <td colspan="4"><eStaffing:TextControl runat="server" ID="txtPositionDescription" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">GR:</td>
                <td colspan="4"><eStaffing:TextControl runat="server" ID="txtPositionGR" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">MOS:</td>
                <td colspan="4"><eStaffing:TextControl runat="server" ID="txtPositionMOS" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">ASI/LIC:</td>
                <td colspan="4"><eStaffing:TextControl runat="server" ID="txtPositionASILIC" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">BR:</td>
                <td colspan="4"><eStaffing:TextControl runat="server" ID="txtPositionBR" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">ID:</td>
                <td colspan="4"><eStaffing:TextControl runat="server" ID="txtPositionID" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">AMSC:</td>
                <td colspan="4"><eStaffing:TextControl runat="server" ID="txtPositionAMSC" Width="100%" /></td>
            </tr>
            <tr>
                <td class="label left">New Recap:</td>
                <td class="label">Req</td>
                <td><eStaffing:TextControl runat="server" ID="txtPositionNewRecapQtyReq" Width="100%" /></td>
                <td class="label">Auth</td>
                <td><eStaffing:TextControl runat="server" ID="txtPositionNewRecapQtyAuth" Width="100%" /></td>
            </tr>
        </tbody>
    </table>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnSavePositionChange" Text="Save" CssClass="button save" OnClick="btnSavePositionChange_Click" />
        <asp:LinkButton runat="server" ID="btnCancelPositionChange" Text="Cancel" CssClass="button delete" OnClick="btnCancelPositionChange_Click" />
    </div>
</eStaffing:ModalPopup>
<eStaffing:ModalPopup runat="server" ID="mpDeletePositionChangeConfirm" CssClass="modalPopup notice" BackgroundCssClass="modalPopupBackground notice">
    <div class="modalPopupTitle">Confirm</div>
    <div>Are you sure you want to delete this personnel position change?</div>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnDeletePositionChangeConfirm" Text="OK" CssClass="button ok" OnClick="btnDeletePositionChangeConfirm_Click" />
        <asp:LinkButton runat="server" ID="btnDeletePositionChangeCancel" Text="Cancel" CssClass="button delete" OnClick="btnDeletePositionChangeCancel_Click" />
    </div>
</eStaffing:ModalPopup>