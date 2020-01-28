<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SponsorsUserControl.ascx.cs" Inherits="Tournaments.ViewControls.SponsorsUserControl" %>

<asp:GridView ID="GridViewSponsors" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered"
    AutoGenerateSelectButton="true"
    AllowPaging="true">
    <Columns>
        <asp:BoundField HeaderText="Name" DataField="Name"></asp:BoundField>
    </Columns>
</asp:GridView>
