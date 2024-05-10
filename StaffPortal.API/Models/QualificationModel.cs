using System.ComponentModel.DataAnnotations;

namespace StaffPortal.API.Models
{
    public class Qualification
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
