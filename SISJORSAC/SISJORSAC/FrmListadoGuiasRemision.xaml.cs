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
using SISJORSAC.DATA.Modelo;
using SISJORSAC.DATA.DAO;

namespace SISJORSAC
{
    /// <summary>
    /// Lógica de interacción para FrmListadoGuiasRemision.xaml
    /// </summary>
    public partial class FrmListadoGuiasRemision : MetroWindow
    {

        GuiaRemisionDAO guiaDAO = new GuiaRemisionDAO();
        public FrmListadoGuiasRemision()
        {
            InitializeComponent();
            txtBusqueda.Focus();
            ListarGuiaRemisionCparametros("", "DISPONIBLE");
        }
        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string p_busqueda = txtBusqueda.Text;
                dgvListadoGuia.Columns.Clear();
                ListarGuiaRemisionCparametros(p_busqueda, "DISPONIBLE");
            }

        }
        private void ListarGuiaRemisionCparametros(string p_Busqueda,string estado)
        {
            var listadoGuiaRemision = guiaDAO.listarGuiaRemision(p_Busqueda,estado);
            dgvListadoGuia.ItemsSource = listadoGuiaRemision;
            if (estado.Equals("DISPONIBLE"))
            {
                DataGridTextColumn columna = new DataGridTextColumn();               
                columna.Header = "Nº de Guia";
                columna.Binding = new Binding("NRO_GUIA");
                dgvListadoGuia.Columns.Add(columna);

                DataGridTextColumn columnaCli = new DataGridTextColumn();                
                columnaCli.Header = "Cliente-Nombres/Razón Social";
                columnaCli.Binding = new Binding("CLIENTEJURIDICONATURAL");
                dgvListadoGuia.Columns.Add(columnaCli);
               
                DataGridTextColumn columna2 = new DataGridTextColumn();
                columna2.Header = "Fecha de Emisión";
                columna2.HeaderStringFormat = "dd/MM/yyyy";
                columna2.Binding = new Binding("FECHA_EMISION");
                dgvListadoGuia.Columns.Add(columna2);

                DataGridTextColumn columna3 = new DataGridTextColumn();
                columna3.Header = "Punto de Partida";
                columna3.Binding = new Binding("PTO_PARTIDA");
                dgvListadoGuia.Columns.Add(columna3);

                DataGridTextColumn columna4 = new DataGridTextColumn();
                columna4.Header = "Punto de Llegada";
                columna4.Binding = new Binding("PTO_LLEGADA");
                dgvListadoGuia.Columns.Add(columna4);

                DataGridTextColumn columna5 = new DataGridTextColumn();
                columna5.Header = "Vehículo - Marca/ Placa";
                columna5.Binding = new Binding("VEHICULO_MARCA");
                dgvListadoGuia.Columns.Add(columna5);

                DataGridTextColumn columna6= new DataGridTextColumn();
                columna6.Header = "Nº de Certificado";
                columna6.Binding = new Binding("NRO_CERTIFICADO");
                dgvListadoGuia.Columns.Add(columna6);

                DataGridTextColumn columna7 = new DataGridTextColumn();
                columna7.Header = "Nombre del Conductor";
                columna7.Binding = new Binding("NONBRE_CONDUCTOR");
                dgvListadoGuia.Columns.Add(columna7);


                DataGridTextColumn columna8 = new DataGridTextColumn();
                columna8.Header = "Nº de Brevete";
                columna8.Binding = new Binding("NRO_BREVETE");
                dgvListadoGuia.Columns.Add(columna8);


                DataGridTextColumn columna9 = new DataGridTextColumn();
                columna9.Header = "Nombre de Transporte";
                columna9.Binding = new Binding("NOMB_TRANSPORTE");
                dgvListadoGuia.Columns.Add(columna9);


                DataGridTextColumn columna10 = new DataGridTextColumn();
                columna10.Header = "RUC de Transporte";
                columna10.Binding = new Binding("RUC_TRANSPORTE");
                dgvListadoGuia.Columns.Add(columna10);


                DataGridTextColumn columna11= new DataGridTextColumn();
                columna11.Header = "Tipo de Comprobante";
                columna11.Binding = new Binding("TIPO_COMPROB");
                dgvListadoGuia.Columns.Add(columna11);

                DataGridTextColumn columna12 = new DataGridTextColumn();
                columna12.Header = "Tipo de Traslado";
                columna12.Binding = new Binding("TIPO_TRASLADO");
                dgvListadoGuia.Columns.Add(columna12);

                DataGridTextColumn columna13 = new DataGridTextColumn();
                columna13.Header = "Motivo del Traslado";
                columna13.Binding = new Binding("MTO_TRASLADO");
                dgvListadoGuia.Columns.Add(columna13);

                DataGridTextColumn columna14 = new DataGridTextColumn();
                columna14.Header = "Departamento";
                columna14.Binding = new Binding("DEPARTAMENTO");
                dgvListadoGuia.Columns.Add(columna14);

                DataGridTextColumn columna15 = new DataGridTextColumn();
                columna15.Header = "Provincia";
                columna15.Binding = new Binding("PROVINCIA");
                dgvListadoGuia.Columns.Add(columna15);

                DataGridTextColumn columna16 = new DataGridTextColumn();
                columna16.Header = "Distrito";
                columna16.Binding = new Binding("DISTRITO");
                dgvListadoGuia.Columns.Add(columna16);

            }
            else
            {

            }

        }

        private async void btnVerDetalle_Click(object sender, RoutedEventArgs e)
        {
             if(this.dgvListadoGuia.SelectedItem != null)
            {
            FrmVerDetalleGuia frmDetalle = new FrmVerDetalleGuia();
            var guia = this.dgvListadoGuia.SelectedItem as GuiaRemision;
            frmDetalle.nroGuia = guia.NRO_GUIA;
            frmDetalle.ShowDialog();
              }
            else
            {
                await this.ShowMessageAsync("ERROR","Por favor elija una factura");
            }
        }
    }
}
