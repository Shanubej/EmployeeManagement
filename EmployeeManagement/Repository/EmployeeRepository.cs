using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Response AddOrUpdateEmployee(EmployeeModel model)
        {
            Response response = new Response();
            try
            {
                var empData = _dbContext.employeeModels.FirstOrDefault(a => a.Id == model.Id);

                if (empData != null)
                {
                    empData.FirstName = model.FirstName;
                    empData.LastName = model.LastName;
                    empData.Email = model.Email;
                    empData.Mobile = model.Mobile;
                    empData.Gender = model.Gender;
                    empData.DOB = model.DOB;
                    empData.Designation = model.Designation;
                    empData.DOJ = model.DOJ;
                }
                else
                {
                    _dbContext.employeeModels.Add(model);
                }
                _dbContext.SaveChanges();


                response = new Response
                {
                    Status = 1,
                    Message = "success"
                };

                return response;
            }
            catch (Exception ex)
            {
                response = new Response
                {
                    Status = 0,
                    Message = ex.Message
                };
                return response;
            }

        }

        public List<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> employeeList = new List<EmployeeModel>();
            try
            {
                employeeList = _dbContext.employeeModels.ToList();
            }
            catch(Exception ex)
            {

            }
            return employeeList;
        }

        public Response DeleteEmployee(int employeeId)
        {
            Response response = new Response();
            try
            {
                var emp = _dbContext.employeeModels.Find(employeeId);

                _dbContext.employeeModels.Remove(emp);
                _dbContext.SaveChanges();
                response = new Response
                {
                    Status = 1,
                    Message = "success"
                };

                return response;
            }
            catch(Exception ex )
            {
                response = new Response
                {
                    Status = 0,
                    Message = ex.Message
                };
                return response;
            }
        }
    }
}
