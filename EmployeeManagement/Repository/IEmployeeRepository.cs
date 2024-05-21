using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Repository
{
    public interface IEmployeeRepository
    {
        int AddOrUpdateEmployee();
    }
}
