using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISJORSAC.DATA.Conexion;
using SISJORSAC.DATA.Modelo;
using System.Data;
using System.Data.SqlClient;

namespace SISJORSAC.DATA.DAO
{
    public class GuiaRemisionDAO
    {

        public Object[] Agregar(GuiaRemision guiaRemision)
        {
            string cadenaConexion = "server=192.168.0.26;DataBase=BDJORSAC;user=sa;password=2015159";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlTransaction trx = cn.BeginTransaction();

            try
            {
                Object[] salidas = null;
                string query = "SP_TBL_GUIA_REMISION_AGREGAR";

                SqlParameter id = new SqlParameter("@PS_COD", SqlDbType.Int);
                id.Direction = ParameterDirection.Output;

                SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
                msj.Direction = ParameterDirection.Output;


                SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_FECHA_EMISION",guiaRemision.FECHA_EMISION),
                 DBHelper.MakeParam("@P_PTO_PARTIDA",guiaRemision.PTO_PARTIDA),  
                 DBHelper.MakeParam("@P_PTO_LLEGADA",guiaRemision.PTO_LLEGADA), 
                 DBHelper.MakeParam("@P_COD_CLIE",guiaRemision.cliente.COD_CLI),
                 DBHelper.MakeParam("@P_VEHICULO_MARCA",guiaRemision.VEHICULO_MARCA),
                 DBHelper.MakeParam("@P_NRO_CERTIFICADO",guiaRemision.NRO_CERTIFICADO),
                 DBHelper.MakeParam("@P_NOMBRE_CONDUCTOR",guiaRemision.NONBRE_CONDUCTOR),
                 DBHelper.MakeParam("@P_NRO_BREVETE",guiaRemision.NRO_BREVETE),
                 DBHelper.MakeParam("@P_NOMB_TRANSPORTE",guiaRemision.NOMB_TRANSPORTE),
                 DBHelper.MakeParam("@P_RUC_TRANSPORTE",guiaRemision.RUC_TRANSPORTE),
                 DBHelper.MakeParam("@P_TIPO_COMPROB",guiaRemision.TIPO_COMPROB),
                 DBHelper.MakeParam("@P_TIPO_TRASLADO",guiaRemision.TIPO_TRASLADO),
                 DBHelper.MakeParam("@P_MTO_TRASLADO",guiaRemision.MTO_TRASLADO),
                 DBHelper.MakeParam("@P_PROVINCIA",guiaRemision.PROVINCIA),
                 DBHelper.MakeParam("@P_DEPARTAMENTO",guiaRemision.DEPARTAMENTO),
                 DBHelper.MakeParam("@P_DISTRITO",guiaRemision.DISTRITO),
                 DBHelper.MakeParam("@P_SITUACION",guiaRemision.SITUACION),
                 DBHelper.MakeParam("@P_ESTADO","DISPONIBLE"),              
                id,
                msj
             };



                salidas = DBHelper.ExecuteProcedure(query, dbParams, trx, cn);

                foreach (DetalleGuiaRemision detalle in guiaRemision.DETALLEGUIAREMISION)
                {
                    GuiaRemision guiaa = new GuiaRemision();
                    guiaa.COD_GUIA = Convert.ToInt32(salidas[0]);

                    detalle.GUIA_REMISION = guiaa;
                    if (AgregarDetalle(detalle, trx, cn) == null)
                    {
                        throw new Exception("Ocurrio un error en la insercion del detalle de la boleta :" + detalle.SERVICIO.DESCRIPCION);
                    }
                }
                trx.Commit();
                cn.Close();
                return salidas;

            }
            catch (Exception ex)
            {
                trx.Rollback();
                cn.Close();
                throw ex;
            }

        }

        public string AgregarDetalle(DetalleGuiaRemision detalle, SqlTransaction trx, SqlConnection cn)
        {

            string salidas;
            string query = "SP_TBL_DETALLE_GUIA_AGREGAR";

            SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
            msj.Direction = ParameterDirection.Output;


            SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_COD_SERV",detalle.SERVICIO.COD_SERV),
                 DBHelper.MakeParam("@P_NRO_GUIA",detalle.GUIA_REMISION.COD_GUIA),
                 DBHelper.MakeParam("@P_ITEM",detalle.ITEM),  
                 DBHelper.MakeParam("@P_CANTIDAD",detalle.CANTIDAD),                               
                msj
             };

            return salidas = DBHelper.ExecuteProcedureDetalles(query, dbParams, trx, cn);
        }



    }
}
