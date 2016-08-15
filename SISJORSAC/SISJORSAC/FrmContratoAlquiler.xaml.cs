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
using SISJORSAC.Reportes;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace SISJORSAC
{
    /// <summary>
    /// Lógica de interacción para FrmContratoAlquiler.xaml
    /// </summary>
    public partial class FrmContratoAlquiler : MetroWindow
    {
        
        Servicio servicio;
        
        double subtotal = 0;
        double total = 0;
        double IGV = 0.18;
        double igvMonto = 0;
        int item = 1;
        string mensaje = "";

        ClienteDAO clienteDao = new ClienteDAO();
        ServicioDAO servicioDAO = new ServicioDAO();
        FacturaDAO facturaDao = new FacturaDAO();
        GuiaRemisionDAO guiaDao = new GuiaRemisionDAO();
        ContratoDAO contratoDao = new ContratoDAO();
        UsuarioDAO usuarioDao= new UsuarioDAO();

        public FrmContratoAlquiler()
        {
            InitializeComponent();
            this.txtNroContrato.Text = contratoDao.ObtenerNroContrato();
            this.txtFechaEmision.Text = DateTime.Now.ToString();
            ListarServicios();
            ListarUsuarios();
            VariablesGlobales.listaDetallesContrato.Clear();

            if (VariablesGlobales.ClickFacturaContrato)
            {
                ObtenerDatosFactura();
            }
            if (VariablesGlobales.ClickBoletaContrato)
            {
                ObtenerDatosBoleta();
            }
            if (VariablesGlobales.ClickGuiaContrato)
            {
                ObtenerDatosGuia();
            }
            
        }
        private void Imprimir(string numeroContrato)
        {
            FrmContratoImprimirViewer ventana = new FrmContratoImprimirViewer();
            ReportDocument doc = new ReportDocument();
            ParameterField parameter = new ParameterField();
            ParameterFields parameters = new ParameterFields();
            ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            parameter.Name = "@P_NRO_CONTRATO";
            pdv.Value = numeroContrato;
            parameter.CurrentValues.Add(pdv);
            parameters.Add(parameter);
            ventana.crystalReportViewer1.ParameterFieldInfo = parameters;
            //string fullPath = System.IO.Path.GetFullPath("FacturaImprimir.rpt").Replace("\\bin\\Debug","\\Reportes");
            doc.Load(@"C:\Program Files\SISJORSAC\Reportes\ContratoImprimir.rpt");
            ventana.crystalReportViewer1.ReportSource = doc;
            ventana.ShowDialog();
        }
       
       


        private void ListarClientes(string tipoCliente)
        {
            
            
                var listacliente = clienteDao.ListarCliente(tipoCliente);


                this.cboRazonsocial.Items.Clear();
                foreach (var cliente in listacliente)
                {
                    this.cboRazonsocial.Items.Add(cliente);
                }
                if (tipoCliente.Equals("JURIDICA"))
                {
                    this.cboRazonsocial.DisplayMemberPath = "RAZON_SOCIAL";
                    this.cboRazonsocial.SelectedValuePath = "COD_CLI";
                   
                }
                else
                {
                    this.cboRazonsocial.DisplayMemberPath = "NOMBRES";
                    this.cboRazonsocial.SelectedValuePath = "COD_CLI";
                }
            

        }
        private void rbNATURAL_Checked(object sender, RoutedEventArgs e)
        {
            this.txtDniRuc.Text = "";
            this.txtTelf.Text = "";
            this.txtDireccion.Text = "";
            this.cboRazonsocial.IsEnabled = true;
            ListarClientes(rbNATURAL.Content.ToString());
        }

        private void rbJURIDICA_Checked(object sender, RoutedEventArgs e)
        {
            this.txtDniRuc.Text= "";
            this.txtTelf.Text = "";
            this.txtDireccion.Text = "";
            this.cboRazonsocial.IsEnabled = true;
            ListarClientes(rbJURIDICA.Content.ToString());
        }

        private void cboRazonsocial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.cboRazonsocial.SelectedIndex == -1)
            {
                VariablesGlobales.clienteContrato = null;
            }
            else
            {
                int codCliente = Convert.ToInt32(this.cboRazonsocial.SelectedValue);
                VariablesGlobales.clienteContrato = clienteDao.ObtenerCliente(codCliente);
                if (VariablesGlobales.clienteContrato.TIPO_CLIE.Equals("NATURAL"))
                {
                    this.txtDniRuc.Text = VariablesGlobales.clienteContrato.DNI;
                    this.txtTelf.Text = VariablesGlobales.clienteContrato.TEL_FIJO_CASA;
                }
                else
                {
                    this.txtDniRuc.Text = VariablesGlobales.clienteContrato.RUC;
                    this.txtTelf.Text = VariablesGlobales.clienteContrato.TEL_FIJO_OFICINA;
                }
                this.txtDireccion.Text = VariablesGlobales.clienteContrato.DIRECCION.ToString();
            }
        }

        private void ListarServicios()
        {

            var listaServicios = servicioDAO.listarServicio("ACTIVO","");
            this.cboServicio.ItemsSource = listaServicios;
            this.cboServicio.DisplayMemberPath = "DESCRIPCION";
            this.cboServicio.SelectedValuePath = "COD_SERV";


        }

        private DetalleContrato AgregarDetalles()
        {

            DetalleContrato detalle = new DetalleContrato();

            int codServicio = Convert.ToInt32(this.cboServicio.SelectedValue);
            int cantidad = Convert.ToInt32(this.txtCantidad.Text);
            double precio = Convert.ToDouble(this.txtPrecio.Text);

            detalle.SERVICIO = servicioDAO.ObtenerServicio(codServicio);
            detalle.CANTIDAD = cantidad;
            detalle.PRECIO = precio;
            detalle.ITEM = item;
            detalle.IMPORTE = cantidad * precio;
            detalle.DIAS=1;
            VariablesGlobales.listaDetallesContrato.Add(detalle);


            item++;
            return detalle;
        }

        private  async void  btnAgregarDetalle_Click(object sender, RoutedEventArgs e)
        {
            
                if (this.cboServicio.SelectedItem != null && this.txtCantidad.Text.Trim() != "" && this.txtPrecio.Text.Trim() != "")
                {
                    var detalle = AgregarDetalles();
                    LlenarGrid(VariablesGlobales.listaDetallesContrato);
                    subtotal = subtotal + detalle.IMPORTE;


                    if (this.chkIgv.IsChecked == false)
                        igvMonto = subtotal * IGV;
                    else
                        igvMonto = 0;

                    total = subtotal + igvMonto;
                    this.txtSubtotal.Text = subtotal.ToString();
                    this.txtIgv.Text = igvMonto.ToString();
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

        private void cboServicio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int codServicio = Convert.ToInt32(this.cboServicio.SelectedValue);
            servicio = servicioDAO.ObtenerServicio(codServicio);
            this.txtPrecio.Text = servicio.PRECIO.ToString();
        }

        private void txtFechDevolucion_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            DateTime fechaEntrega = (DateTime)this.txtFechaEntrega.Value;
            DateTime fechaDevolucion = (DateTime)this.txtFechDevolucion.Value;

            TimeSpan ts = fechaDevolucion - fechaEntrega;
            int diferenciadias = ts.Days;
            txtDias.Text = ts.Days.ToString();

            
        }

        private void txtFechaEntrega_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            this.txtFechDevolucion.IsEnabled = true;
        }

        private void chkIgv_Checked(object sender, RoutedEventArgs e)
        {

            this.txtIgv.Text = "0.0";
            igvMonto = 0;
            this.txtTotal.Text = subtotal.ToString();
        }

        private void chkIgv_Unchecked(object sender, RoutedEventArgs e)
        {
            if (this.txtSubtotal.Text == this.txtTotal.Text)
            {
                igvMonto = subtotal * IGV;
                total = subtotal + igvMonto;
                this.txtIgv.Text = igvMonto.ToString();
                this.txtTotal.Text = total.ToString();
                this.txtSubtotal.Text = subtotal.ToString();

            }
        }

        private void chkCambiarNroContra_Checked(object sender, RoutedEventArgs e)
        {
            this.txtNroContrato.IsEnabled = true;

            this.txtNroContrato.Focus();
        }

        private async void btnEliminarDetalle_Click(object sender, RoutedEventArgs e)
        {
            if (this.dgvListado.SelectedIndex != -1)
            {
                var detalleContrato = this.dgvListado.SelectedItem as DetalleContrato;
                VariablesGlobales.listaDetallesContrato.RemoveAll(x => x.ITEM == detalleContrato.ITEM);
                item = 1;
                subtotal = 0;
                igvMonto = 0;
                foreach (var detalle in VariablesGlobales.listaDetallesContrato)
                {
                    detalle.ITEM = item;
                    subtotal = subtotal + detalle.IMPORTE;

                    if (this.chkIgv.IsChecked == false)
                        igvMonto = subtotal * IGV;
                    else
                        igvMonto = 0;

                    item++;
                }
                total = subtotal + igvMonto;
                this.txtSubtotal.Text = subtotal.ToString();
                this.txtIgv.Text = igvMonto.ToString();
                this.txtTotal.Text = total.ToString();
                LlenarGrid(VariablesGlobales.listaDetallesContrato);

            }
            else
            {
                await this.ShowMessageAsync("Error", "Seleccione un detalle");
            }
        }

        private void Importe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox t = (TextBox)sender;
                int cantidad = Convert.ToInt32(t.Text);

                var detalleContrato = this.dgvListado.SelectedItem as DetalleContrato;
                var detalleEncontrado = VariablesGlobales.listaDetallesContrato.Find(x => x.IMPORTE == detalleContrato.IMPORTE);
                detalleEncontrado.CANTIDAD = cantidad;
                detalleEncontrado.IMPORTE = cantidad * detalleEncontrado.DIAS * detalleEncontrado.PRECIO;

                subtotal = 0;
                igvMonto = 0;
                foreach (var detalle in VariablesGlobales.listaDetallesContrato)
                {

                    subtotal = subtotal + detalle.IMPORTE;

                    if (this.chkIgv.IsChecked == false)
                        igvMonto = subtotal * IGV;
                    else
                        igvMonto = 0;


                }
                total = subtotal + igvMonto;
                this.txtSubtotal.Text = subtotal.ToString();
                this.txtIgv.Text = igvMonto.ToString();
                this.txtTotal.Text = total.ToString();
                LlenarGrid(VariablesGlobales.listaDetallesContrato);




            }
        }

        private void Dias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox t = (TextBox)sender;
                int dias = Convert.ToInt32(t.Text);

                var detalleContrato = this.dgvListado.SelectedItem as DetalleContrato;
                var detalleEncontrado = VariablesGlobales.listaDetallesContrato.Find(x => x.ITEM == detalleContrato.ITEM);
                detalleEncontrado.DIAS = dias;
                detalleEncontrado.IMPORTE = detalleEncontrado.CANTIDAD * dias * detalleEncontrado.PRECIO;

                subtotal = 0;
                igvMonto = 0;
                foreach (var detalle in VariablesGlobales.listaDetallesContrato)
                {

                    subtotal = subtotal + detalle.IMPORTE;

                    if (this.chkIgv.IsChecked == false)
                        igvMonto = subtotal * IGV;
                    else
                        igvMonto = 0;


                }
                total = subtotal + igvMonto;
                this.txtSubtotal.Text = subtotal.ToString();
                this.txtIgv.Text = igvMonto.ToString();
                this.txtTotal.Text = total.ToString();
                LlenarGrid(VariablesGlobales.listaDetallesContrato);




            }
        }

        private void AgregarContrato()
        {
            Contrato contrato = new Contrato();
            contrato.SUBTOTAL = subtotal;
            contrato.IGV = igvMonto;
            contrato.FECHA_CONTRATO = DateTime.Now;
            contrato.cliente = VariablesGlobales.clienteContrato;
            contrato.CHEQUE = this.txtCheque.Text;
            contrato.DIRECCION_OBRA = this.txtDireccionObra.Text;
            contrato.DOCUMENTO = this.txtDocumento.Text;
            contrato.FECHA_DEVOLUCION=Convert.ToDateTime(this.txtFechDevolucion.Value);
            contrato.FECHA_ENTREGA=Convert.ToDateTime(this.txtFechaEntrega.Value);
            contrato.GARANTIA=this.txtGarantia.Text==""?0:Convert.ToDouble(this.txtGarantia.Text);
            contrato.HORA_DEVOLUCION = TimeSpan.Parse(contrato.FECHA_DEVOLUCION.ToString("HH:mm:ss"));
            contrato.HORA_ENTREGA = TimeSpan.Parse(contrato.FECHA_ENTREGA.ToString("HH:mm:ss"));
            contrato.RECIBO = this.txtRecibo.Text;
            contrato.TOTAL_DIAS =Convert.ToInt32(this.txtDias.Text);
            contrato.DETALLECONTRATO = VariablesGlobales.listaDetallesContrato;
            contrato.MONEDA = ((ComboBoxItem)this.cboMoneda.SelectedItem).Content.ToString();
            contrato.usuario = usuarioDao.ObtenerUsuario(Convert.ToInt32(this.cboVendedor.SelectedValue));
            contrato.TRANSPORTE = this.txtTransporte.Text;
            if (chkCambiarNroFact.IsChecked == true)
            {
                contrato.NRO_CONTRATO = this.txtNroContrato.Text;
                Object[] result = contratoDao.AgregarConNroContrato(contrato);
                mensaje = result[1].ToString();
            }
            else
            {
                Object[] result = contratoDao.Agregar(contrato);
                mensaje = result[1].ToString();
            }


        }

        private void ListarUsuarios()
        {
            UsuarioDAO usuarioDao = new UsuarioDAO();

            var listaUsuarios = usuarioDao.ListarUsuarios("ACTIVO");
            this.cboVendedor.ItemsSource = listaUsuarios;
            this.cboVendedor.DisplayMemberPath = "NOMBRE_COMPLETO";
            this.cboVendedor.SelectedValuePath = "idUsuario";


        }

        private async void btnGenerarContrato_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.txtNroContrato.Text.Trim() != "" && this.cboVendedor.SelectedItem != null && this.cboMoneda.SelectedItem != null &&
             this.cboRazonsocial.SelectedItem != null && this.txtTransporte.Text.Trim() != "" && this.txtDireccionObra.Text.Trim() != ""
                    && this.txtDias.Text.Trim() != "" && this.cboTipoDocumento.SelectedItem != null)
                {
                    if (this.dgvListado.Items.Count == 0)
                    {
                        await this.ShowMessageAsync("Error", "Falta llenar detalles");
                    }
                    else
                    {
                        if (await this.ShowMessageAsync("Confirmacion", "¿Esta seguro de generar este contrato?", MessageDialogStyle.AffirmativeAndNegative) == MessageDialogResult.Affirmative)
                        {
                            AgregarContrato();
                            if (await this.ShowMessageAsync("Contrato Generado", "¿Desea IMPRIMIR el Contrato?", MessageDialogStyle.AffirmativeAndNegative) == MessageDialogResult.Affirmative)
                            {
                                Imprimir(this.txtNroContrato.Text);
                                VariablesGlobales.NRO_GUIA_GLOBAL = "";
                                VariablesGlobales.listaDetallesContrato.Clear();
                                VariablesGlobales.ClickFacturaContrato = false;

                                this.Close();
                            }
                            else
                            {
                                VariablesGlobales.NRO_GUIA_GLOBAL = "";
                                VariablesGlobales.listaDetallesContrato.Clear();
                                VariablesGlobales.ClickFacturaContrato = false;

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
                MessageBox.Show(ex.Message,"Error");
                VariablesGlobales.NRO_GUIA_GLOBAL = "";
              
            }
        }

        private void txtCancelar_Click(object sender, RoutedEventArgs e)
        {
            VariablesGlobales.listaDetallesBoleta.Clear();
            VariablesGlobales.listaDetallesFactura.Clear();
            VariablesGlobales.listaDetallesGuia.Clear();
            VariablesGlobales.listaDetallesContrato.Clear();
            VariablesGlobales.clienteFactura = null;
            VariablesGlobales.ClickFacturaContrato = false;

            this.Close();
        }

        private void LlenarGrid(List<DetalleContrato> detalles)
        {
            this.dgvListado.ItemsSource = null;
            this.dgvListado.ItemsSource = detalles;

        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            VariablesGlobales.ClickFacturaContrato = false;
            VariablesGlobales.ClickBoletaContrato = false;
            VariablesGlobales.ClickContratoBoleta = false;
            VariablesGlobales.ClickGuiaContrato = false;
        }

        private void ObtenerDatosFactura()
        {
            this.cboRazonsocial.DisplayMemberPath = "RAZON_SOCIAL";
            this.cboRazonsocial.SelectedValuePath = "COD_CLI";
            this.cboRazonsocial.SelectedIndex = VariablesGlobales.indexCliente;
            this.txtDireccion.Text = VariablesGlobales.clienteFactura == null ? "" : VariablesGlobales.clienteFactura.DIRECCION;
            this.txtTelf.Text = VariablesGlobales.clienteFactura == null ? "" : VariablesGlobales.clienteFactura.TEL_FIJO_OFICINA;
            DetalleContrato detalleContrato = null;
            VariablesGlobales.listaDetallesContrato.Clear();

            foreach (var detalle in VariablesGlobales.listaDetallesFactura)
            {
                detalleContrato = new DetalleContrato();
                detalleContrato.CANTIDAD = detalle.CANTIDAD;
                detalleContrato.SERVICIO = detalle.SERVICIO;
                detalleContrato.PRECIO = detalle.PRECIO;
                detalleContrato.ITEM = item;
                detalleContrato.IMPORTE = detalle.CANTIDAD * detalle.PRECIO;
                VariablesGlobales.listaDetallesContrato.Add(detalleContrato);
                subtotal = subtotal + detalleContrato.IMPORTE;
                item++;

            }
            igvMonto = subtotal * IGV;
            total = igvMonto + subtotal;
            LlenarGrid(VariablesGlobales.listaDetallesContrato);
            this.txtSubtotal.Text = subtotal.ToString();
            this.txtIgv.Text = igvMonto.ToString();
            this.txtTotal.Text = total.ToString();

            if (VariablesGlobales.clienteFactura != null)
            {
                if (VariablesGlobales.clienteFactura.TIPO_CLIE.Equals("NATURAL"))
                {
                    this.rbNATURAL.IsChecked = true;
                    this.txtDniRuc.Text = VariablesGlobales.clienteFactura.DNI;
                    this.txtDireccion.Text = VariablesGlobales.clienteFactura.DIRECCION;
                    this.txtTelf.Text = VariablesGlobales.clienteFactura.TEL_FIJO_CASA;
        
                }
                else
                {
                    this.rbJURIDICA.IsChecked = true;
                    this.txtDniRuc.Text = VariablesGlobales.clienteFactura.RUC;
                    this.txtDireccion.Text = VariablesGlobales.clienteFactura.DIRECCION;
                    this.txtTelf.Text = VariablesGlobales.clienteFactura.TEL_FIJO_OFICINA;
                }
            }
            
         
        }

        private void ObtenerDatosBoleta()
        {
            this.cboRazonsocial.DisplayMemberPath = "RAZON_SOCIAL";
            this.cboRazonsocial.SelectedValuePath = "COD_CLI";
            this.cboRazonsocial.SelectedIndex = VariablesGlobales.indexCliente;
            
           DetalleContrato detalleContrato = null;
           VariablesGlobales.listaDetallesContrato.Clear();

            foreach (var detalle in VariablesGlobales.listaDetallesBoleta)
            {
                detalleContrato = new DetalleContrato();
                detalleContrato.CANTIDAD = detalle.CANTIDAD;
                detalleContrato.SERVICIO = detalle.SERVICIO;
                detalleContrato.PRECIO = detalle.PRECIO;
                detalleContrato.ITEM = item;
                detalleContrato.IMPORTE = detalle.CANTIDAD * detalle.PRECIO;
                VariablesGlobales.listaDetallesContrato.Add(detalleContrato);
                subtotal = subtotal + detalleContrato.IMPORTE;
                item++;

            }
            igvMonto = subtotal * IGV;
            total = igvMonto + subtotal;
            LlenarGrid(VariablesGlobales.listaDetallesContrato);
            this.txtSubtotal.Text = subtotal.ToString();
            this.txtIgv.Text = igvMonto.ToString();
            this.txtTotal.Text = total.ToString();

            if (VariablesGlobales.indexCliente != -1)
            {
                if (VariablesGlobales.clienteBoleta != null)
                {
                    if (VariablesGlobales.clienteBoleta.TIPO_CLIE.Equals("NATURAL"))
                    {
                        this.rbNATURAL.IsChecked = true;
                        this.txtDniRuc.Text = VariablesGlobales.clienteBoleta.DNI;
                        this.txtDireccion.Text = VariablesGlobales.clienteBoleta.DIRECCION;
                        this.txtTelf.Text = VariablesGlobales.clienteBoleta.TEL_FIJO_CASA;

                    }
                    else
                    {
                        this.rbJURIDICA.IsChecked = true;
                        this.txtDireccion.Text = VariablesGlobales.clienteBoleta.DIRECCION;
                        this.txtTelf.Text = VariablesGlobales.clienteBoleta.TEL_FIJO_OFICINA;
                        this.txtDniRuc.Text = VariablesGlobales.clienteBoleta.RUC;
                    }
                }
            }
           

        }
        private void ObtenerDatosGuia()
        {
            this.cboRazonsocial.DisplayMemberPath = "RAZON_SOCIAL";
            this.cboRazonsocial.SelectedValuePath = "COD_CLI";
            this.cboRazonsocial.SelectedIndex = VariablesGlobales.indexCliente;

            DetalleContrato detalleContrato = null;
            VariablesGlobales.listaDetallesContrato.Clear();

            foreach (var detalle in VariablesGlobales.listaDetallesGuia)
            {
                detalleContrato = new DetalleContrato();
                detalleContrato.CANTIDAD = detalle.CANTIDAD;
                detalleContrato.SERVICIO = detalle.SERVICIO;
                detalleContrato.PRECIO = detalle.SERVICIO.PRECIO;
                detalleContrato.ITEM = item;
                detalleContrato.IMPORTE = detalle.CANTIDAD * detalle.SERVICIO.PRECIO;
                VariablesGlobales.listaDetallesContrato.Add(detalleContrato);
                subtotal = subtotal + detalleContrato.IMPORTE;
                item++;

            }
            igvMonto = subtotal * IGV;
            total = igvMonto + subtotal;
            LlenarGrid(VariablesGlobales.listaDetallesContrato);
            this.txtSubtotal.Text = subtotal.ToString();
            this.txtIgv.Text = igvMonto.ToString();
            this.txtTotal.Text = total.ToString();

            if (VariablesGlobales.indexCliente != -1)
            {
                if (VariablesGlobales.clienteGuia!= null)
                {
                    if (VariablesGlobales.clienteGuia.TIPO_CLIE.Equals("NATURAL"))
                    {
                        this.rbNATURAL.IsChecked = true;
                        this.txtDniRuc.Text = VariablesGlobales.clienteGuia.DNI;
                        this.txtDireccion.Text = VariablesGlobales.clienteGuia.DIRECCION;
                        this.txtTelf.Text = VariablesGlobales.clienteGuia.TEL_FIJO_CASA;

                    }
                    else
                    {
                        this.rbJURIDICA.IsChecked = true;
                        this.txtDireccion.Text = VariablesGlobales.clienteGuia.DIRECCION;
                        this.txtTelf.Text = VariablesGlobales.clienteGuia.TEL_FIJO_OFICINA;
                        this.txtDniRuc.Text = VariablesGlobales.clienteGuia.RUC;
                    }
                }
            }
        }


        private void btnCambiarFactura_Click(object sender, RoutedEventArgs e)
        {
            if (this.cboRazonsocial.SelectedIndex == -1)
            {
                VariablesGlobales.clienteContrato = null;
            }
            else
            {
                VariablesGlobales.indexCliente = this.cboRazonsocial.SelectedIndex;
            }
            VariablesGlobales.clickContratoFactura = true;
            frmFactura frmFactura = new frmFactura();
            this.Close();
            frmFactura.ShowDialog();
        }

        private void btnCambiarBoleta_Click(object sender, RoutedEventArgs e)
        {
            if (this.cboRazonsocial.SelectedIndex == -1)
            {
                VariablesGlobales.clienteContrato = null;
            }
            else
            {
                VariablesGlobales.indexCliente = this.cboRazonsocial.SelectedIndex;
            }
            VariablesGlobales.ClickContratoBoleta = true;
            FrmBoleta frmBoleta = new FrmBoleta();
            this.Close();
            frmBoleta.ShowDialog();
        }

        private void btnCambiarGuia_Click(object sender, RoutedEventArgs e)
        {
            if (this.cboRazonsocial.SelectedIndex == -1)
            {
                VariablesGlobales.clienteContrato = null;
            }
            else
            {
                VariablesGlobales.indexCliente = this.cboRazonsocial.SelectedIndex;
            }
            VariablesGlobales.ClickContratoGuia = true;
            FrmGuiaRemision frmGuia = new FrmGuiaRemision();
            this.Close();
            frmGuia.ShowDialog();
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;          
            else
                e.Handled = true;
        }
      
    }
}
