<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TournamentManager.aspx.cs" Inherits="Tournaments.TournamentManager" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row well content-container-even">

        <asp:GridView ID="GridViewTournaments" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered"
            AutoGenerateInsertButton="true"
            AutoGenerateSelectButton="true"
            AllowPaging="true"
            SelectMethod="GridViewTournaments_GetData"
            InsertMethod="GridViewTournaments_InsertItem"
            DeleteMethod="GridViewTournaments_DeleteItem"
            UpdateMethod="GridViewTournaments_UpdateItem"
            DataKeyNames="Id">
            <Columns>
                <asp:BoundField HeaderText="Name" DataField="Name"></asp:BoundField>
                <asp:BoundField HeaderText="Date" DataField="Date"></asp:BoundField>
                <asp:BoundField HeaderText="Prize" DataField="Prize"></asp:BoundField>
            </Columns>

        </asp:GridView>
    </div>
 </asp:Content>
