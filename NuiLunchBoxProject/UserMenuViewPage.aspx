<%@ Page Title="" Language="C#" MasterPageFile="~/UserPage.Master" AutoEventWireup="true" CodeBehind="UserMenuViewPage.aspx.cs" Inherits="NuiLunchBoxProject.WebForm15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset style="width: 90%;float:left;margin-left:50px">
            <legend>Menu View</legend>
            <asp:ListView ID="MenuList" runat="server">
                 <ItemTemplate>
                     <div style="float:left;width:19%;">
                        <div><a href="UserMenuDetail.aspx?Menu_Group=<%=Session["ClickGroup"]%>&Menu_Name=<%#Eval("Menu_Name")%>">
                        <img style="width:100%" src='<%#Eval("Image_Path") %>', alt='<%#Eval("Menu_Name") %>' /></a></div>
                        <div><center><asp:Label ID="Label1" runat="server" Text='<%#Eval("Menu_Name") %>'></asp:Label></center></div>
                     </div>
           </ItemTemplate>
        </asp:ListView>
    </fieldset>
</asp:Content>
