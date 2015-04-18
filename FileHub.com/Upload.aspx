<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="FileHub.com.Upload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .upload {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="text-align:right">
     <asp:Label style="font-family:'Nova Square';font-size:larger" ID="lblGreet" runat="server" Text="Label" ForeColor="#CCCCCC"></asp:Label>
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" /><br /><br />
     <asp:Label ID="lblSpaceAllocated" runat="server" Text="Label" ForeColor="#CCCCCC" Font-Names="Nova Square"></asp:Label><br />
     <asp:Label ID="lblSpaceUsed" runat="server" Text="Label" ForeColor="#CCCCCC" Font-Names="Nova Square"></asp:Label><br />
     
   </div>
    <div>
        <table style="width:100%">
            <tr>
                <td style="width:20%;vertical-align:top">
                    <p class="perspective">
                    <asp:Button ID="btnSearch" CssClass="btn btn-7 btn-8d"  Width="200px" runat="server" Text="Search  " OnClick="btnSearch_Click" CausesValidation="False"/>
                    </p><br />
                    <p class="perspective">
                    <asp:Button ID="btnUpload" CssClass="btn btn-7 btn-8d" Width="200px" runat="server" Text="Upload" OnClick="btnUpload_Click" CausesValidation="False" />
                    </p><br />
                    <p class="perspective">
                    <asp:Button ID="btnFiles" CssClass="btn btn-7 btn-8d" Width="200px" runat="server" Text="Files" OnClick="btnFiles_Click" CausesValidation="False" />
                    </p>
                </td>
                <td style="vertical-align:top">
                    
                        <div style="text-align:center">
                        <br />
                        <br />
                        <asp:TextBox ID="txtFileName" CssClass="inputs" runat="server" placeholder="FileName" Font-Size="Large" ForeColor="#666699" Height="40px" Width="328px" AutoPostBack="True" OnTextChanged="txtFileName_TextChanged"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" Font-Names="nova square" ForeColor="#CC3300" ControlToValidate="txtFileName">FileName is  Required</asp:RequiredFieldValidator>
                            <br />
                        <asp:TextBox ID="txtDesc" CssClass="inputs" runat="server" placeholder="Description" Font-Size="Large" ForeColor="#666699" Height="40px" Width="328px" AutoPostBack="True" OnTextChanged="txtDesc_TextChanged"></asp:TextBox><br /><br />
                        <asp:FileUpload ID="FileUp" placeholder="Choose File" runat="server"   BackColor="White" ForeColor="Black" style="margin-left: 0px" Width="330px" AllowMultiple="True" Height="42px" OnLoad="FileUp_Load"/><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" Font-Names="nova square" ForeColor="#CC3300" ControlToValidate="FileUp">Please Select the File</asp:RequiredFieldValidator>
                        
                        <table style="width:100%">
                            <tr>
                                <td style="vertical-align:top">
                                    <asp:Label ID="lblAccess" runat="server" Text="Access Level" Font-Names="Nova Square" Font-Size="Large" ForeColor="White"></asp:Label>
                                </td>
                                <td style="text-align:left">
                                    <asp:RadioButtonList ID="rdoAccess" runat="server" Font-Names="nova Square" ForeColor="White">
                                        <asp:ListItem>Private</asp:ListItem>
                                        <asp:ListItem Selected="True">Public</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblMessage" runat="server" Text="Label" Font-Names="Nova Square" Font-Size="Larger" ForeColor="#339933" Visible="False"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        </div>
                   
                    
                </td>
                <td style="vertical-align:top">
                    <br />
                    <asp:Button ID="btnUploadFile" CssClass="btn btn-4 btn-4a icon-arrow-right" runat="server" Text="Upload" OnClick="btnUploadFile_Click"/><br />
                    <asp:Button ID="btnCancel" CssClass="btn btn-4 btn-4a icon-arrow-right" runat="server" Text="Cancel" OnClick="btnCancel_Click"/>
                </td>
             </tr>
        </table>

    </div>
</asp:Content>
