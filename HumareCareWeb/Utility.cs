using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Security;

namespace HumareCareWeb.loginBasedonRoles
{
    public static class Utility
    {
     /* To redirect to the home page based on the Role */

        public static void RedirectFromLoginPage(string username,HttpResponse Response)
        {
            LoginRedirectByRoleSection roleRedirectSection = (LoginRedirectByRoleSection)ConfigurationManager.GetSection("loginRedirectByRole");
            foreach (RoleRedirect roleRedirect in roleRedirectSection.RoleRedirects)
            {
                if (Roles.IsUserInRole(username, roleRedirect.Role))
                {
                    Response.Redirect(roleRedirect.Url);
                }
            }
        }

        public static void ValidateUser(System.Security.Principal.IPrincipal User)
        {
            if (!User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
        }
    }
}