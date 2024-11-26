using System.Web;
using System.Web.Mvc;

namespace ExamenMVC_SistemaGestiónEventos_MartinSanchez
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
