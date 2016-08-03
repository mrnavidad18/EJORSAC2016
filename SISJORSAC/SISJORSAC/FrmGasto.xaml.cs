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
    /// Lógica de interacción para FrmGasto.xaml
    /// </summary>
    public partial class FrmGasto : MetroWindow
    {

        ProveedorDAO proveedorDao = new ProveedorDAO();
        GastoDAO gastoDAO = new GastoDAO();
        ConceptoGastoDAO conceptoGastoDAO = new ConceptoGastoDAO();
        int item = 1;
        double total = 0;
        string mensaje = "";

        public FrmGasto()
        {
            InitializeComponent();
            ListarConceptoGasto("DISPONIBLE");
            this.txtFechaEmision.Text = DateTime.Now.ToString();
            this.txtNroGasto.Text = gastoDAO.ObtenerNroGasto();
        }
        private void ListarProveedores(string tipoCliente)
        {
            var listaProveedores = proveedorDao.ListarProveedor(tipoCliente);
            this.cboProveedor.ItemsSource = listaProveedores;
            if (tipoCliente.Equals("JURIDICA"))
            {
                this.cboProveedor.DisplayMemberPath = "RAZON_SOCIAL";
                this.cboProveedor.SelectedValuePath = "COD_PROV";
            }
            else
            {
                this.cboProveedor.DisplayMemberPath = "NOMBRES";
                this.cboProveedor.SelectedValuePath = "COD_PROV";
            }
        }

        private void ListarConceptoGasto(string estado)
        {
            var listadoConcepto = conceptoGastoDAO.listarConceptoGasto(estado);
            this.cboServicio.ItemsSource = listadoConcepto;
            this.cboServicio.DisplayMemberPath = "DESCRIPCION";
            this.cboServicio.SelectedValuePath = "COD_CON_GAS";
        }

        private void rdNATUTAL_Checked(object sender, RoutedEventArgs e)
        {
            this.cboProveedor.IsEnabled = true;
            ListarProveedores(rdNATUTAL.Content.ToString());
        }

        private void rbJURIDICA_Checked_1(object sender, RoutedEventArgs e)
        {
            this.cboProveedor.IsEnabled = true;
            ListarProveedores(rbJURIDICA.Content.ToString());
        }

        private DetalleGasto AgregarDetalles()
        {           
            DetalleGasto detalleGasto = new DetalleGasto();
            int codConcepto = Convert.ToInt32(this.cboServicio.SelectedValue);            
            double precio = Convert.ToDouble(txtPrecio.Text.ToString().Replace(@".",","));
            int cantidad=Convert.ToInt32(txtCantidad.Text);
            detalleGasto.ConceptoGasto = conceptoGastoDAO.ObtenerConceptoGasto(codConcepto);
            detalleGasto.ITEM = item;
            detalleGasto.CANTIDAD = cantidad;
            detalleGasto.PRECIO = precio;
            detalleGasto.IMPORTE = cantidad * precio;
            var listado = VariablesGlobales.listaDetallesGasto;
            VariablesGlobales.listaDetallesGasto.Add(detalleGasto);
            LlenarGrid(VariablesGlobales.listaDetallesGasto);
            item++;
            total = total + detalleGasto.IMPORTE;
            return detalleGasto;           

        }
        private void LlenarGrid(List<DetalleGasto> listaDetalles)
        {
            this.dgvListado.ItemsSource = null;
            dgvListado.ItemsSource = listaDetalles;
        }

        private async void btnAgregarDetalle_Click(object sender, RoutedEventArgs e)
        {
                 if (this.cboServicio.SelectedItem != null && this.txtCantidad.Text.Trim() != "" && this.txtPrecio.Text.Trim() != "")
                {
                    AgregarDetalles();
                    this.txtTotal.Text = total.ToString();
                    this.txtCantidad.Text = "";
                    this.txtPrecio.Text = "";
                    this.cboServicio.SelectedIndex = -1;
                }
                else
                {
                    await this.ShowMessageAsync("Error", "Falta llenar algunos campos");
            }
        }
        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
           if(this.dgvListado.SelectedIndex != -1)
            {
                var detalleGasto = this.dgvListado.SelectedItem as DetalleGasto;
                VariablesGlobales.listaDetallesGasto.RemoveAll(x => x.ITEM == detalleGasto.ITEM);
                item=1;
                total = 0;
                foreach (var detalle in VariablesGlobales.listaDetallesGasto)
                {
                    detalle.ITEM = item;
                    total=total+detalle.IMPORTE;
                    item++;
                }
              
                this.txtTotal.Text = total.ToString();
                LlenarGrid(VariablesGlobales.listaDetallesGasto);
            }
            else
            {
                await this.ShowMessageAsync("Error", "Seleccione un detalle");
            }
        }
      
        private void GenerarGasto()
        {
            Gasto gasto = new Gasto();
            int codProveedor = Convert.ToInt32(this.cboProveedor.SelectedValue);
            gasto.FECHA_EGRE = Convert.ToDateTime(txtFechaEmision.Text);
            gasto.MONEDA = "SOLES";
            gasto.PROVEEDOR = proveedorDao.ObtenerProveedor(codProveedor);
            gasto.NRO_DOC_REF = txtNroDocRef.Text.Trim();
            gasto.DOC_REF = txtDocRef.Text.ToUpper();
            gasto.DetalleGASTO = VariablesGlobales.listaDetallesGasto;
            gasto.NRO_GASTO = txtNroGasto.Text;
            Object[] result = gastoDAO.Agregar(gasto);
            mensaje = result[1].ToString();
        }

        private async void btnGenerarGasto_Click(object sender, RoutedEventArgs e)
        {            
            try
            {
                if (this.txtNroGasto.Text.Trim() != "" && this.cboProveedor.SelectedItem != null   )      
                {
                    if (this.dgvListado.Items.Count == 0)
                    {
                        await this.ShowMessageAsync("Error", "Falta llenar detalles");
                    }
                    else
                    {
                        if (await this.ShowMessageAsync("Confirmacion", "¿Esta seguro de generar este Gasto?", MessageDialogStyle.AffirmativeAndNegative) == MessageDialogResult.Affirmative)
                        {
                            GenerarGasto();
                            await this.ShowMessageAsync("Gasto Generado",mensaje);
                            VariablesGlobales.listaDetallesGasto = new List<DetalleGasto>();
                            total = 0;
                            mensaje = "";                            
                            this.Close();
                        }
                    }
                }
                else
                {
                    await this.ShowMessageAsync("Error", "Falta llenar algunos campos");
                }
            }
            catch (Exception ex)
            {               
                MessageBox.Show( ex.Message,"Error");
            }
        }

        private void Cantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox t = (TextBox)sender;
                int cantidad = Convert.ToInt32(t.Text);

                var detalleGasto = this.dgvListado.SelectedItem as DetalleGasto;
                var detalleEncontrado = VariablesGlobales.listaDetallesGasto.Find(x => x.ITEM == detalleGasto.ITEM);
                detalleEncontrado.CANTIDAD = cantidad;
                detalleEncontrado.IMPORTE = cantidad * detalleEncontrado.PRECIO;

                total = 0;
                foreach (var detalle in VariablesGlobales.listaDetallesGasto)
                {
                    total = total + detalle.IMPORTE;
                }
                this.txtTotal.Text = total.ToString();

                LlenarGrid(VariablesGlobales.listaDetallesGasto);
            }

            int ascci = Convert.ToInt32(Convert.ToChar(e.Key));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122) e.Handled = false;
            else e.Handled = true;

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            VariablesGlobales.listaDetallesGasto = new List<DetalleGasto>();
            total = 0;
            mensaje = "";
            this.Close();
        }
        

       
    }
}
