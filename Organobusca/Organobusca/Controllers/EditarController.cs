using Organobusca.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Organobusca.Controllers
{
    public class EditarController : Controller
    {
        // GET: Editar
        private dbOrg db = new dbOrg();
        [Authorize]
        public ActionResult Index()
        {
            int id = 0;
            var session = Session["usuario"];

            if (session is Cliente)
            {
                id = ((Cliente)session).id;
                var result = db.Cliente.Find(id);
                    result.confirmaSenha = result.senha;
                return View("IndexCliente", result);
            }
            else if (session is Feirante)
            {
                id = ((Feirante)session).id;
                var result = db.Feirante.Find(id);
                     result.confirmaSenha = result.senha;
                return View("IndexFeirante", result);
            }
            else
            {
                return View("IndexCliente");
            }
        }
        [HttpPost]
        public ActionResult IndexCliente(Cliente c, string NovaSenha, string NovoConfirmaSenha)
        {
            if (ModelState.IsValid && NovoConfirmaSenha == NovaSenha )
            {
                if (!string.IsNullOrEmpty(NovaSenha) && NovaSenha != c.senha)
                {
                    c.senha = NovaSenha;
                }

                db.Cliente.Attach(c);
                db.Entry(c).State = EntityState.Modified;
                db.SaveChanges();
                Session["usuario"] = c;
                TempData["mensagem"] = "Alterado com sucesso!";
                return RedirectToAction("Index", "Dashboard");
            }

            return View("IndexCliente");
        }
        [HttpPost]
        public ActionResult IndexFeirante(Feirante f, string NovaSenha, string NovoConfirmaSenha)
        {
            if (ModelState.IsValid && NovoConfirmaSenha == NovaSenha)
            {
                if (!string.IsNullOrEmpty(NovaSenha) && NovaSenha != f.senha)
                {
                    f.senha = NovaSenha;
                }

                db.Feirante.Attach(f);
                db.Entry(f).State = EntityState.Modified;
                db.SaveChanges();
                Session["usuario"] = f;
                TempData["mensagem"] = "Alterado com sucesso!";
                return RedirectToAction("IndexFeirante", "Dashboard");
            }

            return View("IndexFeirante");
        }
        [Authorize(Roles = "cliente")]
        public ActionResult DeletarCliente(int id)
        {
            var cliente = db.Cliente.Where(a => a.id == id).FirstOrDefault();
            db.Cliente.Remove(cliente);
            db.SaveChanges();
            FormsAuthentication.SignOut();
            Session.Clear();
            TempData["mensagem"] = "Usuário deletado!";
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "feirante")]
        public ActionResult DeletarFeirante(int id)
        {
            var feirante = db.Feirante.Where(a => a.id == id).FirstOrDefault();
            db.Feirante.Remove(feirante);
            db.SaveChanges();
            FormsAuthentication.SignOut();
            Session.Clear();
            TempData["mensagem"] = "Usuário deletado!";
            return RedirectToAction("Index", "Home");
        }
    }
}