using Newtonsoft.Json;
using Project_Manager.Services.BO;
using Project_Manager.Services.DAO;
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
        TblTareasCTRL task = new TblTareasCTRL();
        TblIncidenciasCTRL Inci = new TblIncidenciasCTRL();
        TblRequisitosCTRL Requi = new TblRequisitosCTRL();
        
        // GET: RolEmpleado
        #region Vistas
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
                    ViewBag.proyectosList = juntas.GetAllProjects((int)Session["ID"]);
                    return View();
                }
                else
                    return RedirectToAction("../Login/UserLogin");
            }
            else
                return RedirectToAction("../Login/UserLogin");
        }
        
        public ActionResult Reporte()
        {
            if (Session["Rol"] != null)
            {
                if ((Session["Rol"]).ToString() == "Empleado")
                {
                    int IDJunta = 0;
                    try { IDJunta= int.Parse(Request.QueryString.Get("i")); } catch { }
                    ViewBag.IDJunta = IDJunta;
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

                    ViewBag.incidenciasList = Inci.GetMyIncidencias((int)Session["ID"]);
                    return View();
                }
                else
                    return RedirectToAction("../Login/UserLogin");
            }
            else
                return RedirectToAction("../Login/UserLogin");
        }
        public ActionResult DetalleIncidencia()
        {
            if (Session["Rol"] != null)
            {
                if ((Session["Rol"]).ToString() == "Empleado")
                {
                    int IDIncidencia = 0;
                    try { IDIncidencia = int.Parse(Request.QueryString.Get("i")); } catch { }
                    ViewBag.incidenciasObj = Inci.GetIncidencia(IDIncidencia);
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
                int id = (int)Session["ID"];
                ViewBag.JuntasList = juntas.MisJuntas(id);
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
                ViewBag.incidenciasList = Requi.GetMyRequisitos((int)Session["ID"]);
                return View();
            }
            else
            {
                return RedirectToAction("../Login/UserLogin");
            }
        }
        public ActionResult ListaTareas()
        {
            if (Session["ID"] != null)
            {
                int id = (int)Session["ID"];
                ViewBag.TareasList = task.GetMyTask(id);
                return View();
            }
            else
            {
                return RedirectToAction("../Login/UserLogin");
            }
        }
        #endregion

        #region Metodos 
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
        public int FinalizarTarea()
        {
            int Tarea = int.Parse(Request.Form.Get("Tarea"));
            int TomaTarea = int.Parse(Request.Form.Get("TomaTarea"));
            try
            {
                int res = 0;
                res = task.FinalizarTarea(Tarea, TomaTarea);
                return res;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public int ReporteJunta()
        {
            TblReporteJuntaBO reporte = new TblReporteJuntaBO();
            int Motivo = int.Parse(Request.Form.Get("Motivo"));
            string Descripcion = Request.Form.Get("Descripcion");
            int IDJunta = int.Parse(Request.Form.Get("Junta"));
            reporte.FKEmpleado = (int)Session["ID"];
            reporte.FKJunta = IDJunta;
            reporte.Motivo = Motivo;
            reporte.Descripcion = Descripcion;

            try
            {
                int res = 0;
                res = juntas.NuevoReporte(reporte);
                return res;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public void ImagenThumb()
        {
            int id =int.Parse(Request.QueryString["idMat"]);
            TblIncidenciasDAO img = new TblIncidenciasDAO();
             byte[] _img = img.GetImagen(id);
            try
            {
                if (_img != null)
                {
                    Response.ContentType = "image/jpeg";
                    Response.Cache.SetCacheability(HttpCacheability.Private);
                    Response.BinaryWrite(_img);

                    Response.Flush();
                    Response.End();
                }
            }
            catch
            {
            }
        }
        public void ImagenThumbRe()
        {
            int id = int.Parse(Request.QueryString["idMat"]);
            TblRequisitosDAO img = new TblRequisitosDAO();
            byte[] _img = img.GetImagen(id);
            try
            {
                if (_img != null)
                {
                    Response.ContentType = "image/jpeg";
                    Response.Cache.SetCacheability(HttpCacheability.Private);
                    Response.BinaryWrite(_img);

                    Response.Flush();
                    Response.End();
                }
            }
            catch
            {
            }
        }
        #endregion
    }
}