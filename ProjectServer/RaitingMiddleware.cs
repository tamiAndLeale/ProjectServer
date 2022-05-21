using DL;
using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectServer
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RaitingMiddleware

    {
        CTContext _CTContext;
        private readonly RequestDelegate _next;
       // CTContext ctContext;
        public RaitingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, CTContext ctContext)
        {
            _CTContext = ctContext;
            Rating r = new Rating
            {
                Host = httpContext.Request.Host.ToString(),
                Method = httpContext.Request.Method,
                Path = httpContext.Request.Path,
                RecordDate = DateTime.Now,
                // Referer= httpContext.Request.re
                //UserAgent = httpContext.Request[User-Agent]


            };
            await _CTContext.Ratings.AddAsync(r);
            await _CTContext.SaveChangesAsync();
            await _next(httpContext);
           
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RaitingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRaitingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RaitingMiddleware>();
        }
    }
}
