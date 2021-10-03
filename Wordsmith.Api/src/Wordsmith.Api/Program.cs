using Wordsmith.Core.Services;
using Wordsmith.Core.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IWordTransformationRepository, WordTransformationRepository>();
builder.Services.AddSingleton<IWordReversalService, WordReversalService>();
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
