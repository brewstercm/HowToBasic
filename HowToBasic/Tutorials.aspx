<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tutorials.aspx.cs" Inherits="HowToBasic.Tutorials" ValidateRequest="false"  %>
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
                <asp:TextBox ID="txtTutorialLink" placeholder="Enter tutorial link" runat="server" ></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2">
                <label for="txtTutorialThumbnail">Tutorial Thumbnail:</label>
            </div>
            <div class="col-sm-10">
                <asp:TextBox ID="txtTutorialThumbnail" placeholder="Enter thumbnail link" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2">
                <asp:Button ID="btnAddTutorial" runat="server" Text="Submit" OnClick="btnAddTutorial_Click" />
                <asp:Button ID="btnSaveTutorial" runat="server" CssClass="btn btn-primary" Text="Save" Visible="False" OnClick="btnSaveTutorial_Click" />
                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-secondary" Text="Cancel" Visible="False" OnClick="btnCancel_Click" />
                <asp:Label ID="lblTutorialId" runat="server" Visible="False"></asp:Label>
            </div>
            <div class ="col-sm-10">
                <asp:Label ID="lblFeedback" runat="server" Visible="False"></asp:Label>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlEditTutorials" runat="server">
        <div class="row">

        </div>
        <asp:GridView ID="gvTutorialList" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" OnRowCommand="gvTutorialList_RowCommand" OnRowDataBound="gvTutorialList_RowDataBound">
            <Columns>
                <asp:BoundField DataField="TutorialID" HeaderText="ID" />
                <asp:BoundField DataField="CategoryID" HeaderText="Category ID" />
                <asp:BoundField DataField="DateCreated" HeaderText="Date Created" />
                <asp:BoundField DataField="TypeID" HeaderText="Type ID" />
                <asp:BoundField DataField="TutorialTitle" HeaderText="Title" />
                <asp:BoundField DataField="TutorialLink" HeaderText="Link" />
                <asp:BoundField DataField="TutorialThumbnail" HeaderText="Thumbnail" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-primary" Text="Edit" CommandName="EditTutorial" />
                        <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger"
                            OnClientClick="return confirm('Are you sure you want to delete this tutorial?')" Text="Delete" CommandName="DeleteTutorial" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
