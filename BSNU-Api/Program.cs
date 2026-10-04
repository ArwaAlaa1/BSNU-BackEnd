using BSNU.Core;
using BSNU.Core.Helper;
using BSNU.Core.Models;
using BSNU.Core.Repository.Contract;
using BSNU.Repository;
using BSNU.Repository.Data;
using BSNU.Repository.Repositories;
using BSNU_Api.Helper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi;


namespace BSNU_Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            //   builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);
          //  builder.Services.AddScoped<NewsRepositries>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<INewsRepository, NewsRepository>();
            builder.Services.AddScoped<IFAQRepository, FAQRepository>();

            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
            builder.Services.AddDbContext<BSNUDbContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
           ServiceLifetime.Scoped);
            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<BSNUDbContext>()
              .AddDefaultTokenProviders();

        
            builder.Services.AddEndpointsApiExplorer(); // Required for Swagger

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Hand-made E-Commerce",
                    Version = "v1"
                });

                // Enable JWT Authorization
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and your token."
                });

                //c.AddSecurityRequirement(new OpenApiSecurityRequirement
                //        {
                //            {
                //                new OpenApiSecurityScheme
                //                {
                //                    Referencere = new OpenApiReference
                //                    {
                //                        Type = ReferenceType.SecurityScheme,
                //                        Id = "Bearer"
                //                    }
                //                },
                //                Array.Empty<string>()
                //            }
                //        });
            });



            var app = builder.Build();
            using var scope = app.Services.CreateScope();

            var services = scope.ServiceProvider;
            var loggerfactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                var dbcontext = services.GetRequiredService<BSNUDbContext>();
                //Ask Clr for creating object from dbcontext Explicitly

                await dbcontext.Database.MigrateAsync();

                var usermanager = services.GetRequiredService<UserManager<AppUser>>();
                var rolemanager = services.GetRequiredService<RoleManager<IdentityRole>>();
                await AppSeeding.SeedUsersAsync(usermanager, rolemanager,dbcontext);
                //await AppSeeding.SeedShippingCost(dbcontext);

            }
            catch (Exception ex)
            {
                var logger = loggerfactory.CreateLogger(typeof(Program));
                logger.LogError(ex, "An Error Occured During Apply Migration ");

            }
           

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hand-made E-Commerce v1"));
            }
            app.UseStaticFiles();        // Needed for Swagger CSS/JS
            app.UseRouting();            // Needed for routing
            app.UseSwagger();            // Swagger generator
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hand-made E-Commerce v1");
                c.RoutePrefix = string.Empty; // Swagger opens at root "/"
            });

            app.UseHttpsRedirection();
            app.UseCors("AllowAllOrigins");
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
