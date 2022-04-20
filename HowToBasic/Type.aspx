<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Type.aspx.cs" Inherits="HowToBasic.Type" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Manage Tutorial Types</h2>
    <asp:Panel ID="pnlAddTypes" runat="server">
        <div class="row">
            <div class="col-sm-2">
                <label for="txtTypeName">Type Name: </label>
            </div>
            <div class="col-sm-10">
                <asp:TextBox ID="txtTypeName" runat="server" placeholder="Please enter a name"></asp:TextBox>
                <asp:Label ID="lblFeedback" runat="server" ForeColor="Black" Visible="False"></asp:Label>
                <asp:RequiredFieldValidator ID="rfvTypeName" runat="server" ControlToValidate="txtTypeName" ErrorMessage="Required" ForeColor="#CC0000" ValidationGroup="AddType"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-12">
                <asp:Button ID="btnAddType" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAddType_Click" ValidationGroup="AddType" />
                <asp:Button ID="btnSaveType" runat="server" CssClass="btn btn-primary" Text="Save" Visible="False" OnClick="btnSaveType_Click" />
                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-secondary" Text="Cancel" Visible="False" OnClick="btnCancel_Click" />
                <asp:Label ID="lblTypeId" runat="server" Visible="False"></asp:Label>
            </div>
        </div>
    </asp:Panel>
    <br />
    <asp:Panel ID="pnlTypeList" runat="server">
        <asp:GridView ID="gvTypeList" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" OnRowCommand="gvTypeList_RowCommand" OnRowDataBound="gvTypeList_RowDataBound">
            <Columns>
                <asp:BoundField DataField="TypeID" HeaderText="ID" />
                <asp:BoundField DataField="TypeName" HeaderText="Type" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-primary" Text="Edit" CommandName="EditType" />
                        <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger"
                            OnClientClick="return confirm('Are you sure you want to delete this type?')" Text="Delete" CommandName="DeleteType" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
