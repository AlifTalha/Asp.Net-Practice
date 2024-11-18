using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthCode.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        
        public string FName { get; set; }

        public string LName { get; set; }

        public DateTime Dob {  get; set; }

        public double Cgpa { get; set; }
    }
}