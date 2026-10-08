<%@ Page Title="" Language="C#" MasterPageFile="~/Lecturer/Lecturer.Master" AutoEventWireup="true" CodeBehind="LecturerMaterialsView.aspx.cs" Inherits="Gnana_Jyothi.Lecturer.LecturerMaterialsView" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<h3>Materials Details</h3>
    
    
     
   <asp:Label ID="lblerror" runat="server" Text="" CssClass="errormsg" />


   <div style="width:100%; text-align:center;">

   
        <iframe runat="server" id="pdfiframe" frameborder="1" src=""  class="filedisplay" oncontextmenu="return false">
</iframe>

    </div>

   <div class="ScrollStyle">
    

<asp:GridView ID="grdFeedBack" runat="server" 
                     AutoGenerateColumns="true" Caption="FeedBack List" 
        CssClass="fullgridview">
             <Columns>
              
            </Columns>
            <HeaderStyle CssClass="headerstyle" />
</asp:GridView>

    </div>


     

   <table class="displaytable">

    <tr>
                <th colspan="4">
                Material Details
                </th>
                </tr>
                            <tr>
             

 <td style="width:20%;">Department</td>
                	
					 <td style="width:30%;">
                        <asp:Label ID="lblDepartment" runat="server" Text=""></asp:Label>
</td>
</tr>

<tr>

 <td>Course</td>
                	
					<td>
                  <asp:Label ID="lblCourse" runat="server" Text=""></asp:Label>
</td>

           
                <td>Sem</td>
                	
					<td>
                    <asp:Label ID="lblSem" runat="server" Text=""></asp:Label>
</td>

     </tr>
                


                           <tr>
 <td>Subject</td>
                	
					<td>
                      <asp:Label ID="lblSubject" runat="server" Text=""></asp:Label>
</td>

                <td>Subject Code</td>
                	
					<td>
                   <asp:Label ID="lblSubjectCode" runat="server" Text=""></asp:Label>
</td>

 
              
                </tr>


                             <tr>
                <td>Materil</td>
                	
					<td>
                   <asp:Label ID="lblMaterial" runat="server" Text=""></asp:Label>
</td>

  <td>Name</td>
                	
					<td>
                       <asp:Label ID="lblMaterialName" runat="server" Text=""></asp:Label>
</td>

                </tr>


              


                     <tr>
             


 <td>Description</td>
                	
					<td colspan="3">
                   <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
</td>


                </tr>



                
                <tr>
                <th colspan="4">
                Updated By
                </th>
                </tr>

                  <tr>
                <td>Name</td>
                	
					<td>
                   <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
</td>
              
                	<td>State</td>
					<td>
                          <asp:Label ID="lblState" runat="server" Text=""></asp:Label>
                    
                    </td>
                    </tr>
                    <tr>
                <td>District</td>
                	
					<td>
                       <asp:Label ID="lblDistrict" runat="server" Text=""></asp:Label>
                    </td>
               
                <td>Taluk</td>
                	
					<td>
                      <asp:Label ID="lblTaluk" runat="server" Text=""></asp:Label>
</td>
                </tr>

                
                 <tr>
                <td>College</td>
                	
					<td>
                     <asp:Label ID="lblCollege" runat="server" Text=""></asp:Label>
</td>
              
                <td>University</td>
                	
					<td>
                     <asp:Label ID="lblLectUniversity" runat="server" Text=""></asp:Label>
</td>
                </tr>


                     <tr>
                <td>Department</td>
                	
					<td>
                     <asp:Label ID="lblLectDepartment" runat="server" Text=""></asp:Label>
</td>
                </tr>




                  <tr>
                	<td colspan="4"  style="text-align:center;">
  
                    <asp:Button ID="btnBack" runat="server" Text="Back" onclick="btnBack_Click"/>

                    </td>
                </tr>

           
   </table>


   <asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label>
   <asp:Label ID="lblUpdatedBy" runat="server" Text="" Visible="false"></asp:Label>
  

</asp:Content>
