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
    /// Lógica de interacción para FrmListadoContrato.xaml
    /// </summary>
    public partial class FrmListadoContrato : MetroWindow
    {

        ContratoDAO contratoDAO = new ContratoDAO();
        public FrmListadoContrato()
        {
            InitializeComponent();
            txtBusqueda.Focus();
            ListadoContratoCparametros("", "DISPONIBLE");
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string p_busqueda = txtBusqueda.Text;
                dgvListadoContrato.Columns.Clear();
                ListadoContratoCparametros(p_busqueda, "DISPONIBLE");
            }
        }
        private void ListadoContratoCparametros(string p_Busqueda, string estado)
        {
            var listadoContrato = contratoDAO.listarContrato(p_Busqueda, estado);
            dgvListadoContrato.ItemsSource = listadoContrato;
            if (estado.Equals("DISPONIBLE"))
            {
                DataGridTextColumn columna = new DataGridTextColumn();
                columna.Header = "Nº de Contrato";
                columna.Binding = new Binding("NRO_CONTRATO");
                dgvListadoContrato.Columns.Add(columna);

                DataGridTextColumn columnaCli = new DataGridTextColumn();
                columnaCli.Header = "Cliente-Nombres/Razón Social";
                columnaCli.Binding = new Binding("CLIENTEJURIDICONATURAL");
                dgvListadoContrato.Columns.Add(columnaCli);

                DataGridTextColumn columnaUsuario = new DataGridTextColumn();
                columnaUsuario.Header = "VENDEDOR";
                columnaUsuario.Binding = new Binding("USUARIONOMBRE");
                dgvListadoContrato.Columns.Add(columnaUsuario);

                DataGridTextColumn columna2 = new DataGridTextColumn();
                columna2.Header = "Fecha de Contrato";
                columna2.HeaderStringFormat = "dd/MM/yyyy";
                columna2.Binding = new Binding("FECHA_CONTRATO");
                dgvListadoContrato.Columns.Add(columna2);

                DataGridTextColumn columna3 = new DataGridTextColumn();
                columna3.Header = "Dirección de Obra";
                columna3.Binding = new Binding("DIRECCION_OBRA");
                dgvListadoContrato.Columns.Add(columna3);

                DataGridTextColumn columna4 = new DataGridTextColumn();
                columna4.Header = "Transporte";
                columna4.Binding = new Binding("TRANSPORTE");
                dgvListadoContrato.Columns.Add(columna4);

                DataGridTextColumn columna5 = new DataGridTextColumn();
                columna5.Header = "Total de Días";
                columna5.Binding = new Binding("TOTAL_DIAS");
                dgvListadoContrato.Columns.Add(columna5);

                DataGridTextColumn columna6 = new DataGridTextColumn();
                columna6.Header = "Fecha de Entrega";
                columna6.Binding = new Binding("FECHA_ENTREGA");
                dgvListadoContrato.Columns.Add(columna6);

                DataGridTextColumn columna7 = new DataGridTextColumn();
                columna7.Header = "Hora de Entrega";
                columna7.Binding = new Binding("HORA_ENTREGA");
                dgvListadoContrato.Columns.Add(columna7);


                DataGridTextColumn columna8 = new DataGridTextColumn();
                columna8.Header = "Fecha Devolución";
                columna8.Binding = new Binding("FECHA_DEVOLUCION");
                dgvListadoContrato.Columns.Add(columna8);


                DataGridTextColumn columna9 = new DataGridTextColumn();
                columna9.Header = "Hora de Devolución";
                columna9.Binding = new Binding("HORA_DEVOLUCION");
                dgvListadoContrato.Columns.Add(columna9);


                DataGridTextColumn columna10 = new DataGridTextColumn();
                columna10.Header = "Garantia ";
                columna10.Binding = new Binding("GARANTIA");
                dgvListadoContrato.Columns.Add(columna10);


                DataGridTextColumn columna11 = new DataGridTextColumn();
                columna11.Header = "Cheque";
                columna11.Binding = new Binding("CHEQUE");
                dgvListadoContrato.Columns.Add(columna11);

                DataGridTextColumn columna12 = new DataGridTextColumn();
                columna12.Header = "Documento";
                columna12.Binding = new Binding("DOCUMENTO");
                dgvListadoContrato.Columns.Add(columna12);

                DataGridTextColumn columna13 = new DataGridTextColumn();
                columna13.Header = "RECIBO";
                columna13.Binding = new Binding("RECIBO");
                dgvListadoContrato.Columns.Add(columna13);

                DataGridTextColumn columna14 = new DataGridTextColumn();
                columna14.Header = "IGV";
                columna14.Binding = new Binding("IGV");
                dgvListadoContrato.Columns.Add(columna14);

                DataGridTextColumn columna15 = new DataGridTextColumn();
                columna15.Header = "SUBTOTAL";
                columna15.Binding = new Binding("SUBTOTAL");
                dgvListadoContrato.Columns.Add(columna15);

                DataGridTextColumn columna16 = new DataGridTextColumn();
                columna16.Header = "TOTAL";
                columna16.Binding = new Binding("TOTAL");
                dgvListadoContrato.Columns.Add(columna16);
            }
            else
            {

            }

        }

        private async void btnVerDetalle_Click(object sender, RoutedEventArgs e)
        {
            if(this.dgvListadoContrato.SelectedItem!=null)
            {
            var contrato = this.dgvListadoContrato.SelectedItem as Contrato;
            FrmVerDetalleContrato frmContrato = new FrmVerDetalleContrato();
            frmContrato.nroContrato = contrato.NRO_CONTRATO;
            frmContrato.ShowDialog();
            }
            else
            {
                await this.ShowMessageAsync("ERROR","Por favor elija una factura");
            }

        }
        
    }
}
