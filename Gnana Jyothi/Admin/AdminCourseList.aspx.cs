using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gnana_Jyothi.Admin
{
    public partial class AdminCourseList : System.Web.UI.Page
    {
        readyclass obj = new readyclass();
        string str;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fill();

                string var = ClientScript.GetPostBackEventReference(btnSave, "").ToString();
                btnSave.Attributes.Add("onClick", "javascript :if ( Page_ClientValidate() ){this.disabled=true; this.value='Pls Wait...';" + var + "};");
            }
        }

        private void fill()
        {
            str = "select * from tblCourse";
            obj.fill(grdCourse, str, lblerror);
        }

        protected void btnNewrecord_Click(object sender, EventArgs e)
        {
            obj.End_Block(pnlpopup);

            txtCourse.Focus();

            btnSave.Visible = true;
            this.ModalPopupExtender1.Show();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from tblCourse where Course='" + txtCourse.Text.Trim() + "'";
                if (obj.checkduplicate(sql))
                {
                    readyclass.errormessage(lblerror, "Course Already exist");
                }
                else
                {
                    lblerror.Text = "";

                    int id = obj.autoid("tblCourse", "ID");

                    sql = "insert into tblCourse (ID,Course) ";
                    sql = sql + "Values(" + id + ", '" + txtCourse.Text.Trim() + "')";

                    int rowaffected = Database.executeQuery(sql);

                    if (rowaffected > 0)
                    {
                        obj.ShowAlert(this, "Inserted Successfully");

                        fill();

                        ModalPopupExtender1.Dispose();
                    }
                    else
                    {
                        obj.ShowAlert(this, "Action is not processed");
                    }
                }
            }
            catch (Exception ex)
            {
                readyclass.errormessage(lblerror, ex.Message);
            }
        }

        protected void grdCourse_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string release;
                release = grdCourse.DataKeys[e.RowIndex].Values[0].ToString();

                string sql = "delete from tblCourse where ID = " + release + "";

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

        protected void grdCourse_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // reference the Delete LinkButton
                LinkButton db = (LinkButton)e.Row.Cells[1].Controls[0];

                db.OnClientClick = "return confirm('Are you certain you want to delete this?');";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Dispose();
        }
    }
}