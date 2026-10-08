<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminSubjectList.aspx.cs" Inherits="Gnana_Jyothi.Admin.AdminSubjectList" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h3>Subjects List</h3>

    
    <asp:Button ID="btnNewrecord" runat="server" Text="New Record" 
        onclick="btnNewrecord_Click"/>

    <table class="minitable">

    
    <tr>
    <td>Course</td>
    <td>
        <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" 
            onselectedindexchanged="ddlCourse_SelectedIndexChanged">
        </asp:DropDownList>
        
    </td>
    </tr>


    <tr>
    <td>Sem/Year</td>
    <td>
        <asp:DropDownList ID="ddlSemorYear" runat="server">
        </asp:DropDownList>
         
    </td>
    </tr>

    <tr>
    <td colspan="2" style="text-align:center;">
    
    <asp:Button ID="btnSearch" runat="server" Text="Search" onclick="btnSearch_Click" />
    </td>
    </tr>

    </table>


   

 <asp:Label ID="lblerror" runat="server" Text="" CssClass="errormsg" Visible="false"></asp:Label> 

<asp:GridView ID="grdSubject" runat="server" 
                     AutoGenerateColumns="False" Caption="Subject List" 
        CssClass="gridview" DataKeyNames="ID" 
           onrowdatabound="grdSubject_RowDataBound" 
           onrowdeleting="grdSubject_RowDeleting" >
             <Columns>
                <asp:BoundField DataField="Subject" HeaderText="Subject">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                   <asp:BoundField DataField="SubjectCode" HeaderText="Subject Code">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                  <asp:BoundField DataField="Department" HeaderText="Department">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                 <asp:CommandField ShowDeleteButton="True" CausesValidation="False" />  
            </Columns>
            <HeaderStyle CssClass="headerstyle" />
</asp:GridView>


</asp:Content>