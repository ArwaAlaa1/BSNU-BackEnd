using BSNU.Core;
using BSNU.Core.Models;
using BSNU.Repository;
using BSNU.Repository.Data;
using BSNUDashboard.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BSNUDashboard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<BSNUDbContext>(options =>
          options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
          ServiceLifetime.Scoped);
            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            })

              .AddEntityFrameworkStores<BSNUDbContext>()
              .AddDefaultTokenProviders();
           
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAuthentication("Cookies")
       .AddCookie(options =>
       {
           options.LoginPath = "/Account/Signin";
           // options.AccessDeniedPath = "/Account/AccessDenied"; 
           options.ExpireTimeSpan = TimeSpan.FromMinutes(60);

       });
            builder.Services.ConfigureApplicationCookie(conf =>
            {
                conf.LoginPath = "/Account/Signin";
            });
            builder.Services.AddAuthorization();
            var app = builder.Build();
            HandlerPhotos.Initialize(app.Environment);
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
