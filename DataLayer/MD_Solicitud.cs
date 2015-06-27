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
    public class MD_Solicitud
    {
        Conexion oaccesodedatos = new Conexion();

       
        public List<Solicitud> obtenerSolicitudesEstado(char estado) {

            List<Solicitud> lstsolicitudes = new List<Solicitud>();
            SqlCommand _comando = oaccesodedatos.CrearComando(CommandType.StoredProcedure, "listarsolicitudesestado");
            _comando.Parameters.Add(new SqlParameter("@estado", estado));     
                   
                        
            SqlDataReader dr = oaccesodedatos.ExecuteReaderSelect(_comando);
            while (dr.Read())
            {
                Solicitud solicit = new Solicitud();
                solicit.nroSolicitud = (int)dr["nroSolicitud"];
                solicit.fechaServicio = Convert.ToDateTime(dr["fechaServicio"]);
                solicit.razonCliente = dr["razonCliente"].ToString();
                solicit.nomTipoServicio = dr["nomtipoServicio"].ToString();
                solicit.estado= dr["estado"].ToString();
                lstsolicitudes.Add(solicit);
            }

            return lstsolicitudes;
        }

        public List<Solicitud> obtenerSolicitudesFechaEstado(DateTime fechaservicio, int estado)
        {

            List<Solicitud> lstsolicitudes = new List<Solicitud>();
            SqlCommand _comando = oaccesodedatos.CrearComando(CommandType.StoredProcedure, "listarsolicitudesfechaestado");
            _comando.Parameters.Add(new SqlParameter("@fechaservicio", fechaservicio));
            _comando.Parameters.Add(new SqlParameter("@estado", estado));
            SqlDataReader dr = oaccesodedatos.ExecuteReaderSelect(_comando);
            while (dr.Read())
            {
                Solicitud solicit = new Solicitud();
                solicit.nroSolicitud = (int)dr["nroSolicitud"];
                solicit.fechaServicio = Convert.ToDateTime(dr["fechaServicio"]);
                solicit.razonCliente = dr["razonCliente"].ToString();
                solicit.nomTipoServicio = dr["nomtipoServicio"].ToString();
                solicit.estado = dr["estado"].ToString();
                lstsolicitudes.Add(solicit);
            }

            return lstsolicitudes;
        }
        public List<Solicitud> obtenerSolicitudesTipoEstado(int tiposervicio, int estado)
        {

            List<Solicitud> lstsolicitudes = new List<Solicitud>();
            SqlCommand _comando = oaccesodedatos.CrearComando(CommandType.StoredProcedure, "listarsolicitudestipoestado");
            _comando.Parameters.Add(new SqlParameter("@tiposervicio", tiposervicio));
            _comando.Parameters.Add(new SqlParameter("@estado", estado));
            SqlDataReader dr = oaccesodedatos.ExecuteReaderSelect(_comando);
            while (dr.Read())
            {
                Solicitud solicit = new Solicitud();
                solicit.nroSolicitud = (int)dr["nroSolicitud"];
                solicit.fechaServicio = Convert.ToDateTime(dr["fechaServicio"]);
                solicit.razonCliente = dr["razonCliente"].ToString();
                solicit.nomTipoServicio = dr["nomtipoServicio"].ToString();
                solicit.estado = dr["estado"].ToString();
                lstsolicitudes.Add(solicit);
            }

            return lstsolicitudes;
        }
        public void updateEstadoSolicitud(int nroSolicitud, char estado) {

            SqlCommand _comando = oaccesodedatos.CrearComando(CommandType.StoredProcedure, "updatesolicidtudestado");
            _comando.Parameters.Add(new SqlParameter("@nrosolicitud", nroSolicitud));
            _comando.Parameters.Add(new SqlParameter("@estado", estado));
            _comando.ExecuteNonQuery();
        }
        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            SqlCommand _comando = oaccesodedatos.CrearComando(CommandType.Text, "SELECT * FROM cliente");

            SqlDataReader dr = oaccesodedatos.ExecuteReaderSelect(_comando);
            while (dr.Read())
            {
                Cliente client = new Cliente();
                client.codCliente = (int)dr["codCliente"];
                client.razonSocial = dr["razonSocial"].ToString();
                
                clientes.Add(client);
            }

            return clientes;
        }

        public Int32 registrarSolicitud(int codcliente, DateTime fechaservicio, int codtiposervicio) {
            SqlCommand _comando = oaccesodedatos.CrearComando(CommandType.StoredProcedure, "registrarsolicitud");
            _comando.Parameters.Add(new SqlParameter("@fechaservicio", fechaservicio));
            _comando.Parameters.Add(new SqlParameter("@codcliente", codcliente));
            _comando.Parameters.Add(new SqlParameter("@codtiposervicio", codtiposervicio));
            //  _comando.ExecuteNonQuery();
            SqlDataReader dr = oaccesodedatos.ExecuteReaderSelect(_comando);
            dr.Read();
            int nrosolicitud =(int)dr["nroSolicitud"];
            dr.Close();
            //while (dr.Read())
            //{

            //    int nsolicitud = (int)dr["nroSolicitud"];
            //    nrosolicitud.add(nsolicitud);
            //}

            return nrosolicitud;
        }

        public void registrarItinerario(string origen, string destino, DateTime fechaservicio, string horasalida, string volcarga, string voldescarga,int nrosolicitud)
        {
            SqlCommand _comandoIti = oaccesodedatos.CrearComando(CommandType.StoredProcedure, "registraritinerario");
            _comandoIti.Parameters.Add(new SqlParameter("@origen", origen));
            _comandoIti.Parameters.Add(new SqlParameter("@destino", destino));
            _comandoIti.Parameters.Add(new SqlParameter("@fechasalida", fechaservicio));
            _comandoIti.Parameters.Add(new SqlParameter("@horasalida", horasalida));
            _comandoIti.Parameters.Add(new SqlParameter("@volcarg", volcarga));
            _comandoIti.Parameters.Add(new SqlParameter("@voldescarg", voldescarga));
            _comandoIti.Parameters.Add(new SqlParameter("@nrosolicitud", nrosolicitud));
            _comandoIti.ExecuteNonQuery();
           
           
        }
    }
}
