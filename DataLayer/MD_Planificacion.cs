using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EntityLayer;

namespace DataLayer
{
   public class MD_Planificacion
    {
       Conexion oaccesodedatos = new Conexion();
       public List<Conductor> obtenerConductores(int nrosolicitud)
       {
          

           List<Conductor> lstconductores = new List<Conductor>();
           SqlCommand _comando = oaccesodedatos.CrearComando(CommandType.StoredProcedure, "listarconductores");
           _comando.Parameters.Add(new SqlParameter("@nrosolicitud", nrosolicitud));
           SqlDataReader dr = oaccesodedatos.ExecuteReaderSelect(_comando);
           while (dr.Read())
           {
               Conductor conduct = new Conductor();
               conduct.codConductor = (int)dr["codConductor"];
               //solicit.fechaServicio = Convert.ToDateTime(dr["fechaServicio"]);
               //solicit.razonCliente = dr["razonCliente"].ToString();
               conduct.nomConductor = dr["nomConductor"].ToString();
              // conduct..estado = dr["estado"].ToString();
               lstconductores.Add(conduct);
           }

           return lstconductores;
       }
       public List<TractorCisterna> obtenerTractorCisterna(int nrosolicitud)
       {
           

           List<TractorCisterna> lsttractorcisternas = new List<TractorCisterna>();
           SqlCommand _comando = oaccesodedatos.CrearComando(CommandType.StoredProcedure, "listartractorcisterna");
           _comando.Parameters.Add(new SqlParameter("@nrosolicitud", nrosolicitud));
           SqlDataReader dr = oaccesodedatos.ExecuteReaderSelect(_comando);
           while (dr.Read())
           {
               TractorCisterna tractorcister = new TractorCisterna();
               tractorcister.codConfiguracion = (int)dr["codConfiguracion"];
               //solicit.fechaServicio = Convert.ToDateTime(dr["fechaServicio"]);
               //solicit.razonCliente = dr["razonCliente"].ToString();
               tractorcister.nroPlacaCisterna = dr["nroPlacaCisterna"].ToString();
               tractorcister.nroPlacaTractor = dr["nroPlacaTractor"].ToString();
               // conduct..estado = dr["estado"].ToString();
               lsttractorcisternas.Add(tractorcister);
           }

           return lsttractorcisternas;
       }

       public Int32 registrarPlanificacion(int nroSolicitud, DateTime fechaservicio)
       {
           SqlCommand _comando = oaccesodedatos.CrearComando(CommandType.StoredProcedure, "registrarsolicitud");
           _comando.Parameters.Add(new SqlParameter("@nrosolicitud", nroSolicitud));
           _comando.Parameters.Add(new SqlParameter("@fechaservicio", fechaservicio));
     
    
           //  _comando.ExecuteNonQuery();
           SqlDataReader dr = oaccesodedatos.ExecuteReaderSelect(_comando);
           dr.Read();
           int nroplanificacion = (int)dr["nroPlanificacion"];
           dr.Close();
           //while (dr.Read())
           //{

           //    int nsolicitud = (int)dr["nroSolicitud"];
           //    nrosolicitud.add(nsolicitud);
           //}

           return nroplanificacion;
       }
       public void actualizarConfiguracion(int codConfiguracion,int idplanificacion,DateTime fechaservicio)
       {
           SqlCommand _comandoIti =  oaccesodedatos.CrearComando(CommandType.StoredProcedure, "actualizarconfiguracion");
          
           _comandoIti.Parameters.Add(new SqlParameter("@codconfiguracion", codConfiguracion));
           _comandoIti.Parameters.Add(new SqlParameter("@idplanificacion",idplanificacion));
           _comandoIti.Parameters.Add(new SqlParameter("@fechaservicio", fechaservicio));
           _comandoIti.ExecuteNonQuery();


       }


       public List<Itinerario> obtenerItinerarios(int nroSolicitud)
       {
           List<Itinerario> lstitinerario = new List<Itinerario>();
           SqlCommand _comando = oaccesodedatos.CrearComando(CommandType.StoredProcedure, "listaritinerarioxsolicitud");
           _comando.Parameters.Add(new SqlParameter("@nrosolicitud", nroSolicitud));
           SqlDataReader dr = oaccesodedatos.ExecuteReaderSelect(_comando);
           while (dr.Read())
           {
               Itinerario iter = new Itinerario();
               iter.codItinerario= (int)dr["codItinerario"];
              
               lstitinerario.Add(iter);
           }

           return lstitinerario;
       }

       public void actualizarItinerario(int iditiner, int nroSolicitud, int idplanificacion, int codConductor, DateTime fechaServicio)
       {
           SqlCommand _comandoIti = oaccesodedatos.CrearComando(CommandType.StoredProcedure, "actualizarItinerarioxsolicitud");

           _comandoIti.Parameters.Add(new SqlParameter("@iditinerario", iditiner));
           _comandoIti.Parameters.Add(new SqlParameter("@nrosolicitud", nroSolicitud));
           _comandoIti.Parameters.Add(new SqlParameter("@idplanificacion", idplanificacion));
           _comandoIti.Parameters.Add(new SqlParameter("@codconductor", codConductor));
           _comandoIti.Parameters.Add(new SqlParameter("@fechaservicio", fechaServicio));
           _comandoIti.ExecuteNonQuery();
       }
    }
}
