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
    public partial class ReporteClientesNaturales : Form
    {
        public ReporteClientesNaturales()
        {
            InitializeComponent();
        }

        private void ReporteClientes_Load(object sender, EventArgs e)
        {
            
            // TODO: esta línea de código carga datos en la tabla 'dataSetPrincipal.SP_TBL_CLIENTE_LISTAR_REPORTE_NATURAL' Puede moverla o quitarla según sea necesario.
            this.sP_TBL_CLIENTE_LISTAR_REPORTE_NATURALTableAdapter.Connection.ConnectionString = "server=192.168.0.31;DataBase=BDJORSAC;user=sa;password=Developer2016";
            
            this.sP_TBL_CLIENTE_LISTAR_REPORTE_NATURALTableAdapter.Fill(this.dataSetPrincipal.SP_TBL_CLIENTE_LISTAR_REPORTE_NATURAL);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_ReportRefresh(object sender, CancelEventArgs e)
        {
            this.sP_TBL_CLIENTE_LISTAR_REPORTE_NATURALTableAdapter.Connection.ConnectionString = "server=192.168.0.31;DataBase=BDJORSAC;user=sa;password=Developer2016";

            this.sP_TBL_CLIENTE_LISTAR_REPORTE_NATURALTableAdapter.Fill(this.dataSetPrincipal.SP_TBL_CLIENTE_LISTAR_REPORTE_NATURAL);
            this.reportViewer1.RefreshReport();
        }
    }
}
