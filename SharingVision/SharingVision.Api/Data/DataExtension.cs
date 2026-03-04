using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;

namespace SharingVision.Api.Data;

public static class DataExtension
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<SharingVisionContext>();
        dbContext.Database.Migrate();
    }

    public static void ConnectDb(this WebApplicationBuilder builder)
    {
        var connectionString = "server=localhost;port=3306;database=SharingVision;user=root;password=localhost";
        
        builder.Services.AddMySQLServer<SharingVisionContext>(connectionString);
    }
}
