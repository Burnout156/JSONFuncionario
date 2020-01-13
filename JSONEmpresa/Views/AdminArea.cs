using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JSONEmpresa.Views
{
    public class AdminArea : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";   
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_Default",
                "Admin/{controller}/{action}/{id}",
                new {controller = "Funcionario", action = "Create", id = UrlParameter.Optional},
                namespaces: new[]{ "JSONEmpresa.Controllers" }
                );
        }
    }
}