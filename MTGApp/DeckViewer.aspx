<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="DeckViewer.aspx.cs" Inherits="MTGApp.DeckViewer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >
        
<h3 id="fuckingHell" runat="server">Test Text</h3>
    
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
                    text='<%# Eval("name") %>' />
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
                    text='<%# Eval("name") %>' />
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
            <asp:PlaceHolder ID="PlaceHolder1" runat="server" />
            <asp:PlaceHolder ID="DeckDisplay" runat="server" />
            <asp:PlaceHolder ID="ProblemCardDisplay" runat="server" />
            <asp:PlaceHolder ID="ProblemCardEntry" runat="server" />
            <asp:PlaceHolder ID="DeckEntry" runat="server" />
            <asp:PlaceHolder ID="SuggestCardButton" runat="server" />
            <asp:PlaceHolder ID="SuggestedCard" runat="server" />


         

                  <asp:SqlDataSource 
          ConnectionString=
              "<%$ ConnectionStrings:myServer %>"
          ID="SqlDataSource1" runat="server" 
          SelectCommand="SELECT  Decks.deckName, Card.name, DeckList.quantity FROM Decks, DeckList, Card WHERE 
                      Card.cardID = DeckList.cardID and Decks.deckID = DeckList.deckID and DeckList.deckID = 142;">
      </asp:SqlDataSource>


        </div>
         <td><asp:TextBox ID="RandomDeck" placeholder="Random Deck" style="text-align: center" runat="server"></asp:TextBox></td>
         <td><asp:PlaceHolder ID="RandomDeckButton" runat="server"/></td>
        <td><asp:Label ID="ErrorMsg" style="color:red" runat="server"></asp:Label></td>

    <a href="" class="cancel" title="Cancel">
<img src="https://c1.scryfall.com/file/scryfall-cards/large/front/8/6/86bf43b1-8d4e-4759-bb2d-0b2e03ba7012.jpg?1562242171"  width="20%" />
</a>

    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

</asp:Content>