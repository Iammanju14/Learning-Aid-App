using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;

using System.Net;
using System.Text;

using System.Data.SqlClient;

namespace Gnana_Jyothi.Lecturer
{
    public partial class LecturerMaterialsUploads : System.Web.UI.Page
    {
        readyclass obj = new readyclass();

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (flUploadMaterial.FileBytes.Length > 1048576000)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string sql = "Select distinct(Material) from tblMaterialTypes";
                obj.filllist(ddlMaterial, sql, lblerror);

                sql = "Select distinct(Department) from tblLecturers where Mobile='" + Session["UserID"].ToString() + "'";
                SqlDataReader dr = Database.getDataReader(sql);
                if (dr.Read())
                {
                    lblDepartment.Text = dr[0].ToString().Trim();
                }
                dr.Close();

                sql = "Select distinct(Course) from tblSubjects where Department='" + lblDepartment.Text + "'";
                obj.filllist(ddlCourse, sql, lblerror);

                ddlCourse_SelectedIndexChanged(this, new EventArgs());
                ddlSemorYear_SelectedIndexChanged(this, new EventArgs());
                ddlSubject_SelectedIndexChanged(this, new EventArgs());

            }
        }

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "Select distinct(SemorYear) from tblSubjects where Course='" + ddlCourse.SelectedValue + "' and Department='" + lblDepartment.Text + "'";
            obj.filllist(ddlSemorYear, sql, lblerror);

            ddlSemorYear_SelectedIndexChanged(this, new EventArgs());
            ddlSubject_SelectedIndexChanged(this, new EventArgs());
        }

        protected void ddlSemorYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "Select distinct(Subject) from tblSubjects where Course='" + ddlCourse.SelectedValue + "' and SemorYear='" + ddlSemorYear.SelectedValue + "' and Department='" + lblDepartment.Text + "'";
            obj.filllist(ddlSubject, sql, lblerror);

            ddlSubject_SelectedIndexChanged(this, new EventArgs());
        }

        protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "Select distinct(SubjectCode) from tblSubjects where Course='" + ddlCourse.SelectedValue + "' and SemorYear='" + ddlSemorYear.SelectedValue + "' and Subject='" + ddlSubject.SelectedValue + "' and Department='" + lblDepartment.Text + "'";
            obj.filllist(ddlSubjectCode, sql, lblerror);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (flUploadMaterial.HasFile && IsVaildFile())
            {

                lblerror.Text = "";

                int rowaffected = 0;

                int id = obj.autoid("tblMaterials", "ID");

                FileUpload pdff = (FileUpload)flUploadMaterial;
                Byte[] pdfbyte = null;

                HttpPostedFile File = flUploadMaterial.PostedFile;
                pdfbyte = new Byte[File.ContentLength];

                File.InputStream.Read(pdfbyte, 0, File.ContentLength);


                string sql = "insert into tblMaterials (ID,Course,SemorYear,Subject,SubjectCode,Department,Material,MaterialName, ";
                sql = sql + "Description,MaterialContent,UpdatedBy) ";
                sql = sql + "Values(" + id + ", '" + ddlCourse.SelectedValue + "','" + ddlSemorYear.SelectedValue + "', ";
                sql = sql + "'" + ddlSubject.SelectedValue + "','" + ddlSubjectCode.SelectedValue + "', '" + lblDepartment.Text.Trim() + "', ";
                sql = sql + "'" + ddlMaterial.SelectedValue + "','" + txtMaterialName.Text.Trim() + "', ";
                sql = sql + "'" + txtDescription.Text.Trim() + "','" + Convert.ToBase64String(pdfbyte) + "', ";
                sql = sql + "'" + Session["UserID"].ToString() + "')";

                rowaffected = Database.executeQuery(sql);

                if (rowaffected > 0)
                {
                    obj.Show("Uploaded Successfully", "LecturerMaterialsList.aspx");
                }
                else
                {
                    obj.ShowAlert(this, "Action is not processed");
                }

            }
            else
                readyclass.errormessage(lblerror, "Please upload file");
        }

        private bool IsVaildFile()
        {
            string swfExt = System.IO.Path.GetExtension(flUploadMaterial.FileName);

            switch (swfExt)
            {
                case ".pdf":
                    return true;
                default:
                    {
                        obj.ShowAlert(this, "Please select PDF File");
                        return false;
                    }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("LecturerMaterialsList.aspx");
        }

    }
}