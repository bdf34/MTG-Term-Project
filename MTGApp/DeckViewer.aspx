<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="DeckViewer.aspx.cs" Inherits="MTGApp.DeckViewer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >

   <h5 style="text-align:center; float:unset">Choose a deck, and enter cards that give you trouble. We'll suggest cards that might help!  </h5> 

    <h3 ID="problemHeader" runat="server" Style="float:right; margin-left: 177px;">Enter your Problem Cards here</h3>
    <br /><br />
Choose your deck:
    
    <br /><br /> <asp:TextBox ID="ProblemCardEntry" Style="float:right"  Wrap="true" runat="server" Width ="500"/>
    <br /> 
<select id="Select1" multiple="false" runat="server" style="float:left"/>   <asp:PlaceHolder ID="PlaceHolder1" runat="server" /> 
   
    <div style="text-align:center; float:unset">
   <br /><br /><br />
        <asp:PlaceHolder ID="SuggestCardButton" runat="server" />
   </div>
    <br />
    <br />
<h3 id="titleText" runat="server"></h3>
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

    <asp:PlaceHolder ID="PlaceHolder2" runat="server"/> 

        <h3 ID="messageOutput" runat="server" Style="float:right"></h3>
        <a href="" Style="float:right">
<img  ID ="picOutput" runat="server"/>
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
            <br />

    <div style="text-align:center; float:unset">
            <h5 runat="server" id="suggestedCardsText">Suggested cards</h5>
        <br />
            <br />
            <br />
            <br />

            <a href="" Style="float:unset">
<img  ID ="suggestion1" runat="server"/>
</a>        
            <a href="" Style="float:unset">
<img  ID ="suggestion2" runat="server"/>
</a>
    
                <a href="" Style="float:unset">
<img  ID ="suggestion3" runat="server"/>
</a>
        
   </div>
        

    
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
    

</asp:Content>