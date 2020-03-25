using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;
using Domain.Business.Entities;

namespace WebApplication.employee
{
    public partial class Default : System.Web.UI.Page
    {
        private Controller _c;
        private List<Task> _tasks;
        protected void Page_Load(object sender, EventArgs e)
        {
            _c = (Controller) Session["controller"];


            Employee emp = (Employee) _c.GetUser(Convert.ToInt32(Session["uid"]));

            _tasks = _c.GetTaskList().Where(x => x.Employee == emp).ToList();

            grvTasks.DataSource = _tasks;
            grvTasks.DataBind();
        }

        protected void grvTasks_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            grvTasks.EditIndex = e.NewEditIndex;
            grvTasks.DataBind();
        }

        protected void grvTasks_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvTasks.EditIndex = -1;
            grvTasks.DataBind();
        }

        protected void grvTasks_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var row = grvTasks.Rows[e.RowIndex];
            var task = _tasks[row.DataItemIndex];


            var employeeId = Convert.ToInt32(grvTasks.DataKeys[e.RowIndex]["Id"]);

            try
            {
                task.TimeSpent = TimeSpan.Parse(((TextBox)row.Cells[2].Controls[0]).Text);
            }
            catch (Exception exception)
            {
                throw exception;
            }





            _c.UpdateTask(task);
            grvTasks.EditIndex = -1;

            Response.Redirect(Request.RawUrl);
        }
    }
}