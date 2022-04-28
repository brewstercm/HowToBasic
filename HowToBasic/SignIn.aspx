<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="HowToBasic.SignIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class ="row">
        <div class ="col-sm-12">
            <label for="txtEmail">Email Address: </label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter your email address"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <label for="txtPassword">Password:</label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <asp:TextBox ID="txtPassword" runat="server" placeholder="Enter your password" TextMode="Password"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-2">
            <asp:Button ID="btnSignIn" runat="server" Text="Sign In" OnClick="btnSignIn_Click" />
            <br />
            <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/Register.aspx">Don&#39;t have an account?</asp:LinkButton>
        </div>
        <div class="col-sm-10">
            <asp:Label ID="lblSigninFailed" runat="server" CssClass="alert alert-danger" Visible="false"></asp:Label>
        </div>
    </div>
</asp:Content>
