<%@ Page Title="Преглед на данни за търговец" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View_DealerDetails.aspx.cs" Inherits="Aid4Trade_13118059.Admins.View_DealerDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 500px">
        <asp:FormView ID="dealerDetail" DefaultMode="ReadOnly" runat="server" RenderOuterTable="false" OnItemCreated="dealerDetail_ItemCreated">
            <ItemTemplate>
                <h1>Данни за търговеца</h1>
                <br />
                <tr>
                    <td>
                        <b>Идент. номер на търговеца:</b> <%#:Eval("[Dealer ID]") %>
                        <br />
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
                        <b>Рейтинг:</b> <%#:Eval("[Rating value]") %> / 6
                        <asp:Label ID="rating" runat="server" Text="Label"></asp:Label>
                        <br />
                        <b>Статус:</b>
                        <asp:Label ID="status" runat="server" Text="Label"></asp:Label>
                        <br />
                        <b>Роля в системата:</b>
                        <asp:Label ID="role" runat="server" Text="Label"></asp:Label>
                        <br />
                        <asp:Label ID="result" Visible="false" runat="server" Text="Label"></asp:Label>&nbsp;<a id="result_link" runat="server" visible="false" href='<%# GetRouteUrl("ApproveDisapproveDealers", null) %>'>Към таблицата</a>
                        <br />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:FormView>
        <tr>
            <td>
                <asp:Button ID="approve" ForeColor="Green" Width="200px" runat="server" Text="Одобряване на търговеца" OnClick="approve_Click" OnClientClick="ConfirmApprove()" />
            </td>
            <td style="text-align: right">
                <asp:Button ID="disapprove" ForeColor="Red" Width="200px" runat="server" Text="Неодобряване на търговеца" OnClick="disapprove_Click" OnClientClick="ConfirmDisapprove()" />
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function ConfirmApprove() {
            var confirm_value_approve = document.createElement("INPUT");
            confirm_value_approve.type = "hidden";
            confirm_value_approve.name = "confirm_value_approve";
            if (confirm("Сигурни ли сте че искате да одобрите търговеца?")) {
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
            if (confirm("Сигурни ли сте че искате да неодобрите търговеца?")) {
                confirm_value_disapprove.value = "Да";
            } else {
                confirm_value_disapprove.value = "Не";
            }
            document.forms[0].appendChild(confirm_value_disapprove);
        }
    </script>
</asp:Content>
