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
    public partial class FrmVerDetalleBoleta : Form
    {
        public string nroBoleta { get; set; }
        public FrmVerDetalleBoleta()
        {
            InitializeComponent();
        }

        private void FrmVerDetalleBoleta_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'ConjuntoDatos.SP_TBL_BOLETA_IMPRIMIR' Puede moverla o quitarla según sea necesario.
            try
            {
                this.SP_TBL_BOLETA_IMPRIMIRTableAdapter.Fill(this.ConjuntoDatos.SP_TBL_BOLETA_IMPRIMIR, nroBoleta);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception)
            {

                this.reportViewer1.RefreshReport();
            }
           
        }
    }
}
