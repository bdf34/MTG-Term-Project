<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="DeckViewer.aspx.cs" Inherits="MTGApp.DeckViewer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >
    <h3 ID="problemHeader" runat="server" Style="float:right; margin-left: 177px;">Enter your Problem Cards here</h3>
    <br /><br />
Choose your deck:
    
    <br /><br /> <asp:TextBox ID="ProblemCardEntry" Style="float:right"  Wrap="true" runat="server" Width ="500"/>
    <br /> 
<select id="Select1" multiple="false" runat="server" style="float:left"/>   <asp:PlaceHolder ID="PlaceHolder1" runat="server" /> 
   
    <div style="text-align:center; float:unset">
            <asp:PlaceHolder ID="SuggestCardButton" runat="server" />
            Div area
   </div>
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
            <a href="" Style="float:right">
<img  ID ="suggestion1" runat="server"/>
</a>
            <h5 runat="server" id="suggestedCardsText">Suggested cards</h5>
            <a href="" Style="float:right">
<img  ID ="suggestion2" runat="server"/>
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

    </select>

</asp:Content>