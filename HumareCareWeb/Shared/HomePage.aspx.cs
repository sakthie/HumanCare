using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumareCareWeb
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.IsInRole("Administrator"))
            {
                AdminLink.Visible = true;
            }
            else
            {
                AdminLink.Visible = false;
            }
        }
    }
}
