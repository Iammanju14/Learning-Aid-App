<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminUploadMaterialsFile.aspx.cs" Inherits="Gnana_Jyothi.Admin.AdminUploadMaterialsFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<h3>Upload Materials</h3>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

   <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional">  

   <ContentTemplate>
   
   <table class="bigtable">

   
                            <tr>
              
<td>Department</td>
                	
					<td>
                        <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="true" 
                            onselectedindexchanged="ddlDepartment_SelectedIndexChanged">
                        </asp:DropDownList>
</td>
</tr>

<tr>

 <td>Course</td>
                	
					<td>
                    <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" 
                            onselectedindexchanged="ddlCourse_SelectedIndexChanged">
                        </asp:DropDownList>
              
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCourse"  Display="Dynamic" ValidationGroup="test1" CssClass="error" InitialValue="Select">*</asp:RequiredFieldValidator>

</td>

           
                <td>Sem</td>
                	
					<td>
                    <asp:DropDownList ID="ddlSemorYear" runat="server" AutoPostBack="true" 
                            onselectedindexchanged="ddlSemorYear_SelectedIndexChanged">
                        </asp:DropDownList>
              
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlSemorYear"  Display="Dynamic" ValidationGroup="test1" CssClass="error" InitialValue="Select">*</asp:RequiredFieldValidator>

</td>

     </tr>
                


                           <tr>
 <td>Subject</td>
                	
					<td>
                    <asp:DropDownList ID="ddlSubject" runat="server" AutoPostBack="true" 
                            onselectedindexchanged="ddlSubject_SelectedIndexChanged">
                        </asp:DropDownList>
              
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlSubject"  Display="Dynamic" ValidationGroup="test1" CssClass="error" InitialValue="Select">*</asp:RequiredFieldValidator>

</td>

                <td>Subject Code</td>
                	
					<td>
                    <asp:DropDownList ID="ddlSubjectCode" runat="server">
                        </asp:DropDownList>
              
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlSubjectCode"  Display="Dynamic" ValidationGroup="test1" CssClass="error" InitialValue="Select">*</asp:RequiredFieldValidator>

</td>

 
              
                </tr>

                             <tr>
                <td>Materil</td>
                	
					<td>
                    <asp:DropDownList ID="ddlMaterial" runat="server">
                        </asp:DropDownList>
              
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlMaterial"  Display="Dynamic" ValidationGroup="test" CssClass="error" InitialValue="Select">*</asp:RequiredFieldValidator>

</td>
    <td>Name</td>
                	
					<td>
                        <asp:TextBox ID="txtMaterialName" runat="server" MaxLength="100" placeholder="Enter Content Name"></asp:TextBox>
              
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtMaterialName"  Display="Dynamic" ValidationGroup="test" CssClass="error">*</asp:RequiredFieldValidator>

</td>



                </tr>


                
                     <tr>
             


 <td>Description</td>
                	
					<td colspan="3">
                    <asp:TextBox ID="txtDescription" runat="server" MaxLength="5000" Height="200px" Width="400px" placeholder="Enter Description" TextMode="MultiLine"></asp:TextBox>
              
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtDescription"  Display="Dynamic" ValidationGroup="test" CssClass="error">*</asp:RequiredFieldValidator>

</td>


                </tr>

                <tr>
                <td colspan="4" style="text-align:center;">

                <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>

                   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="flUploadMaterial"
                   ErrorMessage="Only pdf,swf and word Files are allowed" ValidationExpression="(.*?)\.(pdf|swf)$"  ValidationGroup="test" CssClass="errormsg"></asp:RegularExpressionValidator>

                   <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="flUploadMaterial"
   ErrorMessage="File size should not be greater than 10 MB." OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="test" Display="Dynamic" CssClass="errormsg"></asp:CustomValidator>

                </td>
                </tr>  
   </table>
   

   </ContentTemplate>

  
   </asp:UpdatePanel>


   <table class="bigtable">
   <tr>
     <td>Content</td>
                	
					<td>
                     
                 <asp:FileUpload ID="flUploadMaterial" runat="server"  accept=".pdf,.swf"/>
                
</td>
  
                	<td colspan="2"  style="text-align:center;">
   <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="test" onclick="btnSave_Click" />

             
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"/>
                    </td>
                </tr>
   </table>

</asp:Content>
