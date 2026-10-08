<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminCollegesAdd.aspx.cs" Inherits="Gnana_Jyothi.Admin.AdminCollegesAdd"  EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



<h3>Add/Update Colleges</h3>

 <asp:ToolkitScriptManager ID="ScriptManager1" runat="server">
    </asp:ToolkitScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

   <ContentTemplate>
   
   <table class="minitable">

   <tr>
                <td>College</td>
                	
					<td>
                     <asp:TextBox ID="txtCollege" runat="server" placeholder="Enter College" MaxLength="100"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCollege" Display="Dynamic" ValidationGroup="test" CssClass="error">*</asp:RequiredFieldValidator>
     
</td>
                </tr>

<tr>
                <td>Address Line1</td>
                	
					<td>
                     <asp:TextBox ID="txtAddressLine1" runat="server" placeholder="Enter Address" MaxLength="100"></asp:TextBox>
                         
</td>
                </tr>

                <tr>
                <td>Address Line2</td>
                	
					<td>
                     <asp:TextBox ID="txtAddressLine2" runat="server" placeholder="Enter Address" MaxLength="100"></asp:TextBox>
                         
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
                    <asp:DropDownList ID="ddlTaluk" runat="server">
                        </asp:DropDownList>
              
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlTaluk"  Display="Dynamic" ValidationGroup="test" CssClass="error" InitialValue="Select">*</asp:RequiredFieldValidator>
   
</td>
                </tr>

                            
           <tr>
                	<td colspan="2"  style="text-align:center;">
   <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="test" 
                            onclick="btnSave_Click"  />

                    <asp:Button ID="btnEdit" runat="server" Text="Edit" onclick="btnEdit_Click" />

                    <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="test" 
                            onclick="btnUpdate_Click" />
             
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                            onclick="btnCancel_Click"  />

                    <asp:Button ID="btnDelete" runat="server" Text="Delete" 
                       OnClientClick="javascript:return confirm('Are you sure you want Delete?');" 
                            onclick="btnDelete_Click" />

                    
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