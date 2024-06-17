using ACMDotNetCore.ConsoleApp.AdoDotNetExamples;
using ACMDotNetCore.ConsoleApp.DapperExamples;
using ACMDotNetCore.ConsoleApp.EFCoreExamples;
using ACMDotNetCore.ConsoleApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

//Ctrl + . >> Suggestion
//F9 >> Break Point

// => C# <=> DB

//AdoDotNetExaple adoDotNetExaple = new AdoDotNetExaple();
//adoDotNetExaple.Read();
//adoDotNetExaple.Create("Funny", "Mr.Bean", "Merry Cherist");
//adoDotNetExaple.Update(1002, "Thingyan", "Test Auhtour", "Thingyan Festival");
//adoDotNetExaple.Delete(1002);
//adoDotNetExaple.Edit(1002);
//Dapper
//DapperExample dapperExample = new DapperExample();
//dapperExample.Run();

    var connectionString = ConnectionStrings.SqlConnectionStringBuilder.ConnectionString;
    var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

    var serviceProvider = new ServiceCollection()
    .AddScoped(n => new AdoDotNetExaple(sqlConnectionStringBuilder))
    .AddScoped(n => new DapperExample(sqlConnectionStringBuilder))
    .AddScoped<EFCore_Example>()
    .AddDbContext<AppDbContext>(otp =>
        {
            otp.UseSqlServer(connectionString);
        })
    .BuildServiceProvider();
    
    var adoDotNetExample = serviceProvider.GetRequiredService<AdoDotNetExaple>();
    adoDotNetExample.Read();

    var dapperExample = serviceProvider.GetRequiredService<DapperExample>();
    dapperExample.Run();

//EFCore_Example EFCore=new EFCore_Example();
//EFCore.Run();
   Console.ReadLine();