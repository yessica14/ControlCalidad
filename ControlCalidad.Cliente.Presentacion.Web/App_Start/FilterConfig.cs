using System.Web;
using System.Web.Mvc;

namespace ControlCalidad.Cliente.Presentacion.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
