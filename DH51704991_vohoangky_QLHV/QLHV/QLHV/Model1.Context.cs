﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLHV
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class qlhvEntities : DbContext
    {
        public qlhvEntities()
            : base("name=qlhvEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<diemthi> diemthis { get; set; }
        public virtual DbSet<lop> lops { get; set; }
        public virtual DbSet<lylich> lyliches { get; set; }
        public virtual DbSet<monhoc> monhocs { get; set; }
    }
}
