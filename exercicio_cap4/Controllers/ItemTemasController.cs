using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using exercicio_cap4.Models;
using System.Net;

namespace exercicio_cap4.Controllers
{
    public class ItemTemasController : Controller
    {
        private EFContext context = new EFContext();
        // GET: ItemTemas
        public ActionResult Index()
        {
            var items =
            context.ItemTemas.Include(c => c.Tema).
            OrderBy(n => n.Nome);
            return View(items);
        }

        // GET: ItemTemas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemTema item = context.ItemTemas.Where(p => p.ItemTemaId == id).
            Include(c => c.Tema).First();

            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: ItemTemas/Create
        public ActionResult Create()
        {
            ViewBag.TemaId = new SelectList(context.Temas.OrderBy(b => b.Nome),
            "TemaId", "Nome");
            //ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(b => b.Nome),
           // "FabricanteId", "Nome");
            return View();
        }

        // POST: ItemTemas/Create
        [HttpPost]
        public ActionResult Create(ItemTema item)
        {
            try
            {
                context.ItemTemas.Add(item);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(item);
            }
        }

        // GET: ItemTemas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemTema item = context.ItemTemas.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.TemaId = new SelectList(context.Temas.OrderBy(b => b.Nome), "TemaId",
            "Nome", item.TemaId);
            //ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(b => b.Nome), "FabricanteId",
            //"Nome", item.FabricanteId);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(ItemTema item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(item).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(item);
            }
            catch
            {
                return View(item);
            }
        }

        // GET: ItemTemas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemTema item = context.ItemTemas.Where(p => p.ItemTemaId == id).
            Include(c => c.Tema).First();
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: ItemTemas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                ItemTema item = context.ItemTemas.Find(id);
                context.ItemTemas.Remove(item);
                context.SaveChanges();
                TempData["Message"] = "ItemTema " + item.Nome.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
