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
    public class ProveedorDAO
    {

        public string Agregar(Proveedor proveedor)
        {
            string salidas;

            string query = "SP_TBL_PROVEEDOR_AGREGAR";


            SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
            msj.Direction = ParameterDirection.Output;
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
             {

                 DBHelper.MakeParam("@P_NOMBRES",proveedor.NOMBRES),
                 DBHelper.MakeParam("@P_AP_PATERNO",proveedor.AP_PATERNO),
                 DBHelper.MakeParam("@P_AP_MATERNO",proveedor.AP_MATERNO),
                 DBHelper.MakeParam("@P_DNI",proveedor.DNI),
                 DBHelper.MakeParam("@P_RUC",proveedor.RUC),
                 DBHelper.MakeParam("@P_RAZON_SOCIAL",proveedor.RAZON_SOCIAL),
                 DBHelper.MakeParam("@P_DIRECCION",proveedor.DIRECCION),
                 DBHelper.MakeParam("@P_DEPARTAMENTO",proveedor.DEPARTAMENTO),
                 DBHelper.MakeParam("@P_PROVINCIA",proveedor.PROVINCIA),
                 DBHelper.MakeParam("@P_DISTRITO",proveedor.DISTRITO),
                 DBHelper.MakeParam("@P_TELF_FIJO_CASA",proveedor.TELF_FIJO_CASA),
                 DBHelper.MakeParam("@P_TELF_FIJO_OFICINA",proveedor.TELF_FIJO_OFICINA),
                 DBHelper.MakeParam("@P_CELULAR",proveedor.CELULAR),
                 DBHelper.MakeParam("@P_EMAIL",proveedor.EMAIL),
                 DBHelper.MakeParam("@P_OBSERVACIONES",proveedor.OBSERVACIONES),
                 DBHelper.MakeParam("@P_TIPO_PRO",proveedor.TIPO_PRO),
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


        public List<Proveedor> ListarProveedor(string tipoProveedor)
        {
            List<Proveedor> listaProveedor = new List<Proveedor>();
            string query = "SP_TBL_PROVEEDOR_LISTAR";
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]{

                     DBHelper.MakeParam("@TIPO_PRO",tipoProveedor)
                 };

                using(SqlDataReader lector =DBHelper.ExecuteDataReaderProcedure(query,dbParams)){
                    if (lector != null && lector.HasRows)
                    {
                        Proveedor proveedor;
                        while (lector.Read())
                        {
                            proveedor = new Proveedor();
                            if (lector["TIPO_PRO"].ToString().Equals("NATURAL"))
                            {
                                proveedor.COD_PROV = int.Parse(lector["COD_PROV"].ToString());
                                proveedor.NOMBRES = lector["NOMBRES"].ToString();
                                proveedor.AP_PATERNO = lector["AP_PATERNO"].ToString();
                                proveedor.AP_MATERNO = lector["AP_MATERNO"].ToString();
                                proveedor.DNI = lector["DNI"].ToString();                               
                                proveedor.DIRECCION = lector["DIRECCION"].ToString();
                                proveedor.DEPARTAMENTO = lector["DEPARTAMENTO"].ToString();
                                proveedor.PROVINCIA = lector["PROVINCIA"].ToString();
                                proveedor.DISTRITO = lector["DISTRITO"].ToString();
                                proveedor.TELF_FIJO_CASA = lector["TELF_FIJO_CASA"].ToString();
                                proveedor.CELULAR = lector["CELULAR"].ToString();
                                proveedor.EMAIL = lector["EMAIL"].ToString();
                                proveedor.OBSERVACIONES = lector["OBSERVACIONES"].ToString();
                                listaProveedor.Add(proveedor);
                            }
                            else
                            {
                                proveedor.COD_PROV = int.Parse(lector["COD_PROV"].ToString());
                                proveedor.RUC = lector["RUC"].ToString();
                                proveedor.RAZON_SOCIAL = lector["RAZON_SOCIAL"].ToString();
                                proveedor.DIRECCION = lector["DIRECCION"].ToString();
                                proveedor.DEPARTAMENTO = lector["DEPARTAMENTO"].ToString();
                                proveedor.PROVINCIA = lector["PROVINCIA"].ToString();
                                proveedor.DISTRITO = lector["DISTRITO"].ToString();

                                proveedor.TELF_FIJO_OFICINA = lector["TELF_FIJO_OFICINA"].ToString();

                                proveedor.EMAIL = lector["EMAIL"].ToString();
                                proveedor.OBSERVACIONES = lector["OBSERVACIONES"].ToString();
                                listaProveedor.Add(proveedor);
                            }
                        }
                    }

                }
                return listaProveedor;
            }
            catch (Exception)
            {
                
                throw;
            }

        }

    }
}
