using WWDemo.Application.Products.Commands.AddProduct;
using WWDemo.Application.Products.Queries.GetAllProducts;

using WWDemo.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AddProductCommand).Assembly));

builder.Services.AddServiceDataLayer(builder.Configuration);

builder.Services.AddAutoMapper(typeof(GetAllProductsProfileMapper));

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
