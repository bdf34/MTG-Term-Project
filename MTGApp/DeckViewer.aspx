<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeckViewer.aspx.cs" Inherits="MTGApp.DeckViewer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            Choose your deck:
            <select id="Select1" multiple="false" runat="server"/>
            <asp:PlaceHolder ID="ConfirmDeck" runat="server" />
            <asp:PlaceHolder ID="DeckDisplay" runat="server" />
            <asp:PlaceHolder ID="ProblemCardDisplay" runat="server" />
            <asp:PlaceHolder ID="ProblemCardEntry" runat="server" />
            <asp:PlaceHolder ID="DeckEntry" runat="server" />
            <asp:PlaceHolder ID="SuggestCardButton" runat="server" />
            <asp:PlaceHolder ID="SuggestedCard" runat="server" />


         <asp:Repeater ID="Repeater1" runat="server" 
          DataSourceID="SqlDataSource1">
          <HeaderTemplate>
              <table>
              <tr>
                 <th>Card ID Number</th>
                 <th>Quantity</th>
              </tr>
          </HeaderTemplate>

          <ItemTemplate>
          <tr>
              <td bgcolor="#CCFFCC">
                <asp:Label runat="server" ID="Label1" 
                    text='<%# Eval("cardID") %>' />
              </td>
              <td bgcolor="#CCFFCC">
                  <asp:Label runat="server" ID="Label2" 
                      text='<%# Eval("quantity") %>' />
              </td>
          </tr>
          </ItemTemplate>

          <AlternatingItemTemplate>
          <tr>
              <td >
                <asp:Label runat="server" ID="Label3" 
                    text='<%# Eval("cardID") %>' />
              </td>
              <td >
                 <asp:Label runat="server" ID="Label4" 
                     text='<%# Eval("quantity") %>' />
              </td>
          </tr>
          </AlternatingItemTemplate>

          <FooterTemplate>
              </table>
          </FooterTemplate>
      </asp:Repeater>

                  <asp:SqlDataSource 
          ConnectionString=
              "<%$ ConnectionStrings:myServer %>"
          ID="SqlDataSource1" runat="server" 
          SelectCommand="SELECT [cardID], [quantity] FROM [DeckList] WHERE [deckID] = 107">
      </asp:SqlDataSource>


        </div>
         <td><asp:TextBox ID="RandomDeck" placeholder="Random Deck" style="text-align: center" runat="server"></asp:TextBox></td>
         <td><asp:PlaceHolder ID="RandomDeckButton" runat="server"/></td>
        <td><asp:Label ID="ErrorMsg" style="color:red" runat="server"></asp:Label></td>
    </form>
</body>
</html>