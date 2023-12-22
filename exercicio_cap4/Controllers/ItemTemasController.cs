using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using exercicio_cap4.Services;
using exercicio_cap4.Models;

namespace exercicio_cap4.Controllers
{
    public class ItemTemasController : Controller
    {
        private ItemTemaService itemTemaService = new ItemTemaService();
        private TemaService temaService = new TemaService();

        // GET: ItemTemas
        public ActionResult Index()
        {
            var items = itemTemaService.TodosOsItensTemas();
            return View(items);
        }

        // GET: ItemTemas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemTema item = itemTemaService.ItemTemaPorID(id);

            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: ItemTemas/Create
        public ActionResult Create()
        {
            ViewBag.Temas = new SelectList(temaService.TodososTemas(), "TemaId", "Nome");
            ViewBag.TemaId = new SelectList(itemTemaService.TodosOsItensTemas().OrderBy(b => b.Nome),
            "TemaId", "Nome");
            return View();
        }

        // POST: ItemTemas/Create
        [HttpPost]
        public ActionResult Create(ItemTema item)
        {
            try
            {
                itemTemaService.AdicionarItemTema(item);
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
            ItemTema item = itemTemaService.ItemTemaPorID(id);

            if (item == null)
            {
                return HttpNotFound();
            }

            ViewBag.TemaId = new SelectList(itemTemaService.TodosOsItensTemas().OrderBy(b => b.Nome), "TemaId", "Nome", item.TemaId);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(ItemTema item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    itemTemaService.AtualizarItemTema(item);
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
            ItemTema item = itemTemaService.ItemTemaPorID(id);

            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: ItemTemas/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                itemTemaService.DeletarItemTema(id);
                TempData["Message"] = "ItemTema foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
