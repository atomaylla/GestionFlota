using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;
using EntityLayer;

namespace WebSIGestionFlota.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/
        UsuarioNe nUsuario = new UsuarioNe();
        public ActionResult Index()
        {
            //DataTable dt = new DataTable();
            //dt = nUsuario.obtenerUsuarios();
            //List<Usuario> lstusu = new List<Usuario>();
            //foreach(DataRow row in dt.Rows){
            //    lstusu.Add(new Usuario {
            //        codUsuario= (int)row["codUsuario"],
            //        desUsuario= row["desUsuario"].ToString(),
            //        pasUsuario= row["pasUsuario"].ToString(),
            //        codPersona= (int)row["codPersona"]
                
            //    });
            //}

            //List<Usuario> lstusu = nUsuario.obtenerUser();

           // ViewData.Model = dt;
            return View();
        }
        public ActionResult prueba(){
        return View();
        }
	}
}