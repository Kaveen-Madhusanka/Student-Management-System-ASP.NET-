<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Grade.aspx.cs" Inherits="StudentManagementSystem.Pages.Grade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:MultiView ID="mvGrade" runat="server">
         <asp:View ID="v1Grade" runat="server">
             <div class="row">
                &nbsp
             </div>
             <div class="row">
                <div class="col-md-4">
                    <asp:Button ID="btnAddNew" runat="server" Text="Add" CssClass="btn btn-success" OnClick="btnAddNew_Click" />
                    </div>
                <div class="col-md-2">
                    &nbsp
                    </div>
                <span class="col-md-2 col-form-label">Search :</span>
                     <div class="col-md-4">
                         <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
                         <div class="row">
                            &nbsp
                         </div>
                         <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-success" OnClick="btnSearch_Click" />
                    </div>
            </div>
            <div class="row">
                &nbsp
            </div>
             <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="dgvGrade" runat="server" AutoGenerateColumns="false" OnRowCommand="dgvGrade_RowCommand" CssClass="table table-striped">
                            <Columns>
                                <asp:TemplateField HeaderText="Subject Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lblv1SubjectId" runat="server" Text='<%# Bind("SubjectId") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Grade Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lblv1GradeId" runat="server" Text='<%# Bind("GradeId") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lblv1Description" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Lower Limit">
                                    <ItemTemplate>
                                        <asp:Label ID="lblv1LowerLimit" runat="server" Text='<%# Bind("LowerLimit") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Upper Limit">
                                    <ItemTemplate>
                                        <asp:Label ID="lblv1UpperLimit" runat="server" Text='<%# Bind("UpperLimit") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField ShowHeader="false">
                                    <ItemTemplate>
                                        <asp:Button ID="btnView" runat="server" Text="View" CssClass="btn btn-success" CommandArgument="<%# Container.DisplayIndex %>" CommandName="View" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
         </asp:View>
        <asp:View ID="v2Grade" runat="server">
            <div class="row">
                &nbsp
            </div>
            <div class="row">
                    <span class="col-md-2 col-form-label">Subject Id :</span>
                    <div class="col-md-4">
                        <%--<asp:TextBox ID="txtSubjectId" runat="server" CssClass="form-control"></asp:TextBox>--%>
                        <asp:DropDownList ID="drpSubject" runat="server"></asp:DropDownList>
                    </div>
            </div>
            <div class="row">
                &nbsp
            </div>
            <div class="row">
                    <span class="col-md-2 col-form-label">Grade Id :</span>
                    <div class="col-md-4">
                         <asp:TextBox ID="txtGradeId" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
            </div>
            <div class="row">
                &nbsp
            </div>
            <div class="row">
                    <span class="col-md-2 col-form-label">Description :</span>
                    <div class="col-md-4">
                         <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
            </div>
            <div class="row">
                &nbsp
            </div>
            <div class="row">
                    <span class="col-md-2 col-form-label">Lower Limit :</span>
                    <div class="col-md-4">
                         <asp:TextBox ID="txtLowerLimit" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
            </div>
            <div class="row">
                &nbsp
            </div>
            <div class="row">
                    <span class="col-md-2 col-form-label">Upper Limit :</span>
                    <div class="col-md-4">
                         <asp:TextBox ID="txtUpperLimit" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
            </div>
            <div class="row">
                &nbsp
            </div>
            <div class="row">
                    <div class="col-md-12">
                        <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-success" OnClick="btnAdd_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-success" OnClientClick="return DeleteItem()" OnClick="btnDelete_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnclear" runat="server" Text="Clear" CssClass="btn btn-success" OnClick="btnclear_Click" />
                    </div>
            </div>
        </asp:View>
    </asp:MultiView>
    <script type="text/javascript">
        function DeleteItem() {
            if (confirm("Are you sure you want to delete ...?")) {
                return true;
            }
            return false;
        }
    </script>
</asp:Content>
