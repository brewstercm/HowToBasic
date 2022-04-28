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
            <asp:ListBox ID="ListBox1" runat="server">
                <asp:ListItem>Input/Output</asp:ListItem>
                <asp:ListItem>Operators</asp:ListItem>
                <asp:ListItem>Strings</asp:ListItem>
                <asp:ListItem>Arrays</asp:ListItem>
                <asp:ListItem>OOP</asp:ListItem>
                <asp:ListItem>Inheritance</asp:ListItem>
                <asp:ListItem>Abstraction</asp:ListItem>
                <asp:ListItem>Encapsulation</asp:ListItem>
                <asp:ListItem>Polymorphism</asp:ListItem>
                <asp:ListItem>Constructors</asp:ListItem>
                <asp:ListItem>Methods</asp:ListItem>
                <asp:ListItem>Packages</asp:ListItem>
                <asp:ListItem>Objects</asp:ListItem>
            </asp:ListBox>
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