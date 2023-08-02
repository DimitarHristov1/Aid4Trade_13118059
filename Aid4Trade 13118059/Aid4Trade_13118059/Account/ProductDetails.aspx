<%@ Page Title="Данни за продукт" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="Aid4Trade_13118059.Account.ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        body {
        }

        .formDesign {
            background-color: #99ccff;
            padding: 10px;
            width: 600px;
            margin-bottom: 10px;
        }

        .commentbox {
            width: 580px;
            word-break: break-all;
            padding: 10px;
            margin-bottom: 4px;
        }

        .buttonSubmit {
            background-color: #007acc;
            padding: 4px;
            border: none;
            color: white;
        }

        .buttonSubmit:hover {
            background-color: #3ea7ed;

        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:FormView ID="productDetail" DefaultMode="ReadOnly" runat="server" RenderOuterTable="false" OnItemCreated="productDetail_ItemCreated">
                <ItemTemplate>
                    <div>
                        <h1><%#: Eval("[Product name]") %></h1>
                    </div>
                    
                    <br />
                    <table>
                        <tr>
                            <td>
                                <img src="/Images/Products/<%#:Eval("[Product image]") %>" style="border: solid; height: 300px;width:300px;" alt="<%#:Eval("[Product name]") %>" />
                            </td>
                            <td>&nbsp;</td>
                            <td style="vertical-align: top; text-align: left;">
                                <b>Описание на продукта:</b>
                                <br />
                                <%#:Eval("[Product description]") %>
                                <br />
                                <span><b>Цена на продукта:</b> <span id="price" visible="false" runat="server">&nbsp;<%#: String.Format("{0:c}", Eval("[Product price]")) %></span><asp:Label ID="no_price" runat="server" Text="Label"></asp:Label></span>
                                <br />
                                <span><b>Предложен от:</b>&nbsp;<a href="<%#: GetRouteUrl("DealerInfo", new {dealerName = Eval("[Dealer name]"), dealerID = Eval("[Dealer ID]")}) %>"><%#:Eval("[Dealer name]")%></a></span>&nbsp;<asp:ImageButton ID="thumb_up" OnClick="thumb_up_Click" ToolTip="Гласувайте положително за търговеца" ImageUrl="~/Images/thumb-up.png" runat="server" />
                                &nbsp;<asp:ImageButton ID="thumb_down" OnClick="thumb_down_Click" ToolTip="Гласувайте отрицателно за търговеца" ImageUrl="~/Images/thumb-down.png" runat="server" />
                                <br />
                                <span><b>Рейтинг на търговеца:</b>&nbsp;<%#:Eval("[Rating value]")%></span>&nbsp;/ 6&nbsp;(<asp:Label ID="rating" runat="server" Text="Label"></asp:Label>)
                                <br />
                                <asp:Label ID="dealer_admin" runat="server" Visible="false" Text="Label"></asp:Label>
                                <br />
                                <asp:Label ID="if_voted" runat="server" Visible="false" Text="Label"></asp:Label>
                                <br />
                                <span runat="server" id="register" visible="false" style="color: red">Не сте влезли в системата. <span style="color: black">Натиснете <a href="<%# GetRouteUrl("LoginUsers", null) %>">линка</a>.</span></span>
                                <br />
                                <asp:Label ID="result_from_procedure" runat="server" Visible="false" Text="Label"></asp:Label>
                                <br />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:FormView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <div>
                <div class="formDesign">
                    <table style="width: 200px;">
                        <tr>
                            <td class="auto-style1" style="font-size: 18px">Коментар&nbsp;&nbsp;</td>
                            <td class="auto-style2">
                                <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Style="resize: none;width:800px;min-width:130%;height:80px;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="comment_submit" CausesValidation="false" runat="server" Text="Публикувай коментара" CssClass="buttonSubmit" OnClick="comment_submit_Click" />
                            </td>
                            <td>&nbsp;                        
                            </td>
                        </tr>
                        <asp:Label ID="for_comments_info" Visible="false" runat="server" Text="Label"></asp:Label>
                        <span runat="server" id="register_comment" visible="false" style="color: red">Не сте влезли в системата. <span style="color: black">Натиснете <a href="<%: GetRouteUrl("LoginUsers", null) %>">линка</a>.</span></span>
                    </table>
                    <h4 style="text-decoration: underline;">Коментари:</h4>
                    <asp:Repeater ID="Comments" runat="server">
                        <ItemTemplate>
                            <div class="commentbox">
                                <a href="<%# GetRouteUrl("UserInfo", new {userName = Eval("[User name]"), userID = Eval("[User ID]")}) %>"><b>
                                    <asp:Label ID="User_Name" runat="server" Text='<%#Eval("[User name]") %>'></asp:Label></b></a>, написа:<br />
                                <asp:TextBox ID="txtComment" runat="server" ReadOnly="true" TextMode="MultiLine" style="background-color:#99ccff;border: 0.5px solid #333399;resize: none;width:100px;min-width:100%;height:80px;" Text='<%#Eval("[Description of the comment]") %>'></asp:TextBox>
                                <br />
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div style="overflow: hidden;">
                        <asp:Repeater ID="page_numb" runat="server" OnItemCommand="page_ItemCommand">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnPage"
                                    Style="padding: 8px; margin: 2px; background: #007acc; border: solid 1px blue; font: 8px;"
                                    CommandName="Page" CommandArgument="<%# Container.DataItem %>"
                                    runat="server" ForeColor="White" Font-Bold="True" CausesValidation="false"><%# Container.DataItem %>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
