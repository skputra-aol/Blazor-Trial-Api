using BlazorApp.Helpers;
using BlazorApp.Services;
/////using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using MudBlazor.Services;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;


            /////var builder = WebAssemblyHostBuilder.CreateDefault(args);
            var builder = WebApplication.CreateBuilder(args);
            /////builder.RootComponents.Add<App>("app");

            builder.Services.AddRazorPages(); //server
            builder.Services.AddServerSideBlazor();//server
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddMudServices();
            builder.Services
                .AddScoped<IAccountService, AccountService>()
                .AddScoped<IOrganizerService, OrganizerService>()
                .AddScoped<IAlertService, AlertService>()
                .AddScoped<IHttpService, HttpService>()
                .AddScoped<ILocalStorageService, LocalStorageService>();

            // configure http client
            builder.Services.AddScoped(x => {
                var apiUrl = new Uri(builder.Configuration["apiUrl"]);

                // use fake backend if "setBackend" is "true" in appsettings.json
                // if (builder.Configuration["setBackend"] == "true")
                // {
                //     var setBackendHandler = new setBackendHandler(x.GetService<ILocalStorageService>());
                //     return new HttpClient(setBackendHandler) { BaseAddress = apiUrl };
                // }

                return new HttpClient() { BaseAddress = apiUrl };
            });

            /////var host = builder.Build();
            var app = builder.Build(); //server


            //var scope = app.Services.CreateScope();
            // var accountService = scope.ServiceProvider.GetRequiredService<IAccountService>();
            // await accountService.Initialize();

            /////await host.RunAsync(); 

            app.UseStaticFiles();
            app.UseRouting();
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");
            app.Run();

