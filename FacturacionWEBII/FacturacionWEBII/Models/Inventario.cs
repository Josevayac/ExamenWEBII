using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacturacionWEBII.Models
{
    public class Inventario
    {
        [Key, Required]
        public int IdInvent { get; set; }

        [Required, DisplayName("ID PRODUCTO")]
        public List<Producto> Productos { get; set; }

        [DisplayName("EXISTENCIA")]
        public int Cantidad { get; set; }

        [DisplayName("MINIMO")]
        public int Cantidad_Mínima { get; set; }

        [DisplayName("MAXIMO")]
        public int Cantidad_Máxima { get; set; }

        [DisplayName("GRAVADO"), DefaultValue("Gravado")]
        public bool Gravado_Excepto { get; set; }

        public ICollection<Producto> IProductos { get; set; }
    }
}