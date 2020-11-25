using StudentManagementSystem.BL.BL;
using StudentManagementSystem.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentManagementSystem.Pages
{
    public partial class Student : System.Web.UI.Page
    {
        StudentBL oStudentBL = new StudentBL();

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageLoad();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (!CheckAvailability() == true)
            {
                CreateStudent();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            deleteStudent();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            updateStudent();
        }
        protected void dgvStudent_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            try
            {
                switch (e.CommandName)
                {
                    case "View":
                        ViewState["index"] = e.CommandArgument.ToString();
                        ViewStudent();
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            mvStudent.ActiveViewIndex = 1;
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchStudents();
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
        #endregion Events

        #region Methods
        private void PageLoad()
        {
            LoadStudents();
            mvStudent.ActiveViewIndex = 0;
        }

        private void CreateStudent()
        {
            try
            {
                if (!txtStudentId.Text.Trim().Equals(string.Empty))
                {
                    StudentDTO oStudentDTO = new StudentDTO();
                    oStudentDTO.StudentId = txtStudentId.Text.Trim().ToUpper();
                    oStudentDTO.FirstName = txtFirstName.Text.Trim();
                    oStudentDTO.LastName = txtLastName.Text.Trim();
                    oStudentDTO.DateodBirth = txtDateOfBirth.Text.Trim();
                    oStudentDTO.AddressLine1 = txtAddressLine1.Text.Trim();
                    oStudentDTO.AddressLine2 = txtAddressLine2.Text.Trim();
                    oStudentDTO.AddressLine3 = txtAddressLine3.Text.Trim();
                    oStudentDTO.CreatedBy = "Kaveen";
                    oStudentDTO.CreatedDateTime = DateTime.Now;
                    oStudentDTO.ModifiedBy = "Kaveen";
                    oStudentDTO.ModifiedDateTime = DateTime.Now;

                    if (oStudentBL.InsertStudent(oStudentDTO))
                    {
                        ClearControls();
                        LoadStudents();
                        Response.Write("<script>alert('Data inserted successfully')</script>");
                        mvStudent.ActiveViewIndex = 0;
                    }
                }
                else
                {
                    txtStudentId.Focus();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void deleteStudent()
        {
            try
            {
                if (!txtStudentId.Text.Trim().Equals(string.Empty))
                {
                        if (oStudentBL.DeleteStudent(txtStudentId.Text))
                        {
                            ClearControls();
                            LoadStudents();
                            Response.Write("<script>alert('Record deleted successfully.!')</script>");
                            mvStudent.ActiveViewIndex = 0;
                    }
                }
                else
                {
                    txtStudentId.Focus();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void updateStudent()
        {
            try
            {
                if (!txtStudentId.Text.Trim().Equals(string.Empty))
                {
                    StudentDTO oStudentDTO = new StudentDTO();
                    oStudentDTO.StudentId = txtStudentId.Text.Trim();
                    oStudentDTO.FirstName = txtFirstName.Text.Trim();
                    oStudentDTO.LastName = txtLastName.Text.Trim();
                    oStudentDTO.DateodBirth = txtDateOfBirth.Text.Trim();
                    oStudentDTO.AddressLine1 = txtAddressLine1.Text.Trim();
                    oStudentDTO.AddressLine2 = txtAddressLine2.Text.Trim();
                    oStudentDTO.AddressLine3 = txtAddressLine3.Text.Trim();
                    oStudentDTO.ModifiedBy = "Kaveen";
                    oStudentDTO.ModifiedDateTime = DateTime.Now;

                    if (oStudentBL.UpdateStudent(oStudentDTO))
                    {
                        ClearControls();
                        LoadStudents();
                        Response.Write("<script>alert('Record updated successfully.!')</script>");
                        mvStudent.ActiveViewIndex = 0;
                    }
                }
                else
                {
                    txtStudentId.Focus();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void LoadStudents()
        {
            try
            {
                List<StudentDTO> oStudentList = oStudentBL.GetStudents();
                dgvStudent.DataSource = oStudentList;
                dgvStudent.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SearchStudents()
        {
            try
            {
                List<StudentDTO> oStudentList = oStudentBL.SearchStudents(txtSearch.Text);
                dgvStudent.DataSource = oStudentList;
                dgvStudent.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool CheckAvailability()
        {
            bool recordStstus = false;
            try
            {
                if (oStudentBL.CheckAvailability(txtStudentId.Text.Trim()))
                {
                    txtStudentId.Text= string.Empty;
                    txtStudentId.Focus();
                    Response.Write("<script>alert('Record already exist.!')</script>");
                    recordStstus = true;
                }
                else
                {
                    txtStudentId.Focus();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return recordStstus;
        }

        private void ViewStudent()
        {
            try
            {
                GridViewRow row = dgvStudent.Rows[Convert.ToInt32(ViewState["index"])];
                txtStudentId.Text = ((Label)row.FindControl("lblv1StudentId")).Text;
                txtFirstName.Text = ((Label)row.FindControl("lblv1FirstName")).Text;
                txtLastName.Text = ((Label)row.FindControl("lblv1LastName")).Text;
                txtDateOfBirth.Text = ((Label)row.FindControl("lblv1DateodBirth")).Text;
                txtAddressLine1.Text = ((Label)row.FindControl("lblv1AddressLine1")).Text;
                txtAddressLine2.Text = ((Label)row.FindControl("lblv1AddressLine2")).Text;
                txtAddressLine3.Text = ((Label)row.FindControl("lblv1AddressLine3")).Text;
                mvStudent.ActiveViewIndex = 1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ClearControls()
        {
            txtStudentId.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtDateOfBirth.Text = string.Empty;
            txtAddressLine1.Text = string.Empty;
            txtAddressLine2.Text = string.Empty;
            txtAddressLine3.Text = string.Empty;
            txtSearch.Text = string.Empty;
        }
        #endregion Methods

    }
}