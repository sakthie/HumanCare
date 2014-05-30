using System.Web.Mvc;

namespace HumanCarePresentationLayer.Areas.Clerk
{
    public class ClerkAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Clerk";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Clerk_default",
                "Clerk/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
