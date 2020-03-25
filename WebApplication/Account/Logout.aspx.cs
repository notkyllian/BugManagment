using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication.Account
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Session.Remove("uid");
            Session.Remove("error");
            Session.Remove("bug");
            Session.Remove("employee");
            Response.Redirect("~/Default.aspx");
        }
    }
}