using MesaAyuda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MesaAyuda.Controllers
{
    public class AdminController : Controller
    {
		SoporteEntities db = new SoporteEntities();

		public ActionResult Index()
        {
            return View();
        }
		
		public ActionResult Solicitudes()
		{
			return View(db.Solicitudes);
		}

		public ActionResult Solicitud(int id)
		{
			return View(db.Solicitudes.Find(id));
		}
	}
}