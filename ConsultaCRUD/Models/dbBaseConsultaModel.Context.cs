//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsultaCRUD.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbConsultaCadEntities : DbContext
    {
        public dbConsultaCadEntities()
            : base("name=dbConsultaCadEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Consulta> Consulta { get; set; }
        public virtual DbSet<Exame> Exame { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
    }
}
