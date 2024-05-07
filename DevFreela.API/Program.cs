using DevFreela.API.Models;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.Services.Implementations;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using MediatR;
using DevFreela.API.Commands.ProjectCommands.CreateProject;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// builder.Services.Configure<OpeningTimeOption>(builder.Configuration.GetSection("OpeningTime"));

string connectionString = builder.Configuration.GetConnectionString("DevFreelaCs");
builder.Services.AddDbContext<DevFreelaDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();

//.NET 5
//builder.Services.AddMediatR(typeof(CreateProjectCommand))
builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(CreateProjectCommand).Assembly); });
;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IUserService, UserService>();


// objeto igual para toda aplicação enquanto estiver inicializada
// builder.Services.AddSingleton<LifeCycleClass>(e => new LifeCycleClass { Name = "Initial Stage" });

// uma instância por requisição
// builder.Services.AddScoped<LifeCycleClass>(e => new LifeCycleClass { Name = "Initial Stage" });

// uma instância por classe
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
