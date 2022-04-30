using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInventarioOD.Models
{
    class FacturaCompra
    {
        public int IdCompra{ get; set; }
        public int IdProveedor{ get; set; }
        public string Proveedor { get; set; }
        public int IdProducto { get; set; }
        public string NroDocumento { get; set; }
        public string FechaRegistro { get; set; }
        public string Producto { get; set; }
        public float PrecioCompra { get; set; }
        public float PrecioVenta { get; set; }
        public int CantidadProductos { get; set; }
        public float PrecioTotal { get; set; }
    }
}
