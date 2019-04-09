<%@ Page Title="" Language="C#" MasterPageFile="~/UserPage.Master" AutoEventWireup="true" CodeBehind="UserRegister.aspx.cs" Inherits="NuiLunchBoxProject.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
     <fieldset style="margin-top:70px; margin-left:200px">
        <br />
        <legend> Register </legend>
        <br />
        <table style="width: 100%">
            <tr>
                <td style="width: 150px;height:30px">
                    <asp:Label ID="Label_UserID" runat="server" AssociatedControlID="txtUserID" Text="User ID : "></asp:Label>
                </td>
                <td style="width: 300px">
                    <asp:TextBox ID="txtUserID" runat="server" Width="280px" style="margin-right: 4px"></asp:TextBox>
                </td>
                <td style="width: 600px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_UserID" runat="server" ControlToValidate="txtUserID" ErrorMessage="Please input UserID" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 150px;height:30px">
                    <asp:Label ID="Label_Passwd" runat="server" AssociatedControlID="txtUserPasswd" Text="User Passwd :"></asp:Label>
                </td>
                <td style="width: 300px">
                    <asp:TextBox ID="txtUserPasswd" runat="server" TextMode="Password" Width="280px"></asp:TextBox>
                </td>
                <td style="width: 600px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_UserPasswd" runat="server" ControlToValidate="txtUserPasswd" ErrorMessage="Please input Password" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 150px;height:30px">
                    <asp:Label ID="Label_ConfirmPasswd" runat="server" AssociatedControlID="txtConfirmPasswd" Text="Confirm Passwd : "></asp:Label>
                </td>
                <td style="width: 300px">
                    <asp:TextBox ID="txtConfirmPasswd" runat="server" TextMode="Password" Width="280px"></asp:TextBox>
                </td>
                <td style="width: 600px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_ConfirmPasswd" runat="server" ControlToValidate="txtConfirmPasswd" ErrorMessage="Please input password again" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidatorPasswd" runat="server" ControlToCompare="txtUserPasswd" ControlToValidate="txtConfirmPasswd" ErrorMessage="Incorrect password" Font-Size="Small" ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 150px; height: 30px">
                    <asp:Label ID="Label_UserName" runat="server" AssociatedControlID="txtUserName" Text="User Name : "></asp:Label>
                </td>
                <td style="width: 300px">
                    <asp:TextBox ID="txtUserName" runat="server" Width="280px"></asp:TextBox>
                </td>
                <td style="width: 600px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_UserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="Please input User Name" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 150px; height: 30px">
                    <asp:Label ID="Label_UserEmail" runat="server" AssociatedControlID="txtUserEmail" Text="User Email : "></asp:Label>
                </td>
                <td style="width: 300px">
                    <asp:TextBox ID="txtUserEmail" runat="server" TextMode="Email" Width="280px"></asp:TextBox>
                </td>
                <td style="width: 600px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_UserEmail" runat="server" ControlToValidate="txtUserEmail" ErrorMessage="Please input User Email" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ControlToValidate="txtUserEmail" ErrorMessage="Input correct type of Email" Font-Size="Small" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 150px; height: 30px">
                    <asp:Label ID="Label_UserMobile" runat="server" AssociatedControlID="txtUserMobile" Text="User Mobile : "></asp:Label>
                </td>
                <td style="width: 300px">
                    <asp:TextBox ID="txtUserMobile" runat="server" TextMode="Phone" Width="280px"></asp:TextBox>
                </td>
                <td style="width: 600px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_UserMobile" runat="server" ControlToValidate="txtUserMobile" ErrorMessage="Please input User Mobile" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 150px">&nbsp;</td>
                <td style="width: 300px; text-align: right">
                    <asp:Button type="button" class="button button2" ID="Button_Register" runat="server" Text="Register" OnClick="Button_Register_Click" Height="40px" Width="200px" />
                </td>
                <td>
                    <asp:Button type="reset" class="button button4" ID="Button_Reset" runat="server" Text="Reset" Height="40px" Width="200px" OnClick="Button_Reset_Click"/>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
