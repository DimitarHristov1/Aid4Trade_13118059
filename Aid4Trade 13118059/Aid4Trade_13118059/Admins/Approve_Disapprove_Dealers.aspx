<%@ Page Title="Одобряване/неодобряване на търговци" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Approve_Disapprove_Dealers.aspx.cs" Inherits="Aid4Trade_13118059.Admins.Approve_Disapprove_Dealers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset style="margin: auto; text-align: center; width: 1000px;">
        <legend style="text-align: center">Одобряване/Неодобряване на търговци</legend>
    </fieldset>
    <br />
    <asp:GridView ID="dealers_dridview" runat="server" AutoGenerateColumns="False" AllowPaging="True"
        OnPageIndexChanging="OnPaging" CellPadding="4" PageSize="5" ForeColor="#333333" GridLines="Vertical" OnRowDataBound="dealers_dridview_RowDataBound">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField ItemStyle-Width="200px" ItemStyle-Wrap="false" HeaderStyle-Width="200px" HeaderStyle-Wrap="false" DataField="Dealer ID" HeaderText="Идент. номер"></asp:BoundField>
            <asp:BoundField ItemStyle-Width="200px" ItemStyle-Wrap="false" HeaderStyle-Width="200px" HeaderStyle-Wrap="false" DataField="Dealer name" HeaderText="Търговско име"></asp:BoundField>
            <asp:BoundField ItemStyle-Width="200px" ItemStyle-Wrap="false" HeaderStyle-Width="200px" HeaderStyle-Wrap="false" DataField="Dealer type" HeaderText="Тип на търговеца"></asp:BoundField>
            <asp:BoundField ItemStyle-Width="200px" ItemStyle-Wrap="false" HeaderStyle-Width="200px" HeaderStyle-Wrap="false" DataField="Dealer email" HeaderText="Имейл"></asp:BoundField>
            <asp:BoundField ItemStyle-Width="200px" ItemStyle-Wrap="false" HeaderStyle-Width="200px" HeaderStyle-Wrap="false" DataField="Rating value" HeaderText="Рейтинг"></asp:BoundField>
            <asp:BoundField ItemStyle-Width="200px" ItemStyle-Wrap="false" HeaderStyle-Width="200px" HeaderStyle-Wrap="false" DataField="Dealer status" HeaderText="Статус"></asp:BoundField>
            <asp:BoundField ItemStyle-Width="200px" ItemStyle-Wrap="false" HeaderStyle-Width="200px" HeaderStyle-Wrap="false" DataField="Dealer role" HeaderText="Роля в системата"></asp:BoundField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink runat="server" ID="navigate" Width="150px" Style="text-align: center" NavigateUrl='<%# GetRouteUrl("ViewDealerDetails", new { dealerID = Eval("[Dealer ID]") })  %>' Text="Виж детайли" />
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
</asp:Content>
