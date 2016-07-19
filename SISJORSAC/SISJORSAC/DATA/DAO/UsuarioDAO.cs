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
    public class UsuarioDAO
    {
        public Object[] Agregar(Usuario usuario)
        {
            Object[] salidas;
           
            string query = "SP_TBL_USUARIO_AGREGAR";

            SqlParameter id = new SqlParameter("@PS_COD", SqlDbType.Int);
            id.Direction = ParameterDirection.Output;
            SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar,100);
            msj.Direction = ParameterDirection.Output;

            SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_USERNAME",usuario.username),
                 DBHelper.MakeParam("@P_CLAVE",usuario.clave),  
                 DBHelper.MakeParam("@P_NOMBRE",usuario.Nombre),              
                 DBHelper.MakeParam("@P_APELLIDOS",usuario.Apellidos),
                 DBHelper.MakeParam("@P_DNI",usuario.DNI),
                 DBHelper.MakeParam("@P_ESTADO","DISPONIBLE"),
                id ,msj
             };
            salidas = DBHelper.ExecuteProcedure(query, dbParams);
            return salidas;
        }
    }
}
