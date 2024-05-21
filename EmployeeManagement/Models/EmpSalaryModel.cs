using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Models
{
    [Table("EmployeeSalary")]
    public class EmpSalaryModel
    {
        public int Id { get; set; }
        [Required]
        public DateTime YearMonth { get; set; }
        [Required]
        public double Salary { get; set; }

        public int EmployeeId { get; set; }
        public EmployeeModel Employee { get; set; }

    }
}
