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
    public class DashboardBL
    {
        private StringBuilder sb = new StringBuilder();
        public List<StudentMarkCustomDTO> filterData(string studentid)
        {
            List<StudentMarkCustomDTO> oStudentMarkList = new List<StudentMarkCustomDTO>();
            try
            {
                sb.Clear();
                sb.Append("SELECT stm.SubjectId, stm.Marks, sub.SubjectName, g.Description FROM [Subject] sub RIGHT JOIN [StudentMark] stm ON sub.SubjectId = stm.SubjectId LEFT JOIN [Grade] g ON stm.SubjectId = g.SubjectId WHERE stm.StudentId = ?StudentId AND (stm.Marks BETWEEN g.LowerLimit AND g.UpperLimit)");

                using (CloudConnection connection = new CloudConnection(DMSSWE.Common.ConnectionString))
                {
                    connection.CommandText = sb.ToString();
                    connection.Parameters.Add(new Parameter { Name = "StudentId", Value = studentid });
                    using (IDataReader dr = connection.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                StudentMarkCustomDTO oStudentMark = new StudentMarkCustomDTO();
                                oStudentMark.SubjectId = dr["SubjectId"].ToString();
                                oStudentMark.SubjectName = dr["SubjectName"].ToString();
                                oStudentMark.Marks = Convert.ToInt32(dr["Marks"]);
                                oStudentMark.Grade = dr["Description"].ToString();
                                oStudentMarkList.Add(oStudentMark);
                            }
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
    }
}
