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
        public bool Agregar(Usuario usuario)
        {
            bool exito = false;
            string query = "INSERT INTO TBL_USUARIO  VALUES(@pr1,@pr2,@pr3,@pr4,@pr5,@pr6)";

            SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@pr1",usuario.username),
                 DBHelper.MakeParam("@pr2",usuario.clave),  
                 DBHelper.MakeParam("@pr3",usuario.Nombre),              
                DBHelper.MakeParam("@pr4",usuario.Apellidos),
                DBHelper.MakeParam("@pr5",usuario.DNI),
                DBHelper.MakeParam("@pr6","DISPONIBLE")              
             };
            exito = DBHelper.ExecuteNonQuery(query, dbParams) > 0;
            return exito;
        }
    }
}
