using Project_Manager.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Manager.Controllers
{
    public class ProyectosController : Controller
    {
        TblProyectosCTRL proyecto = new TblProyectosCTRL();
        TblClienteCTRL cliente = new TblClienteCTRL();
        // GET: Proyectos
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            ViewBag.ClienteList = cliente.TraerClienteiD();
            return View();
        }
    }
}