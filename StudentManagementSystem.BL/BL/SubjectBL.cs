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
    public class SubjectBL
    {
        private StringBuilder sb = new StringBuilder();
        public bool InsertSubject(SubjectDTO oSubjectDTO)
        {
            bool result = false;
            try
            {
                sb.Clear();
                sb.Append("INSERT INTO [Subject]");
                sb.Append(" VALUES (");
                sb.Append(" ?SubjectId,");
                sb.Append(" ?SubjectName,");
                sb.Append(" ?CreatedBy,");
                sb.Append(" ?CreatedDateTime,");
                sb.Append(" ?ModifiedBy,");
                sb.Append(" ?ModifiedDateTime");
                sb.Append(" )");

                using (CloudConnection connection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    connection.CommandText = sb.ToString();
                    connection.Parameters.Add(new Parameter { Name = "SubjectId", Value = oSubjectDTO.SubjectId });
                    connection.Parameters.Add(new Parameter { Name = "SubjectName", Value = oSubjectDTO.SubjectName });
                    connection.Parameters.Add(new Parameter { Name = "CreatedBy", Value = oSubjectDTO.CreatedBy });
                    connection.Parameters.Add(new Parameter { Name = "CreatedDateTime", Value = oSubjectDTO.CreatedDateTime });
                    connection.Parameters.Add(new Parameter { Name = "ModifiedBy", Value = oSubjectDTO.ModifiedBy });
                    connection.Parameters.Add(new Parameter { Name = "ModifiedDateTime", Value = oSubjectDTO.ModifiedDateTime });

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

        public bool DeleteSubject(string subjectId)
        {
            bool result = false;
            try
            {
                sb.Clear();
                sb.Append("DELETE FROM [Subject]");
                sb.Append(" WHERE SubjectId =?SubjectId");

                using (CloudConnection connection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    connection.CommandText = sb.ToString();
                    connection.Parameters.Add(new Parameter { Name = "SubjectId", Value = subjectId });

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

        public bool UpdateSubject(SubjectDTO oSubjectDTO)
        {
            bool result = false;
            try
            {
                sb.Clear();
                sb.Append("UPDATE  [Subject]");
                sb.Append(" SET ");
                sb.Append(" SubjectName=?SubjectName,");
                sb.Append(" ModifiedBy=?ModifiedBy,");
                sb.Append(" ModifiedDateTime=?ModifiedDateTime");
                sb.Append(" WHERE SubjectId =?SubjectId");

                using (CloudConnection connection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    connection.CommandText = sb.ToString();
                    connection.Parameters.Add(new Parameter { Name = "SubjectName", Value = oSubjectDTO.SubjectName });
                    connection.Parameters.Add(new Parameter { Name = "ModifiedBy", Value = oSubjectDTO.ModifiedBy });
                    connection.Parameters.Add(new Parameter { Name = "ModifiedDateTime", Value = oSubjectDTO.ModifiedDateTime });
                    connection.Parameters.Add(new Parameter { Name = "SubjectId", Value = oSubjectDTO.SubjectId });

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

        public List<SubjectDTO> GetSubjects()
        {
            List<SubjectDTO> oSubjectList = new List<SubjectDTO>();
            try
            {
                sb.Clear();
                sb.Append("SELECT SubjectId, SubjectName");
                sb.Append(" FROM [Subject]");

                using (CloudConnection connection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    connection.CommandText = sb.ToString();
                    using (IDataReader dr = connection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            SubjectDTO oSubject = new SubjectDTO();
                            oSubject.SubjectId = dr["SubjectId"].ToString();
                            oSubject.SubjectName = dr["SubjectName"].ToString();
                            oSubjectList.Add(oSubject);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oSubjectList;
        }

        public List<SubjectDTO> SearchSubject(string subjectName)
        {
            List<SubjectDTO> oSubjectList = new List<SubjectDTO>();
            try
            {
                sb.Clear();
                sb.Append("SELECT SubjectId, SubjectName");
                sb.Append(" FROM [Subject]");
                sb.Append(" WHERE SubjectName LIKE '%' + ?SubjectName + '%'");

                using (CloudConnection connection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    connection.CommandText = sb.ToString();
                    connection.Parameters.Clear();
                    connection.Parameters.Add(new Parameter { Name = "SubjectName", Value = subjectName });
                    using (IDataReader dr = connection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            SubjectDTO oSubject = new SubjectDTO();
                            oSubject.SubjectId = dr["SubjectId"].ToString();
                            oSubject.SubjectName = dr["SubjectName"].ToString();
                            oSubjectList.Add(oSubject);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oSubjectList;
        }

        public bool CheckAvailability(string subjectId)
        {
            bool result = false;
            try
            {
                sb.Clear();
                sb.Append("Select SubjectId FROM [Subject]");
                sb.Append(" WHERE SubjectId=?SubjectId");

                using (CloudConnection connection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    connection.CommandText = sb.ToString();
                    connection.Parameters.Clear();
                    connection.Parameters.Add(new Parameter { Name = "SubjectId", Value = subjectId });

                    using (IDataReader dr = connection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (dr["SubjectId"] != null)
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
    }
}
