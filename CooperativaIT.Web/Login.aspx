<%@ Page Language="C#" AutoEventWireup="true" Inherits="LoginPage" EnableViewState="false" CodeBehind="Login.aspx.cs" %>
<%@ Register Assembly="DevExpress.ExpressApp.Web.v14.2, Version=14.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" 
    Namespace="DevExpress.ExpressApp.Web.Templates.ActionContainers" TagPrefix="cc2" %>
<%@ Register Assembly="DevExpress.ExpressApp.Web.v14.2, Version=14.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" 
    Namespace="DevExpress.ExpressApp.Web.Templates.Controls" TagPrefix="tc" %>
<%@ Register Assembly="DevExpress.ExpressApp.Web.v14.2, Version=14.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" 
    Namespace="DevExpress.ExpressApp.Web.Controls" TagPrefix="cc4" %>
<%@ Register Assembly="DevExpress.ExpressApp.Web.v14.2, Version=14.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" 
    Namespace="DevExpress.ExpressApp.Web.Templates" TagPrefix="cc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Logon</title>
    <style type="text/css">
        #form1
        {
            height: 18px;
        }
    </style>
</head>
<body class="Dialog">
   <center>
    <br /><br />
    <table>
        <tr><td><center><img src="Images/logo1.png" /></center><br /></td></tr>
        <tr>
        <td bgcolor="#d3e4f6">
            <div id="PageContent" class="PageContent DialogPageContent">
                <form id="form1" runat="server">
                <cc4:ASPxProgressControl ID="ProgressControl" runat="server" />
                <div id="Content" runat="server" />
                </form>
         </div>
        </td>
        </tr>
    </table>
    </center>
</body>
</html>
