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
    public partial class Subject : System.Web.UI.Page
    {
        SubjectBL oSubjectBL = new SubjectBL();

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
            mvSubject.ActiveViewIndex = 1;
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (!CheckAvailability() == true)
            {
                AddSubject();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            deleteSubject();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            updateSubject();
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
           
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchSubject();
        }

        protected void dgvSubject_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                switch(e.CommandName)
                {
                    case "View" :
                        ViewState["index"] = e.CommandArgument.ToString();
                        ViewSubject();
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        #endregion Events

        #region Methods

        private void AddSubject()
        {
            try
            {
                if (!txtSubjectId.Text.Equals(string.Empty))
                {
                    SubjectDTO oSubjectDTO = new SubjectDTO();
                    oSubjectDTO.SubjectId = txtSubjectId.Text.Trim();
                    oSubjectDTO.SubjectName = txtSubjectName.Text.Trim();
                    oSubjectDTO.CreatedBy = "Kaveen";
                    oSubjectDTO.CreatedDateTime = DateTime.Now;
                    oSubjectDTO.ModifiedBy = "Kaveen";
                    oSubjectDTO.ModifiedDateTime = DateTime.Now;

                    if (oSubjectBL.InsertSubject(oSubjectDTO))
                    {
                        ClearControls();
                        LoadSubjects();
                        Response.Write("<script>alert('Data inserted successfully')</script>");
                        mvSubject.ActiveViewIndex = 0;
                    }
                }
                else
                {
                    txtSubjectId.Focus();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void deleteSubject()
        {
            try
            {
                if (!txtSubjectId.Text.Trim().Equals(string.Empty))
                {
                    if (oSubjectBL.DeleteSubject(txtSubjectId.Text.Trim()))
                     {
                        ClearControls();
                        LoadSubjects();
                        Response.Write("<script>alert('Record deleted successfully.!')</script>");
                        mvSubject.ActiveViewIndex = 0;

                    }

                }
                else
                {
                    txtSubjectId.Focus();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void updateSubject()
        {
            try
            {
                if (!txtSubjectId.Text.Trim().Equals(string.Empty))
                {
                    SubjectDTO oSubjectDTO = new SubjectDTO();
                    oSubjectDTO.SubjectId = txtSubjectId.Text.Trim();
                    oSubjectDTO.SubjectName = txtSubjectName.Text.Trim();
                    oSubjectDTO.ModifiedBy = "Kaveen";
                    oSubjectDTO.ModifiedDateTime = DateTime.Now;

                    if (oSubjectBL.UpdateSubject(oSubjectDTO))
                    {
                        ClearControls();
                        LoadSubjects();
                        Response.Write("<script>alert('Record updated successfully.!')</script>");
                        mvSubject.ActiveViewIndex = 0;
                    }
                }
                else
                {
                    txtSubjectId.Focus();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void PageLoad()
        {
            LoadSubjects();
            mvSubject.ActiveViewIndex = 0;
        }
        private void LoadSubjects()
        {
            try
            {
                List<SubjectDTO> oSubjectList = oSubjectBL.GetSubjects();
                dgvSubject.DataSource = oSubjectList;
                dgvSubject.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SearchSubject()
        {
            try
            {
                List<SubjectDTO> oSubjectList = oSubjectBL.SearchSubject(txtSearch.Text.Trim());
                dgvSubject.DataSource = oSubjectList;
                dgvSubject.DataBind();
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
                if (oSubjectBL.CheckAvailability(txtSubjectId.Text.Trim()))
                {
                    txtSubjectId.Text= string.Empty;
                    txtSubjectId.Focus();
                    Response.Write("<script>alert('Record already exist.!')</script>");
                    recordStstus = true;
                }
                else
                {
                    txtSubjectName.Focus();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return recordStstus;
        }

        private void ViewSubject()
        {
            try
            {
                GridViewRow row = dgvSubject.Rows[Convert.ToInt32(ViewState["index"])];
                txtSubjectId.Text = ((Label)row.FindControl("lblv1SubjectId")).Text;
                txtSubjectName.Text = ((Label)row.FindControl("lblv1SubjectName")).Text;
                mvSubject.ActiveViewIndex = 1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ClearControls()
        {
            txtSubjectId.Text = string.Empty;
            txtSubjectName.Text = string.Empty;
            txtSearch.Text = string.Empty;
        }

        #endregion Methods

    }
}