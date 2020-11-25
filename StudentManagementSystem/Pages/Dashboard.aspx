<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="StudentManagementSystem.Pages.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="modal fade" id="modal-Students" data-keyboard="false" data-backdrop="static">
        <div class="modal- dialog">
            <div class="modal-content">
                <div class="modal-header">
                            <div class="align-left">
                                <h4 class="modal-title">Students</h4>
                            </div>
                            <button type="button" onclick="HideStudent();" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button>
                        </div>
                <div class="modal-body">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:GridView ID="dgvStudent" runat="server" AutoGenerateColumns="false" OnRowCommand="dgvStudent_RowCommand" CssClass="table table-striped table-bordered table-hover">
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
                                </div>
                            </div>
                        </div>
            </div>
        </div>
        </div>
            <div class="row">
                &nbsp
             </div>
             <div class="row">
                <span class="col-md-2 col-form-label">Search :</span>
                <div class="col-md-2">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"  AutoPostBack="true"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-success" OnClick="btnSearch_Click"/>
                </div> 
            </div>
            <div class="row">
                &nbsp
             </div>
             <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="dgvStudentData" runat="server" AutoGenerateColumns="false">
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
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
        <div class="row">
                &nbsp
        </div>   
        <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="dgvstudentmain" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover">
                            <Columns>
                                <asp:TemplateField HeaderText="Subject Id">
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
                                 <asp:TemplateField HeaderText="Grade">
                                    <ItemTemplate>
                                        <asp:Label ID="lblv1Grade" runat="server" Text='<%# Bind("Grade") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>
                 </div>
           </div>     

        <script type="text/javascript">
            function ShowStudent() {
                $('.modal-backdrop').remove();
                $('#modal-Students').modal('show');
                return false;
            };

            function HideStudent() {
                $('.modal-backdrop').remove();
                $('#modal-Students').modal('hide');
                return false;
            };
            </script>
</asp:Content>
