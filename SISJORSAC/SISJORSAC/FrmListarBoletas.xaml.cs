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
using SISJORSAC.DATA.Modelo;

namespace SISJORSAC
{
    /// <summary>
    /// Lógica de interacción para FrmListarBoletas.xaml
    /// </summary>
    public partial class FrmListarBoletas : MetroWindow
    {
        BoletaDAO boletaDao = new BoletaDAO();
        public FrmListarBoletas()
        {
            InitializeComponent();
            ListarBoletas();
        }

        private void ListarBoletas()
        {


            var lista = boletaDao.ListarBoletasConClientes("ACTIVO");

            this.dgvListado.ItemsSource = lista;
        }

        private void txtNroComp_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox t = (TextBox)sender;
                string nroBoleta = t.Text;
                var lista = boletaDao.BuscarBoletasNroBoleta(nroBoleta);
                this.dgvListado.ItemsSource = null;
                this.dgvListado.ItemsSource = lista;
            }
        }

        private void btnVerDetalle_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
