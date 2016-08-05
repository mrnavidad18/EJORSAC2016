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
    public partial class FrmVerDetalleGuia : Form
    {
        public string nroGuia { get; set; }
        public FrmVerDetalleGuia()
        {
            InitializeComponent();
        }

        private void FrmVerDetalleGuia_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'ConjuntoDatos.SP_TBL_GUIA_REMISION_IMPRIMIR' Puede moverla o quitarla según sea necesario.
            this.SP_TBL_GUIA_REMISION_IMPRIMIRTableAdapter.Fill(this.ConjuntoDatos.SP_TBL_GUIA_REMISION_IMPRIMIR, nroGuia);

            this.reportViewer1.RefreshReport();
        }
    }
}
