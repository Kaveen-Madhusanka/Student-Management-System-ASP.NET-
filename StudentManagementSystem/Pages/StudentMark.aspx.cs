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
    public partial class StudentMark : System.Web.UI.Page
    {
        private SubjectBL oSubjectBL = new SubjectBL();
        StudentMarkBL oStudentMarkBL = new StudentMarkBL();

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
            mvStudentMark.ActiveViewIndex = 1;
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            CreateStudentMark();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            deleteStudentMark();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            updateStudentMark();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchStudentMark(txtSearch.Text);
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        protected void dgvStudentMark_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "View":
                        ViewState["index"] = e.CommandArgument.ToString();
                        ViewStudentMark();
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion Events

        #region Methods
        private void PageLoad()
        {
            LoadSubject();
            LoadStudentmarks();
            mvStudentMark.ActiveViewIndex = 0;
        }

        private void LoadSubject()
        {
            try
            {
                List<SubjectDTO> oSubjectList = oSubjectBL.GetSubjects();
                drpSubject.DataSource = oSubjectList;
                drpSubject.DataTextField = "SubjectName";
                drpSubject.DataValueField = "SubjectId";
                drpSubject.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CreateStudentMark()
        {
            try
            {
                if (!txtStudentId.Text.Trim().Equals(string.Empty))
                {
                    if (!oStudentMarkBL.CheckAvailability(txtStudentId.Text.Trim(), drpSubject.SelectedValue.ToString()))
                    {
                        StudentMarkDTO oStudentMarkDTO = new StudentMarkDTO();
                        oStudentMarkDTO.StudentId = txtStudentId.Text.Trim().ToUpper();
                        oStudentMarkDTO.SubjectId = drpSubject.SelectedValue.ToString();
                        oStudentMarkDTO.Marks = Convert.ToInt32(txtMarks.Text.Trim());
                        oStudentMarkDTO.CreatedBy = "Kaveen";
                        oStudentMarkDTO.CreatedDateTime = DateTime.Now;
                        oStudentMarkDTO.ModifiedBy = "Kaveen";
                        oStudentMarkDTO.ModifiedDateTime = DateTime.Now;

                        if (oStudentMarkBL.InsertStudentMark(oStudentMarkDTO))
                        {
                            ClearControls();
                            Response.Write("<script>alert('Data inserted successfully')</script>");
                            LoadStudentmarks();
                            mvStudentMark.ActiveViewIndex = 0;
                        }
                    }
                    else
                    {
                        txtStudentId.Text = string.Empty;
                        txtStudentId.Focus();
                        Response.Write("<script>alert('Record already exist.!')</script>");
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

        private void deleteStudentMark()
        {
            try
            {
                if (!txtStudentId.Text.Trim().Equals(string.Empty))
                {
                       if (oStudentMarkBL.DeleteStudentMark(txtStudentId.Text.Trim(), drpSubject.SelectedValue.ToString()))
                       {
                            ClearControls();
                            Response.Write("<script>alert('Record deletaed successfully.!')</script>");
                            LoadStudentmarks();
                            mvStudentMark.ActiveViewIndex = 0;  
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

        private void updateStudentMark()
        {
            try
            {
                if (!txtStudentId.Text.Trim().Equals(string.Empty))
                {
                    StudentMarkDTO oStudentMarkDTO = new StudentMarkDTO();
                    oStudentMarkDTO.StudentId = txtStudentId.Text.Trim();
                    oStudentMarkDTO.SubjectId = drpSubject.SelectedValue.ToString();
                    oStudentMarkDTO.Marks = Convert.ToInt32(txtMarks.Text.Trim());
                    oStudentMarkDTO.ModifiedBy = "Kaveen";
                    oStudentMarkDTO.ModifiedDateTime = DateTime.Now;

                    if (oStudentMarkBL.UpdateStudentMark(oStudentMarkDTO))
                    {
                        ClearControls();
                        Response.Write("<script>alert('Record Upadated successfully.!')</script>");
                        LoadStudentmarks();
                        mvStudentMark.ActiveViewIndex = 0;
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

        private void LoadStudentmarks()
        {
            try
            {
                List<StudentMarkCustomDTO> oStudentMarkList = oStudentMarkBL.GetStudentmarks();
                dgvStudentMark.DataSource = oStudentMarkList;
                dgvStudentMark.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SearchStudentMark(string searchField)
        {
            try
            {
                    List<StudentMarkCustomDTO> oStudentMarkList = oStudentMarkBL.SearchStudentMark(searchField);
                    dgvStudentMark.DataSource = oStudentMarkList;
                    dgvStudentMark.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ViewStudentMark()
        {
            try
            {
                GridViewRow row = dgvStudentMark.Rows[Convert.ToInt32(ViewState["index"])];
                drpSubject.SelectedValue = ((Label)row.FindControl("lblv1SubjectId")).Text;
                txtStudentId.Text = ((Label)row.FindControl("lblv1StudentId")).Text;
                txtMarks.Text = ((Label)row.FindControl("lblv1Marks")).Text;
                mvStudentMark.ActiveViewIndex = 1;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void ClearControls()
        {
            drpSubject.SelectedIndex = -1;
            txtStudentId.Text = string.Empty;
            txtSearch.Text = string.Empty;
            txtMarks.Text = string.Empty;
        }
        #endregion Methods 

    }
}