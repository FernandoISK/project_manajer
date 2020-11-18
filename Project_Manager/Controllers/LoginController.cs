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

        public int Validar()
        {
            string usuario = Request.Form.Get("usuario");
            string contraseña = Request.Form.Get("contraseña");

            TblCuentaBO login = new TblCuentaBO();

            login.Usuario = usuario;
            login.Contra = contraseña;

            try
            {
                int res = 0;
                res = Convert.ToInt32(Cuenta.GetAll_Cuenta(login));
                return res;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

    }
}

