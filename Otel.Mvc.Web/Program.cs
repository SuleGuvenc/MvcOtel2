using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Otel.DAL.Contents;
using System.Data;

namespace Otel.Mvc.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<SqlDbContext>(
               options => options.UseSqlServer(builder.Configuration.GetConnectionString("Otel")));



          ////  builder.Services.AddKOtelServis();

            // AutoMapper Servislerini ayaga kaldirir
            //builder.Services.AddAutoMapper(typeof(KatalogProfile));
        }
       
           
            // builder.Services.AddScoped<IBirimRepository,BirimRepository>();

            //builder.Services.AddScoped<IBirimManager, BirimManager>();
            //builder.Services.AddScoped<IKategoriManager, KategoriManager>();
           













        
           
        
    }
}