using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using EntityLayer;

namespace BusinessLayer
{
   public class NUsuario
    {
       MD_Usuario oUsuario = new MD_Usuario();
       public Usuario LoginUsuario(string desUsuario, string pasUsuario) {

           return oUsuario.LoginUsuario(desUsuario, pasUsuario);
       }

    }
}
