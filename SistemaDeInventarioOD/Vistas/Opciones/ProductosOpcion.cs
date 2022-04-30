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
        private List<Almacen> almacenes = new List<Almacen>();

        private static List<Producto> productos = new List<Producto>();
        private List<Producto> productosBusqueda = new List<Producto>();


        public ProductosOpcion()
        {
            InitializeComponent();

            //Informacion a cargar
            CargarDatosProductos();

            CargarDatosCategorias();

            CargarDatosAlmacenes();
        }
        public void DatosUsuario(dynamic usu)
        {
            usuario = usu;
        }
        private void CargarDatosProductos()
        {
            Administrador administrador = new Administrador();
            productos = administrador.VerProductos();

            dgvProductos.Rows.Clear();

            foreach (var item in productos)
            {
                dgvProductos.Rows.Add(item.IdProducto,
                    item.Categoria,
                    item.Almacen,
                    item.Codigo,
                    item.Descripcion);
            }
            
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
        private void CargarDatosAlmacenes()
        {
            Administrador administrador = new Administrador();
            almacenes = administrador.VerAlmacenes();

            foreach(var almacen in almacenes)
            {
                cbBuscarAlmacen.Items.Add(almacen.nombre_almacen);

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

                string mensaje = administrador.NuevoProducto(producto);

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

            if (buscarAlmacenSecundaria.ShowDialog() == DialogResult.OK)
            {
                this.almacen.IdAlmacen = buscarAlmacenSecundaria.IdAlmacen;
                this.almacen.nombre_almacen = buscarAlmacenSecundaria.NombreAlmacen;

                txtAlmacen.Text = buscarAlmacenSecundaria.NombreAlmacen;
            }
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }
        /*
         * Codigo
            Categoria
            Almacen
         */
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            productosBusqueda.Clear();
            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                if (cbBuscarPor.Text == "Codigo")
                {
                    foreach (var producto in productos)
                    {
                        if (producto.Codigo.Contains(txtBuscar.Text))
                        {
                            productosBusqueda.Add(producto);
                        }
                        else if (producto.Codigo.Contains(txtBuscar.Text) && producto.Categoria.Contains(cbBuscarCategoria.Text))
                        {
                            productosBusqueda.Add(producto);
                        }
                        else if (producto.Codigo.Contains(txtBuscar.Text) && producto.Categoria.Contains(cbBuscarCategoria.Text) && producto.Almacen.Contains(cbBuscarAlmacen.Text))
                        {
                            productosBusqueda.Add(producto);
                        }
                    }
                    dgvProductos.Rows.Clear();
                    foreach (var item in productosBusqueda)
                    {
                        dgvProductos.Rows.Add(item.IdProducto,
                            item.Categoria,
                            item.Almacen,
                            item.Codigo,
                            item.Descripcion);
                    }
                }
                else if (cbBuscarPor.Text == "Categoria")
                {
                    if (string.IsNullOrEmpty(txtBuscar.Text))
                    {
                        foreach (var producto in productos)
                        {
                            if (producto.Categoria == cbBuscarCategoria.Text)
                            {
                                productosBusqueda.Add(producto);
                            }
                        }
                        dgvProductos.Rows.Clear();
                        foreach (var item in productosBusqueda)
                        {
                            dgvProductos.Rows.Add(item.IdProducto,
                                item.Categoria,
                                item.Almacen,
                                item.Codigo,
                                item.Descripcion);
                        }
                    }
                    else
                    {
                        foreach (var producto in productos)
                        {
                            if (producto.Categoria == cbBuscarCategoria.Text)
                            {
                                productosBusqueda.Add(producto);
                            }
                            else if(producto.Categoria == cbBuscarCategoria.Text && producto.Codigo.Contains(txtBuscar.Text))
                            {
                                productosBusqueda.Add(producto);
                            }
                            else if (producto.Categoria == cbBuscarCategoria.Text && producto.Descripcion.Contains(txtBuscar.Text))
                            {
                                productosBusqueda.Add(producto);
                            }
                        }
                        dgvProductos.Rows.Clear();
                        foreach (var item in productosBusqueda)
                        {
                            dgvProductos.Rows.Add(item.IdProducto,
                                item.Categoria,
                                item.Almacen,
                                item.Codigo,
                                item.Descripcion);
                        }
                    }
                }
                else if (cbBuscarPor.Text == "Almacen")
                {
                    foreach (var producto in productos)
                    {
                        if (producto.Almacen == cbBuscarAlmacen.Text && producto.Codigo.Contains(txtBuscar.Text))
                        {
                            productosBusqueda.Add(producto);
                        }
                        else if (producto.Almacen == cbBuscarAlmacen.Text && producto.Descripcion.Contains(txtBuscar.Text))
                        {
                            productosBusqueda.Add(producto);
                        }
                    }
                    dgvProductos.Rows.Clear();
                    foreach (var item in productosBusqueda)
                    {
                        dgvProductos.Rows.Add(item.IdProducto,
                            item.Categoria,
                            item.Almacen,
                            item.Codigo,
                            item.Descripcion);
                    }
                }
                else
                {
                    CargarDatosProductos();
                }
            }
        }

        private void btnLimpiarBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = string.Empty;
            CargarDatosProductos();
        }
    }
}
