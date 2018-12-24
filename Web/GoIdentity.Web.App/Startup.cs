using GoIdentity.BusinessAccess.Handlers;
using GoIdentity.Utilities.Constants;
using GoIdentity.Web.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace GoIdentity.Web.App
{
    public partial class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables();
            Configuration = builder.Build();

            ConnectionStrings.COMMON_CONNECTION_STRING = Configuration.GetSection("Data")["ErpCommonConnectionString:ConnectionString"];
            ConnectionStrings.COMMAND_TIMEOUT = int.Parse(Configuration.GetSection("AppSettings")["CommandTimeout"]);

            ConnectionStrings.REPORTS_OUTPUT_PATH = Configuration.GetSection("AppSettings")["ReportsOutputPath"];
            ConnectionStrings.DOCS_PATH = Configuration.GetSection("AppSettings")["DocsPath"];

            ConnectionStrings.GOOGLE_AUTH_SECRET_KEY = Configuration.GetSection("AppSettings")["GoogleAuthSecretKey"];
            ConnectionStrings.REDIRECT_URL_DOMAIN = Configuration.GetSection("AppSettings")["RedirectUrlDomain"];
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            //Invoke DI
            GoIdentity.DIContainer.ServiceLocator.Instance.LoadContainer(services);

            // Add framework services.
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            var tokenProvider = new RsaJwtTokenProvider("GoIdentityIssuer", "GoIdentityAudience", "GoIdentity7star&steps");
            services.AddSingleton<ITokenProvider>(tokenProvider);

#if DEBUG
            Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration.Active.DisableTelemetry = true;
#endif

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = tokenProvider.GetValidationParameters();
                });

            // This is for the [Authorize] attributes.
            services.AddAuthorization(auth =>
            {
                auth.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "API", Version = "v1" });
                c.OperationFilter<HeaderOperationFilter>();
            });

            services.AddSingleton(new HandlerContainer());

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            env.EnvironmentName = "Production";
            app.UseExceptionHandler("/session/error");

            app.UseDeveloperExceptionPage();

            //app.UseExceptionHandler("/session/error");

            app.UseCors("AllowAllOrigins");

            var defaultFilesOptions = new DefaultFilesOptions();
            defaultFilesOptions.DefaultFileNames.Clear();
            defaultFilesOptions.DefaultFileNames.Add("index.html");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });

            app.UseCors("AllowAll")
            .UseMvc()
            .UseDefaultFiles(defaultFilesOptions)
            .UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = context =>
                {
                    if (context.File.Name == "index.html")
                    {
                        context.Context.Response.Headers.Add("Cache-Control", "no-cache, no-store");
                        context.Context.Response.Headers.Add("Expires", "-1");
                    }
                }
            })
            .UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute("spa-fallback", new { controller = "Home", action = "" });
            });
        }
    }
}
