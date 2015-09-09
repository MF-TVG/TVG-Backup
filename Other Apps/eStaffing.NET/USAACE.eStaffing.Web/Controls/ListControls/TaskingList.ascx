<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TaskingList.ascx.cs" Inherits="USAACE.eStaffing.Web.Controls.ListControls.TaskingList" %>
<table class="formGrid">
    <colgroup>
        <col style="width: 3em;" />
        <col style="width: auto;" />
        <col style="width: 24em;" />
    </colgroup>
    <tbody>
        <eStaffing:RepeaterListControl runat="server" ID="dlFormList" OnItemDataBound="dlFormList_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="lnkEdit" ImageUrl="~/images/edit.gif" />
                    </td>
                    <td class="left">
                        <div><span class="label required">Task Number:</span> <asp:Literal runat="server" ID="ltrFormNumber" /></div>
                        <div><span class="label required">Subject:</span> <asp:Literal runat="server" ID="ltrSubject" /></div>
                        <div><span class="label required">Source:</span> <asp:Literal runat="server" ID="ltrSource" /></div>
                    </td>
                    <td class="left">
                        <div><span class="label required">Submit Date:</span> <asp:Literal runat="server" ID="ltrSubmitDate" /></div>
                        <div><span class="label required">Suspense Date:</span> <asp:Literal runat="server" ID="ltrDate" /></div>
                        <div><span class="label required">Status:</span> <asp:Literal runat="server" ID="ltrStatus" /> <asp:Image runat="server" ID="imgStatus" /></div>
                    </td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <tr>
                    <td class="left" colspan="3">There are no forms.</td>
                </tr>
            </EmptyDataTemplate>
        </eStaffing:RepeaterListControl>
    </tbody>
</table>