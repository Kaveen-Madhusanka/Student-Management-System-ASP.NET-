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
    public partial class Dashboard : System.Web.UI.Page
    {
        private StudentBL oStudentBL = new StudentBL();
        DashboardBL oDashboardBL = new DashboardBL();

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageLoad();
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            loadStudentData();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "ShowStudent();", true);
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
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "HideStudent();", true);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Events

        #region Methods
        private void PageLoad()
        {
            
        }

        private void loadStudentData()
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

        private void SearchStudentData()
        {
            try
            {
                List<StudentDTO> oStudentList = oStudentBL.SearchStudents(txtSearch.Text);
                dgvStudentData.DataSource = oStudentList;
                dgvStudentData.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ViewStudent()
        {
            try
            {
                GridViewRow row = dgvStudent.Rows[Convert.ToInt32(ViewState["index"])];
                string studentId = ((Label)row.FindControl("lblv1StudentId")).Text;
                txtSearch.Text = ((Label)row.FindControl("lblv1FirstName")).Text + " " + ((Label)row.FindControl("lblv1LastName")).Text;
                LoadStudentMarks(studentId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void LoadStudentMarks(string studentId)
        {
            try
            {
                List<StudentMarkCustomDTO> oStudentMarkList = oDashboardBL.filterData(studentId);
                dgvstudentmain.DataSource = oStudentMarkList;
                dgvstudentmain.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Methods

    }
}