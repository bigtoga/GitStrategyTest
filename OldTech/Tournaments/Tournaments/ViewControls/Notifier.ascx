<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Notifier.ascx.cs" Inherits="Tournaments.ViewControls.Notifier" %>

<asp:Panel  runat="server" ID="NotificationPane" CssClass="">
    <button type="button" class="close" data-dismiss="alert">&times;</button>
    <asp:Label ID="NotificationMessage" runat="server"></asp:Label>
</asp:Panel>