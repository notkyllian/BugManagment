using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace WebApplication.Account
{
    public partial class Login : System.Web.UI.Page
    {
        private Controller _c;

        protected void Page_Load(object sender, EventArgs e)
        {
            _c = (Controller) Session["controller"];
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
                    message.Text = "Login invalid!";
                    error.Visible = true;
                }
            }
            catch (Exception)
            {
                message.Text = "Invalid request!";
                error.Visible = true;
            }
        }
    }
}