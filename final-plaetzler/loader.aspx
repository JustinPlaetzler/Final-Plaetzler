<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loader.aspx.cs" Inherits="Final_Plaetzler.loader" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Upload and Display of Electronics File</h2>
        <asp:Panel runat="server" ID="pnlUpload">
            <p>Upload the Electronic XML document for display. </p>
            <asp:FileUpload ID="uploadFile" runat="server"  /><br />
            <asp:Button runat="server" ID="btnUpload" OnClick="btnUpload_Click" Text="Upload and Display" />
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlDisplay" Visible="false">
            <asp:Table runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Date</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Price</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Number Available</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Number Remaining</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            
        </asp:Panel>
    </div>
    </form>
</body>
</html>
