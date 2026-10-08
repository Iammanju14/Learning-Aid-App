<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminCollegesList.aspx.cs" Inherits="Gnana_Jyothi.Admin.AdminCollegesList" EnableEventValidation="false" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h3>Colleges List</h3>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

   
   
    <asp:Button ID="btnNewrecord" runat="server" Text="New Record" 
           onclick="btnNewrecord_Click"/>

    <table class="minitable">
    <tr>
    <td>State</td>
    <td>
        <asp:DropDownList ID="ddlState" runat="server">
        </asp:DropDownList>
        <asp:CascadingDropDown ID="cdlState" TargetControlID="ddlState" PromptValue="" runat="server" Category="State" LoadingText="Loading..." ServiceMethod="BindStateFromCollege"  ServicePath="~/ServiceFillList.asmx"/>
     
    </td>
    </tr>
    
    <tr>
    <td>District</td>
    <td>
        <asp:DropDownList ID="ddlDistrict" runat="server">
        </asp:DropDownList>
      <asp:CascadingDropDown ID="cdlDistrict" TargetControlID="ddlDistrict" ParentControlID="ddlState" PromptValue="" runat="server" Category="District" LoadingText="Loading..." ServiceMethod="BindDitrictFromCollege"  ServicePath="~/ServiceFillList.asmx"/>

    </td>
    </tr>


    <tr>
    <td>Taluk</td>
    <td>
        <asp:DropDownList ID="ddlTaluk" runat="server">
        </asp:DropDownList>
          <asp:CascadingDropDown ID="cdlTaluk" TargetControlID="ddlTaluk" ParentControlID="ddlDistrict" PromptValue="" runat="server" Category="Taluk" LoadingText="Loading..." UseContextKey="true" ServiceMethod="BindTalukFromCollege"  ServicePath="~/ServiceFillList.asmx"/>

    </td>
    </tr>

    <tr>
    <td colspan="2" style="text-align:center;">
      
    <asp:Button ID="btnSearch" runat="server" Text="Search" onclick="btnSearch_Click"/>
    </td>
    </tr>

    </table>

     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>

 <asp:Label ID="lblerror" runat="server" Text="" CssClass="errormsg" Visible="false"></asp:Label> 

<asp:GridView ID="grdColleges" runat="server" 
                     AutoGenerateColumns="False" Caption="Colleges List" 
        CssClass="gridview" DataKeyNames="ID">
             <Columns>
                <asp:BoundField DataField="College" HeaderText="College">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                   <asp:BoundField DataField="AddressLine1" HeaderText="AddressLine1">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                
                 <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="AdminCollegesAdd.aspx?ID={0}" Text="View" HeaderText="View">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:HyperLinkField>
            </Columns>
            <HeaderStyle CssClass="headerstyle" />
</asp:GridView>

</ContentTemplate>

<Triggers>
                  <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
               </Triggers>

</asp:UpdatePanel>

</asp:Content>