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
    public class UbigeoDAO
    {
        public List<Ubigeo> llenarDepartamentos()
        {
            List<Ubigeo> listaDepartamentos = new List<Ubigeo>();
            string query = "SP_TBL_UBIGEO_LLENARDEPARTAMENTOS";
            try
            {

                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query))
                {
                    if (lector != null && lector.HasRows)
                    {
                        Ubigeo ubigeo;
                        while (lector.Read())
                        {
                            ubigeo = new Ubigeo();
                            ubigeo.Departamento = lector["Departamento"].ToString();
                            ubigeo.IdUbigeo = lector["IdUbigeo"].ToString();
                            listaDepartamentos.Add(ubigeo);
                        }
                    }
                }
                return listaDepartamentos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Ubigeo> llenarProvincias(string idProvincia)
        {
            List<Ubigeo> listaProvincias = new List<Ubigeo>();
            string query = "SP_TBL_UBIGEO_LLENARPROVINCIAS";
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]{

                     DBHelper.MakeParam("@P_IDUBIGEOPROVINCIA",idProvincia)
                 };
                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query, dbParams))
                {
                    if (lector != null && lector.HasRows)
                    {
                        Ubigeo ubigeo;
                        while (lector.Read())
                        {
                            ubigeo = new Ubigeo();
                            ubigeo.Provincia = lector["Provincia"].ToString();
                            ubigeo.IdUbigeo = lector["IdUbigeo"].ToString();
                            listaProvincias.Add(ubigeo);
                        }
                    }
                }
                return listaProvincias;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Ubigeo> llenarDistritos(string idProvincia,string idDepartamento)
        {
            List<Ubigeo> listaDistritos = new List<Ubigeo>();
            string query = "SP_TBL_UBIGEO_LLENARDISTRITOS";
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]{

                     DBHelper.MakeParam("@P_IDUBIGEO",idProvincia),
                     DBHelper.MakeParam("@P_PROVINCIA",idDepartamento)
                 };
                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query, dbParams))
                {
                    if (lector != null && lector.HasRows)
                    {
                        Ubigeo ubigeo;


                        while (lector.Read())
                        {
                            ubigeo = new Ubigeo();
                            ubigeo.Distrito = lector["Distrito"].ToString();
                            ubigeo.IdUbigeo = lector["IdUbigeo"].ToString();
                            listaDistritos.Add(ubigeo);
                        }
                    }
                }
                return listaDistritos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
