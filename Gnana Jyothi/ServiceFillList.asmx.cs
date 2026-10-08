using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.Data.SqlClient;

using AjaxControlToolkit;

namespace Gnana_Jyothi
{
     [System.Web.Script.Services.ScriptService()]

    public class ServiceFillList : System.Web.Services.WebService
    {
         readyclass obj = new readyclass();

         [WebMethod]
         public CascadingDropDownNameValue[] BindUniversityFromSubject(string knownCategoryValues, string category)
         {
             string query = "SELECT distinct(University) FROM tblSubjects";
             List<CascadingDropDownNameValue> University = GetData(query);
             return University.ToArray();
         }

         [WebMethod]
         public CascadingDropDownNameValue[] BindCourseFromSubject(string knownCategoryValues, string category)
         {
             string University = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)["University"];

             string query = "SELECT distinct(Course) FROM tblSubjects WHERE University = '" + University + "'";
             List<CascadingDropDownNameValue> Course = GetData(query);
             return Course.ToArray();
         }


         [WebMethod]
         public CascadingDropDownNameValue[] BindSemorYearFromSubject(string knownCategoryValues, string category, string contextKey)
         {
             string University = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)["University"];
             string Course = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)["Course"];

             string query = "SELECT distinct(SemorYear) FROM tblSubjects WHERE University = '" + University + "' and Course='" + Course + "'";
             List<CascadingDropDownNameValue> SemorYear = GetData(query);
             return SemorYear.ToArray();
         }


         [WebMethod]
         public CascadingDropDownNameValue[] BindStateFromCollege(string knownCategoryValues, string category)
         {
             string query = "SELECT distinct(State) FROM tblColleges";
             List<CascadingDropDownNameValue> State = GetData(query);
             return State.ToArray();
         }

         [WebMethod]
         public CascadingDropDownNameValue[] BindDitrictFromCollege(string knownCategoryValues, string category)
         {
             string State = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)["State"];

             string query = "SELECT distinct(District) FROM tblColleges WHERE State = '" + State + "'";
             List<CascadingDropDownNameValue> District = GetData(query);
             return District.ToArray();
         }

         [WebMethod]
         public CascadingDropDownNameValue[] BindTalukFromCollege(string knownCategoryValues, string category, string contextKey)
         {
             string State = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)["State"];
             string District = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)["District"];

             string query = "SELECT distinct(Taluk) FROM tblColleges WHERE State = '" + State + "' and District='" + District + "'";
             List<CascadingDropDownNameValue> Taluk = GetData(query);
             return Taluk.ToArray();
         }


         private List<CascadingDropDownNameValue> GetData(string query)
         {

             List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

             values.Add(new CascadingDropDownNameValue
             {
                 name = "Select",
                 value = "Select"
             });

             using (SqlDataReader reader = Database.getDataReader(query))
             {
                 while (reader.Read())
                 {
                     values.Add(new CascadingDropDownNameValue
                     {
                         name = reader[0].ToString(),
                         value = reader[0].ToString()
                     });
                 }

                 return values;

             }
         }
    }
}
