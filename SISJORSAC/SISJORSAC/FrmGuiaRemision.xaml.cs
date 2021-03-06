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
using SISJORSAC.Reportes;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace SISJORSAC
{
    /// <summary>
    /// Lógica de interacción para FrmGuiaRemision.xaml
    /// </summary>
    public partial class FrmGuiaRemision : MetroWindow
    {

        int stockGlobal = 0;
        int cantidadGlobal = 0;
        UbigeoDAO ubigeoDAO = new UbigeoDAO();
        ClienteDAO clienteDAO = new ClienteDAO();
        GuiaRemisionDAO guiaDAO = new GuiaRemisionDAO();
        ServicioDAO servicioDAO = new ServicioDAO();
        ChoferDAO choferDao = new ChoferDAO();
        string mensaje = "";
        string nuevoid = "";
        int item = 1;
        string nuevoidProvincia = "";
        public FrmGuiaRemision()
        {
            InitializeComponent();
            this.cboTipoTraslado.SelectedIndex = 2;
            this.txtPtoPartida.Text = "Av. SANTIAGO DE SURCO 4676 - URB. SAN ROQUE, SURCO";
            this.txtFechaEmision.Text = DateTime.Now.ToString();
            string nroGuia =guiaDAO.traerUltimoNroGuia();
            llenarDepartamentos();
            this.txtNroGuiaRemision.Text = nroGuia;
            Listarservicios("ACTIVO");
            this.cboCliente.IsEnabled = false;
            ListarChofer();
            if (VariablesGlobales.ClickFacturaGuia)
            {
                ObtenerDatosFactura();
            }
            if (VariablesGlobales.ClickBoletaGuia)
            {
                ObtenerDatosBoleta();
            }
            if (VariablesGlobales.ClickContratoGuia)
            {
                ObtenerDatosContrato();
            }
        }

        private void Imprimir(string numeroGuia)
        {
            FrmGuiaImprimirViewer ventana = new FrmGuiaImprimirViewer();
            ReportDocument doc = new ReportDocument();
            ParameterField parameter = new ParameterField();
            ParameterFields parameters = new ParameterFields();
            ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            parameter.Name = "@P_NRO_GUIA";
            pdv.Value = numeroGuia;
            parameter.CurrentValues.Add(pdv);
            parameters.Add(parameter);
            ventana.crystalReportViewer1.ParameterFieldInfo = parameters;
            //string fullPath = System.IO.Path.GetFullPath("FacturaImprimir.rpt").Replace("\\bin\\Debug","\\Reportes");
            doc.Load(@"C:\Program Files (x86)\SISJORSAC\Reportes\GuiaReporte.rpt");
            ventana.crystalReportViewer1.ReportSource = doc;
            ventana.ShowDialog();
        }
        private void ListarChofer()
        {
            var lista = choferDao.Listar("");
            this.cboChofer.ItemsSource = lista;
            this.cboChofer.DisplayMemberPath = "NOMBRE_COMPLETO";
            this.cboChofer.SelectedValuePath = "COD_CHOFER";
            this.cboChofer.SelectedIndex = 0;
        }

       
        private void Listarservicios(string estado)
        {
            var listaServicios = servicioDAO.listarServicio(estado,"");
            this.cboServicio.ItemsSource = listaServicios;
            this.cboServicio.DisplayMemberPath = "DESCRIPCION";
            this.cboServicio.SelectedValuePath = "COD_SERV";
            this.cboServicio.SelectedIndex = 0;
        }

        private void ListarClientes(string tipoCliente)
        {
            var listacliente = clienteDAO.ListarCliente(tipoCliente);
            this.cboCliente.ItemsSource = listacliente;
            if(tipoCliente.Equals("JURIDICA")){
            this.cboCliente.DisplayMemberPath = "RAZON_SOCIAL";
            this.cboCliente.SelectedValuePath = "COD_CLI";
            }
            else { 
             this.cboCliente.DisplayMemberPath = "NOMBRES";
            this.cboCliente.SelectedValuePath = "COD_CLI";
            }
        }

        private void rbNATURAL_Checked(object sender, RoutedEventArgs e)
        {
            this.txtDNIRUC.Text = "";
            this.lblDNIRUC.Content = "DNI:";
            this.cboCliente.IsEnabled = true;
            ListarClientes(rbNATURAL.Content.ToString());
           
            
        }

        private void rbJURIDICA_Checked(object sender, RoutedEventArgs e)
        {
            this.txtDNIRUC.Text= "";
            this.lblDNIRUC.Content = "RUC:";
            this.cboCliente.IsEnabled = true;
            ListarClientes(rbJURIDICA.Content.ToString());            
            
        }

        private void cboCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboCliente.SelectedIndex == -1)
            {

            }
            else {
                VariablesGlobales.indexCliente = this.cboCliente.SelectedIndex;
            int codCliente = Convert.ToInt32(this.cboCliente.SelectedValue);
            VariablesGlobales.clienteGuia = clienteDAO.ObtenerCliente(codCliente);
            if (VariablesGlobales.clienteGuia.TIPO_CLIE.Equals("NATURAL"))
            {
                this.txtDNIRUC.Text = VariablesGlobales.clienteGuia.DNI;                
            }
            else
            {               
                this.txtDNIRUC.Text = VariablesGlobales.clienteGuia.RUC;
            }
            }
            
        }


        private void llenarDepartamentos()
        {
            var listaDepartamentos = ubigeoDAO.llenarDepartamentos();
            this.cboDepartamento.ItemsSource = listaDepartamentos;
            this.cboDepartamento.DisplayMemberPath = "Departamento";
            this.cboDepartamento.SelectedValuePath = "IdUbigeo";           
        }

        private void llenarProvincias(string idprovincia)
        {
            var listaProvincias = ubigeoDAO.llenarProvincias(idprovincia);
            this.cboProvincia.ItemsSource = listaProvincias;
            this.cboProvincia.DisplayMemberPath = "Provincia";
            this.cboProvincia.SelectedValuePath = "IdUbigeo";
        }

        private void llenarDistritos(string idprovincia,string idDepartamento)
        {
            var listaDistritos = ubigeoDAO.llenarDistritos(idprovincia,idDepartamento);
            this.cboDistrito.ItemsSource = listaDistritos;
            this.cboDistrito.DisplayMemberPath = "Distrito";
            this.cboDistrito.SelectedValuePath = "IdUbigeo";
        }

        private void cboDepartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string idDepartamento =this.cboDepartamento.SelectedValue.ToString();
          //  string nuevoid =  Mid(idDepartamento, 1, 2);
            nuevoid = idDepartamento.Substring(0, 2);
           llenarProvincias(nuevoid);
            
        }

        private void cboProvincia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboProvincia.SelectedIndex == -1)
            {

            }
            else
            {
                string idProvincia = this.cboProvincia.SelectedValue.ToString();
                string hola = nuevoid;
                nuevoidProvincia = idProvincia.Substring(2, 2);
                llenarDistritos(nuevoid, nuevoidProvincia);
            }
          
        }

        //private DetalleGuiaRemision AgregarDetallesGuiaButton()
        //{
        //    DetalleGuiaRemision detalle = new DetalleGuiaRemision();
            
        //    int codServicio = Convert.ToInt32(this.cboServicio.SelectedValue);
        //    int cantidad = Convert.ToInt32(this.txtCantidadServicio.Text);
        //    double precio = Convert.ToDouble(this.txtPrecioServicio.Text);

        //    detalle.SERVICIO = servicioDAO.ObtenerServicio(codServicio);
        //    detalle.CANTIDAD = cantidad;
        //    detalle.ITEM = item;
                 
        //    VariablesGlobales.listaDetallesGuia.Add(detalle);

        //    item++;
        //    return detalle;
        
        //}

        private void cboServicio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var servicio = servicioDAO.ObtenerServicio(int.Parse(cboServicio.SelectedValue.ToString()));
            this.txtPrecioServicio.Text = servicio.PRECIO.ToString();
            this.txtMiStock.Text = servicio.STOCK.ToString();
        }

        private async void btnAgragarDetalle_Click(object sender, RoutedEventArgs e)
        {
            if (this.txtCantidadServicio.Text.Trim() != "" && this.cboServicio.SelectedItem!=null && this.txtPrecioServicio.Text.Trim()!="" && txtMiStock.Text.Trim()!="")
            {
                DetalleGuiaRemision detalle = new DetalleGuiaRemision();

                int codServicio = Convert.ToInt32(this.cboServicio.SelectedValue);
                int cantidad = Convert.ToInt32(this.txtCantidadServicio.Text);
                double precio = Convert.ToDouble(this.txtPrecioServicio.Text);

                detalle.SERVICIO = servicioDAO.ObtenerServicio(codServicio);
                detalle.CANTIDAD = cantidad;
                detalle.ITEM = item;                
                if (detalle.SERVICIO.STOCK >= detalle.CANTIDAD)
                {
                    detalle.SERVICIO.STOCK = detalle.SERVICIO.STOCK - detalle.CANTIDAD;
                }
                else
                {
                    await this.ShowMessageAsync("Error", "La cantidad excede el stock");
                    return;
                }
                cantidadGlobal = cantidad;
                VariablesGlobales.listaDetallesGuia.Add(detalle);
                LlenarGrid(VariablesGlobales.listaDetallesGuia);
                stockGlobal = int.Parse(txtMiStock.Text);
                txtMiStock.Text = string.Empty;
                txtCantidadServicio.Text = 1.ToString();
                item++;
                
            }
            else
            {
                await this.ShowMessageAsync("Error", "Falta llenar algunos campos");
               
            }

            
        }

        private void agregarGuiaRemision()
        {
            
            GuiaRemision guiaRemision = new GuiaRemision();
            guiaRemision.PTO_PARTIDA = this.txtPtoPartida.Text;
            guiaRemision.PTO_LLEGADA = this.txtptoLlegada.Text;
            guiaRemision.FECHA_EMISION =Convert.ToDateTime(this.txtFechaEmision.Text);
            guiaRemision.cliente = VariablesGlobales.clienteGuia;
            guiaRemision.CHOFER = choferDao.obtenerChofer(int.Parse(this.cboChofer.SelectedValue.ToString()));
            
            //transportista:
            guiaRemision.NOMB_TRANSPORTE = this.txtNombreTransporte.Text;
            guiaRemision.RUC_TRANSPORTE = this.txtRUC.Text.Trim();
            guiaRemision.TIPO_TRASLADO = ((ComboBoxItem)cboTipoTraslado.SelectedItem).Content.ToString();
            guiaRemision.MTO_TRASLADO = this.txtMotivoTraslado.Text;
            //Direcciones:
            guiaRemision.DEPARTAMENTO = cboDepartamento.Text.ToString();
            guiaRemision.PROVINCIA = cboProvincia.Text.ToString();
            guiaRemision.DISTRITO = cboDistrito.Text.ToString();
            guiaRemision.SITUACION = "GENERADA";
            guiaRemision.DETALLEGUIAREMISION = VariablesGlobales.listaDetallesGuia;
            //tipo
            guiaRemision.TIPO_COMPROB = "FACTURA";
            if (this.chkCambiarNroGuia.IsChecked == true)
            {
                guiaRemision.NRO_GUIA = this.txtNroGuiaRemision.Text;
                Object[] result = guiaDAO.AgregarConNroGuia(guiaRemision);
                mensaje = result[1].ToString();
            }
            else
            {
                Object[] result = guiaDAO.Agregar(guiaRemision);
                mensaje = result[1].ToString();
            }
           
        }

        private async void btnAgregarGuiaFinal_Click(object sender, RoutedEventArgs e)
        {
            if (this.dgvDetalleGuia.Items.Count == 0)
            {
                await this.ShowMessageAsync("Error","Falta agregar detalles");
            }
            else
            {
                if (txtptoLlegada.Text.Trim()!="" && cboChofer.SelectedItem != null && cboTipoTraslado.SelectedItem!=null && cboDistrito.SelectedItem!=null
                    && cboProvincia.SelectedItem!=null && cboDepartamento.SelectedItem!=null)
                {
                    if (await this.ShowMessageAsync("Confirmacion", "¿Esta seguro de generar esta Guía?", MessageDialogStyle.AffirmativeAndNegative) == MessageDialogResult.Affirmative)
                    {
                        agregarGuiaRemision();
                       
                        VariablesGlobales.NRO_GUIA_GLOBAL = "";
                        VariablesGlobales.clienteFactura = null;
                        VariablesGlobales.listaDetallesFactura.Clear();
                        VariablesGlobales.listaDetallesGuia.Clear();
                        VariablesGlobales.ClickFacturaGuia = false;
                        VariablesGlobales.ClickBoletaGuia = false;
                        if (await this.ShowMessageAsync("Guia Generada", "¿Deseas Imrimir la Guia?", MessageDialogStyle.AffirmativeAndNegative) == MessageDialogResult.Affirmative)
                        {
                            Imprimir(this.txtNroGuiaRemision.Text);
                            this.Close();
                        }
                        else
                        {
                            this.Close();
                        }
                       
                    }
                }
                else
                {
                    await this.ShowMessageAsync("Error", "Falta llenar algunos campos");
                }
              
               
            }
          
        }

        public void ObtenerDatosFactura()
        {
            this.cboCliente.DisplayMemberPath = "RAZON_SOCIAL";
            this.cboCliente.SelectedValuePath = "COD_CLI";
            this.cboCliente.SelectedIndex = VariablesGlobales.indexCliente;
         
            this.txtDNIRUC.Text = VariablesGlobales.clienteFactura == null ? "" : VariablesGlobales.clienteFactura.RUC;

            DetalleGuiaRemision detalleGuia = null;

            VariablesGlobales.listaDetallesGuia.Clear();
            foreach (var detalle in VariablesGlobales.listaDetallesFactura)
            {
                detalleGuia = new DetalleGuiaRemision();
                detalleGuia.CANTIDAD = detalle.CANTIDAD;
                detalleGuia.SERVICIO = detalle.SERVICIO;
                detalleGuia.ITEM = item;
                VariablesGlobales.listaDetallesGuia.Add(detalleGuia);
                item++;

            }

            LlenarGrid(VariablesGlobales.listaDetallesGuia);

            if (VariablesGlobales.clienteFactura != null)
            {
                if (VariablesGlobales.clienteFactura.TIPO_CLIE.Equals("NATURAL"))
                {
                    this.rbNATURAL.IsChecked = true;
                    this.txtDNIRUC.Text = VariablesGlobales.clienteFactura.DNI;
                }
                else
                {
                    this.rbJURIDICA.IsChecked = true;
                    this.txtDNIRUC.Text = VariablesGlobales.clienteFactura.RUC;
                }
            }


        }

        private void ObtenerDatosBoleta()
        {
            this.cboCliente.DisplayMemberPath = "RAZON_SOCIAL";
            this.cboCliente.SelectedValuePath = "COD_CLI";
            this.cboCliente.SelectedIndex = VariablesGlobales.indexCliente;

            DetalleGuiaRemision detalleGuia = null;
            VariablesGlobales.listaDetallesGuia.Clear();

            foreach (var detalle in VariablesGlobales.listaDetallesBoleta)
            {
                detalleGuia = new DetalleGuiaRemision();
                detalleGuia.CANTIDAD = detalle.CANTIDAD;
                detalleGuia.SERVICIO = detalle.SERVICIO;
                detalleGuia.ITEM = item;
                VariablesGlobales.listaDetallesGuia.Add(detalleGuia);
                item++;

            }

            LlenarGrid(VariablesGlobales.listaDetallesGuia);

            if (VariablesGlobales.clienteBoleta!= null)
            {
                if (VariablesGlobales.clienteBoleta.TIPO_CLIE.Equals("NATURAL"))
                {
                    this.rbNATURAL.IsChecked = true;
                    this.txtDNIRUC.Text = VariablesGlobales.clienteBoleta.DNI;
                }
                else
                {
                    this.rbJURIDICA.IsChecked = true;
                    this.txtDNIRUC.Text = VariablesGlobales.clienteBoleta.RUC;
                }
            }
        }

        private void ObtenerDatosContrato()
        {

            this.cboCliente.DisplayMemberPath = "RAZON_SOCIAL";
            this.cboCliente.SelectedValuePath = "COD_CLI";
            this.cboCliente.SelectedIndex = VariablesGlobales.indexCliente;

            DetalleGuiaRemision detalleGuia = null;
            VariablesGlobales.listaDetallesGuia.Clear();

            foreach (var detalle in VariablesGlobales.listaDetallesContrato)
            {
                detalleGuia = new DetalleGuiaRemision();
                detalleGuia.CANTIDAD = detalle.CANTIDAD;
                detalleGuia.SERVICIO = detalle.SERVICIO;
                detalleGuia.ITEM = item;
                VariablesGlobales.listaDetallesGuia.Add(detalleGuia);
                item++;

            }

            LlenarGrid(VariablesGlobales.listaDetallesGuia);

            if (VariablesGlobales.clienteContrato != null)
            {
                if (VariablesGlobales.clienteContrato.TIPO_CLIE.Equals("NATURAL"))
                {
                    this.rbNATURAL.IsChecked = true;
                    this.txtDNIRUC.Text = VariablesGlobales.clienteContrato.DNI;
                }
                else
                {
                    this.rbJURIDICA.IsChecked = true;
                    this.txtDNIRUC.Text = VariablesGlobales.clienteContrato.RUC;
                }
            }
        }

        public void LlenarGrid(List<DetalleGuiaRemision> detalle)
        {
            this.dgvDetalleGuia.ItemsSource = null;
            this.dgvDetalleGuia.ItemsSource = detalle;
        }

        private  void Importe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox t = (TextBox)sender;
                int cantidad = Convert.ToInt32(t.Text);
                
                var detalleGuia = this.dgvDetalleGuia.SelectedItem as DetalleGuiaRemision;
                DetalleGuiaRemision detalleEncontrado = null;
                detalleEncontrado = VariablesGlobales.listaDetallesGuia.Find(x => x.ITEM == detalleGuia.ITEM);
                if (stockGlobal >= cantidad)
                {
                    detalleEncontrado.SERVICIO.STOCK = stockGlobal - cantidad;
                    detalleEncontrado.CANTIDAD = cantidad;
                    cantidadGlobal = cantidad;
                    LlenarGrid(VariablesGlobales.listaDetallesGuia);
                }
                else
                {
                    detalleEncontrado.CANTIDAD = cantidadGlobal;                                        
                    LlenarGrid(VariablesGlobales.listaDetallesGuia);
                    MessageBox.Show("La cantidad excede el stock...");
                    return;
                }                                                


            }
        }

        private void btnCancelarGuia_Click(object sender, RoutedEventArgs e)
        {
            VariablesGlobales.NRO_GUIA_GLOBAL = "";
            VariablesGlobales.clienteFactura = null;
            VariablesGlobales.listaDetallesFactura.Clear();
            VariablesGlobales.listaDetallesBoleta.Clear();
            VariablesGlobales.listaDetallesContrato.Clear();
            VariablesGlobales.ClickFacturaGuia = false;
            VariablesGlobales.listaDetallesGuia.Clear();
            this.Close();
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
          
            VariablesGlobales.ClickFacturaGuia = false;
            VariablesGlobales.ClickBoletaGuia = false;
            VariablesGlobales.ClickContratoGuia = false;
            VariablesGlobales.ClickGuiaFactura = false;
            VariablesGlobales.ClickGuiaContrato = false;
            VariablesGlobales.ClickGuiaBoleta = false;
           
        }

        private void btnCambiarFactura_Click(object sender, RoutedEventArgs e)
        {
            if (this.cboCliente.SelectedIndex == -1)
            {
                VariablesGlobales.clienteGuia = null;
            }
            else
            {
                VariablesGlobales.indexCliente = this.cboCliente.SelectedIndex;
            }
            VariablesGlobales.ClickGuiaFactura = true;
            frmFactura frmFactura = new frmFactura();
            this.Close();
            frmFactura.ShowDialog();
        }

        private void btnCambiarContrato_Click(object sender, RoutedEventArgs e)
        {
            if (this.cboCliente.SelectedIndex == -1)
            {
                VariablesGlobales.clienteGuia = null;
            }
            else
            {
                VariablesGlobales.indexCliente = this.cboCliente.SelectedIndex;
            }
            VariablesGlobales.ClickGuiaContrato = true;
            FrmContratoAlquiler frmContrato = new FrmContratoAlquiler();
            this.Close();
            frmContrato.ShowDialog();
        }

        private void btnCambiarBoleta_Click(object sender, RoutedEventArgs e)
        {
            if (this.cboCliente.SelectedIndex == -1)
            {
                VariablesGlobales.clienteGuia = null;
            }
            else
            {
                VariablesGlobales.indexCliente = this.cboCliente.SelectedIndex;
            }
            VariablesGlobales.ClickGuiaBoleta = true;
            FrmBoleta frmBoleta = new FrmBoleta();
            this.Close();
            frmBoleta.ShowDialog();
        }

        private void cboChofer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboChofer.SelectedIndex != -1)
            {
                int codigo = int.Parse(this.cboChofer.SelectedValue.ToString());
                var chofer = choferDao.obtenerChofer(codigo);
                this.txtNroBrevete.Text = chofer.NRO_BREVETE;
                this.txtNroCertificado.Text = chofer.NRO_CERTIFICADO;
                this.txtVehiculoMarca.Text = chofer.VEHICULO_MARCA_PLACA;
            }
           
        }

        private async void btnEliminarDet_Click(object sender, RoutedEventArgs e)
        {
           if(this.dgvDetalleGuia.SelectedIndex != -1)
            {
                var detalleguia = this.dgvDetalleGuia.SelectedItem as DetalleGuiaRemision;
                VariablesGlobales.listaDetallesGuia.RemoveAll(x => x.ITEM == detalleguia.ITEM);
                item=1;
               
                foreach (var detalle in VariablesGlobales.listaDetallesGuia)
                {
                    detalle.ITEM = item;
                   
                    item++;
                }
              
                
                LlenarGrid(VariablesGlobales.listaDetallesGuia);
            }
            else
            {
                await this.ShowMessageAsync("Error", "Seleccione un detalle");
            }
        }

        private void chkCambiarNroGuia_Checked(object sender, RoutedEventArgs e)
        {
            this.txtNroGuiaRemision.IsEnabled = true;
        }

      

    }
}
