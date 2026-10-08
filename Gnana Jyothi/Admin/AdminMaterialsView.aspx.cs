using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Data.SqlClient;
using System.Data;

namespace Gnana_Jyothi.Admin
{
    public partial class AdminMaterialsView : System.Web.UI.Page
    {
        readyclass obj = new readyclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblID.Text = Request.QueryString["ID"].ToString();

                fetchMaterialDetails();
                fetchLecturerDetails();

                displayFeedBack();
            }
        }

        private void fetchMaterialDetails()
        {
            string sql = "Select * from tblMaterials where ID=" + lblID.Text.Trim() + "";
            SqlDataReader dr = Database.getDataReader(sql);
            if (dr.Read())
            {
                lblID.Text = dr[0].ToString().Trim();
                lblCourse.Text = dr[1].ToString().Trim();
                lblSem.Text = dr[2].ToString().Trim();
                lblSubject.Text = dr[3].ToString().Trim();
                lblSubjectCode.Text = dr[4].ToString().Trim();
                lblDepartment.Text = dr[5].ToString().Trim();
                lblMaterial.Text = dr[6].ToString().Trim();
                lblMaterialName.Text = dr[7].ToString().Trim();
                lblDescription.Text = dr[8].ToString().Trim();
                lblUpdatedBy.Text = dr[10].ToString().Trim();


                byte[] imgbyte = Convert.FromBase64String(dr[9].ToString().Trim());

                string imageUrl = "data:application/pdf;base64," + Convert.ToBase64String(imgbyte);
                string pdfUrl = imageUrl;
                pdfiframe.Attributes["src"] = pdfUrl + "#embedded=true&toolbar=0&navpanes=0";
            }
            dr.Close();



        }

        private void fetchLecturerDetails()
        {
            string sql = "Select * from tblLecturers where Mobile='" + lblUpdatedBy.Text.Trim() + "'";
            SqlDataReader dr = Database.getDataReader(sql);
            if (dr.Read())
            {
                lblName.Text = dr[1].ToString().Trim();
                lblState.Text = dr[4].ToString().Trim();
                lblDistrict.Text = dr[5].ToString().Trim();
                lblTaluk.Text = dr[6].ToString().Trim();
                lblCollege.Text = dr[7].ToString().Trim();
                lblLectDepartment.Text = dr[8].ToString().Trim();
            }
            dr.Close();
        }



        private void displayFeedBack()
        {
            string sql = "Select f.ID,f.FeedBack,s.Name,s.Mobile,s.College from tblFeedBack f,tblStudents s where f.MaterialID=" + lblID.Text.Trim() + " and f.PostedBy=s.Mobile";
            obj.fill(grdFeedBack, sql, lblerror);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminMaterialsList.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            string sql = "delete from tblFeedBack where MaterialID = " + lblID.Text.Trim() + "";
            Database.executeQuery(sql);

            sql = "delete from tblMaterials where ID = " + lblID.Text.Trim() + "";
            int rowaffected = Database.executeQuery(sql);

            if (rowaffected > 0)
            {
                obj.Show("Deleted Successfully", "AdminMaterialsList.aspx");
            }
            else
            {
                obj.ShowAlert(this, "Action is not processed");
            }
        }
    }
}