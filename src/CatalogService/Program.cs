using CatalogService;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddData(builder.Configuration)
    .AddServices()
    .AddSwagger()
    .AddRabbitMq()
    .AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();