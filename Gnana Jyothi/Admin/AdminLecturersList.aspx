<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminLecturersList.aspx.cs" Inherits="Gnana_Jyothi.Admin.AdminLecturersList" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h3>Lecturers List</h3>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

   
           
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>

    <table class="minitable">
    <tr>
    <td>State</td>
    <td>
        <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="true" 
            onselectedindexchanged="ddlState_SelectedIndexChanged">
        </asp:DropDownList>
     
    </td>
    </tr>
    
    <tr>
    <td>District</td>
    <td>
        <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true" 
            onselectedindexchanged="ddlDistrict_SelectedIndexChanged">
        </asp:DropDownList>
  
    </td>
    </tr>


    <tr>
    <td>Taluk</td>
    <td>
        <asp:DropDownList ID="ddlTaluk" runat="server" AutoPostBack="true" 
            onselectedindexchanged="ddlTaluk_SelectedIndexChanged">
        </asp:DropDownList>
         
    </td>
    </tr>

    <tr>
    <td>College</td>
    <td>
        <asp:DropDownList ID="ddlCollege" runat="server">
        </asp:DropDownList>
         
    </td>
    </tr>


    <tr>
    <td colspan="2" style="text-align:center;">
      
    <asp:Button ID="btnSearch" runat="server" Text="Search"  onclick="btnSearch_Click"  />

    

    </td>
    </tr>

    </table>

 <asp:Label ID="lblerror" runat="server" Text="" CssClass="errormsg" Visible="false"></asp:Label> 


<div class="ScrollStyle">

<asp:GridView ID="grdColleges" runat="server" 
                     AutoGenerateColumns="False" Caption="Students List" 
        CssClass="gridview" >
             <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                   <asp:BoundField DataField="Mobile" HeaderText="Mobile">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                
                  <asp:BoundField DataField="Department" HeaderText="Department">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>

                <asp:BoundField DataField="Status" HeaderText="Status">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>

                 <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="AdminLecturersView.aspx?ID={0}" Text="View" HeaderText="View">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:HyperLinkField>
            </Columns>
            <HeaderStyle CssClass="headerstyle" />
</asp:GridView>

</div>


</ContentTemplate>

    </asp:UpdatePanel>

</asp:Content>