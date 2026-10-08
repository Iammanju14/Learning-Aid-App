using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gnana_Jyothi
{
    public partial class LecturerRegistration : System.Web.UI.Page
    {
        readyclass obj = new readyclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sql = "Select distinct(State) from tblColleges";
                obj.filllist(ddlState, sql, lblError);

                sql = "Select distinct(Department) from tblDepartment";
                obj.filllist(ddlDepartment, sql, lblError);

         
                ddlState_SelectedIndexChanged(this, new EventArgs());
                ddlDistrict_SelectedIndexChanged(this, new EventArgs());
                ddlTaluk_SelectedIndexChanged(this, new EventArgs());

                string var = ClientScript.GetPostBackEventReference(btnRegister, "").ToString();
                btnRegister.Attributes.Add("onClick", "javascript :if ( Page_ClientValidate() ){this.disabled=true; this.value='Pls Wait...';" + var + "};");
            }
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "Select distinct(District) from tblColleges where State='" + ddlState.SelectedValue + "'";
            obj.filllist(ddlDistrict, sql, lblError);

            ddlDistrict_SelectedIndexChanged(this, new EventArgs());
            ddlTaluk_SelectedIndexChanged(this, new EventArgs());
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "Select distinct(Taluk) from tblColleges where State='" + ddlState.SelectedValue + "' and District='" + ddlDistrict.SelectedValue + "'";
            obj.filllist(ddlTaluk, sql, lblError);

            ddlTaluk_SelectedIndexChanged(this, new EventArgs());
        }

        protected void ddlTaluk_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "Select distinct(College) from tblColleges where State='" + ddlState.SelectedValue + "' and District='" + ddlDistrict.SelectedValue + "' and Taluk='" + ddlTaluk.SelectedValue + "'";
            obj.filllist(ddlCollege, sql, lblError);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                int id = obj.autoid("tblLecturers", "ID");

                string sql = "insert into tblLecturers (ID,Name,Mobile,EmailID,State,District,Taluk,College,Department,Status) ";
                sql = sql + "Values(" + id + ", '" + txtName.Text.Trim() + "','" + txtMobile.Text.Trim() + "', ";
                sql = sql + "'" + txtEmailID.Text.Trim() + "','" + ddlState.SelectedValue + "','" + ddlDistrict.SelectedValue + "', ";
                sql = sql + "'" + ddlTaluk.SelectedValue + "','" + ddlCollege.SelectedValue + "','" + ddlDepartment.SelectedValue + "','New')";

                int rowaffected = Database.executeQuery(sql);

                if (rowaffected > 0)
                {
                    obj.Show("Please wait for admin approval. Registered Successfully", "Login.aspx");
                }
                else
                {
                    obj.ShowAlert(this, "Action is not processed");
                }


            }
            catch (Exception ex)
            {
                readyclass.errormessage(lblError, ex.Message);
            }
        }
    }
}