<%@ Page Title="Продукти" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="Aid4Trade_13118059.Account.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2><%: this.Page.RouteData.Values["categoryName"].ToString() %></h2>
        <asp:ListView ID="productList" runat="server"
            DataKeyNames="Product ID" GroupItemCount="4">
            <EmptyDataTemplate>
                <table>
                    <tr>
                        <td style="font-size: larger">Няма продукти в избраната категория.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <EmptyItemTemplate>
                <td />
            </EmptyItemTemplate>
            <GroupTemplate>
                <tr id="itemPlaceholderContainer" runat="server">
                    <td id="itemPlaceholder" runat="server"></td>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <td runat="server">
                    <table>
                        <tr>
                            <td>
                                <a href="<%#: GetRouteUrl("ProductByName", new {productName = Eval("[Product name]"), productID = Eval("[Product ID]")}) %>">
                                    <image src='/Images/Products/<%#:Eval("[Product image]")%>'
                                        width="100" height="75" border="1" />
                                </a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="<%#: GetRouteUrl("ProductByName", new {productName = Eval("[Product name]"), productID = Eval("[Product ID]")}) %>">
                                    <%#:Eval("[Product name]")%>
                                </a>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    </p>
                </td>
            </ItemTemplate>
            <LayoutTemplate>
                <table style="width: 100%;">
                    <tbody>
                        <tr>
                            <td>
                                <table id="groupPlaceholderContainer" runat="server" style="width: 100%">
                                    <tr id="groupPlaceholder"></tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr></tr>
                    </tbody>
                </table>
            </LayoutTemplate>
        </asp:ListView>
    </div>
</asp:Content>
