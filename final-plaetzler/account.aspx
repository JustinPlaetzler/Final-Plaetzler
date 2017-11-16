<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="Final_Plaetzler.account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Plaetzler Multi-Day Kayak Reservation</h1>
        <h2>Account Detail</h2>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="pnlLoginButton" Visible="false" runat="server">
            <asp:Button runat="server" ID="btnOpenLogin" OnClick="btnOpenLogin_Click" Text="Login"></asp:Button>
        </asp:Panel>
        <asp:Panel ID="pnlLogoutButton" Visible="false" runat="server">
            <asp:Label runat="server" ID="lblConfirmLogin" ForeColor="Green"></asp:Label><br />
            <asp:Label runat="server" ID="lblWelcome"></asp:Label><br />
            <asp:Button runat="server" ID="btnLogout" OnClick="btnLogout_Click" Text="Logout"></asp:Button> <br/>
        </asp:Panel>
        <asp:Panel ID="pnlLogin" Visible="false" runat="server">
            Please Login:<br/>
			Email Address: <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br/>
			Password: <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br/>
			<asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_Click" Text="Login"></asp:Button> <br/>
			<asp:Label runat="server" ID="lblLoginError" ForeColor="DarkRed"></asp:Label><br />
            <asp:HyperLink NavigateUrl="~/create_account.aspx" runat="server">Don't have an account? Create one here.</asp:HyperLink>
        </asp:Panel>
        <asp:Panel ID="pnlBlank" Visible="false" runat="server">
				No ID Provided.
			</asp:Panel>
            <asp:Label ID="lblOrderInfo" runat="server"></asp:Label>
			<asp:Panel ID="pnlValue" Visible="false" runat="server">
				    <asp:Table runat="server" ID="tblOrdersList">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell>Order ID</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Start Date</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Amount</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Detail</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
			</asp:Panel>
    </div>
    </form>
</body>
</html>
