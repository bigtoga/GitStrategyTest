<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TeamsUserControl.ascx.cs" Inherits="Tournaments.ViewControls.TeamsUserControl" %>

<asp:GridView ID="GridViewTeams" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered"
    AutoGenerateSelectButton="true"
    AllowPaging="true"

    SelectMethod="GridViewTeams_GetData"
    InsertMethod="GridViewTeams_InsertItem"
    DeleteMethod="GridViewTeams_DeleteItem"
    UpdateMethod="GridViewTeams_UpdateItem">
    <Columns>
        <asp:BoundField HeaderText="Name" DataField="Name"></asp:BoundField>
        <asp:BoundField HeaderText="Rating" DataField="Rating"></asp:BoundField>
    </Columns>
</asp:GridView>
