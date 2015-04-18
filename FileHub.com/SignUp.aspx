<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="FileHub.com.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <asp:TextBox ID="txtUserName" CssClass="inputs" runat="server" placeholder="Username" Font-Size="Large" ForeColor="#666699" Height="40px" Width="328px"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName" ErrorMessage="UserName is Required" Font-Names="Nova Square" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        <asp:Label ID="lblUserNameError" runat="server" Font-Names="Nova Square" ForeColor="#FF3300" Text="UserName Already Exists" Visible="False"></asp:Label>
        <br />
        <asp:TextBox ID="txtPassword" CssClass="inputs" runat="server" placeholder="Password" Font-Size="Large" ForeColor="#666699" Height="40px" Width="328px"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is Required" Font-Names="Nova Square" ForeColor="#FF3300"></asp:RequiredFieldValidator><br />
        <asp:TextBox ID="txtEmail" CssClass="inputs" runat="server" placeholder="Email" Font-Size="Large" ForeColor="#666699" Height="40px" Width="328px"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is Required" Font-Names="Nova Square" ForeColor="#FF3300"></asp:RequiredFieldValidator><br />
        <asp:RadioButtonList ID="rdoListAccType" runat="server" Font-Names="Nova Square" ForeColor="White" Width="292px" BorderColor="#CCCCCC" BorderStyle="Dashed" BorderWidth="3px" align="Center" OnSelectedIndexChanged="rdoListAccType_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem Selected="True">100 Mb Free Subscription</asp:ListItem>
            <asp:ListItem>500 Mb 1.99 $/Per Mon</asp:ListItem>
            <asp:ListItem>1 GB 2.99$ Per/Mon </asp:ListItem>
        </asp:RadioButtonList>
        
        <asp:Panel ID="pnlPayment" runat="server" Visible="False">
            <br />
            <asp:TextBox ID="txtCardNo" CssClass="inputs" runat="server" placeholder="Card No" Font-Size="Large" ForeColor="#666699" Height="40px" Width="328px"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCardNo" ErrorMessage="CardNo is Required" Font-Names="Nova Square" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtExpDate" CssClass="inputs" runat="server" placeholder="Exp Date" Font-Size="Large" ForeColor="#666699" Height="40px" Width="328px"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtExpDate" ErrorMessage="Expiry Date is Required" Font-Names="Nova Square" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtCardName" CssClass="inputs" runat="server" placeholder="Name on Card" Font-Size="Large" ForeColor="#666699" Height="40px" Width="328px"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCardName" ErrorMessage="Name on Card is Required" Font-Names="Nova Square" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            <br />
        </asp:Panel>
        <br />
        </ContentTemplate>
            <Triggers>
                
            </Triggers>
        </asp:UpdatePanel>
        <p class="perspective">
	        <asp:Button class="btn btn-2 btn-2a" runat="server" style="background-color:gray" id="btnRegister" Text="Register" OnClick="btnRegister_Click"/>
	    </p>
        <p class="perspective">
	        <asp:Button class="btn btn-2 btn-2a" runat="server" style="background-color:gray" id="btnCancel" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="False"/>
	    </p>
	
    </div>
</asp:Content>
