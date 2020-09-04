namespace EmployeeManagementSystemRepositoryLayer
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using EmployeeManagementSystemModelLayer;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// 'Employee Repository' Class.
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string connectionString;
        private readonly SqlConnection con;
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeRepository"/> class
        /// </summary>
        /// <param name="configuration">Reference Of Configuration</param>
        public EmployeeRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration.GetSection("ConnectionStrings").GetSection("EmployeeDBConnection").Value;
            con = new SqlConnection(connectionString);
        }

        /// <summary>
        /// To Add new employee record.
        /// </summary>
        public bool AddEmployee(Employee employee)
        {
            try
            {
                SqlCommand cmd = this.StoredProcedureCommand("spAddEmployee");
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@Password", employee.Password);
                cmd.Parameters.AddWithValue("@MobileNumber", employee.MobileNumber);

                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result != 0)
                {
                    return true;
                }
                return false;
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// To Delete the record on a particular employee.
        /// </summary>
        /// <param name="id">Id Of Employee.</param>
        public bool DeleteEmployee(int? id)
        {
            try
            {
                SqlCommand cmd = this.StoredProcedureCommand("spDeleteEmployee");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpId", id);

                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result != 0)
                {
                    return true;
                }
                return false;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// To View all employees details.
        /// </summary>
        /// <returns>Return All Employee Details.</returns>
        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                List<Employee> lstemployee = new List<Employee>();
                SqlCommand cmd = this.StoredProcedureCommand("spGetAllEmployees");
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        Employee employee = new Employee();
                        employee.ID = Convert.ToInt32(rdr["EmployeeID"]);
                        employee.Name = rdr["Name"].ToString();
                        employee.Email = rdr["Email"].ToString();
                        employee.Password = rdr["Password"].ToString();
                        employee.MobileNumber = rdr["MobileNumber"].ToString();
                        lstemployee.Add(employee);
                    }
                    con.Close();
                    return lstemployee;
                }
                return null;   
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Get the details of a particular employee.
        /// </summary>
        /// <param name="id">Id Of Employee.</param>
        /// <returns>Instance Of Employee.</returns>
        public Employee GetEmployeeData(int? id)
        {
            try
            {
                Employee employee = new Employee();
                SqlCommand cmd = this.StoredProcedureCommand("spGetEmployeeData");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpId", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        employee.ID = Convert.ToInt32(rdr["EmployeeID"]);
                        employee.Name = rdr["Name"].ToString();
                        employee.Email = rdr["Email"].ToString();
                        employee.Password = rdr["Password"].ToString();
                        employee.MobileNumber = rdr["MobileNumber"].ToString();
                    }
                    con.Close();
                    return employee;
                }
                return null;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// To Update the records of a particluar employee.
        /// </summary>
        /// <param name="employee">Instance Of Employee.</param>
        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                SqlCommand cmd = this.StoredProcedureCommand("spUpdateEmployee");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpId", employee.ID);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@Password", employee.Password);
                cmd.Parameters.AddWithValue("@MobileNumber", employee.MobileNumber);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result != 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Method For Stored Procedure.
        /// </summary>
        /// <param name="procedureName">Stored Procedure Name.</param>
        /// <returns>Return The Store Procedure Result.</returns>
        public SqlCommand StoredProcedureCommand(string procedureName)
        {
            using( SqlCommand cmd = new SqlCommand(procedureName, con) )
            {
                cmd.CommandType = CommandType.StoredProcedure;
                return cmd;
            }
        }
    }
}