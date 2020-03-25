using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;
using Domain.Business.Entities;

namespace WebApplication.projectmanager
{
    public partial class Employees : System.Web.UI.Page
    {
        private Controller _c;
        protected void Page_Load(object sender, EventArgs e)
        {
            _c = (Controller)Session["controller"];


            
            grvEmployees.DataSource = _c.GetUsers().OfType<Employee>().ToList();
            grvEmployees.DataBind();
        }

        protected void grvEmployees_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)grvEmployees.SelectedValue;
            Employee employee = (Employee) _c.GetUser(id);
            Session["employee"] = employee;
            Response.Redirect("Tasks.aspx");
        }
    }
}