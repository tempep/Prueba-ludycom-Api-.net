using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductoDbContext>(opt => opt.UseInMemoryDatabase("ProductoList"));
builder.Services.AddControllers();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config => {
    config.DocumentName = "ProductoApi";
    config.Title = "ProductoApi v1";
    config.Version = "v1";
});

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseOpenApi();
    app.UseSwaggerUi(config => {
        config.DocumentTitle = "ProductoApi";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();