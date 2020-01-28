<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileUploadControl.ascx.cs" Inherits="Tournaments.ViewControls.FileUploadControl" %>

<%@ Register Src="~/ViewControls/Notifier.ascx" TagPrefix="uc1" TagName="Notifier" %>


<uc1:Notifier runat="server" ID="Notifier" />
<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <div class="form-group">

            <asp:FileUpload ID="FileUpload" runat="server" CssClass="upload-button" AllowMultiple="true" hidden="true" />
            <asp:Label AssociatedControlID="FileUpload" runat="server" CssClass="upload-button-modified btn btn-info">
        Choose a file
            </asp:Label>
            <asp:Button ID="UploadFileBtn"
                runat="server"
                OnClick="UploadFileBtn_Click"
                Text="Upload"
                CssClass="btn btn-success" />
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="UploadFileBtn" />
    </Triggers>
</asp:UpdatePanel>
