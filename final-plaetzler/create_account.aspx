<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="create_account.aspx.cs" Inherits="Final_Plaetzler.create_account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Plaetzler Multi-Day Kayak Reservation</h1>
        <h2>Create Account</h2>
    <form id="form1" runat="server">
    <div>
        <asp:Panel runat="server" Visible="true" ID="pnlForm">
    <table>
            <tr>
                <td>First Name</td>
                <td><asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="validateFirstName" ControlToValidate="txtFirstName" ErrorMessage="First Name is required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Last Name</td>
                <td><asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="validateLastName" ControlToValidate="txtLastName" ErrorMessage="Last Name is required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Address</td>
                <td><asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="validateAddress" ControlToValidate="txtAddress" ErrorMessage="Address is required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>City</td>
                <td><asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="validateCity" ControlToValidate="txtCity" ErrorMessage="City is required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>State</td>
                <td><asp:DropDownList ID="drpState" runat="server">
	                    <asp:ListItem Value="AL">Alabama</asp:ListItem>
	                    <asp:ListItem Value="AK">Alaska</asp:ListItem>
	                    <asp:ListItem Value="AZ">Arizona</asp:ListItem>
	                    <asp:ListItem Value="AR">Arkansas</asp:ListItem>
	                    <asp:ListItem Value="CA">California</asp:ListItem>
	                    <asp:ListItem Value="CO">Colorado</asp:ListItem>
	                    <asp:ListItem Value="CT">Connecticut</asp:ListItem>
	                    <asp:ListItem Value="DC">District of Columbia</asp:ListItem>
	                    <asp:ListItem Value="DE">Delaware</asp:ListItem>
	                    <asp:ListItem Value="FL">Florida</asp:ListItem>
	                    <asp:ListItem Value="GA">Georgia</asp:ListItem>
	                    <asp:ListItem Value="HI">Hawaii</asp:ListItem>
	                    <asp:ListItem Value="ID">Idaho</asp:ListItem>
	                    <asp:ListItem Value="IL">Illinois</asp:ListItem>
	                    <asp:ListItem Value="IN">Indiana</asp:ListItem>
	                    <asp:ListItem Value="IA">Iowa</asp:ListItem>
	                    <asp:ListItem Value="KS">Kansas</asp:ListItem>
	                    <asp:ListItem Value="KY">Kentucky</asp:ListItem>
	                    <asp:ListItem Value="LA">Louisiana</asp:ListItem>
	                    <asp:ListItem Value="ME">Maine</asp:ListItem>
	                    <asp:ListItem Value="MD">Maryland</asp:ListItem>
	                    <asp:ListItem Value="MA">Massachusetts</asp:ListItem>
	                    <asp:ListItem Value="MI">Michigan</asp:ListItem>
	                    <asp:ListItem Value="MN">Minnesota</asp:ListItem>
	                    <asp:ListItem Value="MS">Mississippi</asp:ListItem>
	                    <asp:ListItem Value="MO">Missouri</asp:ListItem>
	                    <asp:ListItem Value="MT">Montana</asp:ListItem>
	                    <asp:ListItem Value="NE">Nebraska</asp:ListItem>
	                    <asp:ListItem Value="NV">Nevada</asp:ListItem>
	                    <asp:ListItem Value="NH">New Hampshire</asp:ListItem>
	                    <asp:ListItem Value="NJ">New Jersey</asp:ListItem>
	                    <asp:ListItem Value="NM">New Mexico</asp:ListItem>
	                    <asp:ListItem Value="NY">New York</asp:ListItem>
	                    <asp:ListItem Value="NC">North Carolina</asp:ListItem>
	                    <asp:ListItem Value="ND">North Dakota</asp:ListItem>
	                    <asp:ListItem Value="OH">Ohio</asp:ListItem>
	                    <asp:ListItem Value="OK">Oklahoma</asp:ListItem>
	                    <asp:ListItem Value="OR">Oregon</asp:ListItem>
	                    <asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
	                    <asp:ListItem Value="RI">Rhode Island</asp:ListItem>
	                    <asp:ListItem Value="SC">South Carolina</asp:ListItem>
	                    <asp:ListItem Value="SD">South Dakota</asp:ListItem>
	                    <asp:ListItem Value="TN">Tennessee</asp:ListItem>
	                    <asp:ListItem Value="TX">Texas</asp:ListItem>
	                    <asp:ListItem Value="UT">Utah</asp:ListItem>
	                    <asp:ListItem Value="VT">Vermont</asp:ListItem>
	                    <asp:ListItem Value="VA">Virginia</asp:ListItem>
	                    <asp:ListItem Value="WA">Washington</asp:ListItem>
	                    <asp:ListItem Value="WV">West Virginia</asp:ListItem>
	                    <asp:ListItem Value="WI">Wisconsin</asp:ListItem>
	                    <asp:ListItem Value="WY">Wyoming</asp:ListItem>
                    </asp:DropDownList></td>                
            </tr>
            <tr>
                <td>Zip Code</td>
                <td><asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="reqZip" ControlToValidate="txtZip" ErrorMessage="Zip is required"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regexZip" ControlToValidate="txtZip" ValidationExpression="\d{5}" EnableClientScript="False" ErrorMessage="Zip code should be 5 digits." runat="server"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>Email</td>
                <td><asp:TextBox ID="txtEmail" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="reqEmail" ControlToValidate="txtEmail" ErrorMessage="Email is required"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regexEmail" ControlToValidate="txtEmail" ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$" EnableClientScript="true" ErrorMessage="Email not in the correct format." runat="server" SetFocusOnError="true"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>Password</td>
                <td><asp:TextBox ID="txtPassword" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="reqPassword" ControlToValidate="txtPassword" ErrorMessage="Password is required"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <asp:Button runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" Text="Create Account" />
      </asp:Panel>
       <asp:Panel runat="server" ID="pnlThankYou" Visible="false">
           <asp:Label runat="server" ID="lblStatus"></asp:Label>
           <asp:Button ID="btnView" runat="server" Text="View Account" OnClick="btnView_Click"></asp:Button>
           <asp:Button ID="btnRes" runat="server" Text="Make Reservation" OnClick="btnRes_Click"></asp:Button>
       </asp:Panel>
    
    </div>
    </form>
</body>
</html>
