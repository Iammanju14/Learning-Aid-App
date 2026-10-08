using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;

namespace Gnana_Jyothi
{
    public partial class Login : System.Web.UI.Page
    {
        readyclass obj = new readyclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtUserID.Focus();

                string var = ClientScript.GetPostBackEventReference(btnLogin, "").ToString();
                btnLogin.Attributes.Add("onClick", "javascript :if ( Page_ClientValidate() ){this.disabled=true; this.value='Pls Wait...';" + var + "};");
 
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from tblLogin where UserID= '" + txtUserID.Text.Trim() + "' and Password='" + txtPassword.Text.Trim() + "'";

                SqlDataReader dr = Database.getDataReader(sql);

                if (dr.Read())
                {
                    string str = dr[2].ToString();

                    dr.Close();
                    if (str.Trim() == "Admin")
                    {
                        Session["UserID"] = txtUserID.Text.Trim();
                        Response.Redirect("~/Admin/AdminHome.aspx");
                    }

                    else if (str.Trim() == "Lecturer")
                    {
                        Session["UserID"] = txtUserID.Text.Trim();
                        Response.Redirect("~/Lecturer/LecturerHome.aspx");
                    }
                }
                else
                {
                    readyclass.errormessage(lblerror, "Invalid User ID or Password");
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                readyclass.errormessage(lblerror, ex.Message);
            }
        }
    }
}