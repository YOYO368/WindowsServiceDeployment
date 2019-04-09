<%@ Page Title="" Language="C#" MasterPageFile="~/ManagerPage.Master" AutoEventWireup="true" CodeBehind="ViewOrder.aspx.cs" Inherits="NuiLunchBoxProject.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset style="width: 100%;float:left;margin-top:50px">
        <asp:GridView ID="CartView" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333"
                GridLines="None" CssClass="table" Width="80%" AllowSorting="True" HorizontalAlign="Center">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="User_ID" HeaderText="Customer ID"></asp:BoundField>
                    <asp:BoundField DataField="Menu_Name" HeaderText="Menu Name"></asp:BoundField>
                    <asp:BoundField DataField="Menu_Count" HeaderText="Count"></asp:BoundField>
                    <asp:BoundField DataField="Menu_Time" HeaderText="Time"></asp:BoundField>
	            </Columns>
                <HeaderStyle HorizontalAlign="Center" Width="300px" />
                <RowStyle HorizontalAlign="Left" />
            </asp:GridView>
    </fieldset>
</asp:Content>
