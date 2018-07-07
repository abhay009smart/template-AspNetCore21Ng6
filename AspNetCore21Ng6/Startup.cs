using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AspNetCore21Ng6.Models;

namespace AspNetCore21Ng6
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
      var connection = @"Server=tcp:[DB_SERVER],1433;Initial Catalog=[DB_NAME];Persist Security Info=False;User ID=[USERNAME];Password=[PASSWORD];MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
      services.AddDbContext<BloggingContext>(options => options.UseSqlServer(connection));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();
      app.UseDefaultFiles();
      app.UseStaticFiles();
      app.UseMvc();
      //app.Run(async (context) =>
      //{
      //    await context.Response.WriteAsync("Hello World!");
      //});
    }
  }
}
