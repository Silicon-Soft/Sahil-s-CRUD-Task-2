using System.ComponentModel.DataAnnotations;

namespace Task2.ViewModel
{
    public class EmployeeViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "Maximum 10 characters only")]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public double Salary { get; set; }
    }
}
