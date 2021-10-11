using System.Web.Mvc;

namespace QuanLyNhanSu.Areas.NVClient
{
    public class NVClientAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "NVClient";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "NVClient_default",
                "NVClient/{controller}/{action}/{id}",
                new { action = "Index", controller="NVclients" ,id = UrlParameter.Optional }
            );
        }
    }
}