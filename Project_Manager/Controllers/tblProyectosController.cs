using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_Manager.Models;

namespace Project_Manager.Controllers
{
    public class tblProyectosController : Controller
    {
        private BD_APManagerEntities db = new BD_APManagerEntities();

        // GET: tblProyectos
        public async Task<ActionResult> Index()
        {
            var tblProyectos = db.tblProyectos.Include(t => t.tblCliente);
            return View(await tblProyectos.ToListAsync());
        }

        // GET: tblProyectos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProyectos tblProyectos = await db.tblProyectos.FindAsync(id);
            if (tblProyectos == null)
            {
                return HttpNotFound();
            }
            return View(tblProyectos);
        }

        // GET: tblProyectos/Create
        public ActionResult Create()
        {
            ViewBag.FKCliente = new SelectList(db.tblCliente, "IDCliente", "NombreCliente");
            return View();
        }

        // POST: tblProyectos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDProyecto,NombreProyecto,DescripcionProyecto,PrioridadProyecto,FechaProyecto,EstadoProyecto,FKCliente")] tblProyectos tblProyectos)
        {
            if (ModelState.IsValid)
            {
                db.tblProyectos.Add(tblProyectos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FKCliente = new SelectList(db.tblCliente, "IDCliente", "NombreCliente", tblProyectos.FKCliente);
            return View(tblProyectos);
        }

        // GET: tblProyectos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProyectos tblProyectos = await db.tblProyectos.FindAsync(id);
            if (tblProyectos == null)
            {
                return HttpNotFound();
            }
            ViewBag.FKCliente = new SelectList(db.tblCliente, "IDCliente", "NombreCliente", tblProyectos.FKCliente);
            return View(tblProyectos);
        }

        // POST: tblProyectos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDProyecto,NombreProyecto,DescripcionProyecto,PrioridadProyecto,FechaProyecto,EstadoProyecto,FKCliente")] tblProyectos tblProyectos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblProyectos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FKCliente = new SelectList(db.tblCliente, "IDCliente", "NombreCliente", tblProyectos.FKCliente);
            return View(tblProyectos);
        }

        // GET: tblProyectos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProyectos tblProyectos = await db.tblProyectos.FindAsync(id);
            if (tblProyectos == null)
            {
                return HttpNotFound();
            }
            return View(tblProyectos);
        }

        // POST: tblProyectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tblProyectos tblProyectos = await db.tblProyectos.FindAsync(id);
            db.tblProyectos.Remove(tblProyectos);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
