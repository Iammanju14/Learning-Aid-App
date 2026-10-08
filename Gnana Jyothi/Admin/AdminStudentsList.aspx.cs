using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gnana_Jyothi.Admin
{
    public partial class AdminStudentsList : System.Web.UI.Page
    {
        readyclass obj = new readyclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string var = ClientScript.GetPostBackEventReference(btnSearch, "").ToString();
                btnSearch.Attributes.Add("onClick", "javascript :if ( Page_ClientValidate() ){this.disabled=true; this.value='Pls Wait...';" + var + "};");

                string sql = "Select distinct(State) from tblStudents";
                obj.filllist(ddlState, sql, lblerror);

                ddlState_SelectedIndexChanged(this, new EventArgs());
                ddlDistrict_SelectedIndexChanged(this, new EventArgs());
                ddlTaluk_SelectedIndexChanged(this, new EventArgs());
                ddlCollege_SelectedIndexChanged(this, new EventArgs());
                ddlCourse_SelectedIndexChanged(this, new EventArgs());
            }
        }

        private void fill()
        {
            string str = "select * from tblStudents where State='" + ddlState.SelectedValue + "' and District='" + ddlDistrict.SelectedValue + "' and Taluk='" + ddlTaluk.SelectedValue + "' and College='" + ddlCollege.SelectedValue + "' and Course='" + ddlCourse.SelectedValue + "' and SemorYear='" + ddlSemorYear.SelectedValue + "'";
            obj.fill(grdColleges, str, lblerror);
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "Select distinct(District) from tblStudents where State='" + ddlState.SelectedValue + "'";
            obj.filllist(ddlDistrict, sql, lblerror);

            ddlDistrict_SelectedIndexChanged(this, new EventArgs());
            ddlTaluk_SelectedIndexChanged(this, new EventArgs());
            ddlCollege_SelectedIndexChanged(this, new EventArgs());
            ddlCourse_SelectedIndexChanged(this, new EventArgs());
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "Select distinct(Taluk) from tblStudents where State='" + ddlState.SelectedValue + "' and District='" + ddlDistrict.SelectedValue + "'";
            obj.filllist(ddlTaluk, sql, lblerror);

            ddlTaluk_SelectedIndexChanged(this, new EventArgs());
            ddlCollege_SelectedIndexChanged(this, new EventArgs());
            ddlCourse_SelectedIndexChanged(this, new EventArgs());
        }

        protected void ddlTaluk_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "Select distinct(College) from tblStudents where State='" + ddlState.SelectedValue + "' and District='" + ddlDistrict.SelectedValue + "' and Taluk='" + ddlTaluk.SelectedValue + "'";
            obj.filllist(ddlCollege, sql, lblerror);

            ddlCollege_SelectedIndexChanged(this, new EventArgs());
            ddlCourse_SelectedIndexChanged(this, new EventArgs());
        }

        protected void ddlCollege_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "Select distinct(Course) from tblStudents where State='" + ddlState.SelectedValue + "' and District='" + ddlDistrict.SelectedValue + "' and Taluk='" + ddlTaluk.SelectedValue + "' and College='" + ddlCollege.SelectedValue + "'";
            obj.filllist(ddlCourse, sql, lblerror);
            ddlCourse_SelectedIndexChanged(this, new EventArgs());
        }

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "Select distinct(SemorYear) from tblStudents where State='" + ddlState.SelectedValue + "' and District='" + ddlDistrict.SelectedValue + "' and Taluk='" + ddlTaluk.SelectedValue + "' and College='" + ddlCollege.SelectedValue + "' and Course='" + ddlCourse.SelectedValue + "'";
            obj.filllist(ddlSemorYear, sql, lblerror);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            fill();
        }
    }
}