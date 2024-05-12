// See https://aka.ms/new-console-template for more information
using ACMDotNetCore.ConsoleAppHttpClientExamples;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

Console.WriteLine("Hello, World!");

HttpClientExample httpClientExample = new HttpClientExample();
await httpClientExample.RunAsync();
Console.WriteLine();

//HttpClient client = new HttpClient();
//var task = await client.GetAsync("https://localhost:7176/api/Blog");
//if(task.IsSuccessStatusCode)
//{
//    var jsonStr=await task.Content.ReadAsStringAsync();
//    Console.WriteLine(jsonStr);
//    List<BlogModel> lst=JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;
//    foreach(var blog in lst)
//    {
//        Console.WriteLine(JsonConvert.SerializeObject(blog));
//        //OR
//        Console.WriteLine($"Title=>{blog.BlogTitle}");
//        Console.WriteLine($"Author=>{blog.BlogAuthor}");
//        Console.WriteLine($"Content=>{blog.BlogContent}");
//    }
//}
