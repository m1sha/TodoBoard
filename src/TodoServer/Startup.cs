using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoBoard.Core.Entities;
using TodoBoard.Core.Entities.Validators;
using TodoBoard.Db;
using TodoServer.Filters;
using TodoServer.Hubs;
using TodoServer.Middleware;
using TodoServer.Models.Services;
using TodoServer.Models.Services.Intf;


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
      services.AddMvc().AddFluentValidation();
      services.AddControllersWithViews();
      services.AddSignalR();

      var options = new DbContextOptionsBuilder<TodoBoardDbContext>()
                   .UseSqlServer(Configuration.GetConnectionString("TodoBoard"))
                   .Options;

      var storage = new DbTodoBoardStorage(() => new TodoBoardDbContext(options));
      storage.CreateIfNotExists();

      services.AddSingleton<ITodoService, TodoService>(_ => new TodoService(storage));
      services.AddSingleton<IUserService, UserService>(_ => new UserService(storage));

      services.AddTransient<IValidator<TodoItem>, TodoItemValidator>();
      services.AddScoped<ValidationAttribute>();
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
