using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// ✅ Add Controllers (IMPORTANT)
builder.Services.AddControllers();

// ✅ Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Database (MySQL)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

var app = builder.Build();

// ✅ Swagger Middleware
app.UseSwagger();
app.UseSwaggerUI();

// ❌ REMOVE WeatherForecast + minimal APIs

app.UseHttpsRedirection();

app.UseAuthorization();

// ✅ Map Controllers (VERY IMPORTANT)
app.MapControllers();

app.Run();