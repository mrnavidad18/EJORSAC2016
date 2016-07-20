using System;
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
            
            Assert.IsNotNull(dao.Agregar(boleta));

        }
    }
}
