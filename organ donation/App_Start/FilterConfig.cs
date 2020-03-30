using organ_donation.Infra;
using System.Web;
using System.Web.Mvc;


namespace organ_donation
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
           // filters.Add(new MyExceptionFilter());
        }
    }
}
