using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacturacionWEBII.Models
{
    public class Producto
    {
        [Key]
        [Required]
        [DisplayName ("CODIGO")]
        public int IdProduct { get; set; }

        [Required]
        [DisplayName("NOMBRE PRODUCTO")]
        public string Nombre { get; set; }

        [DisplayName("MARCA")]
        public string Marca { get; set; }

        [Required]
        [DisplayName("FAMILIA")]
        public string Familia { get; set; }

        [Required]
        [DisplayName("FABRICANTE")]
        public string Fabricante { get; set; }

        [Required]
        [DisplayName("TIPO UNIDAD")]
        public string Tipo_Unidad { get; set; }

        [DisplayName("DEPARTAMENTO")]
        public string Departamento { get; set; }

        [DisplayName("CONDICION")]
        public bool Activo { get; set; }

        [DisplayName("FECHA INGRESO")]
        public DateTime Fecha_Ingreso { get; set; }

        [DisplayName("UNIDAD")]
        public string Unidad { get; set; }
        [DisplayName("IMPUESTO VENTAS")]
        public float Impuesto { get; set; }
    }
}