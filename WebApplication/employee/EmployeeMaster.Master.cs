using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace WebApplication.employee
{
    public partial class EmployeeMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var c = (Controller)Session["controller"];
            if (Session["uid"] == null || Convert.ToInt32(Session["uid"]) == 0) Response.Redirect("~/Default.aspx");
            else if (c.GetUser(Convert.ToInt32(Session["uid"])).GetType().Name.ToLower() != "employee") Response.Redirect("~/Default.aspx"); // Check if role is user if not redirect to default page which will redirect to correct role page
        }
    }
}