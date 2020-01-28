<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Teams.aspx.cs" Inherits="Tournaments.Teams" %>

<%@ Register Src="~/ViewControls/TeamsUserControl.ascx" TagPrefix="uc" TagName="teams" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <div class="row well content-container-even">
        <uc:teams runat="server" />
    </div>
</asp:Content>

