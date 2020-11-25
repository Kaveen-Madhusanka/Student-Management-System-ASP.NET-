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
    public class StudentMarkBL
    {
        private StringBuilder sb = new StringBuilder();

        public bool InsertStudentMark(StudentMarkDTO oStudentMarkDTO)
        {
            bool result = false;
            try
            {
                sb.Clear();
                sb.Append("INSERT INTO [StudentMark]");
                sb.Append(" VALUES (");
                sb.Append(" ?StudentId,");
                sb.Append(" ?SubjectId,");
                sb.Append(" ?Marks,");
                sb.Append(" ?CreatedBy,");
                sb.Append(" ?CreatedDateTime,");
                sb.Append(" ?ModifiedBy,");
                sb.Append(" ?ModifiedDateTime");
                sb.Append(" )");

                using (CloudConnection connection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    connection.CommandText = sb.ToString();
                    connection.Parameters.Add(new Parameter { Name = "StudentId", Value = oStudentMarkDTO.StudentId });
                    connection.Parameters.Add(new Parameter { Name = "SubjectId", Value = oStudentMarkDTO.SubjectId });
                    connection.Parameters.Add(new Parameter { Name = "Marks", Value = oStudentMarkDTO.Marks });
                    connection.Parameters.Add(new Parameter { Name = "CreatedBy", Value = oStudentMarkDTO.CreatedBy });
                    connection.Parameters.Add(new Parameter { Name = "CreatedDateTime", Value = oStudentMarkDTO.CreatedDateTime });
                    connection.Parameters.Add(new Parameter { Name = "ModifiedBy", Value = oStudentMarkDTO.ModifiedBy });
                    connection.Parameters.Add(new Parameter { Name = "ModifiedDateTime", Value = oStudentMarkDTO.ModifiedDateTime });

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

        public bool DeleteStudentMark(string studentId, string subjectId)
        {
            bool result = false;
            try
            {
                sb.Clear();
                sb.Append("DELETE FROM [StudentMark]");
                sb.Append(" WHERE StudentId =?StudentId AND SubjectId=?SubjectId");

                using (CloudConnection connection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    connection.CommandText = sb.ToString();
                    connection.Parameters.Add(new Parameter { Name = "StudentId", Value = studentId });
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

        public bool UpdateStudentMark(StudentMarkDTO oStudentMarkDTO)
        {
            bool result = false;
            try
            {
                sb.Clear();
                sb.Append("UPDATE  [StudentMark]");
                sb.Append(" SET");
                sb.Append(" Marks=?Marks,");
                sb.Append(" ModifiedBy=?ModifiedBy,");
                sb.Append(" ModifiedDateTime=?ModifiedDateTime");
                sb.Append(" WHERE StudentId=?StudentId AND SubjectId=?SubjectId");

                using (CloudConnection connection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    connection.CommandText = sb.ToString();
                    connection.Parameters.Add(new Parameter { Name = "StudentId", Value = oStudentMarkDTO.StudentId });
                    connection.Parameters.Add(new Parameter { Name = "SubjectId", Value = oStudentMarkDTO.SubjectId });
                    connection.Parameters.Add(new Parameter { Name = "Marks", Value = oStudentMarkDTO.Marks });
                    connection.Parameters.Add(new Parameter { Name = "ModifiedBy", Value = oStudentMarkDTO.ModifiedBy });
                    connection.Parameters.Add(new Parameter { Name = "ModifiedDateTime", Value = oStudentMarkDTO.ModifiedDateTime });

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

        public List<StudentMarkCustomDTO> GetStudentmarks()
        {
            List<StudentMarkCustomDTO> oStudentMarkList = new List<StudentMarkCustomDTO>();
            try
            {
                sb.Clear();
                sb.Append("SELECT sub.SubjectName, stm.StudentId, stm.SubjectId, stm.Marks FROM dbo.Subject AS sub RIGHT JOIN dbo.StudentMark AS stm ON sub.SubjectId = stm.SubjectId");

                using (CloudConnection connection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    connection.CommandText = sb.ToString();
                    using (IDataReader dr = connection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            StudentMarkCustomDTO oStudentMark = new StudentMarkCustomDTO();
                            oStudentMark.StudentId = dr["StudentId"].ToString();
                            oStudentMark.SubjectId = dr["SubjectId"].ToString();
                            oStudentMark.SubjectName = dr["SubjectName"].ToString();
                            oStudentMark.Marks = Convert.ToInt32(dr["Marks"]);
                            oStudentMarkList.Add(oStudentMark);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oStudentMarkList;
        }

        public List<StudentMarkCustomDTO> SearchStudentMark(string SearchText)
        {
            List<StudentMarkCustomDTO> oStudentMarkList = new List<StudentMarkCustomDTO>();
            try
            {
                sb.Clear();
                sb.Append("SELECT sub.SubjectName,stm.StudentId, stm.SubjectId, stm.Marks FROM dbo.Subject AS sub RIGHT JOIN dbo.StudentMark AS stm ON sub.SubjectId = stm.SubjectId WHERE stm.StudentId LIKE '%' + ?StudentId + '%'");


                using (CloudConnection connection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    connection.CommandText = sb.ToString();
                    connection.Parameters.Clear();
                    connection.Parameters.Add(new Parameter { Name = "StudentId", Value = SearchText });
                    using (IDataReader dr = connection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            StudentMarkCustomDTO oStudentMark = new StudentMarkCustomDTO();
                            oStudentMark.StudentId = dr["StudentId"].ToString();
                            oStudentMark.SubjectId = dr["SubjectId"].ToString();
                            oStudentMark.SubjectName = dr["SubjectName"].ToString();
                            oStudentMark.Marks = Convert.ToInt32(dr["Marks"]);
                            oStudentMarkList.Add(oStudentMark);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oStudentMarkList;
        }
        public bool CheckAvailability(string StudentId, String SubjectId)
        {
            bool result = false;
            try
            {
                sb.Clear();
                sb.Append("Select StudentId,SubjectId FROM [StudentMark]");
                sb.Append(" WHERE StudentId=?StudentId AND SubjectId=?SubjectId");

                using (CloudConnection connection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    connection.CommandText = sb.ToString();
                    connection.Parameters.Clear();
                    connection.Parameters.Add(new Parameter { Name = "StudentId", Value = StudentId });
                    connection.Parameters.Add(new Parameter { Name = "SubjectId", Value = SubjectId });

                    using (IDataReader dr = connection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (dr["StudentId"] != null && dr["SubjectId"] != null)
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
