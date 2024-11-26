using ExamenMVC_SistemaGestiónEventos_MartinSanchez.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ExamenMVC_SistemaGestiónEventos_MartinSanchez.DbContext
{
    public class Context : System.Data.Entity.DbContext
    {
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Asistente> Asistentes { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }

        public Context() : base("ConexionBD")
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}