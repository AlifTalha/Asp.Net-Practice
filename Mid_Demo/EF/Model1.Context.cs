﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mid_Demo.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TRP_TablaEntities1 : DbContext
    {
        public TRP_TablaEntities1()
            : base("name=TRP_TablaEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Channel_Table> Channel_Table { get; set; }
        public virtual DbSet<Program_Table> Program_Table { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
