using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Manager.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["Rol"] != null)
            {
                if ((Session["Rol"]).ToString() == "Administrador")
                {
                    return View();
                }
                else if ((Session["Rol"]).ToString() == "Empleado")
                {
                    return RedirectToAction("../RolEmpleado/Index");
                }else if((Session["Rol"]).ToString() == "Cliente")
                {
                    return RedirectToAction("../RolCliente/Index");
                }
                return null;
            }
            else
                return RedirectToAction("../Login/UserLogin");
        }
    }
}