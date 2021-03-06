﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SISJORSAC.DATA.DAO;
using SISJORSAC.DATA.Modelo;
using System.Collections.Generic;



namespace PruebasJORSAC.Test
{
    [TestClass]
    public class UnitTest1
    {

        UsuarioDAO usudao = new UsuarioDAO();
        

        [TestMethod]
        public void AgregarUsuarioTest()
        {

            Usuario usu = new Usuario();
            usu.Apellidos = "Huaman Meza";
            usu.DNI = "77446525";
            usu.clave = "AHYA";
            usu.Nombre = "RICARDO";
            usu.username = "huamanR";
           
               Assert.IsNotNull(usudao.Agregar(usu));
              
                
               
           
        }

         [TestMethod]
        public void agregarGuia()
        {

            GuiaRemisionDAO guiaDAO = new GuiaRemisionDAO();
            Servicio servicio = new Servicio
            {
                COD_SERV = 2
            };

            Cliente cliente = new Cliente
            {
                COD_CLI = 2
            };

            GuiaRemision guiaPrueba = new GuiaRemision();
            guiaPrueba.cliente = cliente;
            guiaPrueba.FECHA_EMISION = DateTime.Now;
            guiaPrueba.PTO_PARTIDA = "DANIEL GARCES 466";
            guiaPrueba.PTO_LLEGADA = "villa maria";
            guiaPrueba.VEHICULO_MARCA = "TOYOYA YARIS";
            guiaPrueba.NRO_CERTIFICADO = "123456789";
            guiaPrueba.NONBRE_CONDUCTOR = "juAN Manuel";
            guiaPrueba.NRO_BREVETE = "A123456789";
            guiaPrueba.NOMB_TRANSPORTE = "TRANSPORTE SAC";
            guiaPrueba.RUC_TRANSPORTE = "AB123456789";
            guiaPrueba.TIPO_COMPROB = "factura";
            guiaPrueba.TIPO_TRASLADO = "TIERRA";
            guiaPrueba.MTO_TRASLADO = "PRUEBAS XD";
            guiaPrueba.PROVINCIA = "LIMA";
            guiaPrueba.DEPARTAMENTO = "LIMA";
            guiaPrueba.DISTRITO = "SURCO";
            guiaPrueba.SITUACION = "PAGADO";


            DetalleGuiaRemision detalleprueba = new DetalleGuiaRemision();
            detalleprueba.SERVICIO = servicio;
            detalleprueba.ITEM = 4;
            detalleprueba.CANTIDAD = 20;

            List<DetalleGuiaRemision> listaDetalleGuia = new List<DetalleGuiaRemision>();
            listaDetalleGuia.Add(detalleprueba);

            guiaPrueba.DETALLEGUIAREMISION = listaDetalleGuia;

            
            Assert.IsNotNull(guiaDAO.Agregar(guiaPrueba));
        }

         [TestMethod]
        public void AgregarBoleta()
        {
            Servicio servicio = new Servicio {
                COD_SERV=1
            };

            Cliente cliente = new Cliente {
                COD_CLI=1
            };

            Boleta boleta = new Boleta ();
                boleta.cliente= cliente;
                boleta.ESTADO="DISPONIBLE";
                boleta.FECHA_EMISION=DateTime.Now;
               boleta.MODALIDAD="Venta";
               boleta.OBSERVACION = "DASDSADAS";
            

            DetalleBoleta detalle = new DetalleBoleta ();
               detalle.CANTIDAD=5;
                  detalle.ITEM=1;
                  detalle.SERVICIO=servicio;
                  detalle.PRECIO = 50;

                  DetalleBoleta detalle2 = new DetalleBoleta();
                  detalle2.CANTIDAD = 5;
                  detalle2.ITEM = 1;
                  detalle2.SERVICIO = servicio;
                  detalle2.PRECIO = 50;


                  List<DetalleBoleta> det = new List<DetalleBoleta>();
                  det.Add(detalle);
                  det.Add(detalle2);
                  boleta.DETALLEBOLETA = det;
                   boleta.TOTAL=0;
                  foreach (var item in det)
                  {
                      boleta.TOTAL = boleta.TOTAL + (item.CANTIDAD * item.PRECIO);
                  }

           

            BoletaDAO dao = new BoletaDAO();
            
            Assert.IsNotNull(dao.AgregarBoleta(boleta));

        }

         [TestMethod]
         public void Agregarservicio()
         {
             Servicio servi = new Servicio();
             servi.PRECIO = 2.5;
             
             servi.TIPO_MONE = "SOLES";
             servi.DESCRIPCION = "CORRIENTE";
             servi.PESO = 3.3;
             ServicioDAO SERVIDAO= new ServicioDAO();
             Assert.IsNotNull(SERVIDAO.Agregar(servi));

         }


        [TestMethod]
         public void AgregarProveedor()
         {
             ProveedorDAO proveDAO = new ProveedorDAO();
             Proveedor proveedor = new Proveedor();
             proveedor.NOMBRES = "";
             proveedor.AP_PATERNO = "";
             proveedor.AP_MATERNO = "";
             proveedor.DNI = "";
             proveedor.RUC = "AB123456789";
             proveedor.RAZON_SOCIAL = "TELEFONICA DEL PERÚ";
             proveedor.DIRECCION = "SAN ISIDRO CUADRA 12";
             proveedor.DEPARTAMENTO = "LIMA";
             proveedor.PROVINCIA = "LIMA";
             proveedor.DISTRITO = "SAN ISIDRO";
             proveedor.TELF_FIJO_CASA = "";
             proveedor.TELF_FIJO_OFICINA = "01 467 4499";
             proveedor.CELULAR = "";
             proveedor.EMAIL = "TELEFONICA@MOVISTAR.pe";
             proveedor.OBSERVACIONES = "empresa de mierda";
             proveedor.TIPO_PRO = "JURIDICA";

             Assert.IsNotNull( proveDAO.Agregar(proveedor));
               
         }

        [TestMethod]
        public void listarproveedores()
        {
            string tipoProveedor;
            tipoProveedor = "JURIDICA";
            ProveedorDAO PROVEDAO=new ProveedorDAO();
            var listado=PROVEDAO.ListarProveedor(tipoProveedor);
            Assert.IsTrue(listado.Count>0);


        }


        [TestMethod]
        public void listarClientes()
        {
            string tipocli;
            tipocli = "JURIDICA";
            ClienteDAO clienteDAO = new ClienteDAO();
            var listado = clienteDAO.ListarCliente(tipocli);
            Assert.IsTrue(listado.Count > 0);


        }

        [TestMethod]
        public void ActualizarBoleta()
        {
            BoletaDAO dao = new BoletaDAO();
            
            Servicio servicio = new Servicio
            {
                COD_SERV = 1
            };

            Cliente cliente = new Cliente
            {
                COD_CLI = 1
            };

            Boleta boleta = new Boleta();
            boleta.NRO_CP = 20;
            boleta.cliente = cliente;
            boleta.ESTADO = "DISPONIBLE";
            boleta.FECHA_EMISION = DateTime.Now;
            boleta.MODALIDAD = "Venta";
            boleta.OBSERVACION = "DASDSADAS";
            boleta.NRO_BOLETA = "000508";


            DetalleBoleta detalle = new DetalleBoleta();
            detalle.CANTIDAD = 2;
            detalle.ITEM = 1;
            detalle.SERVICIO = servicio;
            detalle.PRECIO = 50;
            detalle.COD_DETALLE = 14;
            detalle.BOLETA = boleta;

            DetalleBoleta detalle2 = new DetalleBoleta();
            detalle2.CANTIDAD = 2;
            detalle2.ITEM = 2;
            detalle2.SERVICIO = servicio;
            detalle2.PRECIO = 10;
            detalle2.COD_DETALLE = 15;
            detalle2.BOLETA = boleta;

          

            List<DetalleBoleta> det = new List<DetalleBoleta>();
            det.Add(detalle);
            det.Add(detalle2);
            boleta.DETALLEBOLETA = det;
            boleta.TOTAL = 0;


            



            DetalleBoleta detalle3 = new DetalleBoleta();
            detalle3.CANTIDAD = 3;
            detalle3.ITEM = 3;
            detalle3.SERVICIO = servicio;
            detalle3.PRECIO = 10;
            detalle3.BOLETA = boleta;

           

            int contador = 0;

            det.Add(detalle3);

            int CANTIDAD_ANTIGUA = det.Count;

            DetalleBoleta detalle4 = new DetalleBoleta();
            detalle4.CANTIDAD = 100;
            detalle4.ITEM = 3;
            detalle4.SERVICIO = servicio;
            detalle4.PRECIO = 100;
            detalle4.BOLETA = boleta;

            det.Add(detalle4);

            ///Usar esta logica en la vista
           

            foreach (var item in det)
            {
                if (contador < CANTIDAD_ANTIGUA)
                {
                    
                    boleta.TOTAL = boleta.TOTAL + (item.CANTIDAD * item.PRECIO);
                    dao.ActualizarBoleta(boleta);
                }
                else
                {
                    dao.AgregarDetalleSinTransacion(item);
                    boleta.TOTAL = boleta.TOTAL + (item.CANTIDAD * item.PRECIO);
                    dao.ActualizarBoleta(boleta);
                }
               

                contador++;
            }



           

            Assert.IsNotNull(dao.ActualizarBoleta(boleta));

        }


        [TestMethod]
        public void validaRUsuario()
        {

            Usuario user = new Usuario();
            user.username = "armandez";
            user.clave="1234568987";
            UsuarioDAO userDAO =new UsuarioDAO();
            var usuario=userDAO.ValidarUsuario(user);
            Assert.IsNotNull(usuario);
        }
    }
}
