using Core.Application.Mapping;
using Infrastructure.Persistence.PostgreSQL;
using System.Reflection;
using AutoMapper;
using Core.Application;
using Core.Application.Interfaces;
using WebUI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IUserDbContext).Assembly));
});

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<UserContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception ex) { }
}

app.UseCustomExeptionHandler();
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");




app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();
