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
    public class tblEmpleadoesController : Controller
    {
        private BD_APManagerEntities db = new BD_APManagerEntities();

        // GET: tblEmpleadoes
        public async Task<ActionResult> Index()
        {
            var tblEmpleado = db.tblEmpleado.Include(t => t.tblCuenta).Include(t => t.tblRol);
            return View(await tblEmpleado.ToListAsync());
        }

        // GET: tblEmpleadoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmpleado tblEmpleado = await db.tblEmpleado.FindAsync(id);
            if (tblEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(tblEmpleado);
        }

        // GET: tblEmpleadoes/Create
        public ActionResult Create()
        {
            ViewBag.FKCuenta = new SelectList(db.tblCuenta, "IDCuenta", "CorreoCuenta");
            ViewBag.FKRol = new SelectList(db.tblRol, "IDRol", "Rol");
            return View();
        }

        // POST: tblEmpleadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDEmpleado,NombreEmpleado,ApellidoEmpleado,TelefonoEmpleado,Nacimiento,GeneroEmpleado,FKRol,FKCuenta")] tblEmpleado tblEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.tblEmpleado.Add(tblEmpleado);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FKCuenta = new SelectList(db.tblCuenta, "IDCuenta", "CorreoCuenta", tblEmpleado.FKCuenta);
            ViewBag.FKRol = new SelectList(db.tblRol, "IDRol", "Rol", tblEmpleado.FKRol);
            return View(tblEmpleado);
        }

        // GET: tblEmpleadoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmpleado tblEmpleado = await db.tblEmpleado.FindAsync(id);
            if (tblEmpleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.FKCuenta = new SelectList(db.tblCuenta, "IDCuenta", "CorreoCuenta", tblEmpleado.FKCuenta);
            ViewBag.FKRol = new SelectList(db.tblRol, "IDRol", "Rol", tblEmpleado.FKRol);
            return View(tblEmpleado);
        }

        // POST: tblEmpleadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDEmpleado,NombreEmpleado,ApellidoEmpleado,TelefonoEmpleado,Nacimiento,GeneroEmpleado,FKRol,FKCuenta")] tblEmpleado tblEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEmpleado).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FKCuenta = new SelectList(db.tblCuenta, "IDCuenta", "CorreoCuenta", tblEmpleado.FKCuenta);
            ViewBag.FKRol = new SelectList(db.tblRol, "IDRol", "Rol", tblEmpleado.FKRol);
            return View(tblEmpleado);
        }

        // GET: tblEmpleadoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmpleado tblEmpleado = await db.tblEmpleado.FindAsync(id);
            if (tblEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(tblEmpleado);
        }

        // POST: tblEmpleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tblEmpleado tblEmpleado = await db.tblEmpleado.FindAsync(id);
            db.tblEmpleado.Remove(tblEmpleado);
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
