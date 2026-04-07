using KtraLab.DB.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 2. Add Controllers (tự thêm vì EMPTY không có sẵn)
builder.Services.AddControllers();

var app = builder.Build();

// 3. Map API controller endpoints
app.MapControllers();

app.Run();
