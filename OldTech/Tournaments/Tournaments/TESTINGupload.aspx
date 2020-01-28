<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TESTINGupload.aspx.cs" Inherits="Tournaments.TESTINGupload" %>

<%@ Register Src="~/ViewControls/FileUploadControl.ascx" TagPrefix="uc" TagName="fileUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="row well content-container-even">
        <uc:fileUpload ID="fileUploadInTest" runat="server" />
    </div>
    <br />
    <div>
        <asp:Label ID="labelPictureUrl"  CssClass="upload-button-modified btn btn-warning" runat="server">This be a label.</asp:Label>
    </div>

</asp:Content>
