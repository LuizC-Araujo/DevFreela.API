using DevFreela.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<OpeningTimeOption>(builder.Configuration.GetSection("OpeningTime"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// objeto igual para toda aplicação enquanto estiver inicializada
builder.Services.AddSingleton<LifeCycleClass>(e => new LifeCycleClass { Name = "Initial Stage" });

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
