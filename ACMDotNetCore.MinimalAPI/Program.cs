using ACMDotNetCore.MinimalAPI.Db;
using ACMDotNetCore.MinimalAPI.Feacture.Blog;
using ACMDotNetCore.MinimalAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Formats.Asn1;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(otp =>
{
    otp.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
},
  ServiceLifetime.Transient,
  ServiceLifetime.Transient);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGet("/",() => "Hello World");
//BlogService.MapBlgs(app);
//reverse use this keyword in IEndpoint...//
app.MapBlogs(); // this are call extension method
app.Run();

