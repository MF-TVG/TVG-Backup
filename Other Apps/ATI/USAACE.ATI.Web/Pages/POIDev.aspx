<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="POIDev.aspx.cs" Inherits="USAACE.ATI.Web.Pages.POIDev" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h1 class="formTitle">Build / Update POI</h1>
    <div>
        <asp:ValidationSummary runat="server" ID="vsPOI" ValidationGroup="POI" CssClass="validationError marginTopSmall" HeaderText="The following validation errors have occurred:" />
    </div>
    <table class="formTable">
        <colgroup>
            <col style="width: 20%;" />
            <col style="width: 25%;" />
            <col style="width: 15%;" />
            <col style="width: 20%;" />
            <col style="width: 20%;" />
        </colgroup>
        <tbody>
            <tr>
                <td class="label left required">Select a POI:</td>
                <td colspan="3">
                    <ATI:ComboBoxControl runat="server" ID="cmbPOI" Width="300" AutoPostBack="true" OnTextChanged="cmbPOI_TextChanged" />
                </td>
                <td>
                    <asp:LinkButton runat="server" ID="btnCreatePOICopy" Text="Create a Copy" OnClick="btnCreatePOICopy_Click" Visible="false" CssClass="button copy" />
                </td>
            </tr>
            <tr>
                <td colspan="2" class="label left required">
                    POI Name
                </td>
                <td class="label left"># of Days</td>
                <td class="label left">Effective Date</td>
                <td rowspan="2"><asp:CheckBox runat="server" ID="chkMobilization" Text="Mobilization POI" /></td>
            </tr>
            <tr>
                <td colspan="2"><ATI:TextControl runat="server" ID="txtPOIName" MaxLength="50" Width="300" /></td>
                <td><ATI:NumericControl runat="server" ID="ncPOIDays" Width="50" AutoPostBack="true" OnTextChanged="ncPOIDays_TextChanged" MaxLength="4" Mask="9999" MaskType="Number" /></td>
                <td><ATI:DateControl runat="server" ID="dcEffectiveDate" Width="100" /></td>
            </tr>
        </tbody>
    </table>
    <h2 class="formTitle">Flight Days</h2>
    <div class="label left">Objective</div>
    <div><ATI:ComboBoxControl runat="server" ID="cmbObjective" Width="300" AutoPostBack="true" OnTextChanged="cmbObjective_TextChanged" /></div>
    <asp:Panel runat="server" ID="pnlObjectiveHours" Visible="false" CssClass="marginTop" style="width: 100%; overflow-x: auto;">
        <div class="label left">Units / Eval</div>
        <asp:DataList runat="server" ID="dlFlightDays" RepeatLayout="Table" RepeatDirection="Vertical" OnItemDataBound="dlFlightDays_ItemDataBound">
            <ItemTemplate>
                <asp:Label runat="server" ID="lblDayNumber" Width="20" Visible="false" />
                <ATI:NumericControl runat="server" ID="ncDayUnits" Width="50" Visible="false" MaxLength="6" MaskType="Number" Mask="999.99" ClearMaskOnLostFocus="true" InputDirection="RightToLeft" />
                <asp:CheckBox runat="server" ID="chkDayEval" Visible="false" style="margin-right: 1em;" />
            </ItemTemplate>
        </asp:DataList>
    </asp:Panel>
    <table class="formTable">
        <colgroup>
            <col style="width: 90%;" />
            <col style="width: 10%;" />
        </colgroup>
        <tr>
            <td class="label right">Objective Hours:</td>
            <td class="right"><asp:Literal runat="server" ID="ltrObjectiveHours" /></td>
        </tr>
        <tr>
            <td class="label right">Total Hours:</td>
            <td class="right"><asp:Literal runat="server" ID="ltrTotalHours" /></td>
        </tr>
    </table>
    <div class="right marginTop">
        <asp:LinkButton runat="server" ID="btnUpdatePOI" Text="Save POI" OnClick="btnUpdatePOI_Click" CssClass="button save" />
        <asp:LinkButton runat="server" ID="btnDeletePOI" Text="Delete POI" Visible="false" OnClick="btnDeletePOI_Click" CssClass="button delete" />
        <asp:LinkButton runat="server" ID="btnReportPOI" Text="POI Report" Visible="false" OnClick="btnReportPOI_Click" CssClass="button print" />
    </div>
    <ATI:ModalPopup runat="server" ID="mpCopyPOI" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
        <div class="modalPopupTitle">Copy POI</div>
        <div>
            <asp:ValidationSummary runat="server" ID="vsCopyPOI" ValidationGroup="CopyPOI" CssClass="validationError marginTopSmall" HeaderText="The following validation errors have occurred:" />
        </div>
        <div class="label left">
            Name of New POI
            <asp:RequiredFieldValidator runat="server" ID="rfvCopyPOIName" CssClass="validationError" ControlToValidate="txtCopyPOIName" ErrorMessage="POI Name cannot be empty." Text="*" ValidationGroup="CopyPOI" EnableClientScript="false" />
        </div>
        <div><ATI:TextControl runat="server" ID="txtCopyPOIName" Width="300" MaxLength="50" /></div>
        <div class="right marginTop">
            <asp:LinkButton runat="server" ID="btnCopyPOIConfirm" Text="Copy POI" OnClick="btnCopyPOIConfirm_Click" CssClass="button copy" />
            <asp:LinkButton runat="server" ID="btnCopyPOICancel" Text="Cancel" OnClick="btnCopyPOICancel_Click" CssClass="button delete" />
        </div>
    </ATI:ModalPopup>
    <ATI:ModalPopup runat="server" ID="mpConfirmDeletePOI" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
        <div class="modalPopupTitle">Confirm POI Deletion</div>
        <div class="label left">Are you sure you want to delete this POI?  All associated programs and classes will be deleted as well.</div>
        <div class="right marginTop">
            <asp:LinkButton runat="server" ID="btnDeletePOIConfirm" Text="Delete POI" OnClick="btnDeletePOIConfirm_Click" CssClass="button ok" />
            <asp:LinkButton runat="server" ID="btnDeletePOICancel" Text="Cancel" OnClick="btnDeletePOICancel_Click" CssClass="button delete" />
        </div>
    </ATI:ModalPopup>
    <ATI:ModalPopup runat="server" ID="mpPOIReport" CssClass="modalPopup" BackgroundCssClass="modalPopupBackground">
        <div class="modalPopupTitle">POI Report</div>
        <div style="max-height: 40em; overflow-y: auto; padding: 2em;">
            <div id="divReport" style="width: 100%;">
                <div>
                    <asp:Label runat="server" ID="lblPOIReportName" style="font-weight: bold;" /> ( Length: <asp:Literal runat="server" ID="ltrPOIReportLength" /> Days )
                </div>
                <asp:DataList runat="server" ID="dlReport" RepeatColumns="2" RepeatDirection="Vertical" style="width: 100%; table-layout: fixed;">
                    <ItemTemplate>
                        <table style="width: 100%;">
                            <colgroup>
                                <col style="width: 60%;" />
                                <col style="width: 20%;" />
                                <col style="width: 20%;" />
                            </colgroup>
                            <tr>
                                <td class="left"><%# DataBinder.Eval(Container.DataItem, "ObjectiveDay") %></td>
                                <td class="right"><%# DataBinder.Eval(Container.DataItem, "QTY")%></td>
                                <td class="center"><%# DataBinder.Eval(Container.DataItem, "Eval")%></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
        <div class="right marginTop">
            <asp:LinkButton runat="server" ID="btnPrintPOIReport" Text="Print" OnClientClick="javascript:PrintDiv('divReport');" CssClass="button print" />
            <asp:LinkButton runat="server" ID="btnClosePOIReport" Text="Close" OnClick="btnClosePOIReport_Click" CssClass="button delete" />
        </div>
    </ATI:ModalPopup>
</asp:Content>
