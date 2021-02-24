using Newtonsoft.Json;
using Project_Manager.Services.BO;
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
        TblProyectosCTRL Tarea = new TblProyectosCTRL();
        TblJunstasCTRL juntas = new TblJunstasCTRL();
        // GET: RolEmpleado
        public ActionResult Index()
        {
            if (Session["Rol"] != null)
            {
                if ((Session["Rol"]).ToString() == "Empleado")
                {
                    int id = (int)Session["ID"];
                    ViewBag.TareasList = Tarea.EmpleadoProyectos(id);
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
                    ViewBag.proyectosList = juntas.GetAllProjects();
                    return View();
                }
                else
                    return RedirectToAction("../Login/UserLogin");
            }
            else
                return RedirectToAction("../Login/UserLogin");
        }
        public ActionResult Incidencias()
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

        public ActionResult ListaJuntas()
        {
            if (Session["ID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("../Login/UserLogin");
            }
        }
        public ActionResult Requisitos()
        {
            if (Session["ID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("../Login/UserLogin");
            }
        }

        public int Sugerencia()
        {
            string data = Request.Form.Get("dataJunta");
            TblJuntasBO programarjunta = JsonConvert.DeserializeObject<TblJuntasBO>(data);
            programarjunta.FKEmpleado = (int)Session["ID"];
            try
            {
                int res = 0;
                res = juntas.Alta(programarjunta);
                return res;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}