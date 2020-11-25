<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentMark.aspx.cs" Inherits="StudentManagementSystem.Pages.StudentMark" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:MultiView ID="mvStudentMark" runat="server">
         <asp:View ID="v1StudentMark" runat="server">
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
                         <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"  AutoPostBack="true"></asp:TextBox>
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
                    <asp:GridView ID="dgvStudentMark" runat="server" AutoGenerateColumns="false" OnRowCommand="dgvStudentMark_RowCommand" CssClass="table table-striped table-hover">
                            <Columns>
                                <asp:TemplateField HeaderText="Student Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lblv1StudentId" runat="server" Text='<%# Bind("StudentId") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject Id" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblv1SubjectId" runat="server" Text='<%# Bind("SubjectId") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblv1SubjectName" runat="server" Text='<%# Bind("SubjectName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Marks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblv1Marks" runat="server" Text='<%# Bind("Marks") %>'></asp:Label>
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
         <asp:View ID="v2StudentMark" runat="server">
             <div class="row">
                &nbsp
             </div>
              <div class="row">

                    <span class="col-md-2 col-form-label">Student Id :</span>
                    <div class="col-md-4">
                         <asp:TextBox ID="txtStudentId" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
             </div>
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

                    <span class="col-md-2 col-form-label">Marks :</span>
                    <div class="col-md-4">
                         <asp:TextBox ID="txtMarks" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
             </div>
             <div class="row">
                &nbsp
            </div>
            <div class="row">
                    <div class="col-md-12">
                        <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-success" OnClick="btnAdd_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-success" OnClientClick="return DeleteItem()" OnClick="btnDelete_Click"  />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success" OnClick="btnUpdate_Click"  />
                        <asp:Button ID="btnclear" runat="server" Text="Clear" CssClass="btn btn-success" OnClick="btnclear_Click"  />
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
