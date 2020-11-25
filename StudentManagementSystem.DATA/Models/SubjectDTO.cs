using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentManagementSystem.DATA.Models
{
    public class SubjectDTO
    {
        public string SubjectId { get; set; }

        public string SubjectName { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        
    }
}
