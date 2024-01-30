using BusinessLayer.Interface;
using ModelLayer.Models;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class EmployeeBusiness:IEmployeeBusiness
    {
        public readonly IEmployeeRepo _repo;
        public EmployeeBusiness(IEmployeeRepo repo)
        {
            _repo = repo;
        }
        public List<EmployeeEntity> GetAllEmployee()
        {
            return _repo.GetAllEmployee();

        }

        public EmployeeModel AddEmployee(EmployeeModel employeeModel)
        {
            return _repo.AddEmployee(employeeModel);
        }

        public EmployeeEntity DeleteEmployeeById(int employeeId)
        {
            return _repo.DeleteEmployeeById(employeeId);
        }

        public EmployeeEntity GetEmployeeById(int employeeId)
        {
            return _repo.GetEmployeeById(employeeId);
        }

        public EmployeeEntity UpdateEmployee(EmployeeEntity employee)
        {
            return _repo.UpdateEmployee(employee);
        }

        public List<EmployeeEntity> SearchEmployeeByName(string searchName)
        {
            return _repo.SearchEmployeeByName(searchName);
        }

        public EmployeeEntity EmployeeLogin(LoginModel login)
        {
            return _repo.EmployeeLogin(login);
        }
    }
}
