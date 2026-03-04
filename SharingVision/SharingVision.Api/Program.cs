using System.Collections.Immutable;
using MySql.EntityFrameworkCore.Extensions;
using SharingVision.Api.Data;
using SharingVision.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();
builder.ConnectDb();

var app = builder.Build();

app.MapArticlesEndpoint();
app.MapStatusEndpoint();

app.MigrateDb();

app.Run();