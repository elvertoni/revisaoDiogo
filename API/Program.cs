using API.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>(options => options.UseSqlite("Data Source = revisao.db; Cache = shared"));

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

app.UseCors(
    cors => cors.AllowAnyOrigin().
    AllowAnyMethod().
    AllowAnyHeader()
);


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
