using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class NSolicitud
    {
        MD_Solicitud  oSolicitud = new MD_Solicitud();
        public Int32 registarSolicitud(int codcliente, DateTime fechaservicio, int codtiposervicio) {

            return oSolicitud.registrarSolicitud(codcliente, fechaservicio, codtiposervicio);


        }
        public List<Cliente> obtenerClientes()
        {

            return oSolicitud.ObtenerClientes();
        }
        public void registrarItinerario(string origen, string destino, DateTime fechaservicio,string hora, string volcarga, string voldescarga,int nrosolicitud) {
            oSolicitud.registrarItinerario(origen,destino,fechaservicio,hora,volcarga,voldescarga,nrosolicitud);
        }

        public List<Solicitud> obtenerSolicitudes(char estado){ 

          return oSolicitud.obtenerSolicitudes(estado);
        }
        public List<Solicitud> obtenerSolicitudesFecha(DateTime fechaservicio)
        {

            return oSolicitud.obtenerSolicitudesFecha(fechaservicio);
        }
        public List<Solicitud> obtenerSolicitudesTipo(int tiposervicio)
        {

            return oSolicitud.obtenerSolicitudesTipo(tiposervicio);
        }
        public void updateEstadoSolicitud(int nroSolicitud , char estado) {
             oSolicitud.updateEstadoSolicitud(nroSolicitud, estado);
        }
    }
}
