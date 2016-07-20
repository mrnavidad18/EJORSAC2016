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
    class BoletaDAO
    {
        private static string cadenaConexion = "server=192.168.0.20;DataBase=BDJORSAC;user=sa;password=2015159";
        public Object[] Agregar(Boleta boleta)
        {
            Object[] salidas = null;
            string query = "SP_TBL_BOLETA_AGREGAR";

            SqlParameter id = new SqlParameter("@PS_COD", SqlDbType.Int);
            id.Direction = ParameterDirection.Output;

            SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
            msj.Direction = ParameterDirection.Output;

           
            SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_FECHA_EMISION",boleta.FECHA_EMISION),
                 DBHelper.MakeParam("@P_COD_CLI",boleta.cliente.COD_CLI),  
                 DBHelper.MakeParam("@P_MODALIDAD",boleta.MODALIDAD),              
                 DBHelper.MakeParam("@P_OBSERVACION",boleta.OBSERVACION),
                 DBHelper.MakeParam("@P_TOTAL",boleta.TOTAL),
                 DBHelper.MakeParam(" @P_ESTADO","DISPONIBLE"),
                id,
                msj
             };
            
            SqlConnection cn = new SqlConnection(cadenaConexion);
            SqlTransaction trx = cn.BeginTransaction();

            salidas = DBHelper.ExecuteProcedure(query, dbParams,trx,cn);

            foreach(DetalleBoleta detalle in boleta.DETALLEBOLETA)
            {

            }
            return salidas;
        }

        public Object[] AgregarDetalle(DetalleBoleta detalle)
        {
            Object[] salidas = null;
            string query = "SP_TBL_DETALLE_BOLETA_AGREGAR";

            SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
            msj.Direction = ParameterDirection.Output;

            
            SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_ITEM",detalle.ITEM),
                 DBHelper.MakeParam("@P_COD_SERV",detalle.SERVICIO.COD_SERV),
                 DBHelper.MakeParam("@P_COD_BOLETA",detalle.BOLETA.NRO_CP),  
                 DBHelper.MakeParam(" @P_CANTIDAD",detalle.CANTIDAD),              
                 DBHelper.MakeParam(" @P_PRECIO",detalle.PRECIO),
                msj
             };

            salidas = DBHelper.ExecuteProcedure(query, dbParams);
        }
    }
}
