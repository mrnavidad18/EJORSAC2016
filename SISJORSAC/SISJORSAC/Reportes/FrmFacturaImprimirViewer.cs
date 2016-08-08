using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISJORSAC.Reportes
{
    public partial class FrmFacturaImprimirViewer : Form
    {
        public FrmFacturaImprimirViewer()
        {
            InitializeComponent();
            
        }
        public void ImprimirDirectamente()
        {
            string NombreImpresora = "";//Donde guardare el nombre de la impresora por defecto

            //Busco la impresora por defecto
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                PrinterSettings a = new PrinterSettings();
                a.PrinterName = PrinterSettings.InstalledPrinters[i].ToString();
                if (a.IsDefaultPrinter)
                {
                    NombreImpresora = PrinterSettings.InstalledPrinters[i].ToString();

                }
            }


            FacturaImprimir rpt = new FacturaImprimir();// Instancio el reporte


           
            rpt.PrintOptions.PrinterName = NombreImpresora;//Asigno la impresora
            rpt.PrintToPrinter(1, false, 0, 0);//Imprimo 2 copias
        }
    }
}
