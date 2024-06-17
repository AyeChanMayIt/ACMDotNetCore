using ACMDotNetCore.RestApi.Db;
using ACMDotNetCore.RestApi.Model;
using ACMDotNetCore.Shared;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Define Depentency Injection 
string connectionString = builder.Configuration.GetConnectionString("DbConnection")!;

    builder.Services.AddDbContext<AppDbContext>(otp =>
    {
        otp.UseSqlServer(connectionString);
    },
    ServiceLifetime.Transient,
    ServiceLifetime.Transient); // original is scope change to transient because of DbContext.

//builder.Services.AddScoped<AdoDotNetService>(n => new AdoDotNetService(""));
//builder.Services.AddScoped<DapperService>(n => new DapperService(""));

builder.Services.AddScoped(n => new AdoDotNetService(connectionString));
    builder.Services.AddScoped(n => new DapperService(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
