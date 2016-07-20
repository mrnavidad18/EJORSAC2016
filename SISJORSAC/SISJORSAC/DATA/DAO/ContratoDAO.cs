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
    public class ContratoDAO
    {

        public Object[] Agregar(Contrato contrato)
        {
            string cadenaConexion = "server=192.168.0.26;DataBase=BDJORSAC;user=sa;password=2015159";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlTransaction trx = cn.BeginTransaction();

            try
            {
                Object[] salidas = null;
                string query = "SP_TBL_CONTRATO_AGREGAR";

                SqlParameter id = new SqlParameter("@PS_COD", SqlDbType.Int);
                id.Direction = ParameterDirection.Output;

                SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
                msj.Direction = ParameterDirection.Output;

                SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_FECHA_CONTRATO",contrato.FECHA_CONTRATO),
                 DBHelper.MakeParam("@P_COD_CLI",contrato.cliente.COD_CLI),
                 DBHelper.MakeParam("@P_DIRECCION_OBRA",contrato.DIRECCION_OBRA),
                 DBHelper.MakeParam("@P_TRANSPORTE",contrato.TRANSPORTE),
                 DBHelper.MakeParam("@P_idUsuario",contrato.usuario.idUsuario),
                 DBHelper.MakeParam("@P_TOTAL_DIAS",contrato.TOTAL_DIAS),
                 DBHelper.MakeParam("@P_FECHA_ENTREGA",contrato.FECHA_ENTREGA),
                 DBHelper.MakeParam("@P_HORA_ENTREGA",contrato.HORA_ENTREGA),
                 DBHelper.MakeParam("@P_FECHA_DEVOLUCION",contrato.FECHA_DEVOLUCION),
                 DBHelper.MakeParam("@P_HORA_DEVOLUCION",contrato.HORA_DEVOLUCION),
                 DBHelper.MakeParam("@P_MONEDA",contrato.MONEDA),
                 DBHelper.MakeParam("@P_GARANTIA",contrato.GARANTIA),
                 DBHelper.MakeParam("@P_CHEQUE",contrato.CHEQUE),
                 DBHelper.MakeParam("@P_DOCUMENTO",contrato.DOCUMENTO),
                 DBHelper.MakeParam("@P_RECIBO",contrato.RECIBO),
                 DBHelper.MakeParam("@P_IGV",contrato.IGV),
                 DBHelper.MakeParam("@P_SUBTOTAL",contrato.SUBTOTAL),
                 DBHelper.MakeParam("@P_ESTADO","DISPONIBLE"),                             
                id,
                msj
             };



                salidas = DBHelper.ExecuteProcedure(query, dbParams, trx, cn);

                foreach (DetalleContrato detalle in contrato.DETALLECONTRATO)
                {
                    Contrato contra = new Contrato();
                    contra.COD_CONTRATO = Convert.ToInt32(salidas[0]);
                    detalle.CONTRATO = contra;
                   
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

        public string AgregarDetalle(DetalleContrato detalle, SqlTransaction trx, SqlConnection cn)
        {

            string salidas;
            string query = "SP_TBL_DETALLE_CONTRATO_AGREGAR";

            SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
            msj.Direction = ParameterDirection.Output;


            SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_COD_CONTRATO",detalle.CONTRATO.COD_CONTRATO),
                 DBHelper.MakeParam("@P_COD_SERV",detalle.SERVICIO.COD_SERV),
                 DBHelper.MakeParam("@P_ITEM",detalle.ITEM),  
                 DBHelper.MakeParam("@P_CANTIDAD",detalle.CANTIDAD),                               
                 DBHelper.MakeParam("@P_PRECIO",detalle.PRECIO),
                msj
             };

            return salidas = DBHelper.ExecuteProcedureDetalles(query, dbParams, trx, cn);
        }
    

    }
}
