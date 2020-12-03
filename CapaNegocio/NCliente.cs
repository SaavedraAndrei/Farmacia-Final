using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NCliente
    {

        //MÉTODO DE INSERTAR CLIENTE
        public static string Insertar(string nombre, string apellidos, string sexo, DateTime fecha_nac,
            string tipo_doc, string num_doc, string direccion, string telefono, string email)
        {
            DCliente cliente = new DCliente();
            cliente.Nombre = nombre;
            cliente.Apellidos = apellidos;
            cliente.Sexo = sexo;
            cliente.Fecha_Nac = fecha_nac;
            cliente.Tipo_Doc = tipo_doc;
            cliente.Num_Doc = num_doc;
            cliente.Direccion = direccion;
            cliente.Telefono = telefono;
            cliente.Email = email;

            return cliente.Insertar(cliente);
        }

        //MÉTODO DE MODIFICAR CLIENTE
        public static string Modificar(int idcliente, string nombre, string apellidos, string sexo, DateTime fecha_nac,
            string tipo_doc, string num_doc, string direccion, string telefono, string email)
        {
            DCliente cliente = new DCliente();
            cliente.IdCliente = idcliente;
            cliente.Nombre = nombre;
            cliente.Apellidos = apellidos;
            cliente.Sexo = sexo;
            cliente.Fecha_Nac = fecha_nac;
            cliente.Tipo_Doc = tipo_doc;
            cliente.Num_Doc = num_doc;
            cliente.Direccion = direccion;
            cliente.Telefono = telefono;
            cliente.Email = email;

            return cliente.Modificar(cliente);
        }

        //MÉTODO DE ELIMINAR CLIENTE
        public static string Eliminar(int idcliente)
        {
            DCliente cliente = new DCliente();
            cliente.IdCliente = idcliente;

            return cliente.Eliminar(cliente);
        }

        //MÉTODO DE CONSULTAR CLIENTE
        public static DataTable Consultar()
        {
            return new DCliente().Consultar();
        }
        //MÉTODO DE CONSULTAR APELLIDOS
        public static DataTable ConsultarApellidos(string textobuscar)
        {
            DCliente cliente = new DCliente();
            cliente.TextoBuscar = textobuscar;

            return cliente.ConsultarApellidos(cliente);
        }

        //MÉTODO DE CONSULTAR DOCUMENTOS
        public static DataTable ConsultarDocumento(string textobuscar)
        {
            DCliente cliente = new DCliente();
            cliente.TextoBuscar = textobuscar;

            return cliente.ConsultarDocumento(cliente);
        }

    }
}
