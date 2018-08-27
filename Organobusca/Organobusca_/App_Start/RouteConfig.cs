using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Organobusca_
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            /*
             * http://organobusca.azurewebsites.net/home/index (pagina inicial)
             *      se algum usuario estiver logado, 
             *      ele redireciona para o dashboard  
             * http://organobusca.azurewebsites.net/login (login)
             *      redireciona para o dashboard
             * http://organobusca.azurewebsites.net/cadastrar/ (cadastro)
             *      redireciona para o dashboard
             * http://organobusca.azurewebsites.net/dashboard/ (painel principal)
             *      varias actions
             * http://organobusca.azurewebsites.net/conta (configuracoes)
             *      varias actions:
             *      http://organobusca.azurewebsites.net/conta/senha (mudar senha)
             *      http://organobusca.azurewebsites.net/conta/editar (mudar detalhes)
             *      http://organobusca.azurewebsites.net/conta/preferencias (mudar preferencias)
             *      http://organobusca.azurewebsites.net/conta/feira (so para feirantes)
             */
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
