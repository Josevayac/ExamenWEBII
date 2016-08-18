using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacturacionWEBII.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("CEDULA")]
        public string Cedula { get; set; }

        [Required]
        [DisplayName("NOMBRE")]
        public string Nombre { get; set; }

        [Required]
        [DisplayName("APELLIDOS")]
        public string Apellido { get; set; }

        
        [DisplayName("FECHA CUMPLEAÑOS")]
        public DateTime Fecha_Nacimiento { get; set; }

        [Required]
        [DisplayName("DIRECCION")]
        public string Dirección { get; set; }

        [DisplayName("ESTADO CIVIL")]
        public string Estado_Civil { get; set; }

        [Required]
        [DisplayName("GENERO")]
        public char Sexo { get; set; }

        [DisplayName("FECHA REGISTRO")]
        public DateTime Fecha_Ingreso { get; set; }

        [DisplayName("TIPO CLIENTE")]
        [DefaultValue("Detallista")]
        public string TipoClient { get; set; }

        [DisplayName("DESCUENTO APLICABLE")]
        public float Descuento { get; set; }
    }
}