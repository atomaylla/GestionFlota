using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using EntityLayer;
using System.Globalization;

namespace WebSIGestionFlota.Controllers
{
    public class PlanificacionProgramacionController : Controller
    {

        public ActionResult Index()
        {

            NTipoServicio ntipoServicio = new NTipoServicio();
            SelectList selectTipoServicioList = new SelectList(ntipoServicio.obtenerTipoServicio(), "codigo", "descripcion");
            ViewData["selectTipoServicioList"] = selectTipoServicioList; 
            return View("Index");
        }

        public JsonResult ListSolicitudes(String fecha, String tipoServicio, String option)
        {
             List<Solicitud> listsolicitud = new List<Solicitud>();
            DateTime _fecha = DateTime.Parse(fecha, CultureInfo.InvariantCulture);
            int _tipoServicio = Convert.ToInt32(tipoServicio);          
            NSolicitud nSolicitud = new NSolicitud();

            if (option.Equals("fecha_servicio"))
            {
                listsolicitud = nSolicitud.obtenerSolicitudesFechaEstado(_fecha,1);
            }
            else if (option.Equals("tipo_servicio"))
            {
                listsolicitud = nSolicitud.obtenerSolicitudesTipoEstado(_tipoServicio, 1);
            }
            return Json(listsolicitud, JsonRequestBehavior.AllowGet);

        }
             

         [HttpPost]
        public ActionResult Cargar(int nroSolicitud) {

            NPlanificacion nPlanificacion = new NPlanificacion();
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