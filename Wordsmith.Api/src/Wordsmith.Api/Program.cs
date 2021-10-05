using Wordsmith.Core.Services;
using Wordsmith.Core.Repositories;
using Wordsmith.Core.Contexts;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var variable = (string key) => Environment.GetEnvironmentVariable(key) ?? builder.Configuration.GetValue<string>(key);

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    var builder = new NpgsqlConnectionStringBuilder
    {
        Host = variable("PG_HOST"),
        Port = int.TryParse(variable("PG_PORT"), out var val) ? val : 5432,
        Username = variable("PG_USER"),
        Password = variable("PG_PASSWORD"),
        Database = variable("PG_DATABASE"),
        SslMode = SslMode.Prefer
    };

    var connectionString = builder.ToString();

    options.UseNpgsql(connectionString, b =>
    {
        b.MigrationsAssembly("Wordsmith.Core");
    });
});

// Add services to the container.
builder.Services.AddTransient<IWordTransformationRepository, WordTransformationRepository>();
builder.Services.AddTransient<IWordReversalService, WordReversalService>();
builder.Services.AddTransient<IDatabaseContext, DatabaseContext>();

builder.Services.AddControllers().AddFluentValidation(s =>
{
    s.RegisterValidatorsFromAssemblyContaining<Program>();
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Wordsmith.Api", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(p =>
    {
        p.WithOrigins("http://localhost:3000");
        p.AllowAnyHeader();
        p.AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Wordsmith.Api v1"));
}

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run(app.Environment.IsDevelopment() ? "http://localhost:7272" : null);