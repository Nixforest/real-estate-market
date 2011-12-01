using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Security.Principal;

namespace RealEstateMarket
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            try
            {
                HttpCookie authenCookie = Context.Request.Cookies.Get(FormsAuthentication.FormsCookieName);
                if (authenCookie == null)
                {
                    return;                    
                }
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authenCookie.Value);
                FormsIdentity id = new FormsIdentity(ticket);
                string[] astrRols = ticket.UserData.Split(new char[] { ',' });
                GenericPrincipal principal = new GenericPrincipal(id, astrRols);
                Context.User = principal;
            }
            catch (Exception ex)
            {
                System.IO.StreamWriter wr = new System.IO.StreamWriter(Context.Request.MapPath("log.txt"));
                wr.WriteLine(ex.Message);
                wr.Close();
            }
        }

    }
}
