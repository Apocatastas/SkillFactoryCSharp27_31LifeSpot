using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LifeSpot
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
                app.UseRouting();
                app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapCss();
                        endpoints.MapHtml();
                        endpoints.MapImg();
                        endpoints.MapIcons();
                        endpoints.MapJs();
                    });
        }
    }
}