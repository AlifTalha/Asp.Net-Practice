using System;
using System.ComponentModel.DataAnnotations;

namespace DepartmentDTO.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name should not exceed 50 characters.")]
        public string FName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name should not exceed 50 characters.")]
        public string LName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        public DateTime Dob { get; set; }

        [Range(0.0, 4.0, ErrorMessage = "Enter a valid CGPA between 0.0 and 4.0.")]
        public double Cgpa { get; set; }
    }
}
