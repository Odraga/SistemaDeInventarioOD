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
    public partial class BuscarAlmacenSecundaria : Form
    {
        List<Almacen> almacenes = new List<Almacen>();
        List<Almacen> almacenesBusqueda = new List<Almacen>();

        Almacen almacen = new Almacen();

        public BuscarAlmacenSecundaria()
        {
            InitializeComponent();

            CargarAlmacenes();
        }
        private void CargarAlmacenes()
        {
            Administrador administrador = new Administrador();
            almacenes = administrador.VerAlmacenes();

            dgvAlmacenes.DataSource = almacenes;
        }

        private void BuscarAlmacenSecundaria_Load(object sender, EventArgs e)
        {

        }

        public int IdAlmacen { get; set; }
        public string NombreAlmacen { get; set; }

        private void dgvAlmacenes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdAlmacen = (int)dgvAlmacenes.CurrentRow.Cells[0].Value;
            NombreAlmacen = dgvAlmacenes.CurrentRow.Cells[1].Value.ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnLimpiarBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = string.Empty;
            CargarAlmacenes();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            almacenesBusqueda.Clear();

            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {

                foreach (var almacen in almacenes)
                {
                    if (almacen.nombre_almacen.Contains(txtBuscar.Text))
                    {
                        almacenesBusqueda.Add(almacen);
                    }
                }

                dgvAlmacenes.DataSource = almacenesBusqueda;
            }
        }
    }
}
