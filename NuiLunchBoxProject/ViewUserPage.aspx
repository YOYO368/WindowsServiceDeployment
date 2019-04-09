<%@ Page Title="" Language="C#" MasterPageFile="~/UserPage.Master" AutoEventWireup="true" CodeBehind="ViewUserPage.aspx.cs" Inherits="NuiLunchBoxProject.ViewMasterPage" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <fieldset style="width: 100%;float:left; margin-left:50px;margin-top:100px">
            <asp:ListView ID="MenuList" runat="server">
                 <ItemTemplate>
                     <div style="float:left;width:23%;">
                        <div><a href="UserMenuViewPage.aspx?Menu_Group=<%#Eval("Menu_Group")%>">
                        <img style="width:100%" src='<%#Eval("Image_Path") %>', alt='<%#Eval("Image_Path")%>' /></a></div>
                     </div>
           </ItemTemplate>
        </asp:ListView>
    </fieldset>
 </asp:Content>
