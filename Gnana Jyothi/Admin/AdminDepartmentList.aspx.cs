using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gnana_Jyothi.Admin
{
    public partial class AdminDepartmentList : System.Web.UI.Page
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
            str = "select * from tblDepartment";
            obj.fill(grdDepartment, str, lblerror);
        }

        protected void btnNewrecord_Click(object sender, EventArgs e)
        {
            obj.End_Block(pnlpopup);

            txtDepartment.Focus();

            btnSave.Visible = true;
            this.ModalPopupExtender1.Show();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from tblDepartment where Department='" + txtDepartment.Text.Trim() + "'";
                if (obj.checkduplicate(sql))
                {
                    readyclass.errormessage(lblerror, "Department Already exist");
                }
                else
                {
                    lblerror.Text = "";

                    int id = obj.autoid("tblDepartment", "ID");

                    sql = "insert into tblDepartment (ID,Department) ";
                    sql = sql + "Values(" + id + ", '" + txtDepartment.Text.Trim() + "')";

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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Dispose();
        }

        protected void grdDepartment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // reference the Delete LinkButton
                LinkButton db = (LinkButton)e.Row.Cells[1].Controls[0];

                db.OnClientClick = "return confirm('Are you certain you want to delete this?');";
            }

        }

        protected void grdDepartment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string release;
                release = grdDepartment.DataKeys[e.RowIndex].Values[0].ToString();

                string sql = "delete from tblDepartment where ID = " + release + "";

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
    }
}