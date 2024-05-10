using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using DevFreela.Application.Commands.ProjectCommands.CreateProject;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence.Repositories;
using FluentValidation.AspNetCore;
using DevFreela.Application.Validators;
using FluentValidation;
using DevFreela.Core.Services;
using DevFreela.Infrastructure.AuthServices;
//using DevFreela.API.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// builder.Services.Configure<OpeningTimeOption>(builder.Configuration.GetSection("OpeningTime"));

string connectionString = builder.Configuration.GetConnectionString("DevFreelaCs");
builder.Services.AddDbContext<DevFreelaDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();


//builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)));
builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateProjectCommandValidator>();

//.NET 5
//builder.Services.AddMediatR(typeof(CreateProjectCommand))
builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(CreateProjectCommand).Assembly); });
;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddScoped<IUserService, UserService>();


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

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
