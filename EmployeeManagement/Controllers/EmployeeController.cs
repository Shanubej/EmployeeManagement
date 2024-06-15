using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _empRepo;
        private readonly ApplicationDbContext _context;
        public EmployeeController(IEmployeeRepository empRepo,ApplicationDbContext dbContext)
        {
            _empRepo = empRepo;
            _context = dbContext;
        }
        public IActionResult Index(int id = 0)
        {
            if(id == 0)
            {
                return View();
            }
            var employee = _context.employeeModels.Where(a  => a.Id == id).FirstOrDefault();
            return View(employee);
        }

        public IActionResult GetEmployees()
        {
            var empList = _empRepo.GetAllEmployees();
            return View(empList);
        }

        [HttpPost]
        public IActionResult SaveEmployee(EmployeeModel employeeData)
        {
            var response = _empRepo.AddOrUpdateEmployee(employeeData);
            if (response.Status == 1)
            {
                return Json(response);
            }
            else
            {
                return Json(response);
            }
        }


        [HttpPost]
        public IActionResult DeleteEmployee(int id)
        {
            var response = _empRepo.DeleteEmployee(id);
            return RedirectToAction("GetEmployees");
        }


    }
}
