using Microsoft.Extensions.Options;
using MyAkademi_TakeAway.Catalog.Services.CategoryServices;
using MyAkademi_TakeAway.Catalog.Services.FeatureServices;
using MyAkademi_TakeAway.Catalog.Services.ProductServices;
using MyAkademi_TakeAway.Catalog.Services.SliderServices;
using MyAkademi_TakeAway.Catalog.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ISliderServices, SliderService>();
builder.Services.AddScoped<ICategoryServices, CategoryService>();
builder.Services.AddScoped<IProductServices, ProductService>();
builder.Services.AddScoped<IFeatureServices, FeatureService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
