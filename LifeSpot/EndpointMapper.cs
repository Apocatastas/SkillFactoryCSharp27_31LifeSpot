﻿using Microsoft.AspNetCore.Builder;
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
            string footerHtml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Views", "Shared", "footer.html"));
            string sideBarHtml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Views", "Shared", "sidebar.html"));
            string sliderHtml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Views", "Shared", "slider.html"));

            builder.MapGet("/", async context =>
            {
                var viewPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "index.html");
                var viewText = await File.ReadAllTextAsync(viewPath);
                var html = new StringBuilder(await File.ReadAllTextAsync(viewPath))
                    .Replace("<!--SIDEBAR-->", sideBarHtml)
                    .Replace("<!--FOOTER-->", footerHtml);
                await context.Response.WriteAsync(html.ToString());
            });

            builder.MapGet("/testing", async context =>
            {
                var viewPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "testing.html");
                var html = new StringBuilder(await File.ReadAllTextAsync(viewPath))
                    .Replace("<!--SIDEBAR-->", sideBarHtml)
                    .Replace("<!--FOOTER-->", footerHtml);
                await context.Response.WriteAsync(html.ToString());
            });

            builder.MapGet("/about", async context =>
            {
                var viewPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "about.html");
                var html = new StringBuilder(await File.ReadAllTextAsync(viewPath))
                    .Replace("<!--SLIDER-->", sliderHtml)
                    .Replace("<!--SIDEBAR-->", sideBarHtml)
                    .Replace("<!--FOOTER-->", footerHtml);
                await context.Response.WriteAsync(html.ToString());
            });
        }
        
        /// <summary>
        ///  Маппинг JS
        /// </summary>
        public static void MapJs(this IEndpointRouteBuilder builder)
        {
            var jsFiles = new[] { "index.js", "testing.js", "filter.js", "about.js"};

            foreach (var fileName in jsFiles)
            {
                builder.MapGet($"/Static/JS/{fileName}", async context =>
                {
                    var jsPath = Path.Combine(Directory.GetCurrentDirectory(), "Static", "JS", fileName);
                    var js = await File.ReadAllTextAsync(jsPath);
                    await context.Response.WriteAsync(js);
                });
            }
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

        /// <summary>
        ///  Маппинг Картинок
        /// </summary>
        public static void MapImg(this IEndpointRouteBuilder builder)
        {
            var imgFiles = new[] { "all.jpg", "ann.jpg", "syl.jpg" };

            foreach (var fileName in imgFiles)
            {
                builder.MapGet($"/Static/Img/{fileName}", async context =>
                {
                    var imgPath = Path.Combine(Directory.GetCurrentDirectory(), "Static","Img", fileName);
                    var img = await File.ReadAllBytesAsync(imgPath);
                    await context.Response.Body.WriteAsync(img);
                });
            }
        }
    }
}

