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
    public partial class Bugs : System.Web.UI.Page
    {
        private Controller _c;
        private List<Bug> _bugs;

        protected void Page_Load(object sender, EventArgs e)
        {
            _c = (Controller) Session["controller"];

          
                _bugs = _c.GetBugList();
                grvBugs.DataSource = _bugs;
                grvBugs.DataBind();

        }


        protected void grvBugs_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvBugs.EditIndex = e.NewEditIndex;
            grvBugs.DataBind();
        }

        protected void grvBugs_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var row = grvBugs.Rows[e.RowIndex];
            var bug = _bugs[row.DataItemIndex];

            var newName = ((TextBox) row.Cells[1].Controls[0]).Text; //0=Id 1=Naam
            bug.Description = newName;
            _c.UpdateBug(bug);

            grvBugs.EditIndex = -1;

            grvBugs.DataBind();
        }

        protected void grvBugs_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvBugs.EditIndex = -1;
            grvBugs.DataBind();
        }
    }
}