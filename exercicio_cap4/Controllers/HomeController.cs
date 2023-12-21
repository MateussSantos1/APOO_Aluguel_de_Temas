using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using exercicio_cap4.Models;

namespace exercicio_cap4.Controllers
{
    public class HomeController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Home
        public ActionResult Index()
        {
            Home h = new Home();
            h.Tema = context.Temas.OrderBy(c => c.Nome);

            return View(h);
        }
    }
}