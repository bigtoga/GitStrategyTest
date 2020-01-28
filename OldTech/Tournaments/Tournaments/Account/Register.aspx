<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Tournaments.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create a new account</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label">Username</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                    CssClass="text-danger" ErrorMessage="The username field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="DropDownListRole" CssClass="col-md-2 control-label">Your role</asp:Label>
            <div class="col-md-10">
                <asp:UpdatePanel runat="server" ID="UpdatePanelDropDownListRole">
                    <ContentTemplate>
                        <asp:DropDownList runat="server" ID="DropDownListRole" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownListRole_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="player" Text="Player" />
                            <asp:ListItem Value="coach" Text="Coach" />
                            <asp:ListItem Value="sponsor" Text="Sponsor" />
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <asp:UpdatePanel runat="server" ID="UpdatePanelUserData">
            <ContentTemplate>
                <asp:Panel runat="server" ID="PanelUserData" Visible="true">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="FirstName" CssClass="col-md-2 control-label">First name</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName"
                                CssClass="text-danger" ErrorMessage="The first name field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="LastName" CssClass="col-md-2 control-label">Last name</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="LastName" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName"
                                CssClass="text-danger" ErrorMessage="The last name field is required." />
                        </div>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" ID="UpdatePanelSponsorData">
            <ContentTemplate>
                <asp:Panel runat="server" ID="PanelSponsorData" Visible="false">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">Sponsor's name</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Name" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Name"
                                CssClass="text-danger" ErrorMessage="The sponsor's name field is required." />
                        </div>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
