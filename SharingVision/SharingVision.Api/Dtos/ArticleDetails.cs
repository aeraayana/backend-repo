namespace SharingVision.Api.Dtos;

public record class ArticleDetails
(
    int Id,
    string Title,
    string Content,
    string Category,
    DateTime Created_date,
    DateTime Updated_date,
    int StatusId
);
