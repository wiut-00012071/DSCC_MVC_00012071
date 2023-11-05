
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSCC_MVC_00012071.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [Required]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string JobTitle { get; set; } = "";

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; } = "";

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; } = "";

        [Required]
        [StringLength(300, MinimumLength = 2)]
        public string Bio { get; set; } = "";
    }
}
