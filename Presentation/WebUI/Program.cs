using Infrastructure.Persistence.PostgreSQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UserContext>(x => x.UseNpgsql(builder.Configuration.GetConnectionString("UserContext")));


var app = builder.Build();

app.Run(async (context) =>
{
    context.Response.WriteAsync("Hello Web!");
});

app.Run();
