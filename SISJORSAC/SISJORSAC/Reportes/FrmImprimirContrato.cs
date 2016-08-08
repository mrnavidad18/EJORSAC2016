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
    public partial class FrmImprimirContrato : Form
    {
        public string nroContrato { get; set; }
        public FrmImprimirContrato()
        {
            InitializeComponent();
        }

        private void FrmImprimirContrato_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'ConjuntoDatos.SP_TBL_CONTRATO_IMPRIMIR_2' Puede moverla o quitarla según sea necesario.
            this.SP_TBL_CONTRATO_IMPRIMIR_2TableAdapter.Fill(this.ConjuntoDatos.SP_TBL_CONTRATO_IMPRIMIR_2, nroContrato);

            this.reportViewer1.RefreshReport();
        }
    }
}
