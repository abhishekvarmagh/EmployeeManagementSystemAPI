namespace EmployeeManagementSystemServiceLayer
{
    using System.Collections.Generic;
    using EmployeeManagementSystemModelLayer;

    public interface IEmployeeService
    {
        /// <summary>
        /// To View all employees details.
        /// </summary>
        /// <returns>Return All Employee Details.</returns>
        IEnumerable<Employee> GetAllEmployees();

        /// <summary>
        /// To Add new employee record.
        /// </summary>
        /// <param name="employee">Instance OfEmployee</param>
        /// <returns>Return true or false.</returns>
        bool AddEmployee(Employee employee);

        /// <summary>
        /// To Update the records of a particluar employee.
        /// </summary>
        /// <param name="employee">Instance Of Employee.</param>
        /// <returns>Return true or false.</returns>
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
        /// <returns>Return true or false.</returns>
        bool DeleteEmployee(int? id);
    }
}
