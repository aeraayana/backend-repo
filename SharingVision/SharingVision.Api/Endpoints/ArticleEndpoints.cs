using System.Security.Policy;
using Microsoft.EntityFrameworkCore;
using SharingVision.Api.Data;
using SharingVision.Api.Dtos;
using SharingVision.Api.Models;

namespace SharingVision.Api.Endpoints;

public static class ArticleEndpoints
{
    const string GetArticleEndpointName = "getArticle";
    
    public static void MapArticlesEndpoint(this WebApplication app)
    {
        var group = app.MapGroup("article");
        // GET /article/index/pageSize
        group.MapGet("/{index}/{pageSize}", async (SharingVisionContext dbContext, int index, int pageSize) 
            => await dbContext.Articles
                .Include(article => article.Status)
                .OrderByDescending(article => article.Id)
                .Take(pageSize)
                .Skip((index - 1) * pageSize)
                .Select(article => new ArticleSummary(
                    article.Id,
                    article.Title,
                    article.Category,
                    article.Content,
                    article.Created_date,
                    article.Updated_date,
                    article.Status!.Name
                ))
                .ToListAsync());

        // GET /article/id/
        group.MapGet("/{id}/", async (int id, SharingVisionContext dbContext) => {
            var article = await dbContext.Articles.FindAsync(id);

            return article is null ? Results.NotFound() : Results.Ok(new ArticleDetails(
                article.Id,
                article.Title,
                article.Content,
                article.Category,
                article.Created_date,
                article.Updated_date,
                article.StatusId
            ));
        }).WithName(GetArticleEndpointName);

        // POST /article/
        group.MapPost("/", async (CreateArticle newArticle, SharingVisionContext dbContext) =>
        {
            ArticleModel article = new()
            {
                Title = newArticle.Title,
                Content = newArticle.Content,
                Category = newArticle.Category,
                Created_date = DateTime.UtcNow,
                Updated_date = DateTime.UtcNow,
                StatusId = newArticle.StatusId
            };

            dbContext.Articles.Add(article);
            await dbContext.SaveChangesAsync();

            ArticleDetails articleDto = new(
                article.Id,
                article.Title,
                article.Content,
                article.Category,
                article.Created_date,
                article.Updated_date,
                article.StatusId
            );

            return  Results.CreatedAtRoute(GetArticleEndpointName, new {id = articleDto.Id}, articleDto);
        });

        // PUT /article/id/
        group.MapPut("/{id}/", async (int id, UpdateArticle updatedArticle, SharingVisionContext dbContext) =>
        {
            var existingArticle = await dbContext.Articles.FindAsync(id);

            if (existingArticle is null){
                return Results.NotFound();
            }

            existingArticle.Title = updatedArticle.Title;
            existingArticle.Content = updatedArticle.Content;
            existingArticle.Category = updatedArticle.Category;
            existingArticle.Updated_date = DateTime.UtcNow;
            existingArticle.StatusId = updatedArticle.StatusId;

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        // DELETE /article/id/
        group.MapDelete("/{id}/", async (int id, SharingVisionContext dbContext) =>
        {
            await dbContext.Articles
                .Where(article => article.Id == id)
                .ExecuteDeleteAsync();

            return Results.NoContent();
        });
    }

}
