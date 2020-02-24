using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using TodoServer.Hubs;
using TodoServer.Middleware;
using TodoServer.Models.Services;
using TodoServer.Models.Services.Intf;
using TodoServer.Models.Storage;
using TodoServer.Models.Storage.Db;

namespace TodoServer
{
  public class Startup
  {
    public Startup(IConfiguration configuration, IWebHostEnvironment environment)
    {
      Configuration = configuration;
      Environment = environment;
    }

    public IConfiguration Configuration { get; }
    public IWebHostEnvironment Environment { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllersWithViews();
      services.AddSignalR();
      
      var settings = Configuration.GetSection("TodoStorageSettings").Get<TodoStorageSettings>();
      string rootPath = Environment.WebRootPath;
      settings.SqlInstallFileName = Path.Combine(rootPath, settings.SqlInstallFileName);

      var storage = DbStorageFactory.Create(settings);
      storage.CheckConnection();
      storage.CreateIfNotExists();

      services.AddSingleton<ITodoService, TodoService>(_ => new TodoService(storage));
      services.AddSingleton<IUserService, UserService>(_ => new UserService(storage));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseMiddleware(typeof(ErrorHandlingMiddleware));
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");

        endpoints.MapHub<TodoCrudSyncHub>("/crudSyncHub");
      });
    }
  }
}
