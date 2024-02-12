using Microsoft.EntityFrameworkCore;
using Tasks.DAL.Data.EF;

namespace Tasks.Web
{
    class Program {
        static void Main(string[] args) {
            try {
                var builder = WebApplication.CreateBuilder(args);
                var connection = "Data Source = D:\\Documents\\CSharp\\Projects\\Tasks\\Tasks.DAL\\Tasks.db";

                // Add services to the container.
                builder.Services.AddControllersWithViews();
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(connection));

                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment()) {
                    app.UseDeveloperExceptionPage();
                }

                app.UseHttpsRedirection();
                app.UseDefaultFiles();
                app.UseStaticFiles();
                app.UseRouting();

                app.MapControllers();
                app.MapControllerRoute("default", "{controller=Home}/{action=StartPage}/{id?}");

                app.Run();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message); }
        }
    }
}
