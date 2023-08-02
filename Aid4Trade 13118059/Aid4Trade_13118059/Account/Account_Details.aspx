<%@ Page Title="Информация за акаунта" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Account_Details.aspx.cs" Inherits="Aid4Trade_13118059.Account.Account_Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <!-- login fieldset -->
        <fieldset id="fieldset1" runat="server" style="width:400px;">
            <legend style="text-align:center">Информация за акаунта</legend>
            <table>
                <tr>
                    <td style="font-size:15px; width:200px;"><asp:Label ID="account_type" runat="server" Text="Тип на акаунта:"></asp:Label></td>
                    <td style="font-size:15px; width:200px;"><asp:Label ID="account_type_show" runat="server" Text="..."></asp:Label></td>
                </tr>
                <tr>
                    <td style="font-size:15px; width:200px;"><asp:Label ID="accout_name" runat="server" Text="Име на акаунта:"></asp:Label></td>
                    <td style="font-size:15px; width:200px;"><asp:Label ID="accout_name_show" runat="server" Text="..."></asp:Label></td>
                </tr>
                <tr>
                    <td style="font-size:15px; width:200px;"><asp:Label ID="email_account" runat="server" Text="Имейл адрес:"></asp:Label></td>
                    <td style="font-size:15px; width:200px;"><asp:Label ID="email_account_show" runat="server" Text="..."></asp:Label></td>
                </tr>
            </table>
            </fieldset>
        </div>
</asp:Content>
