<%@ Page Title="" Language="C#" MasterPageFile="~/Lecturer/Lecturer.Master" AutoEventWireup="true" CodeBehind="LecturerMaterialsList.aspx.cs" Inherits="Gnana_Jyothi.Lecturer.LecturerMaterialsList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h3>Materials List</h3>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    
    <asp:Button ID="btnNewrecord" runat="server" Text="New File"
        onclick="btnNewrecord_Click" />

  

          <asp:UpdatePanel ID="UpdatePanel1" runat="server">  
   <ContentTemplate>
   
    <table class="bigtable">
    <tr>
    
    <td>Course</td>
    <td>
        <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" 
            onselectedindexchanged="ddlCourse_SelectedIndexChanged">
        </asp:DropDownList>
      </td>

    <td>Sem/Year</td>
    <td>
        <asp:DropDownList ID="ddlSemorYear" runat="server" AutoPostBack="true" 
            onselectedindexchanged="ddlSemorYear_SelectedIndexChanged">
        </asp:DropDownList>
    </td>
      </tr>


    <tr>
    <td>Subject</td>
    <td>
        <asp:DropDownList ID="ddlSubject" runat="server" AutoPostBack="true" 
            onselectedindexchanged="ddlSubject_SelectedIndexChanged">
        </asp:DropDownList>
    </td>
   
    <td>Material</td>
    <td>
        <asp:DropDownList ID="ddlMaterial" runat="server">
        </asp:DropDownList>
    </td>
     </tr>

     <tr>
    <td colspan="4" style="text-align:center;">
    
    <asp:Button ID="btnSearch" runat="server" Text="Search" onclick="btnSearch_Click" />
    </td>
    </tr>

    </table>

  

 <asp:Label ID="lblerror" runat="server" Text="" CssClass="errormsg" Visible="false"></asp:Label> 

 <div class="ScrollStyle">

<asp:Table ID="tblFiles" runat="server" CssClass="displaytable"
        GridLines="Horizontal">
    </asp:Table>


    </div>

    <asp:Label ID="lblUserID" runat="server" Text="" Visible="false"></asp:Label>

</ContentTemplate>

</asp:UpdatePanel>

</asp:Content>