using System.Web;
using System.Web.Mvc;

namespace arkitektum.kommit.noark.tjeneste
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}