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
    public partial class frmVistaClienteServicio : Form
    {
        public frmVistaClienteServicio()
        {
            InitializeComponent();
        }

        public void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
        }

        //Método Consultar
        public void Consultar()
        {
            this.dataListado.DataSource = NCliente.Consultar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(this.dataListado.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Consultar();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            frmServicio form = frmServicio.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["idCliente"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            form.setCliente(par1, par2);
            this.Hide();
        }

        private void frmVistaClienteServicio_Load(object sender, EventArgs e)
        {
            this.Consultar();
        }
    }
}
