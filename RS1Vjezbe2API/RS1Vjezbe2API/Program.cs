using Microsoft.EntityFrameworkCore;
using RS1Vjezbe2API.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// 1. Zamjena za AddOpenApi()
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<StudentStorage>();
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Main"))
);
var app = builder.Build();

// 2. Zamjena za MapOpenApi()
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();