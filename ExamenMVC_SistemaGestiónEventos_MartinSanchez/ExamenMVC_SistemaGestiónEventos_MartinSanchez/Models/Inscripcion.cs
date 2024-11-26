using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamenMVC_SistemaGestiónEventos_MartinSanchez.Models
{
    [Table("Inscripciones")]
    public class Inscripcion
    {
        [Key]
        public int InscripcionId { get; set; }
        public int EventoId { get; set; }
        public virtual Evento Evento { get; set; }
        public int AsistenteId { get; set; }
        public virtual Asistente Asistente { get; set; }
    }
}