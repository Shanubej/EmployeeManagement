using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Repository
{
    public interface IEmployeeRepository
    {
        Response AddOrUpdateEmployee(EmployeeModel model);
        List<EmployeeModel> GetAllEmployees();
        Response DeleteEmployee(int employeeId);
    }
}
