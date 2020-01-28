<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlayerCreator.aspx.cs" Inherits="Tournaments.PlayerCreator" %>

<%@ Register Src="~/ViewControls/FileUploadControl.ascx" TagPrefix="uc" TagName="fileUpload" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row well content-container-even">

        <asp:Label runat="server" AssociatedControlID="PlayerNameTextBox" CssClass="dropdown-label">Team Name</asp:Label>
        <asp:TextBox runat="server" ID="PlayerNameTextBox" TextMode="SingleLine" />

        <div class="row well content-container-even">
            <uc:fileUpload ID="fileUpload" runat="server" />
        </div>
        <div class="add-class-button">
            <asp:Button runat="server" ID="CreatePlayerBtn" Text="Create Player" CssClass="btn btn-success" OnClick="CreatePlayerBtn_Click" />
        </div>
    </div>
</asp:Content>
