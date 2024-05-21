using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _empRepo;
        public EmployeeController(IEmployeeRepository empRepo)
        {
            _empRepo = empRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetEmployees()
        {
            return View();
        }

        [HttpPost]
        [Route("SaveEmployee")]
        public IActionResult SaveEmployee(EmployeeModel data)
        {

            return Ok();

        }
    }
}
