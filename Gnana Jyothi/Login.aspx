<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Gnana_Jyothi.Login" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



<h3>Login Page</h3>

<table class="minitable">

<tr>
<td style="text-align:center;">
<asp:Label ID="lblerror" runat="server" Text="" Visible="false" CssClass="errormsg"></asp:Label>
</td>
</tr>
            	<tr>
                	
					<td>
                          <asp:TextBox ID="txtUserID" runat="server" placeholder="Enter User ID" MaxLength="100"></asp:TextBox>
              
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserid"  Display="Dynamic" ValidationGroup="test" CssClass="error">*</asp:RequiredFieldValidator>

                    
                    </td>
                </tr>
       			
                <tr>
                	
					<td>
                      <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Enter Passowrd" MaxLength="20"></asp:TextBox>
           
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ValidationGroup="test" CssClass="error">*</asp:RequiredFieldValidator>
     
</td>
                </tr>

                <tr>
                	<td  style="text-align:center;">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" ValidationGroup="test" 
                            onclick="btnLogin_Click" />
                    </td>
                </tr>
                  
                   <tr>
                	<td  style="text-align:center;">
                    <span class="button_style">New Lecturer? <a href="LecturerRegistration.aspx">Register Here</a></span>
                    
                    </td>
                </tr>

           </table>

</asp:Content>