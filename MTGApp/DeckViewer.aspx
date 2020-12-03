<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="DeckViewer.aspx.cs" Inherits="MTGApp.DeckViewer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >

Choose your deck:
    <br />
<select id="Select1" multiple="false" runat="server" style="float:left"/>   <asp:PlaceHolder ID="PlaceHolder1" runat="server" />
    
<h3 id="titleText" runat="server">Test Text</h3>
    <asp:TextBox ID="ProblemCardEntry" Style="float:right"  Wrap="true" TextMode="MultiLine" mode="multiline" runat="server" Width ="500" Height ="500"/>
    <asp:Repeater ID="Repeater1" runat="server" > 
          <HeaderTemplate>
              <table  style="float:left">
              <tr>
                 <th>Card ID Number</th>
                 <th>Quantity</th>
              </tr>
          </HeaderTemplate>
        
          <ItemTemplate>
          <tr>
              <td bgcolor="#CCFFCC">
                <asp:Label runat="server" ID="Label1" 
                    text='<%# Eval("cardName") %>' />
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
                    text='<%# Eval("cardName") %>' />
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
    
    
        
        <br />
    
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
            
            <asp:PlaceHolder ID="ConfirmDeck" runat="server" />
            
            
            <asp:PlaceHolder ID="ProblemCardDisplay" runat="server" />
            
            
            <asp:PlaceHolder ID="SuggestCardButton" runat="server" />
            <asp:PlaceHolder ID="SuggestedCard" runat="server" />
        
        <asp:textbox id="DeckEntry" mode="multiline" runat="server"/>
         

                  


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

</asp:Content>