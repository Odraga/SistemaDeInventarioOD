using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInventarioOD.Models
{
    class Proveedor
    {
        public int IdProveedor { get; set; }
        public string NombreCompleto { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
    }
}
