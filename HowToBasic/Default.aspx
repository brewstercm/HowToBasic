<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HowToBasic._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <div style="background-color: #FF869E !important" class="jumbotron">
        <p class="lead" style="font-family: 'Bebas Neue'; font-size: xx-large; background-color: #FF869E;">Welcome to howtoBasic! Interested in learning something step by step? If So, then you&#39;ve come to the right place!</p>
        <p class="lead" style="font-family: 'Bebas Neue'; font-size: xx-large; background-color: #FF869E;">You can use the search feature to look up a tutorial or get started with one of our three most popular tutorials by clicking on any of the pictures below!</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Sandwich<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="https://fortheloveofcooking.net/wp-content/uploads/2017/02/sandwich-clipart-burger_sandwich_PNG4138-580x373.png" />
            </h2>
        </div>
        <div class="col-md-4">
            <h2>Archery</h2>
            <p>
                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="https://www.pngitem.com/pimgs/m/226-2263641_hunting-clipart-archery-hunting-bow-and-arrow-clipart.png" />
            </p>
        </div>
        <div class="col-md-4">
            <h2>Coding!</h2>
            <p>
                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="https://imageio.forbes.com/blogs-images/forbestechcouncil/files/2019/01/canva-photo-editor-8-7.png?format=png&amp;width=1200" />
            </p>
        </div>
    </div>

</asp:Content>
