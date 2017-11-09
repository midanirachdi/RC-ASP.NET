<!DOCTYPE html>
<html>
<head>
    <title>Admin Form Sending Notifications</title>
 
    <script src="/Scripts/jquery-1.12.4.min.js" ></script>
    <script src="/Scripts/jquery.signalR-2.2.2.js"></script>
    <script src="/signalr/hubs"></script>
 
    <script type="text/javascript">
        $(function () {
            //first letter miniscule
            var proxy = $.connection.notificationHub;
            $("#button1").click(function () {
                proxy.server.sendNotifications($("#text1").val());
            });
            $.connection.hub.start();
        });
    </script>
 
</head>
<body>
<input id="text1" type="text" />
<input id="button1" type="button" value="Send" />
</body>
</html>