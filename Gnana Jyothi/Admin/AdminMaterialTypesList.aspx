<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminMaterialTypesList.aspx.cs" Inherits="Gnana_Jyothi.Admin.AdminMaterialTypesList" %>




<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h3>Materials List</h3>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>
   
    <asp:Button ID="btnNewrecord" runat="server" Text="New Record" 
           onclick="btnNewrecord_Click"/>


   <asp:Button ID="btnShowPopup" runat="server" style="display:none" />

      <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"
 BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>


   <asp:Panel ID="pnlpopup" runat="server" CssClass="modalPopup" style="display:none">

<table class="minitable">
<tr>
<td style="width:35%;">
    Material
</td>
<td>
  <asp:TextBox ID="txtMaterial" runat="server" placeholder="Enter University" MaxLength="100" />
  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMaterial"  Display="Dynamic" ValidationGroup="test" CssClass="error">*</asp:RequiredFieldValidator>

</td>
</tr>


  <tr>
        <td colspan="2" style="text-align:center;">
             <asp:Button ID="btnSave" runat="server" Text="Save" 
                        ToolTip="Click here to Add" onclick="btnSave_Click" ValidationGroup="test"/> 
                 
                 <asp:Button ID="btnCancel" CommandName="Cancel" runat="server" 
                 Text="Cancel" onclick="btnCancel_Click"  />  
        </td>
        </tr>
</table>


</asp:Panel>

 <asp:Label ID="lblerror" runat="server" Text="" CssClass="errormsg" Visible="false"></asp:Label> 

 <div class="ScrollStyle">
<asp:GridView ID="grdMaterial" runat="server" 
                     AutoGenerateColumns="False" Caption="Material List" 
        CssClass="minigrid" DataKeyNames="ID" 
           onrowdatabound="grdMaterial_RowDataBound" 
           onrowdeleting="grdMaterial_RowDeleting">
             <Columns>
                <asp:BoundField DataField="Material" HeaderText="Material">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                 <asp:CommandField ShowDeleteButton="True" />  
            </Columns>
            <HeaderStyle CssClass="headerstyle" />
</asp:GridView>

</div>

</ContentTemplate>
</asp:UpdatePanel>

</asp:Content>