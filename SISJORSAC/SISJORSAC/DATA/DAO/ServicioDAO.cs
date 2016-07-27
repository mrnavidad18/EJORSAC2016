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
                 DBHelper.MakeParam("@P_DESCRIPCION",servicio.DESCRIPCION ),
                 DBHelper.MakeParam("@P_PRECIO",servicio.PRECIO ),               
                 DBHelper.MakeParam("@P_TIPO_MONE",servicio.TIPO_MONE ),
                 DBHelper.MakeParam("@P_PESO",servicio.PESO ),
                 DBHelper.MakeParam("@P_ESTADO","DISPONIBLE"),
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

        public List<Servicio> listarServicio(string estado)
        {
            List<Servicio> listarServi = new List<Servicio>();
            string query = "SP_TBL_SERV_LISTAR";
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]{

                     DBHelper.MakeParam("@ESTADO",estado)
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
                 DBHelper.MakeParam("@P_DESCRIPCION",servicio.DESCRIPCION ),
                 DBHelper.MakeParam("@P_PRECIO",servicio.PRECIO ),               
                 DBHelper.MakeParam("@P_TIPO_MONE",servicio.TIPO_MONE ),
                 DBHelper.MakeParam("@P_PESO",servicio.PESO ),
                 DBHelper.MakeParam("@P_ESTADO","DISPONIBLE"),
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
