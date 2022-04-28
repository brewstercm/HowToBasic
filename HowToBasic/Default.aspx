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
                <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="https://clipartix.com/wp-content/uploads/2017/03/Free-sports-archery-clipart-clip-art-pictures-graphics-3.jpg" />
            </p>
        </div>
        <div class="col-md-4">
            <h8>Coding!</h8>
            <p>
                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="https://www.zdnet.com/a/img/resize/8974d46cae052b00495ab2989e14523134ca610b/2021/07/19/8a337c80-5ed6-43a1-98fb-b981d420890f/programming-languages-shutterstock-1680857539.jpg?width=770&height=578&fit=crop&auto=webp" OnClick="ImageButton3_Click" />
            </p>
        </div>
    </div>

</asp:Content>
