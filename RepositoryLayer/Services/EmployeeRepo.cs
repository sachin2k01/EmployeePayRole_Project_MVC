using Microsoft.Data.SqlClient;
using ModelLayer.Models;
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


        public EmployeeModel AddEmployee(EmployeeModel employeeModel)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("InsertEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure; // Set command type for stored procedure

                cmd.Parameters.AddWithValue("@EmployeeName", employeeModel.EmployeeName);
                cmd.Parameters.AddWithValue("@ImagePath", employeeModel.ImagePath);
                cmd.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                cmd.Parameters.AddWithValue("@Department",employeeModel.Department);
                cmd.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                cmd.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);
                cmd.Parameters.AddWithValue("@Notes", employeeModel.Notes);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            return employeeModel;
        }


        public EmployeeEntity DeleteEmployeeById(int employeeId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("spDeleteEmpByID", connection))
                {
                    // Set the command type to stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    cmd.Parameters.AddWithValue("@EmplId", employeeId);

                    // Execute the DELETE operation
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Check if rows were affected
                    if (rowsAffected > 0)
                    {
                        // Return the employee that was deleted
                        return new EmployeeEntity { EmployeeId = employeeId };
                    }
                }

                connection.Close();
            }

            return null;
        }



        public EmployeeEntity GetEmployeeById(int employeeId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("spGetEmployeeDetailsById", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpId", employeeId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
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

                            return employeeEntity;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception (log it, throw it, etc.)
                    // Example: Console.WriteLine("Error: " + ex.Message);
                    // You might want to log the error for debugging purposes.
                }
                finally
                {
                    conn.Close();
                }

                return null;
            }
        }

    }

}
