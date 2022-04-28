<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchPage.aspx.cs" Inherits="HowToBasic.SearchPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Here is the Search Result</h3>
    <br />
    <asp:Label ID ="displayPage" runat="server"></asp:Label>
    <%--<div class ="col-sm-3">
         <asp:ImageButton ID="searchedTutorial" runat="server" OnClick="searchedTutorial_Click"  />
        <asp:ImageButton ID="searchedTutorial2" runat="server"  />
    </div>--%>
</asp:Content>