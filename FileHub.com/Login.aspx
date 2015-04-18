<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FileHub.com.Login1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/component.css" />
</head>
<body bgcolor="Black">

     <% //////////////////////////////FacebOok Login////////////////////////////////%>
     <script>
         window.fbAsyncInit = function () {
             FB.init({
                 appId: '281227165374420', // App ID
                 status: true, // check login status
                 cookie: true, // enable cookies to allow the server to access the session
                 xfbml: true  // parse XFBML
             });

             // Additional initialization code here
             FB.Event.subscribe('auth.authResponseChange', function (response) {
                 if (response.status === 'connected') {
                     // the user is logged in and has authenticated your
                     // app, and response.authResponse supplies
                     // the user's ID, a valid access token, a signed
                     // request, and the time the access token 
                     // and signed request each expire
                     var uid = response.authResponse.userID;
                     var accessToken = response.authResponse.accessToken;

                     // TODO: Handle the access token
                     // Do a post to the server to finish the logon
                     // This is a form post since we don't want to use AJAX
                     var form = document.createElement("form");
                     form.setAttribute("method", 'post');
                     form.setAttribute("action", 'FacebookLogin.ashx');

                     var field = document.createElement("input");
                     field.setAttribute("type", "hidden");
                     field.setAttribute("name", 'accessToken');
                     field.setAttribute("value", accessToken);
                     form.appendChild(field);

                     document.body.appendChild(form);
                     form.submit();

                 } else if (response.status === 'not_authorized') {
                     // the user is logged in to Facebook, 
                     // but has not authenticated your app
                 } else {
                     // the user isn't logged in to Facebook.
                 }
             });

         };

         // Load the SDK Asynchronously
         (function (d) {
             var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
             if (d.getElementById(id)) { return; }
             js = d.createElement('script'); js.id = id; js.async = true;
             js.src = "//connect.facebook.net/en_US/all.js";
             ref.parentNode.insertBefore(js, ref);
         }(document));

    </script>

    <% //////////////////////////////Facebook Login////////////////////////////////%>

    <form id="form1" runat="server">
        
    <div style="text-align:center">
        <asp:Image ID="ImgLogo" ImageUrl="~/Capture.PNG" runat="server" />
    </div>

    <div style="text-align:center">
    <asp:TextBox ID="txtUserName" CssClass="inputs" runat="server" placeholder="Username" Font-Size="Large" ForeColor="#666699" Height="40px" Width="328px"></asp:TextBox><br />
        <asp:Label ID="lblLoginError" runat="server" Font-Names="nova Square" ForeColor="#FF3300" Text="Invalid UserName or Password" Visible="False"></asp:Label>
        <br />
    <asp:TextBox ID="txtPassword" CssClass="inputs" runat="server" placeholder="Password" Font-Size="Large" ForeColor="#666699" Height="40px" Width="328px"></asp:TextBox>
    <br /><br />
   
        <p class="perspective">
	        <asp:Button class="btn btn-2 btn-2a" runat="server" style="background-color:gray" id="btnLogin" Text="Login" OnClick="btnLogin_Click"/>
	    </p>
	
        <p class="perspective">
            <asp:Button class="btn btn-2 btn-2a" runat="server" style="background-color:gray" id="btnCancel" Text="Cancel" OnClick="btnCancel_Click"/>
        </p> 
          
    </div>
     <div style="text-align:center">   
        <div class="fb-login-button" data-max-rows="10" data-size="xlarge" data-show-faces="false" data-auto-logout-link="false"></div>
     </div>
    </form>
</body>
</html>
