//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AuthCode.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Nullable<int> DeptId { get; set; }
    
        public virtual Department Department { get; set; }
    }
}
