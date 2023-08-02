<%@ Page Title="Данни за потребителя" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="User_Info.aspx.cs" Inherits="Aid4Trade_13118059.Account.User_Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <asp:FormView ID="userDetail" DefaultMode="ReadOnly" runat="server" RenderOuterTable="false">
            <ItemTemplate>
                <h1 style="color:blue">Данни за потребителя</h1>
                <br />
                <tr>
                    <td>
                        <b>Потребителско име:</b> <%#:Eval("[User name]") %>
                        <br />
                        <b>Държава:</b> <%#:Eval("[User country]") %>
                        <br />
                        <b>Град:</b> <%#:Eval("[User city]") %>
                        <br />
                        <b>Имейл:</b> <%#:Eval("[User email]") %>
                        <br />
                        <b>Потребителят е коментирал следните продукти:</b>
                        <br />
                    </td>
            </ItemTemplate>
        </asp:FormView>
        <tr>
            <td>
                <asp:Repeater ID="show_comments" runat="server">
                    <ItemTemplate>
                        &#9658; <a href="<%#GetRouteUrl("ProductByName", new {productName = Eval("[Product name]"), productID = Eval("[Product ID]")})%>"><b>
                            <asp:Label ID="product_name" runat="server" Text='<%#Eval("[Product name]")%>'></asp:Label></b></a>, където има <b><asp:Label ID="count_of_comments" runat="server" Text='<%#Eval("[Count Of Comments]")%>'></asp:Label></b> <asp:Label ID="coments" runat="server" Text="коментара"></asp:Label>.
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
            </td>
        </tr>
    </table>
</asp:Content>
