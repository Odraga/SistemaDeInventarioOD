﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeInventarioOD.Vistas.Opciones
{
    public partial class ComprasOpcion : Form
    {
        public ComprasOpcion()
        {
            InitializeComponent();
        }

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
