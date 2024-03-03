using Application.FoodDelivery.Mapping;
using Infra.Common.Extensions;
using Infra.FoodDelivery.Api.ErrorExceptionHandler;
using Infra.FoodDelivery.Persistence.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(
    typeof(Program).Assembly,
    typeof(FoodDeliveryMapper).Assembly,
    typeof(PersistenceFoodDeliveryMapper).Assembly
    );

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Exception handling
builder.Services.AddExceptionHandler<DefaultExceptionHandler>();
builder.Services.AddProblemDetails();

// Add dependency injection
builder.Services.AddApplicationDependencyInjection();
builder.Services.AddDomainDependencyInjection();
builder.Services.AddPersistenceDependencyInjection();

var app = builder.Build();

app.Urls.Add("http://localhost:5024");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.Urls.Add("http://192.168.1.137:5024");
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.Urls.Add("http://172.31.24.215:5024");
}

app.UseAuthorization();

app.MapControllers();

app.Run();
