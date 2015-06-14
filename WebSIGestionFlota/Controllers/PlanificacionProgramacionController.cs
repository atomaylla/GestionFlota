using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using EntityLayer;

namespace WebSIGestionFlota.Controllers
{
    public class PlanificacionProgramacionController : Controller
    {
        //
        // GET: /PlanificacionProgramacion/

        NPlanificacion nPlanificacion = new NPlanificacion();
        NSolicitud nSolicitud = new NSolicitud();
        public List<Solicitud> listsolicitud = new List<Solicitud>();
        //public List<Conductor> listconductor = new List<Conductor>();
        public ActionResult Index()
        {
            listsolicitud = nSolicitud.obtenerSolicitudes('1');
            ViewData["Solicitudes"] = listsolicitud;
            return View();
           
        }

         [HttpPost]
        public ActionResult Cargar(int nroSolicitud) {
            List<Conductor> listconductores = nPlanificacion.obtenerConductores(nroSolicitud);
            List<TractorCisterna> listtractorcisterna = nPlanificacion.obtenerTractorCisternas(nroSolicitud);
             Session["nroSolicitud"] = nroSolicitud;
            ViewData["Conductores"] = listconductores;
            ViewData["Unidades"] = listtractorcisterna;
            return View();
        
        }
        public ActionResult Registrar()
        {
            return View();
        }
     //   [HttpPost]
     //   public ActionResult EnviarPlanificacion() {
     //       int nroSolicitud = (int)Session["nroSolicitud"];
     //       DateTime fechaServicio = Convert.ToDateTime("12/06/2015");
     //       int codConductor = int.Parse(Request["cbotiposervicio"]);
     //       int codConfiguracion = int.Parse(Request["unidad"]);
     ////       Int32 idplanificacion = nPlanificacion.registarPlanificacion(nroSolicitud, fechaServicio);
     //       Int32 idplanificacion = 1;
     //       nPlanificacion.actualizarConfiguracion(codConfiguracion,idplanificacion, fechaServicio);
     //       List<Itinerario> listitinerario = nPlanificacion.obtenerItinerarios(nroSolicitud);

     //       foreach (var iti in listitinerario)
     //       {
     //           int iditiner= (int)iti.codItinerario;
     //           nPlanificacion.actualizarItinerario(iditiner,nroSolicitud, idplanificacion,codConductor,fechaServicio);

     //       }
     //       return View();
     //   }
	}
}