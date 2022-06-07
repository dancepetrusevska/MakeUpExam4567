using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace UniversityMakeupExam.Data.Entities
{
    public partial class Company
    {
        public Company()
        {
            Employees = new HashSet<Employee>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string Owner { get; set; }
        [Required]
        [StringLength(200)]
        public string City { get; set; }
        [Required]
        [StringLength(200)]
        public string Country { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
