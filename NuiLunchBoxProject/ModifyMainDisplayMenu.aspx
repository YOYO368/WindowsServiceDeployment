<%@ Page Title="" Language="C#" MasterPageFile="~/ManagerPage.Master" AutoEventWireup="true" CodeBehind="ModifyMainDisplayMenu.aspx.cs" Inherits="NuiLunchBoxProject.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset style="width: 100%; margin-top:10px">
        <legend>&nbsp;&nbsp; Delete Main Display Menu</legend>
        <br />
        <table style="width: 100%;margin-left:20px;margin-bottom:10px">
            <tr>
                <td style="height: 35px; width: 30%;">
                    <asp:Label ID="Label1" runat="server" Text="Selected :" Height="26px"></asp:Label>
                </td>
                <td style="height: 35px; width: 20%;">
                    <asp:Label ID="Label2" runat="server" style="margin-left: 7px" Text="0" Width="30px" Height="26px"></asp:Label>
                </td>    
                <td style="height: 35px; width: 50%;">
                    <asp:Button class="button button1" ID="Button1" runat="server" OnClick="btnDelete_Click1" Text="Delete" Width="250px" CausesValidation="False" Height="35px" />
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset style="width: 100%; margin-top:10px;margin-left:20px">
        <legend>&nbsp;&nbsp; View Main Display Menu</legend>
        <br />
       <asp:ListView ID="MenuList" runat="server" style="margin-left:10px">
           <ItemTemplate>
                <div style="float:left;width:23%">
                    <div><asp:CheckBox ID="CheckBox" runat="server" Text='  <%#Eval("Menu_Name") %>' ClientID='<%# Eval("Menu_Group")%>' OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="True"/></div>
                    <div><img style="width:100%" src='<%#Eval("Image_Path") %>', alt='<%#Eval("Menu_Name") %>' /></div>
                </div>
           </ItemTemplate>
        </asp:ListView>
    </fieldset>
</asp:Content>
