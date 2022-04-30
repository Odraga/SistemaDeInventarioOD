using MySql.Data.MySqlClient;
using SistemaDeInventarioOD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInventarioOD.Datos
{
    class DBDatos
    {
        private const string conexion = "datasource = 127.0.0.1; port = 3306; username = root; password = root; database = inventario_od;";

        public Usuario TraerUsuario(string nombreUsuario, string clave)
        {
            MySqlDataReader reader;

            MySqlConnection conn = new MySqlConnection(conexion);

            conn.Open();

            string query = "SELECT * FROM usuario WHERE nombre_usuario = @nombreUsuario AND clave = @clave";

            MySqlCommand comando = new MySqlCommand(query, conn);
            comando.Parameters.AddWithValue("@nombreusuario", nombreUsuario);
            comando.Parameters.AddWithValue("@clave", clave);

            reader = comando.ExecuteReader();

            Usuario usuario = new Usuario();

            if (reader.Read())
            {
                usuario.IdUsuario = (int)reader["id_usuario"];
                usuario.IdNivelUsuario = (int)reader["id_nivel_usuario"];
                usuario.NombreUsuario = reader["nombre_usuario"].ToString();
                usuario.NombreCompleto = reader["nombre_completo"].ToString();
                usuario.Identificacion = reader["identificacion"].ToString();
                usuario.Clave = reader["clave"].ToString();
                usuario.ContieneDatos = true;
            }

            conn.Close();

            return usuario;
        }

        public List<Categoria> TraerCategorias()
        {
            MySqlDataReader reader;

            MySqlConnection conn = new MySqlConnection(conexion);

            conn.Open();

            string query = "SELECT * FROM categoria;";

            MySqlCommand comando = new MySqlCommand(query, conn);

            reader = comando.ExecuteReader();

            List<Categoria> categorias = new List<Categoria>();

            while (reader.Read())
            {
                categorias.Add(new Categoria()
                {
                    IdCategoria = (int)reader["id_categoria"],
                    Descripcion = reader["descripcion"].ToString(),
                });
            }

            conn.Close();

            return categorias;
        }

        public int NuevaCategoria(Categoria categoria)
        {
            MySqlConnection conn = new MySqlConnection(conexion);

            conn.Open();

            string query = "INSERT INTO categoria (descripcion) VALUE (@descripcion);";

            MySqlCommand comando = new MySqlCommand(query, conn);

            comando.Parameters.AddWithValue("@descripcion", categoria.Descripcion);

            int resultado = comando.ExecuteNonQuery();

            conn.Close();

            return resultado;
        }

    }
}
