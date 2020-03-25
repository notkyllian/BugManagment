using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;
using Domain.Business.Entities;

namespace WebApplication.projectmanager
{
    public partial class Tasks : Page
    {
        private Controller _c;
        private List<Task> _tasks;

        protected void Page_Load(object sender, EventArgs e)
        {
            _c = (Controller) Session["controller"];
            if (Session["bug"] != null)
            {
                backPanel.Visible = true;
                _tasks = _c.GetTaskList().Where(x => x.Bug.Id == ((Bug) Session["bug"]).Id).ToList();
            }
            else if (Session["employee"] != null)
            {
                backPanel.Visible = true;
                _tasks = _c.GetTaskList().Where(x => x.Employee == (Employee) Session["employee"]).ToList();
            }
            else
            {
                backPanel.Visible = false;
                _tasks = _c.GetTaskList();
            }
            foreach (var task in _tasks.Where(task => task.Employee == null))
                task.Employee = new Employee(0, "None", DateTime.MinValue, " ", " ");

            grvTasks.DataSource = _tasks;
            grvTasks.DataBind();

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
            var b = _c.GetBug(Convert.ToInt32(DropDownList1.SelectedValue));
            var description = iptTitel.Value;
            try
            {
                var size = int.Parse(iptSize.Value);
                _c.AddTask(b, size, description);
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception exception)
            {
                lblMessage.Text = "Invalid Size, it must be between 1-10";
                ScriptManager.RegisterStartupScript(this, GetType(), "Modal", "Notify();", true);
            }
        }

        protected void grvTasks_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            grvTasks.EditIndex = e.NewEditIndex;
            grvTasks.DataBind();
        }

        protected void grvTasks_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var row = grvTasks.Rows[e.RowIndex];
            var task = _tasks[row.DataItemIndex];


            var ddl = (DropDownList) row.FindControl("ddlEmployees");
            var employeeId = Convert.ToInt32(ddl.SelectedValue);

            var description = ((TextBox) row.FindControl("txtDescription")).Text;
            ; //0=Id 1=Naam
            if (employeeId == 0) task.Employee = null;
            else task.Employee = (Employee) _c.GetUser(employeeId);

            task.Description = description;

            try
            {
                task.Size = Convert.ToInt32(((TextBox)row.FindControl("txtSize")).Text);
                task.TimeSpent = TimeSpan.Parse(((TextBox)row.Cells[4].Controls[0]).Text);
            }
            catch (Exception exception)
            {
                throw exception;
            }





            _c.UpdateTask(task);
            grvTasks.EditIndex = -1;

            Response.Redirect(Request.RawUrl);
        }

        protected void grvTasks_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvTasks.EditIndex = -1;
            grvTasks.DataBind();
        }

        protected void grvTasks_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var grvRow = grvTasks.Rows[e.RowIndex];
            var task = _tasks[grvRow.DataItemIndex];
            _c.RemoveTask(task.Bug, task.Id);

            Response.Redirect(Request.RawUrl);

        }

        protected void btnBack_OnClick(object sender, EventArgs e)
        {
            Session.Remove("bug");
            Session.Remove("employee");
            Response.Redirect("Default.aspx");
        }
    }
}