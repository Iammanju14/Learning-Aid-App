using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gnana_Jyothi.Admin
{
    public partial class AdminSubjectList : System.Web.UI.Page
    {
        readyclass obj = new readyclass();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string str = "Select distinct(Course) from tblSubjects";
                obj.filllist(ddlCourse, str, lblerror);

                string var = ClientScript.GetPostBackEventReference(btnSearch, "").ToString();
                btnSearch.Attributes.Add("onClick", "javascript :if ( Page_ClientValidate() ){this.disabled=true; this.value='Pls Wait...';" + var + "};");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            fill();
        }

        private void fill()
        {
            string str = "select * from tblSubjects where Course='" + ddlCourse.SelectedValue + "' and SemorYear='" + ddlSemorYear.SelectedValue + "'";
            obj.fill(grdSubject, str, lblerror);
        }

        protected void btnNewrecord_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminSubjectAdd.aspx");
        }

        protected void grdSubject_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // reference the Delete LinkButton
                LinkButton db = (LinkButton)e.Row.Cells[3].Controls[0];

                db.OnClientClick = "return confirm('Are you certain you want to delete this?');";
            }
        }

        protected void grdSubject_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string release;
                release = grdSubject.DataKeys[e.RowIndex].Values[0].ToString();

                string sql = "delete from tblSubjects where ID = " + release + "";

                int rowaffected = Database.executeQuery(sql);

                if (rowaffected > 0)
                {
                    obj.ShowAlert(this, "Deleted Successfully");

                    fill();
                }
                else
                {
                    obj.ShowAlert(this, "Action is not processed");
                }
            }
            catch (Exception ex)
            {
                readyclass.errormessage(lblerror, ex.Message);
            }
        }

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = "Select distinct(SemorYear) from tblSubjects where Course='" + ddlCourse.SelectedValue + "'";
            obj.filllist(ddlSemorYear, str, lblerror);
        }
    }
}