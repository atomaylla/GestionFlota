using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using EntityLayer;
using System.Data;
using System.Data.SqlClient;



namespace WebSIGestionFlota.Controllers
{

    public class SolicitudProgramacionController : Controller
    {
        //
        // GET: /SolicitudProgramacion/
        NSolicitud nSolicitud = new NSolicitud();
        Itinerario iter = new Itinerario();
        Solicitud solicitud = new Solicitud();

        public List<Itinerario> listitinerarios;
        public List<Solicitud> listsolicitud = new List<Solicitud>();
        public ActionResult Index()
        {
          //  listiti = new List<Itinerario>();
            listsolicitud = nSolicitud.obtenerSolicitudes('0');
            ViewData["Solicitudes"]=listsolicitud;
            return View();
        }
        public ActionResult Registrar()
        {
            List<Cliente> listclient = nSolicitud.obtenerClientes();
            ViewData["Cliente"]= listclient;
          //  TempData["listitinerarios"] = null;
            return View();
           

            
        }
        [HttpPost]
        public ActionResult Enviar()
        {
            int codcliente = int.Parse(Request["cboclientes"]);
            DateTime fechainicio = Convert.ToDateTime(Request["fechaservicio"].ToString());
            int codtiposervicio = int.Parse(Request["cbotiposervicio"]);
            
            Int32 idsolicitud = nSolicitud.registarSolicitud(codcliente, fechainicio, codtiposervicio);
            
            iter.itinerarios = (List<Itinerario>)Session["listitinerarios"];
           
            foreach (var iti in iter.itinerarios)
            {

                string origend= iti.origen.ToString();
                string destinod= iti.destino.ToString();
                DateTime fechaserviciod= Convert.ToDateTime(iti.fechaServicio);
                string volcargadod= iti.cantidad.ToString();
                string voldescargad= iti.cantidad.ToString();
               nSolicitud.registrarItinerario(origend,destinod, fechaserviciod, volcargadod,voldescargad,idsolicitud);

            }
            

            return RedirectToAction("Index","SolicitudProgramacion");
        }
        [HttpPost]
        public ActionResult CargarIti( Itinerario itiner) {
           

           if (Session["listitinerarios"] != null)
            {
                listitinerarios = (List<Itinerario>)Session["listitinerarios"];
            }
            else {
                listitinerarios = new List<Itinerario>();
            }
            
            Itinerario itiadd = new Itinerario();
            // iter.itinerarios= new List<Itinerario>();
             itiadd=new Itinerario{origen= itiner.origen, destino= itiner.destino,fechaServicio= itiner.fechaServicio,tipoAccion=itiner.tipoAccion,cantidad=itiner.cantidad};

             listitinerarios.Add(itiadd);
            //return RedirectToAction("Index", "SolicitudProgramacion");
             ViewData["listitinerarios"] = listitinerarios;

             Session["listitinerarios"] = listitinerarios;
            // if (Request.IsAjaxRequest())
                 return PartialView();
            // else return View();
        }
	}
}