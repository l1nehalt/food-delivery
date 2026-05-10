using KitchenService;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddData(builder.Configuration)
    .AddServices()
    .AddRabbitMq()
    .AddSwagger()
    .AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();