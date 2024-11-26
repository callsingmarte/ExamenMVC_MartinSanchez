using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamenMVC_SistemaGestiónEventos_MartinSanchez.Models
{
    [Table("Eventos")]
    public class Evento
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public string Ubicacion { get; set; }
    }
}