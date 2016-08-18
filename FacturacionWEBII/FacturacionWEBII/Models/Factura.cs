using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace FacturacionWEBII.Models
{
    public class Factura
    {
        [Key, DisplayName("# CONSECUTIVO #")]
        public int IdFactura { get; set; }

        [DisplayName("FECHA FACTURA")]
        public DateTime FechaFactura { get; set; }

        [DisplayName("CLIENTE")]
        public Cliente IdCliente { get; set; }


        public List<Producto> Productos { get; set; }

        public ICollection<Producto> IProductos { get; set; }
    }
}