namespace EmployeeManagementSystem.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using EmployeeManagementSystemModelLayer;
    using EmployeeManagementSystemServiceLayer;
    using Microsoft.AspNetCore.Cors;
    using System;

    /// <summary>
    /// 'Controller' Class.
    /// </summary>
    [EnableCors("ReactPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        /// <param name="employeeService">Reference Of Employee Service.</param>
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        /// <summary>
        /// To View all employees details.
        /// </summary>
        /// <returns>Return Employee Details.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAll()
        {
            try
            {
                var response = this.employeeService.GetAllEmployees();
                if (response == null)
                {
                    return this.BadRequest(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found", null));
                }
                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Employee Details Found", response));
            }
            catch (Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message, null));
            }
        }
        /// <summary>
        /// To Add New Employee Record.
        /// </summary>
        /// <param name="employee">Instance Of Employee.</param>
        /// <returns>Return Message Of Result.</returns>
        [HttpPost]
        public ActionResult AddEmployee([FromBody] Employee employee)
        {
            try
            {
                bool result = this.employeeService.AddEmployee(employee);
                if (result == true)
                {
                    return this.Ok(new ResponseEntity(HttpStatusCode.Created, "Added Successfully", employee));
                }
                return this.BadRequest(new ResponseEntity(HttpStatusCode.OK, "Record Not Inserted", employee));
            }
            catch(Exception e)
            {
                return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, e.Message, null));
            }
        }

        /// <summary>
        /// To Update the records of a particluar employee.
        /// </summary>
        /// <param name="employee">Instance Of Employee.</param>
        /// <returns>Return Message Of Result.</returns>
        [HttpPut]
        public ActionResult UpdateEmployee([FromBody]Employee employee)
        {
            bool result = this.employeeService.UpdateEmployee(employee);
            if (result == true)
            {
                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Updated Successfully", employee));
            }
            return this.BadRequest(new ResponseEntity(HttpStatusCode.NotFound, "No Record Found", employee));
        }

        /// <summary>
        /// To Delete the record on a particular employee.
        /// </summary>
        /// <param name="id">Employee Id.</param>
        /// <returns>Return Message Of Result.</returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int? id)
        {
            bool result = this.employeeService.DeleteEmployee(id);
            if (result == true)
            {
                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Deleted Successfully"));
            }
            return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, "No Record Found"));
        }

        /// <summary>
        /// Get the details of a particular employee.
        /// </summary>
        /// <param name="id">Employee Id.</param>
        /// <returns>Return Message Of Result.</returns>
        [HttpGet("{id}")]
        public  ActionResult GetEmployeeData(int? id)
        {
            var response = this.employeeService.GetEmployeeData(id);
            if (response != null)
            {
                return this.Ok(new ResponseEntity(HttpStatusCode.OK, "Employee Details Found", response));
            }
            return this.BadRequest(new ResponseEntity(HttpStatusCode.BadRequest, "No Record Found", response));
        }
    }
}