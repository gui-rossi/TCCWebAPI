using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TCCBusiness;
using TCCBusiness.DIBusiness;
using TCCRepositories.DIRepository;
using TCCRepositories.TCCContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR(o => o.EnableDetailedErrors = true);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "TCC API",
        Description = "API to manage data sent to the UI"
    });
});

DIBusiness.AddServices(builder.Services);
DIRepository.AddRepositories(builder.Services);

var app = builder.Build();

app.UseCors("AllowAll"); 
app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapHub<ChatHub>("/ChatHub");

app.MapControllers();

app.Run();
