using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Manager.Services.BO;
using Project_Manager.Services.Services;

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
            string nombre = Request.Form.Get("nombre");
            string apellidop = Request.Form.Get("apellidop");
            string apellidom = Request.Form.Get("apellidom");
            string telefono = Request.Form.Get("telefono");
            string nacimineto = Convert.ToString(Request.Form.Get("nacimineto"));
            string genero = Request.Form.Get("genero");
            string correo = Request.Form.Get("correo");
            string contraseña = Request.Form.Get("contraseña");
            string usuario = Request.Form.Get("usuario");

            TblEmpleadoBO data = new TblEmpleadoBO();
            TblCuentaBO login = new TblCuentaBO();
            data.NombreEmpleado = nombre;
            data.ApellidoPEmpleado = apellidop;
            data.ApellidoMEmpleado = apellidom;
            data.TelefonoEmpleado = telefono;
            data.Nacimiento = nacimineto;
            data.GeneroEmpleado = genero;
            data.CorreoEmpleado = correo;
            data.ContraEmpleado = contraseña;
            data.FKUsuario = usuario;
            data.FKRol = "Empleado";
            login.Correo = correo;
            login.Contra = contraseña;
            login.Usuario = usuario;
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
            int estatus = int.Parse(Request.Form.Get("estatus"));
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