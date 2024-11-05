using System;
using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Please provide a name")]
        [RegularExpression(@"^[a-zA-Z._\-]+$", ErrorMessage = "Name can only contain letters, periods, hyphens, and underscores.")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\d{2}-\d{5}-[1-3]$", ErrorMessage = "ID must be in the format 21-44923-2.")]
        public string ID { get; set; }

        [Required(ErrorMessage = "Please provide your date of birth")]
        [CustomValidation(typeof(StudentValidation), "ValidateAge")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [Required]
        [RegularExpression(@"^\d{2}-\d{5}-[1-3]@student\.aiub\.edu$", ErrorMessage = "Email format must be ID@student.aiub.edu")]
        [EmailAddress]
        [CustomValidation(typeof(StudentValidation), "ValidateEmailIDMatch")]
        public string Email { get; set; }
    }
}
