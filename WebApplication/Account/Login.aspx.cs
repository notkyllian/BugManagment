using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;
using Domain.Business.Entities;

namespace WebApplication.Account
{
    public partial class Login : System.Web.UI.Page
    {
        private Controller _c;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                _c = (Controller)Session["controller"];
            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            try
            {
                var user = _c.Login(inputUser.Text, inputPassword.Text);
                if (user != null)
                {
                    Session["uid"] = user.Id;
                    Response.Redirect($"/{user.GetType().Name.ToLower()}/Default.aspx");
                }
                else
                {
                    Session["error"] = "Login invalid!";
                }
            }
            catch (Exception)
            {
                Session["error"] = "Invalid request!";
            }

            
        }
    }
}