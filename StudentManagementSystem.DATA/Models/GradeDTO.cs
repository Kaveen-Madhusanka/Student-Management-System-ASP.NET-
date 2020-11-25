using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.DATA.Models
{
    public class GradeDTO
    {
        public int GradeId { get; set; }

        public string Description { get; set; }

        public int LowerLimit { get; set; }

        public int UpperLimit { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        public string SubjectId { get; set; }
    }
}
