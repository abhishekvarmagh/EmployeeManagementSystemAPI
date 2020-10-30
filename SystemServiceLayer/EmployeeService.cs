namespace EmployeeManagementSystemServiceLayer
{
    using System.Collections.Generic;
    using EmployeeManagementSystemModelLayer;
    using EmployeeManagementSystemRepositoryLayer;

    /// <summary>
    /// 'Employee Service' Class.
    /// </summary>
    public class EmployeeService : IEmployeeService
    {

        private readonly IEmployeeRepository employeeRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeService"/> class.
        /// </summary>
        /// <param name="employeeRepository">Reference Of IEmployeeRepository</param>
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        /// <summary>
        /// To Add new employee record.
        /// </summary>
        /// <param name="employee">Instance Of Employee.</param>
        /// <returns>Return True Or False.</returns>
        public bool AddEmployee(Employee employee)
        {
            return employeeRepository.AddEmployee(employee);
        }

        /// <summary>
        /// To Delete the record on a particular employee.
        /// </summary>
        /// <param name="id">Id Of Employee.</param>
        /// <returns>Return True Or False.</returns>
        public bool DeleteEmployee(int? id)
        {
            return employeeRepository.DeleteEmployee(id);
        }

        /// <summary>
        /// To View all employees details.
        /// </summary>
        /// <returns>Return All Employee Details.</returns>
        public IEnumerable<Employee> GetAllEmployees()
        {
            return employeeRepository.GetAllEmployees();
        }

        /// <summary>
        /// Get the details of a particular employee.
        /// </summary>
        /// <param name="id">Id Of Employee.</param>
        /// <returns>Instance Of Employee.</returns>
        public Employee GetEmployeeData(int? id)
        {
            return employeeRepository.GetEmployeeData(id);
        }

        /// <summary>
        /// To Update the records of a particluar employee.
        /// </summary>
        /// <param name="employee">Instance Of Employee.</param>
        /// <returns>Return True Or False.</returns>
        public bool UpdateEmployee(Employee employee)
        {
            return employeeRepository.UpdateEmployee(employee);
        }
    }
}
