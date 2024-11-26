namespace ExamenMVC_SistemaGestiónEventos_MartinSanchez.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asistentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Email = c.String(),
                        Telefono = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Eventos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        Ubicacion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Inscripciones",
                c => new
                    {
                        InscripcionId = c.Int(nullable: false, identity: true),
                        EventoId = c.Int(nullable: false),
                        AsistenteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InscripcionId)
                .ForeignKey("dbo.Asistentes", t => t.AsistenteId, cascadeDelete: true)
                .ForeignKey("dbo.Eventos", t => t.EventoId, cascadeDelete: true)
                .Index(t => t.EventoId)
                .Index(t => t.AsistenteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inscripciones", "EventoId", "dbo.Eventos");
            DropForeignKey("dbo.Inscripciones", "AsistenteId", "dbo.Asistentes");
            DropIndex("dbo.Inscripciones", new[] { "AsistenteId" });
            DropIndex("dbo.Inscripciones", new[] { "EventoId" });
            DropTable("dbo.Inscripciones");
            DropTable("dbo.Eventos");
            DropTable("dbo.Asistentes");
        }
    }
}
