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
    public partial class FrmReportContrato : Form
    {
        public DateTime FechaDe { get; set; }
        public DateTime FechaHasta { get; set; }
        public FrmReportContrato()
        {
            InitializeComponent();
        }

        private void FrmReportContrato_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'ConjuntoDatos.SP_TBL_CONTRATO_REPORTE' Puede moverla o quitarla según sea necesario.
            try
            {
                this.SP_TBL_CONTRATO_REPORTETableAdapter.Fill(this.ConjuntoDatos.SP_TBL_CONTRATO_REPORTE, FechaDe, FechaHasta);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception)
            {

                this.reportViewer1.RefreshReport();
            }
           
        }
    }
}
