using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace T1708ESongResource.Middleware
{    
    public class CheckAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public CheckAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            bool isValid = false;
            if (context.Request.Headers.ContainsKey("Authorization"))
            {
                var rawToken = context.Request.Headers["Authorization"].ToString();
                rawToken = rawToken.Replace("Basic ", "");
                HttpClient client = new HttpClient();
                var responseResult = client.GetAsync("https://toauth2server.azurewebsites.net/api/authentication?accessToken=" + rawToken).Result;
                if (responseResult.StatusCode == HttpStatusCode.OK)
                {
                    isValid = true;
                }
            }
            if (isValid)
            {
                // Call the next delegate/middleware in the pipeline
                await _next(context);
            }
            else
            {
                context.Response.StatusCode = (int) HttpStatusCode.Forbidden;
                await context.Response.WriteAsync("Invalid token" + context.Request.Headers.ContainsKey("Authorization"));
            }


        }
        
    }
}

