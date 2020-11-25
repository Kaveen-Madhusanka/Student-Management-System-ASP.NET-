using DMSSWE;
using DMSSWE.DATA;
using StudentManagementSystem.DATA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BL.BL
{
    public class GradeBL
    {
        private StringBuilder sb = new StringBuilder();
        public bool InsertGrade(GradeDTO oGradeDTO)
        {
            bool result = false;
            try
            {
                sb.Clear();
                sb.Append("INSERT INTO [Grade]");
                sb.Append(" VALUES (");
                sb.Append(" ?SubjectId,");
                sb.Append(" ?GradeId,");
                sb.Append(" ?Description,");
                sb.Append(" ?LowerLimit,");
                sb.Append(" ?UpperLimit,");
                sb.Append(" ?CreatedBy,");
                sb.Append(" ?CreatedDateTime,");
                sb.Append(" ?ModifiedBy,");
                sb.Append(" ?ModifiedDateTime");
                sb.Append(" )");

                using (CloudConnection connection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    connection.CommandText = sb.ToString();
                    connection.Parameters.Add(new Parameter { Name = "SubjectId", Value = oGradeDTO.SubjectId });
                    connection.Parameters.Add(new Parameter { Name = "GradeId", Value = oGradeDTO.GradeId });
                    connection.Parameters.Add(new Parameter { Name = "Description", Value = oGradeDTO.Description });
                    connection.Parameters.Add(new Parameter { Name = "LowerLimit", Value = oGradeDTO.LowerLimit });
                    connection.Parameters.Add(new Parameter { Name = "UpperLimit", Value = oGradeDTO.UpperLimit });
                    connection.Parameters.Add(new Parameter { Name = "CreatedBy", Value = oGradeDTO.CreatedBy });
                    connection.Parameters.Add(new Parameter { Name = "CreatedDateTime", Value = oGradeDTO.CreatedDateTime });
                    connection.Parameters.Add(new Parameter { Name = "ModifiedBy", Value = oGradeDTO.ModifiedBy });
                    connection.Parameters.Add(new Parameter { Name = "ModifiedDateTime", Value = oGradeDTO.ModifiedDateTime });

                    if (connection.ExecuteQuery() > 0)
                        result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public bool DeleteGrade(int GradeId, string SubjectId)
        {
            bool result = false;
            try
            {
                sb.Clear();
                sb.Append("DELETE FROM [Grade]");
                sb.Append(" WHERE GradeId =?GradeId AND SubjectId=?SubjectId");

                using (CloudConnection connection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    connection.CommandText = sb.ToString();
                    connection.Parameters.Add(new Parameter { Name = "SubjectId", Value = SubjectId });
                    connection.Parameters.Add(new Parameter { Name = "GradeId", Value = GradeId });

                    if (connection.ExecuteQuery() > 0)
                        result = true;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }

        public bool UpdateGrade(GradeDTO oGradeDTO)
        {
            bool result = false;
            try
            {
                sb.Clear();
                sb.Append("UPDATE  [Grade]");
                sb.Append(" SET ");
                sb.Append(" Description=?Description,");
                sb.Append(" LowerLimit=?LowerLimit,");
                sb.Append(" UpperLimit=?UpperLimit,");
                sb.Append(" ModifiedBy=?ModifiedBy,");
                sb.Append(" ModifiedDateTime=?ModifiedDateTime");
                sb.Append(" WHERE GradeId =?GradeId AND SubjectId=?SubjectId");

                using (CloudConnection connection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    connection.CommandText = sb.ToString();
                    connection.Parameters.Add(new Parameter { Name = "Description", Value = oGradeDTO.Description });
                    connection.Parameters.Add(new Parameter { Name = "LowerLimit", Value = oGradeDTO.LowerLimit });
                    connection.Parameters.Add(new Parameter { Name = "UpperLimit", Value = oGradeDTO.UpperLimit });
                    connection.Parameters.Add(new Parameter { Name = "ModifiedBy", Value = oGradeDTO.ModifiedBy });
                    connection.Parameters.Add(new Parameter { Name = "ModifiedDateTime", Value = oGradeDTO.ModifiedDateTime });
                    connection.Parameters.Add(new Parameter { Name = "GradeId", Value = oGradeDTO.GradeId });
                    connection.Parameters.Add(new Parameter { Name = "SubjectId", Value = oGradeDTO.SubjectId });

                    if (connection.ExecuteQuery() > 0)
                        result = true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public bool CheckAvailability(string subjectId, int GradeId)
        {
            bool result = false;
            try
            {
                sb.Clear();
                sb.Append("Select GradeId FROM [Grade]");
                sb.Append(" WHERE SubjectId=?SubjectId AND GradeId=?GradeId");

                using (CloudConnection connection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    connection.CommandText = sb.ToString();
                    connection.Parameters.Clear();
                    connection.Parameters.Add(new Parameter { Name = "SubjectId", Value = subjectId });
                    connection.Parameters.Add(new Parameter { Name = "GradeId", Value = GradeId });

                    using (IDataReader dr = connection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (dr["GradeId"] != null)
                            {
                                result = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public List<GradeDTO> getGrades()
        {
            List<GradeDTO> oGradeList = new List<GradeDTO>();
            try
            {
                sb.Clear();
                sb.Append("SELECT SubjectId, GradeId, Description, LowerLimit, UpperLimit, SubjectId");
                sb.Append(" FROM [Grade]");

                using (CloudConnection connection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    connection.CommandText = sb.ToString();
                    using (IDataReader dr = connection.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                GradeDTO oGrade = new GradeDTO();
                                oGrade.SubjectId = dr["SubjectId"].ToString();
                                oGrade.GradeId = Convert.ToInt16(dr["GradeId"]);
                                oGrade.Description = dr["Description"].ToString();
                                oGrade.LowerLimit = Convert.ToInt16(dr["LowerLimit"].ToString());
                                oGrade.UpperLimit = Convert.ToInt16(dr["UpperLimit"].ToString());
                                oGradeList.Add(oGrade);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oGradeList;
        }

        public List<GradeDTO> SearchGrade(string searchText)
        {
            List<GradeDTO> oGradeList = new List<GradeDTO>();
            try
            {
                sb.Clear();
                sb.Append("SELECT SubjectId, GradeId, Description, LowerLimit, UpperLimit");
                sb.Append(" FROM [Grade]");
                sb.Append(" WHERE SubjectId=?SubjectId OR Description LIKE '%' + ?Description + '%'");

                using (CloudConnection connection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    connection.CommandText = sb.ToString();
                    connection.Parameters.Add(new Parameter { Name = "SubjectId", Value = searchText });
                    connection.Parameters.Add(new Parameter { Name = "Description", Value = searchText });
                    using (IDataReader dr = connection.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                GradeDTO oGrade = new GradeDTO();
                                oGrade.SubjectId = dr["SubjectId"].ToString();
                                oGrade.GradeId = Convert.ToInt16(dr["GradeId"]);
                                oGrade.Description = dr["Description"].ToString();
                                oGrade.LowerLimit = Convert.ToInt16(dr["LowerLimit"].ToString());
                                oGrade.UpperLimit = Convert.ToInt16(dr["UpperLimit"].ToString());
                                oGradeList.Add(oGrade);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oGradeList;
        }
    }
}
