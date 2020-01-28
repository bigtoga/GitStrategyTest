<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PlayersUserControl.ascx.cs" Inherits="Tournaments.ViewControls.PlayersUserControl" %>

<asp:GridView ID="GridViewPlayers" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Id" DataField="Id"></asp:BoundField>
                    <asp:BoundField HeaderText="First name" DataField="FirstName"></asp:BoundField>
                    <asp:BoundField HeaderText="Last Name" DataField="LastName"></asp:BoundField>

                </Columns>
            </asp:GridView> 