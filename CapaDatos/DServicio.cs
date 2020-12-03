using System;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DServicio
    {

        private int _idServicio;
        private int _idTrabajador;
        private int _idCliente;
        private string _Tipo;
        private DateTime _Fecha;
        private DateTime _Hora;
        private decimal _Precio;

        public int IdServicio { get => _idServicio; set => _idServicio = value; }
        public int IdTrabajador { get => _idTrabajador; set => _idTrabajador = value; }
        public int IdCliente { get => _idCliente; set => _idCliente = value; }
        public string Tipo { get => _Tipo; set => _Tipo = value; }
        public decimal Precio { get => _Precio; set => _Precio = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public DateTime Hora { get => _Hora; set => _Hora = value; }

        public DServicio()
        {

        }

        public DServicio(int idservicio, int idtrabajador, int idcliente, string tipo, DateTime fecha,DateTime hora,
            decimal precio)
        {
            this.IdServicio = idservicio;
            this.IdTrabajador = idtrabajador;
            this.IdCliente = idcliente;
            this.Tipo = tipo;
            this.Fecha = fecha;
            this.Hora = hora;
            this.Precio = precio;
        }

        public string Insertar(DServicio servicio)
        {


            string rpta = string.Empty;
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;
                SqlCn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_A_TABLA_SERVICIO";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paridServicio = new SqlParameter();
                paridServicio.ParameterName = "@idservicio";
                paridServicio.SqlDbType = SqlDbType.Int;
                paridServicio.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paridServicio);

                SqlParameter paridTrabajador = new SqlParameter();
                paridTrabajador.ParameterName = "@idtrabajador";
                paridTrabajador.SqlDbType = SqlDbType.Int;
                paridTrabajador.Value = servicio.IdTrabajador;
                cmd.Parameters.Add(paridTrabajador);

                SqlParameter paridCliente = new SqlParameter();
                paridCliente.ParameterName = "@idcliente";
                paridCliente.SqlDbType = SqlDbType.Int;
                paridCliente.Value = servicio.IdCliente;
                cmd.Parameters.Add(paridCliente);

                SqlParameter parTipo = new SqlParameter();
                parTipo.ParameterName = "@tipo";
                parTipo.SqlDbType = SqlDbType.VarChar;
                parTipo.Size = 20;
                parTipo.Value = servicio.Tipo;
                cmd.Parameters.Add(parTipo);

                SqlParameter parFecha = new SqlParameter();
                parFecha.ParameterName = "@fecha";
                parFecha.SqlDbType = SqlDbType.DateTime;
                parFecha.Value = servicio.Fecha;
                cmd.Parameters.Add(parFecha);

                SqlParameter parHora = new SqlParameter();
                parHora.ParameterName = "@hora";
                parHora.SqlDbType = SqlDbType.DateTime;
                parHora.Value = servicio.Fecha;
                cmd.Parameters.Add(parHora);

                SqlParameter parPrecio = new SqlParameter();
                parPrecio.ParameterName = "@precio";
                parPrecio.SqlDbType = SqlDbType.Money;
                parPrecio.Value = servicio.Precio;
                cmd.Parameters.Add(parPrecio);


                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingresó el registro";



            }
            catch (Exception ex)
            {
                rpta = ex.Message;

            }
            finally
            {
                if (SqlCn.State == ConnectionState.Open)
                {
                    SqlCn.Close();
                }
            }

            return rpta;
        }


        //MÉTODO MODIFICAR
        public string Modificar(DServicio servicio)
        {
            string rpta = string.Empty;
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;
                SqlCn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_M_TABLA_SERVICIO";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paridServicio = new SqlParameter();
                paridServicio.ParameterName = "@idservicio";
                paridServicio.SqlDbType = SqlDbType.Int;
                paridServicio.Value = servicio.IdServicio;
                cmd.Parameters.Add(paridServicio);


                SqlParameter paridTrabajador = new SqlParameter();
                paridTrabajador.ParameterName = "@idtrabajador";
                paridTrabajador.SqlDbType = SqlDbType.Int;
                paridTrabajador.Value = servicio.IdTrabajador;
                cmd.Parameters.Add(paridTrabajador);

                SqlParameter paridCliente = new SqlParameter();
                paridCliente.ParameterName = "@idcliente";
                paridCliente.SqlDbType = SqlDbType.Int;
                paridCliente.Value = servicio.IdCliente;
                cmd.Parameters.Add(paridCliente);

                SqlParameter parTipo = new SqlParameter();
                parTipo.ParameterName = "@tipo";
                parTipo.SqlDbType = SqlDbType.VarChar;
                parTipo.Size = 20;
                parTipo.Value = servicio.Tipo;
                cmd.Parameters.Add(parTipo);

                SqlParameter parFecha = new SqlParameter();
                parFecha.ParameterName = "@fecha";
                parFecha.SqlDbType = SqlDbType.DateTime;
                parFecha.Value = servicio.Fecha;
                cmd.Parameters.Add(parFecha);

                SqlParameter parHora = new SqlParameter();
                parHora.ParameterName = "@hora";
                parHora.SqlDbType = SqlDbType.DateTime;
                parHora.Value = servicio.Fecha;
                cmd.Parameters.Add(parHora);

                SqlParameter parPrecio = new SqlParameter();
                parPrecio.ParameterName = "@precio";
                parPrecio.SqlDbType = SqlDbType.Money;
                parPrecio.Value = servicio.Precio;
                cmd.Parameters.Add(parPrecio);



                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se modificó el registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCn.State == ConnectionState.Open)
                {
                    SqlCn.Close();
                }
            }

            return rpta;
        }

        //MÉTODO ELIMINAR
        public string Eliminar(DServicio servicio)
        {
            string rpta = string.Empty;
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;
                SqlCn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_E_TABLA_SERVICIO";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paridServicio = new SqlParameter();
                paridServicio.ParameterName = "@idservicio";
                paridServicio.SqlDbType = SqlDbType.Int;
                paridServicio.Value = servicio.IdServicio;
                cmd.Parameters.Add(paridServicio);


                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se eliminó el registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCn.State == ConnectionState.Open)
                {
                    SqlCn.Close();
                }
            }

            return rpta;

        }


        //MÉTODO CONSULTAR
        public DataTable Consultar()
        {

            DataTable DtResultado = new DataTable("tblServicio");
            SqlConnection SqlCn = new SqlConnection();

            try
            {
                SqlCn.ConnectionString = Conexion.Cn;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = SqlCn;
                cmd.CommandText = "SP_C_TABLA_SERVICIO";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter Dat = new SqlDataAdapter(cmd);
                Dat.Fill(DtResultado);

            }
            catch (Exception ex)
            {

                DtResultado = null;
            }

            return DtResultado;

        }
    }
}
