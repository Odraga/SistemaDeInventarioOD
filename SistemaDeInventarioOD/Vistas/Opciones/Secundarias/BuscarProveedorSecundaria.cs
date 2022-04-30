using SistemaDeInventarioOD.Controller;
using SistemaDeInventarioOD.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SistemaDeInventarioOD.Vistas.Opciones.Secundarias
{
    public partial class BuscarProveedorSecundaria : Form
    {

        List<Proveedor> proveedores = new List<Proveedor>();
        List<Proveedor> proveedoresBusqueda = new List<Proveedor>();

        public BuscarProveedorSecundaria()
        {
            InitializeComponent();

            CargarProveedores();
        }
        private void CargarProveedores()
        {
            Administrador administrador = new Administrador();
            proveedores = administrador.VerProveedores();

            dgvProveedores.DataSource = proveedores;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            proveedoresBusqueda.Clear();

            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {

                foreach (var proveedor in proveedores)
                {
                    if (proveedor.NombreCompleto.Contains(txtBuscar.Text))
                    {
                        proveedoresBusqueda.Add(proveedor);
                    }
                    else if (proveedor.Identificacion.Contains(txtBuscar.Text))
                    {
                        proveedoresBusqueda.Add(proveedor);
                    }
                    else if (proveedor.Telefono.Contains(txtBuscar.Text))
                    {
                        proveedoresBusqueda.Add(proveedor);
                    }
                }

                dgvProveedores.DataSource = proveedoresBusqueda;
            }
        }

        public int IdProveedor { get; set; }
        public string Identificacion { get; set; }
        public string NombreProveedor { get; set; }

        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdProveedor = (int)dgvProveedores.CurrentRow.Cells[0].Value;
            NombreProveedor = dgvProveedores.CurrentRow.Cells[1].Value.ToString();
            Identificacion = dgvProveedores.CurrentRow.Cells[2].Value.ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnLimpiarBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = string.Empty;

            CargarProveedores();
        }
    }
}
