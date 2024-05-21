using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Models
{
    [Table("Employee")]
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string? FirstName { get; set; }
        [Required]
        [MaxLength(40)]
        public string? LastName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        public string? Gender { get; set; }
        public string? Designation { get; set; }
        public double Salary { get; set; }
        public DateTime DOJ { get; set; }

    }
    public enum Gender
    {
        Male,
        Female,
        Other
    }

}
