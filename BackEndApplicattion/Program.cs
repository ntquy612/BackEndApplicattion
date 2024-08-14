using BackEndApplicattion.Data;
using BackEndApplicattion.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddDbContext<DBContext>(option =>
//{
//    option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
//});
var app = builder.Build();

app.MapControllers();
app.UseRouting();
app.MapGet("/", () => "Hello World!");

app.Run();
