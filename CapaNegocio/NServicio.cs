using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class NServicio
    {
        public static string Insertar(int idtrabajador, int idcliente, string tipo, DateTime fecha,DateTime hora,  decimal precio)
        {
            DServicio obj = new DServicio();
            obj.IdTrabajador =idtrabajador;
            obj.IdCliente= idcliente;
            obj.Tipo=tipo;
            obj.Fecha= fecha;
            obj.Hora = hora;
            obj.Precio= precio;

            return obj.Insertar(obj);
        }

        //Metodo modificar 
        public static string Modificar(int idservicio,int idtrabajador, int idcliente, string tipo, DateTime fecha, DateTime hora, decimal precio)
        {
            DServicio obj = new DServicio();
            obj.IdServicio = idservicio;
            obj.IdTrabajador = idtrabajador;
            obj.IdCliente = idcliente;
            obj.Tipo = tipo;
            obj.Fecha = fecha;
            obj.Hora = hora;
            obj.Precio = precio;

            return obj.Modificar(obj);
        }

        //Metodo Eliminar 
        public static string Eliminar(int idservicio)
        {
            DServicio obj = new DServicio();
            obj.IdServicio = idservicio;

            return obj.Eliminar(obj);
        }

        //Metodo consultar
        public static DataTable Consultar()
        {
            return new DServicio().Consultar();
        }

    }
}
