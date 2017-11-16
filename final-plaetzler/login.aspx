<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Final_Plaetzler.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Plaetzler Multi-Day Kayak Reservation</h1>
        <h2>Login</h2>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="pnlLogin" Visible="false" runat="server">
				Please Login:<br/>
				Email Address: <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br/>
				Password: <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br/>
				<asp:Button runat="server" ID="btnLogin" OnClick="Login" Text="Login"></asp:Button> <br/>
				<asp:Label runat="server" ID="lblResults" BackColor="Red"></asp:Label>
			</asp:Panel>
			<asp:Panel ID="pnlDetails" Visible="false" runat="server">
				<div>
					You are logged in <asp:Label ID="lblUserFullName" runat="server"></asp:Label>. 
					You may now access your <a href="account.aspx">account dashboard</a>.
					<asp:Button ID="btnLogout" runat="server" Text="Log Out" OnClick="LogOut"></asp:Button>
				</div>
			</asp:Panel>
    </div>
    </form>
</body>
</html>
