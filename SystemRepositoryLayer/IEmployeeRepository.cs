using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManagementSystemModelLayer;

namespace EmployeeManagementSystemRepositoryLayer
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// To View all employees details.
        /// </summary>
        /// <returns>Return All Employee Details.</returns>
        IEnumerable<Employee> GetAllEmployees();

        /// <summary>
        /// To Add new employee record.
        /// </summary>
        bool AddEmployee(Employee employee);

        /// <summary>
        /// To Update the records of a particluar employee.
        /// </summary>
        /// <param name="employee">Instance Of Employee.</param>
        bool UpdateEmployee(Employee employee);

        /// <summary>
        /// Get the details of a particular employee.
        /// </summary>
        /// <param name="id">Id Of Employee.</param>
        /// <returns>Instance Of Employee.</returns>
        Employee GetEmployeeData(int? id);

        /// <summary>
        /// To Delete the record on a particular employee.
        /// </summary>
        /// <param name="id">Id Of Employee.</param>
        bool DeleteEmployee(int? id);
    }
}
