using apbd11_cw5.DAL;
using apbd11_cw5.Repositories;
using apbd11_cw5.Services;
using Microsoft.EntityFrameworkCore;

namespace apbd11_cw5;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        // Add services to the container.
        builder.Services.AddAuthorization();
        builder.Services.AddControllers();
        builder.Services.AddDbContext<FarmacyDBContext>(opt =>
        {
            opt.UseSqlServer(connectionString);
        });
        
        builder.Services.AddScoped<IPatientsRepository, PatientsRepository>();
        builder.Services.AddScoped<IPatientsService, PatientsService>();
        builder.Services.AddScoped<IPrescriptionsRepository, PrescriptionsRepository>();
        builder.Services.AddScoped<IPrescriptionsService, PrescriptionsService>();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}