<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SchoolsRequestForm.ascx.cs" Inherits="USAACE.eStaffing.Web.Controls.Forms.SchoolsRequestForm" %>
<table class="formTable">
    <colgroup>
        <col style="width: 14em;" />
        <col style="width: auto;" />
        <col style="width: 16em;" />
        <col style="width: auto;" />
    </colgroup>
    <tbody>
        <tr>
            <td class="label left">Title:</td>
            <td colspan="3"><eStaffing:TextControl runat="server" ID="txtTitle" Width="100%" /></td>
        </tr>
        <tr>
            <td class="label left">Request Type:</td>
            <td colspan="3"><eStaffing:DropDownControl runat="server" ID="ddlRequestType" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlRequestType_SelectedIndexChanged" /></td>
        </tr>
        <tr>
            <td class="label left">Checklist:</td>
            <td colspan="3"><eStaffing:CheckBoxListControl runat="server" ID="cklChecklistItems" RepeatLayout="Flow" RepeatDirection="Vertical" CssClass="checkBoxList" /></td>
        </tr>
        <tr>
            <td class="label left">Who:</td>
            <td colspan="3"><eStaffing:HTMLEditor runat="server" ID="hteWho" Height="150" /></td>
        </tr>
        <tr>
            <td class="label left">Last APFT Score:</td>
            <td colspan="3"><eStaffing:TextControl runat="server" ID="txtAPFTScore" Width="40" MaxLength="3" /></td>
        </tr>
        <tr>
            <td class="label left">Army Height/Weight:</td>
            <td><eStaffing:RadioButtonListControl runat="server" ID="rblAPFTPass" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="radioButtonList" /></td>
            <td class="label left">(If Failed) Body Fat %:</td>
            <td><eStaffing:TextControl runat="server" ID="txtAPFTBodyFat" Width="40" MaxLength="3" /></td>
        </tr>
        <tr>
            <td class="label left">Army SSD Level:</td>
            <td colspan="3"><eStaffing:TextControl runat="server" ID="txtArmySSDLevel" Width="100%" /></td>
        </tr>
        <tr>
            <td class="label left">What:</td>
            <td colspan="3"><eStaffing:HTMLEditor runat="server" ID="hteWhat" Height="150" /></td>
        </tr>
        <tr>
            <td class="label left">When:</td>
            <td colspan="3"><eStaffing:HTMLEditor runat="server" ID="hteWhen" Height="150" /></td>
        </tr>
        <tr>
            <td class="label left">Where:</td>
            <td colspan="3"><eStaffing:HTMLEditor runat="server" ID="hteWhere" Height="150" /></td>
        </tr>
        <tr>
            <td class="label left">Remarks:</td>
            <td colspan="3"><eStaffing:HTMLEditor runat="server" ID="hteRemarks" Height="150" /></td>
        </tr>
    </tbody>
</table>