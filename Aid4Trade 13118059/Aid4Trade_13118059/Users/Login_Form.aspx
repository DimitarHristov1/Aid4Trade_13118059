<%@ Page Title="Вход за потребители" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login_Form.aspx.cs" Inherits="Aid4Trade_13118059.Users.Login_Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <!-- login fieldset -->
        <fieldset id="fieldset1" runat="server" style="width: 500px;">
            <legend style="text-align: left">Вход за потребители</legend>
            <table>
                <tr>
                    <td style="font-size: 15px; width: 240px;">
                        <asp:Label ID="user" runat="server" Text="Имейл адрес:"></asp:Label></td>
                    <td>
                        <input type="text" id="email_input" runat="server" placeholder="user@mail.com" /></td>
                </tr>
                <tr>
                    <td style="text-align: right" colspan="2">
                        <asp:RequiredFieldValidator
                            ID="email_input_validate"
                            ControlToValidate="email_input"
                            ForeColor="#FE2020"
                            ValidationGroup="validate_group"
                            Font-Bold="true"
                            Display="Dynamic"
                            runat="server"
                            ErrorMessage="Не сте въвели имейл адрес!">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator
                            ID="email_input_validate_expression"
                            ControlToValidate="email_input"
                            ValidationGroup="validate_group"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ForeColor="#FE2020"
                            Font-Bold="true"
                            Display="Dynamic"
                            runat="server"
                            ErrorMessage="Невалиден имейл адрес!">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td style="font-size: 15px;">
                        <asp:Label ID="pass" runat="server" Text="Парола:"></asp:Label></td>
                    <td>
                        <input type="password" id="pass_input" runat="server" placeholder="****" /></td>
                </tr>
                <tr>
                    <td style="text-align: right" colspan="2">
                        <asp:RequiredFieldValidator
                            ID="pass_input_validate"
                            ControlToValidate="pass_input"
                            ValidationGroup="validate_group"
                            ForeColor="#FE2020"
                            Font-Bold="true"
                            Display="Dynamic"
                            runat="server"
                            ErrorMessage="Не сте въвели парола!">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Label ID="failure" runat="server" Text="Грешен имейл адрес или парола" Visible="false" ForeColor="#FE2020" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:CheckBox ID="checkbox" runat="server" Text="&nbsp Запомни ме" /></td>
                    <td style="text-align: right">
                        <asp:Button ID="reg" runat="server" Text="Вход" ValidationGroup="validate_group" OnClick="login_Click" /></td>
                </tr>
            </table>
        </fieldset>
    </div>
    <div style="float: right; margin-top: -60px; margin-right: 400px;"><a style="font-size: 18px; color: green" href="LoginDealers">Вход за търговци</a></div>
    <br />
    <a href="RegistrationUsers">Регистриране на нов потребителски акаунт</a>
    <br />
</asp:Content>
