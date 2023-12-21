using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using exercicio_cap4.Models;

namespace exercicio_cap4.Controllers
{
    public class TemasController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Temas
        public ActionResult Index()
        {
            return View(
                context.Temas.OrderBy(c => c.Nome)
            );
        }
        public ActionResult Create()
        {
            return View();
        }

        // GET: Temas/Edit/1
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tema Tema = context.Temas.Find(id);
            if (Tema == null)
            {
                return HttpNotFound();
            }
            return View(Tema);
        }

        // GET: Temas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tema Tema = context.Temas.Where(f => f.TemaId == id).
            Include("ItemTemas.Tema").First();
            if (Tema == null)
            {
                return HttpNotFound();
            }
            return View(Tema);
        }

        // POST: Temas/Delete/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Tema Tema = context.Temas.Find(id);
            context.Temas.Remove(Tema);
            context.SaveChanges();
            TempData["Message"] = "Tema \"" + Tema.Nome + "\" foi removido";
            return RedirectToAction("Index");
        }
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tema Tema = context.Temas.Find(id);
            if (Tema == null)
            {
                return HttpNotFound();
            }
            return View(Tema);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tema Tema)
        {
            if (ModelState.IsValid)
            {
                context.Entry(Tema).State = EntityState.Modified;
                context.SaveChanges();
                TempData["Message"] = "Tema \"" + Tema.Nome + "\" foi modificado";
                return RedirectToAction("Index");
            }
            return View(Tema);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tema Tema)
        {
            context.Temas.Add(Tema);
            context.SaveChanges();
            TempData["Message"] = "Categprico \"" + Tema.Nome + "\" foi registrado";
            return RedirectToAction("Index");
        }
    }
}