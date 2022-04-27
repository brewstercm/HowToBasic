<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Coding.aspx.cs" Inherits="HowToBasic.Coding" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <!DOCTYPE html>
<html>
<head>
  <link rel="stylesheet" href="bootstrap.css">
</head>
<body>
    <div class ="codingbody">
            <span class="codingbody3">
            <br />
            Coding<br />
            <br />
            This tutorial will cover as much material as needed for your programming language.
            <br />
            Whether it will be Java, Python, C++, C or any other language. Not to be confused with </span>
            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="#66FF33">Web Programming Languages</asp:HyperLink>
            <span class="codingbody3">,<br />
            which has it&#39;s own tutorial page here. This coding tutorial will cover everything from Basic to Advanced.</span><br />
            <br />
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>Java</asp:ListItem>
                <asp:ListItem>Python</asp:ListItem>
                <asp:ListItem>C++</asp:ListItem>
                <asp:ListItem>C#</asp:ListItem>
                <asp:ListItem>C</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Menu ID="Menu1" runat="server" CssClass="codingTypes" OnMenuItemClick="Menu1_MenuItemClick">
                <Items>
                    <asp:MenuItem Text="Input/Output" Value="Input/Output"></asp:MenuItem>
                    <asp:MenuItem Text="Operators" Value="Operators"></asp:MenuItem>
                    <asp:MenuItem Text="Strings" Value="Strings"></asp:MenuItem>
                    <asp:MenuItem Text="Arrays" Value="Arrays"></asp:MenuItem>
                    <asp:MenuItem Text="OOP" Value="OOP"></asp:MenuItem>
                    <asp:MenuItem Text="Inheritance" Value="Inheritance"></asp:MenuItem>
                    <asp:MenuItem Text="Abstraction" Value="Abstraction"></asp:MenuItem>
                    <asp:MenuItem Text="Encapsulation" Value="Encapsulation"></asp:MenuItem>
                    <asp:MenuItem Text="Polymorphism" Value="Polymorphism"></asp:MenuItem>
                    <asp:MenuItem Text="Constructors" Value="Constructors"></asp:MenuItem>
                    <asp:MenuItem Text="Methods" Value="Methods"></asp:MenuItem>
                    <asp:MenuItem Text="Packages" Value="Packages"></asp:MenuItem>
                </Items>
            </asp:Menu>
            <br />
            <asp:Button ID="Continue" runat="server" CssClass="btn btn-primary" Text="Apply" />
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
    </div>


</body>
</html>
  
</asp:Content>
