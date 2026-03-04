namespace SharingVision.Api.Dtos;

public record class ArticleSummary
(
    int Id,
    string Title,
    string Content,
    string Category,
    DateTime Created_date,
    DateTime Updated_date,
    string Status 
);
