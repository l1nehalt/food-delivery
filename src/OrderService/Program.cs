using OrderService;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddData(builder.Configuration)
    .AddSwagger()
    .AddServices()
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