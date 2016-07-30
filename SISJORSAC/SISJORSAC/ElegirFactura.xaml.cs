using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using SISJORSAC.DATA.DAO;

namespace SISJORSAC
{
    /// <summary>
    /// Lógica de interacción para ElegirFactura.xaml
    /// </summary>
    public partial class ElegirFactura : MetroWindow
    {
        public string nroGuia;

        public ElegirFactura()
        {
            InitializeComponent();
        }

        private void rbtConGuia_Checked(object sender, RoutedEventArgs e)
        {
            this.txtnroGuia.Visibility = Visibility.Visible;
            this.btnIngresar.Visibility = Visibility.Visible;
        }

        private async void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            string nroGuia = this.txtnroGuia.Text;
            if (nroGuia.Trim() != "")
            {
                GuiaRemisionDAO guiaDao = new GuiaRemisionDAO();
                var guia = guiaDao.ObtenerGuiaRemisionXNroGuia(nroGuia);
                if (guia != null)
                {
                    VariablesGlobales.NRO_GUIA_GLOBAL = nroGuia;
                    frmFactura factura = new frmFactura();
                    this.Close();
                    factura.Show();
                }
                else
                {
                    await this.ShowMessageAsync("Error", "Guia no encontrada");
                }
               
            }
            else
            {
                await this.ShowMessageAsync("Error","ingrese Nro. Guia");
            }

           
        }

        private void rbtSinGuia_Checked(object sender, RoutedEventArgs e)
        {
            VariablesGlobales.NRO_GUIA_GLOBAL = "";
            frmFactura factura = new frmFactura();
            this.Close();
            factura.Show();
        }
    }
}
