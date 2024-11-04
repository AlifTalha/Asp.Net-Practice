using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace personalDemo.Models
{
    public class personInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BloodGroup { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Uri Website { get; set; }
    }
}