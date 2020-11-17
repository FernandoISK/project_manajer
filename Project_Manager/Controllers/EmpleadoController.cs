using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Manager.Services.BO;
using Project_Manager.Services.Services;
using Newtonsoft.Json;

namespace Project_Manager.Controllers
{
    public class EmpleadoController : Controller
    {
        TblEmpleadoCTRL Employees = new TblEmpleadoCTRL();
        TblCuentaCTRL Login = new TblCuentaCTRL();
        // GET: Empleado
        public ActionResult Index()
        {
            ViewBag.EmpleadoList = Employees.GetAll();  //llena el ViewBag con el metodo GetAll hubicado en la carpeta Services
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        public int New()
        {
            string data = Request.Form.Get("dataEmpleado");
            TblEmpleadoBO empleado = JsonConvert.DeserializeObject<TblEmpleadoBO>(data);
            TblCuentaBO login = new TblCuentaBO();
            empleado.FKRol = "Empleado";
            login.Correo = empleado.CorreoEmpleado;
            login.Contra = empleado.ContraEmpleado;
            login.Usuario = empleado.FKUsuario;
            login.Rol = "Empleado";
            login.Estatus = 0;


            try
            {
                int res = 0;
                res = Login.Alta(login);
                res = 0;
                res = Employees.Alta(data);
                return res;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        //get = 
        public int UpdateStatus()
        {
            int estatus = 1;
            int id = int.Parse(Request.Form.Get("id"));
            try
            {
                int res = Employees.Baja(id, estatus);
                return res;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}