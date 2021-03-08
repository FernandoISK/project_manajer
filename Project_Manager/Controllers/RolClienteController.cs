using Newtonsoft.Json;
using Project_Manager.Services.BO;
using Project_Manager.Services.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Project_Manager.Controllers
{
    public class RolClienteController : Controller
    {
        TblProyectosCTRL Tarea = new TblProyectosCTRL();
        TblJunstasCTRL Juntas = new TblJunstasCTRL();
        TblIncidenciasCTRL IncidenciasMT = new TblIncidenciasCTRL();
        TblRequisitosCTRL RequisitosMT = new TblRequisitosCTRL();
        TblJunstasCTRL juntas = new TblJunstasCTRL();
        // GET: RolCliente
        #region Vistas
        public ActionResult Index()
        {
            if (Session["Rol"] != null)
            {
                if ((Session["Rol"]).ToString() == "Cliente")
                {
                    int id = (int)Session["ID"];
                    ViewBag.TareasList = Tarea.clienteProyectos(id);
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
            if (Session["Rol"] != null)
            {
                if ((Session["Rol"]).ToString() == "Cliente")
                {
                    string id = "";
                    try { id = Request.QueryString.Get("i"); } catch { }
                    Juntas.LeidoCliente(int.Parse(id));
                    ViewBag.JuntasObj = Juntas.GetAMeet(int.Parse(id));
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
            if (Session["Rol"] != null)
            {
                if ((Session["Rol"]).ToString() == "Cliente")
                {
                    int id = (int)Session["ID"];
                    ViewBag.JuntasList = Juntas.GetMyMeetings(id);
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
            if (Session["ID"] != null)
            {
                ViewBag.incidenciasList = IncidenciasMT.GetMyIncidencias((int)Session["ID"]);
                return View();
            }
            else
            {
                return RedirectToAction("../Login/UserLogin");
            }
        }
        public ActionResult Requesitos()
        {
            if (Session["ID"] != null)
            {
                ViewBag.incidenciasList = RequisitosMT.GetMyRequisitos((int)Session["ID"]);
                return View();
            }
            else
            {
                return RedirectToAction("../Login/UserLogin");
            }
        }
        public ActionResult CreateRequisito()
        {
            if (Session["ID"] != null)
            {
                string IDProyecto = "";
                try { IDProyecto = Request.QueryString.Get("i"); } catch { }
                ViewBag.IdProyecto = IDProyecto;
                return View();
            }
            else
            {
                return RedirectToAction("../Login/UserLogin");
            }
        }
        public ActionResult CreateIncidencia()
        {
            if (Session["ID"] != null)
            {
                string IDProyecto = "";
                try { IDProyecto = Request.QueryString.Get("i"); } catch { }
                ViewBag.IdProyecto = IDProyecto;
                return View();
            }
            else
            {
                return RedirectToAction("../Login/UserLogin");
            }
        }
        #endregion
        #region Metodos
        public int Updatedate()
        {
            string Fecha = Request.Form.Get("Fecha");
            string hora = Request.Form.Get("hora");
            int id = int.Parse(Request.Form.Get("id"));
            try
            {
                int res = 0;
                res = Juntas.actualizarFecha(id, Fecha, hora);
                return res;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public int Confirmar()
        {

            int id = int.Parse(Request.Form.Get("id"));
            try
            {
                int res = 0;
                res = Juntas.confirmarJunta(id);
                return res;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int NewRequisito()
        {
            string data = Request.Form.Get("DatosRequisitos");
            TblRequisitosBO obj = JsonConvert.DeserializeObject<TblRequisitosBO>(data);
            
            try
            {
                int res = 0;
                res = RequisitosMT.Alta(obj);
                return res;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public int NewInsidencia()
        {
            string data = Request.Form.Get("DatosIncidencia");
            TblIncidenciasBO obj = JsonConvert.DeserializeObject<TblIncidenciasBO>(data);
            try
            {
                int res = 0;
                res = IncidenciasMT.Alta(obj);
                return res;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion
    }
}