using jsreport.AspNetCore;
using jsreport.Binary.Linux;
using jsreport.Local;
using jsreport.Types;
using PdfBuilder.Services;

namespace PdfBuilder
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddJsReport(new LocalReporting()
                .UseBinary(JsReportBinary.GetBinary())
                .KillRunningJsReportProcesses()
                .Configure((cfg) =>
                {
                    const int globalTimeout = 60000;
                    cfg.ReportTimeout = globalTimeout;
                    cfg.TemplatingEngines = new TemplatingEnginesConfiguration { Timeout = globalTimeout };
                    cfg.Chrome = new ChromeConfiguration { Strategy = ChromeStrategy.ChromePool, Timeout = globalTimeout, NumberOfWorkers = 8 };
                    cfg.HttpPort = 1000; // explicitly set port number because Azure Web App sets environment variable PORT which is used also by jsreport
                    return cfg;
                })
                .AsUtility()
                .Create());

            services.BootstrapPdfBuilderServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHttpsRedirection();
                app.UseHsts();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
