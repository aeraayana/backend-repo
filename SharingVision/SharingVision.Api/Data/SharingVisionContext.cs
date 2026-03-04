using Microsoft.EntityFrameworkCore;
using SharingVision.Api.Models;

namespace SharingVision.Api.Data;

public class SharingVisionContext(DbContextOptions<SharingVisionContext> options) : DbContext(options)
{
    public DbSet<ArticleModel> Articles => Set<ArticleModel>();
    public DbSet<StatusModel> Status => Set<StatusModel>();
}
