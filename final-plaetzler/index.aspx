<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Final_Plaetzler.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Plaetzler Multi-Day Kayak Reservation</h1>
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
        
        <asp:Panel ID="pnlReservation" Visible="true" runat="server">
            <asp:Table runat="server">
                <asp:TableRow>
                    <asp:TableCell>
			            Reservation Start Date: <asp:Calendar ID="calStartDate" runat="server" SelectionMode="Day" OnDayRender="cal_DayRender"></asp:Calendar><br />
                    </asp:TableCell>
                    <asp:TableCell>
                        Reservation End Date: <asp:Calendar ID="calEndDate" runat="server" SelectionMode="Day" OnDayRender="cal_DayRender"></asp:Calendar><br/>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
			Number of kayaks:&nbsp; <br />
            <asp:DropDownList ID="drpNumberKayaks" runat="server">
                <asp:ListItem Value="1">1</asp:ListItem>
                <asp:ListItem Value="2">2</asp:ListItem>
                <asp:ListItem Value="3">3</asp:ListItem>
                <asp:ListItem Value="4">4</asp:ListItem>
                <asp:ListItem Value="5">5</asp:ListItem>
			</asp:DropDownList>
            <p>
                <asp:Button runat="server" ID="btnSearch" OnClick="btnSearch_Click" Text="Search"></asp:Button><br />
                <asp:Label ID="lblUnavailable" runat="server" ForeColor="DarkRed"></asp:Label>
            </p>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlConfirm" Visible="false">
            <p>
                <asp:Label ID="lblConfirm" runat="server"></asp:Label>
            </p>
            <p>
                
                <asp:Button runat="server" ID="btnReserve" OnClick="btnReserve_Click" Text="Reserve"></asp:Button><br />
                <asp:Label ID="lblStatus" runat="server" ForeColor="DarkRed"></asp:Label>
            </p>
		</asp:Panel>
	</div>
    </form>
</body>
</html>
