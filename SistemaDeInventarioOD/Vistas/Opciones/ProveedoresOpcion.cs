using SistemaDeInventarioOD.Controller;
using SistemaDeInventarioOD.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SistemaDeInventarioOD.Vistas.Opciones
{
    public partial class ProveedoresOpcion : Form
    {
        private static Usuario usuario = new Usuario();
        private static List<Proveedor> proveedores = new List<Proveedor>();
        private List<Proveedor> proveedoresBusqueda = new List<Proveedor>();

        public ProveedoresOpcion()
        {
            InitializeComponent();

            CargarDatosProveedores();
        }
        public void DatosUsuario(dynamic usu)
        {
            usuario = usu;
        }
        private void CargarDatosProveedores()
        {
            Administrador administrador = new Administrador();
            proveedores = administrador.VerProveedores();

            dgvProveedores.DataSource = proveedores;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void lblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (usuario.IdNivelUsuario == 1)
            {
                Proveedor proveedor = new Proveedor();

                proveedor.NombreCompleto = txtNombreCompleto.Text;
                proveedor.Identificacion = txtIdentificacion.Text;
                proveedor.Telefono = txtTelefono.Text;
                proveedor.Direccion = txtDireccion.Text;
                proveedor.Correo = txtCorreo.Text;

                Administrador administrador = new Administrador();

                string mensaje = administrador.NuevoProveedor(proveedor);

                MessageBox.Show(mensaje);

                CargarDatosProveedores();
            }
            else
            {
                MessageBox.Show("No tiene el nivel suficiente para hacer está Acción!");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreCompleto.Text = string.Empty;
            txtIdentificacion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCorreo.Text = string.Empty;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
             proveedoresBusqueda.Clear();
            //dgvProveedores.Rows.Clear();

            if (!string.IsNullOrEmpty(cbBuscarPor.Text) && !string.IsNullOrEmpty(txtBuscar.Text))
            {
                if (cbBuscarPor.Text == "Nombre")
                {
                    foreach (var cliente in proveedores)
                    {
                        if (cliente.NombreCompleto.Contains(txtBuscar.Text))
                        {
                            proveedoresBusqueda.Add(cliente);
                        }
                    }
                    dgvProveedores.DataSource = proveedoresBusqueda;
                }
                else if (cbBuscarPor.Text == "Identificacion")
                {
                    foreach (var cliente in proveedores)
                    {
                        if (cliente.Identificacion.Contains(txtBuscar.Text))
                        {
                            proveedoresBusqueda.Add(cliente);
                        }
                    }
                    dgvProveedores.DataSource = proveedoresBusqueda;
                }
                else if (cbBuscarPor.Text == "Telefono")
                {
                    foreach (var cliente in proveedores)
                    {
                        if (cliente.Telefono.Contains(txtBuscar.Text))
                        {
                            proveedoresBusqueda.Add(cliente);
                        }
                    }
                    dgvProveedores.DataSource = proveedoresBusqueda;
                }
                else if (cbBuscarPor.Text == "Direccion")
                {
                    foreach (var cliente in proveedores)
                    {
                        if (cliente.Direccion.Contains(txtBuscar.Text))
                        {
                            proveedoresBusqueda.Add(cliente);
                        }
                    }
                    dgvProveedores.DataSource = proveedoresBusqueda;
                }
                else if (cbBuscarPor.Text == "Correo")
                {
                    foreach (var cliente in proveedores)
                    {
                        if (cliente.Correo.Contains(txtBuscar.Text))
                        {
                            proveedoresBusqueda.Add(cliente);
                        }
                    }
                    dgvProveedores.DataSource = proveedoresBusqueda;
                }
            }
            else
            {
                CargarDatosProveedores();
            }
        }

        private void btnLimpiarBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = string.Empty;
            CargarDatosProveedores();
        }
    }
}
