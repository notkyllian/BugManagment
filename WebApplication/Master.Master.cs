using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace WebApplication
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] == null) return;
            var c = (Controller) Session["controller"];
            var user = c.GetUser(Convert.ToInt32(Session["uid"]));
            Response.Redirect($"/{user.GetType().Name.ToLower()}/Default.aspx");
        }

       
    }
}