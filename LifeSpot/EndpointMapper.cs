using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.IO;
using System.Text;

namespace LifeSpot
{
    public static class EndpointMapper
    {
        /// <summary>
        ///  Маппинг CSS-файлов
        /// </summary>
        public static void MapCss(this IEndpointRouteBuilder builder)
        {
            var cssFiles = new[] { "index.css" };

            foreach (var fileName in cssFiles)
            {
                builder.MapGet($"/Static/CSS/{fileName}", async context =>
                {
                    var cssPath = Path.Combine(Directory.GetCurrentDirectory(), "Static", "CSS", fileName);
                    var css = await File.ReadAllTextAsync(cssPath);
                    await context.Response.WriteAsync(css);
                });
            }
        }
     
        /// <summary>
        ///  Маппинг Html-страниц
        /// </summary>
        public static void MapHtml(this IEndpointRouteBuilder builder)
        {

            builder.MapGet("/", async context =>
            {
                var viewPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "index.html");
                var html = await File.ReadAllTextAsync(viewPath);
                await context.Response.WriteAsync(html.ToString());
            });
        }

        /// <summary>
        ///  Маппинг Иконок
        /// </summary>
        public static void MapIcons(this IEndpointRouteBuilder builder)
        {
            var iconFiles = new[] { "magnifier.svg" };

            foreach (var fileName in iconFiles)
            {
                builder.MapGet($"/Static/Icons/{fileName}", async context =>
                {
                    var iconPath = Path.Combine(Directory.GetCurrentDirectory(), "Static", "Icons", fileName);
                    var icon = await File.ReadAllTextAsync(iconPath);
                    await context.Response.WriteAsync(icon);
                });
            }
        }
    }
}

