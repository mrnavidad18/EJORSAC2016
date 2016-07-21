﻿using System;
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

           
            SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar,100);
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
                            usuario.username=lector["username"].ToString();
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

    }
}
