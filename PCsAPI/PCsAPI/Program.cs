using PCsAPI.Data;
using Microsoft.EntityFrameworkCore;
using PCsAPI.Services;

namespace PCsAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();
        builder.Services.AddScoped<IDbService, DbService>();
        
        builder.Services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/openapi/v1.json", "v1");
            });
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}