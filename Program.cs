using Microsoft.Extensions.DependencyInjection.Extensions;
using YourProWebApp.Domain;
using YourProWebApp.Domain.Repositories.Interfaces;
using YourProWebApp.Domain.Repositories.TempImplementations;
using YourProWebApp.Service;

namespace YourProWebApp {
    public class Program {
        public static void Main(string[] args) {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            builder.Services.AddSingleton<IProfessionItemRepository, TempProfessionItemRepository>();
            builder.Services.AddSingleton<ITextFieldRepository, TempTextFieldRepository>();
            builder.Services.AddSingleton<IInterestRepository, TempInterestRepository>();

            // ?????
            builder.Services.AddDbContext<Context>();

            builder.Configuration.Bind("Project", new Config());

			var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

			app.UseRouting();
            app.UseSession();
			app.UseStaticFiles();

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");

            // �� �� �����, ��� � ���� (?)
            app.UseEndpoints(endpoints => { endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}"); });

            app.Run();
        }
    }
}