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
    public class GastoDAO
    {
        public Object[] Agregar(Gasto gasto)
        {
            string cadenaConexion = "server=192.168.0.27;DataBase=BDJORSAC;user=sa;password=2015159";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlTransaction trx = cn.BeginTransaction();

            try
            {
                Object[] salidas = null;
                string query = "SP_TBL_GASTO_AGREGAR";
                SqlParameter id = new SqlParameter("@PS_COD", SqlDbType.Int);
                id.Direction = ParameterDirection.Output;

                SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
                msj.Direction = ParameterDirection.Output;

                SqlParameter[] dbParams = new SqlParameter[]
                {
                 DBHelper.MakeParam("@P_FECHA_EGRE",gasto.FECHA_EGRE),
                 DBHelper.MakeParam("@P_COD_PROV",gasto.PROVEEDOR.COD_PROV),
                 DBHelper.MakeParam("@P_DOC_REF",gasto.DOC_REF..ToUpper()),
                 DBHelper.MakeParam("@P_NRO_DOC_REF",gasto.NRO_DOC_REF),
                 DBHelper.MakeParam("@P_MONEDA",gasto.MONEDA..ToUpper()),
                 DBHelper.MakeParam("@P_ESTADO","DISPONIBLE"),                            
                id,
                msj
                };



                salidas = DBHelper.ExecuteProcedure(query, dbParams, trx, cn);

                foreach (DetalleGasto detalle in gasto.DetalleGASTO)
                {
                    Gasto gastit = new Gasto();
                    gastit.COD_GASTO = Convert.ToInt32(salidas[0]);

                    detalle.GASTO = gastit;

                    if (AgregarDetalle(detalle, trx, cn) == null)
                    {
                        throw new Exception("Ocurrio un error en la insercion del detalle del GASTO :" + detalle.ConceptoGasto.DESCRIPCION);
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

        public string AgregarDetalle(DetalleGasto detalle, SqlTransaction trx, SqlConnection cn)
        {

            string salidas;
            string query = "SP_TBL_DETALLE_GASTO_AGREGAR";

            SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
            msj.Direction = ParameterDirection.Output;


            SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_COD_GASTO",detalle.GASTO.COD_GASTO),
                 DBHelper.MakeParam("@P_COD_CON_GAS",detalle.ConceptoGasto.COD_CON_GAS),
                 DBHelper.MakeParam("@P_ITEM",detalle.ITEM),  
                 DBHelper.MakeParam("@P_CANTIDAD",detalle.CANTIDAD),                               
                 DBHelper.MakeParam("@P_PRECIO",detalle.PRECIO),
                msj
             };

            return salidas = DBHelper.ExecuteProcedureDetalles(query, dbParams, trx, cn);
        }

        public List<Gasto> listarGasto(string estado)
        {

            List<Gasto> listaGasto = new List<Gasto>();
            string query = "SP_TBL_GASTO_LISTAR";
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]{

                     DBHelper.MakeParam("@P_ESTADO",estado)
                 };
                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query, dbParams))
                {
                    if (lector != null && lector.HasRows)
                    {
                        Gasto gasto;
                        Proveedor proveedor;
                        
                        
                        while (lector.Read())
                        {
                            proveedor = new Proveedor();
                            gasto = new Gasto();
                            ProveedorDAO proveedorDAO = new ProveedorDAO();

                            gasto.COD_GASTO = int.Parse(lector["COD_GASTO"].ToString());
                            gasto.NRO_GASTO = lector["NRO_GASTO"].ToString();
                            proveedor = proveedorDAO.ObtenerProveedor(int.Parse(lector["COD_PROV"].ToString()));
                            gasto.PROVEEDOR = proveedor;
                            gasto.FECHA_EGRE = DateTime.Parse(lector["FECHA_EGRE"].ToString());
                            gasto.DOC_REF = lector["DOC_REF"].ToString();
                            gasto.NRO_DOC_REF = lector["NRO_DOC_REF"].ToString();
                            gasto.MONEDA = lector["MONEDA"].ToString();
                            gasto.ESTADO = lector["ESTADO"].ToString();

                            listaGasto.Add(gasto);
                        }
                    }
                }
                return listaGasto;
            }
            catch (Exception)
            {
                throw;
            }


        }

        public Gasto ObtenerGasto(int codGasto)
        {

            Gasto gasto = new Gasto();
            string query = "SP_TBL_GASTO_OBTENERGASTOXCODIGO";
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]{

                     DBHelper.MakeParam("@P_COD_GASTO",codGasto)
                 };
                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query, dbParams))
                {
                    if (lector != null && lector.HasRows)
                    {                        
                        Proveedor proveedor;
                        while (lector.Read())
                        {
                            proveedor = new Proveedor();                            
                            ProveedorDAO proveedorDAO = new ProveedorDAO();
                            gasto.COD_GASTO = int.Parse(lector["COD_GASTO"].ToString());
                            gasto.NRO_GASTO = lector["NRO_GASTO"].ToString();
                            proveedor = proveedorDAO.ObtenerProveedor(int.Parse(lector["COD_PROV"].ToString()));
                            gasto.PROVEEDOR = proveedor;
                            gasto.FECHA_EGRE = DateTime.Parse(lector["FECHA_EGRE"].ToString());
                            gasto.DOC_REF = lector["DOC_REF"].ToString();
                            gasto.NRO_DOC_REF = lector["NRO_DOC_REF"].ToString();
                            gasto.MONEDA = lector["MONEDA"].ToString();
                            gasto.ESTADO = lector["ESTADO"].ToString();                           
                        }
                    }
                }
                return gasto;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
