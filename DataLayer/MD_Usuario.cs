using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityLayer;

namespace DataLayer
{
    public class MD_Usuario
    {
        Conexion oaccesodedatos = new Conexion();
        public Usuario LoginUsuario(string desUsuario, string pasUsuario) {
           
            SqlCommand _comando = oaccesodedatos.CrearComando(CommandType.StoredProcedure, "loginUsuario");
            _comando.Parameters.Add(new SqlParameter("@desusuario",desUsuario));
            _comando.Parameters.Add(new SqlParameter("@pasusuario", pasUsuario));
          //  _comando.ExecuteNonQuery();
            SqlDataReader dr = oaccesodedatos.ExecuteReaderSelect(_comando);
            Usuario user = new Usuario();
            while (dr.Read())
            {
                user.codUsuario = (int)dr["codUsuario"];
                user.desUsuario = dr["desUsuario"].ToString();
                user.pasUsuario = dr["pasUsuario"].ToString();
                user.codPersona = (int)dr["codPersona"];
                
            }

            return user;
        }

        //public Int32 GuardarUsuario(EntidadUsuario oUsuario) {

        //    try
        //    {
        //        oaccesodedatos.Open();

        //        SqlCommand _comando = oaccesodedatos.CrearComando(CommandType.StoredProcedure,"insertusurio");
        //        _comando.Parameters.AddWithValue("",);
        //        _comando.Parameters.AddWithValue("",);
        //        _comando.Parameters.AddWithValue("",);
                
        //        return oaccesodedatos.EjecutarComandoInsert(_comando);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    finally {
        //        oaccesodedatos.close();
        //    }
            

        //}

        //public  DataTable ObtenerUsuarios()
        //{
        //    SqlCommand _comando = oaccesodedatos.CrearComando(CommandType.Text, "SELECT * FROM usuario");
            
        //    return oaccesodedatos.EjecutarComandoSelect(_comando);
        //}
        //public List<Usuario> ObtenerUser() { 
        //    List<Usuario> usuarios = new List<Usuario>();
        //     SqlCommand _comando = oaccesodedatos.CrearComando(CommandType.Text, "SELECT * FROM usuario");

        //     SqlDataReader dr = oaccesodedatos.ExecuteReaderSelect(_comando);
        //    while( dr.Read() )
        //    {
        //        Usuario user = new Usuario();
        //             user.codUsuario= (int)dr["codUsuario"];
        //            user.desUsuario= dr["desUsuario"].ToString();
        //            user.pasUsuario= dr["pasUsuario"].ToString();
        //            user.codPersona= (int)dr["codPersona"];
        //         usuarios.Add(user);
        //    }

        //    return usuarios;
        //}

    }
}
