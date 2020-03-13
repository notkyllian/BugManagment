using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace WebApplication.user
{
    public partial class Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            var c = (Controller) Session["controller"];
            if (Session["uid"] == null) Response.Redirect("~/Default.aspx");
            else if (c.GetUser(Convert.ToInt32(Session["uid"])).GetType().Name.ToLower() != "user") Response.Redirect("~/Default.aspx"); // Check if role is user if not redirect to default page which will redirect to correct role page
     

        }
    }
}