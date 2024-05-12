using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ACMDotNetCore.ConsoleAppHttpClientExamples
{
    internal class HttpClientExample
    {
        private readonly HttpClient _client = new HttpClient() { BaseAddress = new Uri("https://localhost:7176") };
        private readonly string _blogendpoint = "api/Blog";
        public async Task RunAsync()
        {
            // await ReadAsync();
            await EditAsync(1);
            await EditAsync(8);
        }
        public async Task ReadAsync()
        {
           
            var task = await _client.GetAsync(_blogendpoint);
            if (task.IsSuccessStatusCode)
            {
                var jsonStr = await task.Content.ReadAsStringAsync();
                List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;
                foreach (var blog in lst)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(blog));
                    //OR
                    Console.WriteLine($"Title=>{blog.BlogTitle}");
                    Console.WriteLine($"Author=>{blog.BlogAuthor}");
                    Console.WriteLine($"Content=>{blog.BlogContent}");
                }
            }
        }
        public async Task EditAsync(int id)
        {
            var task = await _client.GetAsync($"{_blogendpoint}/{id}");
            if (task.IsSuccessStatusCode)
            {
                var jsonStr = await task.Content.ReadAsStringAsync();
               var item = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;
                Console.WriteLine(JsonConvert.SerializeObject(item));
                    //OR
                Console.WriteLine($"Title=>{item.BlogTitle}");
                Console.WriteLine($"Author=>{item.BlogAuthor}");
                Console.WriteLine($"Content=>{item.BlogContent}");
            }
            else
            {
                var message=await task.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }
        public async Task CreatAsync(string title,string author,string content)
        {
            BlogModel blog = new BlogModel() 
            { 
               BlogTitle = title,
               BlogAuthor = author,
               BlogContent= content
            };
            string blogJson=JsonConvert.SerializeObject(blog);
            HttpContent contentJson = new StringContent(blogJson,Encoding.UTF8, Application.Json);
            var respone = await _client.PostAsync(_blogendpoint, contentJson);
            if(respone.IsSuccessStatusCode)
            {
                string message=await respone.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }
        public async Task DeleteAsync(int id)
        {
            var task = await _client.DeleteAsync($"{_blogendpoint}/{id}");
            if (task.IsSuccessStatusCode)
            {
                var message = await task.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                var message = await task.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }
    }
}

