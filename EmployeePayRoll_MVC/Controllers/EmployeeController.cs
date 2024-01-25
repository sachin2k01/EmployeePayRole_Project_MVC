using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Models;
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

        [HttpGet]
        [Route("Create")]
        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult CreateEmployee([Bind] EmployeeModel empModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _employeeBusiness.AddEmployee(empModel);
                    return RedirectToAction("GetAllEmployee");
                }
                return View(empModel);
            }
            catch (Exception ex)
            {

                return View(empModel);
            }

        }

        [HttpGet]
        [Route("delete/{empId}")]
        public IActionResult Delete(int empId)
        {
            try
            {
                // Check if empId is a valid value
                if (empId <= 0)
                {
                    return NotFound();
                }

                EmployeeEntity employee = _employeeBusiness.GetEmployeeById(empId);

                if (employee == null)
                {
                    return NotFound();
                }

                return View(employee);
            }
            catch (Exception)
            {
                return RedirectToAction("GetAllEmployee");
            }
        }

        [HttpPost]
        [Route("delete/{empId}")]
        public IActionResult DeleteConfirmed(int empId)
        {
            try
            {
                // Perform the deletion
                _employeeBusiness.DeleteEmployeeById(empId);

                // Redirect to the employee list page after deletion
                return RedirectToAction("GetAllEmployee");
            }
            catch (Exception ex)
            {
                return RedirectToAction("GetAllEmployee");
            }
        }

    }
}
