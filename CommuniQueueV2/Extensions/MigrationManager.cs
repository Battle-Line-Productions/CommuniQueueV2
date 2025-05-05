using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CommuniQueueV2.Extensions;

public static class MigrationManager
{
    public static async Task<WebApplication> MigrateDatabaseAsync(this WebApplication webApp)
    {
        using var scope = webApp.Services.CreateScope();
        await using var appContext = scope.ServiceProvider.GetRequiredService<CommuniQueueDbContext>();

        await appContext.Database.MigrateAsync();

        return webApp;
    }
}
