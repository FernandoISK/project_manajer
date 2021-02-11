using Project_Manager.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Manager.Controllers
{
    public class RolEmpleadoController : Controller
    {
        TblProyectoEmpleadoCTRL proyecto = new TblProyectoEmpleadoCTRL();
        // GET: RolEmpleado
        public ActionResult Index()
        {
            if (Session["Rol"] != null)
            {
                if ((Session["Rol"]).ToString() == "Empleado")
                {
                    return View();
                }
                else
                    return RedirectToAction("../Login/UserLogin");
            }
            else
                return RedirectToAction("../Login/UserLogin");
        }
        public ActionResult Juntas()
        {
            if (Session["Rol"] != null)
            {
                if ((Session["Rol"]).ToString() == "Empleado")
                {
                    return View();
                }
                else
                    return RedirectToAction("../Login/UserLogin");
            }
            else
                return RedirectToAction("../Login/UserLogin");
        }
    }
}