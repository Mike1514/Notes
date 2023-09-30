using System.Reflection;
using Notes.Application.Common.Mappings;
using Notes.Application.Interfaces;
using Microsoft.AspNetCore.Builder;
using Notes.Application;
using Notes.Persistance;
using MediatR;
using Notes.Persistence;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(INotesDbContext).Assembly));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    try
    {
        var context = scope.ServiceProvider.GetRequiredService<NotesDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception)
    {
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
