using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace WebApplication
{


    public partial class Default : System.Web.UI.Page
    {

        public bool test = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller c = (Controller)Session["controller"];
            Label1.Text = c.GetUser(1).Name;
        }
    }
}