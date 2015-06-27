using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data;
using System.Data.SqlClient;
using DataLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class NPlanificacion
    {
        MD_Planificacion oPlanificacion = new MD_Planificacion();
        public List<Conductor> obtenerConductores(int nroSolicitud)
        {

            return oPlanificacion.obtenerConductores(nroSolicitud);
        }
        public List<TractorCisterna> obtenerTractorCisternas(int nroSolicitud)
        {

            return oPlanificacion.obtenerTractorCisterna(nroSolicitud);
        }
        public Int32 registarPlanificacion(int nroSolicitud, DateTime fechaservicio)
        {

            return oPlanificacion.registrarPlanificacion(nroSolicitud, fechaservicio);
        }
        public void actualizarConfiguracion(int codConfiguracion,int idplanificacion,DateTime fechaServicio)
        {

             oPlanificacion.actualizarConfiguracion(codConfiguracion,idplanificacion, fechaServicio);
        }

        public List<Itinerario> obtenerItinerarios(int nroSolicitud)
        {
            return oPlanificacion.obtenerItinerarios(nroSolicitud);
        }

        public void actualizarItinerario(int iditiner, int nroSolicitud, int idplanificacion, int codConductor, DateTime fechaServicio)
        {
           oPlanificacion.actualizarItinerario(iditiner, nroSolicitud,  idplanificacion,  codConductor, fechaServicio);
        }
    }
}
