using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;

namespace HumareCareWeb
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Initialize FormsAuthentication, for what it's worth
            FormsAuthentication.Initialize();

            // Create our connection and command objects
            SqlConnection conn =
             new SqlConnection(@"Data Source=SAKTHI-VAIO\SQLEXPRESS;Initial Catalog=web;user id=sa;password=Enter321");
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT roles FROM users WHERE username=@username " +
             "AND password=@password";

            // Fill our parameters
            cmd.Parameters.Add("@username", SqlDbType.NVarChar, 64).Value =
        Username.Text;
            //cmd.Parameters.Add("@password", SqlDbType.NVarChar, 128).Value =
            // FormsAuthentication.HashPasswordForStoringInConfigFile(
            //    Password.Text, "md5"); // Or "sha1"

            cmd.Parameters.Add("@password", SqlDbType.NVarChar, 128).Value = Password.Text;

            // Execute the command
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                // Create a new ticket used for authentication
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                   1, // Ticket version
                   Username.Text, // Username associated with ticket
                   DateTime.Now, // Date/time issued
                   DateTime.Now.AddMinutes(30), // Date/time to expire
                   true, // "true" for a persistent user cookie
                   reader.GetString(0), // User-data, in this case the roles
                   FormsAuthentication.FormsCookiePath);// Path cookie valid for

                // Encrypt the cookie using the machine key for secure transport
                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(
                   FormsAuthentication.FormsCookieName, // Name of auth cookie
                   hash); // Hashed ticket

                // Set the cookie's expiration time to the tickets expiration time
                if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;

                // Add the cookie to the list for outgoing response
                Response.Cookies.Add(cookie);

                // Redirect to requested URL, or homepage if no previous page
                // requested
                string returnUrl = Request.QueryString["HomePage.aspx"];
                if (returnUrl == null) returnUrl = "/";

                // Don't call FormsAuthentication.RedirectFromLoginPage since it
                // could
                // replace the authentication ticket (cookie) we just added
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                // Never tell the user if just the username is password is incorrect.  
                // That just gives them a place to start, once they've found one or
                // the other is correct!
                ErrorLabel.Text = "Username or password provided is incorrect. Please try again.";
                ErrorLabel.Visible = true;
            }

            reader.Close();
            conn.Close();
        }
    }
}