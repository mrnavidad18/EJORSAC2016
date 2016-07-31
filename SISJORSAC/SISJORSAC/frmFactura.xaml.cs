﻿using System;
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
using System.Data.SqlClient;

namespace SISJORSAC
{
    /// <summary>
    /// Lógica de interasdsdcción para frmFactura.xaml
    /// </summary>
    public partial class frmFactura : MetroWindow
    {
       
        Cliente cliente;
        Servicio servicio;
        GuiaRemision guiaRemision;
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
        public frmFactura()
        {
            InitializeComponent();
           
            this.txtFechaEmision.Text = DateTime.Now.ToString();
            this.txtNroFactura.Text =facturaDao.ObtenerNroFactura().ToString();
            ListarClientes();
          
            ListarServicios();
            if (VariablesGlobales.ClickFacturaConGuia)
            {
                ObtenerGuia();

            }
            if (VariablesGlobales.ClickBoletaFactura)
            {
                ObtenerDatosBoleta();
            }
        }


        private  async void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            
                if (this.cboServicio.SelectedItem != null && this.txtCantidad.Text.Trim() != "" && this.txtPrecio.Text.Trim() != "")
                {
                    var detalle = AgregarDetalles();
                    this.dgvListado.ItemsSource = null;
                    dgvListado.ItemsSource = VariablesGlobales.listaDetallesFactura;
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
                    this.cboServicio.SelectedIndex = 0;
                }
                else
                {
                    await this.ShowMessageAsync("Error", "Falta llenar algunos campos");
                }
             
            
        

          
           
        }


        private void AgregarFactura()
        {
            Factura factura = new Factura();
          

            factura.MODALIDAD = ((ComboBoxItem)this.cboModalidad.SelectedItem).Content.ToString();
            
            factura.SUB_TOTAL = subtotal;
            factura.IGV = igvMonto;
            factura.FECHA_EMISION = DateTime.Now;
            factura.cliente = cliente;
            if (this.txtNroGuia.Text == "")
            {
                factura.guiaRemision = null;
            }
            else
            {

                factura.guiaRemision = guiaRemision;
            }
            
            factura.DETALLEFACTURA = VariablesGlobales.listaDetallesFactura;
            factura.OBSERVACION = this.txtObservacion.Text;
            if (chkCambiarNroFact.IsChecked == true)
            {
                factura.NRO_FACTURA = this.txtNroFactura.Text;
               Object[] result= facturaDao.AgregarFacturaConNroFac(factura);
               mensaje = result[1].ToString();
            }
            else
            {
                Object[] result = facturaDao.AgregarFactura(factura);
                mensaje = result[1].ToString();
            }
            

        }

        private DetalleFactura AgregarDetalles()
        {
            
            DetalleFactura detalle = new DetalleFactura();
            
            int codServicio = Convert.ToInt32(this.cboServicio.SelectedValue);
            int cantidad = Convert.ToInt32(this.txtCantidad.Text);
            double precio = Convert.ToDouble(this.txtPrecio.Text);

            detalle.SERVICIO = servicioDAO.ObtenerServicio(codServicio);
            detalle.CANTIDAD = cantidad;
            detalle.PRECIO = precio;
            detalle.ITEM = item;
            detalle.IMPORTE = cantidad * precio;
            VariablesGlobales.listaDetallesFactura.Add(detalle);

      
            item++;
            return detalle;
        }

        private void ListarClientes()
        {
            
            var listacliente = clienteDao.ListarCliente("JURIDICA");
            
            this.cboRazonsocial.ItemsSource = listacliente;
            this.cboRazonsocial.DisplayMemberPath="RAZON_SOCIAL";
            this.cboRazonsocial.SelectedValuePath = "COD_CLI";
       

           
        }

        private void ListarServicios()
        {

            var listaServicios = servicioDAO.listarServicio("DISPONIBLE");
            this.cboServicio.ItemsSource = listaServicios;
            this.cboServicio.DisplayMemberPath = "DESCRIPCION";
            this.cboServicio.SelectedValuePath = "COD_SERV";


        }

        private void cboRazonsocial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int codCliente=Convert.ToInt32(this.cboRazonsocial.SelectedValue);
           
            cliente = clienteDao.ObtenerCliente(codCliente);
            VariablesGlobales.clienteFactura = cliente;
            this.txtDireccion.Text = cliente.DIRECCION;
            this.txtRuc.Text = cliente.RUC;
        }

        private void cboServicio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int codServicio = Convert.ToInt32(this.cboServicio.SelectedValue);
            servicio = servicioDAO.ObtenerServicio(codServicio);
            this.txtPrecio.Text = servicio.PRECIO.ToString();
        }
       
        private async void btnGenerarFactura_Click(object sender, RoutedEventArgs e)
        { 
            try
            {
                if (this.txtNroFactura.Text.Trim() != "" && this.cboModalidad.SelectedItem != null && this.cboMoneda.SelectedItem != null &&
             this.cboRazonsocial.SelectedItem != null)
                {
                    if (this.dgvListado.Items.Count == 0)
                    {
                        await this.ShowMessageAsync("Error", "Falta llenar detalles");
                    }
                    else
                    {
                        if (await this.ShowMessageAsync("Confirmacion", "¿Esta seguro de generar esta factura?", MessageDialogStyle.AffirmativeAndNegative) == MessageDialogResult.Affirmative)
                        {
                            AgregarFactura();
                            string nrofactura = this.txtNroFactura.Text;
                            ImprimirFactura frmimprimir = new ImprimirFactura();
                            frmimprimir.nro_factura = nrofactura;
                            await this.ShowMessageAsync(mensaje,"Factura Generada Correctamente");
                            VariablesGlobales.NRO_GUIA_GLOBAL = "";
                            VariablesGlobales.clienteFactura = null;
                            VariablesGlobales.listaDetallesFactura = null;
                            this.Close();
                            frmimprimir.ShowDialog();
                           
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

        public void ObtenerGuia()
        {
            if (VariablesGlobales.NRO_GUIA_GLOBAL != "")
            {
                DetalleGuiaRemisionDAO detalleGuiaDao = new DetalleGuiaRemisionDAO();
                guiaRemision = guiaDao.ObtenerGuiaRemisionXNroGuia(VariablesGlobales.NRO_GUIA_GLOBAL);
                VariablesGlobales.clienteFactura = guiaRemision.cliente;
                var listaDetalleGuia = detalleGuiaDao.listarDetalleGuiaxGuia(guiaRemision.COD_GUIA);
                if (guiaRemision.cliente.TIPO_CLIE.Equals("JURIDICA"))
                {

                    //VariablesGlobales.indexCliente = this.cboRazonsocial.SelectedIndex;
                    this.cboRazonsocial.Text = guiaRemision.cliente.RAZON_SOCIAL;

                    this.txtRuc.Text = guiaRemision.cliente.RUC;
                }
                //this.cboRazonsocial.DisplayMemberPath = "RAZON_SOCIAL";
                //this.cboRazonsocial.SelectedValuePath = "COD_CLI";

                //this.cboRazonsocial.Items.Add(guiaRemision.cliente);
                //this.cboRazonsocial.SelectedIndex = 0;

                //this.txtRuc.Text = guiaRemision.cliente.RUC;
                this.txtNroGuia.Text = VariablesGlobales.NRO_GUIA_GLOBAL.ToString();
                this.cboModalidad.Items.Clear();
                ComboBoxItem itemModalidad = new ComboBoxItem();
                itemModalidad.Content = guiaRemision.TIPO_TRASLADO;
                this.cboModalidad.Items.Add(itemModalidad);

                this.cboModalidad.SelectedIndex = 0;

                this.cboModalidad.IsEnabled = false;
                DetalleFactura detalleFactura = null;
                VariablesGlobales.listaDetallesFactura.Clear();
                foreach (var detalle in listaDetalleGuia)
                {
                    detalleFactura = new DetalleFactura();
                    detalleFactura.CANTIDAD = detalle.CANTIDAD;
                    detalleFactura.SERVICIO = detalle.SERVICIO;
                    detalleFactura.PRECIO = detalle.SERVICIO.PRECIO;
                    detalleFactura.ITEM = item;
                    detalleFactura.IMPORTE = detalle.CANTIDAD * detalle.SERVICIO.PRECIO;
                    VariablesGlobales.listaDetallesFactura.Add(detalleFactura);



                    subtotal = subtotal + detalleFactura.IMPORTE;
                    item++;

                }

                this.dgvListado.ItemsSource = VariablesGlobales.listaDetallesFactura;

                igvMonto = subtotal * IGV;
                total = subtotal + igvMonto;

                this.txtSubtotal.Text = subtotal.ToString();
                this.txtIgv.Text = igvMonto.ToString();
                this.txtTotal.Text = total.ToString();
           

          
            }
            

        }

        private void txtCancelar_Click(object sender, RoutedEventArgs e)
        {
            VariablesGlobales.NRO_GUIA_GLOBAL = "";
            VariablesGlobales.clienteFactura=null;
            VariablesGlobales.listaDetallesFactura.Clear();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void chkObservacion_Checked(object sender, RoutedEventArgs e)
        {
            this.txtObservacion.IsEnabled = true;
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

        private void chkCambiarNroFact_Checked(object sender, RoutedEventArgs e)
        {
            this.txtNroFactura.IsEnabled = true;
            
            this.txtNroFactura.Focus();
        }

        private async void btnEliminarDetalle_Click(object sender, RoutedEventArgs e)
        {
            if(this.dgvListado.SelectedIndex != -1)
            {
                var detalleFactura = this.dgvListado.SelectedItem as DetalleFactura;
                VariablesGlobales.listaDetallesFactura.RemoveAll(x => x.ITEM==detalleFactura.ITEM);
                item=1;
                subtotal = 0;
                igvMonto = 0;
                foreach (var detalle in VariablesGlobales.listaDetallesFactura)
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
                this.dgvListado.ItemsSource = null;
                dgvListado.ItemsSource = VariablesGlobales.listaDetallesFactura;

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

                var detalleFactura = this.dgvListado.SelectedItem as DetalleFactura;
                var detalleEncontrado = VariablesGlobales.listaDetallesFactura.Find(x => x.ITEM == detalleFactura.ITEM);
                detalleEncontrado.CANTIDAD = cantidad;
                detalleEncontrado.IMPORTE = cantidad * detalleEncontrado.PRECIO;

                subtotal = 0;
                igvMonto = 0;
                foreach (var detalle in VariablesGlobales.listaDetallesFactura)
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
                this.dgvListado.ItemsSource = null;
                dgvListado.ItemsSource = VariablesGlobales.listaDetallesFactura;



               
            }
        }

        private void btnCambiarBoleta_Click(object sender, RoutedEventArgs e)
        {
            VariablesGlobales.indexCliente = this.cboRazonsocial.SelectedIndex;
            VariablesGlobales.ClickFacturaBoleta = true;
            FrmBoleta frmBoleta = new FrmBoleta();
          
            this.Close();
            frmBoleta.ShowDialog();

        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            VariablesGlobales.ClickFacturaConGuia = false;
            VariablesGlobales.ClickBoletaFactura = false;

        }

        private void btnCambiarContrato_Click(object sender, RoutedEventArgs e)
        {
            VariablesGlobales.indexCliente = this.cboRazonsocial.SelectedIndex;
            VariablesGlobales.ClickFacturaContrato = true;
            FrmContratoAlquiler frmContrato = new FrmContratoAlquiler();
            this.Close();
            frmContrato.ShowDialog();
        }

        private void btnCambiarGuia_Click(object sender, RoutedEventArgs e)
        {
            VariablesGlobales.indexCliente = this.cboRazonsocial.SelectedIndex;
            VariablesGlobales.ClickFacturaGuia = true;
            FrmGuiaRemision frmGuia = new FrmGuiaRemision();
            this.Close();
            frmGuia.ShowDialog();
        }

        private void ObtenerDatosBoleta()
        {
           

            //this.txtRuc.Text = VariablesGlobales.clienteBoleta == null ? "" : VariablesGlobales.clienteBoleta.RUC;

            DetalleFactura detalleFactura = null;
            
            VariablesGlobales.listaDetallesFactura.Clear();

            foreach (var detalle in VariablesGlobales.listaDetallesBoleta)
            {
                detalleFactura = new DetalleFactura();
                detalleFactura.CANTIDAD = detalle.CANTIDAD;
                detalleFactura.SERVICIO = detalle.SERVICIO;
                detalleFactura.PRECIO = detalle.PRECIO;
                detalleFactura.ITEM = item;
                detalleFactura.IMPORTE = detalle.CANTIDAD * detalle.PRECIO;
                VariablesGlobales.listaDetallesFactura.Add(detalleFactura);
                subtotal = subtotal + detalleFactura.IMPORTE;
                item++;
            }

            igvMonto = subtotal * IGV;
            total = subtotal + igvMonto;

            this.dgvListado.ItemsSource=VariablesGlobales.listaDetallesFactura;
            this.txtNroGuia.Text = VariablesGlobales.NRO_GUIA_GLOBAL;
            this.txtSubtotal.Text = subtotal.ToString();
            this.txtIgv.Text = igvMonto.ToString();
            this.txtTotal.Text = total.ToString();

            if (VariablesGlobales.indexCliente != -1)
            {
                if (VariablesGlobales.clienteBoleta != null)
                {
                    if (VariablesGlobales.clienteBoleta.TIPO_CLIE.Equals("JURIDICA"))
                    {
                        this.cboRazonsocial.SelectedIndex = VariablesGlobales.indexCliente;
                        this.txtRuc.Text = VariablesGlobales.clienteBoleta.RUC;
                        this.txtDireccion.Text = VariablesGlobales.clienteBoleta.DIRECCION;
                    }

                }
            }
           
        }

        private void LlenarGrid(List<DetalleFactura> list)
        {
            this.dgvListado.ItemsSource = null;
            dgvListado.ItemsSource = list;
        }
       
    }
}
