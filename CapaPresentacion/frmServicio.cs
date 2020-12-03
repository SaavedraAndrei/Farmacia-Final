using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmServicio : Form
    {


        //Si se va a registrar
        private bool IsNuevo = false;

        //Si se va a editar
        private bool IsEditar = false;

        public int IdTrabajador;

        public frmServicio()
        {
            InitializeComponent();
        }

        private static frmServicio _instancia;

        public static frmServicio GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new frmServicio();
            }

            return _instancia;
        }

        public void setCliente(string idcliente, string nombre)
        {
            this.txtidCliente.Text = idcliente;
            this.txtCliente.Text = nombre;
        }


        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            frmVistaClienteServicio vista = new frmVistaClienteServicio();
            vista.ShowDialog();

        }

        public void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar mensaje de Error
        public void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar los controles
        public void Limpiar()
        {
            this.txtidServicio.Text = string.Empty;
            this.txtPrecio.Text = string.Empty;
            this.txtidCliente.Text = string.Empty;
            this.txtCliente.Text = string.Empty;
            //OTRA OPCIÓN PARA IMAGEN Y PARA INGRESAR UN IMAGEN CUANDO SE LIMPIA ES: 
            //this.pxImagen.Image = global::CapaPresentacion.Properties.Resources.file:
            //file es el nombre de la imagen

        }

        //Habilitar los controles del formulario
        public void Habilitar(bool valor)
        {
            this.txtidServicio.ReadOnly = !valor;
            this.txtPrecio.ReadOnly = !valor;
            this.btnBuscarCategoria.Enabled = valor;
            this.cbTipo.Enabled = valor;
        }

        //Habilitar botones
        public void Botones()
        {
            if (IsNuevo || IsEditar)
            {
                Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }

        //Método ocultar Columnas
        public void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[5].Visible = false;

        }

        //Método Consultar
        public void Consultar()
        {
            this.dataListado.DataSource = NServicio.Consultar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(this.dataListado.Rows.Count);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Limpiar();
            this.Habilitar(true);
            this.Botones();
            this.txtidServicio.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = string.Empty;
                if (this.txtidServicio.Text == string.Empty || this.txtPrecio.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    this.ErrorIcono.SetError(txtidServicio, "Ingrese un valor");
                    this.ErrorIcono.SetError(txtPrecio, "Ingrese un valor");
                }
                else
                {


                    if (this.IsNuevo)
                    {
                        rpta = NServicio.Insertar(
                            this.IdTrabajador,
                            Convert.ToInt32(this.txtidCliente.Text.Trim().ToUpper()),
                            this.cbTipo.Text.Trim().ToUpper(),
                            this.dtFecha.Value,
                            Convert.ToDateTime(this.dtHora.Text),
                            Convert.ToDecimal(this.txtPrecio.Text.Trim()));
                    }
                    else if (this.IsEditar)
                    {
                        rpta = NServicio.Modificar(
                            Convert.ToInt32(this.txtidServicio.Text.Trim()),
                            this.IdTrabajador,
                            Convert.ToInt32(this.txtidCliente.Text.Trim().ToUpper()),
                            this.cbTipo.Text.Trim().ToUpper(),
                            this.dtFecha.Value,
                            this.dtHora.Value,
                            Convert.ToDecimal(this.txtPrecio.Text.Trim()));


                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se ingresó correctamente el registro");
                        }
                        else if (this.IsEditar)
                        {
                            this.MensajeOk("Se actualizó correctamente el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Consultar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtidServicio.Text != "")
            {
                this.IsEditar = true;
                this.Habilitar(true);
                this.Botones();
            }
            else
            {
                this.MensajeError("Debe seleccionar el registro a modificar");
                this.ErrorIcono.SetError(this.txtidServicio, "Debe seleccionar un registro");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Consultar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Realmente Desea Eliminar los Registros?", "Sistema de Ventas", MessageBoxButtons.OKCancel
                    , MessageBoxIcon.Question);

                if (opcion == DialogResult.OK)
                {
                    string Codigo;
                    string rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            rpta = NServicio.Eliminar(Convert.ToInt32(Codigo));

                            if (rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se eliminó correctamente");
                            }
                            else
                            {
                                this.MensajeError(rpta);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }

            this.Consultar();
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;

            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //PARA PODER MARCAR LOS CHECKBOX DE LA COLUMNA
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar =
                    (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];

                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtidServicio.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idServicio"].Value);
            this.txtCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Cliente"].Value);
            this.cbTipo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Tipo"].Value);
            this.dtFecha.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Fecha"].Value);
            //this.dtHora.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Hora"].Value);
            this.txtPrecio.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Precio"].Value);

            this.tabControl1.SelectedIndex = 1;
        }
    }
}
