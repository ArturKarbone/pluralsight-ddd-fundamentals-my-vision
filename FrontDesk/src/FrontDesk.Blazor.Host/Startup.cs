﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace FrontDesk.Blazor.Host
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddServerSideBlazor();
      services.AddControllersWithViews();
      services.AddRazorPages();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UsePathBase("/");

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseWebAssemblyDebugging();
      }
      else
      {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        //app.UseHsts();
      }

      //app.UseHttpsRedirection();
      app.UseBlazorFrameworkFiles();
      app.UseStaticFiles();

      app.UseRouting();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapRazorPages();
        endpoints.MapControllers();
        endpoints.MapBlazorHub();
        endpoints.MapFallbackToFile("index.html");
      });
    }
  }
}
