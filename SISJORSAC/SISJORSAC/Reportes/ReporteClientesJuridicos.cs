using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

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
            
       
            // TODO: esta línea de código carga datos en la tabla 'dataSetPrincipal.SP_TBL_CLIENTE_LISTAR_REPORTE_JURIDICO' Puede moverla o quitarla según sea necesario.
            this.sP_TBL_CLIENTE_LISTAR_REPORTE_JURIDICOTableAdapter.Fill(this.dataSetPrincipal.SP_TBL_CLIENTE_LISTAR_REPORTE_JURIDICO);
            
            this.reportViewer1.RefreshReport();
        }
    }
}
