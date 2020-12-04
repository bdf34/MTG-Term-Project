<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RandomDeck.aspx.cs" Inherits="MTGApp.DeckEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:PlaceHolder ID="ConfirmDeck" runat="server" />


     <asp:TextBox ID="RandomDeck" placeholder="Random Deck" style="text-align: center" runat="server"></asp:TextBox></>
     <asp:PlaceHolder ID="RandomDeckButton" runat="server"/>
     <asp:Label ID="ErrorMsg" style="color:red" runat="server"></asp:Label>
    <br />
            <br />
        <asp:Repeater ID="Repeater1" runat="server" > 
          <HeaderTemplate>
              <table  style="align-self">
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
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />


</asp:Content>
