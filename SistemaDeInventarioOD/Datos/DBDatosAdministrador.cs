﻿using MySql.Data.MySqlClient;
using SistemaDeInventarioOD.Controller;
using SistemaDeInventarioOD.Models;
using System.Collections.Generic;

namespace SistemaDeInventarioOD.Datos
{
    class DBDatosAdministrador
    {
        private const string conexion = "datasource = 127.0.0.1; port = 3306; username = root; password = root; database = inventario_od;";
        protected List<Cliente> TraerClientes()
        {
            MySqlDataReader reader;

            MySqlConnection conn = new MySqlConnection(conexion);

            conn.Open();

            string query = "SELECT * FROM clientes;";

            MySqlCommand comando = new MySqlCommand(query, conn);

            reader = comando.ExecuteReader();

            List<Cliente> clientes = new List<Cliente>();

            while (reader.Read())
            {
                clientes.Add(new Cliente()
                {
                    IdCliente = (int)reader["id_clientes"],
                    NombreCompleto = reader["nombre_completo"].ToString(),
                    Identificacion = reader["identificacion"].ToString(),
                    Telefono = reader["telefono"].ToString(),
                    Celular = reader["celular"].ToString(),
                    Correo = reader["correo"].ToString()
                });
            }

            conn.Close();

            return clientes;
        }
        
        protected List<Proveedor> TraerProveedores()
        {
            MySqlDataReader reader;

            MySqlConnection conn = new MySqlConnection(conexion);

            conn.Open();

            string query = "SELECT * FROM proveedor;";

            MySqlCommand comando = new MySqlCommand(query, conn);

            reader = comando.ExecuteReader();

            List<Proveedor> proveedores = new List<Proveedor>();

            while (reader.Read())
            {
                proveedores.Add(new Proveedor()
                {
                    IdProveedor = (int)reader["id_proveedor"],
                    NombreCompleto = reader["nombre_completo"].ToString(),
                    Identificacion = reader["identificacion"].ToString(),
                    Telefono = reader["telefono"].ToString(),
                    Direccion = reader["direccion"].ToString(),
                    Correo = reader["correo"].ToString()
                });
            }

            conn.Close();

            return proveedores;
        }

        protected List<Producto> TraerProductos()
        {
            MySqlDataReader reader;

            MySqlConnection conn = new MySqlConnection(conexion);

            conn.Open();

            string query = "SELECT id_producto, id_categoria, (SELECT descripcion FROM categoria a WHERE id_categoria = producto.id_categoria) AS \"Categoria\"," +
                " id_almacen, (SELECT nombre_almacen FROM almacen WHERE id_almacen = producto.id_almacen) AS \"Almacen\", codigo, descripcion FROM producto;";

            MySqlCommand comando = new MySqlCommand(query, conn);

            reader = comando.ExecuteReader();

            List<Producto> productos = new List<Producto>();

            while (reader.Read())
            {
                productos.Add(new Producto()
                {
                    IdProducto = (int)reader["id_producto"],
                    IdCategoria = (int)reader["id_categoria"],
                    Categoria = reader["categoria"].ToString(),
                    IdAlmacen = (int)reader["id_almacen"],
                    Almacen = reader["almacen"].ToString(),
                    Codigo = reader["codigo"].ToString(),
                    Descripcion = reader["descripcion"].ToString()
                });
            }

            conn.Close();

            return productos;
        }

        protected int AgregarCliente(Cliente cliente)
        {
            MySqlConnection conn = new MySqlConnection(conexion);

            conn.Open();

            string query = "INSERT INTO clientes (nombre_completo, identificacion, telefono, celular, correo) VALUE (@nombreCompleto, @identificacion, @telefono, @celular, @correo);";

            MySqlCommand comando = new MySqlCommand(query, conn);

            comando.Parameters.AddWithValue("@nombreCompleto", cliente.NombreCompleto);
            comando.Parameters.AddWithValue("@identificacion", cliente.Identificacion);
            comando.Parameters.AddWithValue("@telefono", cliente.Telefono);
            comando.Parameters.AddWithValue("@celular", cliente.Celular);
            comando.Parameters.AddWithValue("@correo", cliente.Correo);

            int resultado = comando.ExecuteNonQuery();

            conn.Close();

            return resultado;
        }

        protected int AgregarProveedor(Proveedor proveedor)
        {
            MySqlConnection conn = new MySqlConnection(conexion);

            conn.Open();

            string query = "INSERT INTO proveedor (nombre_completo, identificacion, telefono, direccion, correo) VALUE (@nombreCompleto, @identificacion, @telefono, @direccion, @correo);";

            MySqlCommand comando = new MySqlCommand(query, conn);

            comando.Parameters.AddWithValue("@nombreCompleto", proveedor.NombreCompleto);
            comando.Parameters.AddWithValue("@identificacion", proveedor.Identificacion);
            comando.Parameters.AddWithValue("@telefono", proveedor.Telefono);
            comando.Parameters.AddWithValue("@direccion", proveedor.Direccion);
            comando.Parameters.AddWithValue("@correo", proveedor.Correo);

            int resultado = comando.ExecuteNonQuery();

            conn.Close();

            return resultado;
        }

    }
}