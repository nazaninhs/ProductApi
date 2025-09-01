using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// فعال کردن Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var products = new List<string> { "Laptop", "Phone", "Tablet" };

app.MapGet("/products", () => products);

app.MapPost("/products", (string name) =>
{
    products.Add(name);
    return Results.Ok(products);
});

// فعال کردن UI Swagger در محیط توسعه
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();