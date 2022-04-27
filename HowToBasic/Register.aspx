<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="HowToBasic.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class ="row">
        <div class ="col-sm-12">
            <label for="txtEmail">Email Address: </label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter your email address" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <label for="txtPassword">Password:</label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <asp:TextBox ID="txtPassword" runat="server" placeholder="Enter your password" CssClass="form-control" TextMode="Password"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <label for="txtConfirmPassword">Confirm Password:</label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <asp:TextBox ID="txtConfirmPassword" runat="server" placeholder="Re-Enter your password" CssClass="form-control" TextMode="Password"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
            <asp:Label ID="lblRegisterFailed" runat="server" Visible="false" CssClass="alert alert-danger"></asp:Label>
        </div>
    </div>

</asp:Content>
