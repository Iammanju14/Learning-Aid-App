<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="LecturerRegistration.aspx.cs" Inherits="Gnana_Jyothi.LecturerRegistration" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<h3>Registration</h3>

 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>
   

<table class="minitable">

   <tr>
                <td>Name</td>
                	
					<td>
                     <asp:TextBox ID="txtName" runat="server" placeholder="Enter Name" MaxLength="100"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtName" Display="Dynamic" ValidationGroup="test" CssClass="error" InitialValue="Select">*</asp:RequiredFieldValidator>
     
</td>
                </tr>

                     <tr>
                <td>Mobile</td>
                <td>
                    
                     <asp:TextBox ID="txtMobile" runat="server" placeholder="Enter 10 digits Mobile" MaxLength="10"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtMobile"  Display="Dynamic" ValidationGroup="test" CssClass="error">*</asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtMobile" ID="RegularExpressionValidator5" ValidationExpression = "^\d{10}$" runat="server" ErrorMessage="Enter 10 digits number." ValidationGroup="test" CssClass="error">*</asp:RegularExpressionValidator>
                    </td>
                	</tr>


                     <tr>
                     <td>Email ID</td>
                <td>
                    
                     <asp:TextBox ID="txtEmailID" runat="server" placeholder="Enter EmailID" MaxLength="100"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtEmailID"  Display="Dynamic" ValidationGroup="test" CssClass="error">*</asp:RequiredFieldValidator>
                    
                      <asp:RegularExpressionValidator ID="validateEmail"    
  runat="server" ErrorMessage="Invalid email." Display="Dynamic" 
  ControlToValidate="txtEmailID" 
  ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" CssClass="error">*</asp:RegularExpressionValidator>
                    </td>
                	</tr>

                    

     	<tr>
                	<td style="width:35%;">State</td>
					<td>
                        <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="true" 
                            onselectedindexchanged="ddlState_SelectedIndexChanged">
                        </asp:DropDownList>
              
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlState"  Display="Dynamic" ValidationGroup="test" CssClass="error" InitialValue="Select">*</asp:RequiredFieldValidator>

                    
                    </td>
                    </tr>
                    <tr>
                <td>District</td>
                	
					<td>
                     <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true" 
                            onselectedindexchanged="ddlDistrict_SelectedIndexChanged">
                        </asp:DropDownList>
              
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDistrict"  Display="Dynamic" ValidationGroup="test" CssClass="error" InitialValue="Select">*</asp:RequiredFieldValidator>

                    </td>
                </tr>
                
                 <tr>
                <td>Taluk</td>
                	
					<td>
                    <asp:DropDownList ID="ddlTaluk" runat="server" AutoPostBack="true"  
                            onselectedindexchanged="ddlTaluk_SelectedIndexChanged">
                        </asp:DropDownList>
              
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlTaluk"  Display="Dynamic" ValidationGroup="test" CssClass="error" InitialValue="Select">*</asp:RequiredFieldValidator>

</td>
                </tr>

                
                 <tr>
                <td>College</td>
                	
					<td>
                    <asp:DropDownList ID="ddlCollege" runat="server">
                        </asp:DropDownList>
              
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlCollege"  Display="Dynamic" ValidationGroup="test" CssClass="error" InitialValue="Select">*</asp:RequiredFieldValidator>

</td>
                </tr>


                     <tr>
                <td>Department</td>
                	
					<td>
                    <asp:DropDownList ID="ddlDepartment" runat="server">
                        </asp:DropDownList>
              
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlDepartment"  Display="Dynamic" ValidationGroup="test" CssClass="error" InitialValue="Select">*</asp:RequiredFieldValidator>

</td>
                </tr>

              

           <tr>
                	<td colspan="2"  style="text-align:center;">
                        <asp:Button ID="btnRegister" runat="server" Text="Register" 
                            ValidationGroup="test" onclick="btnRegister_Click" />
                          <asp:Button ID="btnBack" runat="server" Text="Back" onclick="btnBack_Click" />
                    </td>
                </tr>

                <tr> 
                <td colspan="2" style="text-align:center;">
                    <asp:Label ID="lblError" runat="server" Text="" CssClass="errormsg" />

                    <asp:Label ID="lblID" runat="server" Text=""  />
</td>
                </tr>

           </table>

        </ContentTemplate>
</asp:UpdatePanel>

</asp:Content>

