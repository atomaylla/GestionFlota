using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataLayer
{
    
   public class Conexion
    {
        public SqlConnection dbconexion;
        public SqlCommand ocommand;
        public SqlDataReader dtreader;
        public IDataReader Lector;
        public Conexion()
        {
           // string dtconexion = @"Data Source=TOSHIBA\SOPORTEDB;Initial Catalog=gestiondb;User ID=sa";
           // dbconexion = new SqlConnection(dtconexion);
            dbconexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            

        }
        //public SqlConnection conectar(){
        //    //dbconexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        //    dbconexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        //    return dbconexion;
        //}
        public void Abrir() {
            if (dbconexion.State == ConnectionState.Open)
            {
                return;
            }

            try{
                dbconexion.Open();
            }catch{
                 throw;
            }            
               
       }
        public void Cerrar() {
            if (dbconexion.State == ConnectionState.Closed) {
                return;
            }
            dbconexion.Close();
        }

        public Int32 ExecuteNonQuery( CommandType tipoComando, String query) { 
            ocommand.Connection = dbconexion;
            ocommand.CommandType = tipoComando;
            ocommand.CommandText = query;
            int retorno = 0;
            try{
             retorno = ocommand.ExecuteNonQuery();
            }catch{
             throw;
            }
            return retorno;
        
        }
        public IDataReader ExecuteReader(CommandType tipoComando, String consulta) {
            Lector = null;
            ocommand.Connection = dbconexion;
            ocommand.CommandType = tipoComando;
            ocommand.CommandText = consulta;
            try
            {
                Lector = ocommand.ExecuteReader();
            }
            catch {
                throw;
            }
            return Lector;
        }
        public  SqlCommand CrearComando(CommandType tipocomando, String texto) {
   
            //SqlConnection dbconexiont = new SqlConnection(@"Data Source=TOSHIBA\SOPORTEDB;Initial Catalog=gestiondb;User ID=sa");
          
           
            if (dbconexion.State == ConnectionState.Closed)
            {
                dbconexion.Open();
            }
                //ocommand.Connection = dbconexion;
                //ocommand.CommandText = texto;
                //ocommand.CommandType = tipocomando;
              //  dbconexion.Open();
                SqlCommand command = new SqlCommand(texto, dbconexion);
                command.CommandType = tipocomando;

                return command;
            //}
            //catch {
            //    throw;
            //}
        }
        public Int32 EjecutarComandoInsert(SqlCommand comando) {

            try
            {
               // comando.Connection = dbconexion;
                return comando.ExecuteNonQuery();

            }
            catch
            {
                throw;
            }
            finally {
                comando.Connection.Dispose();
                comando.Connection.Close();
            }
        }

        public  DataTable EjecutarComandoSelect(SqlCommand comando)
        {
            DataTable _tabla = new DataTable();
            try
            {
          
                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                adaptador.Fill(_tabla);
            }
            catch (Exception ex)
            { throw ex; }
           
            return _tabla;
        }
        //public List<Object> EjecutarComandoSelect(SqlCommand comando)
        //{
        //    DataTable _tabla = new DataTable();
        //    try
        //    {

        //        SqlDataAdapter adaptador = new SqlDataAdapter();
        //        adaptador.SelectCommand = comando;
        //        adaptador.Fill(_tabla);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }

        //    return _tabla;
        //}
        public SqlDataReader ExecuteReaderSelect(SqlCommand comando)
        {
           // Lector = null;
            //ocommand.Connection = dbconexion;
            //ocommand.CommandType = tipoComando;
            //ocommand.CommandText = consulta;
            try
            {
                dtreader = comando.ExecuteReader();
            }
            catch
            {
                throw;
            }
            return dtreader;
        }
        
    }
}
