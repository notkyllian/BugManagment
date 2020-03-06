using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
            MySqlCommand mySqlCommand = new MySqlCommand("SELECT role FROM tbluser WHERE (username = @login AND password = @password)", mySqlConnection);
            mySqlCommand.Parameters.AddWithValue("login", Login1.UserName);
            mySqlCommand.Parameters.AddWithValue("password", Login1.Password);

            mySqlConnection.Open();

            string strRole;
            if (mySqlCommand.ExecuteScalar() == null) strRole = String.Empty;
            else strRole = mySqlCommand.ExecuteScalar().ToString();

            mySqlConnection.Close();

            if (strRole == "employee" || strRole == "projectmanager")
            {
                Session["role"] = strRole;
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, false);
            }
            else Login1.FailureText = "Wrong login, try again!";
            
        }
    }
}