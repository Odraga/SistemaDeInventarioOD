using SistemaDeInventarioOD.Controller;
using SistemaDeInventarioOD.Datos;
using SistemaDeInventarioOD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeInventarioOD.Vistas.Opciones
{
    public partial class ClientesOpcion : Form
    {
        private static Usuario usuario = new Usuario();
        private static List<Cliente> clientes = new List<Cliente>();
        private List<Cliente> clientesBusqueda = new List<Cliente>();

        public ClientesOpcion()
        {
            InitializeComponent();

            CargarDatosClientes();
        }
        public void DatosUsuario(dynamic usu)
        {
            usuario = usu;
        }
        private void CargarDatosClientes()
        {
            Administrador administrador = new Administrador();
            clientes = administrador.VerClientes();

            dgvClientes.DataSource = clientes;
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

        private void ClientesOpcion_Load(object sender, EventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (usuario.IdNivelUsuario == 1)
            {
                Cliente cliente = new Cliente();

                cliente.NombreCompleto = txtNombreCompleto.Text;
                cliente.Identificacion = txtIdentificacion.Text;
                cliente.Telefono = txtTelefono.Text;
                cliente.Celular = txtCelular.Text;
                cliente.Correo = txtCorreo.Text;

                Administrador administrador = new Administrador();

                string mensaje = administrador.NuevoCliente(cliente);

                MessageBox.Show(mensaje);

                CargarDatosClientes();
            }
            else
            {
                MessageBox.Show("No tiene el nivel suficiente para hacer está Acción!");
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreCompleto.Text = string.Empty;
            txtIdentificacion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCelular.Text = string.Empty;
            txtCorreo.Text = string.Empty;
        }

        /*
         * Nombre
Identificacion
Telefono
Celular
Correo
         */
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            clientesBusqueda.Clear();
            //dgvClientes.Rows.Clear();

            if (!string.IsNullOrEmpty(cbBuscarPor.Text) && !string.IsNullOrEmpty(txtBuscar.Text))
            {
                if (cbBuscarPor.Text == "Nombre")
                {
                    foreach (var cliente in clientes)
                    {
                        if (cliente.NombreCompleto.Contains(txtBuscar.Text))
                        {
                            clientesBusqueda.Add(cliente);
                        }
                    }
                    dgvClientes.DataSource = clientesBusqueda;
                }
                else if (cbBuscarPor.Text == "Identificacion")
                {
                    foreach (var cliente in clientes)
                    {
                        if (cliente.Identificacion.Contains(txtBuscar.Text))
                        {
                            clientesBusqueda.Add(cliente);
                        }
                    }
                    dgvClientes.DataSource = clientesBusqueda;
                }
                else if (cbBuscarPor.Text == "Telefono")
                {
                    foreach (var cliente in clientes)
                    {
                        if (cliente.Telefono.Contains(txtBuscar.Text))
                        {
                            clientesBusqueda.Add(cliente);
                        }
                    }
                    dgvClientes.DataSource = clientesBusqueda;
                }
                else if (cbBuscarPor.Text == "Celular")
                {
                    foreach (var cliente in clientes)
                    {
                        if (cliente.Celular.Contains(txtBuscar.Text))
                        {
                            clientesBusqueda.Add(cliente);
                        }
                    }
                    dgvClientes.DataSource = clientesBusqueda;
                }
                else if (cbBuscarPor.Text == "Correo")
                {
                    foreach (var cliente in clientes)
                    {
                        if (cliente.Correo.Contains(txtBuscar.Text))
                        {
                            clientesBusqueda.Add(cliente);
                        }
                    }
                    dgvClientes.DataSource = clientesBusqueda;
                }
            }
            else
            {
                CargarDatosClientes();
            }
        }

        private void btnLimpiarBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = string.Empty;
            CargarDatosClientes();
        }
    }
}
