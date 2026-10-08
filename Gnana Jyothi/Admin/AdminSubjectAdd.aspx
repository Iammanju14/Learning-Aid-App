<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminSubjectAdd.aspx.cs" Inherits="Gnana_Jyothi.Admin.AdminSubjectAdd" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



<h3>Add/Update Subjects</h3>

 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>
   

<table class="minitable">

                    <tr>
                <td>Course</td>
                	
					<td>
                     <asp:DropDownList ID="ddlCourse" runat="server">
                        </asp:DropDownList>
              
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCourse"  Display="Dynamic" ValidationGroup="test" CssClass="error" InitialValue="Select">*</asp:RequiredFieldValidator>

                    </td>
                </tr>
                
                 <tr>
                <td>Sem/Year</td>
                	
					<td>
                    <asp:DropDownList ID="ddlSemorYear" runat="server">
                        </asp:DropDownList>
              
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlCourse"  Display="Dynamic" ValidationGroup="test" CssClass="error" InitialValue="Select">*</asp:RequiredFieldValidator>

</td>
                </tr>

                 <tr>
                <td>Subject</td>
                	
					<td>
                     <asp:TextBox ID="txtSubject" runat="server" placeholder="Enter Subject" MaxLength="100"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtSubject" Display="Dynamic" ValidationGroup="test" CssClass="error" InitialValue="Select">*</asp:RequiredFieldValidator>
     
</td>
                </tr>


                   <tr>
                <td>Subject Code</td>
                	
					<td>
                     <asp:TextBox ID="txtSubjectCode" runat="server" placeholder="Enter Subject Code" MaxLength="50"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSubjectCode" Display="Dynamic" ValidationGroup="test" CssClass="error" InitialValue="Select">*</asp:RequiredFieldValidator>
     
</td>
                </tr>


                    <tr>
                <td>Department</td>
                	
					<td>
                    <asp:DropDownList ID="ddlDepartment" runat="server">
                        </asp:DropDownList>
              
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlDepartment"  Display="Dynamic" ValidationGroup="test" CssClass="error" InitialValue="Select">*</asp:RequiredFieldValidator>

</td>
                </tr>

           <tr>
                	<td colspan="2"  style="text-align:center;">
   <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="test" 
                            onclick="btnSave_Click"  />

               
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click" />

                    
                    </td>
                </tr>

                <tr> 
                <td colspan="2" style="text-align:center;">
                    <asp:Label ID="lblError" runat="server" Text="" CssClass="errormsg" />
</td>
                </tr>




           </table>

        </ContentTemplate>
</asp:UpdatePanel>

</asp:Content>