using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gnana_Jyothi.Admin
{
    public partial class AdminCollegesList : System.Web.UI.Page
    {
        readyclass obj = new readyclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
            string str = "select * from tblColleges where State='" + ddlState.SelectedValue + "' and District='" + ddlDistrict.SelectedValue + "' and Taluk='" + ddlTaluk.SelectedValue + "'";
            obj.fill(grdColleges, str, lblerror);
        }

        protected void btnNewrecord_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminCollegesAdd.aspx");
        }

    }
}