using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace stable {
    public class Startup {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices (IServiceCollection services) {
            services.AddDbContext<ProjectContext> (options => {
                options.UseSqlite ("Filename=university.db");
            });
            services.AddMvc ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseMvc (routes => {
                routes.MapRoute (
                    name: "default",
                    template: "{controller=Hello}/{action=Index}/{id?}"
                );
            });

            // app.Run (async (context) => {
            //     await context.Response.WriteAsync ("Hello World!");
            // });
            app.UseStaticFiles ();

        }
    }
}