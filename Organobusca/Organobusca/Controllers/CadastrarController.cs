using Organobusca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Organobusca.Controllers
{
    public class CadastrarController : Controller
    {
        // GET: Cadastrar
        private dbOrg db = new dbOrg();
        public ActionResult Index()
        {
            var SESSAO = Session["usuario"];
            if (SESSAO != null)
            {
                if (SESSAO is Feirante)
                    return RedirectToAction("IndexFeirante", "Dashboard");
                else if (SESSAO is Cliente)
                    return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

        public ActionResult Cliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cliente(Cliente c)
        {
            if (ModelState.IsValid)
            {     
                if (db.Cliente.FirstOrDefault(a => a.email == c.email) == null)
                {
                    db.Cliente.Add(c);
                    db.SaveChanges();
                    TempData["mensagem"] = "Cadastrado com sucesso!";
                    return RedirectToAction("Index", "Dashboard");
                }
                ModelState.AddModelError("", "Email já cadastrado.");
                return View();
            }
            return View();
        }

        public ActionResult Feirante()
        {
            dbOrg db = new dbOrg();
            ViewBag.listaFeiras = db.Feira.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Feirante(Feirante f)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Feira_id = new SelectList(db.Feira.ToList(), "id", "nome");
                if (db.Feirante.FirstOrDefault(a => a.email == f.email) == null)
                {
                    db.Feirante.Add(f);
                    db.SaveChanges();
                    TempData["mensagem"] = "Cadastrado com sucesso!";
                    return RedirectToAction("Index", "Dashboard");
                }
                ModelState.AddModelError("", "Email já cadastrado.");
                return View();
            }
            return View();
        }
    }
}