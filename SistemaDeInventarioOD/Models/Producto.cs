using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInventarioOD.Models
{
    class Producto
    {
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        public int IdAlmacen { get; set; }
        public string Almacen { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
    }
}
