using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace ORTPro.Models
{
    public class Profesional
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        [EnumDataType(typeof(Servicio))]
        public Servicio Servicio { get; set; }
        [EnumDataType(typeof(Barrio))]
        public Barrio Barrio { get; set; }
        [EnumDataType(typeof(Puntuacion))]
        public Puntuacion Puntuacion { get; set; }
    }
}
