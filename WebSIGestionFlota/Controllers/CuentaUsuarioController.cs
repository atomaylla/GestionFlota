using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using EntityLayer;

namespace WebSIGestionFlota.Controllers
{
    public class CuentaUsuarioController : Controller
    {
        //
        // GET: /CuentaUsuario/
        NUsuario nuser = new NUsuario();
        public ActionResult Index()
        {
            //Session.Remove("iduser");
            return View();
        }
        [HttpPost]
        public ActionResult Login() {
              string nombreuser= Request["nomusuario"].ToString();
              string contrauser = Request["contrausuario"].ToString();
              Usuario user =nuser.LoginUsuario(nombreuser,contrauser);

              if (user.codUsuario != 0)
              {
                  string desuser = user.desUsuario;
                  int codUser = user.codUsuario;
                  if (desuser == "admin")
                  {
                      ViewData["rol"] = 1;
                  }
                  else
                  {
                      ViewData["rol"] = 2;
                  }
                  Session["idUser"] = codUser;
                  
                  return View("~/Views/CuentaUsuario/Login.cshtml");
              }
              else {
                  TempData["message"] = "Datos incorrectos";
                 return  RedirectToAction("Index", "CuentaUsuario");
                  //return View("~/Views/CuentaUsuario/Index.cshtml");
              }
              
              //else
              //{
              //    return RedirectToAction("Index", "CuentaUsuario");

              //}
            
        }

        public ActionResult Logout()
        {
            Session.Remove("iduser");
            return RedirectToAction("Index", "CuentaUsuario");
        }
	}
}