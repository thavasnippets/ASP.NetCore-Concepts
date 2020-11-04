# ASP.NET Core Middlewares

ASP.NET Core introduced a new concept called Middleware. 
Middleware is similar to HttpHandlers and HttpModules where both needs to be configured and executed in each request.
We can configure middleware in the Configure method of the Startup class using IApplicationBuilder instance. 

[![N|Solid](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/index/_static/request-delegate-pipeline.png?view=aspnetcore-3.1)](https://nodesource.com/products/nsolid)

## The followings are some built-in middleware
|Middleware	|Description|
| --- | --- |
|Authentication|	Adds authentication support|
|CORS|	Configures Cross-Origin Resource Sharing.|
|Routing|	Adds routing capabilities for MVC or web form|
|Session|	Adds support for user session.|
|StaticFiles|	Adds support for serving static files and directory browsing.|
|Diagnostics|	Adds support for reporting and handling exceptions and errors.|

## Custom Middleware
The custom middleware component is like any other .NET class with Invoke() method. However, in order to execute next middleware in a sequence, it should have RequestDelegate type parameter in the constructor.

### Usecase:
if someone calls the API without action methods e.g. www.abc.com/ then we need to redirect to www.abc.com/api/Sample

####  1.Create a class with the parameterized (RequestDelegate) constructor 
####  2.Create Invoke method to do the Http Redirection operation
``` C#
public class UrlRedirectMiddleware
    {
        private readonly RequestDelegate next;
        public UrlRedirectMiddleware(RequestDelegate _next)
        {
            next = _next;
        }

        public async Task Invoke(HttpContext ctx)
        {
            if(ctx.Request.Path == "/")
            {
                ctx.Request.Path = "/api/Sample";
            }
            await next.Invoke(ctx);
        }
    }
```
####  3.Call the Middleware in the Configure method. This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

``` C#
      app.UseMiddleware<UrlRedirectMiddleware>();
```

