using CamionesApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CamionesApp.Controllers
{
    public class HomeController : Controller
    {
        public CamionesAppEntities dbApp = new CamionesAppEntities();
        [Authorize]
        public ActionResult Index()
        {
            string userName = User.Identity.Name;
            AspNetUsers Usuario = dbApp.AspNetUsers.Where(x => x.UserName.Equals(userName)).First();
            List<AspNetUsers> listaCamioneros = null;
            if (Usuario.tipodeUsuario.Equals("usuario"))
            {
                listaCamioneros = dbApp.AspNetUsers.Where(x => x.tipodeUsuario.Equals("camionero") && x.activo == 1).ToList();
            }
            else
            {
             
                return View("VistaCamionero",Usuario);
            }

            ViewBag.ListaCamioneros = listaCamioneros;
            return View();
        }

        public ActionResult MapaCamionero(string UsuarioCamionero)
        {
            AspNetUsers Usuario = dbApp.AspNetUsers.Where(x => x.UserName.Equals(UsuarioCamionero)).First();

            ViewBag.UsuarioCamion = Usuario;
            ViewBag.Latitud = Usuario.latitud;
            ViewBag.Longitud = Usuario.longitud;

            return View();
        }

       

        [HttpPost]
        public ActionResult CoordsCamion(string UsuarioCamion)
        {
            AspNetUsers Usuario = dbApp.AspNetUsers.Where(x => x.UserName.Equals(UsuarioCamion)).First();

            ViewBag.Latitud = Usuario.latitud;
            ViewBag.Longitud = Usuario.longitud;



            return View(Usuario);
        }

        [HttpPost]
        public ActionResult ActualizarCoordenadas(string UsuarioCamion,string latitudCamionero,string longitudCamionero,string activoCamionero)
        {
            AspNetUsers Usuario = dbApp.AspNetUsers.Where(x => x.UserName.Equals(UsuarioCamion)).First();
            Usuario.latitud = latitudCamionero;
            Usuario.longitud = longitudCamionero;
            Usuario.activo =Int32.Parse(activoCamionero);

            dbApp.Entry(Usuario).State = EntityState.Modified;
            dbApp.SaveChangesAsync();

            ViewBag.Latitud = Usuario.latitud;
            ViewBag.Longitud = Usuario.longitud;



            return View("CoordsCamion",Usuario);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}