using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInventarioOD.Models
{
    class Usuario
    {
        public int IdUsuario { get; set; }
        public int IdNivelUsuario { get; set; }
        public string NivelUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Identificacion { get; set; }
        public string Clave { get; set; }
        public bool ContieneDatos { get; set; }
    }
}
