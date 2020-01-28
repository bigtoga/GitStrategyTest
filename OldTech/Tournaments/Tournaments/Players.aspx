<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Players.aspx.cs" Inherits="Tournaments.Players" %>

<%@ Register Src="~/ViewControls/PlayersUserControl.ascx" TagPrefix="uc" TagName="players" %>
<%@ Register Src="~/ViewControls/PlayersUserControl_1.ascx" TagPrefix="uc" TagName="players1" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    

    <div class="row well content-container-even">
        <uc:players runat="server" />
    </div>
</asp:Content>