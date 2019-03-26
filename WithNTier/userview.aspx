<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userview.aspx.cs" Inherits="WithNTier.userview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        	addressid<asp:TextBox ID="txtAddressId" runat="server"></asp:TextBox>
        </div>
    	<p>
			firstname<asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
		</p>
		<p>
			lastname<asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
		</p>
		<p>
			email<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
		</p>
		<p>
			mobno<asp:TextBox ID="txtMobNo" runat="server"></asp:TextBox>
		</p>
		<p>
			address<asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
		</p>
		<asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="insert" />
		<asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="update" />
		<asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" style="height: 26px" Text="delete" />
		<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="search" Width="88px" />
		<p>
			<asp:Button ID="txtShowTable" runat="server" Text="Show Table" />
		</p>
		<asp:Label ID="lblShow" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
