<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orders.aspx.cs" Inherits="Final_Plaetzler.orders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Plaetzler Multi-Day Kayak Reservation</h1>
        <h2>Order Detail</h2>
        	<asp:Panel ID="pnlBlank" Visible="false" runat="server">
				You must <asp:HyperLink NavigateUrl="~/login.aspx" runat="server">login</asp:HyperLink> to view order details.
			</asp:Panel>
            <asp:Label ID="lblOrderInfo" runat="server"></asp:Label>
			<asp:Panel ID="pnlValue" Visible="false" runat="server">
                <asp:Table runat="server" ID="tblDatesPrice">
                    <asp:TableRow>
                        <asp:TableCell Font-Bold="True">Order ID: </asp:TableCell>
                        <asp:TableCell><asp:Label runat="server" ID="lblOrderId"></asp:Label></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell Font-Bold="True">Customer: </asp:TableCell>
                        <asp:TableCell><asp:Label runat="server" ID="lblCustomer"></asp:Label></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="tbrStartDate">
                        <asp:TableCell Font-Bold="True">Rental Start Date: </asp:TableCell>
                        <asp:TableCell><asp:Label ID="lblSDate" runat="server"></asp:Label></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="tbrEndDate">
                        <asp:TableCell Font-Bold="True">Rental End Date: </asp:TableCell>
                        <asp:TableCell><asp:Label ID="lblEDate" runat="server"></asp:Label></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="tbrPrice">
                        <asp:TableCell Font-Bold="True">Rental Price: </asp:TableCell>
                        <asp:TableCell><asp:Label ID="lblTotal" runat="server"></asp:Label></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="tbrButtons">
                        <asp:TableCell><asp:Button runat="server" ID="btnAccount" OnClick="btnAccount_Click" Text="Account Details"></asp:Button></asp:TableCell>
                        <asp:TableCell><asp:Button runat="server" ID="btnCancelRes" OnClick="btnCancelRes_Click" Text="Cancel Reservation"></asp:Button></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>         
			</asp:Panel>
    </div>
    </form>
</body>
</html>
