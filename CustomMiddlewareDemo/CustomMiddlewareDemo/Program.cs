using CustomMiddlewareDemo.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

// 1. Global Exception Middleware
app.UseMiddleware<GlobalExceptionMiddleware>();

// 2. Request Logging Middleware
app.UseMiddleware<RequestLoggingMiddleware>();

// 3. Custom Header Middleware
app.UseMiddleware<CustomHeaderMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
