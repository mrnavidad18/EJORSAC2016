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
        public string Agregar(Usuario usuario)
        {
            string salidas;
            string query = "SP_TBL_USUARIO_AGREGAR";
            SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
            msj.Direction = ParameterDirection.Output;
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_USERNAME",usuario.username),
                 DBHelper.MakeParam("@P_CLAVE",usuario.clave),  
                 DBHelper.MakeParam("@P_NOMBRE",usuario.Nombre.ToUpper()),              
                 DBHelper.MakeParam("@P_APELLIDOS",usuario.Apellidos.ToUpper()),
                 DBHelper.MakeParam("@P_DNI",usuario.DNI),
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
        public Usuario ObtenerUsuario(int idUsuario)
        {
            Usuario usuario = new Usuario();
            string query = "SP_TBL_USUARIO_OBTENERUSUARIOXCODIGO";
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]{
                     DBHelper.MakeParam("@P_IDUSUARIO",idUsuario)
                 };

                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query, dbParams))
                {
                    if (lector != null && lector.HasRows)
                    {

                        while (lector.Read())
                        {
                            usuario.idUsuario = int.Parse(lector["idUsuario"].ToString());
                            usuario.username = lector["username"].ToString();
                            usuario.clave = lector["clave"].ToString();
                            usuario.Nombre = lector["Nombre"].ToString();
                            usuario.Apellidos = lector["Apellidos"].ToString();
                            usuario.DNI = lector["DNI"].ToString();
                            usuario.ESTADO = lector["ESTADO"].ToString();
                        }
                    }
                }
                return usuario;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public string Actualizar(Usuario usuario)
        {
            string salidas;

            string query = "SP_TBL_USUARIO_ACTUALIZAR";
            SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
            msj.Direction = ParameterDirection.Output;
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_USERNAME",usuario.username),
                 DBHelper.MakeParam("@P_CLAVE",usuario.clave),  
                 DBHelper.MakeParam("@P_NOMBRE",usuario.Nombre),              
                 DBHelper.MakeParam("@P_APELLIDOS",usuario.Apellidos),
                 DBHelper.MakeParam("@P_DNI",usuario.DNI),
                 DBHelper.MakeParam("@P_ESTADO","ACTIVO"),
                 DBHelper.MakeParam("@P_IDUSUARIO",usuario.idUsuario),
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
        public Usuario ValidarUsuario(Usuario usuario)
        {
            string resultado;
            Usuario usu = new Usuario();
            string query = "SP_TBL_USUARIO_VALIDARUSUARIO";
            string queryListado = "SP_TBL_USUARIO_TRAERUSUARIOVALIDADO";
            try
            {
                SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
                msj.Direction = ParameterDirection.Output;


                SqlParameter[] dbParams = new SqlParameter[]{
                     DBHelper.MakeParam("@P_USERNAME",usuario.username),
                     DBHelper.MakeParam("@P_CLAVE",usuario.clave),
                     msj
                 };

                SqlParameter[] dbParamListado = new SqlParameter[]{
                     DBHelper.MakeParam("@P_USERNAME",usuario.username),
                     DBHelper.MakeParam("@P_CLAVE",usuario.clave)                     
                 };
                resultado = DBHelper.ExecuteProcedure(query, dbParams);
                if (resultado.Equals("CORRECTO"))
                {
                    using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(queryListado, dbParamListado))
                    {
                        if (lector != null && lector.HasRows)
                        {
                            while (lector.Read())
                            {
                                usu.idUsuario = int.Parse(lector["idUsuario"].ToString());
                                usu.username = lector["username"].ToString();
                                usu.Nombre = lector["Nombre"].ToString();
                                usu.clave = lector["clave"].ToString();
                                usu.Apellidos = lector["Apellidos"].ToString();
                                usu.DNI = lector["DNI"].ToString();
                                usu.ESTADO = lector["ESTADO"].ToString();
                            }
                        }
                    }
                }
                else
                {
                    usu = null;
                }
                return usu;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public string ModificarCuentausuario(Usuario usuario)
        {
            string salidas;
            string query = "SP_TBL_USUARIO_MODIFICARPASSWORD";

            SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
            msj.Direction = ParameterDirection.Output;
            try
            {
              SqlParameter[] dbParams = new SqlParameter[]
             {
              DBHelper.MakeParam("@P_IDUSUARIO",usuario.idUsuario),
              DBHelper.MakeParam("@P_CLAVE",usuario.clave),                   
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

        public List<Usuario> ListarUsuarios(string estado)
        {
            List<Usuario> listaUsuarios = null;
            string query = "SP_TBL_USUARIOS_LISTAR";
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]{
                     DBHelper.MakeParam("@ESTADO",estado)
                 };

                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query, dbParams))
                {
                    if (lector != null && lector.HasRows)
                    {
                        listaUsuarios = new List<Usuario>();
                        Usuario usuario;
                        while (lector.Read())
                        {
                            usuario = new Usuario();
                            usuario.idUsuario = int.Parse(lector["idUsuario"].ToString());
                            usuario.username = lector["username"].ToString();
                            usuario.clave = lector["clave"].ToString();
                            usuario.Nombre = lector["Nombre"].ToString();
                            usuario.Apellidos = lector["Apellidos"].ToString();
                            usuario.DNI = lector["DNI"].ToString();
                            usuario.ESTADO = lector["ESTADO"].ToString();
                            usuario.NOMBRE_COMPLETO = lector["NOMBRE_COMPLETO"].ToString();
                            listaUsuarios.Add(usuario);
                        }
                    }
                }
                return listaUsuarios;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
