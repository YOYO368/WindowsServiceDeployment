<%@ Page Title="" Language="C#" MasterPageFile="~/UserPage.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="NuiLunchBoxProject.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset style="margin-top:70px; margin-left:200px">
       <legend>Login</legend>
       <table>
           <tr>
               <td style="width: 200px; height: 30px">
                   <asp:Label ID="Label_UserID" runat="server" AssociatedControlID="txtUserID" Text="User ID :"></asp:Label>
               </td>
               <td style="width: 400px;height: 30px">
                   <asp:TextBox ID="txtUserID" runat="server" Width="300px"></asp:TextBox>
               </td>
               <td style="width: 500px">
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator_UserID" runat="server" ControlToValidate="txtUserID" ErrorMessage="Please input User ID" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
               </td>
           </tr>
           <tr>
               <td style="width: 200px"></td>
           </tr>
           <tr>
               <td style="width: 200px; height: 30px">
                   <asp:Label ID="Label_UserPasswd" runat="server" AssociatedControlID="txtUserPasswd" Text="User Password :"></asp:Label>
               </td>
               <td style="width: 400px; height: 30px">
                   <asp:TextBox ID="txtUserPasswd" runat="server" TextMode="Password" Width="300px"></asp:TextBox>
               </td>
               <td style="width: 700px">
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator_UserPasswd" runat="server" ControlToValidate="txtUserPasswd" ErrorMessage="Please input User Password" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
               </td>
           </tr>
            <tr>
               <td style="width: 200px"></td>
           </tr>
           <tr>
               <td style="width: 200px">&nbsp;</td>
               <td style="width: 400px">
                   <asp:Button class="button button2" ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" Width="300px" />
               </td>
               <td>&nbsp;</td>
           </tr>
           <tr>
               <td style="width: 870px"></td>
           </tr>
           <tr>
               <td style="width: 870px; height: 30px">
                   Forgot password? Click <a href="UserSearchPasswd.aspx">here</a>
               </td>
           </tr>
           <tr>
               <td style="width: 300px"></td>
           </tr>
           <tr>
               <td style="width: 300px; height: 30px">
                   <asp:Label ID="Label3" runat="server" Text="New customer? Click register :"></asp:Label>
               </td>
               <td style="width: 400px"><a href="Register.aspx"><asp:Button class="button button3" ID="Menu_Register" runat="server" Text="Register" Width="300px" CausesValidation="False" OnClick="Menu_Register_Click" /></a></td>
           </tr>
       </table>
   </fieldset>
</asp:Content>
