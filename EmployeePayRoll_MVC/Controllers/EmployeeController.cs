using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;

namespace EmployeePayRoll_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeBusiness _employeeBusiness;
        public EmployeeController(IEmployeeBusiness employeeBusiness)
        {
            _employeeBusiness = employeeBusiness;           
        }

        [HttpGet("AllEmp")]
        public IActionResult GetAllEmployee()
        {
            List<EmployeeEntity> employeeEntities = _employeeBusiness.GetAllEmployee().ToList();
            return View("GetAllEmployee", employeeEntities);

        }
    }
}
