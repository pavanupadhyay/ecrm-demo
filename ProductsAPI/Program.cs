using Microsoft.EntityFrameworkCore;
using ProductsAPI;
using ProductsAPI.Data.Entities;
using ProductsAPI.Repository;
using ProductsAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>((options) => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

// Product
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

if (!builder.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(o => o.DocumentTitle = "ECRM v1.0");
}

app.MapControllers();
app.Run();
