using Microsoft.AspNetCore.Identity;
using Otel.BL.Abstract;
using Otel.BL.Concrete;
using Otel.DAL.Repository.Abstract;
using Otel.DAL.Repository.Concrete;

namespace Otel.Mvc.Web.Extensions
{
    public  static class AddOtelServis
    {
        public static IServiceCollection AddKatalogServisleri(this IServiceCollection services)
        {
           
        }
        public static string TurkceKarakterDuzelt(this string str, string v)
        {
            str = str.Replace('ş', 's');
            return str;
        }
    }
}
