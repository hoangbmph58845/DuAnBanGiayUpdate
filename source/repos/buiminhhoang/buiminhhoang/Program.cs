using buiminhhoang.DataContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<FinalNet103Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
app.MapGet("/", () => "");

app.Run();
