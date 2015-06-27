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

        public List<Solicitud> obtenerSolicitudesEstado(char estado)
        {
            return oSolicitud.obtenerSolicitudesEstado(estado);
        }
        public List<Solicitud> obtenerSolicitudesFechaEstado(DateTime fechaservicio, int estado)
        {

            return oSolicitud.obtenerSolicitudesFechaEstado(fechaservicio, estado);
        }
        public List<Solicitud> obtenerSolicitudesTipoEstado(int tiposervicio, int estado)
        {

            return oSolicitud.obtenerSolicitudesTipoEstado(tiposervicio, estado);
        }
        public void updateEstadoSolicitud(int nroSolicitud , char estado) {
             oSolicitud.updateEstadoSolicitud(nroSolicitud, estado);
        }
    }
}
