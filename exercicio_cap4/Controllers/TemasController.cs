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
    public class TemasController : Controller
    {
        private TemaService temaService = new TemaService();

        // GET: Temas
        public ActionResult Index()
        {
            var temas = temaService.TodososTemas();
            return View(temas);
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
            Tema tema = temaService.TemasporID(id);
            if (tema == null)
            {
                return HttpNotFound();
            }
            return View(tema);
        }

        // GET: Temas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tema tema = temaService.TemasporID(id);
            if (tema == null)
            {
                return HttpNotFound();
            }
            return View(tema);
        }

        // POST: Temas/Delete/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            temaService.DeletarTema(id);
            TempData["Message"] = "Tema foi removido";
            return RedirectToAction("Index");
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tema tema = temaService.TemasporID(id);
            if (tema == null)
            {
                return HttpNotFound();
            }
            return View(tema);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tema tema)
        {
            if (ModelState.IsValid)
            {
                temaService.AtualizarTema(tema);
                TempData["Message"] = "Tema foi modificado";
                return RedirectToAction("Index");
            }
            return View(tema);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tema tema)
        {
            temaService.AdicionarTema(tema);
            TempData["Message"] = "Tema foi registrado";
            return RedirectToAction("Index");
        }
    }
}
