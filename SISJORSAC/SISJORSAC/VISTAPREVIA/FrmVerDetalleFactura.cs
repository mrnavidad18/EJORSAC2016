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
    public partial class FrmVerDetalleFactura : Form
    {
        public string nroFacturea { get; set; }
        public FrmVerDetalleFactura()
        {
            InitializeComponent();
        }

        private void FrmVerDetalleFactura_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'ConjuntoDatos.SP_IMPRIMIR_FACTURA' Puede moverla o quitarla según sea necesario.
            this.SP_IMPRIMIR_FACTURATableAdapter.Fill(this.ConjuntoDatos.SP_IMPRIMIR_FACTURA, nroFacturea);

            this.reportViewer1.RefreshReport();
        }
    }
}
