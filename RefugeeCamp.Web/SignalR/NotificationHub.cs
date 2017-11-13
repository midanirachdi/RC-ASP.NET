using Microsoft.AspNet.SignalR;

namespace RefugeeCamp.Web.SignalR
{
    public class NotificationHub : Hub
    {
        //public void Hello()
        //{
        //    Clients.All.hello();
        //}
        public void SendNotifications(string message)
        {
            Clients.All.receiveNotification(message);
            //Clients.User(userId).receiveNotification(message);
        }
        public string Activate()
        {
            return "Monitor Activated";
        }
    }
}