using System.ComponentModel.DataAnnotations;

namespace asp.netCore_project.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "اسم الموظف مطلوب")]
        public string? EmployeeName { get; set; }
        [Required(ErrorMessage = "رقم الموظف مطلوب")]
        public string? EmployeePhone { get; set; }
        public string? EmployeeEmail { get; set; }
        
        public int? EmployeeAge { get; set; }
        public string? EmployeeSalary { get; set; }


    }
}
