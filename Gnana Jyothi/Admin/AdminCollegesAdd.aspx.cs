using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;

namespace Gnana_Jyothi.Admin
{
    public partial class AdminCollegesAdd : System.Web.UI.Page
    {
        readyclass obj = new readyclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            //ReadyClass.CheckSession();

            if (!IsPostBack)
            {
                string sql = "Select distinct(State) from tblCityList";
                obj.filllist(ddlState, sql, lblError);

                lblID.Text = Request.QueryString["ID"];

                if (lblID.Text.Trim() != "")
                {
                    pagerefresh();

                    obj.makereadonly(Page.Controls);

                    btnSave.Visible = false;
                    btnUpdate.Visible = false;
                    btnEdit.Visible = true;
                    btnCancel.Visible = true;
                    btnDelete.Visible = true;
                }
                else
                {
                    obj.makeeditable(Page.Controls);
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnEdit.Visible = false;
                    btnCancel.Visible = true;
                    btnDelete.Visible = false;
                }

                string var = ClientScript.GetPostBackEventReference(btnSave, "").ToString();
                btnSave.Attributes.Add("onClick", "javascript :if ( Page_ClientValidate() ){this.disabled=true; this.value='Pls Wait...';" + var + "};");

                var = ClientScript.GetPostBackEventReference(btnUpdate, "").ToString();
                btnUpdate.Attributes.Add("onClick", "javascript :if ( Page_ClientValidate() ){this.disabled=true; this.value='Pls Wait...';" + var + "};");

                var = ClientScript.GetPostBackEventReference(btnDelete, "").ToString();
                btnDelete.Attributes.Add("onClick", "javascript :if ( Page_ClientValidate() ){this.disabled=true; this.value='Pls Wait...';" + var + "};");


                btnDelete.Attributes.Add("onclick", "return confirm();");
            }
        }

        private void pagerefresh()
        {
            try
            {
                string state = string.Empty, district = string.Empty, taluk = string.Empty;

                string sql = "Select * from tblColleges where ID=" + lblID.Text.Trim() + "";
                SqlDataReader dr = Database.getDataReader(sql);

                if (dr.Read())
                {
                    lblID.Text = dr[0].ToString().Trim();
                    txtCollege.Text = dr[1].ToString().Trim();
                    txtAddressLine1.Text = dr[2].ToString().Trim();
                    txtAddressLine2.Text = dr[3].ToString().Trim();
                    taluk = dr[4].ToString().Trim();
                    district = dr[5].ToString().Trim();
                    state = dr[6].ToString().Trim();
                }
                dr.Close();

                ddlState.SelectedValue = state;
                ddlState_SelectedIndexChanged(this, new EventArgs());

                ddlDistrict.SelectedValue = district;
                ddlDistrict_SelectedIndexChanged(this, new EventArgs());

                ddlTaluk.SelectedValue = taluk;
            }
            catch (Exception ex)
            {
                readyclass.errormessage(lblError, ex.Message);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from tblColleges where College='" + txtCollege.Text.Trim() + "' and Taluk='" + ddlTaluk.SelectedValue + "' and District='" + ddlDistrict.SelectedValue + "' and State='" + ddlState.SelectedValue + "'";
                if (obj.checkduplicate(sql))
                {
                    readyclass.errormessage(lblError, "College Already exist");
                }
                else
                {
                    lblError.Text = "";

                    int id = obj.autoid("tblColleges", "ID");

                    sql = "insert into tblColleges (ID,College,AddressLine1,AddressLine2,Taluk,District,State) ";
                    sql = sql + "Values(" + id + ", '" + txtCollege.Text.Trim() + "','" + txtAddressLine1.Text.Trim() + "', ";
                    sql = sql + "'" + txtAddressLine2.Text.Trim() + "','" + ddlTaluk.SelectedValue + "', '" + ddlDistrict.SelectedValue + "', ";
                    sql = sql + "'" + ddlState.SelectedValue + "')";

                    int rowaffected = Database.executeQuery(sql);

                    if (rowaffected > 0)
                    {
                        obj.Show("Inserted Successfully", "AdminCollegesList.aspx");
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

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            obj.makeeditable(Page.Controls);

            btnEdit.Visible = false;
            btnUpdate.Visible = true;
            btnCancel.Visible = true;
            btnSave.Visible = false;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "update tblColleges set College='" + txtCollege.Text.Trim() + "',AddressLine1='" + txtAddressLine1.Text.Trim() + "', ";
                sql = sql + "AddressLine2='" + txtAddressLine2.Text.Trim() + "', Taluk='" + ddlTaluk.SelectedValue + "', ";
                sql = sql + "District='" + ddlDistrict.SelectedValue + "', State='" + ddlState.SelectedValue + "' where ID=" + lblID.Text.Trim() + "";
                int rowaffected = Database.executeQuery(sql);

                if (rowaffected > 0)
                {
                    obj.Show("Updated Successfully", "AdminCollegesList.aspx");
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminCollegesList.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "delete from tblColleges where ID = " + lblID.Text.Trim() + "";

                int rowaffected = Database.executeQuery(sql);

                if (rowaffected > 0)
                {
                    obj.Show("Deleted Successfully", "AdminCollegesList.aspx");
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

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "Select distinct(District) from tblCityList where State='" + ddlState.SelectedValue + "'";
            obj.filllist(ddlDistrict, sql, lblError);

            ddlDistrict_SelectedIndexChanged(this, new EventArgs());
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "Select distinct(Taluk) from tblCityList where State='" + ddlState.SelectedValue + "' and District='" + ddlDistrict.SelectedValue + "'";
            obj.filllist(ddlTaluk, sql, lblError);

        }
    }
}