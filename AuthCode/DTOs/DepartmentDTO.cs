using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuthCode.DTOs
{
    public class DepartmentDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }
    }
}