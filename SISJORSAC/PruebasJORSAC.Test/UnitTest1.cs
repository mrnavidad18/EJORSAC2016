using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SISJORSAC.DATA.DAO;
using SISJORSAC.DATA.Modelo;



namespace PruebasJORSAC.Test
{
    [TestClass]
    public class UnitTest1
    {

        UsuarioDAO usudao = new UsuarioDAO();
        

        [TestMethod]
        public void TestMethod1()
        {
            Usuario usu = new Usuario();
            usu.Apellidos = "Huaman Meza";
            usu.DNI = "77446525";
            usu.clave = "AHYA";
            usu.Nombre = "RICARDO";
            usu.username = "huamanR";

           var salidas= usudao.Agregar(usu);
           int id = Convert.ToInt32(salidas[0]);
           string msj = Convert.ToString(salidas[1]);
           Assert.AreNotEqual(id,0);
            
        }
    }
}
