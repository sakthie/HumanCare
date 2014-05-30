using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace HumareCareWeb.Master
{
    public partial class Doctor : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logOut_event(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
        }
    }
}