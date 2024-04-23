
using ACMDotNetCore.ConsoleApp;
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
DapperExample dapperExample = new DapperExample();
dapperExample.Run();
Console.ReadLine();