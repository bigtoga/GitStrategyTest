<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TeamPlayers.aspx.cs" Inherits="Tournaments.TeamPlayers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Teams And Players</h1>

    <asp:GridView ID="GridViewTeams" runat="server" AutoGenerateColumns="false"
        CssClass="table table-bordered"
        ItemType="Tournaments.Models.Team" DataKeyNames="Id"
        OnSelectedIndexChanged="GridViewTeams_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="true" />
            <asp:BoundField DataField="Name" HeaderText="Team name" />
            <asp:BoundField DataField="Rating" HeaderText="Team rating" />
        </Columns>
    </asp:GridView>
    <br />

    <asp:UpdateProgress ID="UpdateProgressPlayers" runat="server">
        <ProgressTemplate>
            <asp:Image ID="ImageLoading" runat="server" ImageUrl="~/Images/ajax-loader.gif" Height="100" />
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdatePanel ID="UpdatePanelPlayers" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridViewPlayers" runat="server" AutoGenerateColumns="false"
                CssClass="table table-bordered"
                ItemType="Tournaments.Models.Player" DataKeyNames="Id"
                AllowPaging="true" PageSize="5" OnPageIndexChanging="GridViewPlayers_PageIndexChanging">
                <Columns>
                    <asp:BoundField HeaderText="First name" DataField="FirstName"></asp:BoundField>
                    <asp:BoundField HeaderText="Last Name" DataField="LastName"></asp:BoundField>
                    <asp:BoundField HeaderText="Nickname" DataField="NickName"></asp:BoundField>
                    <asp:ImageField HeaderText="Picture" DataImageUrlField="Picture"></asp:ImageField>
                    <asp:BoundField HeaderText="Email" DataField="Email"></asp:BoundField>
                    <asp:BoundField HeaderText="Rating" DataField="Rating"></asp:BoundField>
                    <asp:BoundField HeaderText="IsCoach" DataField="IsCoach"></asp:BoundField>
                    <asp:BoundField HeaderText="CV" DataField="CV"></asp:BoundField>
                    <asp:BoundField HeaderText="Team Name" DataField="Team.Name"></asp:BoundField>
                </Columns>
            </asp:GridView>

        </ContentTemplate>

        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GridViewTeams" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

