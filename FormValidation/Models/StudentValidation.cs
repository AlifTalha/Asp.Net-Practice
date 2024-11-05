using System;
using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models
{
    public static class StudentValidation
    {
        public static ValidationResult ValidateAge(DateTime dob, ValidationContext context)
        {
            int age = DateTime.Now.Year - dob.Year;
            if (dob > DateTime.Now.AddYears(-age)) age--;
            return age >= 20 ? ValidationResult.Success : new ValidationResult("Age must be > 20 years.");
        }

        public static ValidationResult ValidateEmailIDMatch(string email, ValidationContext context)
        {
            var instance = context.ObjectInstance as Student;
            if (instance == null || string.IsNullOrEmpty(instance.ID) || string.IsNullOrEmpty(email))
                return ValidationResult.Success;

            string emailIDPart = email.Split('@')[0];
            if (emailIDPart != instance.ID)
            {
                return new ValidationResult("Email must match the same ID as in the ID field.");
            }

            return ValidationResult.Success;
        }
    }
}
