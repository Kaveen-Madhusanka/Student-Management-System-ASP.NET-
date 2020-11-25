using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.DATA.Models
{
    public class StudentDTO
    {
        public String StudentId { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String DateodBirth { get; set; }

        public String AddressLine1 { get; set; }

        public String AddressLine2 { get; set; }

        public String AddressLine3 { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedDateTime { get; set; }


    }
}
