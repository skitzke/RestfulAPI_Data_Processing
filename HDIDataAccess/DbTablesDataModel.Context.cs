﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HDIDataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.SqlServer;
    using SqlProviderServices= System.Data.Entity.SqlServer.SqlProviderServices;
    
    public partial class HDIEntities : DbContext
    {
        public HDIEntities()
            : base("name=HDIEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<development_index> development_index { get; set; }
        public virtual DbSet<suicide_statistics> suicide_statistics { get; set; }
        public virtual DbSet<unemployment_rates> unemployment_rates { get; set; }
    }
}