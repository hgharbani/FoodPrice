﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class JelvehabKhoramshahrEntities : DbContext
    {
        public JelvehabKhoramshahrEntities()
            : base("name=JelvehabKhoramshahrEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<SurplasCosts> SurplasCosts { get; set; }
        public virtual DbSet<Food> Food { get; set; }
        public virtual DbSet<PreparingFood> PreparingFood { get; set; }
    }
}
