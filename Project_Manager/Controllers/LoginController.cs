using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Manager.Services.BO;
using Project_Manager.Services.Services;

namespace Project_Manager.Controllers
{
    public class LoginController : Controller
    {
        TblCuentaCTRL Cuenta = new TblCuentaCTRL();
        // GET: Login
        public ActionResult UserLogin()
        {
            return View();
        }

        //GET
        public int Validar()
        {
            string usuario = Request.QueryString["usuario"];
            string contraseña = Request.QueryString["contraseña"];
            try
            {
                //int res = Cuenta.login(usuario, contraseña);
                ViewBag.EmpleadoList = Cuenta.login(usuario, contraseña);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}