<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>Index</title>
    <script type="text/javascript" src="http://static.fusioncharts.com/code/latest/fusioncharts.js"></script>
</head>
<body>
    <div>
       
        <asp:Literal ID="literal_1"> <%= ViewBag.displayHTML %> </asp:Literal>
    </div>
</body>
</html>
