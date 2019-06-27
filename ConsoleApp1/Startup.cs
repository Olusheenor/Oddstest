using Owin;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using OddServices;

namespace OddsServer
{

    public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
            
                app.MapHubs();
             }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseCors("CorsPolicy");

            app.UseSignalR(routes =>
            {
                routes.MapHub<MyHub>("/notifications");
            });

            //app.UseStaticFiles();

            //app.Run(context => context.Response.WriteAsync("hello world"));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("CorsPolicy",
               builder =>
               {
                   builder.AllowAnyMethod().AllowAnyHeader()
                          .WithOrigins("http://localhost:55830")
                          .AllowCredentials();
               }));
            services.AddSignalR();
            services.AddSingleton<IOddService, OddsService>()
           .AddSingleton<IDisplayService, DisplayService>()
           .AddSingleton<IUser, User>()
           
           .BuildServiceProvider();
        }


    }


}
