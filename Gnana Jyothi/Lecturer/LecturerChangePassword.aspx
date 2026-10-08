<%@ Page Title="" Language="C#" MasterPageFile="~/Lecturer/Lecturer.Master" AutoEventWireup="true" CodeBehind="LecturerChangePassword.aspx.cs" Inherits="Gnana_Jyothi.Lecturer.LecturerChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h1>Change Password</h1>
    <table class="minitable">

            <tr>
                <td style="width:30%">
                   Current Password
                </td>
                <td style="width:33%">
                    <asp:TextBox ID="txtCurPassword" runat="server" MaxLength="20" TextMode="Password" placeholder="Current Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="" ControlToValidate="txtCurPassword" ValidationGroup="test" CssClass="error" Display="Dynamic">*</asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td>
                   New Password
                </td>
                <td>
                    <asp:TextBox ID="txtNewPassword" runat="server" MaxLength="20" TextMode="Password" placeholder="New Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="" ControlToValidate="txtNewPassword" ValidationGroup="test" CssClass="error" Display="Dynamic">*</asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtNewPassword" ID="RegularExpressionValidator1" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{4,8}$" runat="server" ErrorMessage="" ValidationGroup="test" CssClass="error">*</asp:RegularExpressionValidator>
                   
                </td>
            </tr>

            <tr>
                <td>
                   Confirm Password
                </td>
                <td>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" MaxLength="20" TextMode="Password" placeholder="Confirm Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="" ControlToValidate="txtConfirmPassword" ValidationGroup="test" CssClass="error" Display="Dynamic">*</asp:RequiredFieldValidator>
                </td>
            </tr>

              <tr>
                    <td colspan="2" style="text-align:center;">
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password and confirm password should be same" Display="Dynamic" ValidationGroup="test" CssClass="errormsg" ControlToValidate="txtConfirmPassword" ControlToCompare="txtNewPassword"></asp:CompareValidator>
                    </td>
                    </tr>

            <tr>
                <td colspan="2" style="text-align:center;"> 
                    
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="test" 
                        onclick="btnUpdate_Click"/>

                    <br />
                    <asp:Label ID="lblerror" runat="server" Text="" Visible="False"  ></asp:Label>
                </td>
           </tr>
    </table>
    <asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label>


</asp:Content>
