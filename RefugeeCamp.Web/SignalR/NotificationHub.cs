using Microsoft.AspNet.SignalR;

namespace RefugeeCamp.Web.SignalR
{
    public class NotificationHub : Hub
    {
        
        public void SendNotifications(string message)
        {
            Clients.All.receiveNotification(message);
            //Clients.User(userId).receiveNotification(message);
        }
        
    }
}