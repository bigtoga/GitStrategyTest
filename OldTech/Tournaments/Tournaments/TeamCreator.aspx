<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TeamCreator.aspx.cs" Inherits="Tournaments.TeamCreator" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row well content-container-even">

        <asp:Label runat="server" AssociatedControlID="ClassNameTextBox" CssClass="dropdown-label">Team Name</asp:Label>
        <asp:TextBox runat="server" ID="ClassNameTextBox" CssClass="class-of-students-dropdown" TextMode="SingleLine" />
        <div class="add-class-button">
            <asp:Button runat="server" ID="CreateTeamBtn" Text="Create Team" CssClass="btn btn-success" OnClick="CreateTeamBtn_Click" />
        </div>
    </div>
</asp:Content>
