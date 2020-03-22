using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;
using Domain.Business.Entities;

namespace WebApplication.user
{
    public partial class Default : System.Web.UI.Page
    {
        private Controller _c;
        protected void Page_Load(object sender, EventArgs e)
        {

            _c = (Controller) Session["controller"];
            

        }

        protected void Submit(object sender, EventArgs e)
        {
            var b  = _c.AddBug(bugDescription.Value);
            lblMessage.Text = $@"Bug Reported! Id: {b.Id}";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Modal", "Notify();", true);
        }
    }
}