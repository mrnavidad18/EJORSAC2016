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
using SISJORSAC.Reportes;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace SISJORSAC
{
    /// <summary>
    /// Lógica de interacción para FrmBoleta.xaml
    /// </summary>
    public partial class FrmBoleta : MetroWindow
    {

       
        Servicio servicio;
        GuiaRemision guiaRemision;
        int item =1;
        double total = 0;
        string mensaje = "";
        ClienteDAO clienteDao = new ClienteDAO();
        ServicioDAO servicioDAO = new ServicioDAO();
        BoletaDAO boletaDao = new BoletaDAO();
        GuiaRemisionDAO guiaDao = new GuiaRemisionDAO();

        public FrmBoleta()
        {
            InitializeComponent();
            this.txtNroBoleta.Text = boletaDao.ObtenerNroBoleta();
            this.txtFechaEmision.Text = DateTime.Now.ToString();
            ListarServicios();
            
            if (VariablesGlobales.ClickBoletaConGuia)
                ObtenerGuia();
                
            
            if (VariablesGlobales.ClickFacturaBoleta)
                ObtenerDatosFactura();
            

            if (VariablesGlobales.ClickContratoBoleta)
                ObtenerDatosContrato();

            if (VariablesGlobales.ClickGuiaBoleta)
                ObtenerDatosGuia();
           
        }

        private void Imprimir(string numeroBoleta)
        {
            FrmBoletaImprimirViewer ventana = new FrmBoletaImprimirViewer();
            ReportDocument doc = new ReportDocument();
            ParameterField parameter = new ParameterField();
            ParameterFields parameters = new ParameterFields();
            ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            parameter.Name = "@P_NRO_BOLETA";
            pdv.Value = numeroBoleta;
            parameter.CurrentValues.Add(pdv);
            parameters.Add(parameter);
            ventana.crystalReportViewer1.ParameterFieldInfo = parameters;
            //string fullPath = System.IO.Path.GetFullPath("FacturaImprimir.rpt").Replace("\\bin\\Debug","\\Reportes");
            doc.Load(@"C:\Users\jhon01\Documents\GitHub\EJORSAC2016\SISJORSAC\SISJORSAC\Reportes\BoletaImprimir.rpt");
            ventana.crystalReportViewer1.ReportSource = doc;
            ventana.ShowDialog();
        }
        private void ObtenerDatosGuia()
        {
            this.cboCliente.DisplayMemberPath = "RAZON_SOCIAL";
            this.cboCliente.SelectedValuePath = "COD_CLI";
            this.cboCliente.SelectedIndex = VariablesGlobales.indexCliente;
            this.txtNroGuia.Text = VariablesGlobales.NRO_GUIA_GLOBAL;
            guiaRemision = guiaDao.ObtenerGuiaRemisionXNroGuia(VariablesGlobales.NRO_GUIA_GLOBAL);

            DetalleBoleta detalleBoleta = null;

            VariablesGlobales.listaDetallesBoleta.Clear();
            foreach (var detalle in VariablesGlobales.listaDetallesGuia)
            {
                detalleBoleta = new DetalleBoleta();
                detalleBoleta.CANTIDAD = detalle.CANTIDAD;
                detalleBoleta.SERVICIO = detalle.SERVICIO;
                detalleBoleta.PRECIO = detalle.SERVICIO.PRECIO;
                detalleBoleta.ITEM = item;
                detalleBoleta.IMPORTE = detalle.CANTIDAD * detalle.SERVICIO.PRECIO;
                VariablesGlobales.listaDetallesBoleta.Add(detalleBoleta);
                total = total + detalleBoleta.IMPORTE;
                item++;

            }

            LlenarGrid(VariablesGlobales.listaDetallesBoleta);

            this.txtTotal.Text = total.ToString();

            if (VariablesGlobales.clienteGuia != null)
            {
                if (VariablesGlobales.clienteGuia.TIPO_CLIE.Equals("NATURAL"))
                {
                    this.rbNATURAL.IsChecked = true;
                    this.txtDniRuc.Text = VariablesGlobales.clienteGuia.DNI;
                }
                else
                {
                    this.rbJURIDICA.IsChecked = true;
                    this.txtDniRuc.Text = VariablesGlobales.clienteGuia.RUC;
                }
            }
        }

       
        public void ObtenerDatosFactura()
        {

            this.cboCliente.DisplayMemberPath = "RAZON_SOCIAL";
            this.cboCliente.SelectedValuePath = "COD_CLI";
            this.cboCliente.SelectedIndex = VariablesGlobales.indexCliente;
            this.txtNroGuia.Text = VariablesGlobales.NRO_GUIA_GLOBAL;
            guiaRemision = guiaDao.ObtenerGuiaRemisionXNroGuia(VariablesGlobales.NRO_GUIA_GLOBAL);

            DetalleBoleta detalleBoleta = null;

            VariablesGlobales.listaDetallesBoleta.Clear();
            foreach (var detalle in VariablesGlobales.listaDetallesFactura)
            {
                detalleBoleta = new DetalleBoleta();
                detalleBoleta.CANTIDAD = detalle.CANTIDAD;
                detalleBoleta.SERVICIO = detalle.SERVICIO;
                detalleBoleta.PRECIO = detalle.PRECIO;
                detalleBoleta.ITEM = item;
                detalleBoleta.IMPORTE = detalle.CANTIDAD * detalle.PRECIO;
                VariablesGlobales.listaDetallesBoleta.Add(detalleBoleta);
                total = total + detalleBoleta.IMPORTE;
                item++;

            }

            LlenarGrid(VariablesGlobales.listaDetallesBoleta);

            this.txtTotal.Text = total.ToString();

            if (VariablesGlobales.clienteFactura != null)
            {
                if (VariablesGlobales.clienteFactura.TIPO_CLIE.Equals("NATURAL"))
                {
                    this.rbNATURAL.IsChecked = true;
                    this.txtDniRuc.Text = VariablesGlobales.clienteFactura.DNI;
                }
                else
                {
                    this.rbJURIDICA.IsChecked = true;
                    this.txtDniRuc.Text = VariablesGlobales.clienteFactura.RUC;
                }
            }
           
         
        }

        private void ObtenerDatosContrato()
        {

            this.cboCliente.DisplayMemberPath = "RAZON_SOCIAL";
            this.cboCliente.SelectedValuePath = "COD_CLI";
            this.cboCliente.SelectedIndex = VariablesGlobales.indexCliente;
            //this.txtNroGuia.Text = VariablesGlobales.NRO_GUIA_GLOBAL;
            //guiaRemision = guiaDao.ObtenerGuiaRemisionXNroGuia(VariablesGlobales.NRO_GUIA_GLOBAL);

            DetalleBoleta detalleBoleta = null;

            VariablesGlobales.listaDetallesBoleta.Clear();
            foreach (var detalle in VariablesGlobales.listaDetallesContrato)
            {
                detalleBoleta = new DetalleBoleta();
                detalleBoleta.CANTIDAD = detalle.CANTIDAD;
                detalleBoleta.SERVICIO = detalle.SERVICIO;
                detalleBoleta.PRECIO = detalle.PRECIO;
                detalleBoleta.ITEM = item;
                detalleBoleta.IMPORTE = detalle.CANTIDAD * detalle.PRECIO;
                VariablesGlobales.listaDetallesBoleta.Add(detalleBoleta);
                total = total + detalleBoleta.IMPORTE;
                item++;

            }

            LlenarGrid(VariablesGlobales.listaDetallesBoleta);

            this.txtTotal.Text = total.ToString();

            if (VariablesGlobales.clienteContrato != null)
            {
                if (VariablesGlobales.clienteContrato.TIPO_CLIE.Equals("NATURAL"))
                {
                    this.rbNATURAL.IsChecked = true;
                    this.txtDniRuc.Text = VariablesGlobales.clienteContrato.DNI;
                }
                else
                {
                    this.rbJURIDICA.IsChecked = true;
                    this.txtDniRuc.Text = VariablesGlobales.clienteContrato.RUC;
                }
                this.txtDireccion.Text = VariablesGlobales.clienteContrato.DIRECCION;
            }
           
        }


        private void ListarClientes(string tipoCliente)
        {
            
                var listacliente = clienteDao.ListarCliente(tipoCliente);
                this.cboCliente.Items.Clear();
                foreach (var cliente in listacliente)
                {
                    this.cboCliente.Items.Add(cliente);
                }
               
                if (tipoCliente.Equals("JURIDICA"))
                {
                    this.cboCliente.DisplayMemberPath = "RAZON_SOCIAL";
                    this.cboCliente.SelectedValuePath = "COD_CLI";
                }
                else
                {
                    this.cboCliente.DisplayMemberPath = "NOMBRES";
                    this.cboCliente.SelectedValuePath = "COD_CLI";
                } 
            
           
        }

        private void ListarServicios()
        {

            var listaServicios = servicioDAO.listarServicio("ACTIVO","");
            this.cboServicio.ItemsSource = listaServicios;
            this.cboServicio.DisplayMemberPath = "DESCRIPCION";
            this.cboServicio.SelectedValuePath = "COD_SERV";


        }

        private void cboServicio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int codServicio = Convert.ToInt32(this.cboServicio.SelectedValue);
            servicio = servicioDAO.ObtenerServicio(codServicio);
            this.txtPrecio.Text = servicio.PRECIO.ToString();
        }

        private void rbNATURAL_Checked(object sender, RoutedEventArgs e)
        {
            this.txtDniRuc.Text = "";
            this.txtDireccion.Text = "";
            this.cboCliente.IsEnabled = true;
            ListarClientes(rbNATURAL.Content.ToString());
        }

        private void rbJURIDICA_Checked(object sender, RoutedEventArgs e)
        {
            this.txtDniRuc.Text = "";
            this.txtDireccion.Text = "";
            this.cboCliente.IsEnabled = true;
            ListarClientes(rbJURIDICA.Content.ToString());    
        }

        private void Importe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox t = (TextBox)sender;
                int cantidad = Convert.ToInt32(t.Text);

                var detalleBoleta = this.dgvListado.SelectedItem as DetalleBoleta;
                var detalleEncontrado = VariablesGlobales.listaDetallesBoleta.Find(x => x.ITEM == detalleBoleta.ITEM);
                detalleEncontrado.CANTIDAD = cantidad;
                detalleEncontrado.IMPORTE = cantidad * detalleEncontrado.PRECIO;

                total = 0;
                foreach (var detalle in VariablesGlobales.listaDetallesBoleta)
                {
                    total = total + detalle.IMPORTE;
                }
                this.txtTotal.Text = total.ToString();

                LlenarGrid(VariablesGlobales.listaDetallesBoleta);
            }

            int ascci = Convert.ToInt32(Convert.ToChar(e.Key));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122) e.Handled = false;
            else e.Handled = true;

        }

        private void cboCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboCliente.SelectedIndex == -1)
            {
                VariablesGlobales.clienteBoleta = null;
            }
            else
            {
                int codCliente = Convert.ToInt32(this.cboCliente.SelectedValue);
                VariablesGlobales.clienteBoleta = clienteDao.ObtenerCliente(codCliente);
                if (VariablesGlobales.clienteBoleta.TIPO_CLIE.Equals("NATURAL"))
                {
                    this.txtDniRuc.Text = VariablesGlobales.clienteBoleta.DNI;
                }
                else
                {
                    this.txtDniRuc.Text = VariablesGlobales.clienteBoleta.RUC;
                }
                this.txtDireccion.Text = VariablesGlobales.clienteBoleta.DIRECCION.ToString();
            }
        }

        private DetalleBoleta AgregarDetalles()
        {

            DetalleBoleta detalle = new DetalleBoleta();

            int codServicio = Convert.ToInt32(this.cboServicio.SelectedValue);
            int cantidad = Convert.ToInt32(this.txtCantidad.Text);
            double precio = Convert.ToDouble(this.txtPrecio.Text);

            detalle.SERVICIO = servicioDAO.ObtenerServicio(codServicio);
            detalle.CANTIDAD = cantidad;
            detalle.PRECIO = precio;
            detalle.ITEM = item;
            detalle.IMPORTE = cantidad * precio;
            VariablesGlobales.listaDetallesBoleta.Add(detalle);
            LlenarGrid(VariablesGlobales.listaDetallesBoleta);
            total = total + detalle.IMPORTE;
            item++;
            return detalle;
        }

        private void LlenarGrid(List<DetalleBoleta> listaDetalles)
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

        private void chkObservacion_Checked(object sender, RoutedEventArgs e)
        {
            this.txtObservacion.IsEnabled = true;
        }

        private void chkCambiarNroBol_Checked(object sender, RoutedEventArgs e)
        {
            this.txtNroBoleta.IsEnabled = true;

            this.txtNroBoleta.Focus();
        }

        private void AgregarBoleta()
        {
            Boleta boleta = new Boleta();
            boleta.MODALIDAD = ((ComboBoxItem)this.cboModalidad.SelectedItem).Content.ToString();
            boleta.FECHA_EMISION = DateTime.Now;
            boleta.cliente = VariablesGlobales.clienteBoleta;
            boleta.TOTAL = total;
            if (this.txtNroGuia.Text == "")
            {
                boleta.GUIA = null;
            }
            else
            {

                boleta.GUIA = guiaRemision;
            }

            boleta.DETALLEBOLETA = VariablesGlobales.listaDetallesBoleta;
            boleta.OBSERVACION = this.txtObservacion.Text;
            if (chkCambiarNroBol.IsChecked == true)
            {
                boleta.NRO_BOLETA = this.txtNroBoleta.Text;
                Object[] result = boletaDao.AgregarBoletaConNroBoleta(boleta);
                mensaje = result[1].ToString();
            }
            else
            {
                Object[] result = boletaDao.AgregarBoleta(boleta);
                mensaje = result[1].ToString();
            }


        }

        private async void btnGenerarBoleta_Click(object sender, RoutedEventArgs e)
        {
             try
            {
                if (this.txtNroBoleta.Text.Trim() != "" && this.cboModalidad.SelectedItem != null && this.cboMoneda.SelectedItem != null &&
             this.txtDniRuc.Text.Trim()!="")
                {
                    if (this.dgvListado.Items.Count == 0)
                    {
                        await this.ShowMessageAsync("Error", "Falta llenar detalles");
                    }
                    else
                    {
                        if (await this.ShowMessageAsync("Confirmacion", "¿Esta seguro de generar esta Boleta?", MessageDialogStyle.AffirmativeAndNegative) == MessageDialogResult.Affirmative)
                        {
                            AgregarBoleta();
                            VariablesGlobales.NRO_GUIA_GLOBAL = "";
                            VariablesGlobales.clienteFactura = null;
                            VariablesGlobales.clienteBoleta = null;
                            VariablesGlobales.listaDetallesFactura = null;
                            VariablesGlobales.ClickFacturaBoleta = false;
                            if (await this.ShowMessageAsync("Boleta Generada", "¿Desea IMPRIMIR la boleta?", MessageDialogStyle.AffirmativeAndNegative) == MessageDialogResult.Affirmative)
                            {
                                Imprimir(this.txtNroBoleta.Text);
                                this.Close();
                            }
                            else
                            {
                                this.Close();
                            }
                           
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
                VariablesGlobales.NRO_GUIA_GLOBAL = "";
                MessageBox.Show( ex.Message,"Error");
            }
        }

        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
             if(this.dgvListado.SelectedIndex != -1)
            {
                var detalleBoleta = this.dgvListado.SelectedItem as DetalleBoleta;
                VariablesGlobales.listaDetallesBoleta.RemoveAll(x => x.ITEM==detalleBoleta.ITEM);
                item=1;
                total = 0;
                foreach (var detalle in VariablesGlobales.listaDetallesBoleta)
                {
                    detalle.ITEM = item;
                    total=total+detalle.IMPORTE;
                    item++;
                }
              
                this.txtTotal.Text = total.ToString();
                LlenarGrid(VariablesGlobales.listaDetallesBoleta);

            }
            else
            {
                await this.ShowMessageAsync("Error", "Seleccione un detalle");
            }
        }

        public GuiaRemision ObtenerGuia()
        {
            if (VariablesGlobales.NRO_GUIA_GLOBAL != "")
            {
                DetalleGuiaRemisionDAO detalleGuiaDao = new DetalleGuiaRemisionDAO();
                guiaRemision = guiaDao.ObtenerGuiaRemisionXNroGuia(VariablesGlobales.NRO_GUIA_GLOBAL);
                var listaDetalleGuia = detalleGuiaDao.listarDetalleGuiaxGuia(guiaRemision.COD_GUIA);

                VariablesGlobales.clienteBoleta = guiaRemision.cliente;

                

                this.txtNroGuia.Text = VariablesGlobales.NRO_GUIA_GLOBAL.ToString();
                this.cboModalidad.Items.Clear();
                ComboBoxItem itemModalidad = new ComboBoxItem();
                itemModalidad.Content = guiaRemision.TIPO_TRASLADO;
                this.cboModalidad.Items.Add(itemModalidad);

                this.cboModalidad.SelectedIndex = 0;

                this.cboModalidad.IsEnabled = false;
                DetalleBoleta detalleBoleta = null;

                foreach (var detalle in listaDetalleGuia)
                {
                    detalleBoleta = new DetalleBoleta();
                    detalleBoleta.CANTIDAD = detalle.CANTIDAD;
                    detalleBoleta.SERVICIO = detalle.SERVICIO;
                    detalleBoleta.PRECIO = detalle.SERVICIO.PRECIO;
                    detalleBoleta.ITEM = item;
                    detalleBoleta.IMPORTE = detalle.CANTIDAD * detalle.SERVICIO.PRECIO;
                    VariablesGlobales.listaDetallesBoleta.Add(detalleBoleta);



                    total = total + detalleBoleta.IMPORTE;
                    item++;

                }

                LlenarGrid(VariablesGlobales.listaDetallesBoleta);

                this.txtTotal.Text = total.ToString();


                if (guiaRemision.cliente.TIPO_CLIE.Equals("NATURAL"))
                {
                    this.rbNATURAL.IsChecked = true;
                    this.cboCliente.Text = guiaRemision.cliente.NOMBRES;
                    this.txtDniRuc.Text = guiaRemision.cliente.DNI;
                    this.txtDireccion.Text = guiaRemision.cliente.DIRECCION;
                }
                else
                {
                    this.rbJURIDICA.IsChecked = true;
                    this.cboCliente.Text = guiaRemision.cliente.RAZON_SOCIAL;
                    this.txtDireccion.Text = guiaRemision.cliente.DIRECCION;
                    this.txtDniRuc.Text = guiaRemision.cliente.RUC;
                }
            }
            return guiaRemision;
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            VariablesGlobales.ClickContratoBoleta = false;
            VariablesGlobales.ClickBoletaConGuia = false;
            VariablesGlobales.ClickFacturaBoleta = false;
            VariablesGlobales.ClickGuiaBoleta = false;
        }

        private void txtCancelar_Click(object sender, RoutedEventArgs e)
        {
            VariablesGlobales.clienteBoleta = null;
            VariablesGlobales.NRO_GUIA_GLOBAL = "";
            VariablesGlobales.listaDetallesBoleta.Clear();
            VariablesGlobales.ClickFacturaBoleta = false;
            this.Close();
        }

        private void btnCambiarFactura_Click(object sender, RoutedEventArgs e)
        {
            VariablesGlobales.indexCliente = this.cboCliente.SelectedIndex;
            VariablesGlobales.ClickBoletaFactura = true;
            VariablesGlobales.ClickFacturaBoleta = false;
            frmFactura frmFactura = new frmFactura();
            this.Close();
            frmFactura.ShowDialog();
        }

        private void btnCambiarContrato_Click(object sender, RoutedEventArgs e)
        {
            VariablesGlobales.indexCliente = this.cboCliente.SelectedIndex;
            VariablesGlobales.ClickBoletaContrato = true;
            VariablesGlobales.ClickFacturaBoleta = false;
            FrmContratoAlquiler frmcontrato = new FrmContratoAlquiler();
            this.Close();
            frmcontrato.ShowDialog();
        }

        private void btnCambiarGuia_Click(object sender, RoutedEventArgs e)
        {
            VariablesGlobales.indexCliente = this.cboCliente.SelectedIndex;
            VariablesGlobales.ClickBoletaGuia = true;
            VariablesGlobales.ClickFacturaBoleta = false;
            FrmGuiaRemision frmGuia = new FrmGuiaRemision();
            this.Close();
            frmGuia.ShowDialog();
        }

    }
}
