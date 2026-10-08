using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

namespace Gnana_Jyothi.Lecturer
{
    public partial class LecturerMaterialsList : System.Web.UI.Page
    {
        readyclass obj = new readyclass();
        string UserID = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string var = ClientScript.GetPostBackEventReference(btnSearch, null);
                btnSearch.Attributes.Add("onclick", "if(typeof (Page_ClientValidate) === 'function' && !Page_ClientValidate()){return false;} this.disabled = true;this.value = 'Working...';" + var + ";");

                lblUserID.Text = Session["UserID"].ToString();

                string sql = "Select distinct(Course) from tblMaterials where UpdatedBy='" + lblUserID.Text.Trim() + "'";
                obj.filllist(ddlCourse, sql, lblerror);

                ddlCourse_SelectedIndexChanged(this, new EventArgs());
                ddlSemorYear_SelectedIndexChanged(this, new EventArgs());
                ddlSubject_SelectedIndexChanged(this, new EventArgs());

            }
        }

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "Select distinct(SemorYear) from tblMaterials where UpdatedBy='" + lblUserID.Text.Trim() + "' and Course='" + ddlCourse.SelectedValue + "'";
            obj.filllist(ddlSemorYear, sql, lblerror);

            ddlSemorYear_SelectedIndexChanged(this, new EventArgs());
            ddlSubject_SelectedIndexChanged(this, new EventArgs());
        }

        protected void ddlSemorYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "Select distinct(Subject) from tblMaterials where UpdatedBy='" + lblUserID.Text.Trim() + "' and Course='" + ddlCourse.SelectedValue + "' and SemorYear='" + ddlSemorYear.SelectedValue + "'";
            obj.filllist(ddlSubject, sql, lblerror);

            ddlSubject_SelectedIndexChanged(this, new EventArgs());
        }

        protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "Select distinct(Material) from tblMaterials where UpdatedBy='" + lblUserID.Text.Trim() + "' and Course='" + ddlCourse.SelectedValue + "' and SemorYear='" + ddlSemorYear.SelectedValue + "' and Subject='" + ddlSubject.SelectedValue + "'";
            obj.filllist(ddlMaterial, sql, lblerror);

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {


            string sql = "select ID,MaterialName,Description from tblMaterials where UpdatedBy='" + lblUserID.Text.Trim() + "' and Course='" + ddlCourse.SelectedValue + "' and SemorYear='" + ddlSemorYear.SelectedValue + "' and Subject='" + ddlSubject.SelectedValue + "' and Material='" + ddlMaterial.SelectedValue + "'";

            DataSet ds = new DataSet();
            ds = Database.getdataset(sql);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                TableRow tr;
                TableCell tc;
                HyperLink hy;
                TableHeaderCell thc;

                tr = new TableRow();

                hy = new HyperLink();
                thc = new TableHeaderCell();
                hy.Text = ds.Tables[0].Rows[i][1].ToString();
                hy.NavigateUrl = "LecturerMaterialsView.aspx?ID=" + ds.Tables[0].Rows[i][0].ToString();
                thc.Controls.Add(hy);
                thc.Width = 500;
                thc.HorizontalAlign = HorizontalAlign.Center;
                tr.Cells.Add(thc);

                tblFiles.Rows.Add(tr);


                tr = new TableRow();

                tc = new TableCell();
                tc.ColumnSpan = 3;
                tc.Text = ds.Tables[0].Rows[i][2].ToString();
                tr.Cells.Add(tc);


                tblFiles.Rows.Add(tr);
            }
        }

        protected void btnNewrecord_Click(object sender, EventArgs e)
        {
            Response.Redirect("LecturerMaterialsUploads.aspx");
        }
    }
}