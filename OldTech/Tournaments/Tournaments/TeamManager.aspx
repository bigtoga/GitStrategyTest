<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TeamManager.aspx.cs" Inherits="Tournaments.TeamManager" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row well content-container-even">

        <asp:GridView ID="GridViewTeams" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered"
            AutoGenerateInsertButton="true"
            AutoGenerateSelectButton="true"
            AllowPaging="true"
            SelectMethod="GridViewTeams_GetData"
            InsertMethod="GridViewTeams_InsertItem"
            DeleteMethod="GridViewTeams_DeleteItem"
            UpdateMethod="GridViewTeams_UpdateItem"
            DataKeyNames="Id">
            <Columns>
                <asp:BoundField HeaderText="Name" DataField="Name"></asp:BoundField>
                <asp:BoundField HeaderText="Rating" DataField="Rating"></asp:BoundField>

            </Columns>

        </asp:GridView>
    </div>
 </asp:Content>
