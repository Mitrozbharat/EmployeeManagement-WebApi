
using EmployeeManagement.Application;
using EmployeeManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register services in the correct order
            builder.Services.AddInfrastructureServices(builder.Configuration); // First, DB + Repository
            builder.Services.AddApplicationServices(); // Then, Service Layer
             



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
