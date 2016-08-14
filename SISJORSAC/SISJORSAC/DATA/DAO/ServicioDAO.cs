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
    public class ServicioDAO
    {
        public string Agregar(Servicio servicio)
        {
            string salidas;

            string query = "SP_TBL_SERV_AGREGAR";
            SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
            msj.Direction = ParameterDirection.Output;
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_DESCRIPCION",servicio.DESCRIPCION==null?System.Data.SqlTypes.SqlString.Null:servicio.DESCRIPCION.ToUpper() ),
                 DBHelper.MakeParam("@P_PRECIO",servicio.PRECIO==null?System.Data.SqlTypes.SqlDouble.Null:servicio.PRECIO ),               
                 DBHelper.MakeParam("@P_TIPO_MONE","SOLES"),
                 DBHelper.MakeParam("@P_PESO",servicio.PESO==null?System.Data.SqlTypes.SqlDouble.Null:servicio.PESO ),
                 DBHelper.MakeParam("@P_STOCK",servicio.STOCK==null?System.Data.SqlTypes.SqlInt32.Null:servicio.STOCK ),
                 DBHelper.MakeParam("@P_UNIDAD_MEDIDA",servicio.UNIDAD_MEDIDA==null?System.Data.SqlTypes.SqlString.Null:servicio.UNIDAD_MEDIDA+" "+"UNIDADES."),
                 DBHelper.MakeParam("@P_ESTADO","ACTIVO"),
                 msj
             };
                salidas = DBHelper.ExecuteProcedure(query, dbParams);
                return salidas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Servicio> listarServicio(string estado,string p_busqueda)
        {
            List<Servicio> listarServi = new List<Servicio>();
            string query = "SP_TBL_SERV_LISTAR";
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]{
                DBHelper.MakeParam("@ESTADO",estado),
                DBHelper.MakeParam("@P_BUSQUEDA",p_busqueda)
                 };

                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query, dbParams))
                {
                    if (lector != null && lector.HasRows)
                    {
                        Servicio servicio;
                        while (lector.Read())
                        {
                            servicio = new Servicio();
                            servicio.COD_SERV=int.Parse(lector["COD_SERV"].ToString());
                            servicio.DESCRIPCION=lector["DESCRIPCION"].ToString();
                            servicio.PRECIO=double.Parse(lector["PRECIO"].ToString());                            
                            servicio.TIPO_MONE=lector["TIPO_MONE"].ToString();
                            servicio.PESO=double.Parse(lector["PESO"].ToString());
                            servicio.STOCK = int.Parse(lector["STOCK"].ToString());
                            servicio.UNIDAD_MEDIDA = lector["UNIDAD_MEDIDA"].ToString();
                            listarServi.Add(servicio);   
                        }
                    }
                }
                return listarServi;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Servicio ObtenerServicio(int codServ)
        {
            Servicio servicio = new Servicio();
            string query = "SP_TBL_SERV_OBTENERSERVICIOXCODIGO";
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]{

                     DBHelper.MakeParam("@P_COD_SERV",codServ)
                 };

                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query, dbParams))
                {
                    if (lector != null && lector.HasRows)
                    {

                        while (lector.Read())
                        {
                            servicio.COD_SERV=int.Parse(lector["COD_SERV"].ToString());
                            servicio.DESCRIPCION=lector["DESCRIPCION"].ToString();
                            servicio.PRECIO=double.Parse(lector["PRECIO"].ToString());                            
                            servicio.TIPO_MONE=lector["TIPO_MONE"].ToString();
                            servicio.PESO=double.Parse(lector["PESO"].ToString());
                            servicio.STOCK = int.Parse(lector["STOCK"].ToString());
                            servicio.UNIDAD_MEDIDA = lector["UNIDAD_MEDIDA"].ToString();
                            servicio.ESTADO=lector["ESTADO"].ToString();                            
                        }
                    }

                }
                return servicio;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Actualizar(Servicio servicio)
        {
            string salidas;

            string query = "SP_TBL_SERV_ACTUALIZAR";
            SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
            msj.Direction = ParameterDirection.Output;
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_DESCRIPCION",servicio.DESCRIPCION==null?System.Data.SqlTypes.SqlString.Null:servicio.DESCRIPCION.ToUpper() ),
                 DBHelper.MakeParam("@P_PRECIO",servicio.PRECIO==null?System.Data.SqlTypes.SqlDouble.Null:servicio.PRECIO ),               
                 DBHelper.MakeParam("@P_TIPO_MONE","SOLES"),
                 DBHelper.MakeParam("@P_PESO",servicio.PESO==null?System.Data.SqlTypes.SqlDouble.Null:servicio.PESO ),
                 DBHelper.MakeParam("@P_STOCK",servicio.STOCK==null?System.Data.SqlTypes.SqlInt32.Null:servicio.STOCK ),
                 DBHelper.MakeParam("@P_UNIDAD_MEDIDA",servicio.UNIDAD_MEDIDA==null?System.Data.SqlTypes.SqlString.Null:servicio.UNIDAD_MEDIDA.ToUpper()),
                 DBHelper.MakeParam("@P_ESTADO","ACTIVO"),
                 DBHelper.MakeParam("@P_COD_SERV",servicio.COD_SERV),
                 msj
             };

                salidas = DBHelper.ExecuteProcedure(query, dbParams);
                return salidas;
            }
            catch (Exception)
            {
                throw;
            }


        }
    }
}
