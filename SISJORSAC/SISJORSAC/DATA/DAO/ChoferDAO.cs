using SISJORSAC.DATA.Conexion;
using SISJORSAC.DATA.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISJORSAC.DATA.DAO
{
   public class ChoferDAO
    {
       public string Agregar(Chofer chofer)
       {
           string salidas;

           string query = "SP_TBL_CHOFER_AGREGAR";
           SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
           msj.Direction = ParameterDirection.Output;
           try
           {
               SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_NOMBRES",chofer.NOMBRES.ToUpper()),
                 DBHelper.MakeParam("@P_APELLIDOS",chofer.APELLIDOS.ToUpper()),
                 DBHelper.MakeParam("@P_NRO_BREVETE",chofer.NRO_BREVETE),
                 DBHelper.MakeParam("@P_NRO_CERTIFICADO",chofer.NRO_CERTIFICADO.ToUpper()),
                 DBHelper.MakeParam("@P_VEHICULO_MARCA_PLACA",chofer.VEHICULO_MARCA_PLACA.ToUpper()),
                 msj
             };

               salidas = DBHelper.ExecuteProcedure(query, dbParams);
               return salidas;
           }
           catch (Exception)
           {
               throw new Exception("Ocurrio un problema al crear chofer"); 
           }

       }
       public List<Chofer> Listar(string pBusqueda)
       {
           List<Chofer> lista = new List<Chofer>();
           string query = "SP_TBL_CHOFER_LISTAR";
           try
           {
               SqlParameter[] dbParams = new SqlParameter[]{
             
                DBHelper.MakeParam("@P_BUSQUEDA",pBusqueda)
                 };

               using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query,dbParams))
               {
                   if (lector != null && lector.HasRows)
                   {
                      Chofer chofer;
                       while (lector.Read())
                       {
                           chofer = new Chofer();
                           chofer.COD_CHOFER = int.Parse(lector["COD_CHOFER"].ToString());
                           chofer.NOMBRES = lector["NOMBRES"].ToString();
                           chofer.APELLIDOS = lector["APELLIDOS"].ToString();
                           chofer.NRO_BREVETE = lector["NRO_BREVETE"].ToString();
                           chofer.NOMBRE_COMPLETO = lector["NOMBRE_COMPLETO"].ToString();
                           chofer.NRO_CERTIFICADO = lector["NRO_CERTIFICADO"].ToString();
                           chofer.VEHICULO_MARCA_PLACA = lector["VEHICULO_MARCA_PLACA"].ToString();
                           lista.Add(chofer); 
                           
                       }
                   }

               }
               return lista;
           }
           catch (Exception)
           {
              
               throw new Exception("Ocurrio un problema al obtener chofer"); 
           }

       }
       public Chofer obtenerChofer(int codigo)
       {
           Chofer chofer = null;
          
           string query = "SP_TBL_CHOFER_OBTENER";
           try
           {
               SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_COD_CHOFER",codigo)
                 
             };

               using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query,dbParams))
               {
                   if (lector != null && lector.HasRows)
                   {
                      
                       while (lector.Read())
                       {
                           chofer = new Chofer();
                           chofer.COD_CHOFER = int.Parse(lector["COD_CHOFER"].ToString());
                           chofer.NOMBRES = lector["NOMBRES"].ToString();
                           chofer.APELLIDOS = lector["APELLIDOS"].ToString();
                           chofer.NRO_BREVETE = lector["NRO_BREVETE"].ToString();
                           chofer.NOMBRE_COMPLETO = lector["NOMBRE_COMPLETO"].ToString();
                           chofer.NRO_CERTIFICADO = lector["NRO_CERTIFICADO"].ToString();
                           chofer.VEHICULO_MARCA_PLACA = lector["VEHICULO_MARCA_PLACA"].ToString();
                       }
                   }

               }
               return chofer;
           }
           catch (Exception)
           {

               throw new Exception("Ocurrio un problema al obtener chofer"); 
           }

       }

       public string Actualizar(Chofer chofer)
       {
           string salidas;

           string query = "SP_TBL_CHOFER_ACTUALIZAR";
           SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
           msj.Direction = ParameterDirection.Output;
           try
           {
               SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_NOMBRES",chofer.NOMBRES.ToUpper()),
                 DBHelper.MakeParam("@P_APELLIDOS",chofer.APELLIDOS.ToUpper()),
                 DBHelper.MakeParam("@P_NRO_BREVETE",chofer.NRO_BREVETE),
                 DBHelper.MakeParam("@P_NRO_CERTIFICADO",chofer.NRO_CERTIFICADO.ToUpper()),
                 DBHelper.MakeParam("@P_VEHICULO_MARCA_PLACA",chofer.VEHICULO_MARCA_PLACA.ToUpper()),
                 DBHelper.MakeParam("@P_COD_CHOFER",chofer.COD_CHOFER),
                 msj
             };

               salidas = DBHelper.ExecuteProcedure(query, dbParams);
               return salidas;
           }
           catch (Exception)
           {
               throw new Exception("Ocurrio un problema al actualizar el  chofer");
           }

       }

    }
}
