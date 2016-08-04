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
    /// Lógica de interacción para FrmListadoGasto.xaml
    /// </summary>
    public partial class FrmListadoGasto : MetroWindow
    {

        GastoDAO gastoDAO = new GastoDAO();
        DetalleGastoDAO detalleGASTODAO = new DetalleGastoDAO();
        public FrmListadoGasto()
        {
            InitializeComponent();
            txtBusqueda.Focus();
            ListadoGastoCparametros("", "DISPONIBLE");
            dgvListadoDetalleGasto.Visibility = Visibility.Hidden;
        }



        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string p_busqueda = txtBusqueda.Text;
                dgvListadoGasto.Columns.Clear();
                ListadoGastoCparametros(p_busqueda, "DISPONIBLE");
                dgvListadoDetalleGasto.Visibility = Visibility.Hidden;
            }
        }
        private void ListadoGastoCparametros(string p_Busqueda, string estado)
        {
            var listadoGasto = gastoDAO.listarGasto(p_Busqueda, estado);
            dgvListadoGasto.ItemsSource = listadoGasto;
            if (estado.Equals("DISPONIBLE"))
            {
                DataGridTextColumn columna = new DataGridTextColumn();
                columna.Header = "Nº de Gasto";
                columna.Binding = new Binding("NRO_GASTO");
                dgvListadoGasto.Columns.Add(columna);

                DataGridTextColumn columnaProv= new DataGridTextColumn();
                columnaProv.Header = "Proveedor-Nombres/Razón Social";
                columnaProv.Width = 420;
                columnaProv.Binding = new Binding("PROVEEDOR_NaturalJuridico");
                dgvListadoGasto.Columns.Add(columnaProv);

                DataGridTextColumn columna1 = new DataGridTextColumn();
                columna1.Header = "Fecha de Egreso";
                columna1.Binding = new Binding("FECHA_EGRE");
                columna1.HeaderStringFormat = "dd/MM/yyyy";
                dgvListadoGasto.Columns.Add(columna1);

                DataGridTextColumn columna2 = new DataGridTextColumn();
                columna2.Header = "Documento de Referencia";
                columna2.Binding = new Binding("DOC_REF");
                dgvListadoGasto.Columns.Add(columna2);

                DataGridTextColumn columna3 = new DataGridTextColumn();
                columna3.Header = "Nº de Documento de Referencia";
                columna3.Binding = new Binding("NRO_DOC_REF");
                dgvListadoGasto.Columns.Add(columna3);

                DataGridTextColumn columna4 = new DataGridTextColumn();
                columna4.Header = "TOTAL GASTO";
                columna4.Binding = new Binding("TOTAL");
                dgvListadoGasto.Columns.Add(columna4);
            }
            else
            {

            }

        }

        private void OnDoubleClick(object sender, MouseButtonEventArgs e)
        {           
            Gasto gasto = dgvListadoGasto.SelectedItem as Gasto;           
            dgvListadoDetalleGasto.Visibility = Visibility.Visible;
            dgvListadoDetalleGasto.Columns.Clear();
            listarDetalleXCodigoGasto(gasto.COD_GASTO);
        }

        private void listarDetalleXCodigoGasto(int codGasto)
        {
            var listadoDetalle = detalleGASTODAO.listarDetalleGasto(codGasto);
            dgvListadoDetalleGasto.ItemsSource = listadoDetalle;
            if (codGasto>0)
            {
                DataGridTextColumn columna = new DataGridTextColumn();
                columna.Header = "ITEM";
                columna.Binding = new Binding("ITEM");                                
                dgvListadoDetalleGasto.Columns.Add(columna);

                DataGridTextColumn columnaProv = new DataGridTextColumn();
                columnaProv.Header = "DESCRIPCIÓN SERVICIO";
                columnaProv.Width = 500;
                columnaProv.Binding = new Binding("ConceptoGasto.DESCRIPCION");
                dgvListadoDetalleGasto.Columns.Add(columnaProv);

                DataGridTextColumn columna1 = new DataGridTextColumn();
                columna1.Header = "CANTIDAD";
                columna1.Binding = new Binding("CANTIDAD");

                dgvListadoDetalleGasto.Columns.Add(columna1);

                DataGridTextColumn columna2 = new DataGridTextColumn();
                columna2.Header = "PRECIO";
                columna2.Binding = new Binding("PRECIO");
                dgvListadoDetalleGasto.Columns.Add(columna2);

                DataGridTextColumn columna3 = new DataGridTextColumn();
                columna3.Header = "IMPORTE";
                columna3.Binding = new Binding("IMPORTE");
                dgvListadoDetalleGasto.Columns.Add(columna3);
            }
            else
            {

            }

        }

    }
}
