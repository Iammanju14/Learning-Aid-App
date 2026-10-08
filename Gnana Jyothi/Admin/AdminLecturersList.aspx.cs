using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gnana_Jyothi.Admin
{
    public partial class AdminLecturersList : System.Web.UI.Page
    {
        readyclass obj = new readyclass();

        static int i = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sql = "Select distinct(State) from tblLecturers";
                obj.filllist(ddlState, sql, lblerror);

                ddlState_SelectedIndexChanged(this, new EventArgs());
                ddlDistrict_SelectedIndexChanged(this, new EventArgs());
                ddlTaluk_SelectedIndexChanged(this, new EventArgs());

                string var = ClientScript.GetPostBackEventReference(btnSearch, "").ToString();
                btnSearch.Attributes.Add("onClick", "javascript :if ( Page_ClientValidate() ){this.disabled=true; this.value='Pls Wait...';" + var + "};");

            }
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "Select distinct(District) from tblLecturers where State='" + ddlState.SelectedValue + "'";
            obj.filllist(ddlDistrict, sql, lblerror);

            ddlDistrict_SelectedIndexChanged(this, new EventArgs());
            ddlTaluk_SelectedIndexChanged(this, new EventArgs());
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "Select distinct(Taluk) from tblLecturers where State='" + ddlState.SelectedValue + "' and District='" + ddlDistrict.SelectedValue + "'";
            obj.filllist(ddlTaluk, sql, lblerror);

            ddlTaluk_SelectedIndexChanged(this, new EventArgs());
        }

        protected void ddlTaluk_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "Select distinct(College) from tblLecturers where State='" + ddlState.SelectedValue + "' and District='" + ddlDistrict.SelectedValue + "' and Taluk='" + ddlTaluk.SelectedValue + "'";
            obj.filllist(ddlCollege, sql, lblerror);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            fill();

        }

        private void fill()
        {
            string str = "select * from tblLecturers where State='" + ddlState.SelectedValue + "' and District='" + ddlDistrict.SelectedValue + "' and Taluk='" + ddlTaluk.SelectedValue + "' and College='" + ddlCollege.SelectedValue + "'";
            obj.fill(grdColleges, str, lblerror);
        }

    }
}