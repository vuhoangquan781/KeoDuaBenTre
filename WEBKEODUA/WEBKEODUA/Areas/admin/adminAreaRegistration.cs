using System.Web.Mvc;

namespace WEBKEODUA.Areas.admin
{
    public class adminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "adminLogin",
                "admin/login",
                new { Controller = "Login", Action = "Login", id = UrlParameter.Optional }
           );

            context.MapRoute(
                name: "Admin_Default",
                url: "Admin/{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}