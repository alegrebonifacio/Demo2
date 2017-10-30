using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class PremioNobelsController : Controller
    {
        private NobelEntities db = new NobelEntities();

        // GET: PremioNobels
        public ActionResult Index()
        {
            //var premioNobel = db.PremioNobel.Include(p => p.Categoria);
            var premioNobel = db.PremioNobel.Include(p => p.Categoria).OrderBy(p=>p.Ano);
            return View(premioNobel.ToList());
        }

        // GET: PremioNobels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int theId = id ?? 1;
            //PremioNobel premioNobel = db.PremioNobel.Find(id);
            PremioNobel premioNobel = db.PremioNobel.Where(p => p.PremioNobelId == theId)
                .Include("Laureado")
                .FirstOrDefault();
            if (premioNobel == null)
            {
                return HttpNotFound();
            }
            return View(premioNobel);
        }

        // GET: PremioNobels/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categoria, "CategoriaId", "Nome");
            return View();
        }

        // POST: PremioNobels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PremioNobelId,Ano,CategoriaId,Titulo,Motivacao")] PremioNobel premioNobel)
        {
            if (ModelState.IsValid)
            {
                db.PremioNobel.Add(premioNobel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categoria, "CategoriaId", "Nome", premioNobel.CategoriaId);
            return View(premioNobel);
        }

        // GET: PremioNobels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PremioNobel premioNobel = db.PremioNobel.Find(id);
            if (premioNobel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categoria, "CategoriaId", "Nome", premioNobel.CategoriaId);
            return View(premioNobel);
        }

        // POST: PremioNobels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PremioNobelId,Ano,CategoriaId,Titulo,Motivacao")] PremioNobel premioNobel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(premioNobel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categoria, "CategoriaId", "Nome", premioNobel.CategoriaId);
            return View(premioNobel);
        }

        // GET: PremioNobels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PremioNobel premioNobel = db.PremioNobel.Find(id);
            if (premioNobel == null)
            {
                return HttpNotFound();
            }
            return View(premioNobel);
        }

        // POST: PremioNobels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PremioNobel premioNobel = db.PremioNobel.Find(id);
            db.PremioNobel.Remove(premioNobel);
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
