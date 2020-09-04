namespace EmployeeManagementSystemModelLayer
{
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$",ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^[1-9]{1}[0-9]{9}$", ErrorMessage = "Mobile Number Should Contain Ten Digits")]
        public string MobileNumber { get; set; }
    }
}
