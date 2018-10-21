using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace test_dotnet_core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddElm();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseElmPage();
                app.UseElmCapture();

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();


            app.UseStatusCodePagesWithRedirects("~/{0}.html");
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                //Si le [name] est un TrucCool => appel Home/OneOfTrucCool/[name]
                routes.MapRoute(
                    name: "OneTrucCool",
                    template: "TrucCool/{name=OneOfTrucCool}",
                    defaults: new {controller = "Home", action = "OneOfTrucCool" },
                    constraints: new {OneOfTrucCool = new OneOfTrucCoolConstraint(Configuration)}
                );
            });
        }

        class OneOfTrucCoolConstraint : IRouteConstraint
        {
            private readonly string[] _ListTrucCool;

            public OneOfTrucCoolConstraint(IConfiguration configuration)
            {

                var sectionCOnfiguration = configuration.GetSection("TrucCools");
                _ListTrucCool = sectionCOnfiguration.Get<Dictionary<string, string>>().Keys.ToArray();
            }
            
            public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values,
                RouteDirection routeDirection)
            {
                var param = values["name"];

                return _ListTrucCool.Contains(param);
            }
        }

        
    }
}
