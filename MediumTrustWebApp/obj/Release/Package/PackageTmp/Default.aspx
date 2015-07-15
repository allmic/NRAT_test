<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MediumTrustWebApp.index" %>
<%@ Import Namespace="MediumTrustWebApp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div>
        Medium trust web app | <% Response.Write(DateTime.Now); %><br />
        <% Response.Write(Info.PrintInfoAboutDomainAndAssemblies()); %>
    </div>
</body>
</html>
