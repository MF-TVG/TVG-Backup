<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileControl.ascx.cs" Inherits="USAACE.eStaffing.Web.Controls.FormControls.FileControl.FileControl" %>
<table class="formGrid">
    <colgroup>
        <col style="width: auto;" />
        <col class="hidePrint" style="width: 5em;" />
        <col class="hidePrint" style="width: 5em;" />
        <col class="hidePrint" style="width: 5em;" />
    </colgroup>
    <thead>
        <tr>
            <th class="left">File Name (Open)</th>
            <th class="hidePrint">Save</th>
            <th class="hidePrint">Rename</th>
            <th class="hidePrint">Delete</th>
        </tr>
    </thead>
    <tbody>
        <eStaffing:RepeaterListControl runat="server" ID="dlFiles" OnItemDataBound="dlFiles_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td class="left">
                        <asp:HyperLink runat="server" ID="lnkFile" /> <asp:Literal runat="server" ID="ltrFileStatus" />
                    </td>
                    <td class="hidePrint"><asp:HyperLink runat="server" ID="lnkSaveFile" ImageUrl="~/images/save.gif" /></td>
                    <td class="hidePrint"><asp:ImageButton runat="server" ID="imbRenameFile" ImageUrl="~/images/edit.gif" OnCommand="imbRenameFile_Command" /></td>
                    <td class="hidePrint"><asp:ImageButton runat="server" ID="imbDeleteFile" ImageUrl="~/images/delete.gif" OnCommand="imbDeleteFile_Command" /></td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <tr>
                    <td class="left" colspan="4">There are no attachments.</td>
                </tr>
            </EmptyDataTemplate>
        </eStaffing:RepeaterListControl>
    </tbody>
</table>
<div class="right">
    <asp:LinkButton runat="server" ID="btnAddAttachment" CssClass="button add" Text="Add Attachment" OnClick="btnAddAttachment_Click" />
</div>
<eStaffing:ModalPopup runat="server" ID="mpAddAttachment" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
    <div class="modalPopupTitle">Add Attachment</div>
    <div>
        <span class="label required">Select a File:</span>
    </div>
    <div><asp:FileUpload runat="server" ID="fuFile" Width="400" /></div>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnSaveAttachment" Text="Save" CssClass="button save" OnClick="btnSaveAttachment_Click" />
        <asp:LinkButton runat="server" ID="btnCancelAttachment" Text="Cancel" CssClass="button delete" OnClick="btnCancelAttachment_Click" />
    </div>
</eStaffing:ModalPopup>
<eStaffing:ModalPopup runat="server" ID="mpDeleteAttachmentConfirm" CssClass="modalPopup notice" BackgroundCssClass="modalPopupBackground notice">
    <div class="modalPopupTitle">Confirm</div>
    <div>Are you sure you want to delete this attachment?</div>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnDeleteAttachmentConfirm" Text="OK" CssClass="button ok" OnClick="btnDeleteAttachmentConfirm_Click" />
        <asp:LinkButton runat="server" ID="btnDeleteAttachmentCancel" Text="Cancel" CssClass="button delete" OnClick="btnDeleteAttachmentCancel_Click" />
    </div>
</eStaffing:ModalPopup>
<eStaffing:ModalPopup runat="server" ID="mpRenameAttachment" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
    <div class="modalPopupTitle">Rename Attachment</div>
    <div class="label left">Old File Name:</div>
    <div><asp:Literal runat="server" ID="ltrRenameOldFileName" /></div>
    <div class="label left marginTopSmall">New File Name:</div>
    <div><eStaffing:TextControl runat="server" ID="txtRenameNewFileName" Width="400" /></div>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnSaveRenameAttachment" Text="OK" CssClass="button ok" OnClick="btnSaveRenameAttachment_Click" />
        <asp:LinkButton runat="server" ID="btnCancelRenameAttachment" Text="Cancel" CssClass="button delete" OnClick="btnCancelRenameAttachment_Click" />
    </div>
</eStaffing:ModalPopup>