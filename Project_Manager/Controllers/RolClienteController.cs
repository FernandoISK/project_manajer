using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Manager.Controllers
{
    public class RolClienteController : Controller
    {
        // GET: RolCliente
        public ActionResult Index()
        {
            if (Session["Rol"] != null)
            {
                if ((Session["Rol"]).ToString() == "Cliente")
                {
                    return View();
                }
                else
                    return RedirectToAction("../Login/UserLogin");
            }
            else
                return RedirectToAction("../Login/UserLogin");
        }
        public ActionResult Agendas()
        {
            return View();
        }
    }
}