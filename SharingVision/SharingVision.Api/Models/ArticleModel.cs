namespace SharingVision.Api.Models;

public class ArticleModel
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required string Category { get; set; }
    public required DateTime Created_date { get; set; }
    public required DateTime Updated_date { get; set; }
    public StatusModel? Status { get; set; }
    public int StatusId { get; set; }
}
