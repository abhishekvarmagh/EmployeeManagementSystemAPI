using EmployeeManagementSystem.Controllers;
using EmployeeManagementSystemModelLayer;
using EmployeeManagementSystemServiceLayer;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace EmployeeManagementUnitTest
{
    public class EmployeeManagementTest
    {

        private EmployeeController employeeController;
        private List<Employee> employeeList;

        [SetUp]
        public void Setup()
        {
            this.employeeList = new List<Employee>
            {
                new Employee
                {
                    ID = 23,
                    Name = "Abhishek",
                    Email = "abhishektheverma@gmail.com",
                    Password = "Abhishek",
                    MobileNumber = "9082145106"
                }
            };
        }

        [Test]
        public async Task When_GetAllEmployees_ShouldReturn_AllEmployeesAsync()
        {
            var service = new Mock<IEmployeeService>();
            service.Setup(x => x.GetAllEmployees()).Returns(employeeList);
            employeeController = new EmployeeController(service.Object);
            OkObjectResult actionResult = (OkObjectResult)await employeeController.GetAll();
            ResponseEntity responseEntity = (ResponseEntity)actionResult.Value;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(200, actionResult.StatusCode);
            Assert.AreEqual(HttpStatusCode.OK, responseEntity.HttpStatusCode);
            Assert.AreEqual("Employee Details Found", responseEntity.Message);
        }
    }
}