﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proba.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NNVEntities : DbContext
    {
        public NNVEntities()
            : base("name=NNVEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Clanovi> Clanovi { get; set; }
        public virtual DbSet<Prilozi> Prilozi { get; set; }
        public virtual DbSet<Prisustvo> Prisustvo { get; set; }
        public virtual DbSet<Sednice> Sednice { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
