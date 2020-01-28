<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sponsors.aspx.cs" Inherits="Tournaments.Sponsors" %>

<%@ Register Src="~/ViewControls/SponsorsUserControl.ascx" TagPrefix="uc" TagName="sponsors" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row well content-container-even">
        <uc:sponsors runat="server" />
    </div>
</asp:Content>
