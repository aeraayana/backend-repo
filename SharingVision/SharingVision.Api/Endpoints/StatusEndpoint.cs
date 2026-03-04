using Microsoft.EntityFrameworkCore;
using SharingVision.Api.Data;
using SharingVision.Api.Dtos;

namespace SharingVision.Api.Endpoints;

public static class StatusEndpoint
{
    public static void MapStatusEndpoint(this WebApplication app)
    {
        var group = app.MapGroup("/status");
        group.MapGet("/", async (SharingVisionContext dbContext) => await dbContext.Status
            .Select(status => new Status(status.Id, status.Name ))
            .AsNoTracking()
            .ToListAsync());
    }
}
