﻿using ModelLayer.Models;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IEmployeeBusiness
    {
        public List<EmployeeEntity> GetAllEmployee();
        public EmployeeModel AddEmployee(EmployeeModel employeeModel);

        public EmployeeEntity DeleteEmployeeById(int employeeId);
        public EmployeeEntity GetEmployeeById(int employeeId);

        public EmployeeEntity UpdateEmployee(EmployeeEntity employee);

        public List<EmployeeEntity> SearchEmployeeByName(string searchName);
        public EmployeeEntity EmployeeLogin(LoginModel login);
        public List<EmployeeEntity> GetEmployeeByDate(DateModel Dates);
    }
}
