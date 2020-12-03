using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NPresentacion
    {
        //MÉTODO INSERTAR PRESENTACIONES
        public static string Insertar(string nombre, string descripcion)
        {
            DPresentacion dPresentacion = new DPresentacion();
            dPresentacion.Nombre = nombre;
            dPresentacion.Descripcion = descripcion;
            return dPresentacion.Insertar(dPresentacion);

        }


        //MÉTODO MODIFICAR PRESENTACIONES
        public static string Modificar(int idpresentacion, string nombre, string descripcion)
        {
            DPresentacion dPresentacion = new DPresentacion();
            dPresentacion.idPresentacion = idpresentacion;
            dPresentacion.Nombre = nombre;
            dPresentacion.Descripcion = descripcion;
            return dPresentacion.Modificar(dPresentacion);

        }

        //MÉTODO ELIMINAR PRESENTACIONES
        public static string Eliminar(int idpresentacion)
        {
            DPresentacion dPresentacion = new DPresentacion();
            dPresentacion.idPresentacion = idpresentacion;

            return dPresentacion.Eliminar(dPresentacion);
        }

        //MÉTODO CONSULTAR PRESENTACIONES
        public static DataTable Consultar()
        {
            return new DPresentacion().Consultar();
        }

        //MÉTODO CONSULTAR NOMBRE PRESENTACIONES
        public static DataTable ConsultarNombre(string textobuscar)
        {
            DPresentacion dPresentacion = new DPresentacion();
            dPresentacion.TextoBuscar = textobuscar;

            return dPresentacion.ConsultarNombre(dPresentacion);
        }

    }
}
