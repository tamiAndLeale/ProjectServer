using BL;
using DL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Entities;
using Microsoft.OpenApi.Models;

using Microsoft.EntityFrameworkCore;
using NLog;
using Microsoft.AspNetCore.Http;
using System;

namespace ProjectServer
{
    public class Startup
    {
        //private  ILogger<Startup> _logger;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjectServer", Version = "v1" });
            });
            object p = services.AddDbContext<CTContext>(options => options.UseSqlServer("Server=DESKTOP-R5RADSP;Database=CT;Trusted_Connection=True;"), ServiceLifetime.Scoped);
            //"Data Sorce=srv2/pupils;Initial Catalog=CT;Integrated Security=True;Pooling=False"
            services.AddScoped<IUserDL, UserDL>();
            services.AddScoped<IUserBL, UserBL>();
            services.AddScoped<IPortfolioDL, PortfolioDL>();
            services.AddScoped<IPortfolioBL, PortfolioBL>();
            services.AddScoped<IPortfolioTypeBL, PortfolioTypeBL>();
            services.AddScoped<IPortfolioTypeDL, PortfolioTypeDL>();
            services.AddScoped<IOutputDocumentBL, OutputDocumentBL>();
            services.AddScoped<IOutputDocumentDL, OutputDocumentDL>();
            services.AddScoped<IInputDocumentBL, InputDocumentBL>();
            services.AddScoped<IInputDocumentDL, InputDocumentDL>();
            services.AddScoped<IDocumentTypeBL, DocumentTypeBL>();
            services.AddScoped<IDocumentTypeDL, DocumentTypeDL>();


            services.AddScoped<IPortfolioFolderBL, PortfolioFolderBL>();
            services.AddScoped<IPortfolioFolderDL, PortfolioFolderDL>();
            services.AddScoped<IPersonDL, PersonDL>();
            services.AddAutoMapper(typeof(Startup));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILogger<Startup> logger)
        {
            // _logger = logger;
            //_logger.LogInformation("hello");
            logger.LogInformation("hello");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectServer v1"));
            }
            app.UseResponseCaching();
            app.Use(async (context, next) =>
            {
                context.Response.GetTypedHeaders().CacheControl =
                    new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        Public = true,
                        
                        MaxAge = TimeSpan.FromSeconds(60)
                    };
                context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
                    new string[] { "Accept-Encoding" };

                await next();
            });
            app.UseCors("AllowAll");

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseErrorsToNlogMiddleware();
            app.Map("/api", app2 =>
            {
                app2.UseRouting();
                app2.UseRaitingMiddleware();
                app2.UseAuthorization();

                app2.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            });

            // app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
