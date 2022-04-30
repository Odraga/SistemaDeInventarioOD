using SistemaDeInventarioOD.Models;
using SistemaDeInventarioOD.Resources;
using SistemaDeInventarioOD.Vistas.Opciones;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SistemaDeInventarioOD
{
    public partial class MenuPrincipal : Form
    {
        private static Usuario usuario = new Usuario();

        public MenuPrincipal()
        {
            InitializeComponent();
        }

        public void NuevoLogueo(dynamic usu)
        {
            usuario = usu;
            lblTitulo.Text = "Bienvenido "+ usuario.NombreCompleto;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btnProducto_Click(object sender, EventArgs e)
        {
            ProductosOpcion productosOpcion = new ProductosOpcion();
            productosOpcion.DatosUsuario(usuario);
            productosOpcion.ShowDialog();
        }

        

        private void btnCerrarSession_Click(object sender, EventArgs e)
        {
            Login login = new Login();

            login.Show();
            this.Close();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            ComprasOpcion comprasOpcion = new ComprasOpcion();
            comprasOpcion.ShowDialog();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
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

        private void btnInventario_Click(object sender, EventArgs e)
        {
            InventarioOpcion inventarioOpcion = new InventarioOpcion();
            inventarioOpcion.ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ClientesOpcion clientesOpcion = new ClientesOpcion();
            clientesOpcion.DatosUsuario(usuario);
            clientesOpcion.ShowDialog();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            ProveedoresOpcion proveedoresOpcion = new ProveedoresOpcion();
            proveedoresOpcion.DatosUsuario(usuario);
            proveedoresOpcion.ShowDialog();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            VentasOpcion ventasOpcion = new VentasOpcion();
            ventasOpcion.ShowDialog();
        }
    }
}
