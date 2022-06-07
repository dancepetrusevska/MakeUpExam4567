using System;

namespace UniversityMakeupExam.Models.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? SigningDate { get; set; }
        public DateTime? DOB { get; set; }
        public string Salary { get; set; }

        public int CompanyId { get; set; }

         public virtual CompanyDTO Company { get; set; }
    }
}
