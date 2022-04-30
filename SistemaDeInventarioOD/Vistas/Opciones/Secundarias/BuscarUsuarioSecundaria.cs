using SistemaDeInventarioOD.Controller;
using SistemaDeInventarioOD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeInventarioOD.Vistas.Opciones.Secundarias
{
    public partial class BuscarUsuarioSecundaria : Form
    {
        List<Usuario> usuarios = new List<Usuario>();
        List<Usuario> usuariosBusqueda = new List<Usuario>();

        public BuscarUsuarioSecundaria()
        {
            InitializeComponent();
            CargarDatosUsuarios();
        }
        private void CargarDatosUsuarios()
        {
            Administrador administrador = new Administrador();
            usuarios = administrador.VerUsuarios();

            dgvUsuarios.Rows.Clear();

            foreach (var usuario in usuarios)
            {
                dgvUsuarios.Rows.Add(usuario.IdUsuario,
                usuario.NivelUsuario,
                usuario.NombreUsuario,
                usuario.NombreCompleto,
                usuario.Identificacion,
                usuario.Clave);
            }
            
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            usuariosBusqueda.Clear();

            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {

                foreach (var usuario in usuarios)
                {
                    if (usuario.NombreCompleto.Contains(txtBuscar.Text))
                    {
                        usuariosBusqueda.Add(usuario);
                    }
                    else if (usuario.Identificacion.Contains(txtBuscar.Text))
                    {
                        usuariosBusqueda.Add(usuario);
                    }
                    else if (usuario.NombreUsuario.Contains(txtBuscar.Text))
                    {
                        usuariosBusqueda.Add(usuario);
                    }
                }

                dgvUsuarios.Rows.Clear();

                foreach (var usuario in usuariosBusqueda)
                {
                    dgvUsuarios.Rows.Add(usuario.IdUsuario,
                    usuario.NivelUsuario,
                    usuario.NombreUsuario,
                    usuario.NombreCompleto,
                    usuario.Identificacion,
                    usuario.Clave);
                }
            }
        }

        private void btnLimpiarBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarDatosUsuarios();
        }
    }
}
