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
    public partial class FrmVerDetalleContrato : Form
    {
        public string nroContrato { get; set; }
        public FrmVerDetalleContrato()
        {
            InitializeComponent();
        }

        private void FrmVerDetalleContrato_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'ConjuntoDatos.SP_TBL_CONTRATO_IMPRIMIR' Puede moverla o quitarla según sea necesario.
            try
            {
                this.SP_TBL_CONTRATO_IMPRIMIRTableAdapter.Fill(this.ConjuntoDatos.SP_TBL_CONTRATO_IMPRIMIR, nroContrato);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception)
            {
                this.reportViewer1.RefreshReport();
            }
            
        }
    }
}
