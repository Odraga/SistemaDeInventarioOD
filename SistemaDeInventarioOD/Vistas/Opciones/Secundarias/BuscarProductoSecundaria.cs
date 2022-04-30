using SistemaDeInventarioOD.Controller;
using SistemaDeInventarioOD.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SistemaDeInventarioOD.Vistas.Opciones.Secundarias
{
    public partial class BuscarProductoSecundaria : Form
    {
        List<Producto> productos = new List<Producto>();
        List<Producto> productosBusqueda = new List<Producto>();

        public BuscarProductoSecundaria()
        {
            InitializeComponent();

            CargarProductos();
        }

        private void CargarProductos()
        {
            Administrador administrador = new Administrador();
            productos = administrador.VerProductos();

            dgvProductos.DataSource = productos;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            productosBusqueda.Clear();

            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {

                foreach (var proveedor in productos)
                {
                    if (proveedor.Codigo.Contains(txtBuscar.Text))
                    {
                        productosBusqueda.Add(proveedor);
                    }
                    else if (proveedor.Descripcion.Contains(txtBuscar.Text))
                    {
                        productosBusqueda.Add(proveedor);
                    }
                }

                dgvProductos.DataSource = productosBusqueda;
            }
        }

        private void btnLimpiarBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = string.Empty;

            CargarProductos();
        }

        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        private void dgvProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdProducto = (int)dgvProductos.CurrentRow.Cells[0].Value;
            Codigo = dgvProductos.CurrentRow.Cells[5].Value.ToString();
            Descripcion = dgvProductos.CurrentRow.Cells[6].Value.ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
