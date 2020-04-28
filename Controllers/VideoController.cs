using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.SqlClient;
using System.Data;
using MVCLaboratorio.Models;
using MVCLaboratorio.Utilerias;

namespace MVCLaboratorio.Controllers
{
    public class VideoController : Controller
    {
        //
        // GET: /Video/
        //pagina principal de los videos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Video datosVideo)
        {
            //guardar el video en la base de datos
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Nombre", datosVideo.Nombre));
            parametros.Add(new SqlParameter("@Url",datosVideo.Url));
            parametros.Add(new SqlParameter("@FechaPublicacion ", datosVideo.FechaPublicacion));

            BaseHelper.ejecutarSentencia("sp_Video_Insertar", CommandType.StoredProcedure, parametros);

            return RedirectToAction("Index");
        }

    }
}
