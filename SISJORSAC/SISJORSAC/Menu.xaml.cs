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
using SISJORSAC.Reportes;

namespace SISJORSAC
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : MetroWindow
    {
        public Menu()
        {
            InitializeComponent();
        }

        private  void ItemFactura_Click(object sender, RoutedEventArgs e)
        {
            ElegirFactura _frmelegir = new ElegirFactura();
            _frmelegir.Owner = this;
            _frmelegir.ShowDialog();
        }

        private void ItemCliente_Click(object sender, RoutedEventArgs e)
        {
            FRTipoCliente frmtipoclienteReport = new FRTipoCliente();
            frmtipoclienteReport.Owner = this;
            frmtipoclienteReport.ShowDialog();
        }



        private void ItemGuiaRemision_Click(object sender, RoutedEventArgs e)
        {
            FrmGuiaRemision FrmGuiaRemision = new FrmGuiaRemision();
            FrmGuiaRemision.Owner = this;
            FrmGuiaRemision.ShowDialog();
        }

        private void ItemClienteRegistro_Click(object sender, RoutedEventArgs e)
        {
            FrmClienteRegistro frmCliente = new FrmClienteRegistro();
            frmCliente.ShowDialog();            
        }

        private void ItemServicioRegistro_Click(object sender, RoutedEventArgs e)
        {
            FrmServicioRegistro frmServicio = new FrmServicioRegistro();
            frmServicio.ShowDialog();
        }

        private void ItemProveedor_Click(object sender, RoutedEventArgs e)
        {
            FrmProveedor frmProveedor = new FrmProveedor();
            frmProveedor.ShowDialog();
        }

        private void ItemMiCuenta_Click(object sender, RoutedEventArgs e)
        {
            FrmUsuarioDatos frmUsuarioCambiarInfor = new FrmUsuarioDatos();
            frmUsuarioCambiarInfor.ShowDialog();
        }

        private void ItemBoleta_Click(object sender, RoutedEventArgs e)
        {
            FrmElegirBoleta boleta = new FrmElegirBoleta();
          
            boleta.ShowDialog();
            
        }

        private void ItemContrato_Click(object sender, RoutedEventArgs e)
        {
            FrmContratoAlquiler contrato = new FrmContratoAlquiler();
            contrato.ShowDialog();
        }

        private void ItemConceptoGastoRegistro_Click(object sender, RoutedEventArgs e)
        {
            FrmConceptoGasto frmConceptoGastoRegistro = new FrmConceptoGasto();
            frmConceptoGastoRegistro.ShowDialog();

        }

        private void itemListadoCliente_Click(object sender, RoutedEventArgs e)
        {
            FrmListadoClientes frmListadoClientes = new FrmListadoClientes();
            frmListadoClientes.ShowDialog();

        }

        private void itemListadoFacturas_Click(object sender, RoutedEventArgs e)
        {
            FrmListadoFacturas listadoFactura = new FrmListadoFacturas();
            listadoFactura.ShowDialog();
        }

        private void itemListadoProveedores_Click(object sender, RoutedEventArgs e)
        {
            FrmListadoProveedor frmlistadoProveedor = new FrmListadoProveedor();
            frmlistadoProveedor.ShowDialog();
        }

        private void itemServicios_Click(object sender, RoutedEventArgs e)
        {

            FrmListadoServicios frmlistadoServicios = new FrmListadoServicios();
            frmlistadoServicios.ShowDialog();
        }

        private void itemConceptoGasto_Click(object sender, RoutedEventArgs e)
        {
            FrmListadoConceptoGasto frmlistadoConceptoGasto = new FrmListadoConceptoGasto();
            frmlistadoConceptoGasto.ShowDialog();
        }

        private void itemGasto_Click(object sender, RoutedEventArgs e)
        {
            FrmGasto frmGasto = new FrmGasto();
            frmGasto.ShowDialog();
        }

        private void itemListadoBoletas_Click(object sender, RoutedEventArgs e)
        {
            FrmListarBoletas  listaboleta = new FrmListarBoletas();
            listaboleta.ShowDialog();
        }

        private void itemListadoGuias_Click(object sender, RoutedEventArgs e)
        {
            FrmListadoGuiasRemision frmlistadoGUiaRemision = new FrmListadoGuiasRemision();
            frmlistadoGUiaRemision.ShowDialog();
        }

        private void itemlistadoContrato_Click(object sender, RoutedEventArgs e)
        {
            FrmListadoContrato frmListadoContrato = new FrmListadoContrato();
            frmListadoContrato.ShowDialog();
        }

        private void itemListadoGasto_Click(object sender, RoutedEventArgs e)
        {
            FrmListadoGasto frmListadoGastos = new FrmListadoGasto();
            frmListadoGastos.ShowDialog();
        }

        private void ItemReporteFactura_Click(object sender, RoutedEventArgs e)
        {
            FrmReporteFacturas reporte = new FrmReporteFacturas();
            reporte.ShowDialog();
        }

        private void itemChoferRegistro_Click(object sender, RoutedEventArgs e)
        {
            FrmChoferRegistro FormularioChoferRegisttttro = new FrmChoferRegistro();
            FormularioChoferRegisttttro.ShowDialog();
        }

        private void itemListadoChofer_Click(object sender, RoutedEventArgs e)
        {
            FrmListadoChoferes listadoChoferes = new FrmListadoChoferes();
            listadoChoferes.ShowDialog();
        }

      

       

 






    }
}
