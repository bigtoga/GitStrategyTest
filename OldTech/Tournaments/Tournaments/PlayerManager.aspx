<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlayerManager.aspx.cs" Inherits="Tournaments.PlayerManager" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row well content-container-even">

        <asp:GridView ID="GridViewPlayers" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered"
            AutoGenerateInsertButton="true"
            AutoGenerateSelectButton="true"
            AllowPaging="true"
            SelectMethod="GridViewPlayers_GetData"
            InsertMethod="GridViewPlayers_InsertItem"
            DeleteMethod="GridViewPlayers_DeleteItem"
            UpdateMethod="GridViewPlayers_UpdateItem"
            DataKeyNames="Id">
            <Columns>
            <asp:BoundField HeaderText="First name" DataField="FirstName"></asp:BoundField>
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
    </div>
 </asp:Content>
