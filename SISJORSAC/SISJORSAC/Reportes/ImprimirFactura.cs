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
    public partial class ImprimirFactura : Form
    {
        public string nro_factura { get; set; }
        public ImprimirFactura()
        {
            InitializeComponent();
        }
        private void AutoPrint()
        {
            AutoPrintCls autoprintme = new AutoPrintCls(reportViewer1.LocalReport);
            autoprintme.Print();
        }


        private void ImprimirFactura_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: esta línea de código carga datos en la tabla 'ConjuntoDatos.SP_IMPRIMIR_FACTURA' Puede moverla o quitarla según sea necesario.
                this.SP_IMPRIMIR_FACTURATableAdapter.Fill(this.ConjuntoDatos.SP_IMPRIMIR_FACTURA, nro_factura);
                AutoPrint();
                this.reportViewer1.RefreshReport();
            }
            catch (Exception)
            {
                this.reportViewer1.RefreshReport();                
            }
           
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
