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
    public partial class Tasks : System.Web.UI.Page
    {
        private Controller _c;
        protected void Page_Load(object sender, EventArgs e)
        {

            _c = (Controller) Session["controller"];
            if (Session["bug"] != null)
            {
                backPanel.Visible = true;
                List<Task> _tasks = _c.GetTaskList().Where(x => x.Bug.Id == ((Bug) Session["bug"]).Id).ToList();
                grvTasks.DataSource = _tasks;
                grvTasks.DataBind();

            }
            else
            {
                List<Task> _tasks = _c.GetTaskList();
                grvTasks.DataSource = _tasks;
                grvTasks.DataBind();
                backPanel.Visible = true;
            }

            if (!IsPostBack)
            {
                DropDownList1.DataSource = _c.GetBugList();
                DropDownList1.DataTextField = "Description";
                DropDownList1.DataValueField = "Id";
                DropDownList1.DataBind();
                

            }

        }

        protected void btnAddTask_OnClick(object sender, EventArgs e)
        {
            Bug b = _c.GetBug(Convert.ToInt32(DropDownList1.SelectedValue));
            var description = iptTitel.Value;
            try
            {
                int size = int.Parse(iptSize.Value);
                _c.AddTask(b, size, description);
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception exception)
            {
                lblMessage.Text = "Invalid Size, it must be between 1-10";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Modal", "Notify();", true);
            }

        }

        protected void grvTasks_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            grvTasks.EditIndex = e.NewEditIndex;
            grvTasks.DataBind();

        }

        protected void grvTasks_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void grvTasks_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvTasks.EditIndex = -1;
            grvTasks.DataBind();
        }

        protected void grvTasks_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}