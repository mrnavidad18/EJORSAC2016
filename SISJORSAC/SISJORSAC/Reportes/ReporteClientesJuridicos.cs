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
    public partial class ReporteClientesJuridicos : Form
    {
        public ReporteClientesJuridicos()
        {
            InitializeComponent();
        }

        private void ReporteClientesJuridicos_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
