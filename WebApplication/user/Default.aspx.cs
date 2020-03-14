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
        private Controller _c;
        protected void Page_Load(object sender, EventArgs e)
        {

            _c = (Controller) Session["controller"];
            ltrlName.Text = _c.GetUser(Convert.ToInt32(Session["uid"])).Name;

        }
    }
}