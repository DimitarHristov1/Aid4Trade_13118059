<%@ Page Title="Одобряване/неодобряване на продукти" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Approve_Disapprove_Products.aspx.cs" Inherits="Aid4Trade_13118059.Admins.Approve_Disapprove_Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset style="margin: auto; text-align: center; width: 1000px;">
        <legend style="text-align: center">Одобряване/Неодобряване на продукти</legend>
    </fieldset>
    <br />
    <div style="width:670px;margin-left:auto;margin-right:auto">
    <asp:GridView ID="products_dridview" runat="server" AutoGenerateColumns="False" AllowPaging="True"
        OnPageIndexChanging="OnPaging" CellPadding="4" PageSize="5" ForeColor="#333333" GridLines="Vertical" OnRowDataBound="products_dridview_RowDataBound">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField ItemStyle-Width="200px" ItemStyle-Wrap="false" HeaderStyle-Width="200px" HeaderStyle-Wrap="false" DataField="Product ID" HeaderText="Идент. номер"></asp:BoundField>
            <asp:BoundField ItemStyle-Width="200px" ItemStyle-Wrap="false" HeaderStyle-Width="200px" HeaderStyle-Wrap="false" DataField="Product name" HeaderText="Име на продукта"></asp:BoundField>
            <asp:BoundField ItemStyle-Width="200px" ItemStyle-Wrap="false" HeaderStyle-Width="200px" HeaderStyle-Wrap="false" DataField="Product status" HeaderText="Статус"></asp:BoundField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink runat="server" ID="navigate" Width="150px" Style="text-align: center" NavigateUrl='<%# GetRouteUrl("ViewProductDetails", new { productID = Eval("[Product ID]") })  %>' Text="Виж детайли" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
        </div>
</asp:Content>
