using Wordsmith.Core.Services;
using Wordsmith.Core.Repositories;
using Wordsmith.Core.Contexts;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    var builder = new NpgsqlConnectionStringBuilder
    {
        Host = Environment.GetEnvironmentVariable("PG_HOST"),
        Port = int.TryParse(Environment.GetEnvironmentVariable("PG_PORT"), out var val) ? val : 5432,
        Username = Environment.GetEnvironmentVariable("PG_USER"),
        Password = Environment.GetEnvironmentVariable("PG_PASSWORD"),
        Database = Environment.GetEnvironmentVariable("PG_DATABASE")
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
// builder.Services.AddHttpsRedirection(options =>
// {
//     options.HttpsPort = 5001;
// });

builder.Services.AddControllers();
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

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
