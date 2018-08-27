using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Organobusca.Models;

namespace Organobusca.Controllers
{
    public class ContaController : Controller
    {
        // GET: Conta
        public ActionResult Index()
        {
            if(Session["usuario"] is Cliente)
            {
                return RedirectToAction("Cliente");
            }
            else
            {
                return RedirectToAction("Feirante");
            }
        }
        [Authorize(Roles ="cliente")]
        public ActionResult Cliente()
        {
            return View(Session["usuario"]);
        }
        [Authorize(Roles = "feirante")]
        public ActionResult Feirante()
        {
            return View(Session["usuario"]);
        }
    }
}