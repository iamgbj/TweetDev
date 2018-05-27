using IQVIATweets.ExceptionFilter;
using System.Web;
using System.Web.Mvc;

namespace IQVIATweets
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
