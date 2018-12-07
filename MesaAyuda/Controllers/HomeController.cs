using MesaAyuda.Models;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using MesaAyuda.App_Code;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MesaAyuda.Controllers
{
	public class HomeController : Controller
    {
        SoporteEntities db = new SoporteEntities();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Grados = db.Grados.Where(x => x.EsActivo == true).ToList();
            ViewBag.Categorias = db.Categorias.Where(x => x.EsActivo == true).ToList();

            return View();
        }

		[HttpPost]
		public ActionResult Index(Solicitudes model)
        {
            ViewBag.Grados = db.Grados.Where(x => x.EsActivo == true);
            ViewBag.Categorias = db.Categorias.Where(x => x.EsActivo == true);

			model.Fecha = DateTime.Now;

			db.Solicitudes.Add(model);
			db.SaveChanges();

			this.EnviarCorreo(model.Id);

            return View();
		}
		
		private void EnviarCorreo(int id)
		{
			Solicitudes model = db.Solicitudes.Include(x => x.Incidencias.Categorias).Include(x => x.Grados).FirstOrDefault(x => x.Id == id);

			StringBuilder body = new StringBuilder();
			body.AppendLine("<h2>Solicitud creada</h2>");
			body.AppendLine("<hr />");
			body.AppendLine(string.Format("<p><b>Solicitud Nro.</b> {0}</p>", model.Id));
			body.AppendLine(string.Format("<p><b>Categoria</b> {0}</p>", model.Incidencias.Categorias.Categoria));
			body.AppendLine(string.Format("<p><b>Incidencia</b> {0}</p>", model.Incidencias.Incidencia));
			body.AppendLine(string.Format("<p><b>Enviado por</b> {0}. {1} ({2})</p>", model.Grados.Grado, model.Nombre, model.Correo));
			body.AppendLine(string.Format("<p><b>Comentario</b> {0}</p>", model.Comentario));
			body.AppendLine("<hr />");

			List<string> addresses = new List<string> { model.Correo, "antonio.ramirez@ejercito.mil.co" };

			Helper.SendEmail(
				addresses,
				string.Format("Solicitud de Soporte Nro. {0}",
				model.Id),
				body.ToString());
		}

		public ActionResult CargarIncidencias(int id)
		{
			ViewBag.Incidencias = db.Incidencias.Where(x => x.CategoriaId == id && x.EsActivo == true);

			return PartialView();
		}
	}
}