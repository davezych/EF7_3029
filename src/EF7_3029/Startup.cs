using EF7_3029.Data;
using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Data.Entity;

namespace EF7_3029
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Server=(localdb)\mssqllocaldb;Database=EF7_3029.AspNet5;Trusted_Connection=True;";

            services.AddEntityFramework()
                   .AddSqlServer()
                   .AddDbContext<MyContext>(
                       options => options.UseSqlServer(connection));

            services.AddMvc();

            services.AddScoped<MyContext>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}");
            });
        }
    }
}
