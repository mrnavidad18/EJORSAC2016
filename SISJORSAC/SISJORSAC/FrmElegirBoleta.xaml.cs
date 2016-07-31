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
    /// Lógica de interacción para FrmElegirBoleta.xaml
    /// </summary>
    public partial class FrmElegirBoleta : MetroWindow
    {
        public FrmElegirBoleta()
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
                    VariablesGlobales.listaDetallesBoleta.Clear();
                    VariablesGlobales.ClickBoletaConGuia = true;
                    VariablesGlobales.NRO_GUIA_GLOBAL = nroGuia;
                    FrmBoleta boleta = new FrmBoleta();
                    this.Close();
                    boleta.ShowDialog();
                }
                else
                {
                    await this.ShowMessageAsync("Error", "Guia no encontrada");
                }

            }
            else
            {
                await this.ShowMessageAsync("Error", "ingrese Nro. Guia");
            }


        }

        private void rbtSinGuia_Checked(object sender, RoutedEventArgs e)
        {
            VariablesGlobales.listaDetallesBoleta.Clear();
            VariablesGlobales.NRO_GUIA_GLOBAL = "";
            VariablesGlobales.ClickBoletaConGuia = false;
            FrmBoleta boleta = new FrmBoleta();
            this.Close();
            boleta.ShowDialog();
        }
    }
}
