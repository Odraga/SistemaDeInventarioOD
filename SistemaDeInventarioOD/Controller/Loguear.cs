using SistemaDeInventarioOD.Datos;
using SistemaDeInventarioOD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInventarioOD.Controller
{
    class Loguear
    {
        public Usuario Logueando(string usuario, string clave)
        {
            DBDatos dBDatos = new DBDatos();
            Usuario usu = new Usuario();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(clave))
            {
                return usu;
            }
            else
            {
                usu = dBDatos.TraerUsuario(usuario, clave);

                return usu;
            }
        }
    }
}
