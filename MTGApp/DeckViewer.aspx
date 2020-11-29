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
                 <th>Name</th>
                 <th>Description</th>
              </tr>
          </HeaderTemplate>

          <ItemTemplate>
          <tr>
              <td bgcolor="#CCFFCC">
                <asp:Label runat="server" ID="Label1" 
                    text='<%# Eval("userID") %>' />
              </td>
              <td bgcolor="#CCFFCC">
                  <asp:Label runat="server" ID="Label2" 
                      text='<%# Eval("deckName") %>' />
              </td>
          </tr>
          </ItemTemplate>

          <AlternatingItemTemplate>
          <tr>
              <td >
                <asp:Label runat="server" ID="Label3" 
                    text='<%# Eval("userID") %>' />
              </td>
              <td >
                 <asp:Label runat="server" ID="Label4" 
                     text='<%# Eval("deckName") %>' />
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
          SelectCommand="SELECT [deckID], [userID], 
              [deckName] FROM [DeckLIst]">
      </asp:SqlDataSource>


        </div>
    </form>
</body>
</html>
