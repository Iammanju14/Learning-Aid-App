using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gnana_Jyothi
{
    public partial class Logout : System.Web.UI.Page
    {
        readyclass obj = new readyclass();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Session["UserID"] = null;
                Session.Remove("UserID");

                Session.Abandon();
                Session.Clear();

                obj.ClearCache();


                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
                Response.Cache.SetNoStore();

                Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
                Response.Expires = -1500;
                Response.CacheControl = "no-cache";
                Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            }
        }
    }
}