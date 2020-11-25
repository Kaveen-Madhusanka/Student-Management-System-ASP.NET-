using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.DATA.Models
{
    public class StudentMarkCustomDTO
    {
        public string StudentId { get; set; }

        public string SubjectId { get; set; }

        public string SubjectName { get; set; }

        public int Marks { get; set; }

        public string Grade { get; set; }
    }
}
