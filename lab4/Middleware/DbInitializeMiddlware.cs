using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using lab3;

namespace lab4.Middleware
{
    public class DbInitializeMiddlware
    {
        private readonly RequestDelegate _next;
        public DbInitializeMiddlware(RequestDelegate next, IConfiguration configuration)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context, Petrol_StationContext petrol)
        {
            DbInitializer.Initialize(petrol);

            await _next.Invoke(context);
        }
    }
    public static class DbInitializerExtensions
    {
        public static IApplicationBuilder UseDbInitializerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DbInitializeMiddlware>();
        }
    }
}
