using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SISJORSAC.DATA.Modelo;
using SISJORSAC.DATA.DAO;

namespace PruebasJORSAC.Test
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void ListarBoletas()
        {
            BoletaDAO dao= new BoletaDAO();
            List<Boleta> lista = dao.ListarBoletas("DISPONIBLE");
            Assert.IsNotNull(lista);
        }


        [TestMethod]
        public void ListarFacturas()
        {
            FacturaDAO dao = new FacturaDAO();
            var lista = dao.listarFacturas("DISPONIBLE");
            Assert.IsNotNull(lista);
        }

        [TestMethod]
        public void AgregarFactura()
        {
            double IGV = 0.18;

            Servicio servicio = new Servicio
            {
                COD_SERV = 1
            };

            Cliente cliente = new Cliente
            {
                COD_CLI = 1
            };
            GuiaRemision guia = new GuiaRemision
            {
                COD_GUIA = 2
            };


            Factura factura = new Factura();
            factura.cliente = cliente;
            factura.ESTADO = "DISPONIBLE";
            factura.FECHA_EMISION = DateTime.Now;
            factura.MODALIDAD = "Venta";
            factura.OBSERVACION = "DASDSADAS";
            factura.guiaRemision = null;


            DetalleFactura detalle = new DetalleFactura();
            detalle.CANTIDAD = 5;
            detalle.ITEM = 1;
            detalle.SERVICIO = servicio;
            detalle.PRECIO = 50;

            DetalleFactura detalle2 = new DetalleFactura();
            detalle2.CANTIDAD = 5;
            detalle2.ITEM = 1;
            detalle2.SERVICIO = servicio;
            detalle2.PRECIO = 50;


            List<DetalleFactura> det = new List<DetalleFactura>();
            det.Add(detalle);
            det.Add(detalle2);
            factura.DETALLEFACTURA = det;
            factura.SUB_TOTAL = 0;
            foreach (var item in det)
            {
                factura.SUB_TOTAL = factura.SUB_TOTAL + (item.CANTIDAD * item.PRECIO);
            }

            factura.IGV = factura.SUB_TOTAL * IGV;
           


            FacturaDAO dao = new FacturaDAO();

            Assert.IsNotNull(dao.AgregarFactura(factura));

        }
    }
}
