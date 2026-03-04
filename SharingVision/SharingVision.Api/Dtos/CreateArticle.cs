using System.ComponentModel.DataAnnotations;

namespace SharingVision.Api.Dtos;

public record class CreateArticle
(
    [Required][StringLength(200)] string Title,
    [Required] string Content,
    [Required][StringLength(100)] string Category,
    DateTime Created_date,
    DateTime Updated_date,
    [Required][Range(1, 3)] int StatusId
);