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
    public class StudentBL
    {
        private StringBuilder sb = new StringBuilder();

        public bool InsertStudent(StudentDTO oStudentDTO)
        {
            bool result = false;
            try
            {
                sb.Clear();
                sb.Append("INSERT INTO [Student]");
                sb.Append(" VALUES (");
                sb.Append(" ?StudentId,");
                sb.Append(" ?FirstName,");
                sb.Append(" ?LastName,");
                sb.Append(" ?DateodBirth,");
                sb.Append(" ?AddressLine1,");
                sb.Append(" ?AddressLine2,");
                sb.Append(" ?AddressLine3,");
                sb.Append(" ?CreatedBy,");
                sb.Append(" ?CreatedDateTime,");
                sb.Append(" ?ModifiedBy,");
                sb.Append(" ?ModifiedDateTime");
                sb.Append(" )");

                using (CloudConnection connection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    connection.CommandText = sb.ToString();
                    connection.Parameters.Add(new Parameter { Name = "StudentId", Value = oStudentDTO.StudentId });
                    connection.Parameters.Add(new Parameter { Name = "FirstName", Value = oStudentDTO.FirstName });
                    connection.Parameters.Add(new Parameter { Name = "LastName", Value = oStudentDTO.LastName });
                    connection.Parameters.Add(new Parameter { Name = "DateodBirth", Value = oStudentDTO.DateodBirth });
                    connection.Parameters.Add(new Parameter { Name = "AddressLine1", Value = oStudentDTO.AddressLine1 });
                    connection.Parameters.Add(new Parameter { Name = "AddressLine2", Value = oStudentDTO.AddressLine2 });
                    connection.Parameters.Add(new Parameter { Name = "AddressLine3", Value = oStudentDTO.AddressLine3 });
                    connection.Parameters.Add(new Parameter { Name = "CreatedBy", Value = oStudentDTO.CreatedBy });
                    connection.Parameters.Add(new Parameter { Name = "CreatedDateTime", Value = oStudentDTO.CreatedDateTime });
                    connection.Parameters.Add(new Parameter { Name = "ModifiedBy", Value = oStudentDTO.ModifiedBy });
                    connection.Parameters.Add(new Parameter { Name = "ModifiedDateTime", Value = oStudentDTO.ModifiedDateTime });

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

        public bool DeleteStudent(String StudentId)
        {
            bool result = false;
            try
            {
                sb.Clear();
                sb.Append("DELETE FROM [Student]");
                sb.Append(" WHERE StudentId =?StudentId");

                using (CloudConnection connection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    connection.CommandText = sb.ToString();
                    connection.Parameters.Add(new Parameter { Name = "StudentId", Value = StudentId });

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

        public bool UpdateStudent(StudentDTO oStudentDTO)
        {
            bool result = false;
            try
            {
                sb.Clear();
                sb.Append("UPDATE  [Student]");
                sb.Append(" SET ");
                sb.Append(" FirstName=?FirstName,");
                sb.Append(" LastName=?LastName,");
                sb.Append(" DateodBirth=?DateodBirth,");
                sb.Append(" AddressLine1=?AddressLine1,");
                sb.Append(" AddressLine2=?AddressLine2,");
                sb.Append(" AddressLine3=?AddressLine3,");
                sb.Append(" ModifiedBy=?ModifiedBy,");
                sb.Append(" ModifiedDateTime=?ModifiedDateTime");
                sb.Append(" WHERE StudentId =?StudentId");

                using (CloudConnection connection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    connection.CommandText = sb.ToString();
                    connection.Parameters.Add(new Parameter { Name = "FirstName", Value = oStudentDTO.FirstName });
                    connection.Parameters.Add(new Parameter { Name = "LastName", Value = oStudentDTO.LastName });
                    connection.Parameters.Add(new Parameter { Name = "DateodBirth", Value = oStudentDTO.DateodBirth });
                    connection.Parameters.Add(new Parameter { Name = "AddressLine1", Value = oStudentDTO.AddressLine1 });
                    connection.Parameters.Add(new Parameter { Name = "AddressLine2", Value = oStudentDTO.AddressLine2 });
                    connection.Parameters.Add(new Parameter { Name = "AddressLine3", Value = oStudentDTO.AddressLine3 });
                    connection.Parameters.Add(new Parameter { Name = "ModifiedBy", Value = oStudentDTO.ModifiedBy });
                    connection.Parameters.Add(new Parameter { Name = "ModifiedDateTime", Value = oStudentDTO.ModifiedDateTime });
                    connection.Parameters.Add(new Parameter { Name = "StudentId", Value = oStudentDTO.StudentId });

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

        public List<StudentDTO> GetStudents()
        {
            List<StudentDTO> oStudentList = new List<StudentDTO>();
            try
            {
                sb.Clear();
                sb.Append("SELECT StudentId, FirstName,LastName,DateodBirth,AddressLine1,AddressLine2,AddressLine3");
                sb.Append(" FROM [Student]");

                using (CloudConnection connection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    connection.CommandText = sb.ToString();
                    using (IDataReader dr = connection.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                StudentDTO oStudent = new StudentDTO();
                                oStudent.StudentId = dr["StudentId"].ToString();
                                oStudent.FirstName = dr["FirstName"].ToString();
                                oStudent.LastName = dr["LastName"].ToString();
                                oStudent.DateodBirth = dr["DateodBirth"].ToString();
                                oStudent.AddressLine1 = dr["AddressLine1"].ToString();
                                oStudent.AddressLine2 = dr["AddressLine2"].ToString();
                                oStudent.AddressLine3 = dr["AddressLine3"].ToString();
                                oStudentList.Add(oStudent);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oStudentList;
        }

        public List<StudentDTO> SearchStudents(string Searchtext)
        {
            List<StudentDTO> oStudentList = new List<StudentDTO>();
            try
            {
                sb.Clear();
                sb.Append("SELECT StudentId, FirstName,LastName,DateodBirth,AddressLine1,AddressLine2,AddressLine3");
                sb.Append(" FROM [Student]");
                sb.Append(" WHERE FirstName LIKE '%' + ?FirstName + '%' or StudentId LIKE '%' + ?StudentId + '%'");

                using (CloudConnection connection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    connection.CommandText = sb.ToString();
                    connection.Parameters.Add(new Parameter { Name = "FirstName", Value = Searchtext });
                    connection.Parameters.Add(new Parameter { Name = "StudentId", Value = Searchtext });
                    using (IDataReader dr = connection.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                StudentDTO oStudent = new StudentDTO();
                                oStudent.StudentId = dr["StudentId"].ToString();
                                oStudent.FirstName = dr["FirstName"].ToString();
                                oStudent.LastName = dr["LastName"].ToString();
                                oStudent.DateodBirth = dr["DateodBirth"].ToString();
                                oStudent.AddressLine1 = dr["AddressLine1"].ToString();
                                oStudent.AddressLine2 = dr["AddressLine2"].ToString();
                                oStudent.AddressLine3 = dr["AddressLine3"].ToString();
                                oStudentList.Add(oStudent);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oStudentList;
        }

        public bool CheckAvailability(string Studentid)
        {
            bool result = false;
            try
            {
                sb.Clear();
                sb.Append("Select StudentId FROM [Student]");
                sb.Append(" WHERE StudentId=?StudentId");

                using (CloudConnection connection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    connection.CommandText = sb.ToString();
                    connection.Parameters.Clear();
                    connection.Parameters.Add(new Parameter { Name = "StudentId", Value = Studentid });

                    using (IDataReader dr = connection.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (dr["StudentId"] != null)
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
