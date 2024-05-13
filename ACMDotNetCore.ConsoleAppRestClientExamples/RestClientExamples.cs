using Microsoft.VisualBasic;
using RestSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ACMDotNetCore.ConsoleAppRestClientExamples
{
    internal class RestClientExamples
    {
        private readonly RestClient _client = new RestClient(new Uri("https://localhost:7176"));
        private readonly string _blogendpoint = "api/Blog";
        public async Task RunAsync()
        {
              await ReadAsync();
              await CreateAsync("Title1", "Author1", "Content");
           // await UpdateAsync(3003, "Title1", "Author1", "Content");
        }
        private async Task ReadAsync()
        {
            RestRequest request = new RestRequest(_blogendpoint,Method.Get);
            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = response.Content;
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
            RestRequest request = new RestRequest($"{_blogendpoint}/{id}", Method.Get);
            var respone = await _client.ExecuteAsync(request);
            if (respone.IsSuccessStatusCode)
            {
                var jsonStr = respone.Content;
                var item = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;
                Console.WriteLine(JsonConvert.SerializeObject(item));
                //OR
                Console.WriteLine($"Title=>{item.BlogTitle}");
                Console.WriteLine($"Author=>{item.BlogAuthor}");
                Console.WriteLine($"Content=>{item.BlogContent}");
            }
            else
            {
                var message = respone.Content;
                Console.WriteLine(message);
            }
        }
        private async Task CreateAsync(string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            var restrequest = new RestRequest(_blogendpoint, Method.Post);
            restrequest.AddBody(blog);
            var respone=await _client.ExecuteAsync(restrequest);
            if (respone.IsSuccessStatusCode)
            {
                string message = respone.Content!;
                Console.WriteLine(message);
            }
        }
        private async Task UpdateAsync(int id, string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            var restRequest = new RestRequest($"{_blogendpoint}/{id}", Method.Put);
            restRequest.AddBody(blog);
            var respone = await _client.ExecuteAsync(restRequest);

            if (respone.IsSuccessStatusCode)
            {
                string message = respone.Content!;
                Console.WriteLine(message);
            }

        }
        private async Task DeleteAsync(int id)
        {
            RestRequest restRequest = new RestRequest($"{_blogendpoint}/{id}",Method.Delete);
            var respone = await _client.ExecuteAsync(restRequest);
            if (respone.IsSuccessStatusCode)
            {
                var message = respone.Content;
                Console.WriteLine(message);
            }
            else
            {
                var message = respone.Content;
                Console.WriteLine(message);
            }
        }
    }
}

