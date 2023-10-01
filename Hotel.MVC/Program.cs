using Hotel.MVC.Areas.AdminArea;
using Hotel.MVC.AutoMapper;
using Hotel.MVC.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Otel.DAL.Contents;
using Otel.Entity.Authentication;

namespace Hotel.MVC;

public class Program
{
    public static void Main(string[] args)
    {




        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<SqlDbContext>(
               options => options.UseSqlServer(builder.Configuration.GetConnectionString("MvcOtel")));



        #region Identity Configuration
        builder.Services.AddIdentity<AppUser, AppRole>(options =>
             {
                 //Password settings.
                 options.Password.RequireDigit = false;
                 options.Password.RequireUppercase = false;
                 options.Password.RequireLowercase = false;
                 options.Password.RequireNonAlphanumeric = false;
                 options.Password.RequiredLength = 3;
                 options.Password.RequiredUniqueChars = 1;
                 options.User.RequireUniqueEmail = true;

                 //SignIn settings.
                 options.SignIn.RequireConfirmedPhoneNumber = false;
                 options.SignIn.RequireConfirmedEmail = false;
                 options.SignIn.RequireConfirmedPhoneNumber = false;
                 options.SignIn.RequireConfirmedAccount = false;

                 //Lockout settings.
                 options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                 options.Lockout.MaxFailedAccessAttempts = 5;
                 options.Lockout.AllowedForNewUsers = true;

             }).AddEntityFrameworkStores<SqlDbContext>()
                 .AddDefaultTokenProviders();

        #endregion

        builder.Services.AddOtelServices();
        ///***Cookie***************************////

        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.Name = "MvcOtel";
            options.LoginPath = "/Login";
            options.LogoutPath = "/Logout";
            options.AccessDeniedPath = "/AccessDenied";

            options.Cookie.HttpOnly = true;
            options.SlidingExpiration = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        });

        builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
        {
            options.TokenLifespan = TimeSpan.FromMinutes(5);
        });

        ////*******AutoMapper*****************///

        builder.Services.AddAutoMapper(typeof(MvcOtel));

        var app = builder.Build();
        //
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        //Identity
        app.UseAuthentication();

        //Area controller

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );
        });


        #region Map Controller Route
        app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        #endregion

        app.Run();



    }





}