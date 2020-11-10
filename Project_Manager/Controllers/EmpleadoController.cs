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
        // GET: Empleado
        public ActionResult Index()
        {
            //////string FilterProductName = Request.QueryString["e"];
            //////ViewBag.FilterNameB = FilterProductName;
            ViewBag.EmpleadoList = Employees.GetAll();  //llena el ViewBag con el metodo GetAll hubicado en la carpeta Services
            return View();
        }
        public ActionResult Create()
        {

            return View();
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