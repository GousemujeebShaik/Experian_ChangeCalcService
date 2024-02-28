
using Experian_ChangeCalcService.Services;
using Experian_ChangeCalcService.Services.Contract;
using Microsoft.OpenApi.Models;

namespace Experian_ChangeCalcService
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
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Change Calculator API", Version = "v1" });
            });

            //Register the services
            builder.Services.AddScoped<IChangeCalculatorService, ChangeCalculatorService>();
            builder.Services.AddScoped<IDenominationService, DenominationService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Change Calculator API V1");
                });
            }

            app.UseHttpsRedirection();
          

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
