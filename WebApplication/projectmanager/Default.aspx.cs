using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace WebApplication.projectmanager
{
    public partial class Default : System.Web.UI.Page
    {
        private Controller _c;
        protected void Page_Load(object sender, EventArgs e)
        {
            _c = (Controller) Session["controller"];
            ltrlTask.Text = _c.GetTaskList().Count.ToString();
            ltrlBug.Text = _c.GetBugList().Count.ToString();
        }
    }
}