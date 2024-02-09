using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;

namespace EmployeePayRoll_MVC.Controllers.AJAX
{
    public class AjaxController : Controller
    {
        private readonly IEmployeeBusiness _employeeBusiness;
        public AjaxController(IEmployeeBusiness employeeBusiness)
        {
            _employeeBusiness = employeeBusiness;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("GetallEmp")]
        public IActionResult GetAllEmployeeAj()
        {
            List<EmployeeEntity> employeeEntities = _employeeBusiness.GetAllEmployee().ToList();
            return new JsonResult(employeeEntities);

        }
    }
}
