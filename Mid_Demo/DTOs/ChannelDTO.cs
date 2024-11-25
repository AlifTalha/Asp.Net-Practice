

using System;
using System.ComponentModel.DataAnnotations;

namespace Mid_Demo.DTO
{
    public class ChannelDTO
    {
        [Key]
        public int ChannelId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Channel Name cannot exceed 100 characters.")]
        public string ChannelName { get; set; }

        [Required]
        [Range(1900, 9999, ErrorMessage = "Established Year must be between 1900 and the current year.")]
        public int EstablishedYear { get; set; }

        public static ValidationResult ValidateEstablishedYear(int year, ValidationContext context)
        {
            var currentYear = DateTime.Now.Year;
            if (year < 1900 || year > currentYear)
            {
                return new ValidationResult($"Established Year must be between 1900 and {currentYear}.");
            }
            return ValidationResult.Success;
        }

        [Required]
        [StringLength(50, ErrorMessage = "Country cannot exceed 50 characters.")]
        public string Country { get; set; }
    }
}
