using Owin;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;


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

            app.UseSignalR(route =>
            {
                route.MapHub<ChatHub>("/chathub");
            });

            //app.UseStaticFiles();

            //app.Run(context => context.Response.WriteAsync("hello world"));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           

            services.AddSignalR();
        }


    }


}
