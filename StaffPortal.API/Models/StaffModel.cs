using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffPortal.API.Models
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        public int YearsOfWorkExperience { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public int GenderId { get; set; }

        [ForeignKey("GenderId")]
        public virtual Gender? Gender { get; set; }

        [Required(ErrorMessage = "Qualification is required")]
        public int QualificationId { get; set; }

        [ForeignKey("QualificationId")]
        public virtual Qualification? Qualification { get; set; }
    }
}
