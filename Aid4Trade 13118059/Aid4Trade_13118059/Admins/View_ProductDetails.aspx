<%@ Page Title="Преглед на данни за продукт" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View_ProductDetails.aspx.cs" Inherits="Aid4Trade_13118059.Admins.View_ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 750px">
        <asp:FormView ID="productDetail" DefaultMode="ReadOnly" runat="server" RenderOuterTable="false" OnItemCreated="productDetail_ItemCreated">
            <ItemTemplate>
                <h1>Данни за продукта</h1>
                <br />
                <tr>
                    <td>
                        <img src="/Images/Products/<%#:Eval("[Product image]") %>" style="border: solid; height: 300px;width:300px;" alt="<%#:Eval("[Product name]") %>" />
                    </td>
                    <td>
                        <b>Идент. номер на продукта:</b> <%#:Eval("[Product ID]") %>
                        <br />
                        <b>Име на продукта:</b> <%#:Eval("[Product name]") %>
                        <br />
                        <b>Предложен от:</b> <a href="<%#: GetRouteUrl("DealerInfo", new {dealerName = Eval("[Dealer name]"), dealerID = Eval("[Dealer ID]")}) %>"><%#:Eval("[Dealer name]")%></a>
                        <br />
                        <b>Продуктът е предложен за категория:</b> <a href="<%#GetRouteUrl("CategoryByName", new {categoryName = Eval("[Category name]")})%>"><%#:Eval("[Category name]")%></a>
                        <br />
                        <b>Описание на продукта:</b>
                        <br />
                        <%#:Eval("[Product description]") %>
                        <br />
                        <b>Цена на продукта:</b> <span id="price" visible="false" runat="server">&nbsp;<%#: String.Format("{0:c}", Eval("[Product price]")) %></span><asp:Label ID="no_price" runat="server" Text="Label"></asp:Label></span>
                        <br />
                        <b>Статус:</b>
                        <asp:Label ID="status" runat="server" Text="Label"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="result" Visible="false" runat="server" Text="Label"></asp:Label>&nbsp;<a id="result_link" runat="server" visible="false" href='<%# GetRouteUrl("ApproveDisapproveProducts", null) %>'>Към таблицата</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:FormView>
        <tr>
            <td>
                <br />
                <asp:Button ID="approve" ForeColor="Green" Width="200px" runat="server" Text="Одобряване на продукта" OnClick="approve_Click" OnClientClick="ConfirmApprove()" />
            </td>
            <td style="text-align: right">
                <asp:Button ID="disapprove" ForeColor="Red" Width="200px" runat="server" Text="Неодобряване на продукта" OnClick="disapprove_Click" OnClientClick="ConfirmDisapprove()" />
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function ConfirmApprove() {
            var confirm_value_approve = document.createElement("INPUT");
            confirm_value_approve.type = "hidden";
            confirm_value_approve.name = "confirm_value_approve";
            if (confirm("Сигурни ли сте че искате да одобрите продукта?")) {
                confirm_value_approve.value = "Да";
            } else {
                confirm_value_approve.value = "Не";
            }
            document.forms[0].appendChild(confirm_value_approve);
        }
        function ConfirmDisapprove() {
            var confirm_value_disapprove = document.createElement("INPUT");
            confirm_value_disapprove.type = "hidden";
            confirm_value_disapprove.name = "confirm_value_disapprove";
            if (confirm("Сигурни ли сте че искате да неодобрите продукта?")) {
                confirm_value_disapprove.value = "Да";
            } else {
                confirm_value_disapprove.value = "Не";
            }
            document.forms[0].appendChild(confirm_value_disapprove);
        }
    </script>
</asp:Content>
