using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Practica_Examen_BD_VC.Models
{
    public class EscuelaDBContext: DbContext
    {

        private const string ConnectionString = "DefaultConnection";

        public EscuelaDBContext() : base(ConnectionString)
        {

        }

        public DbSet<Alumnos> Alumnos { get; set; }
        public DbSet<Examenes> Examenes { get; set; }
        public DbSet<Calificaciones> Calificaciones { get; set; }
     

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<int>().Where(p => p.Name.StartsWith("Matricula")).Configure(p => p.IsKey());

            modelBuilder.Properties<int>().Where(p => p.Name.StartsWith("Pregunta")).Configure(p => p.IsKey());
            modelBuilder.Properties<int>().Where(p => p.Name.StartsWith("Respondida")).Configure(p => p.IsKey());
            modelBuilder.Properties<int>().Where(p => p.Name.StartsWith("Calificacion")).Configure(p => p.IsKey());

            modelBuilder.Entity<PreguntasRespondidas>().HasRequired(x => x.Examenes);
            modelBuilder.Entity<Calificaciones>().HasRequired(x => x.Alumnos);



            base.OnModelCreating(modelBuilder);
        }

    }
}