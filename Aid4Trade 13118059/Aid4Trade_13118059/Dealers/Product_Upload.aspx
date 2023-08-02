<%@ Page Title="Качване на продукт" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product_Upload.aspx.cs" Inherits="Aid4Trade_13118059.Dealers.Product_Upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <!-- reg fieldset -->
        <fieldset id="fieldset1" runat="server" style="width: 550px;">
            <legend style="text-align: left">Качване на продукт</legend>
            <table>
                <tr>
                    <td style="font-size: 15px;">
                        <asp:Label ID="product_name" runat="server" Text="Име на продукта:"></asp:Label></td>
                    <td>
                        <input type="text" id="product_name_input" runat="server" /></td>
                </tr>
                <tr>
                    <td style="text-align: right" colspan="2">
                        <asp:RequiredFieldValidator
                            ID="product_name_input_validate"
                            ControlToValidate="product_name_input"
                            ValidationGroup="validate_group"
                            ForeColor="#FE2020"
                            Font-Bold="true"
                            Display="Dynamic"
                            runat="server"
                            ErrorMessage="Не сте въвели име на продукта!">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="font-size: 15px;">
                        <asp:Label ID="product_description" runat="server" Text="Описание на продукта:"></asp:Label></td>
                    <td>
                        <textarea id="product_description_input" runat="server" cols="40" maxlength="200" rows="3" style="resize: none"></textarea></td>
                </tr>
                <tr>
                    <td style="text-align: right" colspan="2">
                        <asp:RequiredFieldValidator
                            ID="product_description_input_validate"
                            ControlToValidate="product_description_input"
                            ValidationGroup="validate_group"
                            ForeColor="#FE2020"
                            Font-Bold="true"
                            Display="Dynamic"
                            runat="server"
                            ErrorMessage="Не сте въвели описание на продукта!">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="font-size: 15px;">
                        <asp:Label ID="product_category" runat="server" Text="Категория на продукта:"></asp:Label></td>
                    <td colspan="2">
                        <asp:DropDownList ID="product_category_dropdownlist" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="font-size: 15px;">
                        <asp:Label ID="product_image" runat="server" Text="Снимка на продукта:"></asp:Label></td>
                    <td>
                        <asp:FileUpload ID="FileUpload" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right" colspan="2">
                        <asp:RequiredFieldValidator
                            ID="FileUpload_validate"
                            ControlToValidate="FileUpload"
                            ValidationGroup="validate_group"
                            ForeColor="#FE2020"
                            Font-Bold="true"
                            Display="Dynamic"
                            runat="server"
                            ErrorMessage="Не сте избрали снимка на продукта!">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="font-size: 15px;">
                        <asp:Label ID="product_price" runat="server" Text="Цена на продукта:"></asp:Label>
                        <br />
                    </td>
                    <td>
                        <input type="text" id="product_price_input" runat="server" />
                        <br />
                        <asp:Label ID="product_price_info" runat="server" Font-Size="Small" Text="(може да не бъде зададена цена)"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right" colspan="2">
                        <asp:RegularExpressionValidator
                            ID="product_price_input_validate"
                            ControlToValidate="product_price_input"
                            ValidationGroup="validate_group"
                            ValidationExpression="^\d{0,8}([.,]\d{1,2})?$"
                            ForeColor="#FE2020"
                            Font-Bold="true"
                            Display="Dynamic"
                            runat="server"
                            ErrorMessage="Невалидна цена!">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Label ID="result" runat="server" Text="" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Label ID="to_result" Visible="false" runat="server" Text="Администраторът на сайта ще прегледа продуктът и ще го публикува, ако той е коректен за системата" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3"></td>
                    <td style="text-align: right">
                        <asp:Button ID="Upload" ValidationGroup="validate_group" runat="server" Text="Качи продукта" OnClick="Upload_Click" />
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>
