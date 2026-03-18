using ajax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ajax.Controllers
{
    public class HomeController : Controller
    {
        #region Index
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region About
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        #endregion

        #region Contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        #endregion

        #region Shippers
        public ActionResult Shippers()
        {
            return View();
        }
        #endregion

        #region Obtener Tabla
        public ActionResult getTabla()
        {
            ShippersBD bd = new ShippersBD();
            List<Shippers> data = new List<Shippers>();
            data = bd.getTabla();
            return Json(new
            {
                result = data
            }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Shipper Data
        [HttpPost]
        public JsonResult ShipperData(Shippers obj)
        {
            ShippersBD bd = new ShippersBD();
            bool respuesta = false;

            switch (obj.opcion)
            {
                case "guardar":
                    if (bd.insertar(obj))
                    {
                        respuesta = true;
                    }
                    else
                    {
                        respuesta = false;
                    }
                    break;
                case "editar":
                    respuesta = bd.editar(obj);
                    break;
                case "eliminar":
                    if (bd.eliminar(obj))
                    {
                        respuesta = true;
                    }
                    else
                    {
                        respuesta = false;
                    }
                    break;
            }

            if (respuesta)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        #endregion

    }
}