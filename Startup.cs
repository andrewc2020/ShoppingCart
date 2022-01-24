namespace HelloRest
{

    using Microsoft.AspNetCore.Builder;
    using Nancy.Owin;
    using Microsoft.AspNetCore.Owin;
    using Microsoft.AspNetCore.Server.Kestrel.Core;

    public static class Startup
    {


        public static WebApplication InitialiseApp(String[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);

            var app = builder.Build();
            Configure(app);
            return app;


        }

        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            //builder.Services.AddHttpsRedirection();
            builder.Services.AddAuthorization();
            // If using Kestrel:
            // If using Kestrel:
            builder.Services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }


        public static void Configure(IApplicationBuilder app)
        {
            app.UseOwin(buildFunc => buildFunc.UseNancy());
            // Configure the HTTP request pipeline.
            //app.UseHttpsRedirection();

            app.UseAuthorization();








        }
    }

}