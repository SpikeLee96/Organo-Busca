using Organobusca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace Organobusca.Util
{
    public static class HtmlExtension
    {
        public static string GetUserName(this HtmlHelper helper, object ss)
        {
            var session = ((HttpSessionState)ss)["usuario"];
            if (session is Cliente)
            {
                return ((Cliente)session).nome;
            }
            else 
            {
                return ((Feirante)session).nome;
            }            
        }
    }
}