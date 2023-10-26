using ClassDemoWoodPelletLib.repository;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<WoodPelletRepository>(new WoodPelletRepository(true));


builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowAny",
     builder => builder.AllowAnyOrigin().
        AllowAnyMethod().
        AllowAnyHeader()
    );
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseAuthorization();

app.UseCors("AllowAny");
app.MapControllers();

app.Run();
