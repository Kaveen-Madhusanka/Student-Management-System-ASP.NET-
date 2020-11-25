<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="StudentManagementSystem.Pages.Student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:MultiView ID="mvStudent" runat="server">
         <asp:View ID="v1Student" runat="server">
             <div class="row">
                &nbsp
              </div>
              <div class="row">
                    <div class="col-md-4">
                        <asp:Button ID="btnAddNew" runat="server" Text="Add" CssClass="btn btn-success" OnClick="btnAddNew_Click"/>
                    </div>
                   <div class="col-md-2">
                        &nbsp
                   </div>
                    <span class="col-md-2 col-form-label">Search :</span>
                    <div class="col-md-4">
                             <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"  AutoPostBack="true" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
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
                    <asp:GridView ID="dgvStudent" runat="server" AutoGenerateColumns="false" OnRowCommand="dgvStudent_RowCommand" CssClass="table table-striped">
                            <Columns>
                                <asp:TemplateField HeaderText="Student Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lblv1StudentId" runat="server" Text='<%# Bind("StudentId") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="First Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblv1FirstName" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Last Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblv1LastName" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date of Birth">
                                    <ItemTemplate>
                                        <asp:Label ID="lblv1DateodBirth" runat="server" Text='<%# Bind("DateodBirth") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address Line1">
                                    <ItemTemplate>
                                        <asp:Label ID="lblv1AddressLine1" runat="server" Text='<%# Bind("AddressLine1") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address Line2">
                                    <ItemTemplate>
                                        <asp:Label ID="lblv1AddressLine2" runat="server" Text='<%# Bind("AddressLine2") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address Line3">
                                    <ItemTemplate>
                                        <asp:Label ID="lblv1AddressLine3" runat="server" Text='<%# Bind("AddressLine3") %>'></asp:Label>
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

         <asp:View ID="v2Student" runat="server">
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
                    <span class="col-md-2 col-form-label">First Name :</span>
                    <div class="col-md-4">
                         <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
              </div>
             <div class="row">
                &nbsp
              </div>
             <div class="row">
                    <span class="col-md-2 col-form-label">Last Name :</span>
                    <div class="col-md-4">
                         <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
              </div>
             <div class="row">
                &nbsp
              </div>
             <div class="row">
                    <span class="col-md-2 col-form-label">Date of Birth :</span>
                    <div class="col-md-4">
                         <asp:TextBox ID="txtDateOfBirth" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
              </div>
              <div class="row">
                &nbsp
              </div>
             <div class="row">
                    <span class="col-md-2 col-form-label">Address Line1 :</span>
                    <div class="col-md-4">
                         <asp:TextBox ID="txtAddressLine1" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
              </div>
             <div class="row">
                &nbsp
              </div>
             <div class="row">
                    <span class="col-md-2 col-form-label">Address Line2 :</span>
                    <div class="col-md-4">
                         <asp:TextBox ID="txtAddressLine2" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
              </div>
             <div class="row">
                &nbsp
              </div>
             <div class="row">
                    <span class="col-md-2 col-form-label">Address Line3 :</span>
                    <div class="col-md-4">
                         <asp:TextBox ID="txtAddressLine3" runat="server" CssClass="form-control"></asp:TextBox>
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
