<%@ Page Title="" Language="C#" MasterPageFile="~/UserPage.Master" AutoEventWireup="true" CodeBehind="UserSearchPasswd.aspx.cs" Inherits="NuiLunchBoxProject.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset style="margin-top:70px; margin-left:200px; width=100%">
        <table class="nav-justified" style="width:90%">
            <tr>
                <td colspan="3">Enter your email address below and we will email your password.</td>
            </tr>
            <tr>
                <td colspan="3" style="height: 20px"><h3>EMAIL ME MY PASSWORD</h3></td>
            </tr>
            <tr>
                <td colspan="3" style="width:100%;border:solid 3px cadetblue"></td>
            </tr>
             <tr>
                <td style="width: 80px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width:50px">Email :</td>
                <td style="width:400px"><asp:TextBox ID="txtEmail" runat="server" TextMode="Email" Width="350px"></asp:TextBox></td>
                <td style="width:400px"><asp:Button class="w3-teal" ID="btnSendEmail" runat="server" Text="SEND ME MY PASSWORD" width="300px" OnClick="btnSendEmail_Click"/></td>
            </tr>
            <tr>
                <td style="width: 80px">&nbsp;</td>
            </tr>
        </table>

    </fieldset>
</asp:Content>
