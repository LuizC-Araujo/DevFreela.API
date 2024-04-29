using DevFreela.API.Models;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<OpeningTimeOption>(builder.Configuration.GetSection("OpeningTime"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<DevFreelaDbContext>();

builder.Services.AddScoped<IProjectService, ProjectService>();

// objeto igual para toda aplica��o enquanto estiver inicializada
// builder.Services.AddSingleton<LifeCycleClass>(e => new LifeCycleClass { Name = "Initial Stage" });

// uma inst�ncia por requisi��o
// builder.Services.AddScoped<LifeCycleClass>(e => new LifeCycleClass { Name = "Initial Stage" });

// uma inst�ncia por classe
// builder.Services.AddTransient<LifeCycleClass>(e => new LifeCycleClass { Name = "Initial Stage" });

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

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
