<%@ Page Title="Данни за търговеца" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dealer_Info.aspx.cs" Inherits="Aid4Trade_13118059.Account.Dealer_Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <asp:FormView ID="dealerDetail" DefaultMode="ReadOnly" runat="server" RenderOuterTable="false" OnItemCreated="dealerDetail_ItemCreated">
            <ItemTemplate>
                <h1 style="color: green">Данни за търговеца</h1>
                <br />
                <tr>
                    <td>
                        <b>Име на търговеца:</b> <%#:Eval("[Dealer name]") %>
                        <br />
                        <b>Описание на търговеца:</b>
                        <br />
                        <%#:Eval("[Dealer description]") %>
                        <br />
                        <b>Тип на търговеца:</b> <%#:Eval("[Dealer type]") %>
                        <br />
                        <b>Държава:</b> <%#:Eval("[Dealer country]") %>
                        <br />
                        <b>Град:</b> <%#:Eval("[Dealer city]") %>
                        <br />
                        <b>Телефон за връзка:</b> <%#:Eval("Phone") %>
                        <br />
                        <b>Имейл:</b> <%#:Eval("[Dealer email]") %>
                        <br />
                        <b>Рейтинг:</b> <%#:Eval("[Rating value]") %> / 6 <asp:Label ID="rating" runat="server" Text="Label"></asp:Label>
                        <br />
                        <b>Търговецът е представил следните продукти:</b>
                        <br />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:FormView>
        <tr>
            <td>
                <asp:Repeater ID="show_products" runat="server">
                    <ItemTemplate>
                        &#9658; Продукт,<a href="<%#GetRouteUrl("ProductByName", new {productName = Eval("[Product name]"), productID = Eval("[Product ID]")})%>"><b>
                            <asp:Label ID="product_name" runat="server" Text='<%#Eval("[Product name]")%>'></asp:Label></b></a>, който е в категория<b>
                            <a href="<%#GetRouteUrl("CategoryByName", new {categoryName = Eval("[Category name]")})%>"><asp:Label ID="category_name" runat="server" Text='<%#Eval("[Category name]")%>'></asp:Label></b></a>.
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
            </td>
        </tr>
    </table>
</asp:Content>
