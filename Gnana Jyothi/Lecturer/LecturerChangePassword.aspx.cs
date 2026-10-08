using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gnana_Jyothi.Lecturer
{
    public partial class LecturerChangePassword : System.Web.UI.Page
    {
        readyclass obj = new readyclass();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                lblID.Text = Session["UserID"].ToString();


                string var = ClientScript.GetPostBackEventReference(btnUpdate, "").ToString();
                btnUpdate.Attributes.Add("onClick", "javascript :if ( Page_ClientValidate() ){this.disabled=true; this.value='Pls Wait...';" + var + "};");


            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from tblLogin where UserID='" + lblID.Text.Trim() + "' and Password='" + txtCurPassword.Text.Trim() + "'";

                bool flag = obj.checkduplicate(sql);

                if (flag == true)
                {
                    string sql1 = "Update tblLogin SET ";
                    sql1 = sql1 + "Password='" + txtNewPassword.Text.Trim() + "' where UserID='" + lblID.Text.Trim() + "'";

                    int rowaffected = Database.executeQuery(sql1);

                    if (rowaffected > 0)
                    {
                        obj.ShowAlert(this, "Password Updated Successfully");
                    }
                    else
                    {
                        obj.ShowAlert(this, "Action is not processed");
                    }
                }
                else
                    obj.ShowAlert(this, "Current Password is incorrect");
            }
            catch (Exception ex)
            {
                readyclass.errormessage(lblerror, ex.Message);
            }
        }
    }
}