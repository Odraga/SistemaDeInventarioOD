using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInventarioOD.Models
{
    class Cliente
    {
        public int IdCliente { get; set; }
        public string NombreCompleto { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
    }
}
