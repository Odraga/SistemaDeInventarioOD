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
    public partial class ConfiguracionOpcion : Form
    {
        private static Usuario usuario = new Usuario();
        private List<Categoria> categorias = new List<Categoria>();
        private Categoria categoria = new Categoria();
        private List<Almacen> almacenes = new List<Almacen>();

        public ConfiguracionOpcion()
        {
            InitializeComponent();
            CargarDatosCategorias();
            CargarDatosAlmacenes();
        }

        public void DatosUsuario(dynamic usu)
        {
            usuario = usu;
        }
        private void CargarDatosCategorias()
        {
            DBDatos dBDatos = new DBDatos();

            categorias = dBDatos.TraerCategorias();

            foreach (var categoria in categorias)
            {
                cbCategorias.Items.Add(categoria.Descripcion);
            }

        }
        private void CargarDatosAlmacenes()
        {
            Administrador administrador = new Administrador();
            almacenes = administrador.VerAlmacenes();

            foreach (var almacen in almacenes)
            {
                cbAlmacenes.Items.Add(almacen.nombre_almacen);

            }
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

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            DBDatos dBDatos = new DBDatos();
            categoria.Descripcion = txtCategoria.Text;

            int resultado = dBDatos.NuevaCategoria(categoria);

            if (resultado < 1)
            {
                MessageBox.Show("Oops! hubo un problema al agregar la nueva categoria!");
            }
            else
            {
                MessageBox.Show("Se agrego la nueva categoria con exito!");
                txtCategoria.Clear();
                cbCategorias.Items.Clear();
                CargarDatosCategorias();
            }
        }

        private void btnAgregarAlmacen_Click(object sender, EventArgs e)
        {
            
            if (usuario.IdNivelUsuario == 1)
            {
                Almacen nuevoAlmacen = new Almacen();


                nuevoAlmacen.nombre_almacen = txtAlmacen.Text;

                Administrador administrador = new Administrador();

                string mensaje = administrador.NuevoAlmacen(nuevoAlmacen);

                MessageBox.Show(mensaje);

                txtAlmacen.Clear();
                cbAlmacenes.Items.Clear();

                CargarDatosAlmacenes();
            }
            else
            {
                MessageBox.Show("No tiene el nivel suficiente para hacer está Acción!");
            }
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            if (usuario.IdNivelUsuario == 1)
            {
                Usuario nuevoUsuario = new Usuario();


                nuevoUsuario.NombreCompleto = txtNombreCompleto.Text;
                nuevoUsuario.Identificacion = txtIdentificacion.Text;
                nuevoUsuario.Clave = txtClave.Text;
                nuevoUsuario.IdNivelUsuario = rbAdministrador.Checked == true ? 1 : 2;
                nuevoUsuario.NombreUsuario = txtNombreUsuario.Text;

                Administrador administrador = new Administrador();

                string mensaje = administrador.NuevoUsuario(nuevoUsuario);

                MessageBox.Show(mensaje);

                txtNombreCompleto.Clear();
                txtIdentificacion.Clear();
                txtClave.Clear();
                txtNombreUsuario.Clear();
            }
            else
            {
                MessageBox.Show("No tiene el nivel suficiente para hacer está Acción!");
            }
        }
    }
}
