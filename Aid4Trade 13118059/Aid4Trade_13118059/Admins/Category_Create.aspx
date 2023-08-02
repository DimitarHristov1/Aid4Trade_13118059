<%@ Page Title="Създаване на категория" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Category_Create.aspx.cs" Inherits="Aid4Trade_13118059.Admins.Category_Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <fieldset id="fieldset1" runat="server" style="width: 500px;">
            <legend style="text-align: left">Създаване на категория</legend>
            <table>
                <tr>
                    <td style="font-size: 15px;">
                        <asp:Label ID="category_name" runat="server" Text="Име на категорията:"></asp:Label></td>
                    <td>
                        <input type="text" id="category_name_input" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right" colspan="2">
                        <asp:RequiredFieldValidator
                            ID="product_name_input_validate"
                            ControlToValidate="category_name_input"
                            ValidationGroup="validate_group"
                            ForeColor="#FE2020"
                            Font-Bold="true"
                            Display="Dynamic"
                            runat="server"
                            ErrorMessage="Не сте въвели име на категорията!">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="font-size: 15px;">
                        <asp:Label ID="category_description" runat="server" Text="Описание на категорията:"></asp:Label></td>
                    <td>
                        <textarea id="category_description_input" runat="server" cols="40" maxlength="200" rows="3" style="resize: none"></textarea></td>
                </tr>
                <tr>
                    <td style="text-align: right" colspan="2">
                        <asp:RequiredFieldValidator
                            ID="product_description_input_validate"
                            ControlToValidate="category_description_input"
                            ValidationGroup="validate_group"
                            ForeColor="#FE2020"
                            Font-Bold="true"
                            Display="Dynamic"
                            runat="server"
                            ErrorMessage="Не сте въвели описание на категорията!">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="category_exists" Visible="false" runat="server" Text="Категорията съществува!"></asp:Label>
                        <asp:Label ID="category_created" Visible="false" runat="server" Text="Категорията е създадена."></asp:Label>
                    </td>
                    <td style="text-align: right">
                        <asp:Button ID="Create" ValidationGroup="validate_group" runat="server" Text="Създай категория" OnClick="Create_Click" />
                </tr>
            </table>
            <b>В системата са създадени следните категории:</b>
            <br />
            <asp:ListView ID="categoryList" runat="server">
                <ItemTemplate>
                    <b style="font-size: medium; font-style: normal">
                        <a title="<%# Eval("[Category description]") %>" href="<%#: GetRouteUrl("CategoryByName", new {categoryName = Eval("[Category name]")}) %>">
                            <%# Eval("[Category name]") %>
                        </a>
                    </b>
                </ItemTemplate>
                <ItemSeparatorTemplate>, </ItemSeparatorTemplate>
            </asp:ListView>
        </fieldset>
    </div>
</asp:Content>
