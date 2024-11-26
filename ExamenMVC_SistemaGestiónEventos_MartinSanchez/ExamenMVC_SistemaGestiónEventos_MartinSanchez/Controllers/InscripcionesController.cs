using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamenMVC_SistemaGestiónEventos_MartinSanchez.DbContext;
using ExamenMVC_SistemaGestiónEventos_MartinSanchez.Models;
using PagedList;

namespace ExamenMVC_SistemaGestiónEventos_MartinSanchez.Controllers
{
    public class InscripcionesController : Controller
    {
        private Context db = new Context();

        // GET: Inscripciones
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;

            ViewBag.NombreEventoSortParam = string.IsNullOrEmpty(sortOrder) ? "evento_desc" : "";
            ViewBag.NombreAsistenteSortParam = sortOrder == "nombre" ? "nombre_desc" : "nombre";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var inscripciones = db.Inscripciones.Include(i => i.Asistente).Include(i => i.Evento);

            if (!string.IsNullOrEmpty(searchString))
            {
                inscripciones = inscripciones.Where(i => i.Evento.Nombre.Contains(searchString) 
                || i.Asistente.Nombre.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "evento_desc":
                    inscripciones = inscripciones.OrderByDescending(i => i.Evento.Nombre);
                    break;
                case "nombre_desc":
                    inscripciones = inscripciones.OrderBy(i => i.Asistente.Nombre);
                    break;
                case "nombre":
                    inscripciones = inscripciones.OrderByDescending(i => i.Asistente.Nombre);
                    break;
                default:
                    inscripciones = inscripciones.OrderBy(i => i.Evento.Nombre);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(inscripciones.ToPagedList(pageNumber, pageSize));
        }

        // GET: Inscripciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscripcion inscripcion = db.Inscripciones.Find(id);
            if (inscripcion == null)
            {
                return HttpNotFound();
            }
            return View(inscripcion);
        }

        // GET: Inscripciones/Create
        public ActionResult Create()
        {
            ViewBag.AsistenteId = new SelectList(db.Asistentes, "Id", "Nombre");
            ViewBag.EventoId = new SelectList(db.Eventos, "Id", "Nombre");
            return View();
        }

        // POST: Inscripciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InscripcionId,EventoId,AsistenteId")] Inscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                db.Inscripciones.Add(inscripcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AsistenteId = new SelectList(db.Asistentes, "Id", "Nombre", inscripcion.AsistenteId);
            ViewBag.EventoId = new SelectList(db.Eventos, "Id", "Nombre", inscripcion.EventoId);
            return View(inscripcion);
        }

        // GET: Inscripciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscripcion inscripcion = db.Inscripciones.Find(id);
            if (inscripcion == null)
            {
                return HttpNotFound();
            }
            ViewBag.AsistenteId = new SelectList(db.Asistentes, "Id", "Nombre", inscripcion.AsistenteId);
            ViewBag.EventoId = new SelectList(db.Eventos, "Id", "Nombre", inscripcion.EventoId);
            return View(inscripcion);
        }

        // POST: Inscripciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InscripcionId,EventoId,AsistenteId")] Inscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inscripcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AsistenteId = new SelectList(db.Asistentes, "Id", "Nombre", inscripcion.AsistenteId);
            ViewBag.EventoId = new SelectList(db.Eventos, "Id", "Nombre", inscripcion.EventoId);
            return View(inscripcion);
        }

        // GET: Inscripciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscripcion inscripcion = db.Inscripciones.Find(id);
            if (inscripcion == null)
            {
                return HttpNotFound();
            }
            return View(inscripcion);
        }

        // POST: Inscripciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inscripcion inscripcion = db.Inscripciones.Find(id);
            db.Inscripciones.Remove(inscripcion);
            db.SaveChanges();
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
