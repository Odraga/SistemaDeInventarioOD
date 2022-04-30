using SistemaDeInventarioOD.Controller;
using SistemaDeInventarioOD.Models;
using SistemaDeInventarioOD.Vistas.Opciones.Secundarias;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SistemaDeInventarioOD.Vistas.Opciones
{
    public partial class ComprasOpcion : Form
    {
        private Proveedor proveedor = new Proveedor();
        private Producto producto = new Producto();
        private static List<FacturaCompra> facturaCompra = new List<FacturaCompra>();

        private static Usuario usuario = new Usuario();

        private float precioTotal = 0.00f;

        public ComprasOpcion()
        {
            InitializeComponent();

            txtFechaRegistro.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm", new CultureInfo("en-US"));
        }
        public void DatosUsuario(dynamic usu)
        {
            usuario = usu;
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

        private void ComprasOpcion_Load(object sender, EventArgs e)
        {
            
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            BuscarProveedorSecundaria buscarProveedorSecundaria = new BuscarProveedorSecundaria();

            if (buscarProveedorSecundaria.ShowDialog() == DialogResult.OK)
            {
                this.proveedor.IdProveedor = buscarProveedorSecundaria.IdProveedor;
                this.proveedor.NombreCompleto = buscarProveedorSecundaria.NombreProveedor;
                this.proveedor.Identificacion = buscarProveedorSecundaria.Identificacion;
                
                txtNombreProveedor.Text = buscarProveedorSecundaria.NombreProveedor;
                txtDocProveedor.Text = buscarProveedorSecundaria.Identificacion;
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            BuscarProductoSecundaria buscarProductoSecundaria = new BuscarProductoSecundaria();

            if (buscarProductoSecundaria.ShowDialog() == DialogResult.OK)
            {
                this.producto.IdProducto = buscarProductoSecundaria.IdProducto;
                this.producto.Codigo = buscarProductoSecundaria.Codigo;
                this.producto.Descripcion = buscarProductoSecundaria.Descripcion;

                txtCodigoProducto.Text = buscarProductoSecundaria.Codigo;
                txtDescripcionProducto.Text = buscarProductoSecundaria.Descripcion;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDocProveedor.Text) || string.IsNullOrEmpty(txtNombreProveedor.Text) || string.IsNullOrEmpty(txtCodigoProducto.Text) || string.IsNullOrEmpty(txtDescripcionProducto.Text) ||
                string.IsNullOrEmpty(txtPrecioCompra.Text) || string.IsNullOrEmpty(txtPrecioVenta.Text) || string.IsNullOrEmpty(txtNroDocumento.Text) || string.IsNullOrEmpty(txtFechaRegistro.Text))
            {
                MessageBox.Show("Por Favor verifique los campos.");
            }
            else{
                precioTotal += float.Parse(txtPrecioCompra.Text) * (int)nUDCantidadProductos.Value;
                lblTotalNumero.Text = precioTotal.ToString();

                FacturaCompra factura = new FacturaCompra();

                factura.IdProveedor = proveedor.IdProveedor;
                factura.Proveedor = proveedor.NombreCompleto;
                factura.IdProducto = producto.IdProducto;
                factura.NroDocumento = txtNroDocumento.Text;
                factura.FechaRegistro = txtFechaRegistro.Text;
                factura.Producto = producto.Descripcion;
                factura.PrecioCompra = float.Parse(txtPrecioCompra.Text);
                factura.PrecioVenta = float.Parse(txtPrecioVenta.Text);
                factura.CantidadProductos = (int)nUDCantidadProductos.Value;
                factura.PrecioTotal = float.Parse(txtPrecioCompra.Text) * (int)nUDCantidadProductos.Value;

                facturaCompra.Add(factura);

                dgvProductos.Rows.Clear();

                foreach (var facturaNueva in facturaCompra)
                {
                    dgvProductos.Rows.Add(
                        facturaNueva.NroDocumento,
                        facturaNueva.FechaRegistro,
                        facturaNueva.Proveedor,
                        facturaNueva.Producto,
                        facturaNueva.PrecioCompra,
                        facturaNueva.PrecioVenta,
                        facturaNueva.CantidadProductos,
                        facturaNueva.PrecioTotal);
                }
            }
            
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (usuario.IdNivelUsuario == 1)
            {
                Administrador administrador = new Administrador();

                string mensaje = administrador.NuevaCompra(facturaCompra);

                MessageBox.Show(mensaje);

                txtCodigoProducto.Clear();
                txtDescripcionProducto.Clear();
                txtDocProveedor.Clear();
                txtNombreProveedor.Clear();
                txtNroDocumento.Clear();
                txtPrecioCompra.Clear();
                txtPrecioVenta.Clear();

                facturaCompra.Clear();
                dgvProductos.Rows.Clear();
            }
            else
            {
                MessageBox.Show("No tiene el nivel suficiente para hacer está Acción!");
            }
        }
    }
}
