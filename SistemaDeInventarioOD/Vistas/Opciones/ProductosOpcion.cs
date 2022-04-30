using SistemaDeInventarioOD.Controller;
using SistemaDeInventarioOD.Datos;
using SistemaDeInventarioOD.Models;
using SistemaDeInventarioOD.Vistas.Opciones.Secundarias;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SistemaDeInventarioOD.Resources
{
    public partial class ProductosOpcion : Form
    {
        private Usuario usuario = new Usuario();
        private Almacen almacen = new Almacen();

        private List<Categoria> categorias = new List<Categoria>();

        private static List<Producto> productos = new List<Producto>();
        private List<Producto> productosBusqueda = new List<Producto>();

        public ProductosOpcion()
        {
            InitializeComponent();

            //Informacion a cargar
            CargarDatosProductos();

            CargarDatosCategorias();
        }
        public void DatosUsuario(dynamic usu)
        {
            usuario = usu;
        }
        private void CargarDatosProductos()
        {
            Administrador administrador = new Administrador();
            productos = administrador.VerProductos();

            dgvProductos.DataSource = productos;
        }
        private void CargarDatosCategorias()
        {
            DBDatos dBDatos = new DBDatos();

            categorias = dBDatos.TraerCategorias();

            foreach(var categoria in categorias)
            {
                cbBuscarCategoria.Items.Add(categoria.Descripcion);
                cbCategoria.Items.Add(categoria.Descripcion);
            }
            
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void panelSuperior_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProductosOpcion_Load(object sender, EventArgs e)
        {

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
                Producto producto = new Producto();

                producto.Codigo = txtCodigo.Text;
                producto.Descripcion = txtDescripcion.Text;

                foreach (var categoria in categorias)
                {
                    if (categoria.Descripcion == cbCategoria.Text)
                    {
                        producto.IdCategoria = categoria.IdCategoria;
                        break;
                    }
                }

                producto.IdAlmacen = almacen.IdAlmacen;

                Administrador administrador = new Administrador();

                string mensaje = "";// administrador.NuevoCliente(cliente);

                MessageBox.Show(mensaje);

                CargarDatosProductos();
            }
            else
            {
                MessageBox.Show("No tiene el nivel suficiente para hacer está Acción!");
            }
        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBuscarAlmacen_Click(object sender, EventArgs e)
        {
            BuscarAlmacenSecundaria buscarAlmacenSecundaria = new BuscarAlmacenSecundaria();

            buscarAlmacenSecundaria.ShowDialog();
        }
    }
}
