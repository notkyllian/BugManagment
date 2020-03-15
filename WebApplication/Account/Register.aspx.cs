using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;
using Domain.Business.Entities;

namespace WebApplication.Account
{
    public partial class Register : System.Web.UI.Page
    {
        private Controller _c;
        protected void Page_Load(object sender, EventArgs e)
        {
            _c = (Controller) Session["controller"];
        }

        protected void RegisterButton_OnClick(object sender, EventArgs e)
        {
            bool success;
            var dateValue = DateTime.ParseExact(hdnDate.Value, "dd/mm/yyyy", CultureInfo.InvariantCulture);
            try
            {
                switch (Role.SelectedItem.Text)
                {
                    case "User":
                        _c.AddUser(inputName.Text, dateValue, inputUser.Text, inputPassword.Text);
                        break;
                    case "Projectmanager":
                        _c.AddProjectmanager(inputName.Text, dateValue, inputUser.Text, inputPassword.Text);
                        break;
                    case "Employee":
                        _c.AddEmployee(inputName.Text, dateValue, inputUser.Text, inputPassword.Text);
                        break;
                    default:
                        Session["error"] = "Invalid user type!";
                        break;
                }
                Session["error"] = "Account created, Login!";
                success = true;

            }
            catch (Exception exception)
            {
                if (exception.Message.Contains("Duplicate")) Session["error"] = "Username already in use!";
                else Session["error"] = "Invalid register request!";
                success = false;
            }
            if(success) Response.Redirect("Login.aspx");

        }
    }
}