using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using EntityLayer;

namespace WebSIGestionFlota.Controllers
{
    public class AtenderSolicitudController : Controller
    {
        //
        // GET: /AtenderSolicitud/
        NSolicitud nSolicitud = new NSolicitud();
        public List<Solicitud> listsolicitud = new List<Solicitud>();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SolicitudesAprobadas() {
           // listsolicitud = nSolicitud.obtenerSolicitudes('1');
            ViewData["Solicitudes"] = listsolicitud;
            return View();
           
        }

        public ActionResult SolicitudesRechazadas() {
           // listsolicitud = nSolicitud.obtenerSolicitudes('2');
            ViewData["Solicitudes"] = listsolicitud;
            return View();
        }
        [HttpPost]
        public ActionResult listarSolicitudes(string opcionlist , string fechaservicio, int tiposervicio) {


            if (opcionlist == "fecha")
            {
                DateTime fechaser = Convert.ToDateTime(fechaservicio);
                listsolicitud = nSolicitud.obtenerSolicitudesFechaEstado(fechaser,0);
                ViewData["Solicitudes"] = listsolicitud;
            }
            else {
                listsolicitud = nSolicitud.obtenerSolicitudesTipoEstado(tiposervicio,0);
                ViewData["Solicitudes"] = listsolicitud;
            }

            return View();
        }

        [HttpPost]
        public ActionResult atenderSolicitudes(String[] listanros) 
        {
                foreach (var item in listanros) {

                    int nrosoli=Convert.ToInt32(item);
                    nSolicitud.updateEstadoSolicitud(nrosoli, '1');
               }

            return View();
        }
         [HttpPost]
        public ActionResult rechazarSolicitudes(String[] listanros)
        {
            foreach (var item in listanros)
            {

                int nrosoli = Convert.ToInt32(item);
                nSolicitud.updateEstadoSolicitud(nrosoli, '2');
            }

            return RedirectToAction("Index", "SolicitudProgramacion");
        }
        
	}
}