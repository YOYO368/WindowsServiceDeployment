<%@ Page Title="" Language="C#" MasterPageFile="~/UserPage.Master" AutoEventWireup="true" CodeBehind="WebForm14.aspx.cs" Inherits="NuiLunchBoxProject.WebForm14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table width=100%>
        <tr>
            <td style="width:35%">
                <table style="width: 100%; float:left; margin-left:100px; height: 400px;">
                    <tr>
                        <td class="auto-style2" style="text-align: left"><asp:Label ID="Label3" runat="server" EnableViewState="True" Text=" " Width="300px" Font-Size="30px" FontColor="red"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="height:20px"></td>
                    </tr>
                    <tr>
                        <td><asp:Image ID="Image1" runat="server" Height="350px" Width="350px" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 65%">
                <table style="width:100%; float:left; height: 400px; margin-left:30px">
                    <tr>
                        <td style="height:30px; width: 275px;">
                            <asp:Label ID="Label_Groupno" runat="server" Text="Label" Visible="False"></asp:Label>
                         </td>
                    </tr>
                    <tr>
                        <td style="height:20px; width: 275px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 275px; height: 20px">
                            <asp:Label ID="Label_Name" runat="server" AssociatedControlID="txtMenuName" EnableViewState="False" Text="Menu Name : " Width="100px"></asp:Label>
                            <asp:TextBox ID="txtMenuName" runat="server" Height="16px" Width="160px" Enabled="False"></asp:TextBox>
                        </td>
                        <td rowspan="6" class="w3-left-align">
                        <br />
                            <br />
                        &nbsp;&nbsp;<asp:Button class="Button_style" ID="btnGoCart" runat="server" Height="45px" Text="Go To Cart" Width="130px" OnClick="btnGoCart_Click" margin-left="30px" />
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 275px; height: 20px; text-align: left;" class="w3-left-align">
                        <asp:Label ID="Label1" runat="server" AssociatedControlID="txtMenuPrice" EnableViewState="False" Text="Menu Price : " Width="100px"></asp:Label>
                            &nbsp;<asp:TextBox ID="txtMenuPrice" runat="server" Height="16px" Width="125px" Enabled="False"></asp:TextBox>
                            <asp:Label ID="Label4" runat="server" AssociatedControlID="txtMenuPrice" Text="NZ $"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 275px; height: 20px; text-align: left;" class="auto-style2">
                            <asp:Label ID="Label5" runat="server" AssociatedControlID="txtCount" EnableViewState="False" Text="Menu Count : " Width="110px"></asp:Label>
                            <asp:TextBox ID="txtCount" runat="server" Height="20px" Width="41px">1</asp:TextBox>
                            <asp:Button ID="btnIncrease" runat="server" CausesValidation="False" OnClick="btnIncrease_Click" Text="+" Width="55px" />
                            <asp:Button ID="btnDecrease" runat="server" CausesValidation="False" OnClick="btnDecrease_Click" Text="-" Width="55px" CssClass="col-xs-offset-0" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 275px; height: 20px;">
                        <asp:Label ID="Label2" runat="server" AssociatedControlID="txtMenuDescription" EnableViewState="False" Text="Menu Description : "></asp:Label>
                        </td>
                     </tr>
                     <tr>
                        <td rowspan="2" style="width: 275px">
                        <asp:TextBox ID="txtMenuDescription" runat="server" Height="252px" Width="270px" Rows="20" TextMode="MultiLine" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
