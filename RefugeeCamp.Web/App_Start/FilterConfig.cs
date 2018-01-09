using System.Web;
using System.Web.Mvc;
using RefugeeCamp.Web.Security;

namespace RefugeeCamp.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
           
        }
    }
}
