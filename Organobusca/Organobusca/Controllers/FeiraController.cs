using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Organobusca.Models;

namespace Organobusca.Controllers
{
    public class FeiraController : Controller
    {
        // GET: Feira
        private dbOrg db = new dbOrg();
        
        public ActionResult Index()
        {
            return RedirectToAction("Listar");
        }
        [Authorize(Roles = "feirante")]
        public ActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "feirante")]
        public ActionResult Criar(Feira f, int[] dia, TimeSpan[] hora_inicio, TimeSpan[] hora_fim)
        {
            for(int i = 0; i < dia.Length; i++)
            {
                DiaDaSemana horarioDia = new DiaDaSemana();
                horarioDia.dia = dia[i];
                horarioDia.hora_inicio = hora_inicio[i];
                horarioDia.hora_fim = hora_fim[i];
                horarioDia.Feira_id = f.id;

                db.DiaDaSemana.Add(horarioDia);
            }
            db.Feira.Add(f);
            db.SaveChanges();
            return RedirectToAction("Listar");
        }
        [Authorize(Roles = "feirante")]
        public ActionResult Listar()
        {
            return View(db.Feira.ToList());
        }
        [Authorize(Roles = "feirante")]
        public ActionResult Excluir(int id)
        {
            var feira = db.Feira.Where(m => m.id == id).FirstOrDefault();
            
            var dia = db.DiaDaSemana.Where(d => d.Feira_id == feira.id).ToList();
            db.DiaDaSemana.RemoveRange(dia);

            db.Feira.Remove(feira);
            db.SaveChanges();
            return RedirectToAction("Listar");
        }
    }
}