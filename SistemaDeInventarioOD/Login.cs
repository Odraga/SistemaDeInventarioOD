using SistemaDeInventarioOD.Controller;
using SistemaDeInventarioOD.Models;
using System;
using System.Windows.Forms;

namespace SistemaDeInventarioOD
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void lblInicioSesion_Click(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            Loguear loguear = new Loguear();
            usuario = loguear.Logueando(txtUsuario.Text, txtContrasenia.Text);

            if (usuario.ContieneDatos)
            {
                MenuPrincipal menuPrincipal = new MenuPrincipal();
                menuPrincipal.NuevoLogueo(usuario);
                menuPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("¡Ocurrio un error al intentar Iniciar Sesion!\nVerifique su Usuario u Contraseña.");
            }
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
