using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class Student
    {
        [Required(ErrorMessage ="Please Provide Name..")]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [Range(1,20,ErrorMessage ="ID must be  between 1 to 20")]
        public int ID { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}