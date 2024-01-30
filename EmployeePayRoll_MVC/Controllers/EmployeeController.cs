using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Models;
using RepositoryLayer.Entity;

namespace EmployeePayRoll_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeBusiness _employeeBusiness;
        public EmployeeController(IEmployeeBusiness employeeBusiness, ILogger<EmployeeController> logger)
        {
            _employeeBusiness = employeeBusiness;
            _logger = logger;
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
                _logger.LogError(ex.Message, ex);
                ModelState.AddModelError(string.Empty, "An error occurred while processing your request.");
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
                _logger.LogTrace("Employee with Id "+empId+"is deleted");
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

        [HttpGet]
        [Route("Update/{empId}")]
        public IActionResult UpdateEmp(int  empId)
        {
            if(empId == 0)
            {
                return NotFound();
            }
            EmployeeEntity employee=_employeeBusiness.GetEmployeeById(empId);
            if(employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [Route("Update/{empId}")]
        public IActionResult UpdateEmp(int empId,[Bind]EmployeeEntity employee)
        {
            try
            {
                if(empId!=employee.EmployeeId)
                {
                    return NotFound();
                }
                if(ModelState.IsValid)
                {
                    var result = _employeeBusiness.UpdateEmployee(employee);
                    return RedirectToAction("GetAllEmployee");
                }
                return View();

            }
            catch (Exception )
            {
                return View(employee);
            }
        }


        public IActionResult GetEmployeeDetials(int empId)
        {
            try
            {
                if (empId == 0)
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

                return View();
            }
        }

        [HttpGet]
        [Route("SearchEmployee")]
        public IActionResult SearchEmployee(string searchterm)
        {
            ViewData["GetAllEmployee"] = searchterm;
            List<EmployeeEntity> employees = _employeeBusiness.SearchEmployeeByName(searchterm);
            return View("GetAllEmployee", employees);
        }


        [HttpGet]
        [Route("Login")]
        public IActionResult EmployeeLogin()
        {
            return View() ;
        }

        [HttpPost]
        [Route("Login")]

        public IActionResult EmployeeLogin([Bind]LoginModel loginEmployee)
        {
            try
            {
                var result = _employeeBusiness.EmployeeLogin(loginEmployee);
                if(result == null)
                {
                    return NotFound("Login Failed!");
                }
                else
                {
                    HttpContext.Session.SetInt32("EmployeeId",loginEmployee.EmployeeId);
                    HttpContext.Session.SetString("EmployeeName", loginEmployee.EmployeeName);
                    return RedirectToAction("GetEmployeeDetials", new { empId = loginEmployee.EmployeeId});
                }

            }
            catch (Exception )
            {
                return BadRequest();
            }
        }

    }
}
