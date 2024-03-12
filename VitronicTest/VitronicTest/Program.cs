
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using VitronicAPI.Infrastructure;
using VitronicAPI.Infrastructure.Data;

namespace VitronicTest
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      // Add services to the container.

      builder.Services.AddControllers();
      // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();

      var constring = builder.Configuration.GetConnectionString("sqlServer");
      builder.Services.AddDbContext<VitronicDbContext>(opt => { opt.UseSqlServer(constring); });

      builder.Services.AddScoped<ITrafficDataService, TrafficDataService>();
           

      var app = builder.Build();

      // Configure the HTTP request pipeline.
      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
      }

      app.UseHttpsRedirection();

      app.UseAuthorization();


      app.MapControllers();

      app.Run();
    }
  }
}
