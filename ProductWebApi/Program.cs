using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using Shopping.Application;
using Shopping.Infrastructure;
using Shopping.TelegramBotService;
using TelegramSink;
using Serilog.Sinks;
using ProductWebApi.ExceptionHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.FileProviders;

namespace ProductWebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
         
                Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .MinimumLevel.Warning()
                .WriteTo.Console()
                 .Enrich.FromLogContext()
                .Enrich.WithEnvironmentUserName()
                .Enrich.WithClientIp()
                .Enrich.WithEnvironmentName()
                .WriteTo.TeleSink(
                 telegramApiKey: builder.Configuration.GetConnectionString("TelegramToken"),
                 telegramChatId: "33780774",
                 minimumLevel: LogEventLevel.Error
        
                 )
                .CreateLogger();

                builder.Host.UseSerilog();

                builder.Services.AddControllers();
                IConfiguration configuration = builder.Configuration;

             
                builder.Services.AddApplication(configuration);
                builder.Services.AddInfrastructure(configuration);
                //builder.Services.AddTelegramBot(configuration, builder.Environment.WebRootPath + "\\photos\\");

 
               builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
               {
                 options.LoginPath = "/";
                 options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                 options.Cookie.MaxAge = options.ExpireTimeSpan;
                 options.SlidingExpiration = true;

                });
                builder.Services.AddAuthorization();
                builder.Services.AddHttpContextAccessor();
                
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen(
                 //   options =>
                 //   {
                 //    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                 //    {
                 //        Scheme = "Bearer",
                 //        BearerFormat = "JWT",
                 //        In = ParameterLocation.Header,
                 //        Name = "Authorization",
                 //        Description = "Bearer Authentication with JWT Token",
                 //        Type = SecuritySchemeType.Http
                 //    });
                 //    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                 //       {{
                 //   new OpenApiSecurityScheme()
                 //   {
                 //      Reference=new OpenApiReference()
                 //      {
                 //          Id="Bearer",
                 //          Type=ReferenceType.SecurityScheme
                 //      }
                 //   },
                 //   new List<string>()
                 //    } });
                 //}
                 );

                var app = builder.Build();
            
                app.UseDirectoryBrowser("/pages");
                app.UseFileServer();
                app.UseStaticFiles();
                app.UseDefaultFiles();

                app.UseHttpsRedirection();
                app.UseExceptionMiddleware();
               
                app.UseAuthentication();
                app.UseAuthorization();
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }
                app.MapControllers();

               await app.RunAsync();

        }
    }
}