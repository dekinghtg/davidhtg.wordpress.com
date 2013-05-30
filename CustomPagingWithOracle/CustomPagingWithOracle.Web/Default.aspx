<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CustomPagingWithOracle.Web.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetEmployee" TypeName="CustomPagingWithOracle.Web.BusinessObject.EmployeeBusiness"
            EnablePaging="True" MaximumRowsParameterName="limit" StartRowIndexParameterName="start"
            SelectCountMethod="GetEmployeeCount">
            <SelectParameters>
                <asp:Parameter Name="start" Type="Int32" />
                <asp:Parameter Name="limit" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" CellPadding="4" DataSourceID="ObjectDataSource1"
            ForeColor="#333333" GridLines="None" PageSize="5" AutoGenerateColumns="False"
            OnPageIndexChanged="GridView1_PageIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="EmpNo" HeaderText="ID" SortExpression="EmpNo" />
                <asp:BoundField DataField="EName" HeaderText="Name" SortExpression="EName" />
                <asp:BoundField DataField="Job" HeaderText="Job" SortExpression="Job" />
                <asp:BoundField DataField="Mgr" HeaderText="Manager" SortExpression="Mgr" />
                <asp:BoundField DataField="HireDate" HeaderText="Hire Date" SortExpression="HireDate" />
                <asp:BoundField DataField="Sal" HeaderText="Salary" SortExpression="Sal" />
                <asp:BoundField DataField="Comm" HeaderText="Commission" SortExpression="Comm" />
                <asp:BoundField DataField="DeptNo" HeaderText="Department" SortExpression="DeptNo" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
