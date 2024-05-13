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
            // await EditAsync(1);
            // await EditAsync(8);
            // await CreateAsync("Title1", "Author1", "Content");
           await UpdateAsync(3003,"Title1", "Author1", "Content");
        }
        private async Task ReadAsync()
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
        private async Task EditAsync(int id)
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
        private async Task CreateAsync(string title,string author,string content)
        {
            BlogModel blog = new BlogModel()
            { 
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string blogJson=JsonConvert.SerializeObject(blog);
            HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, "Application/json");
            var respone=await _client.PostAsync(_blogendpoint,httpContent);
            if(respone.IsSuccessStatusCode)
            {
                string message=await respone.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }
        private async Task UpdateAsync(int id,string title,string author,string content)
        {
            BlogModel blog = new BlogModel()
            { 
                BlogTitle=title,
                BlogAuthor=author,
                BlogContent=content
            };
            string blogJson= JsonConvert.SerializeObject(blog);
            HttpContent httpcontent = new StringContent(blogJson, Encoding.UTF8, "Application/Json");
            var respone= await _client.PutAsync($"{_blogendpoint}/{id}", httpcontent);
            if(respone.IsSuccessStatusCode)
            {
                string message= await respone.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }

        }
        private async Task DeleteAsync(int id)
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

