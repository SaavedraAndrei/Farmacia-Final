using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NTrabajador
    {

        //MÉTODO INSERTAR INGRESO Y DETALLE DE INGRESO
        public static string Insertar(string nombre, string apellidos, string sexo, DateTime fecha_nac,
            string num_doc, string direccion, string telefono, string email,string acceso,string usuario,string password)
        {
            DTrabajador trabajador = new DTrabajador();
            trabajador.Nombre = nombre;
            trabajador.Apellidos = apellidos;
            trabajador.Sexo = sexo;
            trabajador.Fecha_Nac = fecha_nac;
            trabajador.Num_Documento = num_doc;
            trabajador.Direccion = direccion;
            trabajador.Telefono = telefono;
            trabajador.Email = email;
            trabajador.Acceso = acceso;
            trabajador.Usuario = usuario;
            trabajador.Password = password;

            return trabajador.Insertar(trabajador);
        }

        //MÉTODO MODIFICAR
        public static string Modificar(int idtrabajador,string nombre, string apellidos, string sexo, DateTime fecha_nac,
            string num_doc, string direccion, string telefono, string email, string acceso, string usuario, string password)
        {
            DTrabajador trabajador = new DTrabajador();
            trabajador.IdTrabajador = idtrabajador;
            trabajador.Nombre = nombre;
            trabajador.Apellidos = apellidos;
            trabajador.Sexo = sexo;
            trabajador.Fecha_Nac = fecha_nac;
            trabajador.Num_Documento = num_doc;
            trabajador.Direccion = direccion;
            trabajador.Telefono = telefono;
            trabajador.Email = email;
            trabajador.Acceso = acceso;
            trabajador.Usuario = usuario;
            trabajador.Password = password;

            return trabajador.Modificar(trabajador);
        }

        //MÉTODO ELIMINAR
        public static string Eliminar(int idtrabajador)
        {
            DTrabajador trabajador = new DTrabajador();
            trabajador.IdTrabajador = idtrabajador;

            return trabajador.Eliminar(trabajador);
        }

        //MÉTODO  CONSULTAR
        public static DataTable Consultar()
        {
            return new DTrabajador().Consultar();
        }

        //MÉTODO CONSULTAR APELLIDOS
        public static DataTable ConsultarApellidos(string textobuscar)
        {
            DTrabajador trabajador = new DTrabajador();
            trabajador.TextoBuscar = textobuscar;

            return trabajador.ConsultarApellidos(trabajador);
        }

        //MÉTODO CONSULTAR DOCUMENTOS
        public static DataTable ConsultarDocumento(string textobuscar)
        {
            DTrabajador trabajador = new DTrabajador();
            trabajador.TextoBuscar = textobuscar;

            return trabajador.ConsultarDocumento(trabajador);
        }

        //MÉTODO CONSULTAR LOGIN
        public static DataTable Login(string usuario,string password)
        {
            DTrabajador trabajador = new DTrabajador();
            trabajador.Usuario = usuario;
            trabajador.Password = password;

            return trabajador.Login(trabajador);
        }


    }
}
