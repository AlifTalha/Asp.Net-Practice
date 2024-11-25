using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mid_Demo.DTOs
{
    public class ProgramDTO
    {
        [Key]
        public int ProgramId { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Program Name cannot exceed 150 characters.")]
        public string ProgramName { get; set; }

        [Required]
        [Range(0.0, 10.0, ErrorMessage = "TRP Score must be between 0.0 and 10.0.")]
        public decimal TRPScore { get; set; }

        [Required]
        public int ChannelId { get; set; } 

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan AirTime { get; set; }
    }
}