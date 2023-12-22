using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using exercicio_cap4.Models;
using System.Net;
using exercicio_cap4.DAL;

namespace exercicio_cap4.Controllers
{
    public class ItemTemasController : Controller
    {
        private ItemTemaDAL itemTemaDAL = new ItemTemaDAL();
        private TemaDAL temaDal = new TemaDAL();

        // GET: ItemTemas
        public ActionResult Index()
        {
            var items = itemTemaDAL.TodosOsItensTemas();
            return View(items);
        }

        // GET: ItemTemas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemTema item = itemTemaDAL.ItemTemaPorID(id);

            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: ItemTemas/Create
        public ActionResult Create()
        {
            ViewBag.Temas = new SelectList(temaDal.TodososTemas(), "TemaId", "Nome");
            ViewBag.TemaId = new SelectList(itemTemaDAL.TodosOsItensTemas().OrderBy(b => b.Nome),
            "TemaId", "Nome");
            return View();
        }

        // POST: ItemTemas/Create
        [HttpPost]
        public ActionResult Create(ItemTema item)
        {
            try
            {
                itemTemaDAL.AdicionarItemTema(item);
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
            ItemTema item = itemTemaDAL.ItemTemaPorID(id);

            if (item == null)
            {
                return HttpNotFound();
            }

            ViewBag.TemaId = new SelectList(itemTemaDAL.TodosOsItensTemas().OrderBy(b => b.Nome), "TemaId", "Nome", item.TemaId);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(ItemTema item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    itemTemaDAL.AtualizarItemTema(item);
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
            ItemTema item = itemTemaDAL.ItemTemaPorID(id);

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
                itemTemaDAL.DeletarItemTema(id);
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
