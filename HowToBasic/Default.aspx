<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HowToBasic._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <p class="lead" >Welcome to HowToBasic! Interested in learning something step by step? If so, then you&#39;ve come to the right place!</p>
        <p class="lead" >You can use the search feature to look up a tutorial or get started with one of our three most popular tutorials by clicking on any of the pictures below!</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h8><span class="poptutors">Sandwich<br />
            </span><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="https://fortheloveofcooking.net/wp-content/uploads/2017/02/sandwich-clipart-burger_sandwich_PNG4138-580x373.png" OnClick="ImageButton1_Click" />
            </h8>
        </div>
        <div class="col-md-4">
            <h8>Archery</h8>
            <p>
                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="https://www.pngitem.com/pimgs/m/226-2263641_hunting-clipart-archery-hunting-bow-and-arrow-clipart.png" />
            </p>
        </div>
        <div class="col-md-4">
            <h8>Coding!</h8>
            <p>
                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="https://imageio.forbes.com/blogs-images/forbestechcouncil/files/2019/01/canva-photo-editor-8-7.png?format=png&amp;width=1200" OnClick="ImageButton3_Click" />
            </p>
        </div>
    </div>

</asp:Content>
