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
     
        NUsuario nuser = new NUsuario();
        public ActionResult Login()
        {           
            return View("Login");
        }


            [HttpPost]
        public JsonResult Logueo(string user, string pass){
              string nombreuser= Convert.ToString(user);
              string contrauser = Convert.ToString(pass);

              Usuario usuario =nuser.LoginUsuario(nombreuser,contrauser);

              if (usuario.codUsuario != 0)
              {
                  string desuser = usuario.desUsuario;
                  int codUser = usuario.codUsuario;
                  if (desuser == "admin")
                  {
                      ViewData["rol"] = 1;
                  }
                  else
                  {
                      ViewData["rol"] = 2;
                  }
                  Session["idUser"] = codUser;

                  
              }

              return Json(usuario);
        }

        public ActionResult Logout()
        {
            Session.Remove("iduser");
            return RedirectToAction("Login");
        }
	}
}