using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;

namespace Gnana_Jyothi.Admin
{
    public partial class AdminLecturersView : System.Web.UI.Page
    {
        readyclass obj = new readyclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblID.Text = Request.QueryString["ID"].ToString();
                txtMobile.ReadOnly = true;

                string sql = "Select distinct(State) from tblColleges";
                obj.filllist(ddlState, sql, lblError);

                sql = "Select distinct(Department) from tblDepartment";
                obj.filllist(ddlDepartment, sql, lblError);

                ddlState_SelectedIndexChanged(this, new EventArgs());
                ddlDistrict_SelectedIndexChanged(this, new EventArgs());
                ddlTaluk_SelectedIndexChanged(this, new EventArgs());

                pagerefresh();

                string var = ClientScript.GetPostBackEventReference(btnUpdate, "").ToString();
                btnUpdate.Attributes.Add("onClick", "javascript :if ( Page_ClientValidate() ){this.disabled=true; this.value='Pls Wait...';" + var + "};");

                var = ClientScript.GetPostBackEventReference(btnStatus, "").ToString();
                btnStatus.Attributes.Add("onClick", "javascript :if ( Page_ClientValidate() ){this.disabled=true; this.value='Pls Wait...';" + var + "};");

                var = ClientScript.GetPostBackEventReference(btnDelete, "").ToString();
                btnDelete.Attributes.Add("onClick", "javascript :if ( Page_ClientValidate() ){this.disabled=true; this.value='Pls Wait...';" + var + "};");

                btnCancel.Visible = true;
                btnDelete.Visible = true;
                btnEdit.Visible = true;
                btnUpdate.Visible = false;
            }
        }

        private void pagerefresh()
        {
            try
            {
                string state = string.Empty, district = string.Empty, taluk = string.Empty, college = string.Empty;

                string sql = "Select * from tblLecturers where ID=" + lblID.Text.Trim() + "";
                SqlDataReader dr = Database.getDataReader(sql);

                if (dr.Read())
                {
                    lblID.Text = dr[0].ToString().Trim();
                    txtName.Text = dr[1].ToString().Trim();
                    txtMobile.Text = dr[2].ToString().Trim();
                    txtEmailID.Text = dr[3].ToString().Trim();
                    state = dr[4].ToString().Trim();
                    district = dr[5].ToString().Trim();
                    taluk = dr[6].ToString().Trim();
                    college = dr[7].ToString().Trim();
                    ddlDepartment.SelectedValue = dr[8].ToString().Trim();
                    lblStatus.Text = dr[9].ToString().Trim();
                }
                dr.Close();

                ddlState.SelectedValue = state;
                ddlState_SelectedIndexChanged(this, new EventArgs());

                ddlDistrict.SelectedValue = district;
                ddlDistrict_SelectedIndexChanged(this, new EventArgs());

                ddlTaluk.SelectedValue = taluk;
                ddlTaluk_SelectedIndexChanged(this, new EventArgs());

                ddlCollege.SelectedValue = college;


                if (lblStatus.Text == "New")
                {
                    btnStatus.Text = "Activate";
                    btnStatus.Visible = true;
                }
                else
                    btnStatus.Visible = false;

                obj.makereadonly(Page.Controls);
            }
            catch (Exception ex)
            {
                readyclass.errormessage(lblError, ex.Message);
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

        protected void btnStatus_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = string.Empty;

                if (btnStatus.Text == "Activate")
                {
                    sql = "update tblLecturers set Status='Activate' where Mobile='" + txtMobile.Text.Trim() + "'";

                    int rowaffected = Database.executeQuery(sql);

                    string pwd = obj.generateOTP();

                    lblPwd.Text = pwd;

                    sql = "insert into tblLogin (UserID,Password,UserType,UserName) ";
                    sql = sql + "Values('" + txtMobile.Text.Trim() + "','" + pwd + "', 'Lecturer', ";
                    sql = sql + "'" + txtName.Text.Trim() + "')";
                    int rowaffected1 = Database.executeQuery(sql);


                    if (rowaffected > 0 && rowaffected1>0)
                    {
                        string msg = "You have registered to sucessfully. You can login into the application by using user ID " + txtMobile.Text.Trim() + " and Password is " + lblPwd.Text.Trim();

                        obj.sendSMS(msg, txtMobile.Text.Trim());

                        obj.Show(msg, "AdminLecturersList.aspx");
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
            btnDelete.Visible = false;
            btnStatus.Visible = false;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "update tblLecturers set Name='" + txtName.Text.Trim() + "',EmailID='" + txtEmailID.Text.Trim() + "', ";
                sql = sql + "State='" + ddlState.SelectedValue + "', District='" + ddlDistrict.SelectedValue + "', ";
                sql = sql + "Taluk='" + ddlTaluk.SelectedValue + "', College='" + ddlCollege.SelectedValue + "', ";
                sql = sql + "Department='" + ddlDepartment.SelectedValue + "'  where ID=" + lblID.Text.Trim() + "";
                int rowaffected = Database.executeQuery(sql);

                if (rowaffected > 0)
                {
                    obj.Show("Updated Successfully", "AdminLecturersList.aspx");
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
            Response.Redirect("AdminLecturersList.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "delete from tblLogin where UserID = '" + txtMobile.Text.Trim() + "'";

                int rowaffected = Database.executeQuery(sql);

                sql = "delete from tblLecturers where ID = " + lblID.Text.Trim() + "";

                int rowaffected1 = Database.executeQuery(sql);

                if (rowaffected > 0 && rowaffected1 > 0)
                {
                    obj.Show("Deleted Successfully", "AdminLecturersList.aspx");
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