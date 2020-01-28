<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PlayersUserControl_1.ascx.cs" Inherits="Tournaments.ViewControls.PlayersUserControl_1" %>

<asp:GridView ID="GridViewPlayers" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered"
    AllowPaging="True"
    AllowSorting="true"
    DataKeyNames="Id" PageSize="2"
    OnPageIndexChanging="OnGridViewPageChanged"
    >



    <Columns>        
        <asp:BoundField SortExpression="FirstName" HeaderText="First name" DataField="FirstName"></asp:BoundField>
        <asp:BoundField HeaderText="Last Name" DataField="LastName"></asp:BoundField>
        <asp:BoundField HeaderText="Nickname" DataField="NickName"></asp:BoundField>
        <asp:ImageField HeaderText="Picture" DataImageUrlField="Picture"></asp:ImageField>
        <asp:BoundField HeaderText="Email" DataField="Email"></asp:BoundField>
        <asp:BoundField HeaderText="Rating" DataField="Rating"></asp:BoundField>
        <asp:BoundField HeaderText="IsCoach" DataField="IsCoach"></asp:BoundField>
        <asp:BoundField HeaderText="CV" DataField="CV"></asp:BoundField>
        <asp:BoundField HeaderText="Team" DataField="Team.Name"></asp:BoundField>
    </Columns>
</asp:GridView>
