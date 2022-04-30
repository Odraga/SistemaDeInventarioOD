using SistemaDeInventarioOD.Datos;
using SistemaDeInventarioOD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeInventarioOD.Controller
{
    class Administrador : DBDatosAdministrador
    {
        public List<Cliente> VerClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            clientes = TraerClientes();

            return clientes;
        }

        public List<Proveedor> VerProveedores()
        {
            List<Proveedor> proveedores = new List<Proveedor>();

            proveedores = TraerProveedores();

            return proveedores;
        }

        public List<Producto> VerProductos()
        {
            List<Producto> productos = new List<Producto>();

            productos = TraerProductos();

            return productos;
        }

        public List<Almacen> VerAlmacenes()
        {
            List<Almacen> almacenes = new List<Almacen>();

            almacenes = TraerAlmacenes();

            return almacenes;
        }

        public string NuevoCliente(Cliente cliente)
        {
            string Mensaje;

            if (string.IsNullOrEmpty(cliente.NombreCompleto) || string.IsNullOrEmpty(cliente.Identificacion) || string.IsNullOrEmpty(cliente.Telefono) || string.IsNullOrEmpty(cliente.Celular) || string.IsNullOrEmpty(cliente.Correo))
            {
                Mensaje = "Oops! hubo un problema al agregar el nuevo cliente!\nVerifique los campos.";
            }
            else
            {
                int resultado = AgregarCliente(cliente);
                if (resultado < 1)
                {
                    Mensaje = "Oops! hubo un problema al agregar el nuevo cliente!";
                }
                else
                {
                    Mensaje = "Se agrego el nuevo cliente con exito!";
                }
                
            }

            return Mensaje;
            
        }

        public string NuevoProveedor(Proveedor proveedor)
        {
            string Mensaje;

            if (string.IsNullOrEmpty(proveedor.NombreCompleto) || string.IsNullOrEmpty(proveedor.Identificacion) || string.IsNullOrEmpty(proveedor.Telefono) || string.IsNullOrEmpty(proveedor.Direccion) || string.IsNullOrEmpty(proveedor.Correo))
            {
                Mensaje = "Oops! hubo un problema al agregar el nuevo Proveedor!\nVerifique los campos.";
            }
            else
            {
                int resultado = AgregarProveedor(proveedor);

                if (resultado < 1)
                {
                    Mensaje = "Oops! hubo un problema al agregar el nuevo Proveedor!";
                }
                else
                {
                    Mensaje = "Se agrego el nuevo proveedor con exito!";
                }

            }

            return Mensaje;
        }

        public string NuevoProducto(Producto producto)
        {
            string Mensaje;

            if (string.IsNullOrEmpty(producto.Codigo) || string.IsNullOrEmpty(producto.Descripcion) || producto.IdCategoria < 1  || producto.IdAlmacen < 1)
            {
                Mensaje = "Oops! hubo un problema al agregar el nuevo Producto!\nVerifique los campos.";
            }
            else
            {
                int resultado = AgregarProducto(producto);

                if (resultado < 1)
                {
                    Mensaje = "Oops! hubo un problema al agregar el nuevo producto!";
                }
                else
                {
                    Mensaje = "Se agrego el nuevo producto con exito!";
                }

            }

            return Mensaje;
        }

    }
}
