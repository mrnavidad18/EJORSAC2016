using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISJORSAC.Reportes
{
    public partial class Tipo_de_Clientes : Form
    {
        public Tipo_de_Clientes()
        {
            InitializeComponent();
        }

        private void btnReporteClientes_Click(object sender, EventArgs e)
        {
            ReporteClientesNaturales rn = new ReporteClientesNaturales();
            ReporteClientesJuridicos rj = new ReporteClientesJuridicos();

            int op = cboClienteReporte.SelectedIndex;
            if(op ==0){
                MessageBox.Show("Elija un Tipo Cliente");
            }

            if (op == 1)
            {
                rn.ShowDialog();
            }

            if (op == 2)
            {
                rj.ShowDialog();
            }
        }
    }
}
