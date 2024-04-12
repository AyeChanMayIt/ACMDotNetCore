
using ACMDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

//Ctrl + . >> Suggestion
//F9 >> Break Point

// => C# <=> DB

AdoDotNetExaple adoDotNetExaple = new AdoDotNetExaple();
//adoDotNetExaple.Read();
//adoDotNetExaple.Create("Funny", "Mr.Bean", "Merry Cherist");
adoDotNetExaple.Update(1102, "Thingyan", "Test Auhtour", "Thingyan Festival");