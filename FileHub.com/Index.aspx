<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="FileHub.com.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center">

    <p class="perspective">
	<asp:Button class="btn btn-2 btn-2a" runat="server" style="background-color:gray" id="btnSignUp" Text="SignUp" OnClick="btnSignUp_Click"/>
	</p>

	<p class="perspective">
	<asp:Button class="btn btn-2 btn-2a" runat="server" style="background-color:gray" id="btnLogin"  OnClick="btnLogin_Click" Text="Login"/>
	</p>   
        
    </div>
</asp:Content>
