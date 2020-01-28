<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SponsorManager.aspx.cs" Inherits="Tournaments.SponsorManager" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row well content-container-even">

        <asp:GridView ID="GridViewSponsors" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered"
            AutoGenerateInsertButton="true"
            AutoGenerateSelectButton="true"
            AllowPaging="true"
            SelectMethod="GridViewSponsors_GetData"
            InsertMethod="GridViewSponsors_InsertItem"
            DeleteMethod="GridViewSponsors_DeleteItem"
            UpdateMethod="GridViewSponsors_UpdateItem"
            DataKeyNames="Id">
            <Columns>
                <asp:BoundField HeaderText="Name" DataField="Name"></asp:BoundField>
              </Columns>

        </asp:GridView>
    </div>
 </asp:Content>
