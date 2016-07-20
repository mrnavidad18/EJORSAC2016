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
    public class FacturaDAO
    {

        public Object[] Agregar(Factura factura)
        {
            string cadenaConexion = "server=192.168.0.26;DataBase=BDJORSAC;user=sa;password=2015159";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlTransaction trx = cn.BeginTransaction();

            try
            {
                Object[] salidas = null;
                string query = "SP_TBL_FACTURA_AGREGAR";

                SqlParameter id = new SqlParameter("@PS_COD", SqlDbType.Int);
                id.Direction = ParameterDirection.Output;

                SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
                msj.Direction = ParameterDirection.Output;


                SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_FECHA_EMISION",factura.FECHA_EMISION ),
                DBHelper.MakeParam("@P_COD_CLI",factura.cliente.COD_CLI ),
                DBHelper.MakeParam("@P_NRO_GUIA",factura.guiaRemision.COD_GUIA ),
                DBHelper.MakeParam("@P_MODALIDAD", factura.MODALIDAD),
                DBHelper.MakeParam("@P_OBSERVACION", factura.OBSERVACION),
                DBHelper.MakeParam("@P_SUB_TOTAL",factura.SUB_TOTAL ),
                DBHelper.MakeParam("@P_IGV",factura.IGV ),                     
                 DBHelper.MakeParam("@P_ESTADO","DISPONIBLE"),              
                id,
                msj
             };



                salidas = DBHelper.ExecuteProcedure(query, dbParams, trx, cn);

                foreach (DetalleFactura detalle in factura.DETALLEFACTURA)
                {
                    Factura factu = new Factura();
                    factu.COD_FAC = Convert.ToInt32(salidas[0]);
                    detalle.FACTURA = factu;                    
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

        public string AgregarDetalle(DetalleFactura detalle, SqlTransaction trx, SqlConnection cn)
        {

            string salidas;
            string query = "SP_TBL_DETALLE_FACTURA_AGREGAR";

            SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
            msj.Direction = ParameterDirection.Output;


            SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_ITEM",detalle.ITEM),
                 DBHelper.MakeParam("@P_COD_SERV",detalle.SERVICIO.COD_SERV),
                 DBHelper.MakeParam("@P_COD_FACTURA",detalle.FACTURA.COD_FAC),  
                 DBHelper.MakeParam("@P_CANTIDAD",detalle.CANTIDAD),                               
                 DBHelper.MakeParam("@P_PRECIO",detalle.PRECIO),                               
                msj
             };

            return salidas = DBHelper.ExecuteProcedureDetalles(query, dbParams, trx, cn);
        }


    }
}
