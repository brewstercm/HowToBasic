<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tutorials.aspx.cs" Inherits="HowToBasic.Tutorials" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Create Tutorial</h2>
    <asp:Panel ID="pnlCreateTutorial" runat="server">
        <div class ="row">
            <div class="col-sm-2">
                <label for="txtTitle">Tutorial Title:</label>
            </div>
            <div class="col-sm-10">
                <asp:TextBox ID="txtTitle" runat="server" placeholder="Please enter a title"></asp:TextBox>
            </div>
        </div>
        <div class ="row">
            <div class="col-md-2">
                <label for="ddlCategories">Select Category: </label>
            </div>
            <div class ="col-md-10">
                <asp:DropDownList ID="ddlCategories" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2">
                <label for="ddlType">Select Tutorial Type:</label>
            </div>
            <div class="col-sm-10">
                <asp:DropDownList ID="ddlType" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2">
                <label for="txtTutorialLink">Tutorial Link:</label>
            </div>
            <div class="col-sm-10">
                <asp:TextBox ID="txtTutorialLink" placeholder="Enter tutorial link" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            </div>
            <div class ="col-sm-10">
                <asp:Label ID="lblFeedback" runat="server" Visible="False"></asp:Label>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlEditTutorials" runat="server">
        <div class="row">

        </div>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </asp:Panel>
</asp:Content>
