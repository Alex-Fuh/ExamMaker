using ExamMaker.Data.Database;
using Microsoft.EntityFrameworkCore;

namespace ExamMaker;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddServiceDefaults();
        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        builder.AddNpgsqlDbContext<ExamMakerDbContext>("api-db");


        var app = builder.Build();

        // Apply migrations at runtime
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<ExamMakerDbContext>();
            await db.Database.MigrateAsync();
        }

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapDefaultEndpoints();
        app.MapControllers();

        await app.RunAsync();
    }
}