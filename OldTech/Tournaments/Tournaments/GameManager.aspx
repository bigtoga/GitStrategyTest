<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GameManager.aspx.cs" Inherits="Tournaments.GameManager" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row well content-container-even">

        <asp:GridView ID="GridViewGames" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered"
            AutoGenerateInsertButton="true"
            AutoGenerateSelectButton="true"
            AllowPaging="true"
            SelectMethod="GridViewGames_GetData"
            InsertMethod="GridViewGames_InsertItem"
            DeleteMethod="GridViewGames_DeleteItem"
            UpdateMethod="GridViewGames_UpdateItem"
            DataKeyNames="Id">
            <Columns>
                <asp:BoundField HeaderText="Start Time" DataField="StartTime"></asp:BoundField>
                <asp:BoundField HeaderText="End Time" DataField="EndTime"></asp:BoundField>
                <asp:BoundField HeaderText="Result" DataField="Prize"></asp:BoundField>
                <asp:BoundField HeaderText="Place" DataField="Place"></asp:BoundField>
                <asp:BoundField HeaderText="Host" DataField="Host"></asp:BoundField>
                <asp:BoundField HeaderText="Guest" DataField="Guest"></asp:BoundField>
                <asp:BoundField HeaderText="Tournament" DataField="Tournament"></asp:BoundField>
            </Columns>

        </asp:GridView>
    </div>
 </asp:Content>
