namespace ExamenMVC_SistemaGestiónEventos_MartinSanchez.Migrations
{
    using ExamenMVC_SistemaGestiónEventos_MartinSanchez.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ExamenMVC_SistemaGestiónEventos_MartinSanchez.DbContext.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ExamenMVC_SistemaGestiónEventos_MartinSanchez.DbContext.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var asistentes = new List<Asistente>
            {
                new Asistente { Nombre = "Carlos Pérez", Email = "carlos.perez@gmail.com", Telefono = "555-1234" },
                new Asistente { Nombre = "Ana García", Email = "ana.garcia@gmail.com", Telefono = "555-5678" },
                new Asistente { Nombre = "Luis Fernández", Email = "luis.fernandez@gmail.com", Telefono = "555-8765" },
                new Asistente { Nombre = "María López", Email = "maria.lopez@gmail.com", Telefono = "555-4321" },
                new Asistente { Nombre = "Pedro Sánchez", Email = "pedro.sanchez@hotmail.com", Telefono = "555-6543" },
                new Asistente { Nombre = "Laura Jiménez", Email = "laura.jimenez@live.com", Telefono = "555-9876" },
                new Asistente { Nombre = "Jorge Martínez", Email = "jorge.martinez@gmail.com", Telefono = "555-3456" },
                new Asistente { Nombre = "Lucía Gómez", Email = "lucia.gomez@gmail.com", Telefono = "555-7654" },
                new Asistente { Nombre = "Andrés Torres", Email = "andres.torres@outlook.com", Telefono = "555-6789" },
                new Asistente { Nombre = "Claudia Ruiz", Email = "claudia.ruiz@gmail.com", Telefono = "555-9870" }
            };

            asistentes.ForEach(asistente => context.Asistentes.AddOrUpdate(a => a.Email, asistente));
            context.SaveChanges();

            var eventos = new List<Evento>
            {
                new Evento { Nombre = "Conferencia de Tecnología", Fecha = new DateTime(2024, 12, 10), Ubicacion = "Centro de Convenciones" },
                new Evento { Nombre = "Feria de Innovación", Fecha = new DateTime(2025, 01, 15), Ubicacion = "ExpoForum" },
                new Evento { Nombre = "Seminario de Educación", Fecha = new DateTime(2025, 02, 20), Ubicacion = "Auditorio Principal" },
                new Evento { Nombre = "Foro de Negocios", Fecha = new DateTime(2025, 03, 05), Ubicacion = "Hotel Las Palmas" },
                new Evento { Nombre = "Festival Cultural", Fecha = new DateTime(2025, 04, 12), Ubicacion = "Plaza Central" }
            };

            eventos.ForEach(evento => context.Eventos.AddOrUpdate(e => e.Nombre, evento));
            context.SaveChanges();

            var inscripciones = new List<Inscripcion>
            {
                new Inscripcion { EventoId = 1, AsistenteId = 1 },
                new Inscripcion { EventoId = 1, AsistenteId = 2 },
                new Inscripcion { EventoId = 2, AsistenteId = 3 },
                new Inscripcion { EventoId = 3, AsistenteId = 4 },
                new Inscripcion { EventoId = 4, AsistenteId = 5 },
                new Inscripcion { EventoId = 2, AsistenteId = 6 },
                new Inscripcion { EventoId = 5, AsistenteId = 7 },
                new Inscripcion { EventoId = 3, AsistenteId = 8 },
                new Inscripcion { EventoId = 4, AsistenteId = 9 },
                new Inscripcion { EventoId = 1, AsistenteId = 10 },
                new Inscripcion { EventoId = 1, AsistenteId = 4 },
            };

            inscripciones.ForEach(inscripcion => context.Inscripciones.Add(inscripcion));
            context.SaveChanges();
        }
    }
}
