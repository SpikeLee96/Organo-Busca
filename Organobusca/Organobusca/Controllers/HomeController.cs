using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Organobusca.Models;

namespace Organobusca.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
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

            //if(Session["cliente"] != null)
            //{
            //    return RedirectToAction("Index", "Dashboard");
            //}
            //else if (Session["feirante"] != null)
            //{
            //    return RedirectToAction("IndexFeirante", "Dashboard");
            //}
            //return View();
        }
    }
}