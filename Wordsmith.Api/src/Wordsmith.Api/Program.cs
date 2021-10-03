using Wordsmith.Core.Services;
using Wordsmith.Core.Repositories;
using Wordsmith.Core.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext>(options =>
           options.UseNpgsql(builder.Configuration.GetConnectionString("Database"), b => b.MigrationsAssembly("Wordsmith.Core")));

// Add services to the container.
builder.Services.AddTransient<IWordTransformationRepository, WordTransformationRepository>();
builder.Services.AddTransient<IWordReversalService, WordReversalService>();
builder.Services.AddTransient<IDatabaseContext, DatabaseContext>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
