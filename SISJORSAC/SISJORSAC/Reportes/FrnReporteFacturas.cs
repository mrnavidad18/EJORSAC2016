using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISJORSAC{
    public partial class FrnReporteFacturas : Form
    {
        public DateTime FechaDe { get; set; }
        public DateTime FechaHasta { get; set; }
        public FrnReporteFacturas()
        {
            InitializeComponent();
        }

        private void FrnReporteFacturas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'ConjuntoDatos.SP_TBL_FACTURA_BUSCAR_X_FECHAS' Puede moverla o quitarla según sea necesario.
            this.SP_TBL_FACTURA_BUSCAR_X_FECHASTableAdapter.Fill(this.ConjuntoDatos.SP_TBL_FACTURA_BUSCAR_X_FECHAS,FechaDe,FechaHasta);

            this.reportViewer1.RefreshReport();
        }
    }
}
