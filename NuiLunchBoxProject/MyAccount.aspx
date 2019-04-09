<%@ Page Title="" Language="C#" MasterPageFile="~/UserPage.Master" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="NuiLunchBoxProject.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset style="margin-top:70px; margin-left:200px">
        <br />
        <legend> Modify user account </legend>
        <br />
        <table style="width: 100%">
            <tr>
                <td style="width: 125px;height:30px">
                    <asp:Label ID="Label_UserID" runat="server" AssociatedControlID="txtUserID" Text="User ID : "></asp:Label>
                </td>
                <td style="width: 300px; height: 30px;">
                    <asp:TextBox ID="txtUserID" runat="server" Width="290px" style="margin-right: 4px" Enabled="False"></asp:TextBox>
                </td>
                <td style="height: 30px">
                    </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td style="width: 125px;height:30px">
                    <asp:Label ID="Label_Passwd" runat="server" AssociatedControlID="txtUserPasswd" Text="New Passwd :"></asp:Label>
                </td>
                <td style="width: 300px">
                    <asp:TextBox ID="txtUserPasswd" runat="server" TextMode="Password" Width="290px" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_UserPasswd" runat="server" ControlToValidate="txtUserPasswd" ErrorMessage="Please input Password" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr>
                <td></td>
            </tr>
            <tr>
                <td style="width: 125px;height:30px">
                    <asp:Label ID="Label_ConfirmPasswd" runat="server" AssociatedControlID="txtConfirmPasswd" Text="Confirm Passwd : "></asp:Label>
                </td>
                <td style="width: 300px">
                    <asp:TextBox ID="txtConfirmPasswd" runat="server" TextMode="Password" Width="290px" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_ConfirmPasswd" runat="server" ControlToValidate="txtConfirmPasswd" ErrorMessage="Please input password again" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidatorPasswd" runat="server" ControlToCompare="txtUserPasswd" ControlToValidate="txtConfirmPasswd" ErrorMessage="Incorrect password" Font-Size="Small" ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
             <tr>
                <td></td>
            </tr>
            <tr>
                <td style="width: 125px; height: 30px">
                    <asp:Label ID="Label1" runat="server" AssociatedControlID="txtUserName" Text="New Name : "></asp:Label>
                </td>
                <td style="width: 300px">
                    <asp:TextBox ID="txtUserName" runat="server" Width="290px" style="margin-right: 4px" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName" ErrorMessage="Please input User Name" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr>
                <td></td>
            </tr>
            <tr>
                <td style="width: 125px; height: 30px">
                    <asp:Label ID="Label_UserEmail" runat="server" AssociatedControlID="txtUserEmail" Text="New Email : "></asp:Label>
                </td>
                <td style="width: 300px">
                    <asp:TextBox ID="txtUserEmail" runat="server" TextMode="Email" Width="290px" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_UserEmail" runat="server" ControlToValidate="txtUserEmail" ErrorMessage="Please input User Email" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ControlToValidate="txtUserEmail" ErrorMessage="Input correct type of Email" Font-Size="Small" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td style="width: 125px; height: 30px">
                    <asp:Label ID="Label_UserMobile" runat="server" AssociatedControlID="txtUserMobile" Text="User Mobile : "></asp:Label>
                </td>
                <td style="width: 300px">
                    <asp:TextBox ID="txtUserMobile" runat="server" TextMode="Phone" Width="290px" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_UserMobile" runat="server" ControlToValidate="txtUserMobile" ErrorMessage="Please input User Mobile" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr>
                <td></td>
            </tr>
            <tr>
                <td style="height: 30px" class="w3-right-align" colspan="2">
                    <asp:Button type="button" class="w3-teal" ID="Button_Modify" runat="server" Text="Modify" OnClick="Button_Modify_Click" Height="40px" Width="200px" CausesValidation="False" />
                    <asp:Button type="button" class="w3-teal" ID="Button_Save" runat="server" Text="Save" OnClick="Button_Save_Click" Height="40px" Width="200px" Visible="False" CausesValidation="False" />
                </td>
                <td style="height: 30px">
                    <asp:Button type="reset" class="w3-teal" ID="Button_Reset" runat="server" Text="Reset" Height="40px" Width="200px" CausesValidation="False" OnClick="Button_Reset_Click"/>
                </td>
            </tr>
             <tr>
                <td></td>
            </tr>
            <tr>
                <td style="width: 125px">&nbsp;</td>
                <td style="width: 300px; text-align: right">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
