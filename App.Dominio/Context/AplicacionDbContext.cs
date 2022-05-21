using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace App.Dominio.Entidades
{
    public partial class AplicacionDbContext : DbContext
    {
        public AplicacionDbContext()
            : base("name=DbContext")
        {
        }

        public virtual DbSet<Personas> Personas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personas>()
                .Property(e => e.Nombre)
                .IsUnicode(false);
        }
    }
}
