global using LearnifyAPI.Models;
using LearnifyAPI.Services;
using LearnifyAPI.Services.ServiceImpl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
builder.Services.AddScoped<IProgressService, ProgressService>();
builder.Services.AddDbContext<LearnifyContext>();

// Services CORS
builder.Services.AddCors(p => p.AddPolicy("CorsApp", builder =>
{
    builder
    .WithOrigins("*")
    .AllowAnyMethod()
    .AllowAnyHeader();
}));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
