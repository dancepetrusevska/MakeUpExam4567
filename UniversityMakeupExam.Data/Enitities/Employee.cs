using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace UniversityMakeupExam.Data.Entities
{
    public partial class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string LastName { get; set; }
        [Required]
        [StringLength(200)]
        public string FirstName { get; set; }
        [Required]
        public string Salary { get; set; }
        [Required]
        public DateTime SigningDate { get; set; }
        [Required]
        public DateTime Dob { get; set; }
        [Required]
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
