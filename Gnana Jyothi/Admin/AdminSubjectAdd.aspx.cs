using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gnana_Jyothi.Admin
{
    public partial class AdminSubjectAdd : System.Web.UI.Page
    {
        readyclass obj = new readyclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sql = "Select distinct(Course) from tblCourse";
                obj.filllist(ddlCourse, sql, lblError);

                sql = "Select distinct(SemorYear) from tblSemorYear";
                obj.filllist(ddlSemorYear, sql, lblError);

                sql = "Select distinct(Department) from tblDepartment";
                obj.filllist(ddlDepartment, sql, lblError);

                string var = ClientScript.GetPostBackEventReference(btnSave, "").ToString();
                btnSave.Attributes.Add("onClick", "javascript :if ( Page_ClientValidate() ){this.disabled=true; this.value='Pls Wait...';" + var + "};");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminSubjectList.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from tblSubjects where Course='" + ddlCourse.SelectedValue + "' and SemorYear='" + ddlSemorYear.SelectedValue + "' and SubjectCode='" + txtSubjectCode.Text.Trim() + "'";
                if (obj.checkduplicate(sql))
                {
                    readyclass.errormessage(lblError, "Subject Already exist");
                }
                else
                {
                    lblError.Text = "";

                    int id = obj.autoid("tblSubjects", "ID");

                    sql = "insert into tblSubjects (ID,Course,SemorYear,Subject,SubjectCode,Department) ";
                    sql = sql + "Values(" + id + ", ";
                    sql = sql + "'" + ddlCourse.SelectedValue + "','" + ddlSemorYear.SelectedValue + "', ";
                    sql = sql + "'" + txtSubject.Text.Trim() + "','" + txtSubjectCode.Text.Trim() + "','" + ddlDepartment.SelectedValue + "')";

                    int rowaffected = Database.executeQuery(sql);

                    if (rowaffected > 0)
                    {
                        obj.Show("Saved Successfully", "AdminSubjectList.aspx");
                    }
                    else
                    {
                        obj.ShowAlert(this, "Action is not processed");
                    }
                }
            }
            catch (Exception ex)
            {
                readyclass.errormessage(lblError, ex.Message);
            }
        }
    }
}