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
    public partial class FrmReportGasto : Form
    {

        public DateTime FechaDe { get; set; }
        public DateTime FechaHasta { get; set; }
        public FrmReportGasto()
        {
            InitializeComponent();
        }

        private void FrmReportGasto_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'ConjuntoDatos.SP_REPORTE_GASTOS' Puede moverla o quitarla según sea necesario.
            try
            {
                this.SP_REPORTE_GASTOSTableAdapter.Fill(this.ConjuntoDatos.SP_REPORTE_GASTOS, FechaDe, FechaHasta);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception)
            {

                 this.reportViewer1.RefreshReport();
            }

        }
    }
}
