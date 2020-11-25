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
    public partial class Grade : System.Web.UI.Page
    {
        GradeBL oGradeBL = new GradeBL();
        private SubjectBL oSubjectBL = new SubjectBL();
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
            mvGrade.ActiveViewIndex = 1;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (!CheckAvailability() == true)
            {
                CreateGrade();
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            deleteGrade();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            updateGrade();
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchGrade();
        }
        protected void dgvGrade_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "View":
                        ViewState["index"] = e.CommandArgument.ToString();
                        ViewGrade();
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
        private void PageLoad()
        {
            LoadSubject();
            LoadGrade();
            mvGrade.ActiveViewIndex = 0;
        }

        private void CreateGrade()
        {
            try
            {
                if (!txtGradeId.Text.Trim().Equals(string.Empty))
                {
                    GradeDTO oGradeDTO = new GradeDTO();
                    oGradeDTO.GradeId = Convert.ToInt32(txtGradeId.Text.Trim());
                    oGradeDTO.SubjectId = drpSubject.SelectedValue.ToString();
                    oGradeDTO.Description = txtDescription.Text.Trim();
                    oGradeDTO.LowerLimit = Convert.ToInt32(txtLowerLimit.Text.Trim());
                    oGradeDTO.UpperLimit = Convert.ToInt32(txtUpperLimit.Text.Trim());
                    oGradeDTO.CreatedBy = "Kaveen";
                    oGradeDTO.CreatedDateTime = DateTime.Now;
                    oGradeDTO.ModifiedBy = "Kaveen";
                    oGradeDTO.ModifiedDateTime = DateTime.Now;

                    if (oGradeBL.InsertGrade(oGradeDTO))
                    {
                        ClearControls();
                        Response.Write("<script>alert('Data inserted successfully')</script>");
                        LoadGrade();
                        mvGrade.ActiveViewIndex = 0;
                    }
                }
                else
                {
                    txtGradeId.Focus();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void deleteGrade()
        {
            try
            {
                if (!txtGradeId.Text.Trim().Equals(string.Empty))
                {
                    
                   if (oGradeBL.DeleteGrade(Convert.ToInt32(txtGradeId.Text), drpSubject.SelectedValue.ToString()))
                    {
                        ClearControls();
                        Response.Write("<script>alert('Record deleted successfully.!')</script>");
                        LoadGrade();
                        mvGrade.ActiveViewIndex = 0;
                    }
                                       
                }
                else
                {
                    txtGradeId.Focus();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void updateGrade()
        {
            try
            {
                if (!txtGradeId.Text.Trim().Equals(string.Empty))
                {
                    GradeDTO oGradeDTO = new GradeDTO();
                    oGradeDTO.GradeId = Convert.ToInt16(txtGradeId.Text.Trim());
                    oGradeDTO.SubjectId = drpSubject.SelectedValue.ToString();
                    oGradeDTO.Description = txtDescription.Text.Trim();
                    oGradeDTO.LowerLimit = Convert.ToInt16(txtLowerLimit.Text.Trim());
                    oGradeDTO.UpperLimit = Convert.ToInt16(txtUpperLimit.Text.Trim());
                    oGradeDTO.ModifiedBy = "Kaveen";
                    oGradeDTO.ModifiedDateTime = DateTime.Now;

                    if (oGradeBL.UpdateGrade(oGradeDTO))
                    {
                        ClearControls();
                        Response.Write("<script>alert('Record updated successfully.!')</script>");
                        LoadGrade();
                        mvGrade.ActiveViewIndex = 0;
                    }
                }
                else
                {
                    txtGradeId.Focus();
                }
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
                if (oGradeBL.CheckAvailability(drpSubject.SelectedValue.ToString(), Convert.ToInt32(txtGradeId.Text.Trim())))
                {
                    txtGradeId.Text =string.Empty;
                    txtGradeId.Focus();
                    Response.Write("<script>alert('Record already exist.!')</script>");
                    recordStstus = true;
                }
                else
                {
                    txtDescription.Focus();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return recordStstus;
        }

        private void LoadGrade()
        {
            List<GradeDTO> oGradeList = new List<GradeDTO>();
            try
            {
                oGradeList = oGradeBL.getGrades();
                dgvGrade.DataSource = oGradeList;
                dgvGrade.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SearchGrade()
        {
            List<GradeDTO> oGradeList = new List<GradeDTO>();
            try
            {
                oGradeList = oGradeBL.SearchGrade(txtSearch.Text.Trim());
                dgvGrade.DataSource = oGradeList;
                dgvGrade.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ViewGrade()
        {
            try
            {
                GridViewRow row = dgvGrade.Rows[Convert.ToInt32(ViewState["index"])];
                drpSubject.SelectedValue = ((Label)row.FindControl("lblv1SubjectId")).Text;
                txtGradeId.Text = ((Label)row.FindControl("lblv1GradeId")).Text;
                txtDescription.Text = ((Label)row.FindControl("lblv1Description")).Text;
                txtLowerLimit.Text = ((Label)row.FindControl("lblv1LowerLimit")).Text;
                txtUpperLimit.Text = ((Label)row.FindControl("lblv1UpperLimit")).Text;
                mvGrade.ActiveViewIndex = 1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ClearControls()
        {
            drpSubject.SelectedIndex = -1;
            txtGradeId.Text= string.Empty;
            txtSearch.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtLowerLimit.Text = string.Empty;
            txtUpperLimit.Text = string.Empty;
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
        #endregion Methods

    }
}