using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iox_sample_app.Helper;
using iox_sample_app.Helper.Interfaces;
using iox_sample_app.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace iox_sample_app
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
            services.AddControllers();
            var ioxSettingsSection = Configuration.GetSection("iox_settings");
            services.Configure<IoxSettings>(ioxSettingsSection);
            services.AddTransient<ISignatureVerifier, SignatureVerifier>();
            services.AddHttpClient("iox_auth", c =>
            {
                c.BaseAddress = new Uri("https://stagingintegration.ioxfleet.co.za/api/Auth/RequestToken");
            });
            services.AddHttpClient("iox", c =>
            {
                c.BaseAddress = new Uri("https://stagingintegration.ioxfleet.co.za/api/external/");
                c.DefaultRequestHeaders.Add("tenant", ioxSettingsSection.Get<IoxSettings>().tenantId);
            });
            services.AddSingleton<IMemoryTokenStore, MemoryTokenStore>();
            services.AddSingleton<IAPIService, APIService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
