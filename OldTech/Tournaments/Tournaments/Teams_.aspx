<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Teams_.aspx.cs" Inherits="Tournaments.Teams_" %>



<asp:Content ID="ContentBody" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridViewTeams" runat="server" ItemType="Tournaments.Models.Team"
        ShowFooter="True"
        AutoGenerateColumns="false" CssClass="table table-bordered"
        SelectMethod="GridViewTeams_GetData"
        InsertMethod="GridViewTeams_InsertItem"
        DeleteMethod="GridViewTeams_DeleteItem"
        UpdateMethod="GridViewTeams_UpdateItem"
        DataKeyNames="Id">

        <Columns>
            <asp:TemplateField HeaderText="Team Id" InsertVisible="False"
                SortExpression="Id">
                <ItemTemplate>
                    <asp:Label ID="LabelId" runat="server"
                        Text='<%#: Item.Id %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
<asp:LinkButton runat="server" ID="LinkButtonEdit" Text="Insert" CommandName="Insert" />

                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Team Name" InsertVisible="False"
                SortExpression="Name">
                 <ItemTemplate>
                    <asp:Label ID="Name" runat="server"
                        Text='<%#: Item.Name %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="NewName" runat="server" Text='<%#: BindItem.Name %>'></asp:TextBox>
                </FooterTemplate>                           
                
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Team Rating" InsertVisible="False"
                SortExpression="Rating">
                <ItemTemplate>
                    <asp:Label ID="LabelRating" runat="server"
                        Text='<%#: Item.Rating %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="NewRating" runat="server" Text='<%#: BindItem.Rating %>'></asp:TextBox>
                </FooterTemplate> 
            </asp:TemplateField>

        </Columns>

    </asp:GridView>
</asp:Content>
