<%@ Page Title="Регистриране на потребител" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register_Form.aspx.cs" Inherits="Aid4Trade_13118059.Dealers.Register_Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <!-- reg fieldset -->
        <fieldset id="fieldset1" runat="server" style="width: 550px;">
            <legend style="text-align: left">Регистрация на търговски акаунт</legend>
            <table>
                <tr>
                    <td style="font-size: 15px; width: 240px;">
                        <asp:Label ID="user" runat="server" Text="Име на търговец:"></asp:Label></td>
                    <td>
                        <input type="text" id="dealer_input" runat="server" placeholder="me" /></td>
                </tr>
                <tr>
                    <td style="text-align: right" colspan="2">
                        <asp:RequiredFieldValidator
                            ID="dealer_input_validate"
                            ControlToValidate="dealer_input"
                            ValidationGroup="validate_group"
                            ForeColor="#FE2020"
                            Font-Bold="true"
                            Display="Dynamic"
                            runat="server"
                            ErrorMessage="Не сте въвели име на търговец!">
                        </asp:RequiredFieldValidator>
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
                            ID="pass_type_validate"
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
                    <td style="font-size: 15px;">
                        <asp:Label ID="conf_pass" runat="server" Text="Повторете паролата:"></asp:Label></td>
                    <td>
                        <input type="password" id="conf_pass_input" runat="server" placeholder="****" /></td>
                </tr>
                <tr>
                    <td style="text-align: right" colspan="2">
                        <asp:RequiredFieldValidator
                            ID="conf_pass_type_validate"
                            ControlToValidate="conf_pass_input"
                            ValidationGroup="validate_group"
                            ForeColor="#FE2020"
                            Font-Bold="true"
                            Display="Dynamic"
                            runat="server"
                            ErrorMessage="Не сте въвели повторна парола!">
                        </asp:RequiredFieldValidator>
                        <asp:CompareValidator
                            ErrorMessage="Паролите не съвпадат."
                            ForeColor="#FE2020"
                            Display="Dynamic"
                            ValidationGroup="validate_group"
                            Font-Bold="true"
                            ControlToCompare="pass_input"
                            ControlToValidate="conf_pass_input"
                            runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="font-size: 15px;">
                        <asp:Label ID="dealer_description" runat="server" Text="Описание на търговеца:"></asp:Label></td>
                    <td>
                        <textarea id="dealer_description_input" runat="server" cols="40" maxlength="200" rows="3" placeholder="С какво се занимавате като търговец" style="resize: none"></textarea></td>
                </tr>
                <tr>
                    <td style="text-align: right" colspan="2">
                        <asp:RequiredFieldValidator
                            ID="dealer_description_input_validate"
                            ControlToValidate="dealer_description_input"
                            ValidationGroup="validate_group"
                            ForeColor="#FE2020"
                            Font-Bold="true"
                            Display="Dynamic"
                            runat="server"
                            ErrorMessage="Не сте въвели описание на търговеца!">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="font-size: 15px;">
                        <asp:Label ID="dealer_type" runat="server" Text="Вид на търговеца:"></asp:Label></td>
                    <td colspan="2">
                        <asp:DropDownList ID="dealer_type_dropdownlist" runat="server">
                            <asp:ListItem Text="Физическо лице" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Юридическо лице" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="font-size: 15px;">
                        <asp:Label ID="country" runat="server" Text="Държава:"></asp:Label></td>
                    <td>
                        <input type="text" id="country_input" runat="server" placeholder="България" /></td>
                </tr>
                <tr>
                    <td style="text-align: right" colspan="2">
                        <asp:RequiredFieldValidator
                            ID="contry_input_validate"
                            ControlToValidate="country_input"
                            ValidationGroup="validate_group"
                            ForeColor="#FE2020"
                            Font-Bold="true"
                            Display="Dynamic"
                            runat="server"
                            ErrorMessage="Не сте въвели държава!">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="font-size: 15px;">
                        <asp:Label ID="city" runat="server" Text="Град:"></asp:Label></td>
                    <td>
                        <input type="text" id="city_input" runat="server" placeholder="София" /></td>
                </tr>
                <tr>
                    <td style="text-align: right" colspan="2">
                        <asp:RequiredFieldValidator
                            ID="city_input_validate"
                            ControlToValidate="city_input"
                            ValidationGroup="validate_group"
                            ForeColor="#FE2020"
                            Font-Bold="true"
                            Display="Dynamic"
                            runat="server"
                            ErrorMessage="Не сте въвели град!">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="font-size: 15px;">
                        <asp:Label ID="dealer_phone" runat="server" Text="Телефон:"></asp:Label></td>
                    <td>
                        <input type="text" id="dealer_phone_input" runat="server" placeholder="+359 08 654 5730" /></td>
                </tr>
                <tr>
                    <td style="text-align: right" colspan="2">
                        <asp:RequiredFieldValidator
                            ID="dealer_phone_input_validate"
                            ControlToValidate="dealer_phone_input"
                            ValidationGroup="validate_group"
                            ForeColor="#FE2020"
                            Font-Bold="true"
                            Display="Dynamic"
                            runat="server"
                            ErrorMessage="Не сте въвели телефон!">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator
                            ID="dealer_phone_input_expression"
                            ControlToValidate="dealer_phone_input"
                            ValidationGroup="validate_group"
                            ValidationExpression="\+\d{3}\s\d{2}\s\d{3}\s\d{4}"
                            ForeColor="#FE2020"
                            Font-Bold="true"
                            Display="Dynamic"
                            runat="server"
                            ErrorMessage="Невалиден телефон!">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td style="font-size: 15px;">
                        <asp:Label ID="email" runat="server" Text="Имейл адрес:"></asp:Label></td>
                    <td>
                        <input type="text" id="email_input" runat="server" placeholder="user@mail.com" /></td>
                </tr>
                <tr>
                    <td style="text-align: right" colspan="2">
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
                        <asp:RequiredFieldValidator
                            ID="email_input_validate"
                            ControlToValidate="email_input"
                            ValidationGroup="validate_group"
                            ForeColor="#FE2020"
                            Font-Bold="true"
                            Display="Dynamic"
                            runat="server"
                            ErrorMessage="Не сте въвели имейл адрес!">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Label ID="failure" runat="server" Text="Вече съществува потребител със същият имейл адрес. Моля попълнете друг." Visible="false" ForeColor="#FE2020"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Label ID="success" runat="server" Text="Регистрацията е успешна." Visible="false" ForeColor="#43B53F"></asp:Label>
                        <asp:Label ID="info" runat="server" Text="<br />Администраторът на сайта ще прегледа данните Ви, и Вие ще бъдете одобрен ако те са коректни." Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3"></td>
                    <td style="text-align: right">
                        <asp:Button ID="reg" runat="server" ValidationGroup="validate_group" Text="Регистрация" OnClick="reg_Click" /></td>
                </tr>
            </table>
        </fieldset>
    </div>
    <br />
    <a style="color: blue" href="RegistrationUsers">Регистрирайте се за нов потребителски акаунт</a>
</asp:Content>
