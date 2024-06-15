using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers
{
    public class SalaryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public SalaryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<EmpSalaryModel> empSalary = _dbContext.empSalaryModels.Include(e => e.Employee).ToList();
            return View(empSalary);
        }
    }
}
