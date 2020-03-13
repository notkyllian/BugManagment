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
            if(Session["uid"] == null) Response.Redirect("~/Default.aspx");
            var c = (Controller) Session["controller"];
            
            Label1.Text = c.GetUser(Convert.ToInt32(Session["uid"])).Name;


        }
    }
}