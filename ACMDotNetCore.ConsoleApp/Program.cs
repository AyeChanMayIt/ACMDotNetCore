using ACMDotNetCore.ConsoleApp.EFCoreExamples;
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
EFCore_Example EFCore=new EFCore_Example();
EFCore.Run();
Console.ReadLine();