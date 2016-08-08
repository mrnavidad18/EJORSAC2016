using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISJORSAC
{
    public partial class FrnReporFacturas : Form
    {
        public DateTime fechaDe { get; set; }
        public DateTime fechaHasta { get; set; }
        public FrnReporFacturas()
        {
            InitializeComponent();
        }

        private void FrnReporFacturas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'ConjuntoDatos.SP_REPORTE_FACTURAS' Puede moverla o quitarla según sea necesario.
            this.SP_REPORTE_FACTURASTableAdapter.Fill(this.ConjuntoDatos.SP_REPORTE_FACTURAS,fechaDe,fechaHasta);

            this.reportViewer1.RefreshReport();
        }
    }
}
