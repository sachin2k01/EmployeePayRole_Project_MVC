using Microsoft.Data.SqlClient;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class EmployeeRepo : IEmployeeRepo
    {
        string connectionString = @"Data Source=DESKTOP-JJSV9PF\SQLEXPRESS;Initial Catalog=EmployeePayRoleDb;Integrated Security=True;Encrypt=False";
        public List<EmployeeEntity> GetAllEmployee()
        {
            List<EmployeeEntity> employees = new List<EmployeeEntity>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("spGetAllEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure; // Set command type for stored procedure

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EmployeeEntity employeeEntity = new EmployeeEntity()
                    {
                        EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                        EmployeeName = reader["EmployeeName"].ToString(),
                        ImagePath = reader["ImagePath"].ToString(),
                        Gender = reader["Gender"].ToString(),
                        Department = reader["Department"].ToString(),
                        Salary = Convert.ToDecimal(reader["Salary"]),
                        StartDate = Convert.ToDateTime(reader["StartDate"]),
                        Notes = reader["Notes"].ToString()
                    };

                    employees.Add(employeeEntity);
                }

                reader.Close();
            }

            return employees;
        }

    }
}