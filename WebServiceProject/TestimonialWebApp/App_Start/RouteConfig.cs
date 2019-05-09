using System.Web.Mvc;
using System.Web.Routing;

namespace TestimonialWebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
                name: "apply",
				url: "apply/",
				defaults: new { controller = "Home", action = "Apply"}
            );

			routes.MapRoute(
                name: "status",
                url: "status/",
                defaults: new { controller = "Home", action = "Status" }
            );

			routes.MapRoute(
                name: "getStatus",
                url: "getStatus/",
                defaults: new { controller = "Home", action = "GetStatus" }
            );

			routes.MapRoute(
                name: "submit",
                url: "submit/",
                defaults: new { controller = "Home", action = "Submit" }
            );

			routes.MapRoute(
				name: "verifyStudent",
                url: "verifyStudent/",
                defaults: new { controller = "Home", action = "VerifyStudent", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "deptVerify",
                url: "deptVerify/",
                defaults: new { controller = "Home", action = "DeptVerify", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "hallVerify",
                url: "hallVerify/",
                defaults: new { controller = "Home", action = "HallVerify", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "formPayment",
                url: "formPayment/",
                defaults: new { controller = "Home", action = "FormPayment", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "submitPayment",
                url: "submitPayment/",
                defaults: new { controller = "Home", action = "SubmitPayment", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "submitRegistrar",
               url: "submitRegistrar/",
               defaults: new { controller = "Home", action = "SubmitRegistrar", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "index",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
            );

        }
    }
}
