<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchPage.aspx.cs" Inherits="HowToBasic.SearchPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Here are the Search Results</h3>
    <div class ="col-sm-3">
         <asp:ImageButton ID="searchedTutorial" runat="server" OnClick="searchedTutorial_Click"  />
        <asp:ImageButton ID="searchedTutorial2" runat="server"  />
    </div>
</asp:Content>
